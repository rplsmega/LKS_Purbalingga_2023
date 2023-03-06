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
    public partial class ViewOrderForm : Form
    {
        public ViewOrderForm()
        {
            InitializeComponent();
            orderIDComboBox.Fill("select orderid from headorder", valueMember: "orderid", displayMember: "orderid");
            orderIDComboBox.Setup();
            StatusC.Fill(new string[]
            {
                "COOKING", "PENDING", "DELIVER"
            });
        }

        private void ViewOrderForm_Load(object sender, EventArgs e)
        {

        }

        private void orderIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderIDComboBox.SelectedIndex < 0) return;
            int orderid = Convert.ToInt32(orderIDComboBox.Text);
            FillDGV(orderid);
        }

        private void FillDGV(int orderid)
        {
            detailorderDataGridView.Rows.Clear();
            DataTable dt = Helper.GetDataTable($"select detailid, menu.name as 'Menu', status, qty from detailorder join menu on menu.menuid = detailorder.menuid where orderid = {orderid}");
            foreach (DataRow row in dt.Rows)
            {
                detailorderDataGridView.Rows.Add(row["detailid"], row["menu"], row["qty"], row["status"]);
            }
            detailorderDataGridView.Setup();
            detailorderDataGridView.ReadOnly = false;
        }

        private void detailorderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cmb = (ComboBox)e.Control;
            cmb.SelectedIndexChanged -= statusChangedIndex;
            cmb.SelectedIndexChanged += statusChangedIndex;
        }

        private void statusChangedIndex(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string status = cmb.Text;   
            string detailid = detailorderDataGridView.CurrentRow.Cells["detailidc"].Value.ToString();
            Helper.RunQuery($"update detailorder set status = '{status}' where detailid = '{detailid}'");
        }
    }
}
