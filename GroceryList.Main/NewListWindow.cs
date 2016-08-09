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
        private readonly string DEFAULT_FILTER_TEXTBOX_VALUE = "\uD83D\uDD0E Type to filter...";

        public GroceryItemRepository InternalItemsRepo { get; private set; }
        public List<GroceryItem> AvailableItemsRepo { get; private set; }
        public Dictionary<GroceryItem, int> ListItemsRepo { get; private set; }

        public event EventHandler ItemsMoved;

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
                    System.Windows.Forms.MessageBox.Show(
                        "Repository header row invalid.",
                        "Repository Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (e.Message.Contains("Duplicate item found"))
                {
                    System.Windows.Forms.MessageBox.Show(
                        "Duplicate item found: " + e.InnerException.Message,
                        "Repository Import Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            AvailableItemsRepo = InternalItemsRepo.Items;
            ListItemsRepo = new Dictionary<GroceryItem, int>();

            ItemsMoved += UpdateUiFromRepos;

            InitializeComponent();

            DoUiListBoxUpdateFromRepos();
            ResetFilterTextBox(AvailableFilterTextBox);
        }

        private void MoveAvailableToList(GroceryItem itemToMove)
        {
            AvailableItemsRepo.Remove(itemToMove);
            ListItemsRepo.Add(itemToMove, 1);

            RepositoryListBox.SelectedIndex = -1;
            AddToListButton.Enabled = false;

            EventArgs e = new EventArgs();
            ItemsMoved(this, e);
        }

        private void MoveListToAvailable(GroceryItem itemToMove)
        {
            ListItemsRepo.Remove(itemToMove);
            AvailableItemsRepo.Add(itemToMove);

            ListListBox.SelectedIndex = -1;
            RemoveFromListButton.Enabled = false;

            EventArgs e = new EventArgs();
            ItemsMoved(this, e);
        }

        private void UpdateUiFromRepos(object sender, EventArgs e)
        {
            DoUiListBoxUpdateFromRepos();

            InfoTotalPriceLabel.Text = "$" + CalclistTotalCost(Enums.Stores.Hannaford);
            InfoNumItemsLabel.Text = ListListBox.Items.Count.ToString();
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

        private string CalclistTotalCost(Enums.Stores store)
        {
            return Math.Round(((decimal)CalcListTotalCost(store) / 100), 2).ToString();
        }

        private void ResetFilterTextBox(System.Windows.Forms.TextBox textBoxToReset)
        {
            textBoxToReset.Text = DEFAULT_FILTER_TEXTBOX_VALUE;
            textBoxToReset.ForeColor = Color.LightGray;
        }

        private void RepositoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepositoryListBox.SelectedIndex > -1)
            {
                AddToListButton.Enabled = true;
                RemoveFromListButton.Enabled = false;
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

        private void ListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListListBox.SelectedIndex > -1)
            {
                RemoveFromListButton.Enabled = true;
                AddToListButton.Enabled = false;
                RepoEditItemButton.Enabled = false;

                RepositoryListBox.SelectedIndex = -1;
            }
        }

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

        private void RepoEditItemButton_Click(object sender, EventArgs e)
        {
            GroceryItem itemToEdit = InternalItemsRepo
                .GetItemFromString(Regex.Split(RepositoryListBox.SelectedItem.ToString(), @"\s{2,}")[0]);

            EditRepoItemForm editItemForm = new EditRepoItemForm(itemToEdit);
            editItemForm.Show();
            editItemForm.OkButtonClicked += UpdateUiFromRepos;
        }
    }
}
