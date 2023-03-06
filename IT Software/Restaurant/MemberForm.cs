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
    public partial class MemberForm : Form
    {
        Control[] insertInputField;
        Control[] updateInputField;
        Control[] clearableInputField;
        public MemberForm()
        {
            InitializeComponent();
            FillDGV();
            insertInputField = new Control[]
            {
                nameTextBox, emailTextBox, handphoneTextBox
            };
            updateInputField = new Control[]
            {
                nameTextBox, emailTextBox, handphoneTextBox, memberIDTextBox
            };
            clearableInputField = updateInputField;
        }

        private void FillDGV()
        {
            memberDataGridView.DataSource = Vars.db.Members.Select(m => new
            {
                MemberID = m.MemberID,
                Name = m.Name,
                Email = m.Email,
                Handphone = m.Handphone,
                Join_Date = m.Joindate
            }).ToList();
            memberDataGridView.Setup();
        }

        private void MemberForm_Load(object sender, EventArgs e)
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
            Member member = new Member
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Handphone = handphoneTextBox.Text,
                Joindate = DateTime.Now
            };
            Vars.db.Members.Add(member);
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
            if (Guard.FailAgainstNull(updateInputField ))
            {
                Helper.ShowError();
                return;
            }
            Member member = Vars.db.Members.Find(Convert.ToInt32(memberIDTextBox.Text));
            member.Name = nameTextBox.Text;
            member.Email = emailTextBox.Text;
            member.Handphone= handphoneTextBox.Text;
            Vars.db.SaveChanges();
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = memberDataGridView.CurrentRow;
            if (row.Index == -1)
            {
                Helper.ShowError("Please select an employee first");
                return;
            }
            string memberid = memberIDTextBox.Text;
            Helper.RunQuery($"delete from member where memberid = {memberid}");
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void memberDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = memberDataGridView.CurrentRow;
            memberIDTextBox.Text = row.Cells["memberid"].Value.ToString();
            nameTextBox.Text = row.Cells["name"].Value.ToString();
            handphoneTextBox.Text = row.Cells["handphone"].Value.ToString();
            emailTextBox.Text = row.Cells["email"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            memberDataGridView.GenerateExcel($"List of employee {DateTime.Now:yyyy-MM-dd HH-mm-ss}");
        }
    }
}
