
namespace BitOperation
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tx_num1 = new System.Windows.Forms.TextBox();
            this.tx_num2 = new System.Windows.Forms.TextBox();
            this.la_num1 = new System.Windows.Forms.Label();
            this.la_num2 = new System.Windows.Forms.Label();
            this.bt_op2 = new System.Windows.Forms.Button();
            this.tx_ch_num1 = new System.Windows.Forms.TextBox();
            this.tx_ch_num2 = new System.Windows.Forms.TextBox();
            this.la_num3 = new System.Windows.Forms.Label();
            this.la_num4 = new System.Windows.Forms.Label();
            this.bt_op10 = new System.Windows.Forms.Button();
            this.ch_1_0 = new System.Windows.Forms.CheckBox();
            this.ch_1_1 = new System.Windows.Forms.CheckBox();
            this.ch_1_2 = new System.Windows.Forms.CheckBox();
            this.ch_1_3 = new System.Windows.Forms.CheckBox();
            this.ch_1_4 = new System.Windows.Forms.CheckBox();
            this.ch_1_5 = new System.Windows.Forms.CheckBox();
            this.ch_1_6 = new System.Windows.Forms.CheckBox();
            this.ch_1_7 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ch_2_7 = new System.Windows.Forms.CheckBox();
            this.ch_2_6 = new System.Windows.Forms.CheckBox();
            this.ch_2_5 = new System.Windows.Forms.CheckBox();
            this.ch_2_4 = new System.Windows.Forms.CheckBox();
            this.ch_2_3 = new System.Windows.Forms.CheckBox();
            this.ch_2_2 = new System.Windows.Forms.CheckBox();
            this.ch_2_1 = new System.Windows.Forms.CheckBox();
            this.ch_2_0 = new System.Windows.Forms.CheckBox();
            this.bt_sum = new System.Windows.Forms.Button();
            this.tx_16bit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tx_16bit_10 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tx_num1
            // 
            this.tx_num1.Location = new System.Drawing.Point(69, 35);
            this.tx_num1.Name = "tx_num1";
            this.tx_num1.Size = new System.Drawing.Size(259, 21);
            this.tx_num1.TabIndex = 0;
            // 
            // tx_num2
            // 
            this.tx_num2.Location = new System.Drawing.Point(69, 62);
            this.tx_num2.Name = "tx_num2";
            this.tx_num2.Size = new System.Drawing.Size(259, 21);
            this.tx_num2.TabIndex = 1;
            // 
            // la_num1
            // 
            this.la_num1.AutoSize = true;
            this.la_num1.Location = new System.Drawing.Point(7, 38);
            this.la_num1.Name = "la_num1";
            this.la_num1.Size = new System.Drawing.Size(56, 12);
            this.la_num1.TabIndex = 2;
            this.la_num1.Text = "Number1";
            // 
            // la_num2
            // 
            this.la_num2.AutoSize = true;
            this.la_num2.Location = new System.Drawing.Point(7, 65);
            this.la_num2.Name = "la_num2";
            this.la_num2.Size = new System.Drawing.Size(56, 12);
            this.la_num2.TabIndex = 3;
            this.la_num2.Text = "Number2";
            // 
            // bt_op2
            // 
            this.bt_op2.Location = new System.Drawing.Point(348, 41);
            this.bt_op2.Name = "bt_op2";
            this.bt_op2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bt_op2.Size = new System.Drawing.Size(96, 35);
            this.bt_op2.TabIndex = 4;
            this.bt_op2.Text = "2진수로 변환";
            this.bt_op2.UseVisualStyleBackColor = true;
            this.bt_op2.Click += new System.EventHandler(this.bt_op2_Click);
            // 
            // tx_ch_num1
            // 
            this.tx_ch_num1.Location = new System.Drawing.Point(69, 114);
            this.tx_ch_num1.Name = "tx_ch_num1";
            this.tx_ch_num1.ReadOnly = true;
            this.tx_ch_num1.Size = new System.Drawing.Size(259, 21);
            this.tx_ch_num1.TabIndex = 5;
            this.tx_ch_num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tx_ch_num1.TextChanged += new System.EventHandler(this.tx_ch_num1_TextChanged);
            // 
            // tx_ch_num2
            // 
            this.tx_ch_num2.Location = new System.Drawing.Point(69, 141);
            this.tx_ch_num2.Name = "tx_ch_num2";
            this.tx_ch_num2.ReadOnly = true;
            this.tx_ch_num2.Size = new System.Drawing.Size(259, 21);
            this.tx_ch_num2.TabIndex = 6;
            this.tx_ch_num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tx_ch_num2.TextChanged += new System.EventHandler(this.tx_ch_num2_TextChanged);
            // 
            // la_num3
            // 
            this.la_num3.AutoSize = true;
            this.la_num3.Location = new System.Drawing.Point(7, 117);
            this.la_num3.Name = "la_num3";
            this.la_num3.Size = new System.Drawing.Size(56, 12);
            this.la_num3.TabIndex = 7;
            this.la_num3.Text = "Number1";
            // 
            // la_num4
            // 
            this.la_num4.AutoSize = true;
            this.la_num4.Location = new System.Drawing.Point(7, 144);
            this.la_num4.Name = "la_num4";
            this.la_num4.Size = new System.Drawing.Size(56, 12);
            this.la_num4.TabIndex = 8;
            this.la_num4.Text = "Number2";
            // 
            // bt_op10
            // 
            this.bt_op10.Location = new System.Drawing.Point(348, 121);
            this.bt_op10.Name = "bt_op10";
            this.bt_op10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bt_op10.Size = new System.Drawing.Size(96, 35);
            this.bt_op10.TabIndex = 9;
            this.bt_op10.Text = "10진수로 변환";
            this.bt_op10.UseVisualStyleBackColor = true;
            this.bt_op10.Click += new System.EventHandler(this.bt_op2_Click);
            // 
            // ch_1_0
            // 
            this.ch_1_0.AutoCheck = false;
            this.ch_1_0.AutoSize = true;
            this.ch_1_0.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_0.Location = new System.Drawing.Point(313, 168);
            this.ch_1_0.Name = "ch_1_0";
            this.ch_1_0.Size = new System.Drawing.Size(15, 30);
            this.ch_1_0.TabIndex = 10;
            this.ch_1_0.Text = "0";
            this.ch_1_0.UseVisualStyleBackColor = true;
            // 
            // ch_1_1
            // 
            this.ch_1_1.AutoCheck = false;
            this.ch_1_1.AutoSize = true;
            this.ch_1_1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_1.Location = new System.Drawing.Point(292, 168);
            this.ch_1_1.Name = "ch_1_1";
            this.ch_1_1.Size = new System.Drawing.Size(15, 30);
            this.ch_1_1.TabIndex = 11;
            this.ch_1_1.Text = "1";
            this.ch_1_1.UseVisualStyleBackColor = true;
            // 
            // ch_1_2
            // 
            this.ch_1_2.AutoCheck = false;
            this.ch_1_2.AutoSize = true;
            this.ch_1_2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_2.Location = new System.Drawing.Point(271, 168);
            this.ch_1_2.Name = "ch_1_2";
            this.ch_1_2.Size = new System.Drawing.Size(15, 30);
            this.ch_1_2.TabIndex = 12;
            this.ch_1_2.Text = "2";
            this.ch_1_2.UseVisualStyleBackColor = true;
            // 
            // ch_1_3
            // 
            this.ch_1_3.AutoCheck = false;
            this.ch_1_3.AutoSize = true;
            this.ch_1_3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_3.Location = new System.Drawing.Point(250, 168);
            this.ch_1_3.Name = "ch_1_3";
            this.ch_1_3.Size = new System.Drawing.Size(15, 30);
            this.ch_1_3.TabIndex = 13;
            this.ch_1_3.Text = "3";
            this.ch_1_3.UseVisualStyleBackColor = true;
            // 
            // ch_1_4
            // 
            this.ch_1_4.AutoCheck = false;
            this.ch_1_4.AutoSize = true;
            this.ch_1_4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_4.Location = new System.Drawing.Point(229, 168);
            this.ch_1_4.Name = "ch_1_4";
            this.ch_1_4.Size = new System.Drawing.Size(15, 30);
            this.ch_1_4.TabIndex = 14;
            this.ch_1_4.Text = "4";
            this.ch_1_4.UseVisualStyleBackColor = true;
            // 
            // ch_1_5
            // 
            this.ch_1_5.AutoCheck = false;
            this.ch_1_5.AutoSize = true;
            this.ch_1_5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_5.Location = new System.Drawing.Point(208, 168);
            this.ch_1_5.Name = "ch_1_5";
            this.ch_1_5.Size = new System.Drawing.Size(15, 30);
            this.ch_1_5.TabIndex = 15;
            this.ch_1_5.Text = "5";
            this.ch_1_5.UseVisualStyleBackColor = true;
            // 
            // ch_1_6
            // 
            this.ch_1_6.AutoCheck = false;
            this.ch_1_6.AutoSize = true;
            this.ch_1_6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_6.Location = new System.Drawing.Point(187, 168);
            this.ch_1_6.Name = "ch_1_6";
            this.ch_1_6.Size = new System.Drawing.Size(15, 30);
            this.ch_1_6.TabIndex = 16;
            this.ch_1_6.Text = "6";
            this.ch_1_6.UseVisualStyleBackColor = true;
            // 
            // ch_1_7
            // 
            this.ch_1_7.AutoCheck = false;
            this.ch_1_7.AutoSize = true;
            this.ch_1_7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_1_7.Location = new System.Drawing.Point(166, 168);
            this.ch_1_7.Name = "ch_1_7";
            this.ch_1_7.Size = new System.Drawing.Size(15, 30);
            this.ch_1_7.TabIndex = 17;
            this.ch_1_7.Text = "7";
            this.ch_1_7.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Number1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "Number2";
            // 
            // ch_2_7
            // 
            this.ch_2_7.AutoCheck = false;
            this.ch_2_7.AutoSize = true;
            this.ch_2_7.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_7.Location = new System.Drawing.Point(166, 208);
            this.ch_2_7.Name = "ch_2_7";
            this.ch_2_7.Size = new System.Drawing.Size(15, 30);
            this.ch_2_7.TabIndex = 20;
            this.ch_2_7.Text = "7";
            this.ch_2_7.UseVisualStyleBackColor = true;
            // 
            // ch_2_6
            // 
            this.ch_2_6.AutoCheck = false;
            this.ch_2_6.AutoSize = true;
            this.ch_2_6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_6.Location = new System.Drawing.Point(187, 208);
            this.ch_2_6.Name = "ch_2_6";
            this.ch_2_6.Size = new System.Drawing.Size(15, 30);
            this.ch_2_6.TabIndex = 21;
            this.ch_2_6.Text = "6";
            this.ch_2_6.UseVisualStyleBackColor = true;
            // 
            // ch_2_5
            // 
            this.ch_2_5.AutoCheck = false;
            this.ch_2_5.AutoSize = true;
            this.ch_2_5.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_5.Location = new System.Drawing.Point(208, 208);
            this.ch_2_5.Name = "ch_2_5";
            this.ch_2_5.Size = new System.Drawing.Size(15, 30);
            this.ch_2_5.TabIndex = 22;
            this.ch_2_5.Text = "5";
            this.ch_2_5.UseVisualStyleBackColor = true;
            // 
            // ch_2_4
            // 
            this.ch_2_4.AutoCheck = false;
            this.ch_2_4.AutoSize = true;
            this.ch_2_4.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_4.Location = new System.Drawing.Point(229, 208);
            this.ch_2_4.Name = "ch_2_4";
            this.ch_2_4.Size = new System.Drawing.Size(15, 30);
            this.ch_2_4.TabIndex = 23;
            this.ch_2_4.Text = "4";
            this.ch_2_4.UseVisualStyleBackColor = true;
            // 
            // ch_2_3
            // 
            this.ch_2_3.AutoCheck = false;
            this.ch_2_3.AutoSize = true;
            this.ch_2_3.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_3.Location = new System.Drawing.Point(250, 208);
            this.ch_2_3.Name = "ch_2_3";
            this.ch_2_3.Size = new System.Drawing.Size(15, 30);
            this.ch_2_3.TabIndex = 24;
            this.ch_2_3.Text = "3";
            this.ch_2_3.UseVisualStyleBackColor = true;
            // 
            // ch_2_2
            // 
            this.ch_2_2.AutoCheck = false;
            this.ch_2_2.AutoSize = true;
            this.ch_2_2.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_2.Location = new System.Drawing.Point(270, 208);
            this.ch_2_2.Name = "ch_2_2";
            this.ch_2_2.Size = new System.Drawing.Size(15, 30);
            this.ch_2_2.TabIndex = 25;
            this.ch_2_2.Text = "2";
            this.ch_2_2.UseVisualStyleBackColor = true;
            // 
            // ch_2_1
            // 
            this.ch_2_1.AutoCheck = false;
            this.ch_2_1.AutoSize = true;
            this.ch_2_1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_1.Location = new System.Drawing.Point(292, 208);
            this.ch_2_1.Name = "ch_2_1";
            this.ch_2_1.Size = new System.Drawing.Size(15, 30);
            this.ch_2_1.TabIndex = 26;
            this.ch_2_1.Text = "1";
            this.ch_2_1.UseVisualStyleBackColor = true;
            // 
            // ch_2_0
            // 
            this.ch_2_0.AutoCheck = false;
            this.ch_2_0.AutoSize = true;
            this.ch_2_0.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ch_2_0.Location = new System.Drawing.Point(313, 208);
            this.ch_2_0.Name = "ch_2_0";
            this.ch_2_0.Size = new System.Drawing.Size(15, 30);
            this.ch_2_0.TabIndex = 27;
            this.ch_2_0.Text = "0";
            this.ch_2_0.UseVisualStyleBackColor = true;
            // 
            // bt_sum
            // 
            this.bt_sum.Enabled = false;
            this.bt_sum.Location = new System.Drawing.Point(93, 244);
            this.bt_sum.Name = "bt_sum";
            this.bt_sum.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bt_sum.Size = new System.Drawing.Size(235, 45);
            this.bt_sum.TabIndex = 28;
            this.bt_sum.Text = "비트 합치기";
            this.bt_sum.UseVisualStyleBackColor = true;
            this.bt_sum.Click += new System.EventHandler(this.bt_sum_Click);
            // 
            // tx_16bit
            // 
            this.tx_16bit.Location = new System.Drawing.Point(105, 308);
            this.tx_16bit.Name = "tx_16bit";
            this.tx_16bit.ReadOnly = true;
            this.tx_16bit.Size = new System.Drawing.Size(259, 21);
            this.tx_16bit.TabIndex = 29;
            this.tx_16bit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "sum bit (2진수)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "sum bit (10진수)";
            // 
            // tx_16bit_10
            // 
            this.tx_16bit_10.Location = new System.Drawing.Point(105, 345);
            this.tx_16bit_10.Name = "tx_16bit_10";
            this.tx_16bit_10.ReadOnly = true;
            this.tx_16bit_10.Size = new System.Drawing.Size(259, 21);
            this.tx_16bit_10.TabIndex = 32;
            this.tx_16bit_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.tx_16bit_10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tx_16bit);
            this.Controls.Add(this.bt_sum);
            this.Controls.Add(this.ch_2_0);
            this.Controls.Add(this.ch_2_1);
            this.Controls.Add(this.ch_2_2);
            this.Controls.Add(this.ch_2_3);
            this.Controls.Add(this.ch_2_4);
            this.Controls.Add(this.ch_2_5);
            this.Controls.Add(this.ch_2_6);
            this.Controls.Add(this.ch_2_7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ch_1_7);
            this.Controls.Add(this.ch_1_6);
            this.Controls.Add(this.ch_1_5);
            this.Controls.Add(this.ch_1_4);
            this.Controls.Add(this.ch_1_3);
            this.Controls.Add(this.ch_1_2);
            this.Controls.Add(this.ch_1_1);
            this.Controls.Add(this.ch_1_0);
            this.Controls.Add(this.bt_op10);
            this.Controls.Add(this.la_num4);
            this.Controls.Add(this.la_num3);
            this.Controls.Add(this.tx_ch_num2);
            this.Controls.Add(this.tx_ch_num1);
            this.Controls.Add(this.bt_op2);
            this.Controls.Add(this.la_num2);
            this.Controls.Add(this.la_num1);
            this.Controls.Add(this.tx_num2);
            this.Controls.Add(this.tx_num1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tx_num1;
        private System.Windows.Forms.TextBox tx_num2;
        private System.Windows.Forms.Label la_num1;
        private System.Windows.Forms.Label la_num2;
        private System.Windows.Forms.Button bt_op2;
        private System.Windows.Forms.TextBox tx_ch_num1;
        private System.Windows.Forms.TextBox tx_ch_num2;
        private System.Windows.Forms.Label la_num3;
        private System.Windows.Forms.Label la_num4;
        private System.Windows.Forms.Button bt_op10;
        private System.Windows.Forms.CheckBox ch_1_0;
        private System.Windows.Forms.CheckBox ch_1_1;
        private System.Windows.Forms.CheckBox ch_1_2;
        private System.Windows.Forms.CheckBox ch_1_3;
        private System.Windows.Forms.CheckBox ch_1_4;
        private System.Windows.Forms.CheckBox ch_1_5;
        private System.Windows.Forms.CheckBox ch_1_6;
        private System.Windows.Forms.CheckBox ch_1_7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ch_2_7;
        private System.Windows.Forms.CheckBox ch_2_6;
        private System.Windows.Forms.CheckBox ch_2_5;
        private System.Windows.Forms.CheckBox ch_2_4;
        private System.Windows.Forms.CheckBox ch_2_3;
        private System.Windows.Forms.CheckBox ch_2_2;
        private System.Windows.Forms.CheckBox ch_2_1;
        private System.Windows.Forms.CheckBox ch_2_0;
        private System.Windows.Forms.Button bt_sum;
        private System.Windows.Forms.TextBox tx_16bit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tx_16bit_10;
    }
}

