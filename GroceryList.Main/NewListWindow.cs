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

        public NewListWindow()
        {
            AvailableItemsRepo = new GroceryItemRepository();
            ListItemsRepo = new Dictionary<GroceryItem, int>();

            InitializeComponent();
        }

        private void MoveAvailableToList(GroceryItem itemToMove)
        {

        }

        private void MoveListToAvailable(GroceryItem itemToMove)
        {

        }
    }
}
