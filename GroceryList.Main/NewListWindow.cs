using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private bool listIsDirty;
        private string lastSaveAsPath;

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

            listIsDirty = false;

            AvailableItemsRepo = InternalItemsRepo.Items;
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

            string[] stores = Enum.GetNames(typeof(Enums.Stores));
            foreach (var item in stores)
            {
                StoreComboBox.Items.Add(item);
            }
            StoreComboBox.Text = DEFAULT_COMBOBOX_STORE;

            DoUiListBoxUpdateFromRepos();
            ResetFilterTextBox(AvailableFilterTextBox);
        }
        #endregion

        #region Private Methods
        private string CalclistTotalCost(Enums.Stores store)
        {
            return Math.Round(((decimal)CalcListTotalCost(store) / 100), 2).ToString();
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

            listIsDirty = false;

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
        }

        private void DoUiListBoxUpdateFromRepos()
        {
            SuspendLayout();

            RepositoryListBox.Items.Clear();
            ListListBox.Items.Clear();

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
            listIsDirty = true;

            RepositoryListBox.SelectedIndex = -1;
            AddToListButton.Enabled = false;
            ListClearListButton.Enabled = true;
            ListPrintButton.Enabled = true;
            ListSaveButton.Enabled = true;
            ListSaveAsButton.Enabled = true;

            ItemsMoved(this, new EventArgs());
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
                listIsDirty = false;
            }

            ItemsMoved(this, new EventArgs());
        }

        private void ResetFilterTextBox(TextBox textBoxToReset)
        {
            textBoxToReset.Text = DEFAULT_FILTER_TEXTBOX_VALUE;
            textBoxToReset.ForeColor = Color.LightGray;
        }

        private void AddItemFromForm(object sender, AddRepoItemForm.AddRepoItemEventArgs e)
        {
            InternalItemsRepo.Items.Add(e.ItemToAdd);
        }

        private void EditQuantityFromForm(object sender, EditListQuantityForm.EditListQuantityEventArgs e)
        {
            foreach (var item in e.ItemsToEdit)
            {
                ListItemsRepo[item.Key] = item.Value;
            }
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

            listIsDirty = false;
        }

        private void ReadListFromDisk(object sender, EventArgs e)
        {
            DoListClear();

            AvailableItemsRepo.Clear();

            DiskRepoHelpers.ReadListFromDisk(
                new System.IO.FileInfo(ListOpenFileDialog.FileName), ListItemsRepo, AvailableItemsRepo);



            listIsDirty = false;
            ItemsMoved(this, new EventArgs());
        }
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
            editItemForm.Show();
            editItemForm.OkButtonClicked += UpdateUiFromRepos;
            editItemForm.OkButtonClicked += InternalItemsRepo.WriteRepoToDisk;
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
                    AvailableItemsRepo.Remove(item);
                }

                RepoItemsChanged(this, new EventArgs());
                ItemsMoved(this, new EventArgs());
            }
        }

        private void RepoAddItemButton_Click(object sender, EventArgs e)
        {
            AddRepoItemForm addItemForm = new AddRepoItemForm();
            addItemForm.Show();

            addItemForm.OkButtonClicked += AddItemFromForm;
            addItemForm.OkButtonClicked += UpdateUiFromRepos;
            addItemForm.OkButtonClicked += InternalItemsRepo.WriteRepoToDisk;
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
            editQuantityForm.Show();
            editQuantityForm.EditListQuantityFormOkButtonClicked += EditQuantityFromForm;
            editQuantityForm.EditListQuantityFormOkButtonClicked += UpdateUiFromRepos;
        }

        private void ListSaveButton_Click(object sender, EventArgs e)
        {
            if (listIsDirty)
            {
                System.IO.FileInfo f = new System.IO.FileInfo(lastSaveAsPath);
                DiskRepoHelpers.WriteListToDisk(f, ListItemsRepo, AvailableItemsRepo);
            }
            else
            {
                ListSaveAsDialog.ShowDialog();
            }
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