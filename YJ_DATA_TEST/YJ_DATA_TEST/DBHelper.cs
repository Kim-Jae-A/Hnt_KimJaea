using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YJ_DATA_TEST
{
    class DBHelper
    {
        public static string uid = "hnt";
        public static string password = "12#hnt";
        public static string database = "PLC_YJFAB";
        public static string server = "106.241.185.138,5009";
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
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
        }
        public void DisConnect()
        {
            conn.Close();
        }
        public string[] Query()
        {
            string[] query = new string[16];
            
            cmd.Connection = conn;

            //데이터 쿼리문
            cmd.CommandText = "USE PLC_YJFAB"+                    
                "\r\nSELECT TOP(1) M1.DAY_EVENT, M1.VAL_SIGNAL3 AS CH1," +
                "\r\nM1.VAL_SIGNAL4 AS CH2," +
                "\r\nM1.VAL_SIGNAL5 AS CH3," +
                "\r\nM1.VAL_SIGNAL6 AS CH4," +
                "\r\nM1.VAL_SIGNAL7 AS CH5," +
                "\r\nM2.VAL_SIGNAL3 AS CH6," +
                "\r\nM2.VAL_SIGNAL4 AS CH7," +
                "\r\nM2.VAL_SIGNAL5 AS CH8," +
                "\r\nM2.VAL_SIGNAL6 AS CH9," +
                "\r\nM2.VAL_SIGNAL7 AS CH10," +
                "\r\nM3.VAL_SIGNAL1 AS CH11," +
                "\r\nM3.VAL_SIGNAL2 AS CH12," +
                "\r\nM3.VAL_SIGNAL3 AS CH13," +
                "\r\nM3.VAL_SIGNAL4 AS CH14," +
                "\r\nM3.VAL_SIGNAL5 AS CH15" +
                "\r\nFROM MD0110_LOG AS M1" +
                "\r\nLEFT JOIN MD0110_LOG AS M2 ON M1.DAY_EVENT = M2.DAY_EVENT" +
                "\r\nLEFT JOIN MD0110_LOG AS M3 ON M1.DAY_EVENT = M3.DAY_EVENT" +
                "\r\nWHERE M1.COD_DEVICE = 'YJ-002' AND M2.COD_DEVICE = 'YJ-003' AND M3.COD_DEVICE = 'YJ-004'" +
                "\r\nORDER BY M1.DAY_EVENT DESC";

            try 
            { 
                cmd.ExecuteNonQuery(); 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
            SqlDataReader mdr = cmd.ExecuteReader();
            mdr.Read();
            query[0] += (DateTime)mdr["DAY_EVENT"];
            query[0] = (DateTime.Parse(query[0]).ToUniversalTime().ToString("yyMMddHHmmss"));
            for (int i = 1; i < query.Length; i++)
            {
                query[i] += string.Format("{0:0.00}", (double)mdr[$"CH{i}"]);
            }
            mdr.Close();

            return query;
        }
    }
}
