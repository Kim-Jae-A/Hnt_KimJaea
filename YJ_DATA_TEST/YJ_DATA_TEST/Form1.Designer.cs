
namespace YJ_DATA_TEST
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Box_Test_Send = new System.Windows.Forms.TextBox();
            this.Bt_Test_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(496, 268);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "test";
            // 
            // Box_Test_Send
            // 
            this.Box_Test_Send.Location = new System.Drawing.Point(49, 9);
            this.Box_Test_Send.Name = "Box_Test_Send";
            this.Box_Test_Send.Size = new System.Drawing.Size(394, 21);
            this.Box_Test_Send.TabIndex = 2;
            // 
            // Bt_Test_Send
            // 
            this.Bt_Test_Send.Location = new System.Drawing.Point(449, 5);
            this.Bt_Test_Send.Name = "Bt_Test_Send";
            this.Bt_Test_Send.Size = new System.Drawing.Size(53, 31);
            this.Bt_Test_Send.TabIndex = 3;
            this.Bt_Test_Send.Text = "Send";
            this.Bt_Test_Send.UseVisualStyleBackColor = true;
            this.Bt_Test_Send.Click += new System.EventHandler(this.Bt_Test_Send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 326);
            this.Controls.Add(this.Bt_Test_Send);
            this.Controls.Add(this.Box_Test_Send);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Box_Test_Send;
        private System.Windows.Forms.Button Bt_Test_Send;
    }
}

