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
        public static string database = "SF_DJFAB";
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
        public string[] Query(string num)
        {
            string[] query = new string[4];

            cmd.Connection = conn;

            //데이터 쿼리문
            cmd.CommandText = "SELECT COD_ITEM, NAM_ITEM, COM_WARE, COM_SAVE FROM BP0100_ITEMS"+
                $"\r\nWHERE NAM_ITEM LIKE '{num}'";

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
            SqlDataReader mdr = cmd.ExecuteReader();
            mdr.Read();

            query[0] += (String)mdr["NAM_ITEM"];   // 품번코드
            query[1] += (String)mdr["COM_WARE"];   // 경광등 그룹아이디
            query[2] += (String)mdr["COM_SAVE"];   // 경광등 노드아이디

            mdr.Close();

            return query;
        }
    }
}
