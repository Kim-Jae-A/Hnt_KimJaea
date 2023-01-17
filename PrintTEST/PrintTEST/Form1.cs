using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MesSystem;

// Zebra GT800 프린트에서만 테스트 해봄
// 용지 크기는 3.5 * 2 cm 사이즈임
// ZPL 언어 사용함

namespace PrintTEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  // 바코드 생성 버튼 클릭 이벤트
        {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            string BarCode = Getbarcode();

            if(!(RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, BarCode)))
            {
                MessageBox.Show("에러!!");
            }
            else
            {

            }
        }

        private string Getbarcode()   // 바코드 변환
        {
            string BarCode = string.Empty;

            BarCode = "^XA";                                                      // 시작점
            BarCode += "\r\n^LH 180,17";                                          // 기준점
            BarCode += "\r\n^FO 10,10^B3N,N,120,N^FD" + textBox3.Text + "^FS";    // 1차원바코드
            BarCode += "\r\n^XZ";

            return BarCode;
        }

        private void button2_Click(object sender, EventArgs e)   // Qr 버튼 클릭 이벤트
        {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new System.Drawing.Printing.PrinterSettings();

            string Qr = GetQr();

            if (!(RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, Qr)))
            {
                MessageBox.Show("에러!!");
            }
            else
            {

            }
        }

        private string GetQr()   // qr 변환
        {
            string Qr = string.Empty;

            Qr = "^XA";                                                            
            Qr += "\r\n^FO10,5^BQN,5,5^FDAAA" + textBox3.Text + "^FS";    // Qr
            Qr += "\r\n^XZ";

            return Qr;
        }
    }
}
