﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TCP_IP_DB_INSERT_TEST
{
    class DBHelper
    {
        #region  DB 셋팅 
        public static string uid = "hnt";
        public static string password = "12#hnt";
        public static string database = "login";
        public static string server = "118.39.27.73,1433";
        #endregion

        SqlConnection conn = new SqlConnection($"SERVER={server}; DATABASE={database}; UID={uid}; PASSWORD={password};");
        SqlCommand cmd = new SqlCommand();

        public void Connect()  // DB 연결
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
        public void DisConnect()  // DB 연결 해제
        {
            conn.Close();
        }

        public void Query(string query)  // Query 메서드
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO Data values(CURRENT_TIMESTAMP, '{query}')";
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
        }
    }
}