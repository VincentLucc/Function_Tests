using System;
using System.Collections.Generic;
using System.Text;

namespace PDF_Editor {
    public partial class csSimpleReport {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView2 = new DevExpress.XtraCharts.PieSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(csSimpleReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.panel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.pageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.chart1 = new DevExpress.XtraReports.UI.XRChart();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.pageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.pageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.panel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.panel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.pictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.HeightF = 149.9053F;
            this.Detail.MultiColumn.ColumnCount = 3;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 38.75001F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 17F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.GroupHeader1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "?isGroupedParameter")});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Floor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 53.0303F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Expanded = false;
            this.GroupFooter1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "?isGroupedParameter"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "PageBreak", "Iif(?columnLayoutParameter, \'None\', \'AfterBandExceptLastEntry\')")});
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel1,
            this.pageBreak1});
            this.ReportHeader.HeightF = 796.4583F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pageInfo2,
            this.label1,
            this.pageInfo1});
            this.PageFooter.HeightF = 60.77665F;
            this.PageFooter.Name = "PageFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.pageInfo3});
            this.PageHeader.HeightF = 57.29167F;
            this.PageHeader.Name = "PageHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Name = "ReportFooter";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.DataMember = "Items";
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(9.999983F, 26.90532F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(196.9328F, 26.12498F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.Text = "FLOOR [Floor]";
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.chart1,
            this.table1,
            this.pictureBox1});
            this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(101.0417F, 156.7813F);
            this.panel1.Name = "panel1";
            this.panel1.SizeF = new System.Drawing.SizeF(446.875F, 478.9374F);
            // 
            // pageBreak1
            // 
            this.pageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 682.5833F);
            this.pageBreak1.Name = "pageBreak1";
            // 
            // chart1
            // 
            this.chart1.BorderColor = System.Drawing.Color.Black;
            this.chart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.chart1.Legend.Title.Text = "Statistics";
            this.chart1.Legend.Title.Visible = true;
            this.chart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 186.8751F);
            this.chart1.Name = "chart1";
            this.chart1.PaletteName = "JobStatisticsPalette";
            this.chart1.PaletteRepository.Add("JobStatisticsPalette", new DevExpress.XtraCharts.Palette("JobStatisticsPalette", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver)}));
            series1.ArgumentDataMember = "JobStatistics.Name";
            series1.LegendTextPattern = "{A}: {V}";
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "JobStatistics.Value";
            series1.View = pieSeriesView1;
            this.chart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chart1.SeriesTemplate.View = pieSeriesView2;
            this.chart1.SizeF = new System.Drawing.SizeF(446.875F, 292.0624F);
            // 
            // table1
            // 
            this.table1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(73.4375F, 84.79172F);
            this.table1.Name = "table1";
            this.table1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1,
            this.tableRow2,
            this.tableRow3});
            this.table1.SizeF = new System.Drawing.SizeF(300F, 75F);
            this.table1.StylePriority.UseBorders = false;
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2});
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell3,
            this.tableCell4});
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 1D;
            // 
            // tableRow3
            // 
            this.tableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell5,
            this.tableCell6});
            this.tableRow3.Name = "tableRow3";
            this.tableRow3.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.Multiline = true;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.Text = "Product Name";
            this.tableCell1.Weight = 1D;
            // 
            // tableCell2
            // 
            this.tableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[JobInfo].[ProductName]")});
            this.tableCell2.Multiline = true;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.Text = "tableCell2";
            this.tableCell2.Weight = 2D;
            // 
            // tableCell3
            // 
            this.tableCell3.Multiline = true;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.Text = "Time";
            this.tableCell3.Weight = 1D;
            // 
            // tableCell4
            // 
            this.tableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[JobInfo].[ReportTime]")});
            this.tableCell4.Multiline = true;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.Weight = 2D;
            // 
            // tableCell5
            // 
            this.tableCell5.Multiline = true;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.Text = "User";
            this.tableCell5.Weight = 1D;
            // 
            // tableCell6
            // 
            this.tableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[JobInfo].[UserName]")});
            this.tableCell6.Multiline = true;
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.Text = "tableCell6";
            this.tableCell6.Weight = 2D;
            // 
            // pageInfo2
            // 
            this.pageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 27.77666F);
            this.pageInfo2.Name = "pageInfo2";
            this.pageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.pageInfo2.SizeF = new System.Drawing.SizeF(186.4583F, 23F);
            // 
            // label1
            // 
            this.label1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.label1.Multiline = true;
            this.label1.Name = "label1";
            this.label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label1.Text = "PackSmart Inc.";
            // 
            // pageInfo1
            // 
            this.pageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(527F, 0F);
            this.pageInfo1.Name = "pageInfo1";
            this.pageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageInfo1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.pageInfo1.TextFormatString = "Page: {0}/{1}";
            // 
            // pageInfo3
            // 
            this.pageInfo3.LocationFloat = new DevExpress.Utils.PointFloat(527.0001F, 0F);
            this.pageInfo3.Name = "pageInfo3";
            this.pageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.pageInfo3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.pageInfo3.TextFormatString = "Page: {0}/{1}";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel2});
            this.Detail1.HeightF = 149.9053F;
            this.Detail1.MultiColumn.ColumnCount = 3;
            this.Detail1.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail1.Name = "Detail1";
            // 
            // panel2
            // 
            this.panel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel3});
            this.panel2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.panel2.Name = "panel2";
            this.panel2.SizeF = new System.Drawing.SizeF(197.9167F, 149.9053F);
            // 
            // panel3
            // 
            this.panel3.BorderColor = System.Drawing.Color.Gray;
            this.panel3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            this.panel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.panel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.label3,
            this.label4});
            this.panel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "BackColor", "Iif([Floor] == 5, \'241, 218, 248\', [Floor] == 4, \'251, 203, 225\', [Floor] == 3, \'" +
                    "218, 226, 248\', [Floor] == 2, \'248, 218, 220\', [Floor] == 1, \'218, 248, 235\', ?)" +
                    "")});
            this.panel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.panel3.Name = "panel3";
            this.panel3.SizeF = new System.Drawing.SizeF(196.9328F, 139.9053F);
            this.panel3.StylePriority.UseBorderColor = false;
            this.panel3.StylePriority.UseBorderDashStyle = false;
            this.panel3.StylePriority.UseBorders = false;
            // 
            // label3
            // 
            this.label3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Items].[ID]")});
            this.label3.LocationFloat = new DevExpress.Utils.PointFloat(7.291664F, 72.17798F);
            this.label3.Multiline = true;
            this.label3.Name = "label3";
            this.label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.label3.Text = "label2";
            this.label3.TextFormatString = "ID: {0}";
            // 
            // label4
            // 
            this.label4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.label4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Items].[Name]")});
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.LocationFloat = new DevExpress.Utils.PointFloat(7.291667F, 10.00001F);
            this.label4.Name = "label4";
            this.label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label4.SizeF = new System.Drawing.SizeF(181.8402F, 20.91665F);
            this.label4.StylePriority.UseBorders = false;
            this.label4.StylePriority.UseFont = false;
            this.label4.TextFormatString = "Name: {0}";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("pictureBox1.ImageSource"));
            this.pictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(143.2292F, 5.583317F);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.NavigateUrl = "https://packsmartinc.com/";
            this.pictureBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.pictureBox1.SizeF = new System.Drawing.SizeF(160.4167F, 55.20833F);
            this.pictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            this.pictureBox1.UseImageResolution = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.NavigateUrl = "https://packsmartinc.com/";
            this.xrPictureBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(160.4167F, 55.20833F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            this.xrPictureBox1.UseImageResolution = false;
            // 
            // csSimpleReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportHeader,
            this.PageFooter,
            this.PageHeader,
            this.ReportFooter,
            this.DetailReport});
            this.DisplayName = "Test Display Name";
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 39, 17);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.RequestParameters = false;
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel panel1;
        private DevExpress.XtraReports.UI.XRChart chart1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRPictureBox pictureBox1;
        private DevExpress.XtraReports.UI.XRPageBreak pageBreak1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo2;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo3;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRPanel panel2;
        private DevExpress.XtraReports.UI.XRPanel panel3;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.XtraReports.UI.XRLabel label4;
    }
}
