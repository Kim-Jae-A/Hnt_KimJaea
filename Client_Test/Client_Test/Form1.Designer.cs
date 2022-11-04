
namespace Client_Test
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
            this.ServerIP = new System.Windows.Forms.Label();
            this.Box_ServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Box_Port = new System.Windows.Forms.TextBox();
            this.Bt_Connect = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Box_send = new System.Windows.Forms.TextBox();
            this.Bt_send = new System.Windows.Forms.Button();
            this.Box_Hex_Code = new System.Windows.Forms.TextBox();
            this.Bt_Hexcode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ServerIP
            // 
            this.ServerIP.AutoSize = true;
            this.ServerIP.Location = new System.Drawing.Point(17, 15);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(52, 12);
            this.ServerIP.TabIndex = 0;
            this.ServerIP.Text = "ServerIP";
            // 
            // Box_ServerIP
            // 
            this.Box_ServerIP.Location = new System.Drawing.Point(75, 9);
            this.Box_ServerIP.Name = "Box_ServerIP";
            this.Box_ServerIP.Size = new System.Drawing.Size(319, 21);
            this.Box_ServerIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(412, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // Box_Port
            // 
            this.Box_Port.Location = new System.Drawing.Point(445, 8);
            this.Box_Port.Name = "Box_Port";
            this.Box_Port.Size = new System.Drawing.Size(113, 21);
            this.Box_Port.TabIndex = 3;
            // 
            // Bt_Connect
            // 
            this.Bt_Connect.Location = new System.Drawing.Point(579, 6);
            this.Bt_Connect.Name = "Bt_Connect";
            this.Bt_Connect.Size = new System.Drawing.Size(119, 30);
            this.Bt_Connect.TabIndex = 4;
            this.Bt_Connect.Text = "Connect";
            this.Bt_Connect.UseVisualStyleBackColor = true;
            this.Bt_Connect.Click += new System.EventHandler(this.Bt_Connect_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(19, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(678, 304);
            this.listBox1.TabIndex = 5;
            // 
            // Box_send
            // 
            this.Box_send.Location = new System.Drawing.Point(19, 358);
            this.Box_send.Name = "Box_send";
            this.Box_send.Size = new System.Drawing.Size(545, 21);
            this.Box_send.TabIndex = 6;
            // 
            // Bt_send
            // 
            this.Bt_send.Location = new System.Drawing.Point(578, 353);
            this.Bt_send.Name = "Bt_send";
            this.Bt_send.Size = new System.Drawing.Size(119, 30);
            this.Bt_send.TabIndex = 7;
            this.Bt_send.Text = "Send";
            this.Bt_send.UseVisualStyleBackColor = true;
            this.Bt_send.Click += new System.EventHandler(this.Bt_send_Click);
            // 
            // Box_Hex_Code
            // 
            this.Box_Hex_Code.Location = new System.Drawing.Point(19, 387);
            this.Box_Hex_Code.Name = "Box_Hex_Code";
            this.Box_Hex_Code.Size = new System.Drawing.Size(545, 21);
            this.Box_Hex_Code.TabIndex = 8;
            this.Box_Hex_Code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Box_Hex_Code_KeyPress);
            // 
            // Bt_Hexcode
            // 
            this.Bt_Hexcode.Location = new System.Drawing.Point(578, 383);
            this.Bt_Hexcode.Name = "Bt_Hexcode";
            this.Bt_Hexcode.Size = new System.Drawing.Size(119, 30);
            this.Bt_Hexcode.TabIndex = 9;
            this.Bt_Hexcode.Text = "HexCodeSend";
            this.Bt_Hexcode.UseVisualStyleBackColor = true;
            this.Bt_Hexcode.Click += new System.EventHandler(this.Bt_Hexcode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 422);
            this.Controls.Add(this.Bt_Hexcode);
            this.Controls.Add(this.Box_Hex_Code);
            this.Controls.Add(this.Bt_send);
            this.Controls.Add(this.Box_send);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Bt_Connect);
            this.Controls.Add(this.Box_Port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Box_ServerIP);
            this.Controls.Add(this.ServerIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ServerIP;
        private System.Windows.Forms.TextBox Box_ServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Box_Port;
        private System.Windows.Forms.Button Bt_Connect;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox Box_send;
        private System.Windows.Forms.Button Bt_send;
        private System.Windows.Forms.TextBox Box_Hex_Code;
        private System.Windows.Forms.Button Bt_Hexcode;
    }
}

