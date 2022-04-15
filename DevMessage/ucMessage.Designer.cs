
namespace DevMessage
{
    partial class ucMessage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bShowMessage = new DevExpress.XtraEditors.SimpleButton();
            this.bShowMessage2 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bShowMessage
            // 
            this.bShowMessage.Location = new System.Drawing.Point(3, 3);
            this.bShowMessage.Name = "bShowMessage";
            this.bShowMessage.Size = new System.Drawing.Size(106, 23);
            this.bShowMessage.TabIndex = 0;
            this.bShowMessage.Text = "Show Message";
            this.bShowMessage.Click += new System.EventHandler(this.bShowMessage_Click);
            // 
            // bShowMessage2
            // 
            this.bShowMessage2.Location = new System.Drawing.Point(3, 32);
            this.bShowMessage2.Name = "bShowMessage2";
            this.bShowMessage2.Size = new System.Drawing.Size(106, 23);
            this.bShowMessage2.TabIndex = 1;
            this.bShowMessage2.Text = "Default Message";
            this.bShowMessage2.Click += new System.EventHandler(this.bShowMessage2_Click);
            // 
            // ucMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bShowMessage2);
            this.Controls.Add(this.bShowMessage);
            this.Name = "ucMessage";
            this.Size = new System.Drawing.Size(459, 327);
            this.Load += new System.EventHandler(this.ucMessage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bShowMessage;
        private DevExpress.XtraEditors.SimpleButton bShowMessage2;
    }
}
