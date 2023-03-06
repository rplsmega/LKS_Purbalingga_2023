using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Utils
{
    public class Helper
    {
        public static DialogResult AskForConfirmation()
        {
            return MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static string Hash(string input)
        {
            using (var hasher = SHA256.Create())
            {
                byte[ ] res = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder= new StringBuilder();
                foreach (byte b in res)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(Vars.ConnString);
        }
        public static DataTable GetDataTable(string query)
        {
            using (var conn = GetConnection())
            {
                DataTable dt = new DataTable();
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }
        public static void ShowError(string message = "Inputs Cannot Be Empty")
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void RunQuery(string query)
        {
            using (var conn = GetConnection()) 
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();  
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
        }
        public static void Clear(Control[] controls)
        {
            foreach (Control control in controls)
            {
                if (control is ComboBox )
                {
                    (control as ComboBox).SelectedIndex = -1;
                }
                if (control is DataGridView)
                {
                    (control as DataGridView).DataSource = null;
                    (control as DataGridView).Rows.Clear();
                }
                if (control is PictureBox)
                {
                    (control as PictureBox).Image = null;
                }
                control.Text = "";
            }
        }
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
