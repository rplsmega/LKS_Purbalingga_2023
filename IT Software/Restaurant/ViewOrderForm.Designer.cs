namespace Restaurant
{
    partial class ViewOrderForm
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
            System.Windows.Forms.Label orderIDLabel;
            this.detailorderDataGridView = new System.Windows.Forms.DataGridView();
            this.orderIDComboBox = new System.Windows.Forms.ComboBox();
            this.detailidC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            orderIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detailorderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // detailorderDataGridView
            // 
            this.detailorderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailorderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detailidC,
            this.MenuC,
            this.QtyC,
            this.StatusC});
            this.detailorderDataGridView.Location = new System.Drawing.Point(32, 40);
            this.detailorderDataGridView.Name = "detailorderDataGridView";
            this.detailorderDataGridView.Size = new System.Drawing.Size(734, 236);
            this.detailorderDataGridView.TabIndex = 6;
            this.detailorderDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.detailorderDataGridView_EditingControlShowing);
            // 
            // orderIDLabel
            // 
            orderIDLabel.AutoSize = true;
            orderIDLabel.Location = new System.Drawing.Point(288, 16);
            orderIDLabel.Name = "orderIDLabel";
            orderIDLabel.Size = new System.Drawing.Size(50, 13);
            orderIDLabel.TabIndex = 4;
            orderIDLabel.Text = "Order ID:";
            // 
            // orderIDComboBox
            // 
            this.orderIDComboBox.FormattingEnabled = true;
            this.orderIDComboBox.Location = new System.Drawing.Point(344, 13);
            this.orderIDComboBox.Name = "orderIDComboBox";
            this.orderIDComboBox.Size = new System.Drawing.Size(161, 21);
            this.orderIDComboBox.TabIndex = 5;
            this.orderIDComboBox.SelectedIndexChanged += new System.EventHandler(this.orderIDComboBox_SelectedIndexChanged);
            // 
            // detailidC
            // 
            this.detailidC.HeaderText = "Detailid";
            this.detailidC.Name = "detailidC";
            this.detailidC.Visible = false;
            // 
            // MenuC
            // 
            this.MenuC.HeaderText = "Menu";
            this.MenuC.Name = "MenuC";
            // 
            // QtyC
            // 
            this.QtyC.HeaderText = "Qty";
            this.QtyC.Name = "QtyC";
            // 
            // StatusC
            // 
            this.StatusC.HeaderText = "Status";
            this.StatusC.Name = "StatusC";
            // 
            // ViewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.detailorderDataGridView);
            this.Controls.Add(orderIDLabel);
            this.Controls.Add(this.orderIDComboBox);
            this.Name = "ViewOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Order Form";
            this.Load += new System.EventHandler(this.ViewOrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailorderDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView detailorderDataGridView;
        private System.Windows.Forms.ComboBox orderIDComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailidC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuC;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyC;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatusC;
    }
}