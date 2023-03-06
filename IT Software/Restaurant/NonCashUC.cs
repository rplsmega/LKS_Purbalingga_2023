using Restaurant.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class NonCashUC : UserControl
    {
        string orderid = "";
        public NonCashUC(string orderid)
        {
            InitializeComponent();
            this.orderid= orderid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataGridView detailorderDataGridView = (DataGridView)Parent.Parent.Controls.Find("detailorderDataGridView", true)[0];
            ComboBox paymentComboBox = (ComboBox)Parent.Parent.Controls.Find("paymentComboBox", true)[0];
            ComboBox orderidComboBox = (ComboBox)Parent.Parent.Controls.Find("orderIDComboBox", true)[0];
            Label lblTotal = (Label)Parent.Parent.Controls.Find("lblTotal", true)[0];
            string payment = paymentComboBox.Text;
            string bank = bankComboBox.Text;
            Helper.RunQuery($"update headorder set payment = '{payment}', bank = '{bank}' where orderid = {orderid}");
            Helper.ShowInfo("Your order has been paid");
            Helper.Clear(new Control[]
            {
                detailorderDataGridView,paymentComboBox, orderidComboBox, lblTotal
            });
        }
    }
}
