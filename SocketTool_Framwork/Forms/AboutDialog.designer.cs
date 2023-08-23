namespace SocketTool_Framework.Forms
{
    partial class AboutDialog
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
            this.CloseButton = new DevExpress.XtraEditors.SimpleButton();
            this.NameLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.CopyrightLabel = new DevExpress.XtraEditors.LabelControl();
            this.VersionLabel = new DevExpress.XtraEditors.LabelControl();
            this.EmailLabel = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(161, 152);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 31);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            // 
            // NameLabel
            // 
            this.NameLabel.Appearance.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Appearance.Options.UseFont = true;
            this.NameLabel.Location = new System.Drawing.Point(23, 12);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(91, 23);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Socket Tool";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(23, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Version:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(23, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Copyright:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(23, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "E-Mail:";
            this.labelControl5.Visible = false;
            // 
            // CopyrightLabel
            // 
            this.CopyrightLabel.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.CopyrightLabel.Appearance.Options.UseFont = true;
            this.CopyrightLabel.Location = new System.Drawing.Point(87, 60);
            this.CopyrightLabel.Name = "CopyrightLabel";
            this.CopyrightLabel.Size = new System.Drawing.Size(45, 13);
            this.CopyrightLabel.TabIndex = 8;
            this.CopyrightLabel.Text = "Copyright";
            // 
            // VersionLabel
            // 
            this.VersionLabel.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.VersionLabel.Appearance.Options.UseFont = true;
            this.VersionLabel.Location = new System.Drawing.Point(87, 41);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(36, 13);
            this.VersionLabel.TabIndex = 9;
            this.VersionLabel.Text = "Version";
            // 
            // EmailLabel
            // 
            this.EmailLabel.Appearance.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.EmailLabel.Appearance.Options.UseFont = true;
            this.EmailLabel.Location = new System.Drawing.Point(87, 79);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(26, 13);
            this.EmailLabel.TabIndex = 10;
            this.EmailLabel.Text = "Email";
            this.EmailLabel.Visible = false;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(281, 192);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.CopyrightLabel);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton CloseButton;
        private DevExpress.XtraEditors.LabelControl NameLabel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl CopyrightLabel;
        private DevExpress.XtraEditors.LabelControl VersionLabel;
        private DevExpress.XtraEditors.LabelControl EmailLabel;
    }
}