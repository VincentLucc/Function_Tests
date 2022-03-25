
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomEditor));
            this.TemplateGridControl = new DevExpress.XtraGrid.GridControl();
            this.TemplateGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // TemplateGridControl
            // 
            this.TemplateGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateGridControl.Location = new System.Drawing.Point(0, 0);
            this.TemplateGridControl.MainView = this.TemplateGridView;
            this.TemplateGridControl.Name = "TemplateGridControl";
            this.TemplateGridControl.Size = new System.Drawing.Size(800, 450);
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
            // CustomEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TemplateGridControl);
            this.Name = "CustomEditor";
            this.Text = "CustomEditor";
            this.Load += new System.EventHandler(this.CustomEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl TemplateGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView TemplateGridView;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}