
namespace WaitForm
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
            this.bLoading = new DevExpress.XtraEditors.SimpleButton();
            this.bSplash = new DevExpress.XtraEditors.SimpleButton();
            this.bOverLap = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bLoading
            // 
            this.bLoading.Location = new System.Drawing.Point(82, 38);
            this.bLoading.Name = "bLoading";
            this.bLoading.Size = new System.Drawing.Size(75, 23);
            this.bLoading.TabIndex = 0;
            this.bLoading.Text = "Show Loading";
            this.bLoading.Click += new System.EventHandler(this.bLoading_Click);
            // 
            // bSplash
            // 
            this.bSplash.Location = new System.Drawing.Point(193, 38);
            this.bSplash.Name = "bSplash";
            this.bSplash.Size = new System.Drawing.Size(75, 23);
            this.bSplash.TabIndex = 1;
            this.bSplash.Text = "Show Splash";
            this.bSplash.Click += new System.EventHandler(this.bSplash_Click);
            // 
            // bOverLap
            // 
            this.bOverLap.Location = new System.Drawing.Point(82, 67);
            this.bOverLap.Name = "bOverLap";
            this.bOverLap.Size = new System.Drawing.Size(96, 23);
            this.bOverLap.TabIndex = 2;
            this.bOverLap.Text = "Show OverLap";
            this.bOverLap.Click += new System.EventHandler(this.bOverLap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bOverLap);
            this.Controls.Add(this.bSplash);
            this.Controls.Add(this.bLoading);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bLoading;
        private DevExpress.XtraEditors.SimpleButton bSplash;
        private DevExpress.XtraEditors.SimpleButton bOverLap;
    }
}

