using Microsoft.SqlServer.Server;
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
    public partial class LoginForm : Form
    {
        bool hidePW = false;
        public LoginForm()
        {
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = !hidePW;
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void cbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            hidePW = !hidePW;
            passwordTextBox.UseSystemPasswordChar = hidePW;
            passwordTextBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstInvalidEmail(emailTextBox.Text))
            {
                Helper.ShowError("Invalid Email");
                return;
            }
            if (Guard.FailAgainstNull(new Control[] { emailTextBox, passwordTextBox }))
            {
                Helper.ShowError();
                return;
            }
            string email = emailTextBox.Text ;
            string password = Helper.Hash(passwordTextBox.Text);
            Vars.dtEmployee = Helper.GetDataTable($"select * from employee where email = '{email}' and password = '{password}'");
            if (Vars.dtEmployee.Rows.Count < 1)
            {
                Helper.ShowError("User not found");
                return;
            }
            Hide();
            new MainForm().ShowDialog();
            Close();
        }
    }
}
