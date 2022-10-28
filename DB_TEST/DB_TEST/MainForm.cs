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
            UserImfor user = new UserImfor(loginid, loginname);
            user.TopLevel = false;
            this.Controls.Add(user);
            user.StartPosition = FormStartPosition.Manual;
            user.Location = new Point(550, 40);
            user.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
