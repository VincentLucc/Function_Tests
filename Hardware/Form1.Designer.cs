
namespace Hardware
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
            this.cbMac = new System.Windows.Forms.ComboBox();
            this.bAssemblyInfo = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bMotherBoard = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Mac";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbMac
            // 
            this.cbMac.FormattingEnabled = true;
            this.cbMac.Location = new System.Drawing.Point(8, 48);
            this.cbMac.Name = "cbMac";
            this.cbMac.Size = new System.Drawing.Size(137, 21);
            this.cbMac.TabIndex = 1;
            // 
            // bAssemblyInfo
            // 
            this.bAssemblyInfo.Location = new System.Drawing.Point(190, 22);
            this.bAssemblyInfo.Name = "bAssemblyInfo";
            this.bAssemblyInfo.Size = new System.Drawing.Size(75, 23);
            this.bAssemblyInfo.TabIndex = 2;
            this.bAssemblyInfo.Text = "Assembly Info";
            this.bAssemblyInfo.Click += new System.EventHandler(this.AssemblyInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbMac);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mac";
            // 
            // bMotherBoard
            // 
            this.bMotherBoard.Location = new System.Drawing.Point(12, 137);
            this.bMotherBoard.Name = "bMotherBoard";
            this.bMotherBoard.Size = new System.Drawing.Size(118, 23);
            this.bMotherBoard.TabIndex = 4;
            this.bMotherBoard.Text = "Mother Board";
            this.bMotherBoard.UseVisualStyleBackColor = true;
            this.bMotherBoard.Click += new System.EventHandler(this.bMotherBoard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bMotherBoard);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bAssemblyInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbMac;
        private DevExpress.XtraEditors.SimpleButton bAssemblyInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bMotherBoard;
    }
}

