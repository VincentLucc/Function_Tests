using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeList
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

    


        private void Form1_Load(object sender, EventArgs e)
        {
            //var column1 = treeList1.Columns.Add();
            //column1.Caption = "Procedure";
            //column1.Visible = true;

            csUIHelper.InitTreeList(treeList1);
            
            treeList1.DataSource = new string[] {"1","2" };


        }

        private void bAdd_Click(object sender, EventArgs e)
        {


            treeList1.BeginUnboundLoad();
            treeList1.AppendNode(new object[] {"1"},null);
            treeList1.Refresh();
            treeList1.EndUnboundLoad();

        }

        private void bDelete_Click(object sender, EventArgs e)
        {

        }


    }
}
