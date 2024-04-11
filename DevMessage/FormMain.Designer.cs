
namespace DevMessage
{
    partial class FormMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.bShowInfo1 = new DevExpress.XtraEditors.SimpleButton();
            this.bShowInfo2 = new DevExpress.XtraEditors.SimpleButton();
            this.bShowInfoDefault = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bSplashCustom = new System.Windows.Forms.Button();
            this.bSplashDefault = new System.Windows.Forms.Button();
            this.bSHowOverLay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bWaitWIthBlock = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.ucMessage1 = new DevMessage.ucMessage();
            this.UpdateBlockedWaitingButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Loading (Disable current window)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bShowInfo1
            // 
            this.bShowInfo1.Location = new System.Drawing.Point(6, 20);
            this.bShowInfo1.Name = "bShowInfo1";
            this.bShowInfo1.Size = new System.Drawing.Size(85, 23);
            this.bShowInfo1.TabIndex = 1;
            this.bShowInfo1.Text = "Show Info 1";
            this.bShowInfo1.Click += new System.EventHandler(this.bShowInfo1_Click);
            // 
            // bShowInfo2
            // 
            this.bShowInfo2.Location = new System.Drawing.Point(6, 49);
            this.bShowInfo2.Name = "bShowInfo2";
            this.bShowInfo2.Size = new System.Drawing.Size(85, 23);
            this.bShowInfo2.TabIndex = 2;
            this.bShowInfo2.Text = "Show Info 2";
            this.bShowInfo2.Click += new System.EventHandler(this.bShowInfo2_Click);
            // 
            // bShowInfoDefault
            // 
            this.bShowInfoDefault.Location = new System.Drawing.Point(6, 20);
            this.bShowInfoDefault.Name = "bShowInfoDefault";
            this.bShowInfoDefault.Size = new System.Drawing.Size(115, 23);
            this.bShowInfoDefault.TabIndex = 3;
            this.bShowInfoDefault.Text = "Show Info Default";
            this.bShowInfoDefault.Click += new System.EventHandler(this.bShowInfoDefault_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox3);
            this.xtraTabPage1.Controls.Add(this.groupBox2);
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(798, 427);
            this.xtraTabPage1.Text = "General";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bShowInfoDefault);
            this.groupBox3.Location = new System.Drawing.Point(11, 227);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 188);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MessageBox";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bSplashCustom);
            this.groupBox2.Controls.Add(this.bSplashDefault);
            this.groupBox2.Controls.Add(this.bSHowOverLay);
            this.groupBox2.Controls.Add(this.bShowInfo1);
            this.groupBox2.Controls.Add(this.bShowInfo2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(11, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 218);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UI Helper";
            // 
            // bSplashCustom
            // 
            this.bSplashCustom.Location = new System.Drawing.Point(6, 165);
            this.bSplashCustom.Name = "bSplashCustom";
            this.bSplashCustom.Size = new System.Drawing.Size(133, 23);
            this.bSplashCustom.TabIndex = 5;
            this.bSplashCustom.Text = "Show Splash (Custom)";
            this.bSplashCustom.UseVisualStyleBackColor = true;
            this.bSplashCustom.Click += new System.EventHandler(this.bSplashCustom_Click);
            // 
            // bSplashDefault
            // 
            this.bSplashDefault.Location = new System.Drawing.Point(6, 136);
            this.bSplashDefault.Name = "bSplashDefault";
            this.bSplashDefault.Size = new System.Drawing.Size(133, 23);
            this.bSplashDefault.TabIndex = 4;
            this.bSplashDefault.Text = "Show Splash (Default)";
            this.bSplashDefault.UseVisualStyleBackColor = true;
            this.bSplashDefault.Click += new System.EventHandler(this.bSplashDefault_Click);
            // 
            // bSHowOverLay
            // 
            this.bSHowOverLay.Location = new System.Drawing.Point(6, 107);
            this.bSHowOverLay.Name = "bSHowOverLay";
            this.bSHowOverLay.Size = new System.Drawing.Size(85, 23);
            this.bSHowOverLay.TabIndex = 3;
            this.bSHowOverLay.Text = "Show OverLay";
            this.bSHowOverLay.UseVisualStyleBackColor = true;
            this.bSHowOverLay.Click += new System.EventHandler(this.bSHowOverLay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateBlockedWaitingButton);
            this.groupBox1.Controls.Add(this.bWaitWIthBlock);
            this.groupBox1.Controls.Add(this.simpleButton2);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Location = new System.Drawing.Point(323, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 218);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "csDevMessage";
            // 
            // bWaitWIthBlock
            // 
            this.bWaitWIthBlock.Location = new System.Drawing.Point(6, 78);
            this.bWaitWIthBlock.Name = "bWaitWIthBlock";
            this.bWaitWIthBlock.Size = new System.Drawing.Size(130, 23);
            this.bWaitWIthBlock.TabIndex = 6;
            this.bWaitWIthBlock.Text = "Show Blocked Waiting";
            this.bWaitWIthBlock.Click += new System.EventHandler(this.bWaitWIthBlock_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(6, 49);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(130, 23);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Task.MessageBoxCheck";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(6, 20);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(130, 23);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Show Loading Intance";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.ucMessage1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(798, 427);
            this.xtraTabPage2.Text = "User Panel";
            // 
            // ucMessage1
            // 
            this.ucMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMessage1.Location = new System.Drawing.Point(0, 0);
            this.ucMessage1.Name = "ucMessage1";
            this.ucMessage1.Size = new System.Drawing.Size(798, 427);
            this.ucMessage1.TabIndex = 0;
            this.ucMessage1.Load += new System.EventHandler(this.ucMessage1_Load);
            // 
            // UpdateBlockedWaitingButton
            // 
            this.UpdateBlockedWaitingButton.Location = new System.Drawing.Point(6, 107);
            this.UpdateBlockedWaitingButton.Name = "UpdateBlockedWaitingButton";
            this.UpdateBlockedWaitingButton.Size = new System.Drawing.Size(130, 23);
            this.UpdateBlockedWaitingButton.TabIndex = 7;
            this.UpdateBlockedWaitingButton.Text = "Update Blocked Waiting";
            this.UpdateBlockedWaitingButton.Click += new System.EventHandler(this.UpdateBlockedWaitingButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.SimpleButton bShowInfo1;
        private DevExpress.XtraEditors.SimpleButton bShowInfo2;
        private DevExpress.XtraEditors.SimpleButton bShowInfoDefault;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private ucMessage ucMessage1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Button bSHowOverLay;
        private System.Windows.Forms.Button bSplashDefault;
        private System.Windows.Forms.Button bSplashCustom;
        private DevExpress.XtraEditors.SimpleButton bWaitWIthBlock;
        private DevExpress.XtraEditors.SimpleButton UpdateBlockedWaitingButton;
    }
}

