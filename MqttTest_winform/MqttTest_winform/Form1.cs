using System.Net.Security;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttTest_winform
{
    public partial class Form1 : Form
    {
        int i = 0;
        static ListBox? listBox;
        static MqttClient client;
        string topic = "";
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Form1.listBox = this.ls_chat;
        }

        static MqttClient ConnectMQTT(string broker, int port, string clientId, string username, string password)
        {
            client = new MqttClient(broker, port, false, MqttSslProtocols.None, null, null);
            client.Connect(clientId, username, password);
            if (client.IsConnected)
            {
                MessageBox.Show("Connected to MQTT Broker");
            }
            else
            {
                MessageBox.Show("Failed to connect");
            }
            return client;
        }
        
        static void Publish(MqttClient client, string topic, string msg)
        {
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(msg));
        }
        static void Subscribe(MqttClient client, string topic)
        {
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            // 메세지를 보내면 끝
            client.Subscribe(new string[] { $"{topic}"}, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            // 메시지를 한번만 보내지만 수신자가 메시지를 받을때까지 계속 저장후 주기적으로 재전송함
            /*client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });*/
        }
        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string payload = Encoding.Default.GetString(e.Message);
            listBox?.Items.Add(payload);
        }
        private void bt_join_Click(object sender, EventArgs e)
        {
            string broker = tx_borker.Text;
            int port = Convert.ToInt32(tx_port.Text);
            string clientId = Guid.NewGuid().ToString();
            string username = "emqx";
            string password = "public";
            topic = tx_topic.Text;
            if (i != 0)
            {
                client.Disconnect();
                MessageBox.Show("DisConnected to MQTT Broker");
                i = 0;
            }
            else
            {
                ConnectMQTT(broker, port, clientId, username, password);
                Subscribe(client, topic);
                i++;
            }   
            if (bt_join.Text == "DisConnect")
            {
                bt_join.Text = "Join";
            }
            else
            {
                bt_join.Text = "DisConnect";
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            string msg = tx_maintext.Text;
            Publish(client, topic, msg);
            tx_maintext.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (i != 0)
            {
                client.Disconnect();
            }
        }
    }
}