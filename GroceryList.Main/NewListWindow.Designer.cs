namespace GroceryList.Main
{
    partial class NewListWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewListWindow));
            this.RepositoryGroupBox = new System.Windows.Forms.GroupBox();
            this.RepoEditItemButton = new System.Windows.Forms.Button();
            this.RepoRemoveItemButton = new System.Windows.Forms.Button();
            this.RepoAddItemButton = new System.Windows.Forms.Button();
            this.RepositoryListBox = new System.Windows.Forms.ListBox();
            this.ListGroupBox = new System.Windows.Forms.GroupBox();
            this.ListQuantityButton = new System.Windows.Forms.Button();
            this.ListSaveListAsButton = new System.Windows.Forms.Button();
            this.ListSaveListButton = new System.Windows.Forms.Button();
            this.ListOpenListButton = new System.Windows.Forms.Button();
            this.ListClearListButton = new System.Windows.Forms.Button();
            this.ListListBox = new System.Windows.Forms.ListBox();
            this.AddToListButton = new System.Windows.Forms.Button();
            this.RemoveFromListButton = new System.Windows.Forms.Button();
            this.InformationGroupBox = new System.Windows.Forms.GroupBox();
            this.InfoNumItemsLabel = new System.Windows.Forms.Label();
            this.InfoNumItemsNameLabel = new System.Windows.Forms.Label();
            this.InfoTotalAmtNameLabel = new System.Windows.Forms.Label();
            this.InfoTotalPriceLabel = new System.Windows.Forms.Label();
            this.AvailableFilterTextBox = new System.Windows.Forms.TextBox();
            this.ListFilterTextBox = new System.Windows.Forms.TextBox();
            this.RepositoryGroupBox.SuspendLayout();
            this.ListGroupBox.SuspendLayout();
            this.InformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RepositoryGroupBox
            // 
            this.RepositoryGroupBox.Controls.Add(this.AvailableFilterTextBox);
            this.RepositoryGroupBox.Controls.Add(this.RepoEditItemButton);
            this.RepositoryGroupBox.Controls.Add(this.RepoRemoveItemButton);
            this.RepositoryGroupBox.Controls.Add(this.RepoAddItemButton);
            this.RepositoryGroupBox.Controls.Add(this.RepositoryListBox);
            this.RepositoryGroupBox.Location = new System.Drawing.Point(13, 13);
            this.RepositoryGroupBox.Name = "RepositoryGroupBox";
            this.RepositoryGroupBox.Size = new System.Drawing.Size(426, 462);
            this.RepositoryGroupBox.TabIndex = 0;
            this.RepositoryGroupBox.TabStop = false;
            this.RepositoryGroupBox.Text = "Available Items";
            // 
            // RepoEditItemButton
            // 
            this.RepoEditItemButton.Enabled = false;
            this.RepoEditItemButton.Location = new System.Drawing.Point(7, 408);
            this.RepoEditItemButton.Name = "RepoEditItemButton";
            this.RepoEditItemButton.Size = new System.Drawing.Size(118, 23);
            this.RepoEditItemButton.TabIndex = 3;
            this.RepoEditItemButton.Text = "Edit Selected Item...";
            this.RepoEditItemButton.UseVisualStyleBackColor = true;
            // 
            // RepoRemoveItemButton
            // 
            this.RepoRemoveItemButton.Enabled = false;
            this.RepoRemoveItemButton.Location = new System.Drawing.Point(131, 408);
            this.RepoRemoveItemButton.Name = "RepoRemoveItemButton";
            this.RepoRemoveItemButton.Size = new System.Drawing.Size(118, 23);
            this.RepoRemoveItemButton.TabIndex = 2;
            this.RepoRemoveItemButton.Text = "Remove Item...";
            this.RepoRemoveItemButton.UseVisualStyleBackColor = true;
            // 
            // RepoAddItemButton
            // 
            this.RepoAddItemButton.Location = new System.Drawing.Point(255, 408);
            this.RepoAddItemButton.Name = "RepoAddItemButton";
            this.RepoAddItemButton.Size = new System.Drawing.Size(91, 23);
            this.RepoAddItemButton.TabIndex = 1;
            this.RepoAddItemButton.Text = "Add Item...";
            this.RepoAddItemButton.UseVisualStyleBackColor = true;
            // 
            // RepositoryListBox
            // 
            this.RepositoryListBox.FormattingEnabled = true;
            this.RepositoryListBox.Location = new System.Drawing.Point(7, 46);
            this.RepositoryListBox.Name = "RepositoryListBox";
            this.RepositoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RepositoryListBox.Size = new System.Drawing.Size(413, 355);
            this.RepositoryListBox.TabIndex = 0;
            this.RepositoryListBox.SelectedIndexChanged += new System.EventHandler(this.RepositoryListBox_SelectedIndexChanged);
            // 
            // ListGroupBox
            // 
            this.ListGroupBox.Controls.Add(this.ListFilterTextBox);
            this.ListGroupBox.Controls.Add(this.ListQuantityButton);
            this.ListGroupBox.Controls.Add(this.ListSaveListAsButton);
            this.ListGroupBox.Controls.Add(this.ListSaveListButton);
            this.ListGroupBox.Controls.Add(this.ListOpenListButton);
            this.ListGroupBox.Controls.Add(this.ListClearListButton);
            this.ListGroupBox.Controls.Add(this.ListListBox);
            this.ListGroupBox.Location = new System.Drawing.Point(601, 13);
            this.ListGroupBox.Name = "ListGroupBox";
            this.ListGroupBox.Size = new System.Drawing.Size(426, 462);
            this.ListGroupBox.TabIndex = 1;
            this.ListGroupBox.TabStop = false;
            this.ListGroupBox.Text = "Grocery List";
            // 
            // ListQuantityButton
            // 
            this.ListQuantityButton.Enabled = false;
            this.ListQuantityButton.Location = new System.Drawing.Point(7, 433);
            this.ListQuantityButton.Name = "ListQuantityButton";
            this.ListQuantityButton.Size = new System.Drawing.Size(91, 23);
            this.ListQuantityButton.TabIndex = 6;
            this.ListQuantityButton.Text = "Edit Quantity...";
            this.ListQuantityButton.UseVisualStyleBackColor = true;
            // 
            // ListSaveListAsButton
            // 
            this.ListSaveListAsButton.Enabled = false;
            this.ListSaveListAsButton.Location = new System.Drawing.Point(201, 408);
            this.ListSaveListAsButton.Name = "ListSaveListAsButton";
            this.ListSaveListAsButton.Size = new System.Drawing.Size(91, 23);
            this.ListSaveListAsButton.TabIndex = 5;
            this.ListSaveListAsButton.Text = "Save As...";
            this.ListSaveListAsButton.UseVisualStyleBackColor = true;
            // 
            // ListSaveListButton
            // 
            this.ListSaveListButton.Enabled = false;
            this.ListSaveListButton.Location = new System.Drawing.Point(104, 408);
            this.ListSaveListButton.Name = "ListSaveListButton";
            this.ListSaveListButton.Size = new System.Drawing.Size(91, 23);
            this.ListSaveListButton.TabIndex = 4;
            this.ListSaveListButton.Text = "Save";
            this.ListSaveListButton.UseVisualStyleBackColor = true;
            // 
            // ListOpenListButton
            // 
            this.ListOpenListButton.Location = new System.Drawing.Point(7, 408);
            this.ListOpenListButton.Name = "ListOpenListButton";
            this.ListOpenListButton.Size = new System.Drawing.Size(91, 23);
            this.ListOpenListButton.TabIndex = 3;
            this.ListOpenListButton.Text = "Open List...";
            this.ListOpenListButton.UseVisualStyleBackColor = true;
            // 
            // ListClearListButton
            // 
            this.ListClearListButton.Enabled = false;
            this.ListClearListButton.Location = new System.Drawing.Point(298, 408);
            this.ListClearListButton.Name = "ListClearListButton";
            this.ListClearListButton.Size = new System.Drawing.Size(91, 23);
            this.ListClearListButton.TabIndex = 2;
            this.ListClearListButton.Text = "Clear List...";
            this.ListClearListButton.UseVisualStyleBackColor = true;
            // 
            // ListListBox
            // 
            this.ListListBox.FormattingEnabled = true;
            this.ListListBox.Location = new System.Drawing.Point(7, 46);
            this.ListListBox.Name = "ListListBox";
            this.ListListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListListBox.Size = new System.Drawing.Size(413, 355);
            this.ListListBox.TabIndex = 1;
            this.ListListBox.SelectedIndexChanged += new System.EventHandler(this.ListListBox_SelectedIndexChanged);
            // 
            // AddToListButton
            // 
            this.AddToListButton.Enabled = false;
            this.AddToListButton.Location = new System.Drawing.Point(445, 142);
            this.AddToListButton.Name = "AddToListButton";
            this.AddToListButton.Size = new System.Drawing.Size(150, 72);
            this.AddToListButton.TabIndex = 2;
            this.AddToListButton.Text = "Add To Grocery List";
            this.AddToListButton.UseVisualStyleBackColor = true;
            this.AddToListButton.Click += new System.EventHandler(this.AddToListButton_Click);
            // 
            // RemoveFromListButton
            // 
            this.RemoveFromListButton.Enabled = false;
            this.RemoveFromListButton.Location = new System.Drawing.Point(445, 220);
            this.RemoveFromListButton.Name = "RemoveFromListButton";
            this.RemoveFromListButton.Size = new System.Drawing.Size(150, 72);
            this.RemoveFromListButton.TabIndex = 3;
            this.RemoveFromListButton.Text = "Remove From Grocery List";
            this.RemoveFromListButton.UseVisualStyleBackColor = true;
            this.RemoveFromListButton.Click += new System.EventHandler(this.RemoveFromListButton_Click);
            // 
            // InformationGroupBox
            // 
            this.InformationGroupBox.Controls.Add(this.InfoNumItemsLabel);
            this.InformationGroupBox.Controls.Add(this.InfoNumItemsNameLabel);
            this.InformationGroupBox.Controls.Add(this.InfoTotalAmtNameLabel);
            this.InformationGroupBox.Controls.Add(this.InfoTotalPriceLabel);
            this.InformationGroupBox.Location = new System.Drawing.Point(13, 482);
            this.InformationGroupBox.Name = "InformationGroupBox";
            this.InformationGroupBox.Size = new System.Drawing.Size(1014, 139);
            this.InformationGroupBox.TabIndex = 4;
            this.InformationGroupBox.TabStop = false;
            this.InformationGroupBox.Text = "Information";
            // 
            // InfoNumItemsLabel
            // 
            this.InfoNumItemsLabel.AutoSize = true;
            this.InfoNumItemsLabel.Location = new System.Drawing.Point(789, 65);
            this.InfoNumItemsLabel.Name = "InfoNumItemsLabel";
            this.InfoNumItemsLabel.Size = new System.Drawing.Size(13, 13);
            this.InfoNumItemsLabel.TabIndex = 3;
            this.InfoNumItemsLabel.Text = "0";
            // 
            // InfoNumItemsNameLabel
            // 
            this.InfoNumItemsNameLabel.AutoSize = true;
            this.InfoNumItemsNameLabel.Location = new System.Drawing.Point(661, 65);
            this.InfoNumItemsNameLabel.Name = "InfoNumItemsNameLabel";
            this.InfoNumItemsNameLabel.Size = new System.Drawing.Size(118, 13);
            this.InfoNumItemsNameLabel.TabIndex = 2;
            this.InfoNumItemsNameLabel.Text = "Number of Items on List";
            this.InfoNumItemsNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InfoTotalAmtNameLabel
            // 
            this.InfoTotalAmtNameLabel.AutoSize = true;
            this.InfoTotalAmtNameLabel.Location = new System.Drawing.Point(690, 35);
            this.InfoTotalAmtNameLabel.Name = "InfoTotalAmtNameLabel";
            this.InfoTotalAmtNameLabel.Size = new System.Drawing.Size(89, 13);
            this.InfoTotalAmtNameLabel.TabIndex = 1;
            this.InfoTotalAmtNameLabel.Text = "Total List Amount";
            this.InfoTotalAmtNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InfoTotalPriceLabel
            // 
            this.InfoTotalPriceLabel.AutoSize = true;
            this.InfoTotalPriceLabel.Location = new System.Drawing.Point(789, 35);
            this.InfoTotalPriceLabel.Name = "InfoTotalPriceLabel";
            this.InfoTotalPriceLabel.Size = new System.Drawing.Size(34, 13);
            this.InfoTotalPriceLabel.TabIndex = 0;
            this.InfoTotalPriceLabel.Text = "$0.00";
            // 
            // AvailableFilterTextBox
            // 
            this.AvailableFilterTextBox.Location = new System.Drawing.Point(7, 19);
            this.AvailableFilterTextBox.Name = "AvailableFilterTextBox";
            this.AvailableFilterTextBox.Size = new System.Drawing.Size(413, 20);
            this.AvailableFilterTextBox.TabIndex = 4;
            // 
            // ListFilterTextBox
            // 
            this.ListFilterTextBox.Location = new System.Drawing.Point(7, 19);
            this.ListFilterTextBox.Name = "ListFilterTextBox";
            this.ListFilterTextBox.Size = new System.Drawing.Size(413, 20);
            this.ListFilterTextBox.TabIndex = 5;
            // 
            // NewListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 633);
            this.Controls.Add(this.InformationGroupBox);
            this.Controls.Add(this.RemoveFromListButton);
            this.Controls.Add(this.AddToListButton);
            this.Controls.Add(this.ListGroupBox);
            this.Controls.Add(this.RepositoryGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "NewListWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = " NewListWindow";
            this.RepositoryGroupBox.ResumeLayout(false);
            this.RepositoryGroupBox.PerformLayout();
            this.ListGroupBox.ResumeLayout(false);
            this.ListGroupBox.PerformLayout();
            this.InformationGroupBox.ResumeLayout(false);
            this.InformationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RepositoryGroupBox;
        private System.Windows.Forms.GroupBox ListGroupBox;
        private System.Windows.Forms.Button AddToListButton;
        private System.Windows.Forms.Button RemoveFromListButton;
        private System.Windows.Forms.ListBox RepositoryListBox;
        private System.Windows.Forms.ListBox ListListBox;
        private System.Windows.Forms.Button RepoEditItemButton;
        private System.Windows.Forms.Button RepoRemoveItemButton;
        private System.Windows.Forms.Button RepoAddItemButton;
        private System.Windows.Forms.Button ListSaveListAsButton;
        private System.Windows.Forms.Button ListSaveListButton;
        private System.Windows.Forms.Button ListOpenListButton;
        private System.Windows.Forms.Button ListClearListButton;
        private System.Windows.Forms.GroupBox InformationGroupBox;
        private System.Windows.Forms.Button ListQuantityButton;
        private System.Windows.Forms.Label InfoTotalPriceLabel;
        private System.Windows.Forms.Label InfoNumItemsLabel;
        private System.Windows.Forms.Label InfoNumItemsNameLabel;
        private System.Windows.Forms.Label InfoTotalAmtNameLabel;
        private System.Windows.Forms.TextBox AvailableFilterTextBox;
        private System.Windows.Forms.TextBox ListFilterTextBox;
    }
}

