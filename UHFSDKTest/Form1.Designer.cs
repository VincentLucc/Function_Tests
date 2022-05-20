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
            this.bBeepOn = new System.Windows.Forms.Button();
            this.bBeepOff = new System.Windows.Forms.Button();
            this.bPower = new System.Windows.Forms.Button();
            this.cbPower = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bUnLock = new System.Windows.Forms.Button();
            this.bLockTag = new System.Windows.Forms.Button();
            this.bReadTID = new System.Windows.Forms.Button();
            this.bWriteOdoo = new System.Windows.Forms.Button();
            this.bWriteAccessCode = new System.Windows.Forms.Button();
            this.bReadOdooData = new System.Windows.Forms.Button();
            this.bReadAccess = new System.Windows.Forms.Button();
            this.bGetCurrentTag = new System.Windows.Forms.Button();
            this.bReadReserve = new System.Windows.Forms.Button();
            this.bWriteEPC = new System.Windows.Forms.Button();
            this.bWriteReserve = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bRead = new System.Windows.Forms.Button();
            this.bWriteUser = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.bSwetCurrentTag = new System.Windows.Forms.Button();
            this.bShowCurrentTags = new System.Windows.Forms.Button();
            this.bGetAndResetBuffer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRetry = new System.Windows.Forms.TextBox();
            this.bBufferReset = new System.Windows.Forms.Button();
            this.bPowerRead = new System.Windows.Forms.Button();
            this.tabTest = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.btInventoryRealStart.Text = "Inventory Tag";
            this.btInventoryRealStart.UseVisualStyleBackColor = true;
            this.btInventoryRealStart.Click += new System.EventHandler(this.btInventoryRealStart_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(77, 152);
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
            this.button5.Location = new System.Drawing.Point(228, 190);
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
            this.bVersion.Location = new System.Drawing.Point(539, 48);
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
            this.button9.Location = new System.Drawing.Point(35, 190);
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
            this.button11.Location = new System.Drawing.Point(48, 230);
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
            this.button13.Location = new System.Drawing.Point(228, 230);
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
            this.button7.Location = new System.Drawing.Point(666, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 25);
            this.button7.TabIndex = 25;
            this.button7.Text = "Reset Reader";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
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
            this.tabConfig.Controls.Add(this.groupBox1);
            this.tabConfig.Controls.Add(this.bGetAndResetBuffer);
            this.tabConfig.Controls.Add(this.label1);
            this.tabConfig.Controls.Add(this.tbRetry);
            this.tabConfig.Controls.Add(this.bBufferReset);
            this.tabConfig.Controls.Add(this.bPowerRead);
            this.tabConfig.Controls.Add(this.lSerialPort);
            this.tabConfig.Controls.Add(this.button11);
            this.tabConfig.Controls.Add(this.button7);
            this.tabConfig.Controls.Add(this.cbPower);
            this.tabConfig.Controls.Add(this.lBaudRate);
            this.tabConfig.Controls.Add(this.bPower);
            this.tabConfig.Controls.Add(this.cbComPort);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bUnLock);
            this.groupBox1.Controls.Add(this.bLockTag);
            this.groupBox1.Controls.Add(this.bReadTID);
            this.groupBox1.Controls.Add(this.bWriteOdoo);
            this.groupBox1.Controls.Add(this.bWriteAccessCode);
            this.groupBox1.Controls.Add(this.bReadOdooData);
            this.groupBox1.Controls.Add(this.bReadAccess);
            this.groupBox1.Controls.Add(this.bGetCurrentTag);
            this.groupBox1.Controls.Add(this.bReadReserve);
            this.groupBox1.Controls.Add(this.bWriteEPC);
            this.groupBox1.Controls.Add(this.bWriteReserve);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.bRead);
            this.groupBox1.Controls.Add(this.bWriteUser);
            this.groupBox1.Controls.Add(this.tbInput);
            this.groupBox1.Controls.Add(this.bSwetCurrentTag);
            this.groupBox1.Controls.Add(this.bShowCurrentTags);
            this.groupBox1.Location = new System.Drawing.Point(539, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 370);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // bUnLock
            // 
            this.bUnLock.Location = new System.Drawing.Point(139, 194);
            this.bUnLock.Name = "bUnLock";
            this.bUnLock.Size = new System.Drawing.Size(125, 23);
            this.bUnLock.TabIndex = 16;
            this.bUnLock.Text = "Unlock Tag";
            this.bUnLock.UseVisualStyleBackColor = true;
            this.bUnLock.Click += new System.EventHandler(this.bUnLock_Click);
            // 
            // bLockTag
            // 
            this.bLockTag.Location = new System.Drawing.Point(8, 194);
            this.bLockTag.Name = "bLockTag";
            this.bLockTag.Size = new System.Drawing.Size(125, 23);
            this.bLockTag.TabIndex = 15;
            this.bLockTag.Text = "Lock Tag";
            this.bLockTag.UseVisualStyleBackColor = true;
            this.bLockTag.Click += new System.EventHandler(this.bLockTag_Click);
            // 
            // bReadTID
            // 
            this.bReadTID.Location = new System.Drawing.Point(139, 225);
            this.bReadTID.Name = "bReadTID";
            this.bReadTID.Size = new System.Drawing.Size(125, 23);
            this.bReadTID.TabIndex = 14;
            this.bReadTID.Text = "Read TID";
            this.bReadTID.UseVisualStyleBackColor = true;
            this.bReadTID.Click += new System.EventHandler(this.bReadTID_Click);
            // 
            // bWriteOdoo
            // 
            this.bWriteOdoo.Location = new System.Drawing.Point(8, 165);
            this.bWriteOdoo.Name = "bWriteOdoo";
            this.bWriteOdoo.Size = new System.Drawing.Size(125, 23);
            this.bWriteOdoo.TabIndex = 13;
            this.bWriteOdoo.Text = "Write Odoo Data";
            this.bWriteOdoo.UseVisualStyleBackColor = true;
            this.bWriteOdoo.Click += new System.EventHandler(this.bWriteOdoo_Click);
            // 
            // bWriteAccessCode
            // 
            this.bWriteAccessCode.Location = new System.Drawing.Point(8, 136);
            this.bWriteAccessCode.Name = "bWriteAccessCode";
            this.bWriteAccessCode.Size = new System.Drawing.Size(125, 23);
            this.bWriteAccessCode.TabIndex = 12;
            this.bWriteAccessCode.Text = "Write Access Code";
            this.bWriteAccessCode.UseVisualStyleBackColor = true;
            this.bWriteAccessCode.Click += new System.EventHandler(this.bWriteAccessCode_Click);
            // 
            // bReadOdooData
            // 
            this.bReadOdooData.Location = new System.Drawing.Point(139, 165);
            this.bReadOdooData.Name = "bReadOdooData";
            this.bReadOdooData.Size = new System.Drawing.Size(125, 23);
            this.bReadOdooData.TabIndex = 11;
            this.bReadOdooData.Text = "Read Odoo Data";
            this.bReadOdooData.UseVisualStyleBackColor = true;
            this.bReadOdooData.Click += new System.EventHandler(this.bReadOdooData_Click);
            // 
            // bReadAccess
            // 
            this.bReadAccess.Location = new System.Drawing.Point(139, 136);
            this.bReadAccess.Name = "bReadAccess";
            this.bReadAccess.Size = new System.Drawing.Size(125, 23);
            this.bReadAccess.TabIndex = 10;
            this.bReadAccess.Text = "Read Access Code";
            this.bReadAccess.UseVisualStyleBackColor = true;
            this.bReadAccess.Click += new System.EventHandler(this.bReadAccess_Click);
            // 
            // bGetCurrentTag
            // 
            this.bGetCurrentTag.Location = new System.Drawing.Point(139, 19);
            this.bGetCurrentTag.Name = "bGetCurrentTag";
            this.bGetCurrentTag.Size = new System.Drawing.Size(125, 23);
            this.bGetCurrentTag.TabIndex = 9;
            this.bGetCurrentTag.Text = "Get Current Tag";
            this.bGetCurrentTag.UseVisualStyleBackColor = true;
            this.bGetCurrentTag.Click += new System.EventHandler(this.bGetCurrentTag_Click);
            // 
            // bReadReserve
            // 
            this.bReadReserve.Location = new System.Drawing.Point(139, 107);
            this.bReadReserve.Name = "bReadReserve";
            this.bReadReserve.Size = new System.Drawing.Size(125, 23);
            this.bReadReserve.TabIndex = 8;
            this.bReadReserve.Text = "Read Reserve";
            this.bReadReserve.UseVisualStyleBackColor = true;
            this.bReadReserve.Click += new System.EventHandler(this.bReadReserve_Click);
            // 
            // bWriteEPC
            // 
            this.bWriteEPC.Location = new System.Drawing.Point(6, 49);
            this.bWriteEPC.Name = "bWriteEPC";
            this.bWriteEPC.Size = new System.Drawing.Size(125, 23);
            this.bWriteEPC.TabIndex = 7;
            this.bWriteEPC.Text = "Write EPC Data";
            this.bWriteEPC.UseVisualStyleBackColor = true;
            this.bWriteEPC.Click += new System.EventHandler(this.bWriteEPC_Click);
            // 
            // bWriteReserve
            // 
            this.bWriteReserve.Location = new System.Drawing.Point(8, 107);
            this.bWriteReserve.Name = "bWriteReserve";
            this.bWriteReserve.Size = new System.Drawing.Size(125, 23);
            this.bWriteReserve.TabIndex = 6;
            this.bWriteReserve.Text = "Write Reserve";
            this.bWriteReserve.UseVisualStyleBackColor = true;
            this.bWriteReserve.Click += new System.EventHandler(this.bPassWrite_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Read Tag EPC";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bRead
            // 
            this.bRead.Location = new System.Drawing.Point(139, 80);
            this.bRead.Name = "bRead";
            this.bRead.Size = new System.Drawing.Size(125, 23);
            this.bRead.TabIndex = 4;
            this.bRead.Text = "Read User Data";
            this.bRead.UseVisualStyleBackColor = true;
            this.bRead.Click += new System.EventHandler(this.bRead_Click);
            // 
            // bWriteUser
            // 
            this.bWriteUser.Location = new System.Drawing.Point(8, 80);
            this.bWriteUser.Name = "bWriteUser";
            this.bWriteUser.Size = new System.Drawing.Size(125, 23);
            this.bWriteUser.TabIndex = 3;
            this.bWriteUser.Text = "Write User Data";
            this.bWriteUser.UseVisualStyleBackColor = true;
            this.bWriteUser.Click += new System.EventHandler(this.bWriteUser_Click);
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbInput.Location = new System.Drawing.Point(3, 269);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(319, 98);
            this.tbInput.TabIndex = 2;
            // 
            // bSwetCurrentTag
            // 
            this.bSwetCurrentTag.Location = new System.Drawing.Point(8, 19);
            this.bSwetCurrentTag.Name = "bSwetCurrentTag";
            this.bSwetCurrentTag.Size = new System.Drawing.Size(125, 23);
            this.bSwetCurrentTag.TabIndex = 1;
            this.bSwetCurrentTag.Text = "Set Current Tag";
            this.bSwetCurrentTag.UseVisualStyleBackColor = true;
            this.bSwetCurrentTag.Click += new System.EventHandler(this.bSwetCurrentTag_Click);
            // 
            // bShowCurrentTags
            // 
            this.bShowCurrentTags.Location = new System.Drawing.Point(8, 225);
            this.bShowCurrentTags.Name = "bShowCurrentTags";
            this.bShowCurrentTags.Size = new System.Drawing.Size(125, 23);
            this.bShowCurrentTags.TabIndex = 0;
            this.bShowCurrentTags.Text = "Show Tag List";
            this.bShowCurrentTags.UseVisualStyleBackColor = true;
            this.bShowCurrentTags.Click += new System.EventHandler(this.bShowCurrentTags_Click);
            // 
            // bGetAndResetBuffer
            // 
            this.bGetAndResetBuffer.Location = new System.Drawing.Point(228, 274);
            this.bGetAndResetBuffer.Name = "bGetAndResetBuffer";
            this.bGetAndResetBuffer.Size = new System.Drawing.Size(166, 23);
            this.bGetAndResetBuffer.TabIndex = 36;
            this.bGetAndResetBuffer.Text = "Get and Reset Inventory Buffer";
            this.bGetAndResetBuffer.UseVisualStyleBackColor = true;
            this.bGetAndResetBuffer.Click += new System.EventHandler(this.bGetAndResetBuffer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Re-try";
            // 
            // tbRetry
            // 
            this.tbRetry.Location = new System.Drawing.Point(413, 116);
            this.tbRetry.Name = "tbRetry";
            this.tbRetry.Size = new System.Drawing.Size(100, 20);
            this.tbRetry.TabIndex = 34;
            this.tbRetry.Text = "9";
            // 
            // bBufferReset
            // 
            this.bBufferReset.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBufferReset.Location = new System.Drawing.Point(228, 152);
            this.bBufferReset.Name = "bBufferReset";
            this.bBufferReset.Size = new System.Drawing.Size(166, 25);
            this.bBufferReset.TabIndex = 32;
            this.bBufferReset.Text = "Buffer Reset";
            this.bBufferReset.UseVisualStyleBackColor = true;
            this.bBufferReset.Click += new System.EventHandler(this.bBufferReset_Click);
            // 
            // bPowerRead
            // 
            this.bPowerRead.Location = new System.Drawing.Point(539, 21);
            this.bPowerRead.Name = "bPowerRead";
            this.bPowerRead.Size = new System.Drawing.Size(75, 23);
            this.bPowerRead.TabIndex = 31;
            this.bPowerRead.Text = "Get Power";
            this.bPowerRead.UseVisualStyleBackColor = true;
            this.bPowerRead.Click += new System.EventHandler(this.bPowerRead_Click);
            // 
            // tabTest
            // 
            this.tabTest.Location = new System.Drawing.Point(4, 22);
            this.tabTest.Name = "tabTest";
            this.tabTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabTest.Size = new System.Drawing.Size(881, 485);
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
            this.Text = "SDK Tests 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button bBeepOn;
        private System.Windows.Forms.Button bBeepOff;
        private System.Windows.Forms.Button bPower;
        private System.Windows.Forms.ComboBox cbPower;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabTest;
        private System.Windows.Forms.Button bPowerRead;
        private System.Windows.Forms.Button bBufferReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRetry;
        private System.Windows.Forms.Button bGetAndResetBuffer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bShowCurrentTags;
        private System.Windows.Forms.Button bSwetCurrentTag;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button bWriteUser;
        private System.Windows.Forms.Button bRead;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button bWriteReserve;
        private System.Windows.Forms.Button bWriteEPC;
        private System.Windows.Forms.Button bReadReserve;
        private System.Windows.Forms.Button bGetCurrentTag;
        private System.Windows.Forms.Button bReadAccess;
        private System.Windows.Forms.Button bReadOdooData;
        private System.Windows.Forms.Button bWriteAccessCode;
        private System.Windows.Forms.Button bWriteOdoo;
        private System.Windows.Forms.Button bReadTID;
        private System.Windows.Forms.Button bLockTag;
        private System.Windows.Forms.Button bUnLock;
    }
}

