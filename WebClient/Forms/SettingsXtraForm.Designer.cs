namespace WebClient
{
    partial class SettingsXtraForm
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.GeneraTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.CheckIntervalSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ClientSecretMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ClientIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.OKButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.GeneraTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckIntervalSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientSecretMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xtraTabControl1);
            this.layoutControl1.Controls.Add(this.OKButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(564, 456);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.GeneraTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(540, 403);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.GeneraTabPage});
            // 
            // GeneraTabPage
            // 
            this.GeneraTabPage.Controls.Add(this.layoutControl2);
            this.GeneraTabPage.Name = "GeneraTabPage";
            this.GeneraTabPage.Size = new System.Drawing.Size(538, 379);
            this.GeneraTabPage.Text = "General";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.CheckIntervalSpinEdit);
            this.layoutControl2.Controls.Add(this.ClientSecretMemoEdit);
            this.layoutControl2.Controls.Add(this.ClientIDTextEdit);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(538, 379);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // CheckIntervalSpinEdit
            // 
            this.CheckIntervalSpinEdit.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CheckIntervalSpinEdit.Location = new System.Drawing.Point(12, 29);
            this.CheckIntervalSpinEdit.Name = "CheckIntervalSpinEdit";
            this.CheckIntervalSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CheckIntervalSpinEdit.Properties.IsFloatValue = false;
            this.CheckIntervalSpinEdit.Properties.MaskSettings.Set("mask", "N00");
            this.CheckIntervalSpinEdit.Properties.MaxValue = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.CheckIntervalSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CheckIntervalSpinEdit.Size = new System.Drawing.Size(514, 22);
            this.CheckIntervalSpinEdit.StyleController = this.layoutControl2;
            this.CheckIntervalSpinEdit.TabIndex = 6;
            this.CheckIntervalSpinEdit.EditValueChanged += new System.EventHandler(this.CheckIntervalSpinEdit_EditValueChanged);
            // 
            // ClientSecretMemoEdit
            // 
            this.ClientSecretMemoEdit.Location = new System.Drawing.Point(12, 116);
            this.ClientSecretMemoEdit.Name = "ClientSecretMemoEdit";
            this.ClientSecretMemoEdit.Size = new System.Drawing.Size(514, 115);
            this.ClientSecretMemoEdit.StyleController = this.layoutControl2;
            this.ClientSecretMemoEdit.TabIndex = 5;
            this.ClientSecretMemoEdit.EditValueChanged += new System.EventHandler(this.ClientSecretMemoEdit_EditValueChanged);
            // 
            // ClientIDTextEdit
            // 
            this.ClientIDTextEdit.Location = new System.Drawing.Point(12, 72);
            this.ClientIDTextEdit.Name = "ClientIDTextEdit";
            this.ClientIDTextEdit.Size = new System.Drawing.Size(514, 22);
            this.ClientIDTextEdit.StyleController = this.layoutControl2;
            this.ClientIDTextEdit.TabIndex = 4;
            this.ClientIDTextEdit.EditValueChanged += new System.EventHandler(this.ClientIDTextEdit_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.simpleSeparator1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(538, 379);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ClientIDTextEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 43);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(518, 43);
            this.layoutControlItem3.Text = "Client ID:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 223);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(518, 136);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ClientSecretMemoEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(518, 136);
            this.layoutControlItem4.Text = "Client Secrest:";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(74, 13);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 86);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(518, 1);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.CheckIntervalSpinEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(518, 43);
            this.layoutControlItem5.Text = "Check Interval:";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(74, 13);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(452, 419);
            this.OKButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.OKButton.MinimumSize = new System.Drawing.Size(100, 25);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 25);
            this.OKButton.StyleController = this.layoutControl1;
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(564, 456);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 407);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(440, 29);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xtraTabControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(544, 407);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.OKButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(440, 407);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 29);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // SettingsXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 456);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "SettingsXtraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.SettingsXtraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.GeneraTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckIntervalSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientSecretMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton OKButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage GeneraTabPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit ClientSecretMemoEdit;
        private DevExpress.XtraEditors.TextEdit ClientIDTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.SpinEdit CheckIntervalSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}