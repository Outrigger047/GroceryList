namespace GroceryList.Main
{
    partial class EditListQuantityForm
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
            this.QuantityUpDown = new System.Windows.Forms.NumericUpDown();
            this.EditQuantityOkButton = new System.Windows.Forms.Button();
            this.EditQuantityCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // QuantityUpDown
            // 
            this.QuantityUpDown.Location = new System.Drawing.Point(97, 27);
            this.QuantityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuantityUpDown.Name = "QuantityUpDown";
            this.QuantityUpDown.Size = new System.Drawing.Size(71, 20);
            this.QuantityUpDown.TabIndex = 0;
            this.QuantityUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EditQuantityOkButton
            // 
            this.EditQuantityOkButton.Location = new System.Drawing.Point(47, 73);
            this.EditQuantityOkButton.Name = "EditQuantityOkButton";
            this.EditQuantityOkButton.Size = new System.Drawing.Size(75, 23);
            this.EditQuantityOkButton.TabIndex = 1;
            this.EditQuantityOkButton.Text = "OK";
            this.EditQuantityOkButton.UseVisualStyleBackColor = true;
            this.EditQuantityOkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EditQuantityCancelButton
            // 
            this.EditQuantityCancelButton.Location = new System.Drawing.Point(144, 73);
            this.EditQuantityCancelButton.Name = "EditQuantityCancelButton";
            this.EditQuantityCancelButton.Size = new System.Drawing.Size(75, 23);
            this.EditQuantityCancelButton.TabIndex = 2;
            this.EditQuantityCancelButton.Text = "Cancel";
            this.EditQuantityCancelButton.UseVisualStyleBackColor = true;
            this.EditQuantityCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EditListQuantityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 128);
            this.Controls.Add(this.EditQuantityCancelButton);
            this.Controls.Add(this.EditQuantityOkButton);
            this.Controls.Add(this.QuantityUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditListQuantityForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Edit Quantity";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown QuantityUpDown;
        private System.Windows.Forms.Button EditQuantityOkButton;
        private System.Windows.Forms.Button EditQuantityCancelButton;
    }
}