using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class AddRepoItemForm : Form
    {
        private readonly string ERROR_MSG_DUPLICATE_ITEM = "Item already exists: ";
        private readonly string ERROR_MSG_MISSING_NAME = "Provide a valid name for this item";
        
        public GroceryItem ItemToAdd { get; private set; }

        private List<GroceryItem> ExistingRepoItems;

        public event EventHandler<AddRepoItemEventArgs> OkButtonClicked;

        public AddRepoItemForm(List<GroceryItem> existingRepoItems)
        {
            ExistingRepoItems = existingRepoItems;
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ItemNameTextBox.Text == "")
            {
                MessageBox.Show(ERROR_MSG_MISSING_NAME,
                    "Missing Item Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (ExistingRepoItems.Find(x => x.Name == ItemNameTextBox.Text) != null)
            {
                MessageBox.Show(ERROR_MSG_DUPLICATE_ITEM,
                    "Duplicate Item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                ItemToAdd = new GroceryItem(ItemNameTextBox.Text);

                if (HannafordPriceBox.Value != 0)
                {
                    ItemToAdd.AddNewPrice(Enums.Stores.Hannaford, MoneyShit.DecimalToPennies(HannafordPriceBox.Value));
                }

                if (SamsPriceBox.Value != 0)
                {
                    ItemToAdd.AddNewPrice(Enums.Stores.Sams, MoneyShit.DecimalToPennies(SamsPriceBox.Value));
                }

                if (ShawsPriceBox.Value != 0)
                {
                    ItemToAdd.AddNewPrice(Enums.Stores.Shaws, MoneyShit.DecimalToPennies(ShawsPriceBox.Value));
                }

                if (TraderJoesPriceBox.Value != 0)
                {
                    ItemToAdd.AddNewPrice(Enums.Stores.TraderJoes, 
                        MoneyShit.DecimalToPennies(TraderJoesPriceBox.Value));
                }

                OkButtonClicked(this, new AddRepoItemEventArgs(ItemToAdd));

                Close();
            }
        }

        public class AddRepoItemEventArgs : EventArgs
        {
            public GroceryItem ItemToAdd { get; private set; }

            public AddRepoItemEventArgs(GroceryItem itemToAdd)
            {
                ItemToAdd = itemToAdd;
            }
        }
    }
}
