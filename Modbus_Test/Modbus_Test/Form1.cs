using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Modbus.Data;
using Modbus.Device;
using Modbus.Utility;

namespace Modbus_Test
{
    public partial class Form1 : Form
    {
        bool check = true;
        private DataTable table;
        double[] SendData = new double[32];

        public Form1()
        {
            InitializeComponent();
            table = GetTable();
            DataView.DataSource = table.DefaultView; 
            StratModbus();

        }
        public void StratModbus()
        {
            long Data = 0x0000;
            ushort[] Hold_input;
            ushort[] Hold_WriteVal = { 0x0000 };
            int Hold_Write_buff = 0x0000;
            int Hold_Read_buff = 0x0000;
            int HoldBitData = 0;
            ushort HoldBitMask = 0x0001;

            TcpClient client = new TcpClient("10.10.24.251", 5000);
            if (client.Connected == true)
            {
                ModbusIpMaster master = ModbusIpMaster.CreateIp(client);
                ushort startAddress = 0;
                ushort numInputs = 64;

                while (check)
                {
                    try
                    {
                        ushort[] input = master.ReadInputRegisters(startAddress, numInputs);
                        for (int i = 0; i < numInputs; i++)
                        {
                            SetDataGrid(i, input[i]);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }

                }
            }
        }
        public void SetDataGrid(int Index, ushort data)
        {
            Console.WriteLine("DataGride :" + Index.ToString());
            if (Index < 0 || Index > 64) return;
            try
            {
                table.Rows[Index]["RAW DATA"] = "0x" + data.ToString("X4");
                table.Rows[Index]["DATA"] = data.ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { }
        }
        public void SetConvertDataGrid(int Index, double data)
        {
            string Name = "";
            Console.WriteLine("ConvertGride :" + Index.ToString());
            if (Index < 0 || Index > 64) return;

            if (Index == 4 || Index == 8 || Index == 18 || Index == 28 || Index == 38 || Index == 48 || Index == 60)
            {
                if (Index == 4) Name = "(수세 - 1 수위)";
                else if (Index == 8) Name = "(산세 - 1 수위)";
                else if (Index == 18) Name = "(산세 - 2 수위)";
                else if (Index == 28) Name = "(산세 - 3 수위)";
                else if (Index == 38) Name = "(산세 - 4 수위)";
                else if (Index == 48) Name = "(산세 - 5 수위)";
                else if (Index == 60) Name = "(수세 - 2 수위)";
            }
            else if (Index == 6 || Index == 16 || Index == 26 || Index == 36 || Index == 46)
            {
                if (Index == 6) Name = "(산세 - 1 농도)";
                else if (Index == 16) Name = "(산세 - 2 농도)";
                else if (Index == 26) Name = "(산세 - 3 농도)";
                else if (Index == 36) Name = "(산세 - 4 농도)";
                else if (Index == 46) Name = "(산세 - 5 농도)";
            }
            else if (Index == 14 || Index == 24 || Index == 34 || Index == 44 || Index == 54)
            {
                if (Index == 14) Name = "(산세 - 1 온도 - 1)";
                else if (Index == 24) Name = "(산세 - 2 온도)";
                else if (Index == 34) Name = "(산세 - 3 온도)";
                else if (Index == 44) Name = "(산세 - 4 온도)";
                else if (Index == 54) Name = "(산세 - 5 온도)";

            }
            else if (Index == 0 || Index == 12 || Index == 22 || Index == 32 || Index == 42 || Index == 52 || Index == 56)
            {
                if (Index == 0) Name = "(수세 - 1 용수유량계)";
                else if (Index == 12) Name = "(산세 - 1 용수유량계)";
                else if (Index == 22) Name = "(산세 - 2 용수유량계)";
                else if (Index == 32) Name = "(산세 - 3 용수유량계)";
                else if (Index == 42) Name = "(산세 - 4 용수유량계)";
                else if (Index == 52) Name = "(산세 - 5 용수유량계)";
                else if (Index == 56) Name = "(수세 - 2 용수유량계)";

            }
            else if (Index == 10 || Index == 20 || Index == 30 || Index == 40 || Index == 50)
            {
                if (Index == 10) Name = "(산세 - 1 염산유량계)";
                else if (Index == 20) Name = "(산세 - 2 염산유량계)";
                else if (Index == 30) Name = "(산세 - 3 염산유량계)";
                else if (Index == 40) Name = "(산세 - 4 염산유량계)";
                else if (Index == 50) Name = "(산세 - 5 염산유량계)";
            }
            try
            {
                table.Rows[Index]["C-DATA"] = data.ToString("F4") + "   " + Name;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { }
        }

        private DataTable GetTable()
        {
            table = new DataTable();
            table.Columns.Add("MAPADDR");
            table.Columns.Add("ADDRESS");
            table.Columns.Add("RAW DATA");
            table.Columns.Add("DATA");
            table.Columns.Add("C-DATA");

            string sTemp = "";
            for (int i = 34; i < 38; i++)
            {
                sTemp = "D22" + i.ToString("D2");
                table.Rows.Add(sTemp, i.ToString("D4"), 0);
            }
            return table;
        }
    }
}
