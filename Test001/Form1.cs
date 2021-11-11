using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Test001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitCustomizedFixedWidthControl();
        }

        private void InitCustomizedFixedWidthControl()
        {
            gridControl1.Enabled = true;

            //Init row
            DataTable dt = new DataTable();
            dt.Columns.Add("Column ID");
            dt.Columns.Add("Start Index");
            dt.Columns.Add("End Index");


            for (int i = 0; i < 10; i++)
            {
                var row = dt.NewRow();
                row[0] = i + 1; //ID
                row[1] = i + 2; //Start Index
                row[2] = i + 3; //End index
                dt.Rows.Add(row);
            }



            gridControl1.DataSource = dt.DefaultView;


            gridControl1.DataSourceChanged += GridControl1_DataSourceChanged;
            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;

            gridView1.SelectionChanged += GridView1_SelectionChanged;
            gridView1.CellValueChanged += GridView1_CellValueChanged;


        }


  
        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Get current row and column
            int iRow = e.RowHandle;
            int iColumn = e.Column.AbsoluteIndex;

            //Value verification
            if (iColumn==1)  //Start point
            {
                if (e.Value)
                {

                }
            }
            else if (iColumn==2) //End column
            {

            }


            //Get updated data
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();

            //Init selected value
            List<int[]> selectionResult = new List<int[]> { 
            new int[]{dtData.Rows[iRow][1], dtData.Rows[iRow][2]}
            };




            Debug.WriteLine($"Cell Value change,row({iRow}),column({iColumn})");

            //Try to display data source value

            Debug.WriteLine("Table value:" + dtData.Rows[iRow][iColumn].ToString());
        }

        private void GridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Selection");
        }

        private void GridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
           // Debug.WriteLine("Key");
        }

        private void GridControl1_DataSourceChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("chnaged");
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
