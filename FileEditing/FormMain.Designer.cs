
namespace FileEditing
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
            this.bHold = new System.Windows.Forms.Button();
            this.bWriteHoldFile = new System.Windows.Forms.Button();
            this.bCLoseHold = new System.Windows.Forms.Button();
            this.bFileInfo = new System.Windows.Forms.Button();
            this.bFolderPermission = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bHold
            // 
            this.bHold.Location = new System.Drawing.Point(6, 48);
            this.bHold.Name = "bHold";
            this.bHold.Size = new System.Drawing.Size(75, 23);
            this.bHold.TabIndex = 0;
            this.bHold.Text = "Hold File";
            this.bHold.UseVisualStyleBackColor = true;
            this.bHold.Click += new System.EventHandler(this.bHold_Click);
            // 
            // bWriteHoldFile
            // 
            this.bWriteHoldFile.Location = new System.Drawing.Point(6, 82);
            this.bWriteHoldFile.Name = "bWriteHoldFile";
            this.bWriteHoldFile.Size = new System.Drawing.Size(75, 23);
            this.bWriteHoldFile.TabIndex = 1;
            this.bWriteHoldFile.Text = "Write Hold";
            this.bWriteHoldFile.UseVisualStyleBackColor = true;
            this.bWriteHoldFile.Click += new System.EventHandler(this.bWriteHoldFile_Click);
            // 
            // bCLoseHold
            // 
            this.bCLoseHold.Location = new System.Drawing.Point(6, 111);
            this.bCLoseHold.Name = "bCLoseHold";
            this.bCLoseHold.Size = new System.Drawing.Size(75, 23);
            this.bCLoseHold.TabIndex = 2;
            this.bCLoseHold.Text = "CloseHold";
            this.bCLoseHold.UseVisualStyleBackColor = true;
            this.bCLoseHold.Click += new System.EventHandler(this.bCLoseHold_Click);
            // 
            // bFileInfo
            // 
            this.bFileInfo.Location = new System.Drawing.Point(6, 19);
            this.bFileInfo.Name = "bFileInfo";
            this.bFileInfo.Size = new System.Drawing.Size(75, 23);
            this.bFileInfo.TabIndex = 3;
            this.bFileInfo.Text = "FileInfo";
            this.bFileInfo.UseVisualStyleBackColor = true;
            this.bFileInfo.Click += new System.EventHandler(this.bFileInfo_Click);
            // 
            // bFolderPermission
            // 
            this.bFolderPermission.Location = new System.Drawing.Point(6, 19);
            this.bFolderPermission.Name = "bFolderPermission";
            this.bFolderPermission.Size = new System.Drawing.Size(112, 23);
            this.bFolderPermission.TabIndex = 4;
            this.bFolderPermission.Text = "Folder Permission";
            this.bFolderPermission.UseVisualStyleBackColor = true;
            this.bFolderPermission.Click += new System.EventHandler(this.bFolderPermission_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bHold);
            this.groupBox1.Controls.Add(this.bFileInfo);
            this.groupBox1.Controls.Add(this.bCLoseHold);
            this.groupBox1.Controls.Add(this.bWriteHoldFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 198);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Operation";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bFolderPermission);
            this.groupBox2.Location = new System.Drawing.Point(218, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 193);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folder Operation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 300);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bHold;
        private System.Windows.Forms.Button bWriteHoldFile;
        private System.Windows.Forms.Button bCLoseHold;
        private System.Windows.Forms.Button bFileInfo;
        private System.Windows.Forms.Button bFolderPermission;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

