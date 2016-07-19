﻿using System;
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
        public GroceryItemRepository Repo { get; private set; }

        //private BackgroundWorker RepoUpdater;

        public NewListWindow()
        {
            Repo = new GroceryItemRepository();

            InitializeComponent();
            UiLoadRefreshRepository();
        }

        private void UiLoadRefreshRepository()
        {
            foreach (var item in Repo.Items)
            {
                RepositoryListBox.Items.Add(BuildUiTableRowFromRepo(item));
            }
        }

        private string BuildUiTableRowFromRepo(GroceryItem repoItem)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(repoItem.Name + "   ");

            foreach (var price in repoItem.Prices)
            {
                sb.Append(price.Store + ": ");
                sb.Append("$" + Math.Round(Convert.ToDecimal(price.Price) / 100, 2) + "    ");
            }

            return sb.ToString();
        }

        private void RepositoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RepositoryListBox.SelectedIndices != null)
            {
                AddToListButton.Enabled = true;
            }
            else
            {
                AddToListButton.Enabled = false;
            }
        }
    }
}
