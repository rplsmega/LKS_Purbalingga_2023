namespace Restaurant
{
    partial class CashUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label label1;
            this.bayarTextBox = new System.Windows.Forms.TextBox();
            this.kembaliTextBox = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            nameLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(21, 25);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(37, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Bayar:";
            // 
            // bayarTextBox
            // 
            this.bayarTextBox.Location = new System.Drawing.Point(74, 22);
            this.bayarTextBox.Name = "bayarTextBox";
            this.bayarTextBox.Size = new System.Drawing.Size(270, 20);
            this.bayarTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 51);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 13);
            label1.TabIndex = 3;
            label1.Text = "Kembali:";
            // 
            // kembaliTextBox
            // 
            this.kembaliTextBox.Location = new System.Drawing.Point(74, 48);
            this.kembaliTextBox.Name = "kembaliTextBox";
            this.kembaliTextBox.Size = new System.Drawing.Size(270, 20);
            this.kembaliTextBox.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(269, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CashUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(label1);
            this.Controls.Add(this.kembaliTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.bayarTextBox);
            this.Name = "CashUC";
            this.Size = new System.Drawing.Size(359, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox bayarTextBox;
        private System.Windows.Forms.TextBox kembaliTextBox;
        private System.Windows.Forms.Button btnSave;
    }
}
