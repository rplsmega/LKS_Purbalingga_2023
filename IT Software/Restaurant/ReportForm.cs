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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.Series.Add("Income");
            string[] nums = new string[12];
            string[] names = new string[12];
            for (int i = 0; i < 12; i++)
            {
                nums[i] = (i + 1).ToString();
                names[i] = new DateTime(DateTime.Now.Year, (i + 1), 1).ToString("MMMM");
            }
            cmbFrom.Fill(displayMembers: names, valueMembers: nums);
            cmbFrom.Setup();
            cmbTo.Fill(displayMembers: names, valueMembers: nums);
            cmbTo.Setup();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dateFrom = new DateTime(DateTime.Now.Year, Convert.ToInt32(cmbFrom.SelectedValue), 1).ToString("yyyy-MM-dd");
            string dateTo = new DateTime(DateTime.Now.Year, Convert.ToInt32(cmbTo.SelectedValue), 1).ToString("yyyy-MM-dd");
            DataTable dt = Helper.GetDataTable($"select month(date) as 'month', sum(qty * price) as 'income' from headorder join detailorder on detailorder.orderid = headorder.orderid where date >= '{dateFrom}' and date < '{dateTo}' group by month(date)");
            chart1.DataSource = dt;
            foreach (DataRow row in dt.Rows)
            {
                chart1.Series["Income"].Points.AddXY(row["month"], row["income"]);
            }
            dataGridView1.DataSource = dt.AsEnumerable().Select(d => new 
            {
                Month = new DateTime(DateTime.Now.Year, d.Field<int>("month"), 1).ToString("MMMM"),
                Income = d.Field<int>("income")
            }).ToList();
            dataGridView1.Setup();
        }
    }
}
