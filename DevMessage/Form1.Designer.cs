
namespace DevMessage
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
            this.button1 = new System.Windows.Forms.Button();
            this.bShowInfo1 = new DevExpress.XtraEditors.SimpleButton();
            this.bShowInfo2 = new DevExpress.XtraEditors.SimpleButton();
            this.bShowInfoDefault = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.ucMessage1 = new DevMessage.ucMessage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Loading";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bShowInfo1
            // 
            this.bShowInfo1.Location = new System.Drawing.Point(20, 55);
            this.bShowInfo1.Name = "bShowInfo1";
            this.bShowInfo1.Size = new System.Drawing.Size(75, 23);
            this.bShowInfo1.TabIndex = 1;
            this.bShowInfo1.Text = "Show Info 1";
            this.bShowInfo1.Click += new System.EventHandler(this.bShowInfo1_Click);
            // 
            // bShowInfo2
            // 
            this.bShowInfo2.Location = new System.Drawing.Point(101, 55);
            this.bShowInfo2.Name = "bShowInfo2";
            this.bShowInfo2.Size = new System.Drawing.Size(75, 23);
            this.bShowInfo2.TabIndex = 2;
            this.bShowInfo2.Text = "Show Info 2";
            this.bShowInfo2.Click += new System.EventHandler(this.bShowInfo2_Click);
            // 
            // bShowInfoDefault
            // 
            this.bShowInfoDefault.Location = new System.Drawing.Point(182, 55);
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
            this.xtraTabPage1.Controls.Add(this.button1);
            this.xtraTabPage1.Controls.Add(this.bShowInfoDefault);
            this.xtraTabPage1.Controls.Add(this.bShowInfo1);
            this.xtraTabPage1.Controls.Add(this.bShowInfo2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(794, 422);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.ucMessage1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(794, 422);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // ucMessage1
            // 
            this.ucMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMessage1.Location = new System.Drawing.Point(0, 0);
            this.ucMessage1.Name = "ucMessage1";
            this.ucMessage1.Size = new System.Drawing.Size(794, 422);
            this.ucMessage1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
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
    }
}

