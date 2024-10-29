using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Click_2201
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private List<csLog> records = new List<csLog>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init grid
            gridControl1.DataSource = records;
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is DateTime)
            {
                e.DisplayText = ((DateTime)e.Value).ToString("HH:mm:ss.fff");
            }
        }

        private void ClickButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           var newLog= new csLog(){LogTime = DateTime.Now, Source = "Click Button"};
           records.Add(newLog);
           gridControl1.RefreshDataSource();
           gridView1.MoveLast();
        }
    }
}
