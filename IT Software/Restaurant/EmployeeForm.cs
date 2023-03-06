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
    public partial class EmployeeForm : Form
    {
        Control[] insertInputField;
        Control[] updateInputField;
        Control[] clearableInputField;
        public EmployeeForm()
        {
            InitializeComponent();
            FillDGV();
            insertInputField = new Control[]
            {
                nameTextBox, emailTextBox, passwordTextBox, handphoneTextBox
            };
            updateInputField = new Control[]
            {
                nameTextBox, emailTextBox, passwordTextBox, handphoneTextBox, employeeIDTextBox
            };
            clearableInputField = updateInputField;
            positionComboBox.Fill(new string[]
            {
                "ADMIN",
                "CASHIER",
                "CHEF"
            });
            positionComboBox.Setup();
        }

        private void FillDGV()
        {
            employeeDataGridView.DataSource = Vars.db.Employees.Select(emp => new
            {
                emp.EmployeeID,
                emp.Name,
                emp.Email,
                emp.Handphone,
                emp.Position
            }).ToList();
            employeeDataGridView.Setup();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstInvalidEmail(emailTextBox.Text)) {
                Helper.ShowError("invalid email address");
                return;
            }
            if (Guard.FailAgainstNaN(handphoneTextBox.Text)) 
            {
                Helper.ShowError("invalid phone number");
                return;
            }
            if (Guard.FailAgainstNull(insertInputField))
            {
                Helper.ShowError();
                return;
            }
            Employee emp = new Employee
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Handphone = handphoneTextBox.Text,
                Position = positionComboBox.Text,
                Password = Helper.Hash(positionComboBox.Text)
            };
            Vars.db.Employees.Add(emp);
            Vars.db.SaveChanges();
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstInvalidEmail(emailTextBox.Text)) {
                Helper.ShowError("invalid email address");
                return;
            }
            if (Guard.FailAgainstNaN(handphoneTextBox.Text))
            {
                Helper.ShowError("invalid phone number");
                return;
            }
            if (Guard.FailAgainstNull(updateInputField))
            {
                Helper.ShowError();
                return;
            }
            Employee emp = Vars.db.Employees.Find(Convert.ToInt32(employeeIDTextBox.Text));
            emp.Name= nameTextBox.Text;
            emp.Email= emailTextBox.Text;
            emp.Handphone = handphoneTextBox.Text;
            emp.Position = positionComboBox.Text;
            emp.Password = Helper.Hash(passwordTextBox.Text);
            Vars.db.SaveChanges();
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = employeeDataGridView.CurrentRow;
            if (row.Index == -1)
            {
                Helper.ShowError("Please select an employee first");
                return;
            }
            string employeeid = employeeIDTextBox.Text;
            Helper.RunQuery($"delete from employee where employeeid = {employeeid}");
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void employeeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = employeeDataGridView.CurrentRow;
            employeeIDTextBox.Text = row.Cells["employeeid"].Value.ToString();
            nameTextBox.Text = row.Cells["name"].Value.ToString();
            handphoneTextBox.Text = row.Cells["handphone"].Value.ToString();
            emailTextBox.Text = row.Cells["email"].Value.ToString();
            positionComboBox.Text = row.Cells["position"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            employeeDataGridView.GenerateExcel($"List of employee {DateTime.Now:yyyy-MM-dd HH-mm-ss}");
        }
    }
}
