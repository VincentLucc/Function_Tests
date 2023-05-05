using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Database_Sqlite_SqlCipher
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public int iStart = 7000;

        public Form1()
        {
            InitializeComponent();
        }

        private void bInitDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!csSqlHelper.CreateDataBase(out string sMessage))
            {
                MessageBox.Show(sMessage);
            }
            
        }

        private void bAddSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sMessage = "";
            var record = new RecordRow(iStart, 123, 201, 1500, "03/20", "Tag");
            if (!csSqlHelper.CanAddRecord(iStart, out sMessage))
            {
                MessageBox.Show(sMessage);
                return;
            }


            Stopwatch watch = new Stopwatch();
            watch.Start();
            int iCOunt = 1000;
            for (int i = 0; i < iCOunt; i++)
            {
                int iSN = iStart + i;
                record = new RecordRow(iSN, 123, 201, 1500, "03/20", "Tag");
                if (!csSqlHelper.AddRecord(record, out sMessage))
                {
                    MessageBox.Show(sMessage);
                    break;
                }
            }
            iStart += iCOunt;
            watch.Stop();
            Debug.WriteLine("Time:" + watch.ElapsedMilliseconds + "ms");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(csSqlHelper.sDataBasePath))
            {
                csSqlHelper.InitPasswordConnection();
            }
            else
            {
                csSqlHelper.CreateDataBase(out string sMessage);
            }
           
        }
    }
}
