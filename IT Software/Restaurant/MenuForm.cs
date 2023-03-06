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
using System.Web;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class MenuForm : Form
    {
        string imageName = "";
        bool imageChanged = false;
        Control[] insertInputField;
        Control[] updateInputField;
        Control[] clearableInputField;
        public MenuForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(Vars.StorageDir);
            FillDGV();
            insertInputField = new Control[]
            {
                nameTextBox, priceTextBox, photoTextBox
            };
            updateInputField = new Control[]
            {
                nameTextBox, priceTextBox, photoTextBox, menuIDTextBox
            };
            clearableInputField = new Control[]
            {
                nameTextBox, priceTextBox, photoTextBox, menuIDTextBox, pictureBox1
            };
        }

        private void FillDGV()
        {
            menuDataGridView.DataSource = Vars.db.Menus.Select(m => new
            {
                MenuID = m.MenuID,
                Name = m.Name,
                Price = m.Price,
                Photo = m.Photo
            }).ToList();
            menuDataGridView.Columns["photo"].Visible = false;
            menuDataGridView.Setup();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageChanged = true;
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Image only (*.png; *.jpg; *.jpeg) | *.png; *.jpg; *.jpeg",
                Multiselect = false
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageName = ofd.FileName;
                photoTextBox.Text = ofd.SafeFileName;
                pictureBox1.Image = new Bitmap(imageName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstNaN(priceTextBox.Text))
            {
                Helper.ShowError("invalid price number");
                return;
            }
            if (Guard.FailAgainstNull(insertInputField))
            {
                Helper.ShowError();
                return;
            }
            Menu menu = new Menu()
            {
                Name = nameTextBox.Text,
                Price = Convert.ToInt32(priceTextBox.Text),
                Photo = photoTextBox.Text
            };
            File.Copy(imageName,
                Path.Combine(Vars.StorageDir, photoTextBox.Text),
                true);
            Vars.db.Menus.Add(menu);
            Vars.db.SaveChanges();
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Guard.FailAgainstNaN(priceTextBox.Text))
            {
                Helper.ShowError("invalid price number");
                return;
            }
            if (Guard.FailAgainstNull(updateInputField))
            {
                Helper.ShowError();
                return;
            }
            if (imageChanged)
            {
                File.Copy(imageName,
                    Path.Combine(Vars.StorageDir, photoTextBox.Text),
                    true);
            }
            Menu menu = Vars.db.Menus.Find(Convert.ToInt32(menuIDTextBox.Text));
            menu.Name = nameTextBox.Text;
            menu.Price= Convert.ToInt32(priceTextBox.Text);
            menu.Photo= photoTextBox.Text;
            Vars.db.SaveChanges();
            FillDGV();
            Helper.Clear(clearableInputField);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = menuDataGridView.CurrentRow;
            if (row.Index == -1)
            {
                Helper.ShowError("Please select an employee first");
                return;
            }
            string menuid = menuIDTextBox.Text;
            Helper.RunQuery($"delete from menu where menuid = {menuid}");
            FillDGV();
        }

        private void menuDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = menuDataGridView.CurrentRow;
            menuIDTextBox.Text = row.Cells["menuid"].Value.ToString();
            nameTextBox.Text = row.Cells["name"].Value.ToString();
            priceTextBox.Text = row.Cells["price"].Value.ToString();
            photoTextBox.Text = row.Cells["photo"].Value.ToString();
            pictureBox1.Image = Image.FromFile(Path.Combine(Vars.StorageDir, photoTextBox.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menuDataGridView.GenerateExcel($"List of employee {DateTime.Now:yyyy-MM-dd HH-mm-ss}");
        }
    }
}
