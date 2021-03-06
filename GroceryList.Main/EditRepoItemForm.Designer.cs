﻿namespace GroceryList.Main
{
    partial class EditRepoItemForm
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
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemNameTextBox = new System.Windows.Forms.TextBox();
            this.HannafordPriceLabel = new System.Windows.Forms.Label();
            this.ShawsPriceLabel = new System.Windows.Forms.Label();
            this.SamsPriceLabel = new System.Windows.Forms.Label();
            this.EditRepoItemOkButton = new System.Windows.Forms.Button();
            this.EditRepoItemCancelButton = new System.Windows.Forms.Button();
            this.HannafordPriceBox = new System.Windows.Forms.NumericUpDown();
            this.ShawsPriceBox = new System.Windows.Forms.NumericUpDown();
            this.SamsPriceBox = new System.Windows.Forms.NumericUpDown();
            this.TraderJoesPriceBox = new System.Windows.Forms.NumericUpDown();
            this.TraderJoesPriceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HannafordPriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShawsPriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamsPriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TraderJoesPriceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Location = new System.Drawing.Point(87, 26);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(35, 13);
            this.ItemNameLabel.TabIndex = 0;
            this.ItemNameLabel.Text = "Name";
            // 
            // ItemNameTextBox
            // 
            this.ItemNameTextBox.Location = new System.Drawing.Point(137, 23);
            this.ItemNameTextBox.Name = "ItemNameTextBox";
            this.ItemNameTextBox.Size = new System.Drawing.Size(142, 20);
            this.ItemNameTextBox.TabIndex = 0;
            // 
            // HannafordPriceLabel
            // 
            this.HannafordPriceLabel.AutoSize = true;
            this.HannafordPriceLabel.Location = new System.Drawing.Point(38, 61);
            this.HannafordPriceLabel.Name = "HannafordPriceLabel";
            this.HannafordPriceLabel.Size = new System.Drawing.Size(84, 13);
            this.HannafordPriceLabel.TabIndex = 2;
            this.HannafordPriceLabel.Text = "Hannaford Price";
            // 
            // ShawsPriceLabel
            // 
            this.ShawsPriceLabel.AutoSize = true;
            this.ShawsPriceLabel.Location = new System.Drawing.Point(54, 85);
            this.ShawsPriceLabel.Name = "ShawsPriceLabel";
            this.ShawsPriceLabel.Size = new System.Drawing.Size(68, 13);
            this.ShawsPriceLabel.TabIndex = 3;
            this.ShawsPriceLabel.Text = "Shaw\'s Price";
            // 
            // SamsPriceLabel
            // 
            this.SamsPriceLabel.AutoSize = true;
            this.SamsPriceLabel.Location = new System.Drawing.Point(36, 110);
            this.SamsPriceLabel.Name = "SamsPriceLabel";
            this.SamsPriceLabel.Size = new System.Drawing.Size(86, 13);
            this.SamsPriceLabel.TabIndex = 4;
            this.SamsPriceLabel.Text = "Sam\'s Club Price";
            // 
            // EditRepoItemOkButton
            // 
            this.EditRepoItemOkButton.Location = new System.Drawing.Point(90, 169);
            this.EditRepoItemOkButton.Name = "EditRepoItemOkButton";
            this.EditRepoItemOkButton.Size = new System.Drawing.Size(75, 23);
            this.EditRepoItemOkButton.TabIndex = 4;
            this.EditRepoItemOkButton.Text = "OK";
            this.EditRepoItemOkButton.UseVisualStyleBackColor = true;
            this.EditRepoItemOkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EditRepoItemCancelButton
            // 
            this.EditRepoItemCancelButton.Location = new System.Drawing.Point(171, 169);
            this.EditRepoItemCancelButton.Name = "EditRepoItemCancelButton";
            this.EditRepoItemCancelButton.Size = new System.Drawing.Size(75, 23);
            this.EditRepoItemCancelButton.TabIndex = 5;
            this.EditRepoItemCancelButton.Text = "Cancel";
            this.EditRepoItemCancelButton.UseVisualStyleBackColor = true;
            this.EditRepoItemCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // HannafordPriceBox
            // 
            this.HannafordPriceBox.DecimalPlaces = 2;
            this.HannafordPriceBox.Location = new System.Drawing.Point(137, 59);
            this.HannafordPriceBox.Name = "HannafordPriceBox";
            this.HannafordPriceBox.Size = new System.Drawing.Size(120, 20);
            this.HannafordPriceBox.TabIndex = 1;
            this.HannafordPriceBox.ThousandsSeparator = true;
            // 
            // ShawsPriceBox
            // 
            this.ShawsPriceBox.DecimalPlaces = 2;
            this.ShawsPriceBox.Location = new System.Drawing.Point(137, 83);
            this.ShawsPriceBox.Name = "ShawsPriceBox";
            this.ShawsPriceBox.Size = new System.Drawing.Size(120, 20);
            this.ShawsPriceBox.TabIndex = 2;
            this.ShawsPriceBox.ThousandsSeparator = true;
            // 
            // SamsPriceBox
            // 
            this.SamsPriceBox.DecimalPlaces = 2;
            this.SamsPriceBox.Location = new System.Drawing.Point(137, 108);
            this.SamsPriceBox.Name = "SamsPriceBox";
            this.SamsPriceBox.Size = new System.Drawing.Size(120, 20);
            this.SamsPriceBox.TabIndex = 3;
            this.SamsPriceBox.ThousandsSeparator = true;
            // 
            // TraderJoesPriceBox
            // 
            this.TraderJoesPriceBox.DecimalPlaces = 2;
            this.TraderJoesPriceBox.Location = new System.Drawing.Point(137, 134);
            this.TraderJoesPriceBox.Name = "TraderJoesPriceBox";
            this.TraderJoesPriceBox.Size = new System.Drawing.Size(120, 20);
            this.TraderJoesPriceBox.TabIndex = 6;
            this.TraderJoesPriceBox.ThousandsSeparator = true;
            // 
            // TraderJoesPriceLabel
            // 
            this.TraderJoesPriceLabel.AutoSize = true;
            this.TraderJoesPriceLabel.Location = new System.Drawing.Point(36, 136);
            this.TraderJoesPriceLabel.Name = "TraderJoesPriceLabel";
            this.TraderJoesPriceLabel.Size = new System.Drawing.Size(92, 13);
            this.TraderJoesPriceLabel.TabIndex = 7;
            this.TraderJoesPriceLabel.Text = "Trader Joe\'s Price";
            // 
            // EditRepoItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 226);
            this.Controls.Add(this.TraderJoesPriceBox);
            this.Controls.Add(this.TraderJoesPriceLabel);
            this.Controls.Add(this.SamsPriceBox);
            this.Controls.Add(this.ShawsPriceBox);
            this.Controls.Add(this.HannafordPriceBox);
            this.Controls.Add(this.EditRepoItemCancelButton);
            this.Controls.Add(this.EditRepoItemOkButton);
            this.Controls.Add(this.SamsPriceLabel);
            this.Controls.Add(this.ShawsPriceLabel);
            this.Controls.Add(this.HannafordPriceLabel);
            this.Controls.Add(this.ItemNameTextBox);
            this.Controls.Add(this.ItemNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRepoItemForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Item";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HannafordPriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShawsPriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamsPriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TraderJoesPriceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.Label HannafordPriceLabel;
        private System.Windows.Forms.Label ShawsPriceLabel;
        private System.Windows.Forms.Label SamsPriceLabel;
        private System.Windows.Forms.Button EditRepoItemOkButton;
        private System.Windows.Forms.Button EditRepoItemCancelButton;
        private System.Windows.Forms.NumericUpDown HannafordPriceBox;
        private System.Windows.Forms.NumericUpDown ShawsPriceBox;
        private System.Windows.Forms.NumericUpDown SamsPriceBox;
        private System.Windows.Forms.NumericUpDown TraderJoesPriceBox;
        private System.Windows.Forms.Label TraderJoesPriceLabel;
    }
}