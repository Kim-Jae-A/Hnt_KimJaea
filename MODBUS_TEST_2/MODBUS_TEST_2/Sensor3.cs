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
using System.Globalization;

namespace MODBUS_TEST_2
{
    public partial class Sensor3 : Form
    {
        int check = 0;
        Socket Sensor3_Sock;
        AsyncObject obj = new AsyncObject(99999);   // 소켓 크기 설정
        Thread thread;
        public float per;
        public float tem;

        public Sensor3()
        {
            InitializeComponent();
            SocketSet();
            ConnServer();
        }
        private void SocketSet()
        {
            Sensor3_Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void ConnServer()
        {       
            // 서버 아이피
            string serverip = "10.10.24.253";
            // 서버 포트
            int serverport = 5000;
            try
            {
                // 설정한 서버 IP 에 맞게 IP 설정
                IPAddress serverAddr = IPAddress.Parse($"{serverip}");
                //IPAddress serverAddr = Dns.GetHostAddresses(serverip)[0];
                IPEndPoint clientEP = new IPEndPoint(serverAddr, serverport);      // 설정한 IP, Port 에 맞게 클라이언트로 서버 접속
                Sensor3_Sock.BeginConnect(clientEP, new AsyncCallback(ConnectCallback), Sensor3_Sock);      // 접속한 서버 IP 에 맞게 소켓 연결
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
            finally
            { 
                thread = new Thread(Workthread_RESIVE);    // 쓰레드 설정                                           
                thread.IsBackground = true;                // 쓰레드 백그라운드 셋팅
                thread.Start();
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
        }
        void ConnectCallback(IAsyncResult ar)   //커넥트 콜백 메소드
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                obj.WorkingSocket = Sensor3_Sock;
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
            ListBoxChoice(buffer);        
        }
        public void Send(string msg)   // 서버로 데이터 보내는 메소드
        {
            try
            {
                String message = msg;
                byte[] buff = HexToByte(message);
                Sensor3_Sock.Send(buff, buff.Length, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now}" + ex);
            }
        }

        private void Workthread_RESIVE()   // 셋팅한 쓰레드가 시작되면 실행되는 함수
        {
            while (true)
            {
                try
                {
                    Sensor3_Sock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);  // 실시간으로 서버에서 보낸 데이터를 받는다.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now}" + ex);
                }
                finally
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public byte[] HexToByte(string strHex)
        {
            byte[] bytes = new byte[strHex.Length / 2];

            for (int count = 0; count < strHex.Length; count += 2)
            {
                bytes[count / 2] = Convert.ToByte(strHex.Substring(count, 2), 16);
            }
            return bytes;
        }
        public string ByteToHex(byte[] hex)
        {
            string result = string.Empty;
            foreach (byte c in hex)
            {
                result += c.ToString("x2").ToUpper();
            }

            return result;
        }
        public string Convert_Tem(string msg)
        {
            string con;
            string con1 = msg.Substring(6, 4);
            string con2 = msg.Substring(10, 4);
            con = con2 + con1;

            return con;
        }
        public float HextoFloat(string num)
        {
            Int32 intRep = Int32.Parse(num, NumberStyles.AllowHexSpecifier);
            float f = BitConverter.ToSingle(BitConverter.GetBytes(intRep), 0);

            return f;
        }


        public void ListBoxChoice(byte[] buffer)
        {
            if (check == 0)
            {
                Tx_Tem.Invoke(new MethodInvoker(delegate
                {
                    tem = HextoFloat(Convert_Tem(ByteToHex(buffer)));
                    Tx_Tem.Text = HextoFloat(Convert_Tem(ByteToHex(buffer))).ToString("0.0");
                }));  
            }
            else
            {
                Tx_Per.Invoke(new MethodInvoker(delegate
                {
                    per = HextoFloat(Convert_Tem(ByteToHex(buffer)));
                    Tx_Per.Text = HextoFloat(Convert_Tem(ByteToHex(buffer))).ToString("P1",CultureInfo.InvariantCulture);
                }));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            check = 0;
            Send("01030037000275C5");  // 온도 명령어
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            check = 1;
            Send("010300350002D405"); // 농도 명령어
            timer1.Enabled = true;
        }
    }
}
