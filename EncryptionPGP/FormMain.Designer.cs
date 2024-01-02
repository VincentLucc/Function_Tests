namespace EncryptionPGP
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.DecryptionTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.FilePathButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.PasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CheckButton = new DevExpress.XtraEditors.SimpleButton();
            this.PrivateKeyButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.PublickKeyButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.EncryptionTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.KeysButtonEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.CreateKeyButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.createFileButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.DecryptionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePathButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrivateKeyButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublickKeyButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.EncryptionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeysButtonEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.DecryptionTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(612, 404);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.DecryptionTabPage,
            this.EncryptionTabPage});
            // 
            // DecryptionTabPage
            // 
            this.DecryptionTabPage.Controls.Add(this.layoutControl1);
            this.DecryptionTabPage.Name = "DecryptionTabPage";
            this.DecryptionTabPage.Size = new System.Drawing.Size(610, 373);
            this.DecryptionTabPage.Text = "Decryption File";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.memoEdit1);
            this.layoutControl1.Controls.Add(this.FilePathButtonEdit);
            this.layoutControl1.Controls.Add(this.PasswordTextEdit);
            this.layoutControl1.Controls.Add(this.CheckButton);
            this.layoutControl1.Controls.Add(this.PrivateKeyButtonEdit);
            this.layoutControl1.Controls.Add(this.PublickKeyButtonEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(610, 373);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(16, 171);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(578, 152);
            this.memoEdit1.StyleController = this.layoutControl1;
            this.memoEdit1.TabIndex = 9;
            // 
            // FilePathButtonEdit
            // 
            this.FilePathButtonEdit.Location = new System.Drawing.Point(116, 118);
            this.FilePathButtonEdit.Name = "FilePathButtonEdit";
            this.FilePathButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FilePathButtonEdit.Size = new System.Drawing.Size(478, 28);
            this.FilePathButtonEdit.StyleController = this.layoutControl1;
            this.FilePathButtonEdit.TabIndex = 8;
            this.FilePathButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.FilePathButtonEdit_ButtonClick);
            this.FilePathButtonEdit.EditValueChanged += new System.EventHandler(this.FilePathButtonEdit_EditValueChanged);
            // 
            // PasswordTextEdit
            // 
            this.PasswordTextEdit.Location = new System.Drawing.Point(116, 84);
            this.PasswordTextEdit.Name = "PasswordTextEdit";
            this.PasswordTextEdit.Size = new System.Drawing.Size(478, 28);
            this.PasswordTextEdit.StyleController = this.layoutControl1;
            this.PasswordTextEdit.TabIndex = 7;
            this.PasswordTextEdit.EditValueChanged += new System.EventHandler(this.PasswordTextEdit_EditValueChanged);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(494, 329);
            this.CheckButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.CheckButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(100, 28);
            this.CheckButton.StyleController = this.layoutControl1;
            this.CheckButton.TabIndex = 6;
            this.CheckButton.Text = "Check";
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // PrivateKeyButtonEdit
            // 
            this.PrivateKeyButtonEdit.Location = new System.Drawing.Point(116, 50);
            this.PrivateKeyButtonEdit.Name = "PrivateKeyButtonEdit";
            this.PrivateKeyButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PrivateKeyButtonEdit.Size = new System.Drawing.Size(478, 28);
            this.PrivateKeyButtonEdit.StyleController = this.layoutControl1;
            this.PrivateKeyButtonEdit.TabIndex = 5;
            this.PrivateKeyButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.PrivateKeyButtonEdit_ButtonClick);
            this.PrivateKeyButtonEdit.EditValueChanged += new System.EventHandler(this.PrivateKeyButtonEdit_EditValueChanged);
            // 
            // PublickKeyButtonEdit
            // 
            this.PublickKeyButtonEdit.Location = new System.Drawing.Point(116, 16);
            this.PublickKeyButtonEdit.Name = "PublickKeyButtonEdit";
            this.PublickKeyButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PublickKeyButtonEdit.Size = new System.Drawing.Size(478, 28);
            this.PublickKeyButtonEdit.StyleController = this.layoutControl1;
            this.PublickKeyButtonEdit.TabIndex = 4;
            this.PublickKeyButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.PublickKeyButtonEdit_ButtonClick);
            this.PublickKeyButtonEdit.EditValueChanged += new System.EventHandler(this.PublickKeyButtonEdit_EditValueChanged);
            this.PublickKeyButtonEdit.Click += new System.EventHandler(this.PublickKeyButtonEdit_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(610, 373);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.PublickKeyButtonEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(584, 34);
            this.layoutControlItem1.Text = "Public Key:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.PrivateKeyButtonEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(584, 34);
            this.layoutControlItem2.Text = "PrivateKey:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.CheckButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(478, 313);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(106, 34);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 313);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(478, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.PasswordTextEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(584, 34);
            this.layoutControlItem4.Text = "Password:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.FilePathButtonEdit;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(584, 34);
            this.layoutControlItem7.Text = "File Path:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.memoEdit1;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 136);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(584, 177);
            this.layoutControlItem8.Text = "Result Plain Text:";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(84, 13);
            // 
            // EncryptionTabPage
            // 
            this.EncryptionTabPage.Controls.Add(this.layoutControl2);
            this.EncryptionTabPage.Name = "EncryptionTabPage";
            this.EncryptionTabPage.Size = new System.Drawing.Size(610, 373);
            this.EncryptionTabPage.Text = "Encryption";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.createFileButton);
            this.layoutControl2.Controls.Add(this.KeysButtonEdit);
            this.layoutControl2.Controls.Add(this.CreateKeyButton);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(610, 373);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // KeysButtonEdit
            // 
            this.KeysButtonEdit.Location = new System.Drawing.Point(92, 16);
            this.KeysButtonEdit.Name = "KeysButtonEdit";
            this.KeysButtonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KeysButtonEdit.Size = new System.Drawing.Size(502, 28);
            this.KeysButtonEdit.StyleController = this.layoutControl2;
            this.KeysButtonEdit.TabIndex = 5;
            this.KeysButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.KeysButtonEdit_ButtonClick);
            this.KeysButtonEdit.EditValueChanged += new System.EventHandler(this.KeysButtonEdit_EditValueChanged);
            // 
            // CreateKeyButton
            // 
            this.CreateKeyButton.Location = new System.Drawing.Point(388, 329);
            this.CreateKeyButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.CreateKeyButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.CreateKeyButton.Name = "CreateKeyButton";
            this.CreateKeyButton.Size = new System.Drawing.Size(100, 28);
            this.CreateKeyButton.StyleController = this.layoutControl2;
            this.CreateKeyButton.TabIndex = 4;
            this.CreateKeyButton.Text = "Create Key";
            this.CreateKeyButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.emptySpaceItem4,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.layoutControlItem9});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(610, 373);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.CreateKeyButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(372, 313);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(106, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 313);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(372, 34);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 34);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(584, 279);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.KeysButtonEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(584, 34);
            this.layoutControlItem6.Text = "Keys Folder:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 13);
            // 
            // createFileButton
            // 
            this.createFileButton.Location = new System.Drawing.Point(494, 329);
            this.createFileButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.createFileButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.createFileButton.Name = "createFileButton";
            this.createFileButton.Size = new System.Drawing.Size(100, 28);
            this.createFileButton.StyleController = this.layoutControl2;
            this.createFileButton.TabIndex = 6;
            this.createFileButton.Text = "Create File";
            this.createFileButton.Click += new System.EventHandler(this.createFileButton_Click);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.createFileButton;
            this.layoutControlItem9.Location = new System.Drawing.Point(478, 313);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(106, 34);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 404);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.DecryptionTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePathButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrivateKeyButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PublickKeyButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.EncryptionTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KeysButtonEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage DecryptionTabPage;
        private DevExpress.XtraTab.XtraTabPage EncryptionTabPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.ButtonEdit PublickKeyButtonEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit PrivateKeyButtonEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton CheckButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit PasswordTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton CreateKeyButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.ButtonEdit KeysButtonEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.ButtonEdit FilePathButtonEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton createFileButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}

