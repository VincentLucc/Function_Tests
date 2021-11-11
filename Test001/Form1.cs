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
            //Load text


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

            //Verify current input
            var result = ClassPublic.IntVerification(e.Value, 0, 10000);
            if (!result.IsSuccess)
            {
                MessageBox.Show($"Invalid input in row {iRow+1}, column {iColumn+1}.\r\n"+result.Message);
                return;
            }

            //Get selected value
            var verifyResult=VerifyFixedWidthDefinition();
            if (!verifyResult.IsSuccess)
            {
                MessageBox.Show("Verification Fail.\r\n"+verifyResult.Message);
                return;
            }


            //Get value
            int[] rowValue = verifyResult.Selection[iRow];
            Debug.WriteLine($"Start {rowValue[0]}, End {rowValue[1]}");//Show selection


            var selection = GetSelectedWidthDefinition(iRow);
            if (!selection.IsSuccess)
            {
                return;
            }
            
            //Apply selection

        }

        /// <summary>
        /// Get selected row int value
        /// </summary>
        private SelectionResult GetSelectedWidthDefinition(int SelectedRow)
        { 
            //Init result
            var result = new SelectionResult();

            //Error avoid
            if (SelectedRow < 0)
            {
                result.Message = "Invalid row index.";
                return result;
            }
                
             
            //Get updated data
            DataTable dtData = ((DataView)gridControl1.DataSource).ToTable();

            //Read current start value
            if (!int.TryParse(dtData.Rows[SelectedRow][1].ToString(), out int iStart))
            {
                result.Message = "Invalid start value.";
                return result;
            }
            //Read current end value
            if (!int.TryParse(dtData.Rows[SelectedRow][2].ToString(), out int iEnd))
            {
                MessageBox.Show($"Invalid end value.");
                return result;
            }

            //Generate result
            result.Selection = new List<int[]> { new int[] { iStart,iEnd} };
            result.IsSuccess = true;
            Debug.WriteLine($"Start {iStart}, End {iEnd}");//Show selection
            return result;
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
                var startResult = ClassPublic.IntVerification(row[1].ToString(),0,10000);
                if (!startResult.IsSuccess)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = "Invalid start value.\r\n"+startResult.Message;
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
                if (startResult.IntResult>endResult.IntResult)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = $"Start index must be smaller than end index.\r\n Row:{i+1}";
                    return mainResult;
                }

                //Finish verification, add to result
                mainResult.Selection.Add(new int[] { startResult.IntResult,endResult.IntResult});
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
    }
}
