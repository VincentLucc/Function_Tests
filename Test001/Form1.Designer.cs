
namespace Test001
{
    partial class Form1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnSelectorControl1 = new Test001.ColumnSelectorControlSingle();
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
            this.pShow = new System.Windows.Forms.Panel();
            this.bTest = new DevExpress.XtraEditors.SimpleButton();
            this.pSelection = new System.Windows.Forms.Panel();
            this.pBottom = new System.Windows.Forms.Panel();
            this.bMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.bMoveDown = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pTable.SuspendLayout();
            this.pControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pShow.SuspendLayout();
            this.pSelection.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(408, 250);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "123";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // columnSelectorControl1
            // 
            this.columnSelectorControl1.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.columnSelectorControl1.Appearance.Font = new System.Drawing.Font("Consolas", 12F);
            this.columnSelectorControl1.Appearance.Options.UseBorderColor = true;
            this.columnSelectorControl1.Appearance.Options.UseFont = true;
            this.columnSelectorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnSelectorControl1.FontSize = 12F;
            this.columnSelectorControl1.Location = new System.Drawing.Point(0, 0);
            this.columnSelectorControl1.Margin = new System.Windows.Forms.Padding(4);
            this.columnSelectorControl1.MarkerColor = System.Drawing.Color.Gray;
            this.columnSelectorControl1.MaxAllowedColumns = 32;
            this.columnSelectorControl1.Name = "columnSelectorControl1";
            this.columnSelectorControl1.Padding = new System.Windows.Forms.Padding(4);
            this.columnSelectorControl1.Size = new System.Drawing.Size(611, 223);
            this.columnSelectorControl1.TabIndex = 1;
            this.columnSelectorControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.columnSelectorControl1_MouseDown);
            this.columnSelectorControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.columnSelectorControl1_MouseUp);
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
            this.pTable.Controls.Add(this.gridControl1);
            this.pTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTable.Location = new System.Drawing.Point(203, 0);
            this.pTable.Name = "pTable";
            this.pTable.Size = new System.Drawing.Size(408, 250);
            this.pTable.TabIndex = 5;
            // 
            // pControls
            // 
            this.pControls.Controls.Add(this.tableLayoutPanel1);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pControls.Location = new System.Drawing.Point(0, 0);
            this.pControls.Name = "pControls";
            this.pControls.Size = new System.Drawing.Size(203, 250);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 250);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // bSort
            // 
            this.bSort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bSort.Location = new System.Drawing.Point(125, 81);
            this.bSort.Name = "bSort";
            this.bSort.Size = new System.Drawing.Size(54, 23);
            this.bSort.TabIndex = 8;
            this.bSort.Text = "Sort";
            this.bSort.Click += new System.EventHandler(this.bSort_Click);
            // 
            // bDel
            // 
            this.bDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bDel.Location = new System.Drawing.Point(23, 44);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(54, 23);
            this.bDel.TabIndex = 7;
            this.bDel.Text = "Delete";
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bClear
            // 
            this.bClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bClear.Location = new System.Drawing.Point(23, 81);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(54, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bReload
            // 
            this.bReload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bReload.Location = new System.Drawing.Point(125, 44);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(54, 23);
            this.bReload.TabIndex = 4;
            this.bReload.Text = "Reload";
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bAdd.Location = new System.Drawing.Point(23, 7);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(54, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bModify
            // 
            this.bModify.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bModify.Location = new System.Drawing.Point(125, 7);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(54, 23);
            this.bModify.TabIndex = 6;
            this.bModify.Text = "Modify";
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // pShow
            // 
            this.pShow.Controls.Add(this.bTest);
            this.pShow.Controls.Add(this.bShow);
            this.pShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pShow.Location = new System.Drawing.Point(0, 223);
            this.pShow.Name = "pShow";
            this.pShow.Size = new System.Drawing.Size(611, 36);
            this.pShow.TabIndex = 6;
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
            this.pSelection.Controls.Add(this.columnSelectorControl1);
            this.pSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelection.Location = new System.Drawing.Point(0, 0);
            this.pSelection.Name = "pSelection";
            this.pSelection.Size = new System.Drawing.Size(611, 223);
            this.pSelection.TabIndex = 7;
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.pTable);
            this.pBottom.Controls.Add(this.pControls);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 259);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(611, 250);
            this.pBottom.TabIndex = 2;
            this.pBottom.Visible = false;
            // 
            // bMoveUp
            // 
            this.bMoveUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bMoveUp.Location = new System.Drawing.Point(116, 118);
            this.bMoveUp.Name = "bMoveUp";
            this.bMoveUp.Size = new System.Drawing.Size(72, 23);
            this.bMoveUp.TabIndex = 9;
            this.bMoveUp.Text = "MoveUp";
            this.bMoveUp.Click += new System.EventHandler(this.bMoveUp_Click);
            // 
            // bMoveDown
            // 
            this.bMoveDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bMoveDown.Location = new System.Drawing.Point(116, 155);
            this.bMoveDown.Name = "bMoveDown";
            this.bMoveDown.Size = new System.Drawing.Size(72, 23);
            this.bMoveDown.TabIndex = 10;
            this.bMoveDown.Text = "MoveDown";
            this.bMoveDown.Click += new System.EventHandler(this.bMoveDown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 509);
            this.Controls.Add(this.pSelection);
            this.Controls.Add(this.pShow);
            this.Controls.Add(this.pBottom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pTable.ResumeLayout(false);
            this.pControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pShow.ResumeLayout(false);
            this.pSelection.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private ColumnSelectorControlSingle columnSelectorControl1;
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
    }
}

