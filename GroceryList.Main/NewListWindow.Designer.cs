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
            this.AvailableFilterTextBox = new System.Windows.Forms.TextBox();
            this.RepoEditItemButton = new System.Windows.Forms.Button();
            this.RepoRemoveItemButton = new System.Windows.Forms.Button();
            this.RepoAddItemButton = new System.Windows.Forms.Button();
            this.RepositoryListBox = new System.Windows.Forms.ListBox();
            this.ListGroupBox = new System.Windows.Forms.GroupBox();
            this.ListSaveAsButton = new System.Windows.Forms.Button();
            this.ListSaveButton = new System.Windows.Forms.Button();
            this.OpenListButton = new System.Windows.Forms.Button();
            this.ListPrintButton = new System.Windows.Forms.Button();
            this.ListQuantityButton = new System.Windows.Forms.Button();
            this.ListClearListButton = new System.Windows.Forms.Button();
            this.ListListBox = new System.Windows.Forms.ListBox();
            this.AddToListButton = new System.Windows.Forms.Button();
            this.RemoveFromListButton = new System.Windows.Forms.Button();
            this.InformationGroupBox = new System.Windows.Forms.GroupBox();
            this.InfoNumItemsLabel = new System.Windows.Forms.Label();
            this.InfoNumItemsNameLabel = new System.Windows.Forms.Label();
            this.InfoTotalAmtNameLabel = new System.Windows.Forms.Label();
            this.InfoTotalPriceLabel = new System.Windows.Forms.Label();
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
            // AvailableFilterTextBox
            // 
            this.AvailableFilterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableFilterTextBox.Location = new System.Drawing.Point(7, 19);
            this.AvailableFilterTextBox.MaxLength = 100;
            this.AvailableFilterTextBox.Name = "AvailableFilterTextBox";
            this.AvailableFilterTextBox.Size = new System.Drawing.Size(413, 20);
            this.AvailableFilterTextBox.TabIndex = 4;
            this.AvailableFilterTextBox.TextChanged += new System.EventHandler(this.AvailableFilterTextBox_TextChanged);
            this.AvailableFilterTextBox.Enter += new System.EventHandler(this.AvailableFilterTextBox_Enter);
            this.AvailableFilterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AvailableFilterTextBox_KeyPress);
            this.AvailableFilterTextBox.Leave += new System.EventHandler(this.AvailableFilterTextBox_Leave);
            this.AvailableFilterTextBox.MouseEnter += new System.EventHandler(this.AvailableFilterTextBox_MouseEnter);
            this.AvailableFilterTextBox.MouseLeave += new System.EventHandler(this.AvailableFilterTextBox_MouseLeave);
            // 
            // RepoEditItemButton
            // 
            this.RepoEditItemButton.Enabled = false;
            this.RepoEditItemButton.Location = new System.Drawing.Point(28, 408);
            this.RepoEditItemButton.Name = "RepoEditItemButton";
            this.RepoEditItemButton.Size = new System.Drawing.Size(115, 48);
            this.RepoEditItemButton.TabIndex = 3;
            this.RepoEditItemButton.Text = "Edit Selected Item";
            this.RepoEditItemButton.UseVisualStyleBackColor = true;
            this.RepoEditItemButton.Click += new System.EventHandler(this.RepoEditItemButton_Click);
            // 
            // RepoRemoveItemButton
            // 
            this.RepoRemoveItemButton.Enabled = false;
            this.RepoRemoveItemButton.Location = new System.Drawing.Point(152, 408);
            this.RepoRemoveItemButton.Name = "RepoRemoveItemButton";
            this.RepoRemoveItemButton.Size = new System.Drawing.Size(115, 48);
            this.RepoRemoveItemButton.TabIndex = 2;
            this.RepoRemoveItemButton.Text = "Remove Item";
            this.RepoRemoveItemButton.UseVisualStyleBackColor = true;
            this.RepoRemoveItemButton.Click += new System.EventHandler(this.RepoRemoveItemButton_Click);
            // 
            // RepoAddItemButton
            // 
            this.RepoAddItemButton.Location = new System.Drawing.Point(276, 408);
            this.RepoAddItemButton.Name = "RepoAddItemButton";
            this.RepoAddItemButton.Size = new System.Drawing.Size(115, 48);
            this.RepoAddItemButton.TabIndex = 1;
            this.RepoAddItemButton.Text = "Add Item";
            this.RepoAddItemButton.UseVisualStyleBackColor = true;
            this.RepoAddItemButton.Click += new System.EventHandler(this.RepoAddItemButton_Click);
            // 
            // RepositoryListBox
            // 
            this.RepositoryListBox.FormattingEnabled = true;
            this.RepositoryListBox.Location = new System.Drawing.Point(7, 46);
            this.RepositoryListBox.Name = "RepositoryListBox";
            this.RepositoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RepositoryListBox.Size = new System.Drawing.Size(413, 355);
            this.RepositoryListBox.Sorted = true;
            this.RepositoryListBox.TabIndex = 0;
            this.RepositoryListBox.SelectedIndexChanged += new System.EventHandler(this.RepositoryListBox_SelectedIndexChanged);
            // 
            // ListGroupBox
            // 
            this.ListGroupBox.Controls.Add(this.ListSaveAsButton);
            this.ListGroupBox.Controls.Add(this.ListSaveButton);
            this.ListGroupBox.Controls.Add(this.OpenListButton);
            this.ListGroupBox.Controls.Add(this.ListPrintButton);
            this.ListGroupBox.Controls.Add(this.ListQuantityButton);
            this.ListGroupBox.Controls.Add(this.ListClearListButton);
            this.ListGroupBox.Controls.Add(this.ListListBox);
            this.ListGroupBox.Location = new System.Drawing.Point(601, 13);
            this.ListGroupBox.Name = "ListGroupBox";
            this.ListGroupBox.Size = new System.Drawing.Size(426, 462);
            this.ListGroupBox.TabIndex = 1;
            this.ListGroupBox.TabStop = false;
            this.ListGroupBox.Text = "Grocery List";
            // 
            // ListSaveAsButton
            // 
            this.ListSaveAsButton.Enabled = false;
            this.ListSaveAsButton.Location = new System.Drawing.Point(288, 433);
            this.ListSaveAsButton.Name = "ListSaveAsButton";
            this.ListSaveAsButton.Size = new System.Drawing.Size(119, 23);
            this.ListSaveAsButton.TabIndex = 10;
            this.ListSaveAsButton.Text = "Save As...";
            this.ListSaveAsButton.UseVisualStyleBackColor = true;
            // 
            // ListSaveButton
            // 
            this.ListSaveButton.Enabled = false;
            this.ListSaveButton.Location = new System.Drawing.Point(157, 433);
            this.ListSaveButton.Name = "ListSaveButton";
            this.ListSaveButton.Size = new System.Drawing.Size(119, 23);
            this.ListSaveButton.TabIndex = 9;
            this.ListSaveButton.Text = "Save List";
            this.ListSaveButton.UseVisualStyleBackColor = true;
            // 
            // OpenListButton
            // 
            this.OpenListButton.Location = new System.Drawing.Point(26, 433);
            this.OpenListButton.Name = "OpenListButton";
            this.OpenListButton.Size = new System.Drawing.Size(119, 23);
            this.OpenListButton.TabIndex = 8;
            this.OpenListButton.Text = "Open Saved List...";
            this.OpenListButton.UseVisualStyleBackColor = true;
            // 
            // ListPrintButton
            // 
            this.ListPrintButton.Enabled = false;
            this.ListPrintButton.Location = new System.Drawing.Point(288, 408);
            this.ListPrintButton.Name = "ListPrintButton";
            this.ListPrintButton.Size = new System.Drawing.Size(119, 23);
            this.ListPrintButton.TabIndex = 7;
            this.ListPrintButton.Text = "Print";
            this.ListPrintButton.UseVisualStyleBackColor = true;
            // 
            // ListQuantityButton
            // 
            this.ListQuantityButton.Enabled = false;
            this.ListQuantityButton.Location = new System.Drawing.Point(26, 408);
            this.ListQuantityButton.Name = "ListQuantityButton";
            this.ListQuantityButton.Size = new System.Drawing.Size(119, 23);
            this.ListQuantityButton.TabIndex = 6;
            this.ListQuantityButton.Text = "Edit Quantity";
            this.ListQuantityButton.UseVisualStyleBackColor = true;
            this.ListQuantityButton.Click += new System.EventHandler(this.ListQuantityButton_Click);
            // 
            // ListClearListButton
            // 
            this.ListClearListButton.Enabled = false;
            this.ListClearListButton.Location = new System.Drawing.Point(157, 408);
            this.ListClearListButton.Name = "ListClearListButton";
            this.ListClearListButton.Size = new System.Drawing.Size(119, 23);
            this.ListClearListButton.TabIndex = 2;
            this.ListClearListButton.Text = "Clear List";
            this.ListClearListButton.UseVisualStyleBackColor = true;
            this.ListClearListButton.Click += new System.EventHandler(this.ListClearListButton_Click);
            // 
            // ListListBox
            // 
            this.ListListBox.FormattingEnabled = true;
            this.ListListBox.Location = new System.Drawing.Point(7, 20);
            this.ListListBox.Name = "ListListBox";
            this.ListListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListListBox.Size = new System.Drawing.Size(413, 381);
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
            this.InfoNumItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoNumItemsLabel.Location = new System.Drawing.Point(768, 65);
            this.InfoNumItemsLabel.Name = "InfoNumItemsLabel";
            this.InfoNumItemsLabel.Size = new System.Drawing.Size(24, 25);
            this.InfoNumItemsLabel.TabIndex = 3;
            this.InfoNumItemsLabel.Text = "0";
            // 
            // InfoNumItemsNameLabel
            // 
            this.InfoNumItemsNameLabel.AutoSize = true;
            this.InfoNumItemsNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoNumItemsNameLabel.Location = new System.Drawing.Point(524, 65);
            this.InfoNumItemsNameLabel.Name = "InfoNumItemsNameLabel";
            this.InfoNumItemsNameLabel.Size = new System.Drawing.Size(238, 25);
            this.InfoNumItemsNameLabel.TabIndex = 2;
            this.InfoNumItemsNameLabel.Text = "Number of Items on List";
            this.InfoNumItemsNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InfoTotalAmtNameLabel
            // 
            this.InfoTotalAmtNameLabel.AutoSize = true;
            this.InfoTotalAmtNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoTotalAmtNameLabel.Location = new System.Drawing.Point(583, 35);
            this.InfoTotalAmtNameLabel.Name = "InfoTotalAmtNameLabel";
            this.InfoTotalAmtNameLabel.Size = new System.Drawing.Size(179, 25);
            this.InfoTotalAmtNameLabel.TabIndex = 1;
            this.InfoTotalAmtNameLabel.Text = "Total List Amount";
            this.InfoTotalAmtNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InfoTotalPriceLabel
            // 
            this.InfoTotalPriceLabel.AutoSize = true;
            this.InfoTotalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoTotalPriceLabel.Location = new System.Drawing.Point(768, 35);
            this.InfoTotalPriceLabel.Name = "InfoTotalPriceLabel";
            this.InfoTotalPriceLabel.Size = new System.Drawing.Size(66, 25);
            this.InfoTotalPriceLabel.TabIndex = 0;
            this.InfoTotalPriceLabel.Text = "$0.00";
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
        private System.Windows.Forms.Button ListClearListButton;
        private System.Windows.Forms.GroupBox InformationGroupBox;
        private System.Windows.Forms.Button ListQuantityButton;
        private System.Windows.Forms.Label InfoTotalPriceLabel;
        private System.Windows.Forms.Label InfoNumItemsLabel;
        private System.Windows.Forms.Label InfoNumItemsNameLabel;
        private System.Windows.Forms.Label InfoTotalAmtNameLabel;
        private System.Windows.Forms.TextBox AvailableFilterTextBox;
        private System.Windows.Forms.Button ListPrintButton;
        private System.Windows.Forms.Button ListSaveAsButton;
        private System.Windows.Forms.Button ListSaveButton;
        private System.Windows.Forms.Button OpenListButton;
    }
}

