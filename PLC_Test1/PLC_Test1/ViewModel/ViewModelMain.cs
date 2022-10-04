using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ACTMULTILib;
using PLC_Test1.Helpers;

namespace PLC_Test1.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        private ActEasyIF aei;
        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisconnectCommand { get; set; }
        public RelayCommand ReadCommand { get; set; }
/*        public RelayCommand WriteCommand { get; set; }*/
        int check;
        int[] data;
        char[] cData;

        public ViewModelMain()
        {
            if (Num <= 0)
            {
                Num = 5;
            }
            ConnectCommand = new RelayCommand(Connect);
            DisconnectCommand = new RelayCommand(Disconnect);
            ReadCommand = new RelayCommand(Read);
/*            WriteCommand = new RelayCommand(Write);*/

            aei = new ActEasyIF();
            data = new int[Num];
            cData = new char[Num];
            check = 0;
        }

        /*        private void Write(object obj)
                {
                    if (IsConnected == 0)
                    {
                        Array.Clear(data, 0, data.Length);

                        for (int i = 0; i < data.Length; i++)
                        {
                            cData[i] = Str1[i];
                            data[i] = Convert.ToInt32(cData[i]);
                        }
                        check = aei.WriteDeviceBlock(SzDevice, data.Length, ref data[0]);
                    }
                }*/

        private void Read(object obj)
        {
            data = new int[Num];
            Str2 = "";

            if (IsConnected == 0)
            {
                Array.Clear(data, 0, data.Length);
                check = aei.ReadDeviceBlock(SzDevice, data.Length, out data[0]);

                if (check != 0) //에러
                {
                    MessageBox.Show("에러코드 " + check.ToString());
                }
                else if (check == 0) //정상동작
                {

                    for (int i = 0; i < data.Length; i++) //배열 크기만큼 반복
                    {
                        int sum = 0;
                        string str ="";
                        /*Str2 += Convert.ToChar(data[i]);*/
                        /*Str2 += $"{Convert.ToString(Convert.ToInt32(data[i]),16)} ";*/
                        if (Convert.ToInt32(data[i]) > 32767) // data 배열의 i 인덱스에 해당하는 값이 32767 보다 크면 음수라서 1의 보수를 취한다
                        {
                            sum = Convert.ToInt32(data[i]);
                            sum -= 1;
                            str = Convert.ToString(sum, 2);
                            if(str == "111111111111111") // 값이 -32768 이면 -0 으로 나와서 if문으로 따로 설정
                            {
                                str = "0111111111111111";
                            }
                            str = str.Replace("0", "2");
                            str = str.Replace("1", "0");
                            str = str.Replace("2", "1");
                            sum = Convert.ToInt32(str, 2);
                            Str2 += $"-{Convert.ToString(sum)} ";
                        }
                        else // 양수면 그냥 10진수로 변경후 출력
                        {
                            Str2 += $"{Convert.ToInt32(data[i])} ";
                    }
                }
                }
            }
        }
        private void Disconnect(object obj)
        {
            aei.Close();
            MessageBox.Show("연결 해제");
        }

        private void Connect(object obj)
        {
            aei.ActLogicalStationNumber = Number;
            IsConnected = aei.Open();
            if (IsConnected != 0)
            {
                MessageBox.Show("연결 에러");
            }
            else
                MessageBox.Show("연결 성공");
        }
    }
}
