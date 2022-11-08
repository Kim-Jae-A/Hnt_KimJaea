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

namespace YJ_DATA_TEST
{
    public partial class Form1 : Form
    {
        Socket mainSock;
        AsyncObject obj = new AsyncObject(99999);   // 소켓 크기 설정
        DBHelper helper = new DBHelper();

        public Form1()
        {
            InitializeComponent();
            SocketSet();

            Thread.Sleep(1000);
            ConnServer();
            
            helper.Connect();
            
            Test();
        }

        private void ConnServer()
        {
            int i = 0;
            string serverip = "tcp.wim-x.kr";            // 서버 아이피
            string serverport = "50300";                 // 서버 포트
            //string serverip = "10.10.24.64";            // 서버 아이피
            //string serverip = "192.168.1.100"; 
            //string serverport = "5000";                 // 서버 포트
            try
            {
                // 설정한 서버 IP 에 맞게 IP 설정
                //IPAddress serverAddr = IPAddress.Parse($"{serverip}");
                IPAddress serverAddr = Dns.GetHostAddresses(serverip)[0];
                IPEndPoint clientEP = new IPEndPoint(serverAddr, Convert.ToInt32(serverport));       // 설정한 IP, Port 에 맞게 클라이언트로 서버 접속
                mainSock.BeginConnect(clientEP, new AsyncCallback(ConnectCallback), mainSock);      // 접속한 서버 IP 에 맞게 소켓 연결
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}"+ ex);
            }
            finally
            {
                if (i != 0)
                {
                    Timer_Reconn.Enabled = false;
                    Thread thread = new Thread(Workthread);    // 쓰레드 설정
                    thread.IsBackground = true;                // 쓰레드 백그라운드 셋팅
                    thread.Start();
                    //Timer_Send.Enabled = true;
                }
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
                Console.WriteLine($"{DateTime.Now}" + ex);
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
            
            if (listBox1.InvokeRequired)    // 받아온 데이터를 리스트 박스에 표시
            {
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    Timer_Send.Enabled = true;
                    Timer_Reconn.Enabled = false;
                    listBox1.Items.Add(Encoding.Default.GetString(buffer));
                }));
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }));
            }
            else
            {
                Timer_Send.Enabled = true;
                Timer_Reconn.Enabled = false;
                listBox1.Items.Add(Encoding.Default.GetString(buffer));
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }
        public void Send(string msg)   // 서버로 데이터 보내는 메소드
        {
            try
            {
                String message = msg;
                byte[] buff = Encoding.ASCII.GetBytes(message);
                mainSock.Send(buff, buff.Length, 0);
                Timer_Send.Enabled = false;
                Timer_Reconn.Enabled = true;
            }
            catch (Exception ex)
            {
                Timer_Reconn.Enabled = true;
                Timer_Send.Enabled = false;
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
        }
        public void Test()
        {
            string testmsg = "WR-001816,000000000000,v1.000,000,000,0.0000,0.0000,0.0000";
            Send(testmsg);
        }
        private void timer1_Tick(object sender, EventArgs e)  // 5초마다 메시지 보냄
        {
            string[] data = helper.Query();
            string msg = "WR-1816,";
            msg += $"{data[0]},";
            msg += "v1.000,1,-99,";
            for (int i = 1; i < data.Length; i++)
            {
                msg += data[i];
                if (i < 3)
                    msg += ",";
                else if (i < 15)
                    msg += "#";
            }
            //listBox1.Items.Add(msg);
            //listBox1.TopIndex = listBox1.Items.Count - 1;
            Send(msg);
        }
        private void Timer_Reconn_Tick(object sender, EventArgs e)     // 메세지 보내는데 실패하면 타이머 시작한 뒤 소켓 및 연결 재시도
        {
            SocketSet();
            ConnServer();
            Test();
        }
        private void SocketSet()
        {
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                    Console.WriteLine($"{DateTime.Now}" + ex);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
