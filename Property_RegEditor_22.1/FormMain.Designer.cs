
namespace Property_RegEditor_22._1
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
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bCutomized = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.DefaultDockPanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.MainPropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.CustomPropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.CustomPropertyGridGeneralTab = new DevExpress.XtraVerticalGrid.Tab();
            this.AdvancedTab = new DevExpress.XtraVerticalGrid.Tab();
            this.tab3 = new DevExpress.XtraVerticalGrid.Tab();
            this.CustomContainPanelControl = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            this.DefaultDockPanel.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomPropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomContainPanelControl)).BeginInit();
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
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bCutomized});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bCutomized)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bCutomized
            // 
            this.bCutomized.Caption = "Customize PropertyLayout";
            this.bCutomized.Id = 0;
            this.bCutomized.Name = "bCutomized";
            this.bCutomized.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bCutomized_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(900, 57);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 545);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(900, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 57);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 488);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(900, 57);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 488);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.DefaultDockPanel});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("2a055cc5-2984-4d4f-8899-48cb06054d7f");
            this.dockPanel1.Location = new System.Drawing.Point(0, 57);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 488);
            this.dockPanel1.Text = "Menu";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.listBoxControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 31);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(193, 454);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControl1.Location = new System.Drawing.Point(0, 0);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(193, 454);
            this.listBoxControl1.TabIndex = 6;
            this.listBoxControl1.SelectedIndexChanged += new System.EventHandler(this.listBoxControl1_SelectedIndexChanged);
            // 
            // DefaultDockPanel
            // 
            this.DefaultDockPanel.Controls.Add(this.dockPanel2_Container);
            this.DefaultDockPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.DefaultDockPanel.ID = new System.Guid("5665eb07-b129-4b6f-a8ad-30fca27ba9da");
            this.DefaultDockPanel.Location = new System.Drawing.Point(532, 57);
            this.DefaultDockPanel.Name = "DefaultDockPanel";
            this.DefaultDockPanel.Options.ShowCloseButton = false;
            this.DefaultDockPanel.OriginalSize = new System.Drawing.Size(368, 200);
            this.DefaultDockPanel.Size = new System.Drawing.Size(368, 488);
            this.DefaultDockPanel.Text = "Default Property Grid";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.MainPropertyGridControl);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 31);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(361, 454);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // MainPropertyGridControl
            // 
            this.MainPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPropertyGridControl.Location = new System.Drawing.Point(0, 0);
            this.MainPropertyGridControl.MenuManager = this.barManager1;
            this.MainPropertyGridControl.Name = "MainPropertyGridControl";
            this.MainPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            this.MainPropertyGridControl.Size = new System.Drawing.Size(361, 454);
            this.MainPropertyGridControl.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(200, 57);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(332, 488);
            this.panelControl1.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.CustomPropertyGridControl);
            this.groupControl1.Controls.Add(this.CustomContainPanelControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(328, 484);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Customized Layout";
            // 
            // CustomPropertyGridControl
            // 
            this.CustomPropertyGridControl.ActiveViewType = DevExpress.XtraVerticalGrid.PropertyGridView.Office;
            this.CustomPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomPropertyGridControl.Location = new System.Drawing.Point(2, 22);
            this.CustomPropertyGridControl.MenuManager = this.barManager1;
            this.CustomPropertyGridControl.Name = "CustomPropertyGridControl";
            this.CustomPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            this.CustomPropertyGridControl.SelectedTab = this.CustomPropertyGridGeneralTab;
            this.CustomPropertyGridControl.Size = new System.Drawing.Size(324, 344);
            this.CustomPropertyGridControl.TabIndex = 0;
            this.CustomPropertyGridControl.Tabs.AddRange(new DevExpress.XtraVerticalGrid.Tab[] {
            this.CustomPropertyGridGeneralTab,
            this.AdvancedTab,
            this.tab3});
            // 
            // GeneralTab
            // 
            this.CustomPropertyGridGeneralTab.Caption = "General";
            this.CustomPropertyGridGeneralTab.Name = "GeneralTab";
            // 
            // AdvancedTab
            // 
            this.AdvancedTab.Caption = "Advanced";
            this.AdvancedTab.Name = "AdvancedTab";
            // 
            // tab3
            // 
            this.tab3.Caption = "Tab 3";
            this.tab3.Name = "tab3";
            // 
            // CustomContainPanelControl
            // 
            this.CustomContainPanelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CustomContainPanelControl.Location = new System.Drawing.Point(2, 366);
            this.CustomContainPanelControl.Name = "CustomContainPanelControl";
            this.CustomContainPanelControl.Size = new System.Drawing.Size(324, 116);
            this.CustomContainPanelControl.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.DefaultDockPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            this.DefaultDockPanel.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainPropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomPropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomContainPanelControl)).EndInit();
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
        private DevExpress.XtraVerticalGrid.PropertyGridControl MainPropertyGridControl;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl1;
        private DevExpress.XtraBars.BarButtonItem bCutomized;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl CustomContainPanelControl;
        private DevExpress.XtraVerticalGrid.PropertyGridControl CustomPropertyGridControl;
        private DevExpress.XtraVerticalGrid.Tab CustomPropertyGridGeneralTab;
        private DevExpress.XtraVerticalGrid.Tab AdvancedTab;
        private DevExpress.XtraVerticalGrid.Tab tab3;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel DefaultDockPanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
    }
}

