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
        AsyncObject obj = new AsyncObject(4096);   // 소켓 크기 설정
        bool check = false;

        public Form1()
        {
            InitializeComponent();
            Box_ServerIP.Text = "10.10.24.251";     // 디폴트 IP
            Box_Port.Text = "5000";                 // 디폴트 Port
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  // Socket 설정
        }

        private void Bt_Connect_Click(object sender, EventArgs e)    // 연결 버튼 클릭 메소드
        {
            //mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int i = 0;
            try
            {
                IPAddress serverAddr = IPAddress.Parse($"{Box_ServerIP.Text}");                         // 설정한 서버 IP 에 맞게 IP 설정
                IPEndPoint clientEP = new IPEndPoint(serverAddr, Convert.ToInt32(Box_Port.Text));       // 설정한 IP, Port 에 맞게 클라이언트로 서버 접속
                mainSock.BeginConnect(clientEP, new AsyncCallback(ConnectCallback), mainSock);          // 접속한 서버 IP 에 맞게 소켓 연결
                i++;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
                mainSock.Close();
                mainSock.Dispose();
            }
            if(i != 0)  // 연결 성공시 실행
            {
                MessageBox.Show("연결되었습니다.");
                check = true;
                Thread thread = new Thread(Workthread);    // 쓰레드 설정
                thread.IsBackground = true;                // 쓰레드 백그라운드 셋팅
                thread.Start();                            // 쓰레드 실행
            }
        }
        void ConnectCallback(IAsyncResult ar)   //커넥트 콜백 메소드
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar); 
                obj.WorkingSocket = mainSock;
                mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);  // 비동기 리시브로 데이터 받아옴
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
        void DataReceived(IAsyncResult ar)        // 데이터 받아오는 리시브 메서드
        {
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            int received = obj.WorkingSocket.EndReceive(ar);

            byte[] buffer = new byte[received];

            Array.Copy(obj.Buffer, 0, buffer, 0, received);

            if (check)
            {
                if (listBox1.InvokeRequired)    // 받아온 데이터를 리스트 박스에 표시
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
        }

        private void Bt_send_Click(object sender, EventArgs e)  // Send 버튼 클릭 메소드
        {
            Send();
        }
        public void Send()   // 서버로 데이터 보내는 메소드
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
        private void Workthread()   // 셋팅한 쓰레드가 시작되면 실행되는 함수
        { 
            while (true)
            {
                try
                {
                    mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);  // 실시간으로 서버에서 보낸 데이터를 받는다.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                }
                Thread.Sleep(1);
            }
        }

        private void Bt_Hexcode_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                int message = Convert.ToInt32(Box_Hex_Code.Text);
                string hexmes = Convert.ToString(message, 16);
                byte[] buff = Encoding.ASCII.GetBytes(hexmes);
                mainSock.Send(buff, buff.Length, 0);
                i++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            if (i != 0)
            {
                MessageBox.Show("메시지를 보냈습니다.");
            }
        }

        private void Box_Hex_Code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
