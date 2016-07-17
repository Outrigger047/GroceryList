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
            this.RepositoryGroupBox = new System.Windows.Forms.GroupBox();
            this.ListGroupBox = new System.Windows.Forms.GroupBox();
            this.AddToListButton = new System.Windows.Forms.Button();
            this.RemoveFromListButton = new System.Windows.Forms.Button();
            this.RepositoryListBox = new System.Windows.Forms.ListBox();
            this.ListListBox = new System.Windows.Forms.ListBox();
            this.RepoAddItemButton = new System.Windows.Forms.Button();
            this.RepoRemoveItemButton = new System.Windows.Forms.Button();
            this.RepoEditItemButton = new System.Windows.Forms.Button();
            this.ListNewListButton = new System.Windows.Forms.Button();
            this.ListOpenListButton = new System.Windows.Forms.Button();
            this.ListSaveListButton = new System.Windows.Forms.Button();
            this.ListSaveListAsButton = new System.Windows.Forms.Button();
            this.RepositoryGroupBox.SuspendLayout();
            this.ListGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RepositoryGroupBox
            // 
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
            // ListGroupBox
            // 
            this.ListGroupBox.Controls.Add(this.ListSaveListAsButton);
            this.ListGroupBox.Controls.Add(this.ListSaveListButton);
            this.ListGroupBox.Controls.Add(this.ListOpenListButton);
            this.ListGroupBox.Controls.Add(this.ListNewListButton);
            this.ListGroupBox.Controls.Add(this.ListListBox);
            this.ListGroupBox.Location = new System.Drawing.Point(601, 13);
            this.ListGroupBox.Name = "ListGroupBox";
            this.ListGroupBox.Size = new System.Drawing.Size(426, 462);
            this.ListGroupBox.TabIndex = 1;
            this.ListGroupBox.TabStop = false;
            this.ListGroupBox.Text = "Grocery List";
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
            // 
            // RepositoryListBox
            // 
            this.RepositoryListBox.FormattingEnabled = true;
            this.RepositoryListBox.Location = new System.Drawing.Point(7, 20);
            this.RepositoryListBox.Name = "RepositoryListBox";
            this.RepositoryListBox.Size = new System.Drawing.Size(413, 381);
            this.RepositoryListBox.TabIndex = 0;
            // 
            // ListListBox
            // 
            this.ListListBox.FormattingEnabled = true;
            this.ListListBox.Location = new System.Drawing.Point(7, 20);
            this.ListListBox.Name = "ListListBox";
            this.ListListBox.Size = new System.Drawing.Size(413, 381);
            this.ListListBox.TabIndex = 1;
            // 
            // RepoAddItemButton
            // 
            this.RepoAddItemButton.Location = new System.Drawing.Point(7, 408);
            this.RepoAddItemButton.Name = "RepoAddItemButton";
            this.RepoAddItemButton.Size = new System.Drawing.Size(91, 23);
            this.RepoAddItemButton.TabIndex = 1;
            this.RepoAddItemButton.Text = "Add Item";
            this.RepoAddItemButton.UseVisualStyleBackColor = true;
            // 
            // RepoRemoveItemButton
            // 
            this.RepoRemoveItemButton.Location = new System.Drawing.Point(201, 408);
            this.RepoRemoveItemButton.Name = "RepoRemoveItemButton";
            this.RepoRemoveItemButton.Size = new System.Drawing.Size(91, 23);
            this.RepoRemoveItemButton.TabIndex = 2;
            this.RepoRemoveItemButton.Text = "Remove Item";
            this.RepoRemoveItemButton.UseVisualStyleBackColor = true;
            // 
            // RepoEditItemButton
            // 
            this.RepoEditItemButton.Location = new System.Drawing.Point(104, 408);
            this.RepoEditItemButton.Name = "RepoEditItemButton";
            this.RepoEditItemButton.Size = new System.Drawing.Size(91, 23);
            this.RepoEditItemButton.TabIndex = 3;
            this.RepoEditItemButton.Text = "Edit Item";
            this.RepoEditItemButton.UseVisualStyleBackColor = true;
            // 
            // ListNewListButton
            // 
            this.ListNewListButton.Location = new System.Drawing.Point(7, 408);
            this.ListNewListButton.Name = "ListNewListButton";
            this.ListNewListButton.Size = new System.Drawing.Size(91, 23);
            this.ListNewListButton.TabIndex = 2;
            this.ListNewListButton.Text = "New List...";
            this.ListNewListButton.UseVisualStyleBackColor = true;
            // 
            // ListOpenListButton
            // 
            this.ListOpenListButton.Location = new System.Drawing.Point(104, 408);
            this.ListOpenListButton.Name = "ListOpenListButton";
            this.ListOpenListButton.Size = new System.Drawing.Size(91, 23);
            this.ListOpenListButton.TabIndex = 3;
            this.ListOpenListButton.Text = "Open List...";
            this.ListOpenListButton.UseVisualStyleBackColor = true;
            // 
            // ListSaveListButton
            // 
            this.ListSaveListButton.Location = new System.Drawing.Point(201, 408);
            this.ListSaveListButton.Name = "ListSaveListButton";
            this.ListSaveListButton.Size = new System.Drawing.Size(91, 23);
            this.ListSaveListButton.TabIndex = 4;
            this.ListSaveListButton.Text = "Save";
            this.ListSaveListButton.UseVisualStyleBackColor = true;
            // 
            // ListSaveListAsButton
            // 
            this.ListSaveListAsButton.Location = new System.Drawing.Point(298, 408);
            this.ListSaveListAsButton.Name = "ListSaveListAsButton";
            this.ListSaveListAsButton.Size = new System.Drawing.Size(91, 23);
            this.ListSaveListAsButton.TabIndex = 5;
            this.ListSaveListAsButton.Text = "Save As...";
            this.ListSaveListAsButton.UseVisualStyleBackColor = true;
            // 
            // NewListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 591);
            this.Controls.Add(this.RemoveFromListButton);
            this.Controls.Add(this.AddToListButton);
            this.Controls.Add(this.ListGroupBox);
            this.Controls.Add(this.RepositoryGroupBox);
            this.Name = "NewListWindow";
            this.Text = " NewListWindow";
            this.RepositoryGroupBox.ResumeLayout(false);
            this.ListGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.Button ListNewListButton;
    }
}

