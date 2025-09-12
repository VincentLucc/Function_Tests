using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDF_Editor
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
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
    }
}
