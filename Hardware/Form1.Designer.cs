
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 25);
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
            this.cbMac.Location = new System.Drawing.Point(130, 25);
            this.cbMac.Name = "cbMac";
            this.cbMac.Size = new System.Drawing.Size(186, 21);
            this.cbMac.TabIndex = 1;
            // 
            // bAssemblyInfo
            // 
            this.bAssemblyInfo.Location = new System.Drawing.Point(28, 77);
            this.bAssemblyInfo.Name = "bAssemblyInfo";
            this.bAssemblyInfo.Size = new System.Drawing.Size(75, 23);
            this.bAssemblyInfo.TabIndex = 2;
            this.bAssemblyInfo.Text = "Assembly Info";
            this.bAssemblyInfo.Click += new System.EventHandler(this.AssemblyInfo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bAssemblyInfo);
            this.Controls.Add(this.cbMac);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbMac;
        private DevExpress.XtraEditors.SimpleButton bAssemblyInfo;
    }
}

