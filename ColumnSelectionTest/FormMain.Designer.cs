
namespace Test001
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
            this.DataFileFieldGridControl = new DevExpress.XtraGrid.GridControl();
            this.DataFileFieldGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.FileColumnSelector = new Test001.ColumnSelectorControlV2();
            this.bShow = new DevExpress.XtraEditors.SimpleButton();
            this.pTable = new System.Windows.Forms.Panel();
            this.pControls = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bSort = new DevExpress.XtraEditors.SimpleButton();
            this.bDel = new DevExpress.XtraEditors.SimpleButton();
            this.bClear = new DevExpress.XtraEditors.SimpleButton();
            this.bReload = new DevExpress.XtraEditors.SimpleButton();
            this.bAdd = new DevExpress.XtraEditors.SimpleButton();
            this.bModify = new DevExpress.XtraEditors.SimpleButton();
            this.bMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.bMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.pShow = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bTest2 = new DevExpress.XtraEditors.SimpleButton();
            this.bTest = new DevExpress.XtraEditors.SimpleButton();
            this.pSelection = new System.Windows.Forms.Panel();
            this.pBottom = new System.Windows.Forms.Panel();
            this.FieldContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NewFieldAfterCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewCurrentSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NewFieldDefaultSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.ColumnSelector2TabPage = new DevExpress.XtraTab.XtraTabPage();
            this.ColumnSelector3TabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Selector3ToggleSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pColumnSelector3 = new System.Windows.Forms.Panel();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataFileFieldGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFileFieldGridView)).BeginInit();
            this.pTable.SuspendLayout();
            this.pControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pShow.SuspendLayout();
            this.pSelection.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.FieldContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.ColumnSelector2TabPage.SuspendLayout();
            this.ColumnSelector3TabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Selector3ToggleSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFileFieldGridControl
            // 
            this.DataFileFieldGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataFileFieldGridControl.Location = new System.Drawing.Point(0, 0);
            this.DataFileFieldGridControl.MainView = this.DataFileFieldGridView;
            this.DataFileFieldGridControl.Name = "DataFileFieldGridControl";
            this.DataFileFieldGridControl.Size = new System.Drawing.Size(406, 204);
            this.DataFileFieldGridControl.TabIndex = 0;
            this.DataFileFieldGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DataFileFieldGridView});
            this.DataFileFieldGridControl.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // DataFileFieldGridView
            // 
            this.DataFileFieldGridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.DataFileFieldGridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DataFileFieldGridView.Appearance.Row.Options.UseTextOptions = true;
            this.DataFileFieldGridView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DataFileFieldGridView.GridControl = this.DataFileFieldGridControl;
            this.DataFileFieldGridView.Name = "DataFileFieldGridView";
            this.DataFileFieldGridView.NewItemRowText = "123";
            this.DataFileFieldGridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.DataFileFieldGridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow;
            this.DataFileFieldGridView.OptionsCustomization.AllowFilter = false;
            this.DataFileFieldGridView.OptionsCustomization.AllowSort = false;
            this.DataFileFieldGridView.OptionsDetail.EnableMasterViewMode = false;
            this.DataFileFieldGridView.OptionsFilter.AllowFilterEditor = false;
            this.DataFileFieldGridView.OptionsLayout.Columns.AddNewColumns = false;
            this.DataFileFieldGridView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.DataFileFieldGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.DataFileFieldGridView.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.DataFileFieldGridView.OptionsView.ShowGroupPanel = false;
            // 
            // FileColumnSelector
            // 
            this.FileColumnSelector.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.FileColumnSelector.Appearance.Font = new System.Drawing.Font("Consolas", 12F);
            this.FileColumnSelector.Appearance.Options.UseBorderColor = true;
            this.FileColumnSelector.Appearance.Options.UseFont = true;
            this.FileColumnSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileColumnSelector.FontSize = 12F;
            this.FileColumnSelector.Location = new System.Drawing.Point(0, 0);
            this.FileColumnSelector.Margin = new System.Windows.Forms.Padding(4);
            this.FileColumnSelector.MarkerColor = System.Drawing.Color.Gray;
            this.FileColumnSelector.MaxAllowedColumns = 32;
            this.FileColumnSelector.Name = "FileColumnSelector";
            this.FileColumnSelector.Padding = new System.Windows.Forms.Padding(4);
            this.FileColumnSelector.Size = new System.Drawing.Size(609, 246);
            this.FileColumnSelector.TabIndex = 1;
            this.FileColumnSelector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.columnSelectorControl1_MouseDown);
            this.FileColumnSelector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.columnSelectorControl1_MouseUp);
            // 
            // bShow
            // 
            this.bShow.Location = new System.Drawing.Point(23, 6);
            this.bShow.Name = "bShow";
            this.bShow.Size = new System.Drawing.Size(54, 23);
            this.bShow.TabIndex = 6;
            this.bShow.Text = "Show";
            this.bShow.Click += new System.EventHandler(this.bShow_Click);
            // 
            // pTable
            // 
            this.pTable.Controls.Add(this.DataFileFieldGridControl);
            this.pTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTable.Location = new System.Drawing.Point(203, 0);
            this.pTable.Name = "pTable";
            this.pTable.Size = new System.Drawing.Size(406, 204);
            this.pTable.TabIndex = 5;
            // 
            // pControls
            // 
            this.pControls.Controls.Add(this.tableLayoutPanel1);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pControls.Location = new System.Drawing.Point(0, 0);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(203, 204);
            this.pControls.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bSort, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.bDel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.bClear, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.bReload, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bModify, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bMoveUp, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.bMoveDown, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07124F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.07238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.64149F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 204);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // bSort
            // 
            this.bSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bSort.Location = new System.Drawing.Point(125, 63);
            this.bSort.Name = "bSort";
            this.bSort.Size = new System.Drawing.Size(54, 23);
            this.bSort.TabIndex = 8;
            this.bSort.Text = "Sort";
            this.bSort.Click += new System.EventHandler(this.bSort_Click);
            // 
            // bDel
            // 
            this.bDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bDel.Location = new System.Drawing.Point(23, 33);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(54, 23);
            this.bDel.TabIndex = 7;
            this.bDel.Text = "Delete";
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bClear.Location = new System.Drawing.Point(23, 63);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(54, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bReload
            // 
            this.bReload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bReload.Location = new System.Drawing.Point(125, 33);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(54, 23);
            this.bReload.TabIndex = 4;
            this.bReload.Text = "Reload";
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bAdd.Location = new System.Drawing.Point(23, 3);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(54, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bModify
            // 
            this.bModify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bModify.Location = new System.Drawing.Point(125, 3);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(54, 23);
            this.bModify.TabIndex = 6;
            this.bModify.Text = "Modify";
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // bMoveUp
            // 
            this.bMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bMoveUp.Location = new System.Drawing.Point(116, 93);
            this.bMoveUp.Name = "bMoveUp";
            this.bMoveUp.Size = new System.Drawing.Size(72, 23);
            this.bMoveUp.TabIndex = 9;
            this.bMoveUp.Text = "MoveUp";
            this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
            // 
            // bMoveDown
            // 
            this.bMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bMoveDown.Location = new System.Drawing.Point(116, 123);
            this.bMoveDown.Name = "bMoveDown";
            this.bMoveDown.Size = new System.Drawing.Size(72, 23);
            this.bMoveDown.TabIndex = 10;
            this.bMoveDown.Text = "MoveDown";
            this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
            // 
            // pShow
            // 
            this.pShow.Controls.Add(this.simpleButton1);
            this.pShow.Controls.Add(this.bTest2);
            this.pShow.Controls.Add(this.bTest);
            this.pShow.Controls.Add(this.bShow);
            this.pShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pShow.Location = new System.Drawing.Point(0, 450);
            this.pShow.Name = "pShow";
            this.pShow.Size = new System.Drawing.Size(609, 36);
            this.pShow.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(465, 6);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(124, 23);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "TestDataMapping";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // bTest2
            // 
            this.bTest2.Location = new System.Drawing.Point(278, 7);
            this.bTest2.Name = "bTest2";
            this.bTest2.Size = new System.Drawing.Size(54, 23);
            this.bTest2.TabIndex = 8;
            this.bTest2.Text = "Test2";
            this.bTest2.Click += new System.EventHandler(this.bTest2_Click);
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(149, 7);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(54, 23);
            this.bTest.TabIndex = 7;
            this.bTest.Text = "Test";
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // pSelection
            // 
            this.pSelection.Controls.Add(this.FileColumnSelector);
            this.pSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelection.Location = new System.Drawing.Point(0, 0);
            this.pSelection.Name = "pSelection";
            this.pSelection.Size = new System.Drawing.Size(609, 246);
            this.pSelection.TabIndex = 7;
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.pTable);
            this.pBottom.Controls.Add(this.pControls);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 246);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(609, 204);
            this.pBottom.TabIndex = 2;
            this.pBottom.Visible = false;
            // 
            // FieldContextMenuStrip
            // 
            this.FieldContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.NewFieldAfterCurrentMenuItem,
            this.toolStripSeparator1,
            this.NewCurrentSelectionMenuItem,
            this.toolStripSeparator3,
            this.NewFieldDefaultSelectionMenuItem});
            this.FieldContextMenuStrip.Name = "FieldContextMenuStrip";
            this.FieldContextMenuStrip.Size = new System.Drawing.Size(215, 88);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // NewFieldAfterCurrentMenuItem
            // 
            this.NewFieldAfterCurrentMenuItem.Name = "NewFieldAfterCurrentMenuItem";
            this.NewFieldAfterCurrentMenuItem.Size = new System.Drawing.Size(214, 22);
            this.NewFieldAfterCurrentMenuItem.Text = "Add after current selection";
            this.NewFieldAfterCurrentMenuItem.Click += new System.EventHandler(this.NewFieldAfterCurrentMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // NewCurrentSelectionMenuItem
            // 
            this.NewCurrentSelectionMenuItem.Name = "NewCurrentSelectionMenuItem";
            this.NewCurrentSelectionMenuItem.Size = new System.Drawing.Size(214, 22);
            this.NewCurrentSelectionMenuItem.Text = "Add with current selection";
            this.NewCurrentSelectionMenuItem.Click += new System.EventHandler(this.NewCurrentSelectionMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
            // 
            // NewFieldDefaultSelectionMenuItem
            // 
            this.NewFieldDefaultSelectionMenuItem.Name = "NewFieldDefaultSelectionMenuItem";
            this.NewFieldDefaultSelectionMenuItem.Size = new System.Drawing.Size(214, 22);
            this.NewFieldDefaultSelectionMenuItem.Text = "Add with default selection";
            this.NewFieldDefaultSelectionMenuItem.Click += new System.EventHandler(this.NewFieldDefaultSelectionMenuItem_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.ColumnSelector2TabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(750, 509);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.ColumnSelector2TabPage,
            this.ColumnSelector3TabPage});
            // 
            // ColumnSelector2TabPage
            // 
            this.ColumnSelector2TabPage.Controls.Add(this.pSelection);
            this.ColumnSelector2TabPage.Controls.Add(this.pBottom);
            this.ColumnSelector2TabPage.Controls.Add(this.pShow);
            this.ColumnSelector2TabPage.Name = "ColumnSelector2TabPage";
            this.ColumnSelector2TabPage.Size = new System.Drawing.Size(609, 486);
            this.ColumnSelector2TabPage.Text = "Column Selector V2";
            // 
            // ColumnSelector3TabPage
            // 
            this.ColumnSelector3TabPage.Controls.Add(this.layoutControl1);
            this.ColumnSelector3TabPage.Name = "ColumnSelector3TabPage";
            this.ColumnSelector3TabPage.Size = new System.Drawing.Size(748, 486);
            this.ColumnSelector3TabPage.Text = "Column Selector V3";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pColumnSelector3);
            this.layoutControl1.Controls.Add(this.Selector3ToggleSwitch);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(748, 486);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(748, 486);
            this.Root.Text = "Enable";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(12, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(138, 22);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton2;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(142, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(142, 418);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Selector3ToggleSwitch
            // 
            this.Selector3ToggleSwitch.Location = new System.Drawing.Point(56, 38);
            this.Selector3ToggleSwitch.Name = "Selector3ToggleSwitch";
            this.Selector3ToggleSwitch.Properties.OffText = "Off";
            this.Selector3ToggleSwitch.Properties.OnText = "On";
            this.Selector3ToggleSwitch.Size = new System.Drawing.Size(94, 18);
            this.Selector3ToggleSwitch.StyleController = this.layoutControl1;
            this.Selector3ToggleSwitch.TabIndex = 5;
            this.Selector3ToggleSwitch.Toggled += new System.EventHandler(this.Selector3ToggleSwitch_Toggled);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Selector3ToggleSwitch;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(142, 22);
            this.layoutControlItem2.Text = "Enable";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(32, 13);
            // 
            // pColumnSelector3
            // 
            this.pColumnSelector3.Location = new System.Drawing.Point(154, 12);
            this.pColumnSelector3.Name = "pColumnSelector3";
            this.pColumnSelector3.Size = new System.Drawing.Size(582, 462);
            this.pColumnSelector3.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pColumnSelector3;
            this.layoutControlItem3.Location = new System.Drawing.Point(142, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(586, 466);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 509);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataFileFieldGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataFileFieldGridView)).EndInit();
            this.pTable.ResumeLayout(false);
            this.pControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pShow.ResumeLayout(false);
            this.pSelection.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.FieldContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ColumnSelector2TabPage.ResumeLayout(false);
            this.ColumnSelector3TabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Selector3ToggleSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl DataFileFieldGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView DataFileFieldGridView;
        private ColumnSelectorControlV2 FileColumnSelector;
        private System.Windows.Forms.Panel pTable;
        private DevExpress.XtraEditors.SimpleButton bClear;
        private DevExpress.XtraEditors.SimpleButton bReload;
        private DevExpress.XtraEditors.SimpleButton bAdd;
        private DevExpress.XtraEditors.SimpleButton bModify;
        private DevExpress.XtraEditors.SimpleButton bDel;
        private DevExpress.XtraEditors.SimpleButton bShow;
        private System.Windows.Forms.Panel pControls;
        private System.Windows.Forms.Panel pShow;
        private System.Windows.Forms.Panel pSelection;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton bSort;
        private DevExpress.XtraEditors.SimpleButton bTest;
        private DevExpress.XtraEditors.SimpleButton bMoveUp;
        private DevExpress.XtraEditors.SimpleButton bMoveDown;
        private DevExpress.XtraEditors.SimpleButton bTest2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ContextMenuStrip FieldContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NewFieldDefaultSelectionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem NewCurrentSelectionMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem NewFieldAfterCurrentMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage ColumnSelector2TabPage;
        private DevExpress.XtraTab.XtraTabPage ColumnSelector3TabPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.Panel pColumnSelector3;
        private DevExpress.XtraEditors.ToggleSwitch Selector3ToggleSwitch;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

