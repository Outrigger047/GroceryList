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
    public partial class EditListQuantityForm : Form
    {
        private int initialQuantity;
        private List<GroceryItem> _itemsToEdit;
        public List<GroceryItem> ItemsToEdit
        {
            get { return _itemsToEdit; }
        }

        public EditListQuantityForm()
        {
            initialQuantity = 1;

            InitializeComponent();

            SuspendLayout();
            QuantityUpDown.Value = 1;
            ResumeLayout();
        }

        public EditListQuantityForm(int initialQuantity)
        {
            this.initialQuantity = initialQuantity;

            InitializeComponent();

            SuspendLayout();
            QuantityUpDown.Value = initialQuantity;
            ResumeLayout();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
