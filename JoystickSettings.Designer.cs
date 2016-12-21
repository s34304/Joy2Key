namespace Joy2Key
{
    partial class JoystickSettings
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
            this.leftRaduis = new System.Windows.Forms.TextBox();
            this.leftOriginY = new System.Windows.Forms.TextBox();
            this.leftOriginX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leftRaduis
            // 
            this.leftRaduis.Location = new System.Drawing.Point(56, 107);
            this.leftRaduis.Name = "leftRaduis";
            this.leftRaduis.Size = new System.Drawing.Size(76, 21);
            this.leftRaduis.TabIndex = 9;
            this.leftRaduis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftRaduis_KeyPress);
            // 
            // leftOriginY
            // 
            this.leftOriginY.Location = new System.Drawing.Point(56, 80);
            this.leftOriginY.Name = "leftOriginY";
            this.leftOriginY.Size = new System.Drawing.Size(76, 21);
            this.leftOriginY.TabIndex = 10;
            this.leftOriginY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftOriginY_KeyPress);
            // 
            // leftOriginX
            // 
            this.leftOriginX.Location = new System.Drawing.Point(56, 50);
            this.leftOriginX.Name = "leftOriginX";
            this.leftOriginX.Size = new System.Drawing.Size(76, 21);
            this.leftOriginX.TabIndex = 11;
            this.leftOriginX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.leftOriginX_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "半径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "原点Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "原点X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "左摇杆";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // JoystickSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leftRaduis);
            this.Controls.Add(this.leftOriginY);
            this.Controls.Add(this.leftOriginX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JoystickSettings";
            this.Text = "JoystickSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox leftRaduis;
        private System.Windows.Forms.TextBox leftOriginY;
        private System.Windows.Forms.TextBox leftOriginX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}