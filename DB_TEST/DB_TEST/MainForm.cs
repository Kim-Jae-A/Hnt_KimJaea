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
    public partial class MainForm : Form
    {
        string loginid;
        string loginname;
        public MainForm()
        {
            InitializeComponent();
        }
        public void UserCheck(string id, string name)
        {
            loginid = id;
            loginname = name;
            label1.Text = $"{loginname} 님 반갑습니다.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ID = {loginid}" +
                $"\r\nname = {loginname}");
        }
    }
}
