
namespace DocumentManager
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
            this.bFormWinUI = new DevExpress.XtraEditors.SimpleButton();
            this.bTabbedView = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bWidgetDynamic = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bFormWinUI
            // 
            this.bFormWinUI.Location = new System.Drawing.Point(32, 41);
            this.bFormWinUI.Name = "bFormWinUI";
            this.bFormWinUI.Size = new System.Drawing.Size(75, 23);
            this.bFormWinUI.TabIndex = 0;
            this.bFormWinUI.Text = "Win UI View";
            this.bFormWinUI.Click += new System.EventHandler(this.bForm2_Click);
            // 
            // bTabbedView
            // 
            this.bTabbedView.Location = new System.Drawing.Point(32, 70);
            this.bTabbedView.Name = "bTabbedView";
            this.bTabbedView.Size = new System.Drawing.Size(124, 23);
            this.bTabbedView.TabIndex = 1;
            this.bTabbedView.Text = "Load Tabbed View";
            this.bTabbedView.Click += new System.EventHandler(this.bTabbedView_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(32, 99);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(124, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Widget View";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // bWidgetDynamic
            // 
            this.bWidgetDynamic.Location = new System.Drawing.Point(32, 128);
            this.bWidgetDynamic.Name = "bWidgetDynamic";
            this.bWidgetDynamic.Size = new System.Drawing.Size(124, 23);
            this.bWidgetDynamic.TabIndex = 3;
            this.bWidgetDynamic.Text = "Widget View Dynamic";
            this.bWidgetDynamic.Click += new System.EventHandler(this.bWidgetDynamic_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bWidgetDynamic);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.bTabbedView);
            this.Controls.Add(this.bFormWinUI);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document2;
        private DevExpress.XtraEditors.SimpleButton bFormWinUI;
        private DevExpress.XtraEditors.SimpleButton bTabbedView;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton bWidgetDynamic;
    }
}

