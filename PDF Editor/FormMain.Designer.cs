
namespace PDF_Editor
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.OpenButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.CombineBar = new DevExpress.XtraBars.Bar();
            this.AddFileBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.DeleteFileButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.MoveUpFileButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.MoveDownFileButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.CombineBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.CombineStandaloneBarDockControl = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.PdfViewerPage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.CombinePage = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CombineGridControl = new DevExpress.XtraGrid.GridControl();
            this.CombineGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.PdfViewerPage.SuspendLayout();
            this.CombinePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CombineGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombineGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3,
            this.CombineBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.CombineStandaloneBarDockControl);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.OpenButtonItem,
            this.AddFileBarButtonItem,
            this.DeleteFileButtonItem,
            this.MoveUpFileButtonItem,
            this.MoveDownFileButtonItem,
            this.CombineBarButtonItem});
            this.barManager1.MaxItemId = 6;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.OpenButtonItem)});
            this.bar1.Text = "Tools";
            // 
            // OpenButtonItem
            // 
            this.OpenButtonItem.Caption = "Open";
            this.OpenButtonItem.Id = 0;
            this.OpenButtonItem.ImageOptions.SvgImage = global::PDF_Editor.Properties.Resources.open;
            this.OpenButtonItem.Name = "OpenButtonItem";
            this.OpenButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.OpenButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OpenButtonItem_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // CombineBar
            // 
            this.CombineBar.BarName = "Combine";
            this.CombineBar.DockCol = 0;
            this.CombineBar.DockRow = 0;
            this.CombineBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.CombineBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AddFileBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.DeleteFileButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MoveUpFileButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MoveDownFileButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.CombineBarButtonItem)});
            this.CombineBar.StandaloneBarDockControl = this.CombineStandaloneBarDockControl;
            this.CombineBar.Text = "Combine";
            // 
            // AddFileBarButtonItem
            // 
            this.AddFileBarButtonItem.Caption = "AddButtonItem";
            this.AddFileBarButtonItem.Id = 1;
            this.AddFileBarButtonItem.ImageOptions.Image = global::PDF_Editor.Properties.Resources.add_16x16;
            this.AddFileBarButtonItem.ImageOptions.LargeImage = global::PDF_Editor.Properties.Resources.add_32x32;
            this.AddFileBarButtonItem.Name = "AddFileBarButtonItem";
            this.AddFileBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AddFileBarButtonItem_ItemClick);
            // 
            // DeleteFileButtonItem
            // 
            this.DeleteFileButtonItem.Caption = "DeleteButtonItem";
            this.DeleteFileButtonItem.Id = 2;
            this.DeleteFileButtonItem.ImageOptions.Image = global::PDF_Editor.Properties.Resources.remove_16x16;
            this.DeleteFileButtonItem.ImageOptions.LargeImage = global::PDF_Editor.Properties.Resources.remove_32x32;
            this.DeleteFileButtonItem.Name = "DeleteFileButtonItem";
            // 
            // MoveUpFileButtonItem
            // 
            this.MoveUpFileButtonItem.Caption = "MoveUpButtonItem";
            this.MoveUpFileButtonItem.Id = 3;
            this.MoveUpFileButtonItem.ImageOptions.Image = global::PDF_Editor.Properties.Resources.moveup_16x16;
            this.MoveUpFileButtonItem.ImageOptions.LargeImage = global::PDF_Editor.Properties.Resources.moveup_32x32;
            this.MoveUpFileButtonItem.Name = "MoveUpFileButtonItem";
            // 
            // MoveDownFileButtonItem
            // 
            this.MoveDownFileButtonItem.Caption = "barButtonItem4";
            this.MoveDownFileButtonItem.Id = 4;
            this.MoveDownFileButtonItem.ImageOptions.Image = global::PDF_Editor.Properties.Resources.movedown_16x16;
            this.MoveDownFileButtonItem.ImageOptions.LargeImage = global::PDF_Editor.Properties.Resources.movedown_32x32;
            this.MoveDownFileButtonItem.Name = "MoveDownFileButtonItem";
            // 
            // CombineBarButtonItem
            // 
            this.CombineBarButtonItem.Caption = "CombineButtonItem";
            this.CombineBarButtonItem.Id = 5;
            this.CombineBarButtonItem.ImageOptions.Image = global::PDF_Editor.Properties.Resources.contentarrangeinrows_16x16;
            this.CombineBarButtonItem.ImageOptions.LargeImage = global::PDF_Editor.Properties.Resources.contentarrangeinrows_32x32;
            this.CombineBarButtonItem.Name = "CombineBarButtonItem";
            // 
            // CombineStandaloneBarDockControl
            // 
            this.CombineStandaloneBarDockControl.CausesValidation = false;
            this.CombineStandaloneBarDockControl.Location = new System.Drawing.Point(12, 12);
            this.CombineStandaloneBarDockControl.Manager = this.barManager1;
            this.CombineStandaloneBarDockControl.Name = "CombineStandaloneBarDockControl";
            this.CombineStandaloneBarDockControl.Size = new System.Drawing.Size(180, 26);
            this.CombineStandaloneBarDockControl.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(639, 27);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 381);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(639, 19);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 27);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 354);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(639, 27);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 354);
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.PdfViewerPage);
            this.tabPane1.Controls.Add(this.CombinePage);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 27);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.PdfViewerPage,
            this.CombinePage});
            this.tabPane1.RegularSize = new System.Drawing.Size(639, 354);
            this.tabPane1.SelectedPage = this.PdfViewerPage;
            this.tabPane1.Size = new System.Drawing.Size(639, 354);
            this.tabPane1.TabIndex = 4;
            this.tabPane1.Text = "tabPane1";
            // 
            // PdfViewerPage
            // 
            this.PdfViewerPage.Caption = "Viewer";
            this.PdfViewerPage.Controls.Add(this.pdfViewer1);
            this.PdfViewerPage.Name = "PdfViewerPage";
            this.PdfViewerPage.Size = new System.Drawing.Size(639, 317);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewer1.MenuManager = this.barManager1;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.Size = new System.Drawing.Size(639, 317);
            this.pdfViewer1.TabIndex = 0;
            // 
            // CombinePage
            // 
            this.CombinePage.Caption = "Combine";
            this.CombinePage.Controls.Add(this.layoutControl1);
            this.CombinePage.Name = "CombinePage";
            this.CombinePage.Size = new System.Drawing.Size(639, 317);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CombineStandaloneBarDockControl);
            this.layoutControl1.Controls.Add(this.CombineGridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(639, 317);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CombineGridControl
            // 
            this.CombineGridControl.Location = new System.Drawing.Point(12, 42);
            this.CombineGridControl.MainView = this.CombineGridView;
            this.CombineGridControl.MenuManager = this.barManager1;
            this.CombineGridControl.Name = "CombineGridControl";
            this.CombineGridControl.Size = new System.Drawing.Size(615, 263);
            this.CombineGridControl.TabIndex = 4;
            this.CombineGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.CombineGridView});
            // 
            // CombineGridView
            // 
            this.CombineGridView.GridControl = this.CombineGridControl;
            this.CombineGridView.Name = "CombineGridView";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(639, 317);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CombineGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(619, 267);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CombineStandaloneBarDockControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(619, 30);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 400);
            this.Controls.Add(this.tabPane1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.PdfViewerPage.ResumeLayout(false);
            this.CombinePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CombineGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CombineGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage PdfViewerPage;
        private DevExpress.XtraBars.Navigation.TabNavigationPage CombinePage;
        private DevExpress.XtraBars.BarButtonItem OpenButtonItem;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl CombineGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView CombineGridView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Bar CombineBar;
        private DevExpress.XtraBars.BarButtonItem AddFileBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem DeleteFileButtonItem;
        private DevExpress.XtraBars.BarButtonItem MoveUpFileButtonItem;
        private DevExpress.XtraBars.BarButtonItem MoveDownFileButtonItem;
        private DevExpress.XtraBars.StandaloneBarDockControl CombineStandaloneBarDockControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.BarButtonItem CombineBarButtonItem;
    }
}

