using Restaurant.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class OrderForm : Form
    {
        string menuid = "";
        public OrderForm()
        {
            InitializeComponent();
            FillMenuDGV();
        }

        private void FillMenuDGV()
        {
            menuDataGridView.DataSource = Vars.db.Menus.Select(m => new
            {
                MenuID = m.MenuID,
                Name = m.Name,
                Price = m.Price,
                Photo = m.Photo,
            }).ToList();
            menuDataGridView.Columns["menuid"].Visible = false;
            menuDataGridView.Columns["photo"].Visible = false;
            menuDataGridView.Setup();
            orderDataGridView.Setup();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
        }

        private void menuDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = menuDataGridView.CurrentRow;
            menuIDTextBox.Text = row.Cells["name"].Value.ToString();
            priceTextBox.Text = row.Cells["price"].Value.ToString();
            pictureBox1.Image = Image.FromFile(Path.Combine(Vars.StorageDir, row.Cells["photo"].Value.ToString()));
            menuid = row.Cells["menuid"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstNaN(qtyTextBox.Text))
            {
                Helper.ShowError("invalid price number");
                return;
            }
            if (Guard.FailAgainstNull(new Control[]
            {
                qtyTextBox, menuIDTextBox, priceTextBox
            }))
            {
                Helper.ShowError();
                return;
            }
            string price = priceTextBox.Text;
            string qty = qtyTextBox.Text;
            string name = menuIDTextBox.Text;
            orderDataGridView.Rows.Add(menuid, name, qty, price, Convert.ToInt32(qty) * Convert.ToInt32(price));
            int total = 0;
            foreach (DataGridViewRow row in orderDataGridView.Rows )
            {
                total += Convert.ToInt32(row.Cells["totalc"].Value);
            }
            lblTotal.Text = $"Total : {total.FormatIDR()}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int orderid = Convert.ToInt32(DateTime.Now.ToString("yyyyMM001"));
            if (Helper.GetDataTable($"select * from headorder where orderid >= '{orderid}'").Rows.Count >= 0)
            {
                orderid = Convert.ToInt32(Helper.GetDataTable("select max (orderid) as 'orderid' from headorder ").Rows[0]["orderid"]) + 1;
            }
            int employeeID = Convert.ToInt32(Vars.dtEmployee.Rows[0]["employeeid"]);
            int memberID = Convert.ToInt32(Vars.dtMember.Rows[0]["memberid"]);
            DateTime date = DateTime.Now;
            string payment = "-";
            string bank = "-";
            Headorder headorder = new Headorder
            {
                OrderID = orderid,
                MemberID = memberID,
                EmployeeID = employeeID,
                Date = date,
                Payment = payment,
                Bank = bank
            };
            Vars.db.Headorders.Add(headorder);
            Vars.db.SaveChanges();
            foreach (DataGridViewRow row in orderDataGridView.Rows)
            {
                Detailorder detailorder = new Detailorder
                {
                    OrderID = orderid,
                    MenuID = Convert.ToInt32(row.Cells["menuidc"].Value),
                    Qty = Convert.ToInt32(row.Cells["qtyc"].Value),
                    Price = Convert.ToInt32(row.Cells["pricec"].Value),
                    Status = "COOKING"
                };
                Vars.db.Detailorders.Add(detailorder);
                Vars.db.SaveChanges();
            }
            Helper.ShowInfo("Your order has been submitted");
            Helper.Clear(new Control[]
            {
                orderDataGridView, qtyTextBox, priceTextBox, menuIDTextBox
            });
        }
    }
}
