namespace Restaurant
{
    partial class OrderForm
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
            System.Windows.Forms.Label menuIDLabel;
            System.Windows.Forms.Label qtyLabel;
            System.Windows.Forms.Label priceLabel;
            this.menuDataGridView = new System.Windows.Forms.DataGridView();
            this.orderDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuIDTextBox = new System.Windows.Forms.TextBox();
            this.qtyTextBox = new System.Windows.Forms.TextBox();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.menuidc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            menuIDLabel = new System.Windows.Forms.Label();
            qtyLabel = new System.Windows.Forms.Label();
            priceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.menuDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuDataGridView
            // 
            this.menuDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuDataGridView.Location = new System.Drawing.Point(12, 114);
            this.menuDataGridView.Name = "menuDataGridView";
            this.menuDataGridView.Size = new System.Drawing.Size(776, 163);
            this.menuDataGridView.TabIndex = 0;
            this.menuDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuDataGridView_CellClick);
            // 
            // orderDataGridView
            // 
            this.orderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.menuidc,
            this.MenuC,
            this.qtyC,
            this.priceC,
            this.TotalC});
            this.orderDataGridView.Location = new System.Drawing.Point(12, 432);
            this.orderDataGridView.Name = "orderDataGridView";
            this.orderDataGridView.Size = new System.Drawing.Size(776, 136);
            this.orderDataGridView.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(516, 288);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // menuIDLabel
            // 
            menuIDLabel.AutoSize = true;
            menuIDLabel.Location = new System.Drawing.Point(121, 311);
            menuIDLabel.Name = "menuIDLabel";
            menuIDLabel.Size = new System.Drawing.Size(40, 13);
            menuIDLabel.TabIndex = 16;
            menuIDLabel.Text = "Menu :";
            // 
            // menuIDTextBox
            // 
            this.menuIDTextBox.Location = new System.Drawing.Point(178, 308);
            this.menuIDTextBox.Name = "menuIDTextBox";
            this.menuIDTextBox.Size = new System.Drawing.Size(276, 20);
            this.menuIDTextBox.TabIndex = 17;
            // 
            // qtyLabel
            // 
            qtyLabel.AutoSize = true;
            qtyLabel.Location = new System.Drawing.Point(121, 337);
            qtyLabel.Name = "qtyLabel";
            qtyLabel.Size = new System.Drawing.Size(26, 13);
            qtyLabel.TabIndex = 18;
            qtyLabel.Text = "Qty:";
            // 
            // qtyTextBox
            // 
            this.qtyTextBox.Location = new System.Drawing.Point(178, 334);
            this.qtyTextBox.Name = "qtyTextBox";
            this.qtyTextBox.Size = new System.Drawing.Size(276, 20);
            this.qtyTextBox.TabIndex = 19;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(121, 363);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new System.Drawing.Size(34, 13);
            priceLabel.TabIndex = 20;
            priceLabel.Text = "Price:";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(178, 360);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(276, 20);
            this.priceTextBox.TabIndex = 21;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(287, 590);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(76, 24);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "Total : 0";
            // 
            // menuidc
            // 
            this.menuidc.HeaderText = "menuid";
            this.menuidc.Name = "menuidc";
            this.menuidc.Visible = false;
            // 
            // MenuC
            // 
            this.MenuC.HeaderText = "Menu";
            this.MenuC.Name = "MenuC";
            // 
            // qtyC
            // 
            this.qtyC.HeaderText = "Qty";
            this.qtyC.Name = "qtyC";
            // 
            // priceC
            // 
            this.priceC.HeaderText = "Price";
            this.priceC.Name = "priceC";
            // 
            // TotalC
            // 
            this.TotalC.HeaderText = "Total";
            this.TotalC.Name = "TotalC";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(178, 590);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Order";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "MENU ORDER";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 632);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(menuIDLabel);
            this.Controls.Add(this.menuIDTextBox);
            this.Controls.Add(qtyLabel);
            this.Controls.Add(this.qtyTextBox);
            this.Controls.Add(priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.orderDataGridView);
            this.Controls.Add(this.menuDataGridView);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Form";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView menuDataGridView;
        private System.Windows.Forms.DataGridView orderDataGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox menuIDTextBox;
        private System.Windows.Forms.TextBox qtyTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn menuidc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuC;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyC;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalC;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
    }
}