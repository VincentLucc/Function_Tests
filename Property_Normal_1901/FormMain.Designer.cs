
namespace Property_Normal_Dev191
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pg1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pd1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.te1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bClearItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pCenter = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pg1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCenter)).BeginInit();
            this.pCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pg1
            // 
            this.pg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg1.Location = new System.Drawing.Point(0, 0);
            this.pg1.Name = "pg1";
            this.pg1.OptionsBehavior.AutoPostEditorDelay = 1000;
            this.pg1.OptionsCollectionEditor.AllowMultiSelect = false;
            this.pg1.Size = new System.Drawing.Size(450, 317);
            this.pg1.TabIndex = 0;
            this.pg1.Click += new System.EventHandler(this.propertyGridControl1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pg1);
            this.panel1.Controls.Add(this.pd1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(423, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 397);
            this.panel1.TabIndex = 1;
            // 
            // pd1
            // 
            this.pd1.Appearance.Panel.BorderColor = System.Drawing.Color.Blue;
            this.pd1.Appearance.Panel.Options.UseBorderColor = true;
            this.pd1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pd1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pd1.Location = new System.Drawing.Point(0, 317);
            this.pd1.Name = "pd1";
            this.pd1.Size = new System.Drawing.Size(450, 80);
            this.pd1.TabIndex = 1;
            this.pd1.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(0, 146);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(149, 397);
            this.lb1.TabIndex = 2;
            this.lb1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // te1
            // 
            this.te1.Location = new System.Drawing.Point(128, 12);
            this.te1.Name = "te1";
            this.te1.Size = new System.Drawing.Size(59, 20);
            this.te1.StyleController = this.layoutControl1;
            this.te1.TabIndex = 3;
            this.te1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.bClear);
            this.layoutControl1.Controls.Add(this.button1);
            this.layoutControl1.Controls.Add(this.te1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(270, 393);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "0";
            this.textEdit1.Location = new System.Drawing.Point(128, 60);
            this.textEdit1.MenuManager = this.ribbonControl1;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Mask.EditMask = "####0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Size = new System.Drawing.Size(130, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 6;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bClearItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(873, 146);
            // 
            // bClearItem
            // 
            this.bClearItem.Caption = "Clear";
            this.bClearItem.Id = 1;
            this.bClearItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bClearItem.ImageOptions.Image")));
            this.bClearItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bClearItem.ImageOptions.LargeImage")));
            this.bClearItem.Name = "bClearItem";
            this.bClearItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bClearItem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Function Group";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bClearItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tests";
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(137, 36);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(121, 20);
            this.bClear.TabIndex = 5;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(270, 393);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.te1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(179, 24);
            this.layoutControlItem1.Text = "Text:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(113, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(250, 301);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.button1;
            this.layoutControlItem2.Location = new System.Drawing.Point(179, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(71, 24);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bClear;
            this.layoutControlItem3.Location = new System.Drawing.Point(125, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(125, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(125, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(250, 24);
            this.layoutControlItem4.Text = "Number Mask \"####0\"";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(113, 13);
            // 
            // pCenter
            // 
            this.pCenter.Controls.Add(this.layoutControl1);
            this.pCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCenter.Location = new System.Drawing.Point(149, 146);
            this.pCenter.Name = "pCenter";
            this.pCenter.Size = new System.Drawing.Size(274, 397);
            this.pCenter.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 543);
            this.Controls.Add(this.pCenter);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pg1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCenter)).EndInit();
            this.pCenter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl pg1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl pd1;
        private System.Windows.Forms.ListBox lb1;
        private DevExpress.XtraEditors.TextEdit te1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bClear;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bClearItem;
        private DevExpress.XtraEditors.PanelControl pCenter;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}

