using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database_Sqlite_SqlCipher
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bInitDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            csSqlHelper.InitDataBase();
        }

        private void bAddSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!csSqlHelper.AddRecord(126, 123, "Tag", 201, 1500, "03/20", "", out string sMessage))
            //{
            //    MessageBox.Show(sMessage);
            //}
            string sMessage = "";

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int iBase = 3300;
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
