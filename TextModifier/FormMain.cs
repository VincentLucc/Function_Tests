using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Windows.Forms;

namespace TextModifier
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public csDevMessage messageHelper;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init
            messageHelper = new csDevMessage(this);

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

                //Prepare
                string sFileName = fileDialog.FileName;
                Stopwatch watch = Stopwatch.StartNew();
                messageHelper.ShowMainLoading(null, "Reading File.");

                //Read to memory
                byte[] bData = File.ReadAllBytes(sFileName);

                //Show time spending
                long lTotal = watch.ElapsedMilliseconds;
                Trace.WriteLine($"Read to memory:{lTotal}ms");
                long lPre = lTotal;



                string sError = largeTextUserControl1.LoadFile(bData);
                if (sError != null)
                {
                    messageHelper.Info("sError");
                    return;
                }


                //Try to only load limited lines
                var v1 = richEditControl1.ActiveView.GetVisiblePageLayoutInfos();
                var v2 = richEditControl1.ActiveView.GetVisiblePagesRange();
                var v3 = richEditControl1.ActiveView.GetDocumentLayoutPosition(new Point(0, 50));

                messageHelper.ShowMainLoading(null, "Updating Display.");
                //Attempt to increase performace(SuspendLayout:No big changes)
                if (!richEditControl1.LoadDocument(bData))
                {
                    messageHelper.Info("UI updating error.\r\nPlease try smaller file size.");
                    return;
                }
                richEditControl1.LoadDocument(bData);
                lTotal = watch.ElapsedMilliseconds;
                Trace.WriteLine($"Updating Display:{lTotal - lPre}ms/{lTotal}ms");
                messageHelper.CloseForm();

            }

        }


    }
}
