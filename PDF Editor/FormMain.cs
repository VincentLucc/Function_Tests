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
        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog=new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                pdfViewer1.LoadDocument(openFileDialog.FileName);
              
            }
        }

        private void AddFileBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                pdfViewer1.LoadDocument(openFileDialog.FileName);

            }
        }
    }
}
