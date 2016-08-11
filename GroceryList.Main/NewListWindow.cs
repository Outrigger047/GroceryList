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
        private readonly string CONFIRM_LIST_CLEAR = "Are you sure you want to clear the grocery list?";
        private readonly string CONFIRM_REPO_REMOVE_SINGLE = "Are you sure you want to remove this item?";
        private readonly string CONFIRM_REPO_REMOVE_MULTI = "Are you sure you want to remove these items?";
        private readonly string DEFAULT_FILTER_TEXTBOX_VALUE = "\uD83D\uDD0E Type to filter...";

        public GroceryItemRepository InternalItemsRepo { get; private set; }
        public List<GroceryItem> AvailableItemsRepo { get; private set; }
        public Dictionary<GroceryItem, int> ListItemsRepo { get; private set; }

        public event EventHandler ItemsMoved;
        public event EventHandler RepoItemsChanged;

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

            AvailableItemsRepo = InternalItemsRepo.Items;
            ListItemsRepo = new Dictionary<GroceryItem, int>();

            ItemsMoved += UpdateUiFromRepos;
            RepoItemsChanged += InternalItemsRepo.WriteRepoToDisk;

            InitializeComponent();

            DoUiListBoxUpdateFromRepos();
            ResetFilterTextBox(AvailableFilterTextBox);
        }

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

        private void UpdateUiFromRepos(object sender, EventArgs e)
        {
            DoUiListBoxUpdateFromRepos();

            InfoTotalPriceLabel.Text = "$" + CalclistTotalCost(Enums.Stores.Hannaford);
            InfoNumItemsLabel.Text = ListListBox.Items.Count.ToString();
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
                ListClearListButton.Enabled = false;
                ListSaveButton.Enabled = false;
                ListSaveAsButton.Enabled = false;
                ListPrintButton.Enabled = false;

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
        }
        #endregion
        #endregion
    }
}