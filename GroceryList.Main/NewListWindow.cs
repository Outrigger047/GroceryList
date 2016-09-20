using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class NewListWindow : Form
    {
        #region Fields/Trivial properties
        private readonly string CONFIRM_LIST_CLEAR = "Are you sure you want to clear the grocery list?";
        private readonly string CONFIRM_REPO_REMOVE_SINGLE = "Are you sure you want to remove this item?";
        private readonly string CONFIRM_REPO_REMOVE_MULTI = "Are you sure you want to remove these items?";
        private readonly string DEFAULT_FILTER_TEXTBOX_VALUE = "\uD83D\uDD0E Type to filter...";
        private readonly string DEFAULT_COMBOBOX_STORE = "Hannaford";
        private readonly string DEFAULT_PERSIST_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string DEFAULT_PERSIST_EXTENSION = ".nom";
        private readonly string TITLE = "Grocery List Manager";
        private readonly string SAVE_QUIT_PROMPT = "Save changes to list before quitting?";

        private string lastSaveAsPath = "";

        private bool unsavedChanges;

        public GroceryItemRepository InternalItemsRepo { get; private set; }
        public List<GroceryItem> AvailableItemsRepo { get; private set; }
        public Dictionary<GroceryItem, int> ListItemsRepo { get; private set; }

        public event EventHandler ItemsMoved;
        public event EventHandler RepoItemsChanged;
        public event EventHandler InfoStoreSelectedChanged;
        #endregion

        #region Constructor
        public NewListWindow()
        {
            // GroceryItemRepository constructor loads repository from disk
            try
            {
                InternalItemsRepo = new GroceryItemRepository();
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Header row invalid"))
                {
                    MessageBox.Show(
                        "Repository header row invalid.",
                        "Repository Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (e.Message.Contains("Duplicate item found"))
                {
                    MessageBox.Show(
                        "Duplicate item found: " + e.InnerException.Message,
                        "Repository Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            AvailableItemsRepo = new List<GroceryItem>();
            foreach (var item in InternalItemsRepo.Items)
            {
                AvailableItemsRepo.Add(item);
            }

            ListItemsRepo = new Dictionary<GroceryItem, int>();

            ItemsMoved += UpdateUiFromRepos;
            RepoItemsChanged += InternalItemsRepo.WriteRepoToDisk;
            InfoStoreSelectedChanged += UpdateUiFromRepos;

            InitializeComponent();

            ListSaveAsDialog.InitialDirectory = DEFAULT_PERSIST_PATH;
            ListSaveAsDialog.DefaultExt = DEFAULT_PERSIST_EXTENSION;
            ListSaveAsDialog.FileOk += SaveListToDisk;

            ListOpenFileDialog.InitialDirectory = DEFAULT_PERSIST_PATH;
            ListOpenFileDialog.DefaultExt = DEFAULT_PERSIST_EXTENSION;
            ListOpenFileDialog.FileOk += ReadListFromDisk;

            FormClosing += SaveOnQuit;

            string[] stores = Enum.GetNames(typeof(Enums.Stores));
            foreach (var item in stores)
            {
                StoreComboBox.Items.Add(item);
            }
            StoreComboBox.Text = DEFAULT_COMBOBOX_STORE;

            Text = TITLE;

            unsavedChanges = false;

            DoUiListBoxUpdateFromRepos();
            ResetFilterTextBox(AvailableFilterTextBox);
        }
        #endregion

        #region Private Methods
        private string CalclistTotalCost(Enums.Stores store)
        {
            return Math.Round(((decimal)CalcListTotalCost(store) / 100), 2).ToString("0.00");
        }

        private int CalcListTotalCost(Enums.Stores store)
        {
            int total = 0;

            foreach (var item in ListItemsRepo)
            {
                int itemUnitPrice;

                StorePrice currentPrice = item.Key.Prices.Find(x => x.Store == store);
                itemUnitPrice = currentPrice?.Price ?? 0;

                total += (itemUnitPrice * item.Value);
            }

            return total;
        }

        private void DoListClear()
        {
            ListClearListButton.Enabled = false;
            ListSaveButton.Enabled = false;
            ListSaveAsButton.Enabled = false;
            ListPrintButton.Enabled = false;
            ListQuantityButton.Enabled = false;

            List<GroceryItem> itemsToMove = new List<GroceryItem>();

            foreach (var item in ListItemsRepo)
            {
                itemsToMove.Add(item.Key);
            }

            ListItemsRepo.Clear();

            foreach (var item in itemsToMove)
            {
                AvailableItemsRepo.Add(item);
            }

            ItemsMoved(this, new EventArgs());
            unsavedChanges = false;
        }

        private void DoUiListBoxUpdateFromRepos()
        {
            SuspendLayout();

            RepositoryListBox.Items.Clear();
            ListListBox.Items.Clear();

            RefreshAvailableRepo();

            foreach (var item in AvailableItemsRepo)
            {
                RepositoryListBox.Items.Add(item.ListBoxRowText);
            }

            foreach (var item in ListItemsRepo)
            {
                ListListBox.Items.Add(string.Concat(item.Value, "x  ", item.Key.ListBoxRowText));
            }

            ResumeLayout();
        }

        private void MoveAvailableToList(GroceryItem itemToMove)
        {
            AvailableItemsRepo.Remove(itemToMove);
            ListItemsRepo.Add(itemToMove, 1);

            RepositoryListBox.SelectedIndex = -1;
            AddToListButton.Enabled = false;
            ListClearListButton.Enabled = true;
            ListPrintButton.Enabled = true;
            ListSaveButton.Enabled = true;
            ListSaveAsButton.Enabled = true;

            ItemsMoved(this, new EventArgs());
            unsavedChanges = true;
        }

        private void MoveListToAvailable(GroceryItem itemToMove)
        {
            ListItemsRepo.Remove(itemToMove);
            AvailableItemsRepo.Add(itemToMove);

            ListListBox.SelectedIndex = -1;
            RemoveFromListButton.Enabled = false;
            if (ListItemsRepo.Count < 1)
            {
                ListClearListButton.Enabled = false;
                ListSaveAsButton.Enabled = false;
                ListSaveButton.Enabled = false;
                ListPrintButton.Enabled = false;
                ListQuantityButton.Enabled = false;

                unsavedChanges = false;
            }
            else
            {
                ListSaveButton.Enabled = true;
                unsavedChanges = true;
            }

            ItemsMoved(this, new EventArgs());
        }

        private void RefreshAvailableRepo()
        {
            AvailableItemsRepo.Clear();

            List<string> listItemsRepoNames = new List<string>();
            foreach (var item in ListItemsRepo)
            {
                listItemsRepoNames.Add(item.Key.Name);
            }

            foreach (var item in InternalItemsRepo.Items)
            {
                if (!listItemsRepoNames.Contains(item.Name))
                {
                    AvailableItemsRepo.Add(item);
                }
            }
        }

        private void ResetFilterTextBox(TextBox textBoxToReset)
        {
            textBoxToReset.Text = DEFAULT_FILTER_TEXTBOX_VALUE;
            textBoxToReset.ForeColor = Color.LightGray;
        }

        private void UpdateMainFormTitle()
        {
            Text = TITLE + " - " + lastSaveAsPath;
        }

        #region Private Methods - Event handlers
        private void AddItemFromForm(object sender, AddRepoItemForm.AddRepoItemEventArgs e)
        {
            InternalItemsRepo.Items.Add(e.ItemToAdd);

            ItemsMoved(this, new EventArgs());
        }

        private void EditQuantityFromForm(object sender, EditListQuantityForm.EditListQuantityEventArgs e)
        {
            foreach (var item in e.ItemsToEdit)
            {
                ListItemsRepo[item.Key] = item.Value;
            }

            unsavedChanges = true;
            ListSaveButton.Enabled = true;
        }

        private void UpdateUiFromRepos(object sender, EventArgs e)
        {
            DoUiListBoxUpdateFromRepos();

            var selectedStore = (Enums.Stores)Enum.Parse(typeof(Enums.Stores), (string)StoreComboBox.SelectedItem);
            InfoTotalPriceLabel.Text = "$" + CalclistTotalCost(selectedStore);
            InfoNumItemsLabel.Text = ListListBox.Items.Count.ToString();
        }

        private void SaveListToDisk(object sender, EventArgs e)
        {
            lastSaveAsPath = ListSaveAsDialog.FileName;

            DiskRepoHelpers.WriteListToDisk(
                new System.IO.FileInfo(lastSaveAsPath), ListItemsRepo, AvailableItemsRepo);

            UpdateMainFormTitle();
            unsavedChanges = false;
        }

        private void SaveOnQuit(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                DialogResult result = MessageBox.Show(SAVE_QUIT_PROMPT, 
                    "Save Changes", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    if (lastSaveAsPath != "")
                    {
                        System.IO.FileInfo f = new System.IO.FileInfo(lastSaveAsPath);
                        DiskRepoHelpers.WriteListToDisk(f, ListItemsRepo, AvailableItemsRepo);
                    }
                    else
                    {
                        ListSaveAsDialog.ShowDialog();
                    }
                }
            }
        }

        private void ReadListFromDisk(object sender, EventArgs e)
        {
            DoListClear();
            AvailableItemsRepo.Clear();
            //InternalItemsRepo.Items.Clear();

            DiskRepoHelpers.ReadListFromDisk(
                new System.IO.FileInfo(ListOpenFileDialog.FileName), ListItemsRepo, AvailableItemsRepo);

            //RefreshAvailableRepo();

            lastSaveAsPath = ListOpenFileDialog.FileName;

            UpdateMainFormTitle();

            ListPrintButton.Enabled = true;
            ListClearListButton.Enabled = true;
            ListSaveAsButton.Enabled = true;

            ItemsMoved(this, new EventArgs());
            unsavedChanges = false;
        }
        #endregion

        #region Private Methods - Printing
        private void PrintGroceryList()
        {
            PrintDialog dialog = new PrintDialog();
            PrintDocument document = new PrintDocument();
            PrinterSettings settings = new PrinterSettings();
            PaperSize size = new PaperSize("Custom", 100, 200);

            dialog.Document = document;
            dialog.Document.DefaultPageSettings.PaperSize = size;

            document.DefaultPageSettings.PaperSize.Height = 1100;
            document.DefaultPageSettings.PaperSize.Width = 850;
            document.PrintPage += new PrintPageEventHandler(PrintGroceryList_PrintPage);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                document.Print();
            }
        }

        private void PrintGroceryList_PrintPage(object sender, PrintPageEventArgs e)
        {
            var selectedStore = (Enums.Stores)Enum.Parse(typeof(Enums.Stores), (string)StoreComboBox.SelectedItem);
            List<string> documentContents = PrepDocumentContents(selectedStore);

            Graphics graphics = e.Graphics;
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);

            int fontHeight = Convert.ToInt32(font.GetHeight());
            int startX = 50;
            int startY = 55;
            int offset = 40;

            foreach (var line in documentContents)
            {
                graphics.DrawString(line, font, brush, startX, startY + offset);
                offset = offset + fontHeight + 3;
            }
        }

        private List<string> PrepDocumentContents(Enums.Stores store)
        {
            List<string> documentContents = new List<string>();
            decimal runningTotal = 0;
            int runningItemCount = 0;

            documentContents.Add(lastSaveAsPath);
            documentContents.Add("");

            documentContents.Add(store.ToString());
            documentContents.Add("");

            foreach (var item in ListItemsRepo)
            {
                StorePrice unitCostPrice = item.Key.Prices.Find(x => x.Store == store);

                runningItemCount = runningItemCount + 1;

                StringBuilder lineText = new StringBuilder();

                // Checkbox
                lineText.Append("\u2610  ");

                // Quantity
                lineText.Append(item.Value.ToString());
                lineText.Append("x   ");

                // Item
                lineText.Append(item.Key.Name.ToString());

                if (unitCostPrice != null)
                {
                    lineText.Append("       ");

                    // Price
                    decimal unitCost = MoneyShit.PenniesToDecimal(unitCostPrice.Price);
                    decimal totalItemCost = unitCost * item.Value;

                    runningTotal = runningTotal + totalItemCost;

                    if (item.Value > 1)
                    {
                        lineText
                            .Append("$" +
                            totalItemCost.ToString("0.00") +
                            " (" + "$" + unitCost.ToString("0.00") + " ea.)");
                    }
                    else
                    {
                        lineText.Append("$" + unitCost.ToString("0.00"));
                    }
                }

                documentContents.Add(lineText.ToString());
            }

            documentContents.Add("");
            documentContents.Add("");
            documentContents.Add("Total: $" + runningTotal.ToString("0.00"));
            documentContents.Add("Number of items: " + runningItemCount);

            return documentContents;
        }
        #endregion
        #endregion

        #region UI Interaction Event Handlers
        #region ListBox Selection
        private void ListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListListBox.SelectedIndex > -1)
            {
                RemoveFromListButton.Enabled = true;
                ListQuantityButton.Enabled = true;
                AddToListButton.Enabled = false;
                RepoEditItemButton.Enabled = false;
                RepoRemoveItemButton.Enabled = false;

                RepositoryListBox.SelectedIndex = -1;
            }
        }

        private void RepositoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepositoryListBox.SelectedIndex > -1)
            {
                AddToListButton.Enabled = true;
                RepoRemoveItemButton.Enabled = true;
                RemoveFromListButton.Enabled = false;
                ListQuantityButton.Enabled = false;
                if (RepositoryListBox.SelectedItems.Count == 1)
                {
                    RepoEditItemButton.Enabled = true;
                }
                else
                {
                    RepoEditItemButton.Enabled = false;
                }

                ListListBox.SelectedIndex = -1;
            }
        }

        private void ListListBox_DoubleClick(object sender, EventArgs e)
        {
            if (ListListBox.SelectedItems.Count > 0)
            {
                Dictionary<GroceryItem, int> itemsToEdit = new Dictionary<GroceryItem, int>();

                Dictionary<GroceryItem, int>.KeyCollection groceryItems = ListItemsRepo.Keys;

                foreach (var item in ListListBox.SelectedItems)
                {
                    string itemNameFromListBox = Regex.Split(item.ToString(), @"\s{2,}")[1];
                    IEnumerable<GroceryItem> g = groceryItems.Where(x => x.Name == itemNameFromListBox);
                    foreach (var gItem in g)
                    {
                        itemsToEdit.Add(gItem, ListItemsRepo[gItem]);
                    }
                }

                EditListQuantityForm editQuantityForm = new EditListQuantityForm(itemsToEdit);
                editQuantityForm.EditListQuantityFormOkButtonClicked += EditQuantityFromForm;
                editQuantityForm.EditListQuantityFormOkButtonClicked += UpdateUiFromRepos;
                editQuantityForm.Location = new Point(Location.X + 200, Location.Y + 100);
                editQuantityForm.Show(); 
            }
        }
        #endregion

        #region Add/Remove Buttons
        private void AddToListButton_Click(object sender, EventArgs e)
        {
            List<GroceryItem> itemsToMove = new List<GroceryItem>();

            foreach (var item in RepositoryListBox.SelectedItems)
            {
                itemsToMove.Add(
                    AvailableItemsRepo.Find(x => x.Name == Regex.Split(item.ToString(), @"\s{2,}")[0]));
            }

            foreach (var item in itemsToMove)
            {
                MoveAvailableToList(item);
            }

            RepoEditItemButton.Enabled = false;
            RepoRemoveItemButton.Enabled = false;

            ResetFilterTextBox(AvailableFilterTextBox);
        }

        private void RemoveFromListButton_Click(object sender, EventArgs e)
        {
            List<GroceryItem> itemsToMove = new List<GroceryItem>();

            foreach (var item in ListListBox.SelectedItems)
            {
                itemsToMove.Add(
                    ListItemsRepo.Keys.ToList().Find(x => x.Name == Regex.Split(item.ToString(), @"\s{2,}")[1]));
            }

            foreach (var item in itemsToMove)
            {
                MoveListToAvailable(item);
            }

            ListQuantityButton.Enabled = false;
        }
        #endregion

        #region Repo ListBox Buttons
        private void RepoEditItemButton_Click(object sender, EventArgs e)
        {
            GroceryItem itemToEdit = InternalItemsRepo
                .GetItemFromString(Regex.Split(RepositoryListBox.SelectedItem.ToString(), @"\s{2,}")[0]);

            EditRepoItemForm editItemForm = new EditRepoItemForm(itemToEdit);
            editItemForm.OkButtonClicked += UpdateUiFromRepos;
            editItemForm.OkButtonClicked += InternalItemsRepo.WriteRepoToDisk;
            editItemForm.Location = new Point(Location.X + 200, Location.Y + 100);
            editItemForm.Show();
        }

        private void RepoRemoveItemButton_Click(object sender, EventArgs e)
        {
            List<GroceryItem> itemsToRemove = new List<GroceryItem>();

            foreach (var item in RepositoryListBox.SelectedItems)
            {
                itemsToRemove.Add(
                    AvailableItemsRepo.Find(x => x.Name == Regex.Split(item.ToString(), @"\s{2,}")[0]));
            }

            DialogResult r = MessageBox.Show(
                itemsToRemove.Count > 1 ? CONFIRM_REPO_REMOVE_MULTI : CONFIRM_REPO_REMOVE_SINGLE,
                "Confirm Item Removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                foreach (var item in itemsToRemove)
                {
                    InternalItemsRepo.Items.Remove(item);
                }

                RepoItemsChanged(this, new EventArgs());
                ItemsMoved(this, new EventArgs());
            }
        }

        private void RepoAddItemButton_Click(object sender, EventArgs e)
        {
            AddRepoItemForm addItemForm = new AddRepoItemForm(InternalItemsRepo.Items);
            addItemForm.OkButtonClicked += AddItemFromForm;
            addItemForm.OkButtonClicked += UpdateUiFromRepos;
            addItemForm.OkButtonClicked += InternalItemsRepo.WriteRepoToDisk;
            addItemForm.Location = new Point(Location.X + 200, Location.Y + 100);
            addItemForm.Show();
        }
        #endregion

        #region AvailableFilterTextBox
        private void AvailableFilterTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (AvailableFilterTextBox.Text == DEFAULT_FILTER_TEXTBOX_VALUE)
            {
                AvailableFilterTextBox.ForeColor = Color.Gray;
            }
        }

        private void AvailableFilterTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (AvailableFilterTextBox.Text == DEFAULT_FILTER_TEXTBOX_VALUE)
            {
                AvailableFilterTextBox.ForeColor = Color.LightGray;
            }
        }

        private void AvailableFilterTextBox_Enter(object sender, EventArgs e)
        {
            if (AvailableFilterTextBox.Text == DEFAULT_FILTER_TEXTBOX_VALUE)
            {
                AvailableFilterTextBox.Text = "";
                AvailableFilterTextBox.ForeColor = Color.Black;
            }
            else if (AvailableFilterTextBox.Text != "") // WHY DOESNT THIS WORK??
            {
                AvailableFilterTextBox.SelectAll();
            }
        }

        private void AvailableFilterTextBox_Leave(object sender, EventArgs e)
        {
            if (AvailableFilterTextBox.Text == "" | !RepositoryListBox.Focused)
            {
                ResetFilterTextBox(AvailableFilterTextBox);
                DoUiListBoxUpdateFromRepos();
            }
        }

        private void AvailableFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AvailableFilterTextBox.Text != "" &&
                AvailableFilterTextBox.Text != DEFAULT_FILTER_TEXTBOX_VALUE)
            {
                RepositoryListBox.Items.Clear();

                foreach (var item in AvailableItemsRepo)
                {
                    if (item.Name.ToLower().Contains(AvailableFilterTextBox.Text.ToLower()))
                    {
                        RepositoryListBox.Items.Add(item.ListBoxRowText);
                    }
                }
            }
            else if (AvailableFilterTextBox.Text == "")
            {
                RepositoryListBox.ClearSelected();
                DoUiListBoxUpdateFromRepos();
            }
        }

        private void AvailableFilterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Handle user pressing ESC while filter text box is in focus
            if (e.KeyChar == 27)
            {
                RepositoryListBox.Focus();
                ResetFilterTextBox(AvailableFilterTextBox);
                DoUiListBoxUpdateFromRepos();
            }
        }
        #endregion

        #region List ListBox Buttons
        private void ListClearListButton_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                CONFIRM_LIST_CLEAR,
                "Comfirm Clear Grocery List",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                DoListClear();
            }
        }

        private void ListQuantityButton_Click(object sender, EventArgs e)
        {
            Dictionary<GroceryItem, int> itemsToEdit = new Dictionary<GroceryItem, int>();

            Dictionary<GroceryItem, int>.KeyCollection groceryItems = ListItemsRepo.Keys;

            foreach (var item in ListListBox.SelectedItems)
            {
                string itemNameFromListBox = Regex.Split(item.ToString(), @"\s{2,}")[1];
                IEnumerable<GroceryItem> g = groceryItems.Where(x => x.Name == itemNameFromListBox);
                foreach (var gItem in g)
                {
                    itemsToEdit.Add(gItem, ListItemsRepo[gItem]);
                }
            }

            EditListQuantityForm editQuantityForm = new EditListQuantityForm(itemsToEdit);
            editQuantityForm.EditListQuantityFormOkButtonClicked += EditQuantityFromForm;
            editQuantityForm.EditListQuantityFormOkButtonClicked += UpdateUiFromRepos;
            editQuantityForm.Location = new Point(Location.X + 200, Location.Y + 100);
            editQuantityForm.Show();
        }

        private void ListSaveButton_Click(object sender, EventArgs e)
        {
            if (lastSaveAsPath != "")
            {
                System.IO.FileInfo f = new System.IO.FileInfo(lastSaveAsPath);
                DiskRepoHelpers.WriteListToDisk(f, ListItemsRepo, AvailableItemsRepo);
            }
            else
            {
                ListSaveAsDialog.ShowDialog();
            }

            ListSaveButton.Enabled = false;
        }

        private void ListSaveAsButton_Click(object sender, EventArgs e)
        {
            ListSaveAsDialog.ShowDialog();
        }

        private void OpenListButton_Click(object sender, EventArgs e)
        {
            if (ListListBox.Items.Count > 0)
            {
                DialogResult r = MessageBox.Show(
                    CONFIRM_LIST_CLEAR,
                    "Comfirm Clear Grocery List",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (r == DialogResult.Yes)
                {
                    ListOpenFileDialog.ShowDialog();
                }
            }
            else
            {
                ListOpenFileDialog.ShowDialog();
            }
        }

        private void ListPrintButton_Click(object sender, EventArgs e)
        {
            PrintGroceryList();
        }
        #endregion

        #region Information Pane

        private void StoreComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            InfoStoreSelectedChanged(this, new EventArgs());
        }

        #endregion

        #endregion
    }
}