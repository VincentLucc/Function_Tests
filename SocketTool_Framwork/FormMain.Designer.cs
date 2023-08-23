using DevExpress.XtraEditors;

namespace SocketTool_Framework
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDel = new DevExpress.XtraBars.BarButtonItem();
            this.moveUpButton = new DevExpress.XtraBars.BarButtonItem();
            this.moveDownButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ExitButton = new DevExpress.XtraBars.BarButtonItem();
            this.HelpButton = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.MainSplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.MenuAccordionControl = new SocketTool_Framework.AccordionControlEx();
            this.TCPServerAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.TCPClientAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement11 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement12 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement13 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.accordionControlElement15 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement16 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl.Panel1)).BeginInit();
            this.MainSplitContainerControl.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl.Panel2)).BeginInit();
            this.MainSplitContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuAccordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.barSubItem1,
            this.HelpButton,
            this.barButtonItem2,
            this.ExitButton,
            this.barButtonAdd,
            this.barButtonDel,
            this.moveUpButton,
            this.moveDownButton,
            this.barButtonItem4,
            this.barButtonItem5});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 11;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.moveUpButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.moveDownButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // barButtonAdd
            // 
            this.barButtonAdd.Caption = "Add";
            this.barButtonAdd.Id = 5;
            this.barButtonAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonAdd.ImageOptions.Image")));
            this.barButtonAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonAdd.ImageOptions.LargeImage")));
            this.barButtonAdd.Name = "barButtonAdd";
            this.barButtonAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonAdd_ItemClick);
            // 
            // barButtonDel
            // 
            this.barButtonDel.Caption = "Delete";
            this.barButtonDel.Id = 6;
            this.barButtonDel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonDel.ImageOptions.Image")));
            this.barButtonDel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonDel.ImageOptions.LargeImage")));
            this.barButtonDel.Name = "barButtonDel";
            this.barButtonDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDel_ItemClick);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Caption = "Move Up";
            this.moveUpButton.Id = 7;
            this.moveUpButton.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.moveup_16x16;
            this.moveUpButton.ImageOptions.LargeImage = global::SocketTool_Framework.Properties.Resources.moveup_32x32;
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.moveUpButton_ItemClick);
            this.moveUpButton.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.moveUpButton_ItemDoubleClick);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Caption = "Move Down";
            this.moveDownButton.Id = 8;
            this.moveDownButton.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.movedown_16x16;
            this.moveDownButton.ImageOptions.LargeImage = global::SocketTool_Framework.Properties.Resources.movedown_32x32;
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.moveDownButton_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Start ";
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.play_16x16;
            this.barButtonItem4.ImageOptions.LargeImage = global::SocketTool_Framework.Properties.Resources.play_32x32;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Stop";
            this.barButtonItem5.Id = 10;
            this.barButtonItem5.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.stop_16x16;
            this.barButtonItem5.ImageOptions.LargeImage = global::SocketTool_Framework.Properties.Resources.stop_32x32;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.HelpButton)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "File";
            this.barSubItem1.Id = 0;
            this.barSubItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.Image")));
            this.barSubItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSubItem1.ImageOptions.LargeImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.ExitButton)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Open";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // ExitButton
            // 
            this.ExitButton.Caption = "Exit";
            this.ExitButton.Id = 4;
            this.ExitButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.ImageOptions.Image")));
            this.ExitButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.ImageOptions.LargeImage")));
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExitButton_ItemClick);
            // 
            // HelpButton
            // 
            this.HelpButton.Caption = "Help";
            this.HelpButton.Id = 1;
            this.HelpButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("HelpButton.ImageOptions.Image")));
            this.HelpButton.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("HelpButton.ImageOptions.LargeImage")));
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.HelpButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.HelpButton_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(834, 61);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 500);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(834, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 61);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 439);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(834, 61);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 439);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.MainSplitContainerControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 61);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(834, 439);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // MainSplitContainerControl
            // 
            this.MainSplitContainerControl.Location = new System.Drawing.Point(12, 12);
            this.MainSplitContainerControl.Name = "MainSplitContainerControl";
            // 
            // MainSplitContainerControl.Panel1
            // 
            this.MainSplitContainerControl.Panel1.Controls.Add(this.MenuAccordionControl);
            this.MainSplitContainerControl.Panel1.Text = "Panel1";
            // 
            // MainSplitContainerControl.Panel2
            // 
            this.MainSplitContainerControl.Panel2.Text = "Panel2";
            this.MainSplitContainerControl.Size = new System.Drawing.Size(810, 415);
            this.MainSplitContainerControl.SplitterPosition = 182;
            this.MainSplitContainerControl.TabIndex = 0;
            // 
            // MenuAccordionControl
            // 
            this.MenuAccordionControl.AllowItemSelection = true;
            this.MenuAccordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuAccordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.TCPServerAccordionControlElement,
            this.TCPClientAccordionControlElement});
            this.MenuAccordionControl.Location = new System.Drawing.Point(0, 0);
            this.MenuAccordionControl.Name = "MenuAccordionControl";
            this.MenuAccordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            this.MenuAccordionControl.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.MenuAccordionControl.Size = new System.Drawing.Size(182, 415);
            this.MenuAccordionControl.TabIndex = 4;
            this.MenuAccordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // TCPServerAccordionControlElement
            // 
            this.TCPServerAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement4});
            this.TCPServerAccordionControlElement.Expanded = true;
            this.TCPServerAccordionControlElement.Name = "TCPServerAccordionControlElement";
            this.TCPServerAccordionControlElement.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Normal;
            this.TCPServerAccordionControlElement.Text = "TCP Server";
            this.TCPServerAccordionControlElement.Click += new System.EventHandler(this.TCPServerAccordionControlElement_Click);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
            this.accordionControlElement1.Text = "Element1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
            this.accordionControlElement2.Text = "Element2";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
            this.accordionControlElement3.Text = "Element3";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Element4";
            // 
            // TCPClientAccordionControlElement
            // 
            this.TCPClientAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement11,
            this.accordionControlElement12,
            this.accordionControlElement13});
            this.TCPClientAccordionControlElement.Expanded = true;
            this.TCPClientAccordionControlElement.Name = "TCPClientAccordionControlElement";
            this.TCPClientAccordionControlElement.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
            this.TCPClientAccordionControlElement.Text = "TCP Client";
            // 
            // accordionControlElement11
            // 
            this.accordionControlElement11.Name = "accordionControlElement11";
            this.accordionControlElement11.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement11.Text = "Element11";
            // 
            // accordionControlElement12
            // 
            this.accordionControlElement12.Name = "accordionControlElement12";
            this.accordionControlElement12.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement12.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
            this.accordionControlElement12.Text = "Element12";
            // 
            // accordionControlElement13
            // 
            this.accordionControlElement13.Name = "accordionControlElement13";
            this.accordionControlElement13.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement13.Text = "Element13";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(834, 439);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.MainSplitContainerControl;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(814, 419);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // accordionControlElement15
            // 
            this.accordionControlElement15.Name = "accordionControlElement15";
            this.accordionControlElement15.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement15.Text = "Element15";
            // 
            // accordionControlElement16
            // 
            this.accordionControlElement16.Name = "accordionControlElement16";
            this.accordionControlElement16.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement16.Text = "Element16";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 525);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("FormMain.IconOptions.LargeImage")));
            this.Name = "FormMain";
            this.Text = "Socket Tool";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl.Panel1)).EndInit();
            this.MainSplitContainerControl.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainerControl)).EndInit();
            this.MainSplitContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuAccordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem HelpButton;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonDel;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem ExitButton;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private AccordionControlEx MenuAccordionControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement TCPServerAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement TCPClientAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement11;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement12;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement13;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement15;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement16;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private SplitContainerControl MainSplitContainerControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem moveUpButton;
        private DevExpress.XtraBars.BarButtonItem moveDownButton;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    }
}

