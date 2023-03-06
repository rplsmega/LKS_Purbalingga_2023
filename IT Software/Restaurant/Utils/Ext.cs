using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Utils
{
    public static class Ext
    {
        public static ErrorProvider ep = new ErrorProvider();
        public static void Setup(this DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows= false;
        }
        public static void Fill(this ComboBox cmb, string query, string valueMember, string displayMember = "name")
        {
            System.Data.DataTable dt = Helper.GetDataTable(query);
            cmb.DataSource = dt;
            cmb.ValueMember= valueMember;
            cmb.DisplayMember= displayMember;
        }
        public static void Fill(this ComboBox cmb, string[] displayMembers, string[] valueMembers)
        {
            if (valueMembers.Length != displayMembers.Length)
            {
                throw new ArgumentException("array length mismatch");
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("valueMember");
            dt.Columns.Add("displayMember");
            for (int i = 0; i < valueMembers.Length; i++)
            {
                dt.Rows.Add(valueMembers[i], displayMembers[i]);
            }
            cmb.DataSource = dt;
            cmb.ValueMember = "valueMember";
            cmb.DisplayMember = "displayMember";
        }
        public static void Fill(this ComboBox cmb, string[] items)
        {
            cmb.Items.Clear();
            foreach (string item in items)
            {
                cmb.Items.Add(item);
            }
        }
        public static void Fill(this DataGridViewComboBoxColumn cmb, string[] items)
        {
            cmb.Items.Clear();
            foreach (string item in items)
            {
                cmb.Items.Add(item);
            }
        }
        public static void Setup(this ComboBox cmb)
        {
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.SelectedIndex = -1;
        }
        public static void ShowTinyError(this Control c, string message = "Input cannot be empty")
        {
            ep.SetError(c, message);
        }
        public static void ClearTinyError(this Control c)
        {
            ep.SetError(c, "");
        }
        public static string FormatIDR(this int s)
        {
            return s.ToString("C", CultureInfo.GetCultureInfo("id-ID"));
        }
        public static void GenerateExcel(this DataGridView dgv, string filename)
        {
            dgv.SelectAll();
            DataObject obj = dgv.GetClipboardContent();
            Clipboard.SetDataObject(obj);
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet ws = wb.Worksheets[1];
            app.Visible = true;
            Range range = ws.Cells[1, 1];
            var missing = Type.Missing;
            ws.PasteSpecial(range, missing, missing, missing, missing, missing, true);
            ws.SaveAs(filename, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            dgv.ClearSelection();
        }
    }
}
