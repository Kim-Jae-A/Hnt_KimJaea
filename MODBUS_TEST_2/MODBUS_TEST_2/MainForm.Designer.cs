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
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(12, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "데이터 갱신 주기";
            // 
            // Tx_TimeSet
            // 
            this.Tx_TimeSet.Font = new System.Drawing.Font("굴림", 15F);
            this.Tx_TimeSet.Location = new System.Drawing.Point(237, 349);
            this.Tx_TimeSet.Name = "Tx_TimeSet";
            this.Tx_TimeSet.Size = new System.Drawing.Size(192, 30);
            this.Tx_TimeSet.TabIndex = 1;
            this.Tx_TimeSet.Text = "5";
            this.Tx_TimeSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tx_TimeSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tx_TimeSet_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20F);
            this.label2.Location = new System.Drawing.Point(435, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "초";
            // 
            // Bt_Setting
            // 
            this.Bt_Setting.Font = new System.Drawing.Font("굴림", 15F);
            this.Bt_Setting.Location = new System.Drawing.Point(482, 349);
            this.Bt_Setting.Name = "Bt_Setting";
            this.Bt_Setting.Size = new System.Drawing.Size(96, 29);
            this.Bt_Setting.TabIndex = 3;
            this.Bt_Setting.Text = "설정";
            this.Bt_Setting.UseVisualStyleBackColor = true;
            this.Bt_Setting.Click += new System.EventHandler(this.Bt_Setting_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 386);
            this.Controls.Add(this.Bt_Setting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Tx_TimeSet);
            this.Controls.Add(this.label1);
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
    }
}