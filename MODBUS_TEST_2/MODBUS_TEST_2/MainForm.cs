using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

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
            helper.Query(sen1.tem, sen2.tem, sen3.tem, sen4.tem, sen1.per, sen2.per, sen3.per, sen4.per);
        }
        private void Sensor1_Load()
        {
            sen1.TopLevel = false;
            this.Controls.Add(sen1);
            sen1.StartPosition = FormStartPosition.Manual;
            sen1.Location = new Point(5, 20);
            sen1.Show();
            sen1.Per_Send();
            sen1.Tx_Per.Text = PerWrite(sen1.per);
            sen1.Tem_Send();
            sen1.Tx_Tem.Text = TemWrite(sen1.tem);
        }
        private void Sensor2_Load()
        {
            sen2.TopLevel = false;
            this.Controls.Add(sen2);
            sen2.StartPosition = FormStartPosition.Manual;
            sen2.Location = new Point(300, 20);
            sen2.Show();
            sen2.Per_Send();
            sen2.Tx_Per.Text = PerWrite(sen2.per);
            sen2.Tem_Send();
            sen2.Tx_Tem.Text = TemWrite(sen2.tem);
        }
        private void Sensor3_Load()
        {
            sen3.TopLevel = false;
            this.Controls.Add(sen3);
            sen3.StartPosition = FormStartPosition.Manual;
            sen3.Location = new Point(5, 200);
            sen3.Show();
            sen3.Per_Send();
            sen3.Tx_Per.Text = PerWrite(sen3.per);
            sen3.Tem_Send();
            sen3.Tx_Tem.Text = TemWrite(sen3.tem);
        }
        private void Sensor4_Load()
        {
            sen4.TopLevel = false;
            this.Controls.Add(sen4);
            sen4.StartPosition = FormStartPosition.Manual;
            sen4.Location = new Point(300, 200);
            sen4.Show();
            sen4.Per_Send();
            sen4.Tx_Per.Text = PerWrite(sen4.per);
            sen4.Tem_Send();
            sen4.Tx_Tem.Text = TemWrite(sen4.tem);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sen1.Per_Send();
            sen1.Tx_Per.Text = PerWrite(sen1.per);
            sen1.Tem_Send();
            sen1.Tx_Tem.Text = TemWrite(sen1.tem);

            sen2.Per_Send();
            sen2.Tx_Per.Text = PerWrite(sen2.per);
            sen2.Tem_Send();
            sen2.Tx_Tem.Text = TemWrite(sen2.tem);

            sen3.Per_Send();
            sen3.Tx_Per.Text = PerWrite(sen3.per);
            sen3.Tem_Send();
            sen3.Tx_Tem.Text = TemWrite(sen3.tem);

            sen4.Per_Send();
            sen4.Tx_Per.Text = PerWrite(sen4.per);
            sen4.Tem_Send();
            sen4.Tx_Tem.Text = TemWrite(sen4.tem);

            helper.Query(sen1.tem, sen2.tem, sen3.tem, sen4.tem, sen1.per, sen2.per, sen3.per, sen4.per);
        }

        private void Bt_Setting_Click(object sender, EventArgs e)
        {
            if(Tx_TimeSet.Text == "")
            {
                Tx_TimeSet.Text = "5";
            }
            int x = Convert.ToInt32(Tx_TimeSet.Text);
            int set = x * 60000;
            timer1.Interval = set;
        }

        private void Tx_TimeSet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
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
            per_con = x.ToString("P1", CultureInfo.InvariantCulture);

            return per_con;
        }
    }
}
