using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeList
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Stopwatch watch = new Stopwatch();

        List<string> sDataSource = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {


            csUIHelper.InitTreeList(treeList1);
          
 
            bool useDataSource = false;

            if (useDataSource)
            {//Use data source
                treeList1.Columns.Clear();
                treeList1.DataSource = sDataSource;
            }
            else
            { 
                treeList1.Columns.Clear();
                var column1 = treeList1.Columns.Add();
                column1.Caption = "Procedure";
                column1.Visible = true;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            treeList1.BeginUnboundLoad();
            treeList1.AppendNode(new object[] { "1" }, null);
            treeList1.Refresh();
            treeList1.EndUnboundLoad();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //12 seconds

            watch.Restart();

            for (int i = 0; i < 10000; i++)
            {
                treeList1.AppendNode(i, null);
            }

            watch.Stop();
            Debug.WriteLine("Direct Add:" + watch.ElapsedMilliseconds);
            watch.Restart();
            treeList1.Refresh();
            watch.Stop();
            Debug.WriteLine("Direct Add refresh:" + watch.ElapsedMilliseconds);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            watch.Restart();

            for (int i = 0; i < 10000; i++)
            {
                sDataSource.Add(i.ToString());
            }
            watch.Stop();
            Debug.WriteLine("Data source add:" + watch.ElapsedMilliseconds);
            watch.Restart();
            treeList1.RefreshDataSource();
            watch.Stop();
            Debug.WriteLine("Direct source refresh:" + watch.ElapsedMilliseconds);
        }
    }
}
