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
            //包装成一个Ienumerable后才不会报错！！！
            report.DataSource = new csReportModel[] { repostData}; 
        }
    }
}
