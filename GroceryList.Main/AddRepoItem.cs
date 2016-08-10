using System;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class AddRepoItemForm : Form
    {
        public bool ItemUpdated { get; private set; }
        public GroceryItem ItemToEdit;

        public event EventHandler OkButtonClicked;

        public AddRepoItemForm()
        {
            ItemUpdated = false;

            InitializeComponent();

            SuspendLayout();

            ItemNameTextBox.Text = ItemToEdit.Name;


            ResumeLayout();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ItemNameTextBox.Text != ItemToEdit.Name)
            {
                ItemToEdit.ChangeName(ItemNameTextBox.Text);
                ItemUpdated = true;
            }

            if (HannafordPriceBox.Value != 0)
            {
                ItemToEdit.AddNewPrice(Enums.Stores.Hannaford, MoneyShit.DecimalToPennies(HannafordPriceBox.Value));
                ItemUpdated = true;
            }

            if (SamsPriceBox.Value != 0)
            {
                ItemToEdit.AddNewPrice(Enums.Stores.Sams, MoneyShit.DecimalToPennies(SamsPriceBox.Value));
                ItemUpdated = true;
            }

            if (ShawsPriceBox.Value != 0)
            {
                ItemToEdit.AddNewPrice(Enums.Stores.Shaws, MoneyShit.DecimalToPennies(ShawsPriceBox.Value));
                ItemUpdated = true;
            }

            EventArgs okEventArgs = new EventArgs();
            OkButtonClicked(this, okEventArgs);

            Close();
        }
    }
}
