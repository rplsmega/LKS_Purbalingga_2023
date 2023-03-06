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
    public partial class PreoderForm : Form
    {
        public PreoderForm()
        {
            InitializeComponent();
            memberComboBox.Fill("select * from member", "memberid");
            memberComboBox.Setup();
        }

        private void PreoderForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Vars.dtMember = Helper.GetDataTable($"select * from member where memberid = {memberComboBox.SelectedValue}");
            this.Close();
        }
    }
}
