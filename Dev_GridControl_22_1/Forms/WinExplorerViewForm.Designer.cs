namespace Dev_GridControl_22_1.Forms
{
    partial class WinExplorerViewForm
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
            DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
            DevExpress.Utils.ContextButton contextButton2 = new DevExpress.Utils.ContextButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinExplorerViewForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView1 = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.winExplorerView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(646, 500);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView1});
            // 
            // winExplorerView1
            // 
            this.winExplorerView1.ContextButtonOptions.TopPanelPadding = new System.Windows.Forms.Padding(0);
            contextButton1.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right;
            contextButton1.Id = new System.Guid("af1c6564-62a4-40aa-90ad-c32841c5bc56");
            contextButton1.ImageOptionsCollection.ItemNormal.Image = global::Dev_GridControl_22_1.Properties.Resources.about_16x16;
            contextButton1.Name = "contextButton1";
            contextButton2.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far;
            contextButton2.Id = new System.Guid("e760e57d-23b2-4e7c-b3fe-6a1fc969a944");
            contextButton2.ImageOptionsCollection.ItemNormal.Image = global::Dev_GridControl_22_1.Properties.Resources.cancel_16x16;
            contextButton2.Name = "contextButtonDelete";
            this.winExplorerView1.ContextButtons.Add(contextButton1);
            this.winExplorerView1.ContextButtons.Add(contextButton2);
            this.winExplorerView1.GridControl = this.gridControl1;
            this.winExplorerView1.Name = "winExplorerView1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "add_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "remove_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "cancel_16x16.png");
            this.imageCollection1.Images.SetKeyName(3, "apply_16x16.png");
            // 
            // WinExplorerViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 500);
            this.Controls.Add(this.gridControl1);
            this.Name = "WinExplorerViewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WinExplorerViewForm";
            this.Load += new System.EventHandler(this.WinExplorerViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}