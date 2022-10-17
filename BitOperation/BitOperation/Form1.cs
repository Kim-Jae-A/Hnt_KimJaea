using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void bt_op2_Click(object sender, EventArgs e)
        {
            if (tx_num1.Text == "")
            {
                tx_num1.Text = "0";
            }
            if (tx_num2.Text == "")
            {
                tx_num2.Text = "0";
            }
            int num1 = Convert.ToInt32(tx_num1.Text);
            int num2 = Convert.ToInt32(tx_num2.Text);
            if (num1 > 255 || num2 > 255)
            {
                tx_ch_num1.Text = Convert.ToString(num1, 2).PadLeft(16, '0');
                tx_ch_num2.Text = Convert.ToString(num2, 2).PadLeft(16, '0');
            }
            else
            {
                tx_ch_num1.Text = Convert.ToString(num1, 2).PadLeft(8, '0');
                tx_ch_num2.Text = Convert.ToString(num2, 2).PadLeft(8, '0');
            }
            bt_sum.Enabled = true;
        }

        private void tx_ch_num1_TextChanged(object sender, EventArgs e)
        {
            if (tx_ch_num1.Text.Substring(0, 1) == "1")
                ch_1_7.Checked = true;
            else
                ch_1_7.Checked = false;
            if (tx_ch_num1.Text.Substring(1, 1) == "1")
                ch_1_6.Checked = true;
            else
                ch_1_6.Checked = false;
            if (tx_ch_num1.Text.Substring(2, 1) == "1")
                ch_1_5.Checked = true;
            else
                ch_1_5.Checked = false;
            if (tx_ch_num1.Text.Substring(3, 1) == "1")
                ch_1_4.Checked = true;
            else
                ch_1_4.Checked = false;
            if (tx_ch_num1.Text.Substring(4, 1) == "1")
                ch_1_3.Checked = true;
            else
                ch_1_3.Checked = false;
            if (tx_ch_num1.Text.Substring(5, 1) == "1")
                ch_1_2.Checked = true;
            else
                ch_1_2.Checked = false;
            if (tx_ch_num1.Text.Substring(6, 1) == "1")
                ch_1_1.Checked = true;
            else
                ch_1_1.Checked = false;
            if (tx_ch_num1.Text.Substring(7, 1) == "1")
                ch_1_0.Checked = true;
            else
                ch_1_0.Checked = false;
        }

        private void bt_op10_Click(object sender, EventArgs e)
        {
            if (tx_ch_num1.Text == "")
            {
                tx_ch_num1.Text = "0";
            }
            if (tx_ch_num2.Text == "")
            {
                tx_ch_num2.Text = "0";
            }
            int num1 = Convert.ToInt32(tx_ch_num1.Text, 2);
            int num2 = Convert.ToInt32(tx_ch_num2.Text, 2);
            tx_num1.Text = Convert.ToString(num1);
            tx_num2.Text = Convert.ToString(num2);
        }

        private void tx_ch_num2_TextChanged(object sender, EventArgs e)
        {
            if (tx_ch_num2.Text.Substring(0, 1) == "1")
                ch_2_7.Checked = true;
            else
                ch_2_7.Checked = false;
            if (tx_ch_num2.Text.Substring(1, 1) == "1")
                ch_2_6.Checked = true;
            else
                ch_2_6.Checked = false;
            if (tx_ch_num2.Text.Substring(2, 1) == "1")
                ch_2_5.Checked = true;
            else
                ch_2_5.Checked = false;
            if (tx_ch_num2.Text.Substring(3, 1) == "1")
                ch_2_4.Checked = true;
            else
                ch_2_4.Checked = false;
            if (tx_ch_num2.Text.Substring(4, 1) == "1")
                ch_2_3.Checked = true;
            else
                ch_2_3.Checked = false;
            if (tx_ch_num2.Text.Substring(5, 1) == "1")
                ch_2_2.Checked = true;
            else
                ch_2_2.Checked = false;
            if (tx_ch_num2.Text.Substring(6, 1) == "1")
                ch_2_1.Checked = true;
            else
                ch_2_1.Checked = false;
            if (tx_ch_num2.Text.Substring(7, 1) == "1")
                ch_2_0.Checked = true;
            else
                ch_2_0.Checked = false;
        }

        private void bt_sum_Click(object sender, EventArgs e)
        {
            string sum;
            sum = tx_ch_num1.Text + tx_ch_num2.Text;
            tx_16bit.Text = sum;
            tx_16bit_10.Text = Convert.ToString(Convert.ToInt64(sum,2));
        }
    }
}
