using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_TEST
{
    public partial class SignUpForm : Form
    {
        DBHelper dbconn = new DBHelper();
        public SignUpForm()
        {
            dbconn.Connect();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pass = textBox2.Text;
            string name = textBox3.Text;
            int i = 0;
             
            try
            {
                dbconn.SignUpQuery(id, pass, name);
            }
            catch (SqlException)
            {
                MessageBox.Show("아이디가 중복입니다");
                i++;
            }
            catch (Exception)
            {
                MessageBox.Show("연결상태를 확인하세요");
                i++;
            }
            if (i == 0)
            {
                MessageBox.Show("회원가입 완료");
                dbconn.DisConnect();
                Close();
            }
        }
    }
}
