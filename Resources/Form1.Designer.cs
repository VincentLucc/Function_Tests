
namespace Resources
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bResString = new DevExpress.XtraEditors.SimpleButton();
            this.bCommentRead = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(22, 23);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 30);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Image resource";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // bResString
            // 
            this.bResString.Location = new System.Drawing.Point(22, 71);
            this.bResString.Name = "bResString";
            this.bResString.Size = new System.Drawing.Size(176, 23);
            this.bResString.TabIndex = 1;
            this.bResString.Text = "String Resource: Read Key Value";
            this.bResString.Click += new System.EventHandler(this.bResString_Click);
            // 
            // bCommentRead
            // 
            this.bCommentRead.Location = new System.Drawing.Point(22, 100);
            this.bCommentRead.Name = "bCommentRead";
            this.bCommentRead.Size = new System.Drawing.Size(176, 23);
            this.bCommentRead.TabIndex = 2;
            this.bCommentRead.Text = "String Resource: Read COmments";
            this.bCommentRead.Click += new System.EventHandler(this.bCommentRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bCommentRead);
            this.Controls.Add(this.bResString);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton bResString;
        private DevExpress.XtraEditors.SimpleButton bCommentRead;
    }
}

