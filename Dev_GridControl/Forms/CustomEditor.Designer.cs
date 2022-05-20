
namespace Dev_GridControl
{
    partial class CustomEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomEditor));
            this.TemplateGridControl = new DevExpress.XtraGrid.GridControl();
            this.TemplateGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.bMultiSelect = new DevExpress.XtraEditors.SimpleButton();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // TemplateGridControl
            // 
            this.TemplateGridControl.Location = new System.Drawing.Point(6, 6);
            this.TemplateGridControl.MainView = this.TemplateGridView;
            this.TemplateGridControl.Name = "TemplateGridControl";
            this.TemplateGridControl.Size = new System.Drawing.Size(684, 438);
            this.TemplateGridControl.TabIndex = 0;
            this.TemplateGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.TemplateGridView});
            // 
            // TemplateGridView
            // 
            this.TemplateGridView.GridControl = this.TemplateGridControl;
            this.TemplateGridView.Name = "TemplateGridView";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::Dev_GridControl.Properties.Resources.apply_32x321, "apply_32x321", typeof(global::Dev_GridControl.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "apply_32x321");
            this.imageCollection1.InsertImage(global::Dev_GridControl.Properties.Resources.cancel_32x32, "cancel_32x32", typeof(global::Dev_GridControl.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "cancel_32x32");
            this.imageCollection1.InsertImage(global::Dev_GridControl.Properties.Resources.clear_32x32, "clear_32x32", typeof(global::Dev_GridControl.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "clear_32x32");
            this.imageCollection1.Images.SetKeyName(3, "Picture1.png");
            this.imageCollection1.InsertImage(global::Dev_GridControl.Properties.Resources.apply_32x32, "apply_32x32", typeof(global::Dev_GridControl.Properties.Resources), 4);
            this.imageCollection1.Images.SetKeyName(4, "apply_32x32");
            // 
            // bMultiSelect
            // 
            this.bMultiSelect.Location = new System.Drawing.Point(692, 6);
            this.bMultiSelect.Name = "bMultiSelect";
            this.bMultiSelect.Size = new System.Drawing.Size(102, 22);
            this.bMultiSelect.StyleController = this.lcMain;
            this.bMultiSelect.TabIndex = 1;
            this.bMultiSelect.Text = "MultiSelect";
            this.bMultiSelect.Click += new System.EventHandler(this.bMultiSelect_Click);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.bMultiSelect);
            this.lcMain.Controls.Add(this.TemplateGridControl);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.Root;
            this.lcMain.Size = new System.Drawing.Size(800, 450);
            this.lcMain.TabIndex = 2;
            this.lcMain.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.TemplateGridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(686, 440);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.bMultiSelect;
            this.layoutControlItem2.Location = new System.Drawing.Point(686, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(104, 440);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // CustomEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lcMain);
            this.Name = "CustomEditor";
            this.Text = "CustomEditor";
            this.Load += new System.EventHandler(this.CustomEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl TemplateGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView TemplateGridView;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton bMultiSelect;
        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}