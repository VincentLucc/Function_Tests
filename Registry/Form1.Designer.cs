
namespace RegistryTests
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
            this.bCheck = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.bHold = new System.Windows.Forms.Button();
            this.bThread = new System.Windows.Forms.Button();
            this.bRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bCheck
            // 
            this.bCheck.Location = new System.Drawing.Point(29, 72);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(112, 23);
            this.bCheck.TabIndex = 0;
            this.bCheck.Text = "Check Existance";
            this.bCheck.UseVisualStyleBackColor = true;
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(29, 43);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(75, 23);
            this.bCreate.TabIndex = 1;
            this.bCreate.Text = "Create";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // bHold
            // 
            this.bHold.Location = new System.Drawing.Point(29, 101);
            this.bHold.Name = "bHold";
            this.bHold.Size = new System.Drawing.Size(112, 23);
            this.bHold.TabIndex = 2;
            this.bHold.Text = "Hold Key";
            this.bHold.UseVisualStyleBackColor = true;
            this.bHold.Click += new System.EventHandler(this.bHold_Click);
            // 
            // bThread
            // 
            this.bThread.Location = new System.Drawing.Point(29, 130);
            this.bThread.Name = "bThread";
            this.bThread.Size = new System.Drawing.Size(112, 23);
            this.bThread.TabIndex = 3;
            this.bThread.Text = "Thread";
            this.bThread.UseVisualStyleBackColor = true;
            this.bThread.Click += new System.EventHandler(this.bThread_Click);
            // 
            // bRead
            // 
            this.bRead.Location = new System.Drawing.Point(147, 72);
            this.bRead.Name = "bRead";
            this.bRead.Size = new System.Drawing.Size(112, 23);
            this.bRead.TabIndex = 4;
            this.bRead.Text = "Read";
            this.bRead.UseVisualStyleBackColor = true;
            this.bRead.Click += new System.EventHandler(this.bRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bRead);
            this.Controls.Add(this.bThread);
            this.Controls.Add(this.bHold);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bCheck);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bCheck;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bHold;
        private System.Windows.Forms.Button bThread;
        private System.Windows.Forms.Button bRead;
    }
}

