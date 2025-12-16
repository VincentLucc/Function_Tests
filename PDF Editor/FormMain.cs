using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _CommonCode_Dev22;
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
            using (OpenFileDialog openFileDialog=new OpenFileDialog())
            {
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
            if (iRow==0)
            {

                return;
            }

            var current = PDFFiles[iRow];
            PDFFiles.RemoveAt(iRow);
        }

        private void MoveDownFileButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void SimpleButton_Click(object sender, EventArgs e)
        {
            csPublic.report = new csSimpleReport();
            documentViewer1.DocumentSource = csPublic.report;
        }

        private void OpenDialogButton_Click(object sender, EventArgs e)
        {

            if (csPublic.report==null)
            {
                csPublic.report = new csSimpleReport();
            }

            ReportDesignTool designTool = new ReportDesignTool(csPublic.report);
            //designTool.ShowDesignerDialog(); //Old ribbon style
            
            designTool.ShowRibbonDesignerDialog(); //Modern view

            csPublic.report = designTool.Report;
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (csPublic.report==null)
            {
                messageHelper.Info("Please open or create a report file.");
                return;
            }
        }
    }
}
