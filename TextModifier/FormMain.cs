using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextModifier
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
      
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitTextViewer();
        }

        private void InitTextViewer()
        {
            richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            richEditControl1.ReadOnly = true;
            richEditControl1.ActiveView.AllowDisplayLineNumbers = true;
            richEditControl1.Views.SimpleView.WordWrap = false;

        }

        private void OpenBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (XtraOpenFileDialog fileDialog = new XtraOpenFileDialog())
            {
                if (fileDialog.ShowDialog() != DialogResult.OK) return;

                string sFileName = fileDialog.FileName;

                byte[] bData = File.ReadAllBytes(sFileName);

                
                richEditControl1.LoadDocument(bData);


            }

        }


    }
}
