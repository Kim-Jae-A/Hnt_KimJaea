using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_TEST
{
    public partial class LoginForm : Form
    {
        DBHelper dbconn = new DBHelper();
        public LoginForm()
        {
            InitializeComponent();
            dbconn.Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm sign = new SignUpForm();
            sign.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string pass = textBox2.Text;
            dbconn.LoginQuery(id, pass);
        }
    }
}
