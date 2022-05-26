
namespace FileEditing
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
            this.bHold = new System.Windows.Forms.Button();
            this.bWriteHoldFile = new System.Windows.Forms.Button();
            this.bCLoseHold = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bHold
            // 
            this.bHold.Location = new System.Drawing.Point(37, 13);
            this.bHold.Name = "bHold";
            this.bHold.Size = new System.Drawing.Size(75, 23);
            this.bHold.TabIndex = 0;
            this.bHold.Text = "Hold File";
            this.bHold.UseVisualStyleBackColor = true;
            this.bHold.Click += new System.EventHandler(this.bHold_Click);
            // 
            // bWriteHoldFile
            // 
            this.bWriteHoldFile.Location = new System.Drawing.Point(140, 13);
            this.bWriteHoldFile.Name = "bWriteHoldFile";
            this.bWriteHoldFile.Size = new System.Drawing.Size(75, 23);
            this.bWriteHoldFile.TabIndex = 1;
            this.bWriteHoldFile.Text = "Write Hold";
            this.bWriteHoldFile.UseVisualStyleBackColor = true;
            this.bWriteHoldFile.Click += new System.EventHandler(this.bWriteHoldFile_Click);
            // 
            // bCLoseHold
            // 
            this.bCLoseHold.Location = new System.Drawing.Point(246, 13);
            this.bCLoseHold.Name = "bCLoseHold";
            this.bCLoseHold.Size = new System.Drawing.Size(75, 23);
            this.bCLoseHold.TabIndex = 2;
            this.bCLoseHold.Text = "CloseHold";
            this.bCLoseHold.UseVisualStyleBackColor = true;
            this.bCLoseHold.Click += new System.EventHandler(this.bCLoseHold_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 300);
            this.Controls.Add(this.bCLoseHold);
            this.Controls.Add(this.bWriteHoldFile);
            this.Controls.Add(this.bHold);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bHold;
        private System.Windows.Forms.Button bWriteHoldFile;
        private System.Windows.Forms.Button bCLoseHold;
    }
}

