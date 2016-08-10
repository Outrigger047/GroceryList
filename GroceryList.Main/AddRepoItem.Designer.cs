namespace GroceryList.Main
{
    partial class AddRepoItemForm
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.HannafordPriceBox = new System.Windows.Forms.NumericUpDown();
            this.ShawsPriceBox = new System.Windows.Forms.NumericUpDown();
            this.SamsPriceBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.HannafordPriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShawsPriceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamsPriceBox)).BeginInit();
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
            this.ItemNameTextBox.TabIndex = 1;
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
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(92, 142);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(173, 142);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // HannafordPriceBox
            // 
            this.HannafordPriceBox.DecimalPlaces = 2;
            this.HannafordPriceBox.Location = new System.Drawing.Point(137, 59);
            this.HannafordPriceBox.Name = "HannafordPriceBox";
            this.HannafordPriceBox.Size = new System.Drawing.Size(120, 20);
            this.HannafordPriceBox.TabIndex = 7;
            this.HannafordPriceBox.ThousandsSeparator = true;
            // 
            // ShawsPriceBox
            // 
            this.ShawsPriceBox.DecimalPlaces = 2;
            this.ShawsPriceBox.Location = new System.Drawing.Point(137, 83);
            this.ShawsPriceBox.Name = "ShawsPriceBox";
            this.ShawsPriceBox.Size = new System.Drawing.Size(120, 20);
            this.ShawsPriceBox.TabIndex = 8;
            this.ShawsPriceBox.ThousandsSeparator = true;
            // 
            // SamsPriceBox
            // 
            this.SamsPriceBox.DecimalPlaces = 2;
            this.SamsPriceBox.Location = new System.Drawing.Point(137, 108);
            this.SamsPriceBox.Name = "SamsPriceBox";
            this.SamsPriceBox.Size = new System.Drawing.Size(120, 20);
            this.SamsPriceBox.TabIndex = 9;
            this.SamsPriceBox.ThousandsSeparator = true;
            // 
            // AddRepoItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 184);
            this.Controls.Add(this.SamsPriceBox);
            this.Controls.Add(this.ShawsPriceBox);
            this.Controls.Add(this.HannafordPriceBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SamsPriceLabel);
            this.Controls.Add(this.ShawsPriceLabel);
            this.Controls.Add(this.HannafordPriceLabel);
            this.Controls.Add(this.ItemNameTextBox);
            this.Controls.Add(this.ItemNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRepoItemForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Item";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.HannafordPriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShawsPriceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SamsPriceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.TextBox ItemNameTextBox;
        private System.Windows.Forms.Label HannafordPriceLabel;
        private System.Windows.Forms.Label ShawsPriceLabel;
        private System.Windows.Forms.Label SamsPriceLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown HannafordPriceBox;
        private System.Windows.Forms.NumericUpDown ShawsPriceBox;
        private System.Windows.Forms.NumericUpDown SamsPriceBox;
    }
}