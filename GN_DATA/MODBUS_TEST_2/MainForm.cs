using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        bool check = false;

        public MainForm()
        {
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
            if (sen4.per != 0 || sen4.tem != 0)
            { 
                helper.Query(sen1.tem, sen2.tem, sen3.tem, sen4.tem, sen1.per, sen2.per, sen3.per, sen4.per);
                sen1.Tx_Per.Text = PerWrite(sen1.per);
                sen1.Tx_Tem.Text = TemWrite(sen1.tem);
                sen2.Tx_Per.Text = PerWrite(sen2.per);
                sen2.Tx_Tem.Text = TemWrite(sen2.tem);
                sen3.Tx_Per.Text = PerWrite(sen3.per);
                sen3.Tx_Tem.Text = TemWrite(sen3.tem);
                sen4.Tx_Per.Text = TemWrite(sen4.per);
                sen4.Tx_Tem.Text = TemWrite(sen4.tem);
            }
            else
            {
                System.Threading.Thread.Sleep(3000);
            }
        }

        private void Bt_Setting_Click(object sender, EventArgs e)
        {
            TimerSetting();
            GN_SENSOR_DATA.Properties.Settings.Default.TimerSet = Tx_TimeSet.Text;
            GN_SENSOR_DATA.Properties.Settings.Default.Save();
        }

        private void Tx_TimeSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void TimerSetting()
        {
            if (Tx_TimeSet.Text == "" || Tx_TimeSet.Text == "0")
            {
                Tx_TimeSet.Text = "5";
            }
            int x = Convert.ToInt32(Tx_TimeSet.Text);
            //int set = x * 1000;
            int set = x * 60000;
            sen1.timer1.Interval = set - 5000;
            sen2.timer1.Interval = set - 5000;
            sen3.timer1.Interval = set - 5000;
            sen4.timer1.Interval = set - 5000;
            sen1.timer2.Interval = set - 3000;
            sen2.timer2.Interval = set - 3000;
            sen3.timer2.Interval = set - 3000;
            sen4.timer2.Interval = set - 3000;
            timer1.Interval = set;
        }
        private void LodingData()
        {
            int set = 3000;
            timer1.Interval = set;
            sen1.timer1.Interval = set - 1200;
            sen2.timer1.Interval = set - 1200;
            sen3.timer1.Interval = set - 1200;
            sen4.timer1.Interval = set - 1200;
            sen1.timer2.Interval = set - 700;
            sen2.timer2.Interval = set - 700;
            sen3.timer2.Interval = set - 700;
            sen4.timer2.Interval = set - 700;
            check = true;
            timer2.Enabled = true;
        }
        public string TemWrite(float x)
        {
            string tem_con;
            tem_con = x.ToString("0.0");

            return tem_con;
        }
        public string PerWrite(float x)
        {
            string per_con;
            per_con = x.ToString("0.00");

            return per_con;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Sensor1_Load();
            Sensor2_Load();
            Sensor3_Load();
            Sensor4_Load();
            helper.Connect();
            Tx_TimeSet.Text = GN_SENSOR_DATA.Properties.Settings.Default.TimerSet;
            LodingData();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            TimerSetting();
            timer2.Enabled = false;
        }
    }
}
