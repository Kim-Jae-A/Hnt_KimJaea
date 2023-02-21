#region < HEADER AREA >
// *---------------------------------------------------------------------------------------------*
//   경광등 제어 폼
//   수정날짜 : 2023-02-01  
// *---------------------------------------------------------------------------------------------*
#endregion
#region  < using 선언 >
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
#endregion

namespace DH_LED_Controller
{
    public partial class Form1 : Form
    {
        #region  < 전역 변수 설정 >
        const int SENDNUM = 1;
        const int TTL = 8;
        //ushort groupid;
        DBHelper helper = new DBHelper();
        int macCount;
        string[] macIP;
        #endregion

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
            try
            {
                Find_ITEMS_COD();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
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
            //comboBox1.Items.Clear();
            //listBox1.Items.Clear();
            macCount = 0;         
            Dictionary<string, string> list = await QLightAPI.FindMacGateways();  // 게이트 웨이 맥 주소 찾아서 리스트업
            Delay(1000);
            foreach (string listkey in list.Keys)       // Mac 값
            {
                //listBox1.Items.Add(listkey);
                macCount++;
            }

            macIP = new string[macCount];
            int i = 0;
            foreach (string listvalues in list.Values)  // ip 값
            {
                macIP[i] = listvalues;
                //listBox1.Items.Add(listvalues);  // 확인용
                //comboBox1.Items.Add(listvalues);  // 콤보 박스에 값 넣기
                i++;
            }
            Conn_IP();
        }

        public async void Conn_IP()
        {
            bool check;

            for (int i = 0; i < macCount; i++)
            {
                check = await QLightAPI.ConnectGatewayLAN(macIP[i], 32177);  // 아이피 콤보 박스 값이 있으니 그 아이피로 연결 시도

                if (check) // 연결 성공 여부 확인
                    MessageBox.Show($"{macIP[i]} 연결성공");
                else
                    MessageBox.Show($"{macIP[i]} 연결실패");
            }
            AddRouters();
            QLightAPI.SearchRouters();
        }

        /*public async void Get_GroupID(string ipadd) // 그룹아이디 찾기
        {
            GatewayInfo gatewayinfo = await QLightAPI.GetInfoGatewayLAN(ipadd);  //  연결된 게이트웨이의 정보 받아오기
            groupid = gatewayinfo.GroupId;                                       //  정보 중 그룹아이디 값 받기
        }*/

        /*public void LED_ON()
        {
            ushort list;
            if (comboBox2.Text != "")  // 콤보 박스가 빈칸 이 아니면
            {
                list = ushort.Parse(comboBox2.Text);  // 콤보 박스에 선택한 라우터 Nodeid 정보를 저장
            }
            else  // 콤보 박스가 빈칸이면
            {
                comboBox2.SelectedIndex = 0;  // 콤보 박스의 첫번째 항목을 기본으로 설정
                list = ushort.Parse(comboBox2.Text);  // 콤보 박스에 선택한 라우터 Nodeid 정보를 저장
                //list = ushort.Parse(node);
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
        }*/

        public void LED_ON(string[] node)
        {
            ushort[] nodeid = new ushort[1];
            nodeid[0] = ushort.Parse(node[1]);

            if (Convert.ToInt32(node[2]) <= 0)
            {
                QLightAPI.ControlRoutersLED(nodeid,
                 LEDState.ON,
                 LEDState.OFF,
                 LEDState.OFF,
                 LEDState.OFF,
                 LEDState.OFF);

                RED_LIGHT(node[1]);
            }
            else
            {
                QLightAPI.ControlRoutersLED(nodeid,
                 LEDState.OFF,
                 LEDState.OFF,
                 LEDState.ON,
                 LEDState.OFF,
                 LEDState.OFF);

                GREEN_LIGHT(node[1]);
            }
        }

        public void LED_OFF()
        {
            Dictionary<ushort, ushort> list = QLightAPI.GetAllRouterList();
            ushort[] nodeid = new ushort[list.Keys.Count()];
            int i = 0;

            foreach (ushort listkey in list.Keys)       // NODE ID
            {
                nodeid[i] = listkey;
                i++;
            }

            // 모든 경광등 전원 OFF
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);

            for (i = 0; i < nodeid.Length; i++)
            {
                OFF_LIGHT(Convert.ToString(nodeid[i]));
            }
        }

        public void Find_ITEMS_COD()  // DB에 저장된 품목들을 가지고와서 콤보박스에 넣는 메소드
        {
            cb_ITEMLIST.Items.Clear();
            string[] items = helper.CodITEM();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    cb_ITEMLIST.Items.Add(items[i]);
                }
                else
                {
                    break;
                }
            }
        }

        #region < 경광등 정보 >
        public void AddRouters()  // 경광등 아이디 정보
        {
            #region < 11그룹 라우터 총 29개 >
            QLightAPI.AddRouterListManually(1101, 11);
            QLightAPI.AddRouterListManually(1102, 11);
            QLightAPI.AddRouterListManually(1103, 11);
            QLightAPI.AddRouterListManually(1104, 11);
            QLightAPI.AddRouterListManually(1105, 11);
            QLightAPI.AddRouterListManually(1106, 11);
            QLightAPI.AddRouterListManually(1107, 11);
            QLightAPI.AddRouterListManually(1108, 11);
            QLightAPI.AddRouterListManually(1109, 11);
            QLightAPI.AddRouterListManually(1110, 11);
            QLightAPI.AddRouterListManually(1111, 11);
            QLightAPI.AddRouterListManually(1112, 11);
            QLightAPI.AddRouterListManually(1113, 11);
            QLightAPI.AddRouterListManually(1114, 11);
            QLightAPI.AddRouterListManually(1115, 11);
            QLightAPI.AddRouterListManually(1116, 11);
            QLightAPI.AddRouterListManually(1117, 11);
            QLightAPI.AddRouterListManually(1401, 11);
            QLightAPI.AddRouterListManually(1402, 11);
            QLightAPI.AddRouterListManually(1403, 11);
            QLightAPI.AddRouterListManually(1404, 11);
            QLightAPI.AddRouterListManually(1405, 11);
            QLightAPI.AddRouterListManually(1412, 11);
            QLightAPI.AddRouterListManually(1413, 11);
            QLightAPI.AddRouterListManually(1414, 11);
            QLightAPI.AddRouterListManually(1415, 11);
            QLightAPI.AddRouterListManually(1416, 11);
            QLightAPI.AddRouterListManually(1417, 11);
            QLightAPI.AddRouterListManually(1418, 11);
            #endregion
            #region < 12그룹 라우터 총 28개 >
            QLightAPI.AddRouterListManually(1201, 12);
            QLightAPI.AddRouterListManually(1202, 12);
            QLightAPI.AddRouterListManually(1203, 12);
            QLightAPI.AddRouterListManually(1204, 12);
            QLightAPI.AddRouterListManually(1205, 12);
            QLightAPI.AddRouterListManually(1206, 12);
            QLightAPI.AddRouterListManually(1207, 12);
            QLightAPI.AddRouterListManually(1208, 12);
            QLightAPI.AddRouterListManually(1209, 12);
            QLightAPI.AddRouterListManually(1210, 12);
            QLightAPI.AddRouterListManually(1211, 12);
            QLightAPI.AddRouterListManually(1212, 12);
            QLightAPI.AddRouterListManually(1213, 12);
            QLightAPI.AddRouterListManually(1214, 12);
            QLightAPI.AddRouterListManually(1215, 12);
            QLightAPI.AddRouterListManually(1216, 12);
            QLightAPI.AddRouterListManually(1217, 12);
            QLightAPI.AddRouterListManually(1218, 12);
            QLightAPI.AddRouterListManually(1219, 12);
            QLightAPI.AddRouterListManually(1220, 12);
            QLightAPI.AddRouterListManually(1221, 12);
            QLightAPI.AddRouterListManually(1222, 12);
            QLightAPI.AddRouterListManually(1224, 12);
            QLightAPI.AddRouterListManually(1408, 12);
            QLightAPI.AddRouterListManually(1419, 12);
            QLightAPI.AddRouterListManually(1420, 12);
            QLightAPI.AddRouterListManually(1421, 12);
            QLightAPI.AddRouterListManually(1422, 12);
            #endregion
            #region < 13그룹 라우터 총 20개 >
            QLightAPI.AddRouterListManually(1301, 13);
            QLightAPI.AddRouterListManually(1302, 13);
            QLightAPI.AddRouterListManually(1303, 13);
            QLightAPI.AddRouterListManually(1304, 13);
            QLightAPI.AddRouterListManually(1305, 13);
            QLightAPI.AddRouterListManually(1306, 13);
            QLightAPI.AddRouterListManually(1307, 13);
            QLightAPI.AddRouterListManually(1308, 13);
            QLightAPI.AddRouterListManually(1309, 13);
            QLightAPI.AddRouterListManually(1310, 13);
            QLightAPI.AddRouterListManually(1311, 13);
            QLightAPI.AddRouterListManually(1312, 13);
            QLightAPI.AddRouterListManually(1313, 13);
            QLightAPI.AddRouterListManually(1314, 13);
            QLightAPI.AddRouterListManually(1315, 13);
            QLightAPI.AddRouterListManually(1316, 13);
            QLightAPI.AddRouterListManually(1317, 13);
            QLightAPI.AddRouterListManually(1318, 13);
            QLightAPI.AddRouterListManually(1319, 13);
            QLightAPI.AddRouterListManually(1320, 13);
            QLightAPI.AddRouterListManually(1406, 13);
            QLightAPI.AddRouterListManually(1407, 13);
            QLightAPI.AddRouterListManually(1409, 13);
            QLightAPI.AddRouterListManually(1410, 13);
            QLightAPI.AddRouterListManually(1411, 13);
            #endregion
            #region < 14그룹 라우터 총 0개 >

            #endregion
        }
        #endregion

        #region < 버튼 클릭 이벤트>
        /*        private async void bt_conn_Click(object sender, EventArgs e)
                {
                    *//*bool check;

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
                        MessageBox.Show("연결실패");*//*
                }*/

        /*private void bt_FIndMac_Click(object sender, EventArgs e)
        {
            FindMac();
        }*/

        /*private void bt_FindRouter_Click(object sender, EventArgs e)
        {
            try
            {
                //listBox1.Items.Clear();
                //comboBox2.Items.Clear();

                // 라우터 찾기 함수
                //QLightAPI.SearchRouters();
                //Delay(1000);
                // 현재 연결된 게이트웨이의 그룹 아이디인 라우터들을 검색하여 리스트에 저장
                //List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);

                *//*for (int i = 0; i < list.Count(); i++)
                {
                    listBox1.Items.Add(list[i]);  // 확인용
                    comboBox2.Items.Add(list[i]); // 콤보 박스에 하나씩 매칭
                }*//*


                // 모든 라우터(경광등) 리스트 검색
                Dictionary<ushort, ushort> list = QLightAPI.GetAllRouterList();

                foreach (ushort listkey in list.Keys)       // NODE ID
                {
                    //listBox1.Items.Add(listkey);
                }

                *//*foreach (ushort listValues in list.Values)       // GROUP ID
                {
                    listBox1.Items.Add(listValues);
                }*//*

                //listBox1.Items.Add("총 " + list.Count() + "개");  // 확인용 (검색된 라우터 총 갯수 표시)
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }*/

        private void bt_LEDALLON_Click(object sender, EventArgs e)
        {
            // 현재 연결된 게이트웨이의 그룹 아이디 정보를 가지고 그 그룹에 맞는 모든 라우터들을 검색 후 리스트로 저장

            /*List<ushort> list = QLightAPI.GetRouterListGroupId(groupid);
            ushort[] nodeid = new ushort[list.Count()];

            for (int i = 0; i < nodeid.Length; i++)
            {
                // Nodeid 배열에 리스트(모든 라우터)들을 하나씩 매칭 
                nodeid[i] = list[i];
            }*/

            Dictionary<ushort, ushort> list = QLightAPI.GetAllRouterList();
            ushort[] nodeid = new ushort[list.Keys.Count()];
            int i = 0;
            foreach (ushort listkey in list.Keys)       // NODE ID
            {
                nodeid[i] = listkey;
                i++;
            }

            // 같은 그룹의 모든 라우터들의 LED ON (초록색)
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.ON,
                LEDState.OFF,
                LEDState.OFF);

            for(i = 0; i < nodeid.Length; i++)
            {
                GREEN_LIGHT(Convert.ToString(nodeid[i]));
            }
        }

        private void bt_LED_ALL_OFF_Click(object sender, EventArgs e)
        {
            Dictionary<ushort, ushort> list = QLightAPI.GetAllRouterList();
            ushort[] nodeid = new ushort[list.Keys.Count()];
            int i = 0;

            foreach (ushort listkey in list.Keys)       // NODE ID
            {
                nodeid[i] = listkey;
                i++;
            }

            // 같은 그룹의 모든 라우터들의 LED ON (빨간색)
            QLightAPI.ControlRoutersLED(nodeid,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF,
                LEDState.OFF);

            for (i = 0; i < nodeid.Length; i++)
            {
                OFF_LIGHT(Convert.ToString(nodeid[i]));
            }
        }
        #endregion

        private void bt_QueryTEST_Click(object sender, EventArgs e)  // 테스트용
        {
            //listBox1.Items.Clear();
            string[] testid;
            if (cb_ITEMLIST.Text == "")
            {
                MessageBox.Show("품목을 선택해 주세요.");
            }
            else
            {
                testid = helper.Query(cb_ITEMLIST.Text);
                //testid = helper.Query("테스트");
                LED_ON(testid);
            }
            //listBox1.Items.Add(testid[1]);
        }
        #region < UI 색 제어 함수 >

        #region < 빨간색 >
        private void RED_LIGHT(string node)  // UI 상에서 빨간색으로 표시하는 함수
        {
            switch (node)
            {
                #region < 11그룹 버튼 빨간색 ON >
                case "1101":
                    LED_1101.BackColor = Color.Red;
                    break;
                case "1102":
                    LED_1102.BackColor = Color.Red;
                    break;
                case "1103":
                    LED_1103.BackColor = Color.Red;
                    break;
                case "1104":
                    LED_1104.BackColor = Color.Red;
                    break;
                case "1105":
                    LED_1105.BackColor = Color.Red;
                    break;
                case "1106":
                    LED_1106.BackColor = Color.Red;
                    break;
                case "1107":
                    LED_1107.BackColor = Color.Red;
                    break;
                case "1108":
                    LED_1108.BackColor = Color.Red;
                    break;
                case "1109":
                    LED_1109.BackColor = Color.Red;
                    break;
                case "1110":
                    LED_1110.BackColor = Color.Red;
                    break;
                case "1111":
                    LED_1111.BackColor = Color.Red;
                    break;
                case "1112":
                    LED_1112.BackColor = Color.Red;
                    break;
                case "1113":
                    LED_1113.BackColor = Color.Red;
                    break;
                case "1114":
                    LED_1114.BackColor = Color.Red;
                    break;
                case "1115":
                    LED_1115.BackColor = Color.Red;
                    break;
                case "1116":
                    LED_1116.BackColor = Color.Red;
                    break;
                case "1117":
                    LED_1117.BackColor = Color.Red;
                    break;
                #endregion
                #region < 12그룹 버튼 빨간색 ON >
                case "1201":
                    LED_1201.BackColor = Color.Red;
                    break;
                case "1202":
                    LED_1202.BackColor = Color.Red;
                    break;
                case "1203":
                    LED_1203.BackColor = Color.Red;
                    break;
                case "1204":
                    LED_1204.BackColor = Color.Red;
                    break;
                case "1205":
                    LED_1205.BackColor = Color.Red;
                    break;
                case "1206":
                    LED_1206.BackColor = Color.Red;
                    break;
                case "1207":
                    LED_1207.BackColor = Color.Red;
                    break;
                case "1208":
                    LED_1208.BackColor = Color.Red;
                    break;
                case "1209":
                    LED_1209.BackColor = Color.Red;
                    break;
                case "1210":
                    LED_1210.BackColor = Color.Red;
                    break;
                case "1211":
                    LED_1211.BackColor = Color.Red;
                    break;
                case "1212":
                    LED_1212.BackColor = Color.Red;
                    break;
                case "1213":
                    LED_1213.BackColor = Color.Red;
                    break;
                case "1214":
                    LED_1214.BackColor = Color.Red;
                    break;
                case "1215":
                    LED_1215.BackColor = Color.Red;
                    break;
                case "1216":
                    LED_1216.BackColor = Color.Red;
                    break;
                case "1217":
                    LED_1217.BackColor = Color.Red;
                    break;
                case "1218":
                    LED_1218.BackColor = Color.Red;
                    break;
                case "1219":
                    LED_1219.BackColor = Color.Red;
                    break;
                case "1220":
                    LED_1220.BackColor = Color.Red;
                    break;
                case "1221":
                    LED_1221.BackColor = Color.Red;
                    break;
                case "1222":
                    LED_1222.BackColor = Color.Red;
                    break;
                case "1224":
                    LED_1224.BackColor = Color.Red;
                    break;
                #endregion
                #region < 13그룹 버튼 빨간색 ON >
                case "1301":
                    LED_1301.BackColor = Color.Red;
                    break;
                case "1302":
                    LED_1302.BackColor = Color.Red;
                    break;
                case "1303":
                    LED_1303.BackColor = Color.Red;
                    break;
                case "1304":
                    LED_1304.BackColor = Color.Red;
                    break;
                case "1305":
                    LED_1305.BackColor = Color.Red;
                    break;
                case "1306":
                    LED_1306.BackColor = Color.Red;
                    break;
                case "1307":
                    LED_1307.BackColor = Color.Red;
                    break;
                case "1308":
                    LED_1308.BackColor = Color.Red;
                    break;
                case "1309":
                    LED_1309.BackColor = Color.Red;
                    break;
                case "1310":
                    LED_1310.BackColor = Color.Red;
                    break;
                case "1311":
                    LED_1311.BackColor = Color.Red;
                    break;
                case "1312":
                    LED_1312.BackColor = Color.Red;
                    break;
                case "1313":
                    LED_1313.BackColor = Color.Red;
                    break;
                case "1314":
                    LED_1314.BackColor = Color.Red;
                    break;
                case "1315":
                    LED_1315.BackColor = Color.Red;
                    break;
                case "1316":
                    LED_1316.BackColor = Color.Red;
                    break;
                case "1317":
                    LED_1317.BackColor = Color.Red;
                    break;
                case "1318":
                    LED_1318.BackColor = Color.Red;
                    break;
                case "1319":
                    LED_1319.BackColor = Color.Red;
                    break;
                case "1320":
                    LED_1320.BackColor = Color.Red;
                    break;
                #endregion
                #region < 14그룹 버튼 빨간색 ON >
                case "1401":
                    LED_1401.BackColor = Color.Red;
                    break;
                case "1402":
                    LED_1402.BackColor = Color.Red;
                    break;
                case "1403":
                    LED_1403.BackColor = Color.Red;
                    break;
                case "1404":
                    LED_1404.BackColor = Color.Red;
                    break;
                case "1405":
                    LED_1405.BackColor = Color.Red;
                    break;
                case "1406":
                    LED_1406.BackColor = Color.Red;
                    break;
                case "1407":
                    LED_1407.BackColor = Color.Red;
                    break;
                case "1408":
                    LED_1408.BackColor = Color.Red;
                    break;
                case "1409":
                    LED_1409.BackColor = Color.Red;
                    break;
                case "1410":
                    LED_1410.BackColor = Color.Red;
                    break;
                case "1411":
                    LED_1411.BackColor = Color.Red;
                    break;
                case "1412":
                    LED_1412.BackColor = Color.Red;
                    break;
                case "1413":
                    LED_1413.BackColor = Color.Red;
                    break;
                case "1414":
                    LED_1414.BackColor = Color.Red;
                    break;
                case "1415":
                    LED_1415.BackColor = Color.Red;
                    break;
                case "1416":
                    LED_1416.BackColor = Color.Red;
                    break;
                case "1417":
                    LED_1417.BackColor = Color.Red;
                    break;
                case "1418":
                    LED_1418.BackColor = Color.Red;
                    break;
                case "1419":
                    LED_1419.BackColor = Color.Red;
                    break;
                case "1420":
                    LED_1420.BackColor = Color.Red;
                    break;
                case "1421":
                    LED_1421.BackColor = Color.Red;
                    break;
                case "1422":
                    LED_1422.BackColor = Color.Red;
                    break;
                    #endregion
            }
        }
        #endregion
        #region < 파란색 >
        private void BLUE_LIGHT(string node)  // UI 상에서 파란색으로 표시하는 함수
        {
            switch (node)
            {
                #region < 11그룹 버튼 파란색 ON >
                case "1101":
                    LED_1101.BackColor = Color.Blue;
                    break;
                case "1102":
                    LED_1102.BackColor = Color.Blue;
                    break;
                case "1103":
                    LED_1103.BackColor = Color.Blue;
                    break;
                case "1104":
                    LED_1104.BackColor = Color.Blue;
                    break;
                case "1105":
                    LED_1105.BackColor = Color.Blue;
                    break;
                case "1106":
                    LED_1106.BackColor = Color.Blue;
                    break;
                case "1107":
                    LED_1107.BackColor = Color.Blue;
                    break;
                case "1108":
                    LED_1108.BackColor = Color.Blue;
                    break;
                case "1109":
                    LED_1109.BackColor = Color.Blue;
                    break;
                case "1110":
                    LED_1110.BackColor = Color.Blue;
                    break;
                case "1111":
                    LED_1111.BackColor = Color.Blue;
                    break;
                case "1112":
                    LED_1112.BackColor = Color.Blue;
                    break;
                case "1113":
                    LED_1113.BackColor = Color.Blue;
                    break;
                case "1114":
                    LED_1114.BackColor = Color.Blue;
                    break;
                case "1115":
                    LED_1115.BackColor = Color.Blue;
                    break;
                case "1116":
                    LED_1116.BackColor = Color.Blue;
                    break;
                case "1117":
                    LED_1117.BackColor = Color.Blue;
                    break;
                #endregion
                #region < 12그룹 버튼 파란색 ON >
                case "1201":
                    LED_1201.BackColor = Color.Blue;
                    break;
                case "1202":
                    LED_1202.BackColor = Color.Blue;
                    break;
                case "1203":
                    LED_1203.BackColor = Color.Blue;
                    break;
                case "1204":
                    LED_1204.BackColor = Color.Blue;
                    break;
                case "1205":
                    LED_1205.BackColor = Color.Blue;
                    break;
                case "1206":
                    LED_1206.BackColor = Color.Blue;
                    break;
                case "1207":
                    LED_1207.BackColor = Color.Blue;
                    break;
                case "1208":
                    LED_1208.BackColor = Color.Blue;
                    break;
                case "1209":
                    LED_1209.BackColor = Color.Blue;
                    break;
                case "1210":
                    LED_1210.BackColor = Color.Blue;
                    break;
                case "1211":
                    LED_1211.BackColor = Color.Blue;
                    break;
                case "1212":
                    LED_1212.BackColor = Color.Blue;
                    break;
                case "1213":
                    LED_1213.BackColor = Color.Blue;
                    break;
                case "1214":
                    LED_1214.BackColor = Color.Blue;
                    break;
                case "1215":
                    LED_1215.BackColor = Color.Blue;
                    break;
                case "1216":
                    LED_1216.BackColor = Color.Blue;
                    break;
                case "1217":
                    LED_1217.BackColor = Color.Blue;
                    break;
                case "1218":
                    LED_1218.BackColor = Color.Blue;
                    break;
                case "1219":
                    LED_1219.BackColor = Color.Blue;
                    break;
                case "1220":
                    LED_1220.BackColor = Color.Blue;
                    break;
                case "1221":
                    LED_1221.BackColor = Color.Blue;
                    break;
                case "1222":
                    LED_1222.BackColor = Color.Blue;
                    break;
                case "1224":
                    LED_1224.BackColor = Color.Blue;
                    break;
                #endregion
                #region < 13그룹 버튼 파란색 ON >
                case "1301":
                    LED_1301.BackColor = Color.Blue;
                    break;
                case "1302":
                    LED_1302.BackColor = Color.Blue;
                    break;
                case "1303":
                    LED_1303.BackColor = Color.Blue;
                    break;
                case "1304":
                    LED_1304.BackColor = Color.Blue;
                    break;
                case "1305":
                    LED_1305.BackColor = Color.Blue;
                    break;
                case "1306":
                    LED_1306.BackColor = Color.Blue;
                    break;
                case "1307":
                    LED_1307.BackColor = Color.Blue;
                    break;
                case "1308":
                    LED_1308.BackColor = Color.Blue;
                    break;
                case "1309":
                    LED_1309.BackColor = Color.Blue;
                    break;
                case "1310":
                    LED_1310.BackColor = Color.Blue;
                    break;
                case "1311":
                    LED_1311.BackColor = Color.Blue;
                    break;
                case "1312":
                    LED_1312.BackColor = Color.Blue;
                    break;
                case "1313":
                    LED_1313.BackColor = Color.Blue;
                    break;
                case "1314":
                    LED_1314.BackColor = Color.Blue;
                    break;
                case "1315":
                    LED_1315.BackColor = Color.Blue;
                    break;
                case "1316":
                    LED_1316.BackColor = Color.Blue;
                    break;
                case "1317":
                    LED_1317.BackColor = Color.Blue;
                    break;
                case "1318":
                    LED_1318.BackColor = Color.Blue;
                    break;
                case "1319":
                    LED_1319.BackColor = Color.Blue;
                    break;
                case "1320":
                    LED_1320.BackColor = Color.Blue;
                    break;
                #endregion
                #region < 14그룹 버튼 파란색 ON >
                case "1401":
                    LED_1401.BackColor = Color.Blue;
                    break;
                case "1402":
                    LED_1402.BackColor = Color.Blue;
                    break;
                case "1403":
                    LED_1403.BackColor = Color.Blue;
                    break;
                case "1404":
                    LED_1404.BackColor = Color.Blue;
                    break;
                case "1405":
                    LED_1405.BackColor = Color.Blue;
                    break;
                case "1406":
                    LED_1406.BackColor = Color.Blue;
                    break;
                case "1407":
                    LED_1407.BackColor = Color.Blue;
                    break;
                case "1408":
                    LED_1408.BackColor = Color.Blue;
                    break;
                case "1409":
                    LED_1409.BackColor = Color.Blue;
                    break;
                case "1410":
                    LED_1410.BackColor = Color.Blue;
                    break;
                case "1411":
                    LED_1411.BackColor = Color.Blue;
                    break;
                case "1412":
                    LED_1412.BackColor = Color.Blue;
                    break;
                case "1413":
                    LED_1413.BackColor = Color.Blue;
                    break;
                case "1414":
                    LED_1414.BackColor = Color.Blue;
                    break;
                case "1415":
                    LED_1415.BackColor = Color.Blue;
                    break;
                case "1416":
                    LED_1416.BackColor = Color.Blue;
                    break;
                case "1417":
                    LED_1417.BackColor = Color.Blue;
                    break;
                case "1418":
                    LED_1418.BackColor = Color.Blue;
                    break;
                case "1419":
                    LED_1419.BackColor = Color.Blue;
                    break;
                case "1420":
                    LED_1420.BackColor = Color.Blue;
                    break;
                case "1421":
                    LED_1421.BackColor = Color.Blue;
                    break;
                case "1422":
                    LED_1422.BackColor = Color.Blue;
                    break;
                    #endregion
            }
        }
        #endregion
        #region < 초록색 >
        private void GREEN_LIGHT(string node)  // UI 상에서 초록색으로 표시하는 함수
        {
            switch (node)
            {
                #region < 11그룹 버튼 초록색 ON >
                case "1101":
                    LED_1101.BackColor = Color.Green;
                    break;
                case "1102":
                    LED_1102.BackColor = Color.Green;
                    break;
                case "1103":
                    LED_1103.BackColor = Color.Green;
                    break;
                case "1104":
                    LED_1104.BackColor = Color.Green;
                    break;
                case "1105":
                    LED_1105.BackColor = Color.Green;
                    break;
                case "1106":
                    LED_1106.BackColor = Color.Green;
                    break;
                case "1107":
                    LED_1107.BackColor = Color.Green;
                    break;
                case "1108":
                    LED_1108.BackColor = Color.Green;
                    break;
                case "1109":
                    LED_1109.BackColor = Color.Green;
                    break;
                case "1110":
                    LED_1110.BackColor = Color.Green;
                    break;
                case "1111":
                    LED_1111.BackColor = Color.Green;
                    break;
                case "1112":
                    LED_1112.BackColor = Color.Green;
                    break;
                case "1113":
                    LED_1113.BackColor = Color.Green;
                    break;
                case "1114":
                    LED_1114.BackColor = Color.Green;
                    break;
                case "1115":
                    LED_1115.BackColor = Color.Green;
                    break;
                case "1116":
                    LED_1116.BackColor = Color.Green;
                    break;
                case "1117":
                    LED_1117.BackColor = Color.Green;
                    break;
                #endregion
                #region < 12그룹 버튼 초록색 ON >
                case "1201":
                    LED_1201.BackColor = Color.Green;
                    break;
                case "1202":
                    LED_1202.BackColor = Color.Green;
                    break;
                case "1203":
                    LED_1203.BackColor = Color.Green;
                    break;
                case "1204":
                    LED_1204.BackColor = Color.Green;
                    break;
                case "1205":
                    LED_1205.BackColor = Color.Green;
                    break;
                case "1206":
                    LED_1206.BackColor = Color.Green;
                    break;
                case "1207":
                    LED_1207.BackColor = Color.Green;
                    break;
                case "1208":
                    LED_1208.BackColor = Color.Green;
                    break;
                case "1209":
                    LED_1209.BackColor = Color.Green;
                    break;
                case "1210":
                    LED_1210.BackColor = Color.Green;
                    break;
                case "1211":
                    LED_1211.BackColor = Color.Green;
                    break;
                case "1212":
                    LED_1212.BackColor = Color.Green;
                    break;
                case "1213":
                    LED_1213.BackColor = Color.Green;
                    break;
                case "1214":
                    LED_1214.BackColor = Color.Green;
                    break;
                case "1215":
                    LED_1215.BackColor = Color.Green;
                    break;
                case "1216":
                    LED_1216.BackColor = Color.Green;
                    break;
                case "1217":
                    LED_1217.BackColor = Color.Green;
                    break;
                case "1218":
                    LED_1218.BackColor = Color.Green;
                    break;
                case "1219":
                    LED_1219.BackColor = Color.Green;
                    break;
                case "1220":
                    LED_1220.BackColor = Color.Green;
                    break;
                case "1221":
                    LED_1221.BackColor = Color.Green;
                    break;
                case "1222":
                    LED_1222.BackColor = Color.Green;
                    break;
                case "1224":
                    LED_1224.BackColor = Color.Green;
                    break;
                #endregion
                #region < 13그룹 버튼 초록색 ON >
                case "1301":
                    LED_1301.BackColor = Color.Green;
                    break;
                case "1302":
                    LED_1302.BackColor = Color.Green;
                    break;
                case "1303":
                    LED_1303.BackColor = Color.Green;
                    break;
                case "1304":
                    LED_1304.BackColor = Color.Green;
                    break;
                case "1305":
                    LED_1305.BackColor = Color.Green;
                    break;
                case "1306":
                    LED_1306.BackColor = Color.Green;
                    break;
                case "1307":
                    LED_1307.BackColor = Color.Green;
                    break;
                case "1308":
                    LED_1308.BackColor = Color.Green;
                    break;
                case "1309":
                    LED_1309.BackColor = Color.Green;
                    break;
                case "1310":
                    LED_1310.BackColor = Color.Green;
                    break;
                case "1311":
                    LED_1311.BackColor = Color.Green;
                    break;
                case "1312":
                    LED_1312.BackColor = Color.Green;
                    break;
                case "1313":
                    LED_1313.BackColor = Color.Green;
                    break;
                case "1314":
                    LED_1314.BackColor = Color.Green;
                    break;
                case "1315":
                    LED_1315.BackColor = Color.Green;
                    break;
                case "1316":
                    LED_1316.BackColor = Color.Green;
                    break;
                case "1317":
                    LED_1317.BackColor = Color.Green;
                    break;
                case "1318":
                    LED_1318.BackColor = Color.Green;
                    break;
                case "1319":
                    LED_1319.BackColor = Color.Green;
                    break;
                case "1320":
                    LED_1320.BackColor = Color.Green;
                    break;
                #endregion
                #region < 14그룹 버튼 초록색 ON >
                case "1401":
                    LED_1401.BackColor = Color.Green;
                    break;
                case "1402":
                    LED_1402.BackColor = Color.Green;
                    break;
                case "1403":
                    LED_1403.BackColor = Color.Green;
                    break;
                case "1404":
                    LED_1404.BackColor = Color.Green;
                    break;
                case "1405":
                    LED_1405.BackColor = Color.Green;
                    break;
                case "1406":
                    LED_1406.BackColor = Color.Green;
                    break;
                case "1407":
                    LED_1407.BackColor = Color.Green;
                    break;
                case "1408":
                    LED_1408.BackColor = Color.Green;
                    break;
                case "1409":
                    LED_1409.BackColor = Color.Green;
                    break;
                case "1410":
                    LED_1410.BackColor = Color.Green;
                    break;
                case "1411":
                    LED_1411.BackColor = Color.Green;
                    break;
                case "1412":
                    LED_1412.BackColor = Color.Green;
                    break;
                case "1413":
                    LED_1413.BackColor = Color.Green;
                    break;
                case "1414":
                    LED_1414.BackColor = Color.Green;
                    break;
                case "1415":
                    LED_1415.BackColor = Color.Green;
                    break;
                case "1416":
                    LED_1416.BackColor = Color.Green;
                    break;
                case "1417":
                    LED_1417.BackColor = Color.Green;
                    break;
                case "1418":
                    LED_1418.BackColor = Color.Green;
                    break;
                case "1419":
                    LED_1419.BackColor = Color.Green;
                    break;
                case "1420":
                    LED_1420.BackColor = Color.Green;
                    break;
                case "1421":
                    LED_1421.BackColor = Color.Green;
                    break;
                case "1422":
                    LED_1422.BackColor = Color.Green;
                    break;
                    #endregion
            }
        }
        #endregion
        #region < 표시 끄기 >
        private void OFF_LIGHT(string node)  // UI 상에서 표시된 색 OFF
        {
            switch (node)
            {
                #region < 11그룹 버튼 색 표시 OFF >
                case "1101":
                    LED_1101.BackColor = Color.Transparent;
                    break;
                case "1102":
                    LED_1102.BackColor = Color.Transparent;
                    break;
                case "1103":
                    LED_1103.BackColor = Color.Transparent;
                    break;
                case "1104":
                    LED_1104.BackColor = Color.Transparent;
                    break;
                case "1105":
                    LED_1105.BackColor = Color.Transparent;
                    break;
                case "1106":
                    LED_1106.BackColor = Color.Transparent;
                    break;
                case "1107":
                    LED_1107.BackColor = Color.Transparent;
                    break;
                case "1108":
                    LED_1108.BackColor = Color.Transparent;
                    break;
                case "1109":
                    LED_1109.BackColor = Color.Transparent;
                    break;
                case "1110":
                    LED_1110.BackColor = Color.Transparent;
                    break;
                case "1111":
                    LED_1111.BackColor = Color.Transparent;
                    break;
                case "1112":
                    LED_1112.BackColor = Color.Transparent;
                    break;
                case "1113":
                    LED_1113.BackColor = Color.Transparent;
                    break;
                case "1114":
                    LED_1114.BackColor = Color.Transparent;
                    break;
                case "1115":
                    LED_1115.BackColor = Color.Transparent;
                    break;
                case "1116":
                    LED_1116.BackColor = Color.Transparent;
                    break;
                case "1117":
                    LED_1117.BackColor = Color.Transparent;
                    break;
                #endregion
                #region < 12그룹 버튼 색 표시 OFF >
                case "1201":
                    LED_1201.BackColor = Color.Transparent;
                    break;
                case "1202":
                    LED_1202.BackColor = Color.Transparent;
                    break;
                case "1203":
                    LED_1203.BackColor = Color.Transparent;
                    break;
                case "1204":
                    LED_1204.BackColor = Color.Transparent;
                    break;
                case "1205":
                    LED_1205.BackColor = Color.Transparent;
                    break;
                case "1206":
                    LED_1206.BackColor = Color.Transparent;
                    break;
                case "1207":
                    LED_1207.BackColor = Color.Transparent;
                    break;
                case "1208":
                    LED_1208.BackColor = Color.Transparent;
                    break;
                case "1209":
                    LED_1209.BackColor = Color.Transparent;
                    break;
                case "1210":
                    LED_1210.BackColor = Color.Transparent;
                    break;
                case "1211":
                    LED_1211.BackColor = Color.Transparent;
                    break;
                case "1212":
                    LED_1212.BackColor = Color.Transparent;
                    break;
                case "1213":
                    LED_1213.BackColor = Color.Transparent;
                    break;
                case "1214":
                    LED_1214.BackColor = Color.Transparent;
                    break;
                case "1215":
                    LED_1215.BackColor = Color.Transparent;
                    break;
                case "1216":
                    LED_1216.BackColor = Color.Transparent;
                    break;
                case "1217":
                    LED_1217.BackColor = Color.Transparent;
                    break;
                case "1218":
                    LED_1218.BackColor = Color.Transparent;
                    break;
                case "1219":
                    LED_1219.BackColor = Color.Transparent;
                    break;
                case "1220":
                    LED_1220.BackColor = Color.Transparent;
                    break;
                case "1221":
                    LED_1221.BackColor = Color.Transparent;
                    break;
                case "1222":
                    LED_1222.BackColor = Color.Transparent;
                    break;
                case "1224":
                    LED_1224.BackColor = Color.Transparent;
                    break;
                #endregion
                #region < 13그룹 버튼 색 표시 OFF >
                case "1301":
                    LED_1301.BackColor = Color.Transparent;
                    break;
                case "1302":
                    LED_1302.BackColor = Color.Transparent;
                    break;
                case "1303":
                    LED_1303.BackColor = Color.Transparent;
                    break;
                case "1304":
                    LED_1304.BackColor = Color.Transparent;
                    break;
                case "1305":
                    LED_1305.BackColor = Color.Transparent;
                    break;
                case "1306":
                    LED_1306.BackColor = Color.Transparent;
                    break;
                case "1307":
                    LED_1307.BackColor = Color.Transparent;
                    break;
                case "1308":
                    LED_1308.BackColor = Color.Transparent;
                    break;
                case "1309":
                    LED_1309.BackColor = Color.Transparent;
                    break;
                case "1310":
                    LED_1310.BackColor = Color.Transparent;
                    break;
                case "1311":
                    LED_1311.BackColor = Color.Transparent;
                    break;
                case "1312":
                    LED_1312.BackColor = Color.Transparent;
                    break;
                case "1313":
                    LED_1313.BackColor = Color.Transparent;
                    break;
                case "1314":
                    LED_1314.BackColor = Color.Transparent;
                    break;
                case "1315":
                    LED_1315.BackColor = Color.Transparent;
                    break;
                case "1316":
                    LED_1316.BackColor = Color.Transparent;
                    break;
                case "1317":
                    LED_1317.BackColor = Color.Transparent;
                    break;
                case "1318":
                    LED_1318.BackColor = Color.Transparent;
                    break;
                case "1319":
                    LED_1319.BackColor = Color.Transparent;
                    break;
                case "1320":
                    LED_1320.BackColor = Color.Transparent;
                    break;
                #endregion
                #region < 14그룹 버튼 색 표시 OFF >
                case "1401":
                    LED_1401.BackColor = Color.Transparent;
                    break;
                case "1402":
                    LED_1402.BackColor = Color.Transparent;
                    break;
                case "1403":
                    LED_1403.BackColor = Color.Transparent;
                    break;
                case "1404":
                    LED_1404.BackColor = Color.Transparent;
                    break;
                case "1405":
                    LED_1405.BackColor = Color.Transparent;
                    break;
                case "1406":
                    LED_1406.BackColor = Color.Transparent;
                    break;
                case "1407":
                    LED_1407.BackColor = Color.Transparent;
                    break;
                case "1408":
                    LED_1408.BackColor = Color.Transparent;
                    break;
                case "1409":
                    LED_1409.BackColor = Color.Transparent;
                    break;
                case "1410":
                    LED_1410.BackColor = Color.Transparent;
                    break;
                case "1411":
                    LED_1411.BackColor = Color.Transparent;
                    break;
                case "1412":
                    LED_1412.BackColor = Color.Transparent;
                    break;
                case "1413":
                    LED_1413.BackColor = Color.Transparent;
                    break;
                case "1414":
                    LED_1414.BackColor = Color.Transparent;
                    break;
                case "1415":
                    LED_1415.BackColor = Color.Transparent;
                    break;
                case "1416":
                    LED_1416.BackColor = Color.Transparent;
                    break;
                case "1417":
                    LED_1417.BackColor = Color.Transparent;
                    break;
                case "1418":
                    LED_1418.BackColor = Color.Transparent;
                    break;
                case "1419":
                    LED_1419.BackColor = Color.Transparent;
                    break;
                case "1420":
                    LED_1420.BackColor = Color.Transparent;
                    break;
                case "1421":
                    LED_1421.BackColor = Color.Transparent;
                    break;
                case "1422":
                    LED_1422.BackColor = Color.Transparent;
                    break;
                    #endregion
            }
        }
        #endregion

        #endregion
    }
}