using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODBUS_TEST_2
{
    public partial class MainForm : Form
    {
        Sensor1 sen1 = new Sensor1();
        Sensor2 sen2 = new Sensor2();
        Sensor3 sen3 = new Sensor3();
        Sensor4 sen4 = new Sensor4();
        DBHelper helper = new DBHelper();

        public MainForm()
        {
            Sensor1_Load();
            Sensor2_Load();
            Sensor3_Load();
            Sensor4_Load();
            helper.Connect();
            InitializeComponent();
        }
        private void Sensor1_Load()
        {
            sen1.TopLevel = false;
            this.Controls.Add(sen1);
            sen1.StartPosition = FormStartPosition.Manual;
            sen1.Location = new Point(5, 20);
            sen1.Show();
        }
        private void Sensor2_Load()
        {
            sen2.TopLevel = false;
            this.Controls.Add(sen2);
            sen2.StartPosition = FormStartPosition.Manual;
            sen2.Location = new Point(300, 20);
            sen2.Show();
        }
        private void Sensor3_Load()
        {
            sen3.TopLevel = false;
            this.Controls.Add(sen3);
            sen3.StartPosition = FormStartPosition.Manual;
            sen3.Location = new Point(5, 200);
            sen3.Show();
        }
        private void Sensor4_Load()
        {
            sen4.TopLevel = false;
            this.Controls.Add(sen4);
            sen4.StartPosition = FormStartPosition.Manual;
            sen4.Location = new Point(300, 200);
            sen4.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            helper.Query(sen1.tem, sen2.tem, sen3.tem, sen4.tem, sen1.per, sen2.per, sen3.per, sen4.per);
        }

        private void Bt_Setting_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Tx_TimeSet.Text);
            int set = x * 1000;
            sen1.timer1.Interval = set;
            sen1.timer2.Interval = set + 150;
            sen2.timer1.Interval = set;
            sen2.timer2.Interval = set + 150;
            sen3.timer1.Interval = set;
            sen3.timer2.Interval = set + 150;
            sen4.timer1.Interval = set;
            sen4.timer2.Interval = set + 150;
            timer1.Interval = set + 160;
        }

        private void Tx_TimeSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
