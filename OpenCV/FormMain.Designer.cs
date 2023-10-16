namespace OpenCV_Sharp4
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
            this.bOpen = new DevExpress.XtraBars.BarButtonItem();
            this.cbRotate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bScreenShot = new DevExpress.XtraBars.BarButtonItem();
            this.bZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.bZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.BarCodeBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.RerunBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.FileBarSubItem = new DevExpress.XtraBars.BarSubItem();
            this.OpenBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.CloseBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bOpen,
            this.cbRotate,
            this.bScreenShot,
            this.bZoomIn,
            this.bZoomOut,
            this.barButtonItem2,
            this.FileBarSubItem,
            this.OpenBarButtonItem,
            this.CloseBarButtonItem,
            this.BarCodeBarButtonItem,
            this.RerunBarButtonItem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 14;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bOpen),
            new DevExpress.XtraBars.LinkPersistInfo(this.cbRotate, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bScreenShot, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bZoomIn, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bZoomOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.RerunBarButtonItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarCodeBarButtonItem)});
            this.bar1.Text = "Tools";
            // 
            // bOpen
            // 
            this.bOpen.Caption = "Open";
            this.bOpen.Id = 0;
            this.bOpen.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.loadfrom_16x16;
            this.bOpen.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.loadfrom_32x32;
            this.bOpen.Name = "bOpen";
            this.bOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bOpen_ItemClick);
            // 
            // cbRotate
            // 
            this.cbRotate.Caption = "Rotate:";
            this.cbRotate.Edit = this.repositoryItemComboBox1;
            this.cbRotate.EditValue = "0";
            this.cbRotate.Id = 2;
            this.cbRotate.Name = "cbRotate";
            this.cbRotate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // bScreenShot
            // 
            this.bScreenShot.Caption = "ScreenShot";
            this.bScreenShot.Id = 3;
            this.bScreenShot.Name = "bScreenShot";
            this.bScreenShot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bScreenShot_ItemClick);
            // 
            // bZoomIn
            // 
            this.bZoomIn.Caption = "Zoom In";
            this.bZoomIn.Id = 4;
            this.bZoomIn.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.zoomin_16x16;
            this.bZoomIn.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.zoomin_32x32;
            this.bZoomIn.Name = "bZoomIn";
            // 
            // bZoomOut
            // 
            this.bZoomOut.Caption = "Zoom Out";
            this.bZoomOut.Id = 5;
            this.bZoomOut.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.zoomout_16x16;
            this.bZoomOut.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.zoomout_32x32;
            this.bZoomOut.Name = "bZoomOut";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Zoom Reset";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.zoom100percent_16x16;
            this.barButtonItem2.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.zoom100percent_32x32;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // BarCodeBarButtonItem
            // 
            this.BarCodeBarButtonItem.Caption = "BarCode";
            this.BarCodeBarButtonItem.Id = 12;
            this.BarCodeBarButtonItem.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.barcode_16x16;
            this.BarCodeBarButtonItem.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.barcode_32x32;
            this.BarCodeBarButtonItem.Name = "BarCodeBarButtonItem";
            this.BarCodeBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarCodeBarButtonItem_ItemClick);
            // 
            // RerunBarButtonItem
            // 
            this.RerunBarButtonItem.Caption = "Re-Run";
            this.RerunBarButtonItem.Id = 13;
            this.RerunBarButtonItem.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.reset_16x16;
            this.RerunBarButtonItem.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.reset_32x32;
            this.RerunBarButtonItem.Name = "RerunBarButtonItem";
            this.RerunBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RerunBarButtonItem_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.FileBarSubItem)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // FileBarSubItem
            // 
            this.FileBarSubItem.Caption = "File";
            this.FileBarSubItem.Id = 9;
            this.FileBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.OpenBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.CloseBarButtonItem)});
            this.FileBarSubItem.Name = "FileBarSubItem";
            // 
            // OpenBarButtonItem
            // 
            this.OpenBarButtonItem.Caption = "Open";
            this.OpenBarButtonItem.Id = 10;
            this.OpenBarButtonItem.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.open_16x16;
            this.OpenBarButtonItem.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.open_32x32;
            this.OpenBarButtonItem.Name = "OpenBarButtonItem";
            this.OpenBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.OpenBarButtonItem_ItemClick);
            // 
            // CloseBarButtonItem
            // 
            this.CloseBarButtonItem.Caption = "Close";
            this.CloseBarButtonItem.Id = 11;
            this.CloseBarButtonItem.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.cancel_16x16;
            this.CloseBarButtonItem.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.cancel_32x32;
            this.CloseBarButtonItem.Name = "CloseBarButtonItem";
            this.CloseBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CloseBarButtonItem_ItemClick);
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(634, 52);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 414);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(634, 18);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 52);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 362);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(634, 52);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 362);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pictureBox1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 52);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(634, 362);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(610, 322);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(634, 362);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pictureBox1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(614, 342);
            this.layoutControlItem1.Text = "Test View";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(46, 13);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Zoom In";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.ImageOptions.Image = global::OpenCV_Sharp4.Properties.Resources.zoomin_16x16;
            this.barButtonItem1.ImageOptions.LargeImage = global::OpenCV_Sharp4.Properties.Resources.zoomin_32x32;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // popupMenu1
            // 
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 432);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormMain";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bOpen;
        private DevExpress.XtraBars.BarEditItem cbRotate;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem bScreenShot;
        private DevExpress.XtraBars.BarButtonItem bZoomIn;
        private DevExpress.XtraBars.BarButtonItem bZoomOut;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarSubItem FileBarSubItem;
        private DevExpress.XtraBars.BarButtonItem OpenBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem CloseBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem BarCodeBarButtonItem;
        private DevExpress.XtraBars.BarButtonItem RerunBarButtonItem;
    }
}

