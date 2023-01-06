using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
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
    public partial class DireclyAddForm : DevExpress.XtraEditors.XtraForm
    {

        Stopwatch watch = new Stopwatch();

        public DireclyAddForm()
        {
            InitializeComponent();
        }

        private void DireclyAddForm_Load(object sender, EventArgs e)
        {
            csUIHelper.InitTreeList(treeList1);
            treeList1.Columns.Clear();
            treeList1.Nodes.Clear();

            //Column is invisible by default, in unBinded mode, directly add object by index,
            //column name can be different
            treeList1.Columns.AddVisible("ID");         
            treeList1.Columns.AddVisible("Name");
            treeList1.Columns.AddVisible("Age");
 
            AddRecords(1000000);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;


            AddRecords(100);
            timer1.Enabled = true;
        }

        private void AddRecords(int iCount)
        {
            watch.Restart();
            int iStart = treeList1.Nodes.Count;
            int iEnd = iStart + iCount;

            //Freeze UI
            treeList1.BeginUpdate();

            for (int i = iStart; i < iEnd; i++)
            {
                var data = new object[]
                { i.ToString(), i.ToString(), i.ToString() };

                //Add to root level
                treeList1.AppendNode(data, null);   
            }

            treeList1.MoveLast();
            treeList1.EndUpdate();

            watch.Stop();

            string sMessage = $"Add {iCount},{watch.ElapsedMilliseconds}ms";
            Debug.WriteLine(sMessage);

        }
    }
}