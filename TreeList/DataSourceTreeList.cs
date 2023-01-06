using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeList
{
    public partial class DataSourceTreeList : DevExpress.XtraEditors.XtraForm
    {
        List<Student> sDataSource = new List<Student>();
        Stopwatch watch=new Stopwatch();

        public DataSourceTreeList()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (this.Disposing || this.IsDisposed) return;


            AddRecords(100);


            timer1.Enabled = true;
        }


        private void AddRecords(int iCount)
        {
            watch.Restart();
            int iStart = sDataSource.Count;
            int iEnd = iStart + iCount;

            for (int i = iStart; i < iEnd; i++)
            {
                var sutdent = new Student()
                { id = i, age = i, name = i.ToString() };

                sDataSource.Add(sutdent);
            }

            treeList1.RefreshDataSource();
 
            watch.Stop();
            Debug.WriteLine(watch.ElapsedMilliseconds);

        }

        private  void BindingTreeList_Load(object sender, EventArgs e)
        {
            //Init
            csUIHelper.InitTreeList(treeList1);
            treeList1.DataSource = null;
            treeList1.RefreshDataSource();
            treeList1.DataSource = sDataSource;

            AddRecords(10000);

            timer1.Start();
        }
    }
}