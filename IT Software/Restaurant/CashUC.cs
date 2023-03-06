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
    public partial class CashUC : UserControl
    {
        string orderid = "";
        public CashUC(string orderid)
        {
            InitializeComponent();
            this.orderid = orderid; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstNull(new Control[]
            {
                bayarTextBox
            }))
            {
                Helper.ShowError();
                return;
            }
            int total = Convert.ToInt32(Helper.GetDataTable($"select sum(qty * price) as 'total' from detailorder where orderid = '{orderid}'").Rows[0]["total"]);
            if (Convert.ToInt32(bayarTextBox.Text) < total)
            {
                Helper.ShowError("The amount recieved was less than exptected");
                return;
            }
            DataGridView detailorderDataGridView = (DataGridView)Parent.Parent.Controls.Find("detailorderDataGridView", true)[0];
            ComboBox paymentComboBox = (ComboBox)Parent.Parent.Controls.Find("paymentComboBox", true)[0];
            ComboBox orderidComboBox = (ComboBox)Parent.Parent.Controls.Find("orderIDComboBox", true)[0];
            Label lblTotal = (Label)Parent.Parent.Controls.Find("lblTotal", true)[0];
            Helper.RunQuery($"update headorder set payment = 'CASH' where orderid = {orderid}");
            Helper.ShowInfo("Your order has been paid");
            Helper.Clear(new Control[]
            {
                detailorderDataGridView,paymentComboBox, orderidComboBox, lblTotal
            });
        }
    }
}
