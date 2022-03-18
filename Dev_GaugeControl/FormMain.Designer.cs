
namespace Dev_GaugeControl
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
            this.bShowGauge = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bShowGauge
            // 
            this.bShowGauge.Location = new System.Drawing.Point(48, 43);
            this.bShowGauge.Name = "bShowGauge";
            this.bShowGauge.Size = new System.Drawing.Size(75, 23);
            this.bShowGauge.TabIndex = 0;
            this.bShowGauge.Text = "Show Gauge";
            this.bShowGauge.Click += new System.EventHandler(this.bShowGauge_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bShowGauge);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bShowGauge;
    }
}

