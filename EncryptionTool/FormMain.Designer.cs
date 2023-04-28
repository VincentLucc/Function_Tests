namespace EncryptionTool
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.bSettings = new DevExpress.XtraEditors.SimpleButton();
            this.bCOnvert = new DevExpress.XtraEditors.SimpleButton();
            this.bLoadFile = new DevExpress.XtraEditors.SimpleButton();
            this.OutputMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.OutputLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.InputLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.InputMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EncryptionListLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bENcrypt = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutputMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionListLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bENcrypt);
            this.layoutControl1.Controls.Add(this.EncryptionListLookUpEdit);
            this.layoutControl1.Controls.Add(this.bSettings);
            this.layoutControl1.Controls.Add(this.bCOnvert);
            this.layoutControl1.Controls.Add(this.bLoadFile);
            this.layoutControl1.Controls.Add(this.OutputMemoEdit);
            this.layoutControl1.Controls.Add(this.OutputLookUpEdit);
            this.layoutControl1.Controls.Add(this.InputLookUpEdit);
            this.layoutControl1.Controls.Add(this.InputMemoEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(655, 457);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(180, 150);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(95, 22);
            this.bSettings.StyleController = this.layoutControl1;
            this.bSettings.TabIndex = 6;
            this.bSettings.Text = "Settings";
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bCOnvert
            // 
            this.bCOnvert.Location = new System.Drawing.Point(93, 150);
            this.bCOnvert.Name = "bCOnvert";
            this.bCOnvert.Size = new System.Drawing.Size(83, 22);
            this.bCOnvert.StyleController = this.layoutControl1;
            this.bCOnvert.TabIndex = 5;
            this.bCOnvert.Text = "Decrypt";
            this.bCOnvert.Click += new System.EventHandler(this.bCOnvert_Click);
            // 
            // bLoadFile
            // 
            this.bLoadFile.Location = new System.Drawing.Point(12, 176);
            this.bLoadFile.Name = "bLoadFile";
            this.bLoadFile.Size = new System.Drawing.Size(117, 22);
            this.bLoadFile.StyleController = this.layoutControl1;
            this.bLoadFile.TabIndex = 7;
            this.bLoadFile.Text = "Decrypt From File";
            this.bLoadFile.Click += new System.EventHandler(this.bLoadFile_Click);
            // 
            // OutputMemoEdit
            // 
            this.OutputMemoEdit.Location = new System.Drawing.Point(12, 226);
            this.OutputMemoEdit.Name = "OutputMemoEdit";
            this.OutputMemoEdit.Size = new System.Drawing.Size(631, 219);
            this.OutputMemoEdit.StyleController = this.layoutControl1;
            this.OutputMemoEdit.TabIndex = 5;
            // 
            // OutputLookUpEdit
            // 
            this.OutputLookUpEdit.Location = new System.Drawing.Point(512, 202);
            this.OutputLookUpEdit.Name = "OutputLookUpEdit";
            this.OutputLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.OutputLookUpEdit.Size = new System.Drawing.Size(131, 20);
            this.OutputLookUpEdit.StyleController = this.layoutControl1;
            this.OutputLookUpEdit.TabIndex = 4;
            // 
            // InputLookUpEdit
            // 
            this.InputLookUpEdit.Location = new System.Drawing.Point(512, 12);
            this.InputLookUpEdit.Name = "InputLookUpEdit";
            this.InputLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.InputLookUpEdit.Size = new System.Drawing.Size(131, 20);
            this.InputLookUpEdit.StyleController = this.layoutControl1;
            this.InputLookUpEdit.TabIndex = 4;
            // 
            // InputMemoEdit
            // 
            this.InputMemoEdit.Location = new System.Drawing.Point(12, 36);
            this.InputMemoEdit.Name = "InputMemoEdit";
            this.InputMemoEdit.Size = new System.Drawing.Size(631, 110);
            this.InputMemoEdit.StyleController = this.layoutControl1;
            this.InputMemoEdit.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem7,
            this.layoutControlItem3,
            this.layoutControlItem8,
            this.layoutControlItem4,
            this.layoutControlItem9,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(655, 457);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.InputMemoEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(635, 114);
            this.layoutControlItem1.Text = "Input:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.OutputMemoEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 214);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(635, 223);
            this.layoutControlItem2.Text = "Output:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.InputLookUpEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(423, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem5.Text = "Input Type:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(65, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(423, 24);
            this.emptySpaceItem3.Text = "Input：";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(65, 0);
            this.emptySpaceItem3.TextVisible = true;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.OutputLookUpEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(423, 190);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem6.Text = "Output Type:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(65, 13);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 190);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(423, 24);
            this.emptySpaceItem4.Text = "Output:";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(65, 0);
            this.emptySpaceItem4.TextVisible = true;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(267, 138);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(71, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.bCOnvert;
            this.layoutControlItem7.Location = new System.Drawing.Point(81, 138);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(87, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.bLoadFile;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(121, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.bSettings;
            this.layoutControlItem8.Location = new System.Drawing.Point(168, 138);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(99, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // EncryptionListLookUpEdit
            // 
            this.EncryptionListLookUpEdit.Location = new System.Drawing.Point(427, 150);
            this.EncryptionListLookUpEdit.Name = "EncryptionListLookUpEdit";
            this.EncryptionListLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EncryptionListLookUpEdit.Size = new System.Drawing.Size(216, 20);
            this.EncryptionListLookUpEdit.StyleController = this.layoutControl1;
            this.EncryptionListLookUpEdit.TabIndex = 8;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.EncryptionListLookUpEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(338, 138);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(297, 26);
            this.layoutControlItem3.Text = "Encryption:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(65, 13);
            // 
            // bENcrypt
            // 
            this.bENcrypt.Location = new System.Drawing.Point(12, 150);
            this.bENcrypt.Name = "bENcrypt";
            this.bENcrypt.Size = new System.Drawing.Size(77, 22);
            this.bENcrypt.StyleController = this.layoutControl1;
            this.bENcrypt.TabIndex = 9;
            this.bENcrypt.Text = "Encrypt";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bENcrypt;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(121, 164);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(514, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 457);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutputMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EncryptionListLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.MemoEdit OutputMemoEdit;
        private DevExpress.XtraEditors.MemoEdit InputMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit InputLookUpEdit;
        private DevExpress.XtraEditors.LookUpEdit OutputLookUpEdit;
        private DevExpress.XtraEditors.SimpleButton bCOnvert;
        private DevExpress.XtraEditors.SimpleButton bSettings;
        private DevExpress.XtraEditors.SimpleButton bLoadFile;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.LookUpEdit EncryptionListLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton bENcrypt;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}

