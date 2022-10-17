using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_TEST
{
    class DBHelper
    {
        public static string uid = "test";
        public static string password = "1234";
        public static string database = "login";
        public static string server = "localhost";
        private SqlConnection conn = new SqlConnection($"SERVER={server}; DATABASE={database}; UID={uid}; PASSWORD={password}");
        SqlCommand cmd = new SqlCommand();

        public void Connect()
        {
            int i = 0;
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("연결실패 " + ex);
                i++;
            }
            if (i == 0)
            {
                MessageBox.Show("DB 연결성공");
            }
        }
        public void DisConnect()
        {
            conn.Close();
        }
        public void SignUpQuery(string id, string pass, string name)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"INSERT INTO login_Member values('{id}','{pass}','{name}')"; ;
            cmd.ExecuteNonQuery();
        }
        public void LoginQuery(string id, string pass)
        {
            cmd.Connection = conn;
            cmd.CommandText = $"SELECT * FROM login_Member WHERE ID = '{id}'";
            //cmd.ExecuteNonQuery();

            SqlDataReader mdr = cmd.ExecuteReader();
            while (mdr.Read())
            {
                if (id == (string)mdr["ID"] && pass == (string)mdr["PASSWORD"])
                {
                    MessageBox.Show("로그인 성공");
                    MainForm main = new MainForm();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("아이디/비밀번호를 확인하세요.");
                }
            }
            mdr.Close();
        }
    }
}

