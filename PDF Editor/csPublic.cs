using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _CommonCode_Framework;
using DevExpress.Pdf;
using DevExpress.XtraReports.UI;

namespace PDF_Editor
{
    public static class csPublic
    {
        
        public static string OutputFolder => $"{Application.StartupPath}\\output";

        public static bool CreateEmptyPdfEx(this PdfDocumentProcessor processor,string sFilePath, out string sMessage)
        {
            sMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(sFilePath))
                {
                    sMessage = "The file path is empty.";
                    return false;
                }

                //Check path
                string sDir= Path.GetDirectoryName(sFilePath);
                if (!Directory.Exists(sDir)) Directory.CreateDirectory(sDir);
                //Create pdf
                processor.CreateEmptyDocument(sFilePath);
 
                //Pass all 
                return true;
            }
            catch (Exception e)
            {
                e.TraceException("CreateEmptyPdfSafe");
                sMessage = e.Message;
                return false;
            }
        }
    }
}
