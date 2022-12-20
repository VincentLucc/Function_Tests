using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_22_1
{
    public partial class BigDataUpdate : DevExpress.XtraEditors.XtraForm
    {
        public List<Student> Students { get; set; }
        private object lockStudents { get; set; }

        public bool UIExit => (this == null || this.IsDisposed || this.Disposing);



        public BigDataUpdate()
        {
            InitializeComponent();
        }

        private void BigDataUpdate_Load(object sender, EventArgs e)
        {
            //Init variables
            lockStudents = new object();

            PrepareGridData();

            //Init update thread
            Thread t1 = new Thread(ProcessUpdate);
            t1.IsBackground = true;
            t1.Start();
        }


        private void PrepareGridData()
        {
            Students = new List<Student>();
            for (int i = 0; i < 1000000; i++)
            {
                Student s = new Student();
                s.Name = $"X_{i + 1}";
                s.Age = i + 10;
                s.Class = "ABC";
                Students.Add(s);
            }

            gridControl1.DataSource = Students;
        }


        private void ProcessUpdate()
        {
            Stopwatch watch = new Stopwatch();

            while (!UIExit)
            {

                try
                {
                    Thread.Sleep(50);

                    watch.Restart();

                    UpdateValue();

                    watch.Stop();

                    Debug.WriteLine($"Operation time:{watch.ElapsedMilliseconds}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("ProcessUpdate:\r\n" + ex.Message);
                }


            }
        }


        private void UpdateValue()
        {
            lock (lockStudents)
            {
                for (int i = 0; i < 100; i++)
                {
                    Students[i].Age += 1;
                }


              

                gridControl1.Invoke(new Action(() =>
                {
                    gridControl1.RefreshDataSource();           

                }));

                int iRowCount = gridView1.RowCount;

                // gridView1.TopRowIndex= iRowCount;
                GridViewInfo viewInfo= (GridViewInfo)gridView1.GetViewInfo();
                int iViewCount= viewInfo.RowsInfo.Count;
                int iRowIndex = iViewCount;

                gridControl1.Invoke(new Action(() =>
                {
                    gridView1.TopRowIndex= -100;

                }));
            }



        }
    }
}