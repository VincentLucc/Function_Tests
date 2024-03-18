namespace SkiaSharp
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bDrawSkia = new DevExpress.XtraEditors.SimpleButton();
            this.SkiaPictureBox = new System.Windows.Forms.PictureBox();
            this.GDIPictureBox = new System.Windows.Forms.PictureBox();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.SkiaControl1 = new SkiaSharp.Views.Desktop.SKControl();
            this.SkiaGLControl = new SkiaSharp.Views.Desktop.SKGLControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkiaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDIPictureBox)).BeginInit();
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
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
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
            this.barDockControlTop.Size = new System.Drawing.Size(720, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(720, 19);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 523);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(720, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 523);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 41);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(720, 523);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.tableLayoutPanel1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(718, 500);
            this.xtraTabPage1.Text = "Compare";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bDrawSkia, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.SkiaPictureBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.GDIPictureBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.SkiaControl1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.SkiaGLControl, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 500);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // bDrawSkia
            // 
            this.bDrawSkia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bDrawSkia.Location = new System.Drawing.Point(147, 13);
            this.bDrawSkia.MaximumSize = new System.Drawing.Size(120, 0);
            this.bDrawSkia.MinimumSize = new System.Drawing.Size(0, 24);
            this.bDrawSkia.Name = "bDrawSkia";
            this.bDrawSkia.Size = new System.Drawing.Size(85, 24);
            this.bDrawSkia.TabIndex = 2;
            this.bDrawSkia.Text = "Draw";
            this.bDrawSkia.Click += new System.EventHandler(this.bDrawSkia_Click);
            // 
            // SkiaPictureBox
            // 
            this.SkiaPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkiaPictureBox.Location = new System.Drawing.Point(23, 43);
            this.SkiaPictureBox.Name = "SkiaPictureBox";
            this.SkiaPictureBox.Size = new System.Drawing.Size(333, 204);
            this.SkiaPictureBox.TabIndex = 0;
            this.SkiaPictureBox.TabStop = false;
            // 
            // GDIPictureBox
            // 
            this.GDIPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GDIPictureBox.Location = new System.Drawing.Point(362, 43);
            this.GDIPictureBox.Name = "GDIPictureBox";
            this.GDIPictureBox.Size = new System.Drawing.Size(333, 204);
            this.GDIPictureBox.TabIndex = 1;
            this.GDIPictureBox.TabStop = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(718, 402);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // SkiaControl1
            // 
            this.SkiaControl1.BackColor = System.Drawing.Color.Black;
            this.SkiaControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkiaControl1.Location = new System.Drawing.Point(23, 283);
            this.SkiaControl1.Name = "SkiaControl1";
            this.SkiaControl1.Size = new System.Drawing.Size(333, 204);
            this.SkiaControl1.TabIndex = 3;
            this.SkiaControl1.Text = "skControl1";
            // 
            // SkiaGLControl
            // 
            this.SkiaGLControl.BackColor = System.Drawing.Color.Black;
            this.SkiaGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkiaGLControl.Location = new System.Drawing.Point(362, 283);
            this.SkiaGLControl.Name = "SkiaGLControl";
            this.SkiaGLControl.Size = new System.Drawing.Size(333, 204);
            this.SkiaGLControl.TabIndex = 4;
            this.SkiaGLControl.VSync = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 253);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Skia Control";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(362, 253);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Skia OpenGL Control";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 583);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkiaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GDIPictureBox)).EndInit();
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
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.PictureBox SkiaPictureBox;
        private System.Windows.Forms.PictureBox GDIPictureBox;
        private DevExpress.XtraEditors.SimpleButton bDrawSkia;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Views.Desktop.SKControl SkiaControl1;
        private Views.Desktop.SKGLControl SkiaGLControl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}

