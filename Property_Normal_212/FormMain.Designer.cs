
namespace Property_Normal_212
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
            this.bClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bClearItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pCenter = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pg1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCenter)).BeginInit();
            this.pCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pg1
            // 
            this.pg1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg1.Location = new System.Drawing.Point(0, 0);
            this.pg1.Name = "pg1";
            this.pg1.OptionsBehavior.AutoPostEditorDelay = 1000;
            this.pg1.OptionsCollectionEditor.AllowMultiSelect = false;
            this.pg1.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            this.pg1.Size = new System.Drawing.Size(450, 313);
            this.pg1.TabIndex = 0;
            this.pg1.Click += new System.EventHandler(this.propertyGridControl1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pg1);
            this.panel1.Controls.Add(this.pd1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(423, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 393);
            this.panel1.TabIndex = 1;
            // 
            // pd1
            // 
            this.pd1.Appearance.Panel.BorderColor = System.Drawing.Color.Blue;
            this.pd1.Appearance.Panel.Options.UseBorderColor = true;
            this.pd1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pd1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pd1.Location = new System.Drawing.Point(0, 313);
            this.pd1.Name = "pd1";
            this.pd1.Size = new System.Drawing.Size(450, 80);
            this.pd1.TabIndex = 1;
            this.pd1.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(0, 150);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(149, 393);
            this.lb1.TabIndex = 2;
            this.lb1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // te1
            // 
            this.te1.Location = new System.Drawing.Point(6, 8);
            this.te1.Name = "te1";
            this.te1.Size = new System.Drawing.Size(100, 20);
            this.te1.TabIndex = 3;
            this.te1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(6, 34);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 5;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.ribbonControl1.Size = new System.Drawing.Size(873, 150);
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
            // pCenter
            // 
            this.pCenter.Controls.Add(this.te1);
            this.pCenter.Controls.Add(this.button1);
            this.pCenter.Controls.Add(this.bClear);
            this.pCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCenter.Location = new System.Drawing.Point(149, 150);
            this.pCenter.Name = "pCenter";
            this.pCenter.Size = new System.Drawing.Size(274, 393);
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
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
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
    }
}

