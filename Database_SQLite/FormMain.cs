using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database_SQLite
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void bCreateDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            csSqlHelper.InitDataBase();
        }

        private void bAddRecords_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string sMessage = "";

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int iBase = 1000;
            for (int i = 0; i < 10; i++)
            {
                int iSN = iBase + i;
                var record = new RecordRow(iSN, 123, 201, 1500, "03/20", "Tag");
                if (!csSqlHelper.AddRecord(record, out sMessage))
                {
                    MessageBox.Show(sMessage);
                    break;
                }
            }
            watch.Stop();
            Debug.WriteLine("Time:" + watch.ElapsedMilliseconds + "ms");
        }
    }
}
