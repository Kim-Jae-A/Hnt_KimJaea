using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DH_LED_Controller
{
    class DBHelper
    {
        public static string uid = "sa";
        public static string password = "hntadmin";
        public static string database = "PLC_YJFAB";
        public static string server = "118.39.27.73,1500";
        SqlConnection conn = new SqlConnection($"SERVER={server}; DATABASE={database}; UID={uid}; PASSWORD={password};");
        SqlCommand cmd = new SqlCommand();

        public void Connect()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("연결실패 " + ex);
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
        }
        public void DisConnect()
        {
            conn.Close();
        }
    }
}
