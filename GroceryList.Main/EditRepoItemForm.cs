using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroceryList.Main.Helpers;

namespace GroceryList.Main
{
    public partial class EditRepoItemForm : Form
    {
        GroceryItem ItemToEdit;

        public EditRepoItemForm(GroceryItem itemToEditIn)
        {
            ItemToEdit = itemToEditIn;

            InitializeComponent();

            SuspendLayout();

            ItemNameTextBox.Text = ItemToEdit.Name;

            foreach (var price in ItemToEdit.Prices)
            {
                switch (price.Store)
                {
                    case Helpers.Enums.Stores.Hannaford:
                        HannafordPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    case Helpers.Enums.Stores.Sams:
                        SamsPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    case Helpers.Enums.Stores.Shaws:
                        ShawsPriceBox.Value = MoneyShit.PenniesToDecimal(price.Price);
                        break;
                    default:
                        break;
                }
            }

            ResumeLayout();
        }
    }
}
