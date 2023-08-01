using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
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
    public partial class BindingTreeList : DevExpress.XtraEditors.XtraForm
    {
        BindingList<Student> sBindingSource = new BindingList<Student>();
        Stopwatch watch=new Stopwatch();

        public BindingTreeList()
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
            int iStart = sBindingSource.Count;
            int iEnd = iStart + iCount;

            treeList1.BeginUpdate();
            

            for (int i = iStart; i < iEnd; i++)
            {
                var sutdent = new Student()
                { id = i, age = i, name = i.ToString() };

                sBindingSource.Add(sutdent);
            }

            treeList1.EndUpdate();

            watch.Stop();
            Debug.WriteLine(watch.ElapsedMilliseconds);

        }

        private async void BindingTreeList_Load(object sender, EventArgs e)
        {
            //Init
            treeList1.DataSource = null;
            treeList1.RefreshDataSource();
            treeList1.DataSource = sBindingSource;

            AddRecords(10000);

            await Task.Delay(1000);

            timer1.Start();
        }
    }
}