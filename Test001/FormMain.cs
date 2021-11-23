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
    public partial class FormMain : Form
    {

       public List<InputField> ColumnDefinition { get; set; }
        public bool IgnoreDataFileFieldGridViewRowSelectionChange { get; set; }

        UIOperation UserOperation=new UIOperation();

        public FormMain()
        {
            InitializeComponent();

            //string s = "abc";
            //string s3 = s.Substring(1, 5);
            ClassPublic.winMain = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load text
            string sPath = Directory.GetCurrentDirectory() + "/output 10-12.txt";
            FileColumnSelector.LoadFile(sPath, 10, true);

            InitCustomizedFixedWidthControl();
            //ShowMapForm();
            ShowTreeListForm();
        }

        private void InitCustomizedFixedWidthControl()
        {
            DataFileFieldGridControl.Enabled = true;


            CreateRowData();

            FileColumnSelector.SelectionReady += SelectionReadyMethod;
            DataFileFieldGridView.FocusedRowChanged += GridView1_FocusedRowChanged;
            DataFileFieldGridView.CellValueChanged += GridView1_CellValueChanged;
        }

        private void SelectionReadyMethod(object sender, EventArgs e)
        {
            //Get event button
            var eButton = (ColumnSelectorControlSingle.IndexCollectionChangeEventArgs)e;
            //Get current selected index
            int iIndex = DataFileFieldGridView.FocusedRowHandle;

            //Selection when left button used
            if (eButton.Button == MouseButtons.Left)
            {
                if (iIndex >= 0)
                {
                    ModifyIndexRows();
                }
            }
            //Selection when right button used
            else if (eButton.Button == MouseButtons.Right)
            {
                //Always add a new record
                DataFieldAddIndexRows();
            }
        }

        private void GridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Debug.WriteLine("Current row:" + e.FocusedRowHandle);

            //Check ignore, ignore once
            //if (IgnoreDataFileFieldGridViewRowSelectionChange)
            //{
            //    IgnoreDataFileFieldGridViewRowSelectionChange = false;
            //    return;
            //}

            //Get selected value
            var verifyResult = VerifyFixedWidthDefinition();
            if (!verifyResult.IsSuccess)
            {
                MessageBox.Show("Verification Fail.\r\n" + verifyResult.Message);
                return;
            }

            //Get current selection
            int iRow = e.FocusedRowHandle;

            //None verification
            if (iRow < 0) return;
            int[] Selection = verifyResult.Selection[iRow];

            //Apply color and convert format
            List<Tuple<SolidBrush, int, int>> selection = new List<Tuple<SolidBrush, int, int>>()
            {new Tuple<SolidBrush,int,int>(new SolidBrush(Color.Red),Selection[0],Selection[1]) };

            //Appy selection 
            FileColumnSelector.SetColumnCoords(selection);
        }

        private void CreateRowData()
        {
            //Init row
            ColumnDefinition = new List<InputField>();

            for (int i = 0; i < 5; i++)
            {
                InputField field = new InputField()
                { Name = $"Test{i}", Description = "Test", Position = i, Length = i + 1 };


                for (int j = 0; j < 3; j++)
                {
                    InputField customFiled = new InputField()
                    { Name = $"Test{i}_{j}", Description = "Test", Position = i, Length = i + 1 };
                    field.CustomFields.Add(customFiled);
                }

                ColumnDefinition.Add(field);
            }

            DataFileFieldGridControl.DataSource = ColumnDefinition;
            DataFileFieldGridView.Columns[nameof(InputField.ColumnNumber)].Visible = false;
        }


        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Get current row and column
            int iRow = e.RowHandle;
            string sColumn = e.Column.FieldName;
            string sLocatin = $"Input in row {iRow + 1}, column {sColumn}.";
            Debug.WriteLine(sLocatin);

            //Ignore one new row creation process
            if (iRow < -1) return; //Sample:RowID=2147483647

            //Ignore verification when position and length not selected
            if (sColumn != nameof(InputField.Position) && sColumn != nameof(InputField.Length))
            {
                return;
            }

            //Verify input
            var result = ClassPublic.IntVerification(e.Value, 0, 10000);
            if (!result.IsSuccess)
            {
                MessageBox.Show($"Invalid input in row {iRow + 1}, column {sColumn}.\r\n" + result.Message);
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
            FileColumnSelector.SetColumnCoords(selection);

            //Display first row value
            Debug.WriteLine($"Value changed:{ColumnDefinition[0].Length}");

        }

        private SelectionResult VerifyFixedWidthDefinition()
        {
            //Init result
            var mainResult = new SelectionResult();

            //Get updated data
            var fieldData = ((List<InputField>)DataFileFieldGridControl.DataSource);

            //Null verification
            if (fieldData == null)
            {
                mainResult.IsSuccess = false;
                mainResult.Message = "Invalid field data.\r\n";
                return mainResult;
            }

            for (int i = 0; i < fieldData.Count; i++)
            {
                //Get row
                var fieldRow = fieldData[i];

                //Check Position value rangle
                if (fieldRow.Position < 0)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = "Invalid position value.\r\n";
                    return mainResult;
                }

                //Check length value range
                if (fieldRow.Length < 1)
                {
                    mainResult.IsSuccess = false;
                    mainResult.Message = "Invalid length value.\r\n";
                    return mainResult;
                }


                //Finish verification, add to result
                int iEnd = fieldRow.Position + fieldRow.Length;
                mainResult.Selection.Add(new int[] { fieldRow.Position, iEnd });
            }


            //Pass all step
            mainResult.IsSuccess = true;
            return mainResult;
        }






        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            //Get updated data
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;
            dataSource.Clear();
            DataFileFieldGridControl.DataSource = dataSource;
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
            //Directly add
            DataFieldAddIndexRows();

            IgnoreDataFileFieldGridViewRowSelectionChange = true;    //Set row change ignore flag
            DataFileFieldGridView.FocusedRowHandle = DataFileFieldGridView.RowCount - 1;


            //Get new row handle
        
        }




        public enum UIOperation
        {
           Added
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IndexList"></param>
        private void DataFieldAddIndexRows()
        {
            //Init variables
            var IndexList = new List<int[]>();

            //Try get selection
            var result = FileColumnSelector.getSingleColumnCoords();
            if (!result.IsSuccess)
            {
                //Create a default selection
                var indexRow = new Tuple<SolidBrush, int, int>(new SolidBrush(Color.Red), 0, 1);
                FileColumnSelector.SetColumnCoords(new List<Tuple<SolidBrush, int, int>>() { indexRow });
                IndexList.Add(new int[] { 0, 1 }); //Use default value
            }
            else
            {
                //Get Selected index
                IndexList = result.Selection;
            }

            //Get current data source
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;

            //Add data row
            for (int i = 0; i < IndexList.Count; i++)
            {
                //Get value
                int[] indexCurrent = IndexList[i];   //Current index
                int iPosition = indexCurrent[0]; //Start point
                int iLength = indexCurrent[1] - indexCurrent[0]; //Get length

                //Add value
                var rowData = new InputField();
                rowData.Position = iPosition;
                rowData.Length = iLength;
                dataSource.Add(rowData);
            }

            //Refresh data display
            DataFileFieldGridView.RefreshData();

            //Clear selection
            FileColumnSelector.ClearColumnCoords();
        }


        /// <summary>
        /// Modify selected index row
        /// </summary>
        /// <param name="IndexList"></param>
        private GeneralResult ModifyIndexRows()
        {
            //Init result
            var result = new GeneralResult();

            //Check data table selection
            if (!DataFileFieldGridView.IsValidRowHandle(DataFileFieldGridView.FocusedRowHandle))
            {
                result.Message = "Please select a valid row first.";
                return result;
            }

            //Verify UI selection
            var selection = FileColumnSelector.getSingleColumnCoords();
            if (!selection.IsSuccess)
            {
                result.Message = "Please select valid column range first.";
                return result;
            }

            //Get selected result
            var IndexList = selection.Selection; //Get column selection tool selected index
            var SelectedIndex = DataFileFieldGridView.GetDataSourceRowIndex(DataFileFieldGridView.FocusedRowHandle);   //Get data table selection index

            //Verify UI column selection index counts
            if (IndexList.Count == 0 || IndexList.Count != 1)
            {
                result.Message = "Invalid data count.";
                return result;
            }

            //Verify UI column selection value
            if (IndexList[0][0] < 0 || IndexList[0][1] < 0 || IndexList[0][0] == IndexList[0][1])
            {
                result.Message = "Invalid selection.";
                return result;
            }

            //Get datasource
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;
            var selectedRow = dataSource[SelectedIndex]; //Get selected row

            //Set row value
            selectedRow.Position = IndexList[0][0]; //Start Index
            int iLength = IndexList[0][1] - IndexList[0][0]; //end index - start index
            selectedRow.Length = iLength;  //length


            //Re-new value
            DataFileFieldGridControl.RefreshDataSource();

            //Pass all steps
            result.IsSuccess = true;

            return result;
        }

        /// <summary>
        /// Modify selected index row
        /// </summary>
        /// <param name="IndexList"></param>
        private GeneralResult DeleteIndexRow()
        {
            //Init result
            var result = new GeneralResult();

            //Check data table selection
            if (!DataFileFieldGridView.IsValidRowHandle(DataFileFieldGridView.FocusedRowHandle))
            {
                result.Message = $"Please select a valid row first.";
                result.IsSuccess = false;
                return result;
            }


            //Get source data
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;
            //Get selected datasource index
            int SelectedIndex = DataFileFieldGridView.GetDataSourceRowIndex(DataFileFieldGridView.FocusedRowHandle);

            //Try remove selected row
            try
            {
                dataSource.RemoveAt(SelectedIndex);
            }
            catch (Exception ex)
            {
                result.Message = $"Error in removeing row {SelectedIndex + 1}.\r\n" + ex.Message;
                result.IsSuccess = false;
                return result;
            }

            //Re-new value
            DataFileFieldGridControl.DataSource = dataSource;

            //Clear UI column selection
            FileColumnSelector.ClearColumnCoords();

            //Pass all steps
            result.IsSuccess = true;

            return result;
        }


        /// <summary>
        /// Re-sort the data table column ID based on value changes
        /// </summary>
        private void SortDataTable()
        {
            //Get source data
            DataTable dtData = ((DataView)DataFileFieldGridControl.DataSource).ToTable();

            var Rows = dtData.Select(null, "[Start Index] ASC,[End Index] ASC"); //Sort row

            //Add rows to new table
            var dtNew = dtData.Clone();
            for (int i = 0; i < Rows.Length; i++)
            {
                //Change ID
                var newRow = dtNew.NewRow();
                newRow["Column ID"] = i + 1; ; //Column ID
                newRow["Start Index"] = Rows[i]["Start Index"]; //Start Index
                newRow["End Index"] = Rows[i]["End Index"]; //End Index            
                dtNew.Rows.Add(newRow);
            }

            //Re-new value
            DataFileFieldGridControl.DataSource = dtNew.DefaultView;
        }


        /// <summary>
        /// Move field row up
        /// </summary>
        private void DataFieldMoveUp()
        {
            //Get current selection
            int iSelection = DataFileFieldGridView.FocusedRowHandle;

            //Ignore when row selection reach limit
            //When first row or nothing selected
            if (iSelection == 0 || iSelection < 0) return;

            //Get source data
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;

            //Get row data
            var selectedRow = dataSource[iSelection];

            //Switch data
            dataSource.RemoveAt(iSelection);
            dataSource.Insert(iSelection - 1, selectedRow);

            //Re-new value
            DataFileFieldGridView.RefreshData();

            //Reset selection
            DataFileFieldGridView.FocusedRowHandle = iSelection - 1;
        }

        /// <summary>
        /// Move field row up
        /// </summary>
        private void DataFieldMoveDown()
        {
            //Get current selection
            int iSelection = DataFileFieldGridView.FocusedRowHandle;

            //Get source data
            var dataSource = (List<InputField>)DataFileFieldGridControl.DataSource;

            //Get max index value
            int iMax = dataSource.Count - 1;

            //Ignore when row selection reach limit
            //When last row or nothing selected
            if (iSelection == iMax || iSelection < 0) return;

            //Get row data
            var selectedRow = dataSource[iSelection];

            //Switch data
            dataSource.RemoveAt(iSelection);
            dataSource.Insert(iSelection + 1, selectedRow);

            //Re-new value
            DataFileFieldGridView.RefreshData();

            //Reset selection
            DataFileFieldGridView.FocusedRowHandle = iSelection + 1;
        }

        /// <summary>
        /// Modify selected column indexes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bModify_Click(object sender, EventArgs e)
        {
            //Modify row
            var result = ModifyIndexRows();
            if (!result.IsSuccess)
            {
                MessageBox.Show(result.Message);
                return;
            }
        }

        private void bShow_Click(object sender, EventArgs e)
        {
            pBottom.Visible = !pBottom.Visible;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(ColumnDefinition.Count);
            DataFileFieldGridView.DeleteSelectedRows();
            Debug.WriteLine(ColumnDefinition.Count);
        }

        private void bSort_Click(object sender, EventArgs e)
        {
            SortDataTable();
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            DataFileFieldGridControl.Visible = !DataFileFieldGridControl.Visible;
        }

        private void columnSelectorControl1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void columnSelectorControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            Debug.WriteLine("Right Click");
        }

        private void bMoveUp_Click(object sender, EventArgs e)
        {
            DataFieldMoveUp();
        }

        private void bMoveDown_Click(object sender, EventArgs e)
        {
            DataFieldMoveUp();
        }

        private void bTest2_Click(object sender, EventArgs e)
        {
            DataFileFieldGridView.FocusInvalidRow();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ShowMapForm();
        }

        private void ShowMapForm()
        {
            if (ClassPublic.winMapping == null)
            {
                ClassPublic.winMapping = new FormMapping();
                ClassPublic.winMapping.Show();
            }
        }

        private async void ShowTreeListForm()
        {
            await Task.Delay(100);
            if (ClassPublic.winTree == null)
            {
                ClassPublic.winTree = new FormTree();
                ClassPublic.winTree.Show();
                ClassPublic.winTree.BringToFront();
            }
        }
    }
}
