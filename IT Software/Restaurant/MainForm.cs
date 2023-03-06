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
    public partial class MainForm : Form
    {
        ToolStripItem[] admin;
        ToolStripItem[] chef;
        ToolStripItem[] cashier;
        ToolStripItem[] toDisable;
        public MainForm()
        {
            InitializeComponent();
            admin = new ToolStripItem[]
            {
                lOGINToolStripMenuItem
            };
            chef = new ToolStripItem[]
            {
                lOGINToolStripMenuItem, dATAToolStripMenuItem, tRANSACTIONToolStripMenuItem, rEPORTToolStripMenuItem
            };
            cashier = new ToolStripItem[]
            {
                lOGINToolStripMenuItem, dATAToolStripMenuItem, cHEFToolStripMenuItem, rEPORTToolStripMenuItem
            };
            switch (Vars.dtEmployee.Rows[0]["position"])
            {
                case "ADMIN":
                    toDisable = admin;
                    break;
                case "CHEF":
                    toDisable = chef;
                    break;
                case "CASHIER":
                    toDisable = cashier;
                    break;
            }
        }

        private void kARYAWANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmployeeForm().ShowDialog();
        }

        private void mEMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MemberForm().ShowDialog();
        }

        private void mENURESTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MenuForm().ShowDialog();
        }

        private void oRDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new PreoderForm().ShowDialog() != DialogResult.OK) return;

            new OrderForm().ShowDialog();
        }

        private void pAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PaymentForm().ShowDialog();
        }

        private void rEPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ReportForm().ShowDialog();
        }

        private void vIEWORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ViewOrderForm().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in toDisable)
            {
                item.Enabled = false;
            }
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.AskForConfirmation() != DialogResult.Yes) return;
            Hide();
            new LoginForm().ShowDialog();
            Close();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.AskForConfirmation() != DialogResult.Yes) return;
            Application.Exit();
        }
    }
}
