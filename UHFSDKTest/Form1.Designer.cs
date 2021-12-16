namespace UHFSDKTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectRs232 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btInventoryRealStart = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.bVersion = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.cbComPort = new System.Windows.Forms.ComboBox();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.lSerialPort = new System.Windows.Forms.Label();
            this.lBaudRate = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btInventoryRealStop = new System.Windows.Forms.Button();
            this.bBeepOn = new System.Windows.Forms.Button();
            this.bBeepOff = new System.Windows.Forms.Button();
            this.bPower = new System.Windows.Forms.Button();
            this.cbPower = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectRs232
            // 
            this.btnConnectRs232.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectRs232.Location = new System.Drawing.Point(228, 19);
            this.btnConnectRs232.Name = "btnConnectRs232";
            this.btnConnectRs232.Size = new System.Drawing.Size(90, 25);
            this.btnConnectRs232.TabIndex = 3;
            this.btnConnectRs232.Text = "Connect";
            this.btnConnectRs232.UseVisualStyleBackColor = true;
            this.btnConnectRs232.Click += new System.EventHandler(this.btnConnectRs232_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(228, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Disconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btInventoryRealStart
            // 
            this.btInventoryRealStart.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInventoryRealStart.Location = new System.Drawing.Point(32, 112);
            this.btInventoryRealStart.Name = "btInventoryRealStart";
            this.btInventoryRealStart.Size = new System.Drawing.Size(161, 25);
            this.btInventoryRealStart.TabIndex = 5;
            this.btInventoryRealStart.Text = "Inventory start";
            this.btInventoryRealStart.UseVisualStyleBackColor = true;
            this.btInventoryRealStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(77, 190);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 25);
            this.button4.TabIndex = 7;
            this.button4.Text = "Read Tag";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(228, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 25);
            this.button5.TabIndex = 8;
            this.button5.Text = "Get buffer tag count";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(228, 112);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 25);
            this.button6.TabIndex = 9;
            this.button6.Text = "Buffer inventory";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // bVersion
            // 
            this.bVersion.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bVersion.Location = new System.Drawing.Point(535, 19);
            this.bVersion.Name = "bVersion";
            this.bVersion.Size = new System.Drawing.Size(121, 25);
            this.bVersion.TabIndex = 11;
            this.bVersion.Text = "Reader Version";
            this.bVersion.UseVisualStyleBackColor = true;
            this.bVersion.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(441, 112);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(158, 25);
            this.button9.TabIndex = 12;
            this.button9.Text = "Test 6B inventory";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(441, 152);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(145, 25);
            this.button11.TabIndex = 14;
            this.button11.Text = "Test 6B read";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // cbComPort
            // 
            this.cbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComPort.FormattingEnabled = true;
            this.cbComPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16"});
            this.cbComPort.Location = new System.Drawing.Point(72, 23);
            this.cbComPort.Name = "cbComPort";
            this.cbComPort.Size = new System.Drawing.Size(121, 21);
            this.cbComPort.TabIndex = 20;
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Items.AddRange(new object[] {
            "38400",
            "115200",
            "921600"});
            this.cbBaudrate.Location = new System.Drawing.Point(72, 50);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudrate.TabIndex = 21;
            // 
            // lSerialPort
            // 
            this.lSerialPort.AutoSize = true;
            this.lSerialPort.Location = new System.Drawing.Point(8, 26);
            this.lSerialPort.Name = "lSerialPort";
            this.lSerialPort.Size = new System.Drawing.Size(58, 13);
            this.lSerialPort.TabIndex = 22;
            this.lSerialPort.Text = "Serial Port:";
            // 
            // lBaudRate
            // 
            this.lBaudRate.AutoSize = true;
            this.lBaudRate.Location = new System.Drawing.Point(8, 54);
            this.lBaudRate.Name = "lBaudRate";
            this.lBaudRate.Size = new System.Drawing.Size(53, 13);
            this.lBaudRate.TabIndex = 23;
            this.lBaudRate.Text = "Baudrate:";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(228, 190);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(191, 25);
            this.button13.TabIndex = 24;
            this.button13.Text = "Get Buffer inventory tag";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(535, 51);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 25);
            this.button7.TabIndex = 25;
            this.button7.Text = "Reset Reader";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btInventoryRealStop
            // 
            this.btInventoryRealStop.Enabled = false;
            this.btInventoryRealStop.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInventoryRealStop.Location = new System.Drawing.Point(32, 152);
            this.btInventoryRealStop.Name = "btInventoryRealStop";
            this.btInventoryRealStop.Size = new System.Drawing.Size(161, 25);
            this.btInventoryRealStop.TabIndex = 26;
            this.btInventoryRealStop.Text = "Inventory stop";
            this.btInventoryRealStop.UseVisualStyleBackColor = true;
            this.btInventoryRealStop.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // bBeepOn
            // 
            this.bBeepOn.Location = new System.Drawing.Point(344, 21);
            this.bBeepOn.Name = "bBeepOn";
            this.bBeepOn.Size = new System.Drawing.Size(75, 23);
            this.bBeepOn.TabIndex = 27;
            this.bBeepOn.Text = "BeepOn";
            this.bBeepOn.UseVisualStyleBackColor = true;
            this.bBeepOn.Click += new System.EventHandler(this.bBeepOn_Click);
            // 
            // bBeepOff
            // 
            this.bBeepOff.Location = new System.Drawing.Point(344, 50);
            this.bBeepOff.Name = "bBeepOff";
            this.bBeepOff.Size = new System.Drawing.Size(75, 23);
            this.bBeepOff.TabIndex = 28;
            this.bBeepOff.Text = "BeepOFF";
            this.bBeepOff.UseVisualStyleBackColor = true;
            this.bBeepOff.Click += new System.EventHandler(this.bBeepOff_Click);
            // 
            // bPower
            // 
            this.bPower.Location = new System.Drawing.Point(441, 21);
            this.bPower.Name = "bPower";
            this.bPower.Size = new System.Drawing.Size(75, 23);
            this.bPower.TabIndex = 29;
            this.bPower.Text = "Set Power";
            this.bPower.UseVisualStyleBackColor = true;
            this.bPower.Click += new System.EventHandler(this.bPower_Click);
            // 
            // cbPower
            // 
            this.cbPower.FormattingEnabled = true;
            this.cbPower.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbPower.Location = new System.Drawing.Point(441, 51);
            this.cbPower.Name = "cbPower";
            this.cbPower.Size = new System.Drawing.Size(75, 21);
            this.cbPower.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabTest);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(889, 511);
            this.tabControl1.TabIndex = 31;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.lSerialPort);
            this.tabConfig.Controls.Add(this.button11);
            this.tabConfig.Controls.Add(this.button7);
            this.tabConfig.Controls.Add(this.cbPower);
            this.tabConfig.Controls.Add(this.lBaudRate);
            this.tabConfig.Controls.Add(this.bPower);
            this.tabConfig.Controls.Add(this.cbComPort);
            this.tabConfig.Controls.Add(this.btInventoryRealStop);
            this.tabConfig.Controls.Add(this.button13);
            this.tabConfig.Controls.Add(this.button9);
            this.tabConfig.Controls.Add(this.bBeepOff);
            this.tabConfig.Controls.Add(this.button4);
            this.tabConfig.Controls.Add(this.button5);
            this.tabConfig.Controls.Add(this.cbBaudrate);
            this.tabConfig.Controls.Add(this.bBeepOn);
            this.tabConfig.Controls.Add(this.button6);
            this.tabConfig.Controls.Add(this.bVersion);
            this.tabConfig.Controls.Add(this.btInventoryRealStart);
            this.tabConfig.Controls.Add(this.btnConnectRs232);
            this.tabConfig.Controls.Add(this.button1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(881, 485);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "tabPage1";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // tabTest
            // 
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(344, 272);
            this.tabTest.TabIndex = 1;
            this.tabTest.Text = "tabPage2";
            this.tabTest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectRs232;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btInventoryRealStart;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button bVersion;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox cbComPort;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.Label lSerialPort;
        private System.Windows.Forms.Label lBaudRate;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btInventoryRealStop;
        private System.Windows.Forms.Button bBeepOn;
        private System.Windows.Forms.Button bBeepOff;
        private System.Windows.Forms.Button bPower;
        private System.Windows.Forms.ComboBox cbPower;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabTest;
    }
}

