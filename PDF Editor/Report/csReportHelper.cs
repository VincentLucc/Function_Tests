using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraReports.UI;

namespace PDF_Editor
{
    static class csReportHelper
    {
        public static XtraReport report;
        public static void InitDataSource()
        {
            if (report==null) return;
 
            var repostData = new csReportModel();
            repostData.InitRecords();
            //Must within in an IEnumerable 
            report.DataSource = new csReportModel[] { repostData}; 
        }
    }
}
