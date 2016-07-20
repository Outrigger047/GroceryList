using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryList.Main
{
    public partial class NewListWindow : Form
    {
        public GroceryItemRepository AvailableItemsRepo { get; private set; }
        public Dictionary<GroceryItem, int> ListItemsRepo { get; private set; }

        public event EventHandler ItemsMoved;

        public NewListWindow()
        {
            AvailableItemsRepo = new GroceryItemRepository();
            ListItemsRepo = new Dictionary<GroceryItem, int>();

            ItemsMoved += UpdateUiFromRepos;

            InitializeComponent();

            DoUiListBoxUpdateFromRepos();
        }

        private void MoveAvailableToList(GroceryItem itemToMove)
        {
            ListItemsRepo.Add(itemToMove, 1);
            AvailableItemsRepo.Items.Find(x => x.Name == itemToMove.Name).SetIsOnListFlag(true);

            EventArgs e = new EventArgs();
            ItemsMoved(this, e);
        }

        private void MoveListToAvailable(GroceryItem itemToMove)
        {
            ListItemsRepo.Remove(itemToMove);
            AvailableItemsRepo.Items.Find(x => x.Name == itemToMove.Name).SetIsOnListFlag(false);

            EventArgs e = new EventArgs();
            ItemsMoved(this, e);
        }

        private void UpdateUiFromRepos(object sender, EventArgs e)
        {
            DoUiListBoxUpdateFromRepos();
        }

        private void DoUiListBoxUpdateFromRepos()
        {
            SuspendLayout();

            RepositoryListBox.Items.Clear();
            ListListBox.Items.Clear();

            foreach (var item in AvailableItemsRepo.Items)
            {
                RepositoryListBox.Items.Add(item.ListBoxRowText);
            }

            foreach (var item in ListItemsRepo)
            {
                ListListBox.Items.Add(item.Key.ListBoxRowText);
            }

            ResumeLayout();
        }
    }
}
