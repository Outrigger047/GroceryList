using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class NewListWindow : Form
    {
        public GroceryItemRepository InternalItemsRepo { get; private set; }
        public List<GroceryItem> AvailableItemsRepo { get; private set; }
        public Dictionary<GroceryItem, int> ListItemsRepo { get; private set; }

        public event EventHandler ItemsMoved;

        public NewListWindow()
        {
            // GroceryItemRepository constructor loads repository from disk
            InternalItemsRepo = new GroceryItemRepository();

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
                ListListBox.Items.Add(item.Key.ListBoxRowText);
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
            textBoxToReset.Text = "\uD83D\uDD0E Type to filter...";
            textBoxToReset.ForeColor = Color.Gray;
        }

        private void RepositoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepositoryListBox.SelectedIndex > -1)
            {
                AddToListButton.Enabled = true;
                RemoveFromListButton.Enabled = false;

                ListListBox.SelectedIndex = -1;
            }
        }

        private void ListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListListBox.SelectedIndex > -1)
            {
                RemoveFromListButton.Enabled = true;
                AddToListButton.Enabled = false;

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
        }

        private void RemoveFromListButton_Click(object sender, EventArgs e)
        {
            List<GroceryItem> itemsToMove = new List<GroceryItem>();

            foreach (var item in ListListBox.SelectedItems)
            {
                itemsToMove.Add(
                    ListItemsRepo.Keys.ToList().Find(x => x.Name == Regex.Split(item.ToString(), @"\s{2,}")[0]));
            }

            foreach (var item in itemsToMove)
            {
                MoveListToAvailable(item);
            }
        }
    }
}
