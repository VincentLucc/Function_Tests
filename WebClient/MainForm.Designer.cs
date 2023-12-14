namespace WebClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.AddButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.DeleteButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.SettingsButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.EditButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.StatusButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.MainTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.StatusGridControl = new DevExpress.XtraGrid.GridControl();
            this.StatusGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LogTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.LogGridControl = new DevExpress.XtraGrid.GridControl();
            this.LogGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGridView)).BeginInit();
            this.LogTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.SettingsButtonItem,
            this.StatusButtonItem,
            this.AddButtonItem,
            this.DeleteButtonItem,
            this.EditButtonItem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AddButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.DeleteButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.EditButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.SettingsButtonItem, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // AddButtonItem
            // 
            this.AddButtonItem.Caption = "Add GTIN";
            this.AddButtonItem.Hint = "Add GTIN";
            this.AddButtonItem.Id = 9;
            this.AddButtonItem.ImageOptions.Image = global::WebClient.Properties.Resources.add_16x162;
            this.AddButtonItem.ImageOptions.LargeImage = global::WebClient.Properties.Resources.add_32x322;
            this.AddButtonItem.Name = "AddButtonItem";
            this.AddButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AddButtonItem_ItemClick_1);
            // 
            // DeleteButtonItem
            // 
            this.DeleteButtonItem.Caption = "Delete GTIN";
            this.DeleteButtonItem.Hint = "Delete GTIN";
            this.DeleteButtonItem.Id = 10;
            this.DeleteButtonItem.ImageOptions.Image = global::WebClient.Properties.Resources.remove_16x161;
            this.DeleteButtonItem.ImageOptions.LargeImage = global::WebClient.Properties.Resources.remove_32x321;
            this.DeleteButtonItem.Name = "DeleteButtonItem";
            this.DeleteButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteButtonItem_ItemClick);
            // 
            // SettingsButtonItem
            // 
            this.SettingsButtonItem.Caption = "Settings";
            this.SettingsButtonItem.Id = 4;
            this.SettingsButtonItem.ImageOptions.Image = global::WebClient.Properties.Resources.properties_16x16;
            this.SettingsButtonItem.ImageOptions.LargeImage = global::WebClient.Properties.Resources.properties_32x32;
            this.SettingsButtonItem.Name = "SettingsButtonItem";
            this.SettingsButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SettingsButtonItem_ItemClick);
            // 
            // EditButtonItem
            // 
            this.EditButtonItem.Caption = "Edit GTIN";
            this.EditButtonItem.Id = 11;
            this.EditButtonItem.ImageOptions.Image = global::WebClient.Properties.Resources.editname_16x16;
            this.EditButtonItem.ImageOptions.LargeImage = global::WebClient.Properties.Resources.editname_32x32;
            this.EditButtonItem.Name = "EditButtonItem";
            this.EditButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditButtonItem_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.StatusButtonItem)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // StatusButtonItem
            // 
            this.StatusButtonItem.Caption = "Login";
            this.StatusButtonItem.Id = 6;
            this.StatusButtonItem.ImageOptions.Image = global::WebClient.Properties.Resources.iconsetredtoblack4_16x16;
            this.StatusButtonItem.ImageOptions.LargeImage = global::WebClient.Properties.Resources.iconsetredtoblack4_32x32;
            this.StatusButtonItem.Name = "StatusButtonItem";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(661, 33);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 356);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(661, 33);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 33);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 323);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(661, 33);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 323);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.xtraTabControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 33);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(661, 323);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.MainTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(637, 299);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.MainTabPage,
            this.LogTabPage});
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.StatusGridControl);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Size = new System.Drawing.Size(635, 275);
            this.MainTabPage.Text = "Status";
            // 
            // StatusGridControl
            // 
            this.StatusGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusGridControl.Location = new System.Drawing.Point(0, 0);
            this.StatusGridControl.MainView = this.StatusGridView;
            this.StatusGridControl.MenuManager = this.barManager1;
            this.StatusGridControl.Name = "StatusGridControl";
            this.StatusGridControl.Size = new System.Drawing.Size(635, 275);
            this.StatusGridControl.TabIndex = 4;
            this.StatusGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.StatusGridView});
            // 
            // StatusGridView
            // 
            this.StatusGridView.GridControl = this.StatusGridControl;
            this.StatusGridView.Name = "StatusGridView";
            this.StatusGridView.OptionsBehavior.Editable = false;
            this.StatusGridView.OptionsCustomization.AllowSort = false;
            this.StatusGridView.OptionsView.ShowGroupPanel = false;
            this.StatusGridView.OptionsView.ShowIndicator = false;
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.LogGridControl);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Size = new System.Drawing.Size(635, 275);
            this.LogTabPage.Text = "Log";
            // 
            // LogGridControl
            // 
            this.LogGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogGridControl.Location = new System.Drawing.Point(0, 0);
            this.LogGridControl.MainView = this.LogGridView;
            this.LogGridControl.MenuManager = this.barManager1;
            this.LogGridControl.Name = "LogGridControl";
            this.LogGridControl.Size = new System.Drawing.Size(635, 275);
            this.LogGridControl.TabIndex = 0;
            this.LogGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.LogGridView});
            // 
            // LogGridView
            // 
            this.LogGridView.GridControl = this.LogGridControl;
            this.LogGridView.Name = "LogGridView";
            this.LogGridView.OptionsCustomization.AllowSort = false;
            this.LogGridView.OptionsView.ShowIndicator = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(661, 323);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.xtraTabControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(641, 303);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 389);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = global::WebClient.Properties.Resources.boorderitem_16x16;
            this.Name = "MainForm";
            this.Text = "Gtin Service";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusGridView)).EndInit();
            this.LogTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl StatusGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView StatusGridView;
        private DevExpress.XtraBars.BarButtonItem SettingsButtonItem;
        private DevExpress.XtraBars.BarButtonItem StatusButtonItem;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage MainTabPage;
        private DevExpress.XtraTab.XtraTabPage LogTabPage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl LogGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView LogGridView;
        private DevExpress.XtraBars.BarButtonItem AddButtonItem;
        private DevExpress.XtraBars.BarButtonItem DeleteButtonItem;
        private DevExpress.XtraBars.BarButtonItem EditButtonItem;
    }
}