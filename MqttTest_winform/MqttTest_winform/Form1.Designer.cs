namespace MqttTest_winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tx_borker = new System.Windows.Forms.TextBox();
            this.la_broker = new System.Windows.Forms.Label();
            this.bt_join = new System.Windows.Forms.Button();
            this.la_topic = new System.Windows.Forms.Label();
            this.tx_topic = new System.Windows.Forms.TextBox();
            this.la_port = new System.Windows.Forms.Label();
            this.tx_port = new System.Windows.Forms.TextBox();
            this.tx_maintext = new System.Windows.Forms.TextBox();
            this.la_message = new System.Windows.Forms.Label();
            this.bt_send = new System.Windows.Forms.Button();
            this.ls_chat = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tx_borker
            // 
            this.tx_borker.Location = new System.Drawing.Point(53, 413);
            this.tx_borker.Name = "tx_borker";
            this.tx_borker.Size = new System.Drawing.Size(320, 23);
            this.tx_borker.TabIndex = 0;
            // 
            // la_broker
            // 
            this.la_broker.AutoSize = true;
            this.la_broker.Location = new System.Drawing.Point(6, 416);
            this.la_broker.Name = "la_broker";
            this.la_broker.Size = new System.Drawing.Size(41, 15);
            this.la_broker.TabIndex = 1;
            this.la_broker.Text = "Borker";
            // 
            // bt_join
            // 
            this.bt_join.Location = new System.Drawing.Point(393, 381);
            this.bt_join.Name = "bt_join";
            this.bt_join.Size = new System.Drawing.Size(78, 55);
            this.bt_join.TabIndex = 2;
            this.bt_join.Text = "join";
            this.bt_join.UseVisualStyleBackColor = true;
            this.bt_join.Click += new System.EventHandler(this.bt_join_Click);
            // 
            // la_topic
            // 
            this.la_topic.AutoSize = true;
            this.la_topic.Location = new System.Drawing.Point(6, 384);
            this.la_topic.Name = "la_topic";
            this.la_topic.Size = new System.Drawing.Size(36, 15);
            this.la_topic.TabIndex = 3;
            this.la_topic.Text = "Topic";
            // 
            // tx_topic
            // 
            this.tx_topic.Location = new System.Drawing.Point(53, 381);
            this.tx_topic.Name = "tx_topic";
            this.tx_topic.Size = new System.Drawing.Size(135, 23);
            this.tx_topic.TabIndex = 4;
            // 
            // la_port
            // 
            this.la_port.AutoSize = true;
            this.la_port.Location = new System.Drawing.Point(194, 384);
            this.la_port.Name = "la_port";
            this.la_port.Size = new System.Drawing.Size(29, 15);
            this.la_port.TabIndex = 5;
            this.la_port.Text = "Port";
            // 
            // tx_port
            // 
            this.tx_port.Location = new System.Drawing.Point(236, 381);
            this.tx_port.Name = "tx_port";
            this.tx_port.Size = new System.Drawing.Size(137, 23);
            this.tx_port.TabIndex = 6;
            this.tx_port.Text = "1883";
            // 
            // tx_maintext
            // 
            this.tx_maintext.Location = new System.Drawing.Point(65, 14);
            this.tx_maintext.Name = "tx_maintext";
            this.tx_maintext.Size = new System.Drawing.Size(320, 23);
            this.tx_maintext.TabIndex = 7;
            // 
            // la_message
            // 
            this.la_message.AutoSize = true;
            this.la_message.Location = new System.Drawing.Point(6, 17);
            this.la_message.Name = "la_message";
            this.la_message.Size = new System.Drawing.Size(53, 15);
            this.la_message.TabIndex = 8;
            this.la_message.Text = "Message";
            // 
            // bt_send
            // 
            this.bt_send.Location = new System.Drawing.Point(393, 14);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(78, 23);
            this.bt_send.TabIndex = 9;
            this.bt_send.Text = "send";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // ls_chat
            // 
            this.ls_chat.FormattingEnabled = true;
            this.ls_chat.ItemHeight = 15;
            this.ls_chat.Location = new System.Drawing.Point(8, 43);
            this.ls_chat.Name = "ls_chat";
            this.ls_chat.Size = new System.Drawing.Size(463, 319);
            this.ls_chat.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 448);
            this.Controls.Add(this.ls_chat);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.la_message);
            this.Controls.Add(this.tx_maintext);
            this.Controls.Add(this.tx_port);
            this.Controls.Add(this.la_port);
            this.Controls.Add(this.tx_topic);
            this.Controls.Add(this.la_topic);
            this.Controls.Add(this.bt_join);
            this.Controls.Add(this.la_broker);
            this.Controls.Add(this.tx_borker);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tx_borker;
        private Label la_broker;
        private Button bt_join;
        private Label la_topic;
        private TextBox tx_topic;
        private Label la_port;
        private TextBox tx_port;
        private TextBox tx_maintext;
        private Label la_message;
        private Button bt_send;
        private ListBox ls_chat;
    }
}