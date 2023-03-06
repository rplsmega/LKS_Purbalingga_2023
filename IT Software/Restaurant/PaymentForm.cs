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
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
            orderIDComboBox.Fill("select orderid from headorder where payment = '-'", valueMember: "orderid", displayMember: "orderid");
            orderIDComboBox.Setup();
            FillDGV();
            paymentComboBox.Fill(new string[]
            {
                "CASH", "CREDIT CARD", "DEBIT CARD"
            });
            paymentComboBox.Setup();
        }

        private void FillDGV(int orderid = -1)
        {
            if (orderid == -1) return;
            detailorderDataGridView.DataSource = Vars.db.Detailorders.Where(d => d.OrderID == orderid).Select(d => new
            {
                Menu = d.Menu.Name,
                Qty = d.Qty,
                Price = d.Price,
                Total = d.Qty * d.Price
            }).ToList();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
        }

        private void orderIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderIDComboBox.SelectedIndex < 0) return;
            int orderid = Convert.ToInt32(orderIDComboBox.Text);
            FillDGV(orderid);
            int total = 0;
            foreach(DataGridViewRow row in detailorderDataGridView.Rows)
            {
                total += Convert.ToInt32(row.Cells["total"].Value);
            }
            lblTotal.Text = $"Total: {total}";
        }

        private void paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderid = orderIDComboBox.Text;
            switch (paymentComboBox.SelectedIndex)
            {
                case 0:
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(new CashUC(orderid));
                    break;
                case 1:
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(new NonCashUC(orderid));
                    break;
                case 2:
                    flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.Add(new NonCashUC(orderid));
                    break;
                default:
                    flowLayoutPanel1.Controls.Clear();
                    break;
            }
        }
    }
}
