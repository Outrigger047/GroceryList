﻿using System;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class AddRepoItemForm : Form
    {
        private readonly string ERROR_MSG_MISSING_NAME = "Provide a valid name for this item";

        public GroceryItem ItemToAdd { get; private set; }

        public event EventHandler<AddRepoItemEventArgs> OkButtonClicked;

        public AddRepoItemForm()
        {
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