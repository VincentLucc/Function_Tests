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
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDel = new DevExpress.XtraBars.BarButtonItem();
            this.moveUpButton = new DevExpress.XtraBars.BarButtonItem();
            this.moveDownButton = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.VersionStaticItem = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.ExitButton = new DevExpress.XtraBars.BarButtonItem();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
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
            this.barButtonItem2,
            this.ExitButton,
            this.barButtonAdd,
            this.barButtonDel,
            this.moveUpButton,
            this.moveDownButton,
            this.VersionStaticItem});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDel),
            new DevExpress.XtraBars.LinkPersistInfo(this.moveUpButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.moveDownButton)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
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
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.VersionStaticItem)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // VersionStaticItem
            // 
            this.VersionStaticItem.Caption = "Version Info";
            this.VersionStaticItem.Id = 11;
            this.VersionStaticItem.Name = "VersionStaticItem";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(834, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 496);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(834, 29);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 441);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(834, 55);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 441);
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.MainSplitContainerControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 55);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(834, 441);
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
            this.MainSplitContainerControl.Size = new System.Drawing.Size(810, 417);
            this.MainSplitContainerControl.SplitterPosition = 208;
            this.MainSplitContainerControl.TabIndex = 0;
            // 
            // MenuAccordionControl
            // 
            this.MenuAccordionControl.AllowItemSelection = true;
            this.MenuAccordionControl.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.MenuAccordionControl.Appearance.AccordionControl.Options.UseBackColor = true;
            this.MenuAccordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuAccordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.TCPServerAccordionControlElement,
            this.TCPClientAccordionControlElement});
            this.MenuAccordionControl.Location = new System.Drawing.Point(0, 0);
            this.MenuAccordionControl.Name = "MenuAccordionControl";
            this.MenuAccordionControl.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            this.MenuAccordionControl.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.MenuAccordionControl.Size = new System.Drawing.Size(208, 417);
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
            this.TCPServerAccordionControlElement.Tag = SocketTool_Framework.AccordionControlEx.MouseEventType.Click;
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
            this.Root.Size = new System.Drawing.Size(834, 441);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.MainSplitContainerControl;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(814, 421);
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "record_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "iconsettrafficlights3_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "iconsetredtoblack4_16x16.png");
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
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
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
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarStaticItem VersionStaticItem;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}

