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
    public partial class UserImfor : Form
    {
        public UserImfor(string id, string name)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Form_Closing()
        {
            Close();
        }
    }
}
