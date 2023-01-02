﻿
namespace MODBUS_TEST_2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.Tx_TimeSet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Bt_Setting = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(14, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터 갱신 주기";
            // 
            // Tx_TimeSet
            // 
            this.Tx_TimeSet.Font = new System.Drawing.Font("굴림", 15F);
            this.Tx_TimeSet.Location = new System.Drawing.Point(271, 436);
            this.Tx_TimeSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Tx_TimeSet.Name = "Tx_TimeSet";
            this.Tx_TimeSet.Size = new System.Drawing.Size(219, 36);
            this.Tx_TimeSet.TabIndex = 1;
            this.Tx_TimeSet.Text = "5";
            this.Tx_TimeSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tx_TimeSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_TimeSet_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20F);
            this.label2.Location = new System.Drawing.Point(497, 438);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "분";
            // 
            // Bt_Setting
            // 
            this.Bt_Setting.Font = new System.Drawing.Font("굴림", 15F);
            this.Bt_Setting.Location = new System.Drawing.Point(551, 436);
            this.Bt_Setting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Bt_Setting.Name = "Bt_Setting";
            this.Bt_Setting.Size = new System.Drawing.Size(110, 36);
            this.Bt_Setting.TabIndex = 3;
            this.Bt_Setting.Text = "설정";
            this.Bt_Setting.UseVisualStyleBackColor = true;
            this.Bt_Setting.Click += new System.EventHandler(this.Bt_Setting_Click);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 482);
            this.Controls.Add(this.Bt_Setting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tx_TimeSet);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "GN_SENSOR_DATA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Tx_TimeSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Bt_Setting;
        private System.Windows.Forms.Timer timer2;
    }
}