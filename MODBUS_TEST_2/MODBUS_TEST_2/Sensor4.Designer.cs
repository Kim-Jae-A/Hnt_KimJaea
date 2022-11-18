
namespace MODBUS_TEST_2
{
    partial class Sensor4
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Tx_Tem = new System.Windows.Forms.TextBox();
            this.Tx_Per = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F);
            this.label1.Location = new System.Drawing.Point(36, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "온도";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F);
            this.label2.Location = new System.Drawing.Point(168, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "PH";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5150;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Tx_Tem
            // 
            this.Tx_Tem.Font = new System.Drawing.Font("굴림", 15F);
            this.Tx_Tem.Location = new System.Drawing.Point(12, 81);
            this.Tx_Tem.Name = "Tx_Tem";
            this.Tx_Tem.ReadOnly = true;
            this.Tx_Tem.Size = new System.Drawing.Size(106, 30);
            this.Tx_Tem.TabIndex = 5;
            this.Tx_Tem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tx_Per
            // 
            this.Tx_Per.Font = new System.Drawing.Font("굴림", 15F);
            this.Tx_Per.Location = new System.Drawing.Point(137, 81);
            this.Tx_Per.Name = "Tx_Per";
            this.Tx_Per.ReadOnly = true;
            this.Tx_Per.Size = new System.Drawing.Size(116, 30);
            this.Tx_Per.TabIndex = 6;
            this.Tx_Per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F);
            this.label3.Location = new System.Drawing.Point(104, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "PH";
            // 
            // Sensor4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 131);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Tx_Per);
            this.Controls.Add(this.Tx_Tem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sensor4";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox Tx_Tem;
        public System.Windows.Forms.TextBox Tx_Per;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
    }
}

