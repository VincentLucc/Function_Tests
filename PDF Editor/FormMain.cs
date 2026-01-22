using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _CommonCode_Dev22;
using _CommonCode_Framework;
using DevExpress.Pdf;
using DevExpress.XtraReports.UI;

namespace PDF_Editor
{
    public partial class FormMain : XtraFormEx
    {

        private List<csPDFFile> PDFFiles = new List<csPDFFile>();

        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CombineGridControl.DataSource = PDFFiles;
        }

        private void OpenButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF File(*.pdf)|*.pdf|All File(*.*)|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                pdfViewer1.LoadDocument(openFileDialog.FileName);
                PDFFiles.Add(new csPDFFile(openFileDialog.FileName));
            }
        }

        private void AddFileBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                pdfViewer1.LoadDocument(openFileDialog.FileName);
                PDFFiles.Add(new csPDFFile(openFileDialog.FileName));
            }


        }

        private void MoveUpFileButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CombineGridView.FocusedRowHandle < 0) return;

            //Get the row
            int iRow = CombineGridView.FocusedRowHandle;
            if (iRow == 0)
            {

                return;
            }

            var current = PDFFiles[iRow];
            PDFFiles.RemoveAt(iRow);
        }

        private void MoveDownFileButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

 
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (csReportHelper.report == null)
            {
                messageHelper.Info("Please open or create a report file.");
                return;
            }

            //Save to stream
            using (var memStream = new MemoryStream())
            {
                csReportHelper.report.ExportToPdf(memStream);
                pdfViewer1.LoadDocument(memStream);
            }


            tabPane1.SelectedPage = PdfViewerPage;
        }

        private void simplePDFButton_Click(object sender, EventArgs e)
        {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {
                string sPath = $"{csPublic.OutputFolder}\\SimpleCreate.pdf";
                if (!processor.CreateEmptyPdfEx(sPath, out string sMessage))
                {
                    messageHelper.Info(sMessage);
                    return;
                }

                using (PdfGraphics graph = processor.CreateGraphics())
                {
                    //Start paint
                    var newFont = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);
                    SolidBrush black = (SolidBrush)Brushes.Black;
                    graph.DrawString("This is a text", newFont, black, 10, 10);

                    //Create a page based on the paint info
                    int iPage = processor.RenderNewPage(PdfPaperSize.A4, graph);

                    //Get the page
                    var pageContent = processor.Document.Pages[iPage - 1];

                    graph.AddToPageForeground(pageContent);
                    graph.AddToPageBackground(pageContent);


                }
            }
        }

        private void EditInDesignerButton_Click(object sender, EventArgs e)
        {
            if (csReportHelper.report == null)
            {
                csReportHelper.report = new csSimpleReport();
            }

            ReportDesignTool designTool = new ReportDesignTool(csReportHelper.report);
            //designTool.ShowDesignerDialog(); //Old ribbon style

            designTool.ShowRibbonDesignerDialog(); //Modern view

            csReportHelper.report = designTool.Report;
        }

        private void OpenTemplateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Report File(*.repx)|*.repx|All File(*.*)|*.*";
                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                    csReportHelper.report = XtraReport.FromFile(openFileDialog.FileName);
                    csReportHelper.InitDataSource();
                    csReportHelper.report.CreateDocument();
                    documentViewer1.DocumentSource = null;
                    documentViewer1.DocumentSource = csReportHelper.report;
                }
            }
            catch (Exception exception)
            {
                exception.TraceException("OpenTemplateButton_Click");
                messageHelper.Error(exception.Message);
            }

        }

        private void CreateNewFomBaseButton_Click(object sender, EventArgs e)
        {
            csReportHelper.report = new csSimpleReport();
            csReportHelper.report.CreateDocument();
            documentViewer1.DocumentSource = csReportHelper.report;
        }
    }
}
