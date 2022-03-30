
namespace DocumentManager
{
    partial class WinUIView
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
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.windowsUIView1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView(this.components);
            this.tileContainer1 = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer(this.components);
            this.uc2Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.uc2Document = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.uc1Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            this.uc1Document = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.uC3Document = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document(this.components);
            this.UC3Tile = new DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc2Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc2Document)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc1Tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc1Document)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uC3Document)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UC3Tile)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.windowsUIView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.windowsUIView1});
            // 
            // windowsUIView1
            // 
            this.windowsUIView1.ContentContainers.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.IContentContainer[] {
            this.tileContainer1});
            this.windowsUIView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.uc2Document,
            this.uc1Document,
            this.uC3Document});
            this.windowsUIView1.Tiles.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.uc2Tile,
            this.uc1Tile,
            this.UC3Tile});
            // 
            // tileContainer1
            // 
            this.tileContainer1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.WindowsUI.BaseTile[] {
            this.uc2Tile,
            this.uc1Tile,
            this.UC3Tile});
            this.tileContainer1.Name = "tileContainer1";
            // 
            // uc2Tile
            // 
            this.uc2Tile.Document = this.uc2Document;
            this.uc2Tile.Name = "uc2Tile";
            // 
            // uc2Document
            // 
            this.uc2Document.Caption = "uc2";
            this.uc2Document.ControlName = "uc2";
            this.uc2Document.ControlTypeName = "DocumentManager.uc2";
            // 
            // uc1Tile
            // 
            this.uc1Tile.Document = this.uc1Document;
            this.tileContainer1.SetID(this.uc1Tile, 1);
            this.uc1Tile.Name = "uc1Tile";
            // 
            // uc1Document
            // 
            this.uc1Document.Caption = "uc1";
            this.uc1Document.ControlName = "uc1";
            this.uc1Document.ControlTypeName = "DocumentManager.uc1";
            // 
            // uC3Document
            // 
            this.uC3Document.Caption = "UC3";
            this.uC3Document.ControlName = "UC3";
            this.uC3Document.ControlTypeName = "DocumentManager.Controls.UC3";
            // 
            // UC3Tile
            // 
            this.UC3Tile.Document = this.uC3Document;
            this.tileContainer1.SetID(this.UC3Tile, 2);
            this.UC3Tile.Name = "UC3Tile";
            // 
            // WinUIView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 496);
            this.Name = "WinUIView";
            this.Text = "TestForm2";
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowsUIView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc2Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc2Document)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc1Tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uc1Document)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uC3Document)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UC3Tile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.WindowsUIView windowsUIView1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.TileContainer tileContainer1;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile uc2Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document uc2Document;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile uc1Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document uc1Document;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Tile UC3Tile;
        private DevExpress.XtraBars.Docking2010.Views.WindowsUI.Document uC3Document;
    }
}