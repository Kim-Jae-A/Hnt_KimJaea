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
        DBHelper helper = new DBHelper();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            helper.Connect();
            FindMac();

            // 무선통신 설정값 변경
            // 1. 송신 반복 횟수 : 1~10사이값 (기본값 4), 설정하면 한 명령을 300ms 간격으로 반복횟수만큼 무선송신합니다.
            // 즉, 한번 제어명령 송신시 기본값으로는 1.2초 이상(300ms X 기본값4회 = 1200ms) 딜레이를 줘야 합니다.
            QLightAPI.SetSendNumber(SENDNUM);

            // 2. 패킷 전달 횟수 : 명령을 전달되는 중간노드의 최대 개수입니다. 기본값은 8로 되어 있습니다.
            // 라우터간의 거리가 길고 라우터의 갯수가 많을수록 높이 설정해야 하지만 무선 복잡도가 늘어 실패확률이 늘어납니다.
            QLightAPI.SetTTL(TTL);

            // 3. 라이브러리 내 자체 스캔주기 : 설정하면 라이브러리에서 자체 타이머로 주기적인, 등록된 라우터의 상태를 가져옵니다.
            // 빠른 제어를 원한다면 이 값을 0으로 설정하여 스캔하지 않도록 합니다.
            QLightAPI.SetScanInterval(0);
        }
        private void Form1_Leave(object sender, EventArgs e)
        {
            helper.DisConnect();
            QLightAPI.DisconnectAndClearAllConnection();   // 모든 연결을 해제
        }
        private static DateTime Delay(int MS)  // 딜레이 걸어주는 함수
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
        public async void FindMac()  // 맥 찾기 함수
        {
            comboBox1.Items.Clear();
            listBox1.Items.Clear();
            Dictionary<string, string> list = await QLightAPI.FindMacGateways();  // 게이트 웨이 맥 주소 찾아서 리스트업
            Delay(1000);
            foreach (string listkey in list.Keys)       // Mac 값
            {
                listBox1.Items.Add(listkey);
            }
            foreach (string listvalues in list.Values)  // ip 값
            {
                listBox1.Items.Add(listvalues);  // 확인용
                comboBox1.Items.Add(listvalues);  // 콤보 박스에 값 넣기
            }
        }
        public async void Get_GroupID(string ipadd)
        {
            GatewayInfo gatewayinfo = await QLightAPI.GetInfoGatewayLAN(ipadd);  //  연결된 게이트웨이의 정보 받아오기
            groupid = gatewayinfo.GroupId;                                       //  정보 중 그룹아이디 값 받기
        }

        public void LED_ON()
        {
            /*List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);  // 그룹에 맞는 라우터들 찾기
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
                LEDState.OFF);*/
            ushort list;
            if (comboBox2.Text != "")  // 콤보 박스가 빈칸 이 아니면
            {
                list = ushort.Parse(comboBox2.Text);  // 콤보 박스에 선택한 라우터 Nodeid 정보를 저장
            }
            else  // 콤보 박스가 빈칸이면
            {
                comboBox2.SelectedIndex = 0;  // 콤보 박스의 첫번째 항목을 기본으로 설정
                list = ushort.Parse(comboBox2.Text);  // 콤보 박스에 선택한 라우터 Nodeid 정보를 저장
            }
            ushort[] nodeid = new ushort[1];  
            nodeid[0] = list;   // 콤보 박스의 NodeID 정보를 배열 형태로 저장

            // 선택된 라우터를 제어하여 LED ON 지금은 빨간색
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.ON,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);
        }
        public void LED_OFF()
        {
            // 현재 연결된 게이트웨이의 그룹 아이디 정보를 가지고 그 그룹에 맞는 모든 라우터들을 검색 후 리스트로 저장
            List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);  
            ushort[] nodeid = new ushort[list.Count()];
            for (int i = 0; i < nodeid.Length; i++)
            {
                // Nodeid 배열에 리스트(모든 라우터)들을 하나씩 매칭 
                nodeid[i] = list[i];
            }

            // 같은 그룹인 모든 라우터들의 LED OFF
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);
        }
        private async void button1_Click(object sender, EventArgs e)  // 커넥트 버튼
        {
            bool check;

            if (comboBox1.Text == "")  // 아이피 설정 콤보 박스가 빈칸이면
                check = await QLightAPI.ConnectGatewayLAN("192.168.0.237", 32177); // 일단 임시로 설정해둔 아이피로 연결 시도
            else
                check = await QLightAPI.ConnectGatewayLAN(comboBox1.Text, 32177);  // 아이피 콤보 박스 값이 있으니 그 아이피로 연결 시도

            if (check) // 연결 성공 여부 확인
            {
                MessageBox.Show("연결성공");
                if (comboBox1.Text == "")  // 연결이 성공 했을 때 아이피 콤보박스가 빈칸이면
                    Get_GroupID("192.168.0.237");  // 임시로 설정해둔 아이피로 그룹 아이디 값 받아오기
                else
                    Get_GroupID(comboBox1.Text);  // 아이피 콤보 박스 값으로 그룹 아이디 값 받아오기
            }
            else
                MessageBox.Show("연결실패");
        }
        private void button2_Click(object sender, EventArgs e)   // 맥 찾기
        {
            FindMac();
        }
        private void button3_Click(object sender, EventArgs e)  // 라우터 찾기
        {
            try
            {
                listBox1.Items.Clear();
                comboBox2.Items.Clear();

                // 라우터 찾기 함수
                QLightAPI.SearchRouters();
                Delay(1000);

                // 현재 연결된 게이트웨이의 그룹 아이디인 라우터들을 검색하여 리스트에 저장
                List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);
                for (int i = 0; i < list.Count(); i++)
                {
                    listBox1.Items.Add(list[i]);  // 확인용
                    comboBox2.Items.Add(list[i]); // 콤보 박스에 하나씩 매칭
                }
                listBox1.Items.Add("총 " + list.Count() + "개");  // 확인용 (검색된 라우터 총 갯수 표시)
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        private void button4_Click(object sender, EventArgs e)  // LED 온
        {
            LED_ON();
        }
        private void button5_Click(object sender, EventArgs e)  // LED 끄기
        {
            LED_OFF();
        }

        private void button6_Click(object sender, EventArgs e)  //  모든 LED 켜기
        {
            // 현재 연결된 게이트웨이의 그룹 아이디 정보를 가지고 그 그룹에 맞는 모든 라우터들을 검색 후 리스트로 저장
            List<ushort> list = QLightAPI.GetRouterListGroupId(groupid); 
            ushort[] nodeid = new ushort[list.Count()];
            for (int i = 0; i < nodeid.Length; i++)
            {
                // Nodeid 배열에 리스트(모든 라우터)들을 하나씩 매칭 
                nodeid[i] = list[i];
            }
            
            // 같은 그룹의 모든 라우터들의 LED ON (빨간색)
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.ON,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] testid;
            testid = helper.Query("77");
            listBox1.Items.Add(testid[2]);
        }
    }
}
