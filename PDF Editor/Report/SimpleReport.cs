using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace PDF_Editor
{
    /// <summary>
    /// Summary description for Report.
    /// </summary>
    public partial class csSimpleReport : XtraReport
    {
        static csSimpleReport()
        {
            DevExpress.XtraReports.Expressions.ExpressionBindingDescriptor.SetPropertyDescription(typeof(Band), "PageBreak", new DevExpress.XtraReports.Expressions.ExpressionBindingDescription(new[] { "BeforePrint" }, 1000, new string[0]));
        }

        public csSimpleReport()
        {
            InitializeComponent();
            Name = "Test Name";
            DisplayName = "Test Display Name";
            var repostData = new csReportModel();
            repostData.InitRecords();
            this.DataSource = repostData.Items;
        }

        void Report_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XtraReport report = sender as XtraReport;
            DetailBand detailBand = report.Bands[BandKind.Detail] as DetailBand;

            detailBand.MultiColumn.Layout = (bool)columnLayoutParameter.Value
                ? ColumnLayout.AcrossThenDown
                : ColumnLayout.DownThenAcross;
        }
    }
}
