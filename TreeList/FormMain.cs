using DevExpress.XtraGrid;
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
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        Stopwatch watch = new Stopwatch();

        List<string> sDataSource = new List<string>();
        BindingList<Student> sBindingSource = new BindingList<Student>();

        public FormMain()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
 
 
        }

 

 

 


        /// <summary>
        /// use data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataSourceTreeList windSource = new DataSourceTreeList();
            windSource.Show();
        }

 
        /// <summary>
        /// /Use Binding Mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            BindingTreeList winBinding = new BindingTreeList();

            winBinding.Show();
        }

 

        private void bDirectlyAdd_Click(object sender, EventArgs e)
        {
            DireclyAddForm winDirectAdd = new DireclyAddForm();

            winDirectAdd.Show();
        }

        private void bPartailModification_Click(object sender, EventArgs e)
        {

            PartialModification winPartial = new PartialModification();

            winPartial.Show();

        }

        private void bBindHierachicalData_Click(object sender, EventArgs e)
        {
            BindHierachicalData winData = new BindHierachicalData();

            winData.Show();
        }
    }
}
