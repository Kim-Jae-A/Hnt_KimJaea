using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLightRFLibrary;

namespace DH_LED_Controller
{
    public partial class Form1 : Form
    {
        const int SENDNUM = 1;
        const int TTL = 8;
        ushort groupid;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FindMac();
            QLightAPI.SetSendNumber(SENDNUM);
            QLightAPI.SetTTL(TTL);
            QLightAPI.SetScanInterval(0);
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        public async void FindMac()
        {
            Dictionary<string, string> list = await QLightAPI.FindMacGateways();
            Delay(1000);
            foreach (string listkey in list.Keys)
            {
                listBox1.Items.Add(listkey);
            }
            foreach (string listvalues in list.Values)
            {
                listBox1.Items.Add(listvalues);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            bool check;
            if (textBox1.Text == "")
            {
                check = await QLightAPI.ConnectGatewayLAN("192.168.0.245", 32177);
            }
            else
            {
                check = await QLightAPI.ConnectGatewayLAN(textBox1.Text, 32177);
            }
            //check = await QLightAPI.ConnectGatewayLAN("192.168.0.245", 32177);
            if (check)
            {
                MessageBox.Show("연결성공");
                if (textBox1.Text == "")
                {
                    Get_GroupID("192.168.0.245");
                }
                else
                {
                    Get_GroupID(textBox1.Text);
                }
            }
            else
                MessageBox.Show("연결실패");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FindMac();
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            QLightAPI.DisconnectAndClearAllConnection();
        }
        public async void Get_GroupID(string ipadd)
        {
            GatewayInfo gatewayinfo = await QLightAPI.GetInfoGatewayLAN(ipadd);
            groupid = gatewayinfo.GroupId;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            QLightAPI.SearchRouters();
            Delay(1000);
            List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);
            for (int i = 0; i < list.Count(); i++)
            {
                listBox1.Items.Add(list[i]);
            }
            listBox1.Items.Add(list.Count());
        }
        public void LED_ON()
        {
            List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);
            ushort[] nodeid = new ushort[list.Count()];
            for (int i = 0; i < nodeid.Length; i++)
            {
                nodeid[i] = list[i];
            }
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.ON,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);
        }
        public void LED_OFF()
        {
            List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);
            ushort[] nodeid = new ushort[list.Count()];
            for (int i = 0; i < nodeid.Length; i++)
            {
                nodeid[i] = list[i];
            }
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            LED_ON();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LED_OFF();
        }
    }
}
