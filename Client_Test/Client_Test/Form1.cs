using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;

namespace Client_Test
{
    public partial class Form1 : Form
    {
        Socket mainSock;
        AsyncObject obj = new AsyncObject(4096);

        public Form1()
        {
            InitializeComponent();
            Box_ServerIP.Text = "10.10.24.251";
            Box_Port.Text = "5000";
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        private void Bt_Connect_Click(object sender, EventArgs e)
        {
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int i = 0;
            try
            {
                IPAddress serverAddr = IPAddress.Parse($"{Box_ServerIP.Text}");
                IPEndPoint clientEP = new IPEndPoint(serverAddr, Convert.ToInt32(Box_Port.Text));
                mainSock.BeginConnect(clientEP, new AsyncCallback(ConnectCallback), mainSock);
                i++;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
                mainSock.Close();
                mainSock.Dispose();
            }
            if(i != 0)
            {
                MessageBox.Show("연결되었습니다.");
                Thread thread = new Thread(Workthread);
                thread.IsBackground = true;
                thread.Start();
            }
        }
        void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar); 
                obj.WorkingSocket = mainSock;
                //mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
                //mainSock.BeginReceive(obj.Buffer, 0, 10, 0, DataReceived, obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        public class AsyncObject
        {
            public byte[] Buffer;
            public Socket WorkingSocket;
            public readonly int BufferSize;
            public AsyncObject(int bufferSize)
            {
                BufferSize = bufferSize;
                Buffer = new byte[(long)BufferSize];
            }

            public void ClearBuffer()
            {
                Array.Clear(Buffer, 0, BufferSize);
            }
        }
        void DataReceived(IAsyncResult ar)
        {
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            int received = obj.WorkingSocket.EndReceive(ar);

            byte[] buffer = new byte[received];

            Array.Copy(obj.Buffer, 0, buffer, 0, received);

            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    listBox1.Items.Add(Encoding.Default.GetString(buffer));
                }));
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }));
            }
            else
            {
                listBox1.Items.Add(Encoding.Default.GetString(buffer));
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }

        private void Bt_send_Click(object sender, EventArgs e)
        {
            Send();
        }
        public void Send()
        {
            int i = 0;
            try
            {
                String message = Box_send.Text;
                byte[] buff = Encoding.ASCII.GetBytes(message);
                mainSock.Send(buff, buff.Length, 0);
                i++;
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            if (i != 0)
            {
                MessageBox.Show("메시지를 보냈습니다.");
            }
        }
        private void Workthread()
        {
            //mainSock.BeginReceive
            while (true)
            {
                try
                {
                    mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                Thread.Sleep(1);
            }
        }
    }
}
