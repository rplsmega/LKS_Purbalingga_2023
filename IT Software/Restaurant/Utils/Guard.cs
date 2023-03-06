using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Utils
{
    internal class Guard
    {
        public static bool FailAgainstNull(Control[] control)
        {
            bool isNull = false;
            foreach (Control c in control)
            {
                if (c is ComboBox)
                {
                    if (((ComboBox)c).SelectedIndex == -1)
                    {
                        isNull = true;
                        c.ShowTinyError();
                    } else {
                        c.ClearTinyError();
                    }
                }
                if (c is TextBox)
                {
                    if (c.Text.Length == 0)
                    {
                        isNull = true;
                        c.ShowTinyError();
                    } else {
                        c.ClearTinyError();
                    }
                }
            }
            return isNull;
        }
        public static bool FailAgainstNaN(string s)
        {
            Regex regex = new Regex("[0-9]");
            return !regex.IsMatch(s);
        }
        public static bool FailAgainstInvalidEmail(string email)
        {
            if (!email.Contains("@"))
            {
                return true;
            }
            if (!email.Contains("."))
            {
                return true;
            }
            return false;
        }
    }
}
