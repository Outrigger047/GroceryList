using System;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class EditRepoItemForm : Form
    {
        public bool ItemUpdated { get; private set; }
        public GroceryItem ItemToEdit;

        public EditRepoItemForm(GroceryItem itemToEditIn)
        {
            ItemUpdated = false;
            ItemToEdit = itemToEditIn;

            InitializeComponent();

            SuspendLayout();

            ItemNameTextBox.Text = ItemToEdit.Name;

            foreach (var price in ItemToEdit.Prices)
            {
                switch (price.Store)
                {
                    case Enums.Stores.Hannaford:
                        HannafordPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    case Enums.Stores.Sams:
                        SamsPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    case Enums.Stores.Shaws:
                        ShawsPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    default:
                        break;
                }
            }

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

            Close();
        }
    }
}
