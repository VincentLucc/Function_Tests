
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
            this.MainPropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.CustomContainPanelControl = new DevExpress.XtraEditors.PanelControl();
            this.CustomPropertyGridControl = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tab1 = new DevExpress.XtraVerticalGrid.Tab();
            this.tab2 = new DevExpress.XtraVerticalGrid.Tab();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomContainPanelControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomPropertyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(786, 43);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 438);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(786, 19);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 43);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 395);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(786, 43);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 395);
            // 
            // MainPropertyGridControl
            // 
            this.MainPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPropertyGridControl.Location = new System.Drawing.Point(2, 23);
            this.MainPropertyGridControl.MenuManager = this.barManager1;
            this.MainPropertyGridControl.Name = "MainPropertyGridControl";
            this.MainPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            this.MainPropertyGridControl.Size = new System.Drawing.Size(305, 370);
            this.MainPropertyGridControl.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(406, 43);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(71, 395);
            this.panelControl1.TabIndex = 5;
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxControl1.Location = new System.Drawing.Point(0, 43);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(127, 395);
            this.listBoxControl1.TabIndex = 6;
            this.listBoxControl1.SelectedIndexChanged += new System.EventHandler(this.listBoxControl1_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.CustomContainPanelControl);
            this.groupControl1.Controls.Add(this.CustomPropertyGridControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(127, 43);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(279, 395);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Customized Layout";
            // 
            // CustomContainPanelControl
            // 
            this.CustomContainPanelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CustomContainPanelControl.Location = new System.Drawing.Point(2, 277);
            this.CustomContainPanelControl.Name = "CustomContainPanelControl";
            this.CustomContainPanelControl.Size = new System.Drawing.Size(275, 116);
            this.CustomContainPanelControl.TabIndex = 1;
            // 
            // CustomPropertyGridControl
            // 
            this.CustomPropertyGridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.CustomPropertyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomPropertyGridControl.Location = new System.Drawing.Point(2, 23);
            this.CustomPropertyGridControl.MenuManager = this.barManager1;
            this.CustomPropertyGridControl.Name = "CustomPropertyGridControl";
            this.CustomPropertyGridControl.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            this.CustomPropertyGridControl.SelectedTab = this.tab1;
            this.CustomPropertyGridControl.Size = new System.Drawing.Size(275, 370);
            this.CustomPropertyGridControl.TabIndex = 0;
            this.CustomPropertyGridControl.Tabs.AddRange(new DevExpress.XtraVerticalGrid.Tab[] {
            this.tab1,
            this.tab2});
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.MainPropertyGridControl);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl2.Location = new System.Drawing.Point(477, 43);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(309, 395);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "Default Property Grid";
            // 
            // tab1
            // 
            this.tab1.Caption = "General";
            this.tab1.Name = "tab1";
            // 
            // tab2
            // 
            this.tab2.Caption = "Advanced";
            this.tab2.Name = "tab2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 457);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.listBoxControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomContainPanelControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomPropertyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraVerticalGrid.Tab tab1;
        private DevExpress.XtraVerticalGrid.Tab tab2;
    }
}

