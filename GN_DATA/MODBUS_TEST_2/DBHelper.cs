using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MODBUS_TEST_2
{
    class DBHelper
    {
        public static string uid = "hnt";
        public static string password = "12#hnt";
        public static string database = "SF_JNFAB";
        public static string server = "58.234.148.135,1433";
        //public static string server = "118.39.27.73,1500";

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
                //Console.WriteLine($"{DateTime.Now} " + ex);
                ErrorQuery($"{DateTime.Now}", $"{ex}");
            }
        }
        public void DisConnect()
        {
            conn.Close();
        }
        public void Query(float tem1, float tem2, float tem3, float tem4, float per1, float per2, float per3, float ph)
        {
            cmd.Connection = conn;
            cmd.CommandText = "INSERT into MD0110_LOG (COD_DEVICE,DAY_EVENT,VAL_SIGNAL1,VAL_SIGNAL2,VAL_SIGNAL3,VAL_SIGNAL4) " +
                "\r\nvalues " +
                $"\r\n('GN-001', getdate(), {tem1}, {tem2}, {tem3},{tem4})," +
                $"\r\n('GN-002', getdate(), {per1}, {per2}, {per3}, null)," +
                $"\r\n('GN-003', getdate(), null, null, null, {ph});";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"{DateTime.Now} " + ex);
                ErrorQuery($"{DateTime.Now}", $"{ex}");
            }
        }
        public void ErrorQuery(string time, string code)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT E0000_SENSORLOG (ERROR_DAY, ERROR_LOG) VALUES ('{time}','{code}')";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} " + ex);
            }
        }
    }
}
