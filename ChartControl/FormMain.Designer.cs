
namespace ChartControl
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.MainTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.HistogramTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.SeriesSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.bHisto = new DevExpress.XtraEditors.SimpleButton();
            this.HistoChartControl = new DevExpress.XtraCharts.ChartControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.TimelineTabPage = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.CameraLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.RotateChartButton = new DevExpress.XtraEditors.SimpleButton();
            this.ProcessTimeChartButton = new DevExpress.XtraEditors.SimpleButton();
            this.TimeChartControl = new DevExpress.XtraCharts.ChartControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.HistogramTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SeriesSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.TimelineTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(16, 15);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(86, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "View: Pie View";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.MainTabPage;
            this.xtraTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.MainTabPage,
            this.HistogramTabPage,
            this.TimelineTabPage});
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.simpleButton1);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Size = new System.Drawing.Size(798, 426);
            this.MainTabPage.Text = "Main Page";
            // 
            // HistogramTabPage
            // 
            this.HistogramTabPage.Controls.Add(this.layoutControl1);
            this.HistogramTabPage.Name = "HistogramTabPage";
            this.HistogramTabPage.Size = new System.Drawing.Size(798, 426);
            this.HistogramTabPage.Text = "Histogram";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.SeriesSpinEdit);
            this.layoutControl1.Controls.Add(this.simpleButton3);
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.bHisto);
            this.layoutControl1.Controls.Add(this.HistoChartControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(798, 426);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // SeriesSpinEdit
            // 
            this.SeriesSpinEdit.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeriesSpinEdit.Location = new System.Drawing.Point(309, 12);
            this.SeriesSpinEdit.Name = "SeriesSpinEdit";
            this.SeriesSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SeriesSpinEdit.Properties.MaxValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SeriesSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SeriesSpinEdit.Size = new System.Drawing.Size(149, 22);
            this.SeriesSpinEdit.StyleController = this.layoutControl1;
            this.SeriesSpinEdit.TabIndex = 8;
            this.SeriesSpinEdit.EditValueChanged += new System.EventHandler(this.SeriesSpinEdit_EditValueChanged);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(180, 12);
            this.simpleButton3.MaximumSize = new System.Drawing.Size(80, 0);
            this.simpleButton3.MinimumSize = new System.Drawing.Size(80, 0);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(80, 22);
            this.simpleButton3.StyleController = this.layoutControl1;
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Stop Update";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(96, 12);
            this.simpleButton2.MaximumSize = new System.Drawing.Size(80, 0);
            this.simpleButton2.MinimumSize = new System.Drawing.Size(80, 0);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(80, 22);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Start Update";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // bHisto
            // 
            this.bHisto.Location = new System.Drawing.Point(12, 12);
            this.bHisto.MaximumSize = new System.Drawing.Size(80, 0);
            this.bHisto.MinimumSize = new System.Drawing.Size(80, 0);
            this.bHisto.Name = "bHisto";
            this.bHisto.Size = new System.Drawing.Size(80, 22);
            this.bHisto.StyleController = this.layoutControl1;
            this.bHisto.TabIndex = 4;
            this.bHisto.Text = "Init Histo Chart";
            this.bHisto.Click += new System.EventHandler(this.bHisto_Click);
            // 
            // HistoChartControl
            // 
            xyDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            xyDiagram1.AxisX.TimeSpanScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.WholeRange.EndSideMargin = 0D;
            xyDiagram1.AxisX.WholeRange.StartSideMargin = 0D;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.HistoChartControl.Diagram = xyDiagram1;
            this.HistoChartControl.Location = new System.Drawing.Point(12, 38);
            this.HistoChartControl.Name = "HistoChartControl";
            series1.Name = "Series 1";
            areaSeriesView1.EmptyPointOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            areaSeriesView1.Transparency = ((byte)(0));
            series1.View = areaSeriesView1;
            this.HistoChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.HistoChartControl.Size = new System.Drawing.Size(774, 376);
            this.HistoChartControl.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem10});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(798, 426);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.HistoChartControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(778, 380);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.bHisto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(450, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(328, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton2;
            this.layoutControlItem3.Location = new System.Drawing.Point(84, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton3;
            this.layoutControlItem4.Location = new System.Drawing.Point(168, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.SeriesSpinEdit;
            this.layoutControlItem10.Location = new System.Drawing.Point(252, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(198, 26);
            this.layoutControlItem10.Text = "Series:";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(33, 13);
            // 
            // TimelineTabPage
            // 
            this.TimelineTabPage.Controls.Add(this.layoutControl2);
            this.TimelineTabPage.Name = "TimelineTabPage";
            this.TimelineTabPage.Size = new System.Drawing.Size(798, 426);
            this.TimelineTabPage.Text = "Process Time";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.CameraLookUpEdit);
            this.layoutControl2.Controls.Add(this.RotateChartButton);
            this.layoutControl2.Controls.Add(this.ProcessTimeChartButton);
            this.layoutControl2.Controls.Add(this.TimeChartControl);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup1;
            this.layoutControl2.Size = new System.Drawing.Size(798, 426);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // CameraLookUpEdit
            // 
            this.CameraLookUpEdit.Location = new System.Drawing.Point(269, 12);
            this.CameraLookUpEdit.Name = "CameraLookUpEdit";
            this.CameraLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CameraLookUpEdit.Size = new System.Drawing.Size(232, 22);
            this.CameraLookUpEdit.StyleController = this.layoutControl2;
            this.CameraLookUpEdit.TabIndex = 7;
            this.CameraLookUpEdit.EditValueChanged += new System.EventHandler(this.CameraLookUpEdit_EditValueChanged);
            // 
            // RotateChartButton
            // 
            this.RotateChartButton.Location = new System.Drawing.Point(116, 12);
            this.RotateChartButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.RotateChartButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.RotateChartButton.Name = "RotateChartButton";
            this.RotateChartButton.Size = new System.Drawing.Size(100, 22);
            this.RotateChartButton.StyleController = this.layoutControl2;
            this.RotateChartButton.TabIndex = 6;
            this.RotateChartButton.Text = "Rotate Chart";
            this.RotateChartButton.Click += new System.EventHandler(this.RotateChartButton_Click);
            // 
            // ProcessTimeChartButton
            // 
            this.ProcessTimeChartButton.Location = new System.Drawing.Point(12, 12);
            this.ProcessTimeChartButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.ProcessTimeChartButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.ProcessTimeChartButton.Name = "ProcessTimeChartButton";
            this.ProcessTimeChartButton.Size = new System.Drawing.Size(100, 22);
            this.ProcessTimeChartButton.StyleController = this.layoutControl2;
            this.ProcessTimeChartButton.TabIndex = 5;
            this.ProcessTimeChartButton.Text = "Init TimeLine Chart";
            this.ProcessTimeChartButton.Click += new System.EventHandler(this.ProcessTimeChartButton_Click);
            // 
            // TimeChartControl
            // 
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.TimeChartControl.Diagram = xyDiagram2;
            this.TimeChartControl.Location = new System.Drawing.Point(12, 38);
            this.TimeChartControl.Name = "TimeChartControl";
            series2.Name = "Series 1";
            this.TimeChartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.TimeChartControl.Size = new System.Drawing.Size(774, 376);
            this.TimeChartControl.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(798, 426);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.TimeChartControl;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(778, 380);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ProcessTimeChartButton;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.RotateChartButton;
            this.layoutControlItem7.Location = new System.Drawing.Point(104, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.CameraLookUpEdit;
            this.layoutControlItem8.Location = new System.Drawing.Point(208, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(285, 26);
            this.layoutControlItem8.Text = "Camera";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(37, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(493, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(285, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.HistogramTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SeriesSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistoChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.TimelineTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CameraLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage MainTabPage;
        private DevExpress.XtraTab.XtraTabPage HistogramTabPage;
        private DevExpress.XtraCharts.ChartControl HistoChartControl;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton bHisto;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraTab.XtraTabPage TimelineTabPage;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraCharts.ChartControl TimeChartControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton ProcessTimeChartButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton RotateChartButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LookUpEdit CameraLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SpinEdit SeriesSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
    }
}

