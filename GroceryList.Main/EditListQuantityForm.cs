using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GroceryList.Main
{
    public partial class EditListQuantityForm : Form
    {
        private Dictionary<GroceryItem, int> _itemsToEdit;
        public Dictionary<GroceryItem, int> ItemsToEdit
        {
            get { return _itemsToEdit; }
        }

        public event EventHandler<EditListQuantityEventArgs> EditListQuantityFormOkButtonClicked;

        public EditListQuantityForm(Dictionary<GroceryItem, int> itemsToEdit)
        {
            _itemsToEdit = itemsToEdit;

            InitializeComponent();

            SuspendLayout();

            QuantityUpDown.Value = 1;

            ResumeLayout();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            List<GroceryItem> k = new List<GroceryItem>(_itemsToEdit.Keys);

            foreach (var item in k)
            {
                _itemsToEdit[item] = Convert.ToInt32(QuantityUpDown.Value);
            }

            EditListQuantityFormOkButtonClicked(this, new EditListQuantityEventArgs(_itemsToEdit));
            Close();
        }

        public class EditListQuantityEventArgs : EventArgs
        {
            public Dictionary<GroceryItem, int> ItemsToEdit { get; private set; }

            public EditListQuantityEventArgs(Dictionary<GroceryItem, int> itemsToEdit)
            {
                ItemsToEdit = itemsToEdit;
            }
        }
    }
}
