using System.Net.Security;
using System.Text;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttTest_winform
{
    public partial class Form1 : Form
    {
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
            // �޼����� ������ ��
            client.Subscribe(new string[] { $"{topic}"}, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
            // �޽����� �ѹ��� �������� �����ڰ� �޽����� ���������� ��� ������ �ֱ������� ��������
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
            ConnectMQTT(broker, port, clientId, username, password);
            Subscribe(client, topic);
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            string msg = tx_maintext.Text;
            Publish(client, topic, msg);
            tx_maintext.Clear();
        }
    }
}