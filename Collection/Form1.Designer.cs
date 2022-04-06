
namespace Collection
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
            this.bConcurrentBag = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // bConcurrentBag
            // 
            this.bConcurrentBag.Location = new System.Drawing.Point(13, 13);
            this.bConcurrentBag.Name = "bConcurrentBag";
            this.bConcurrentBag.Size = new System.Drawing.Size(96, 23);
            this.bConcurrentBag.TabIndex = 0;
            this.bConcurrentBag.Text = "Concurrent Bag";
            this.bConcurrentBag.Click += new System.EventHandler(this.bConcurrentBag_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bConcurrentBag);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton bConcurrentBag;
    }
}

