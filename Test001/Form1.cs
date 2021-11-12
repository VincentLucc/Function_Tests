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
using System.IO;

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
            //Load text
            string sPath = Directory.GetCurrentDirectory() + "/output 10-12.txt";
            columnSelectorControl1.LoadFile(sPath, 10, true);

            InitCustomizedFixedWidthControl();
        }

        private void InitCustomizedFixedWidthControl()
        {
            gridControl1.Enabled = true;


            CreateRowData();

            gridControl1.DataSourceChanged += GridControl1_DataSourceChanged;
            gridControl1.ProcessGridKey += GridControl1_ProcessGridKey;

            gridView1.SelectionChanged += GridView1_SelectionChanged;
            gridView1.FocusedRowChanged += GridView1_FocusedRowChanged;
            gridView1.CellValueChanged += GridView1_CellValueChanged;

        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Debug.WriteLine("Current row:" + e.FocusedRowHandle);

            //Get selected value
            var verifyResult = VerifyFixedWidthDefinition();
            if (!verifyResult.IsSuccess)
            {
                MessageBox.Show("Verification Fail.\r\n" + verifyResult.Message);
                return;
            }

            //Get current selection
            int iRow = e.FocusedRowHandle;
            int[] Selection = verifyResult.Selection[iRow];

            //Apply color and convert format
            List<Tuple<SolidBrush, int, int>> selection = new List<Tuple<SolidBrush, int, int>>()
            {new Tuple<SolidBrush,int,int>(new SolidBrush(Color.Red),Selection[0],Selection[1]) };

            //Appy selection 
            columnSelectorControl1.SetColumnCoords(selection);




        }

        private void CreateRowData()
        {
            //Init row
            DataTable dt = new DataTable();
            dt.Columns.Add("Column ID",typeof(int));
            dt.Columns.Add("Start Index",typeof(int));
            dt.Columns.Add("End Index",typeof(int));


            for (int i = 0; i < 10; i++)
            {
                var row = dt.NewRow();
                row["Column ID"] = i + 1; //ID
                row["Start Index"] = i + 2; //Start Index
                row["End Index"] = i + 3; //End index
                dt.Rows.Add(row);
            }



            gridControl1.DataSource = dt.DefaultView;
        }


        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Get current row and column
            int iRow = e.RowHandle;
            int iColumn = e.Column.AbsoluteIndex;

            //Verify current input
            var result = ClassPublic.IntVerification(e.Value, 0, 10000);
            if (!result.IsSuccess)
            {
                MessageBox.Show($"Invalid input in row {iRow + 1}, column {iColumn + 1}.\r\n" + result.Message);
                return;
            }

            //Get selected value
            var verifyResult = VerifyFixedWidthDefinition();
            if (!verifyResult.IsSuccess)
            {
                MessageBox.Show("Verification Fail.\r\n" + verifyResult.Message);
                return;
            }

            //Get current selection
            int[] Selection = verifyResult.Selection[iRow];

            //Apply color and convert format
            List<Tuple<SolidBrush, int, int>> selection = new List<Tuple<SolidBrush, int, int>>()
            {new Tuple<SolidBrush,int,int>(new SolidBrush(Color.Red),Selection[0],Selection[1]) };

            //Appy selection 
            columnSelectorControl1.SetColumnCoords(selection);

        }



        private SelectionResult VerifyFixedWidthDefinition()
        {
            //Init result
            var mainResult = new SelectionResult();

            //Get updated data
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                //Get row
                var row = dtData.Rows[i];

                //Read current start value
                var startResult = ClassPublic.IntVerification(row[1].ToString(), 0, 10000);
                if (!startResult.IsSuccess)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = "Invalid start value.\r\n" + startResult.Message;
                    return mainResult;
                }

                //Read current end value
                var endResult = ClassPublic.IntVerification(row[2].ToString(), 0, 10000);
                if (!endResult.IsSuccess)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = "Invalid start value.\r\n" + startResult.Message;
                    return mainResult;
                }

                //Verify size
                if (startResult.IntResult > endResult.IntResult)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = $"Start index must be smaller than end index.\r\n Row:{i + 1}";
                    return mainResult;
                }

                //Finish verification, add to result
                mainResult.Selection.Add(new int[] { startResult.IntResult, endResult.IntResult });
            }


            //Pass all step
            mainResult.IsSuccess = true;
            return mainResult;
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

        private void bClear_Click(object sender, EventArgs e)
        {
            //Get updated data
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();
            dtData.Rows.Clear();
            gridControl1.DataSource = dtData.DefaultView;
        }

        private void bReload_Click(object sender, EventArgs e)
        {
            CreateRowData();


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAdd_Click(object sender, EventArgs e)
        {
            //Get selected
            var result = columnSelectorControl1.getSingleColumnCoords();
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                return;
            }

            //Directly add
            AddIndexRows(result.Selection);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="IndexList"></param>
        private void AddIndexRows(List<int[]> IndexList)
        {
            //Get datatable
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();
            int iRowStart = dtData.Rows.Count+1; //Row start
            for (int i = 0; i < IndexList.Count; i++)
            {
                //Current index
                int[] indexCurrent = IndexList[i];

                //Create row
                var row = dtData.NewRow();
                row["Column ID"] = iRowStart+i; //ID
                row["Start Index"] = indexCurrent[0]; //Start Index
                row["End Index"] = indexCurrent[1];  //End index

                //Add row
                dtData.Rows.Add(row);
            }

            //Re-new value
            gridControl1.DataSource = dtData.DefaultView;

            //Clear column selection
            columnSelectorControl1.ClearColumnCoords();
        }


        /// <summary>
        /// Modify selected index row
        /// </summary>
        /// <param name="IndexList"></param>
        private GeneralResult ModifyIndexRows(int SelectedIndex,List<int[]> IndexList)
        {
            //Init result
            var result =new GeneralResult();

            //Verify
            if (IndexList.Count ==0||IndexList.Count!=1)
            {
                result.Message = "Invalid data count.";
                return result;
            }

            //Verify data
            if (IndexList[0][0]<0 || IndexList[0][1]<0 || IndexList[0][0]== IndexList[0][1])
            {
                result.Message = "Invalid selection.";
                return result;
            }

            //Get datatable
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();
            var selectedRow = dtData.Rows[SelectedIndex]; //Get selected row

            //Set row value
            selectedRow["Start Index"] = IndexList[0][0]; //Start Index
            selectedRow["End Index"] = IndexList[0][1];  //End index

            
     
            //Re-new value
            gridControl1.DataSource = dtData.DefaultView;
            gridView1.FocusedRowHandle = SelectedIndex;//Set selection back

            //Clear column selection
            columnSelectorControl1.ClearColumnCoords();

            //Pass all steps
            result.IsSuccess = true;

            return result;
        }

        /// <summary>
        /// Modify selected column indexes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bModify_Click(object sender, EventArgs e)
        {
            //Check data table selection
            if (!gridView1.IsValidRowHandle(gridView1.FocusedRowHandle))
            {
                MessageBox.Show("Please select a valid row first.");
                return;
            }

            //Verify UI selection
            var selection = columnSelectorControl1.getSingleColumnCoords();
            if (!selection.IsSuccess)
            {
                MessageBox.Show("Please select valid column rrange first.");
                return;
            }

            //Modify row
            ModifyIndexRows(gridView1.FocusedRowHandle, selection.Selection);

        }
    }
}
