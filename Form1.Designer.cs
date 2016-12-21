using System;

namespace Joy2Key
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.connectDevice = new System.Windows.Forms.Button();
            this.devList = new System.Windows.Forms.ListBox();
            this.GetDevice = new System.Windows.Forms.Button();
            this.logList = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // connectDevice
            // 
            this.connectDevice.Location = new System.Drawing.Point(555, 152);
            this.connectDevice.Name = "connectDevice";
            this.connectDevice.Size = new System.Drawing.Size(75, 23);
            this.connectDevice.TabIndex = 2;
            this.connectDevice.Text = "连接手柄";
            this.connectDevice.UseVisualStyleBackColor = true;
            this.connectDevice.Click += new System.EventHandler(this.ConnectDevice_Click);
            // 
            // devList
            // 
            this.devList.FormattingEnabled = true;
            this.devList.ItemHeight = 12;
            this.devList.Location = new System.Drawing.Point(12, 123);
            this.devList.Name = "devList";
            this.devList.Size = new System.Drawing.Size(459, 52);
            this.devList.TabIndex = 3;
            // 
            // GetDevice
            // 
            this.GetDevice.Location = new System.Drawing.Point(555, 123);
            this.GetDevice.Name = "GetDevice";
            this.GetDevice.Size = new System.Drawing.Size(75, 23);
            this.GetDevice.TabIndex = 4;
            this.GetDevice.Text = "刷新列表";
            this.GetDevice.UseVisualStyleBackColor = true;
            this.GetDevice.Click += new System.EventHandler(this.GetDevice_Click);
            // 
            // logList
            // 
            this.logList.FormattingEnabled = true;
            this.logList.ItemHeight = 12;
            this.logList.Location = new System.Drawing.Point(12, 182);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(459, 160);
            this.logList.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 407);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.logList);
            this.Controls.Add(this.GetDevice);
            this.Controls.Add(this.devList);
            this.Controls.Add(this.connectDevice);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }    

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectDevice;
        private System.Windows.Forms.ListBox devList;
        private System.Windows.Forms.Button GetDevice;
        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

