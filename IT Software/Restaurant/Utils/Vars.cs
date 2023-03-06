using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Utils
{
    public class Vars
    {
        public static string ConnString = "Data Source=DESKTOP-GHNE639;Initial Catalog=DbRestaurant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static DbRestaurantEntities db = new DbRestaurantEntities();
        public static string StorageDir = @"C:\Users\" + Environment.UserName + @"\Desktop\Restaurant\Images";
        public static DataTable dtMember = new DataTable();
        public static DataTable dtEmployee = new DataTable();
    }
}
