using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraWizard;
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

namespace Dev_GridControl_22_1.Forms
{
    public partial class CustomBindingEditForm : Form
    {

        BindingList<Student> students;

        RepositoryItemButtonEdit ButtonEdit;

        public CustomBindingEditForm()
        {
            InitializeComponent();
        }

        private void CustomBindingEditForm_Load(object sender, EventArgs e)
        {
            students = new BindingList<Student>();
            csPublic.InitGridview(gridView1, true, true);
            csPublic.SetGridViewAlignment(gridView1, HorzAlignment.Center);
            gridView1.CustomRowCellEdit += GridView1_CustomRowCellEdit;
            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.ValidatingEditor += GridView1_ValidatingEditor;
            gridView1.RowCellClick += GridView1_RowCellClick;
            gridView1.InitNewRow += GridView1_InitNewRow;
            gridControl1.DataSource = students;
            gridView1.MouseDown += GridView1_MouseDown;


            //Init grid control
            ButtonEdit = new RepositoryItemButtonEdit();
            ButtonEdit.EditValueChanged += ButtonEdit_EditValueChanged;
            ButtonEdit.ButtonClick += ButtonEdit_ButtonClick;
            ButtonEdit.Click += ButtonEdit_Click;

        }

        private void GridView1_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("GridView1_MouseDown:" + e.Button);
            if (gridView1.FocusedRowHandle < 0 && gridView1.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                //var hitInfo = gridView1.CalcHitInfo(e.Location);

                //gridView1.AddNewRow();
                //gridView1.UpdateCurrentRow();
                //gridView1.FocusedRowHandle= gridView1.RowCount;//Select current row
            }

        }

        private void GridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            Debug.WriteLine("GridView1_ValidatingEditor:" + e.Value);
        }

        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            Debug.WriteLine("GridView1_InitNewRow:" + e.RowHandle);

        }

        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

            if (gridView1.FocusedRowHandle < 0 && e.Column.FieldName == nameof(Student.Enable2))
            {
                var hitInfo = gridView1.CalcHitInfo(e.Location);
            }


        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("ButtonEdit_Click:" + e.ToString());


        }

        private void ButtonEdit_EditValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("ButtonEdit_EditValueChanged:" + e.ToString());
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Debug.WriteLine("GridView1_ValidateRow:" + e.RowHandle);
        }

        private void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iHandle = gridView1.FocusedRowHandle;
            Debug.WriteLine(iHandle);

            //Can read new item row
            var rowData = gridView1.GetDataRow(iHandle); //No read
            var row1 = gridView1.GetRow(iHandle);//With value, can read new row
            var row2 = gridView1.GetFocusedRow();
            gridView1.GetFocusedDataRow();

            if (row1 == null)
            {
                Debug.WriteLine("Empty");
            }
            else
            {
                Debug.WriteLine("OK");
            }


        }

        private void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            if (e.Column.FieldName == nameof(Student.Enable2))
            {
                e.RepositoryItem = ButtonEdit;
            }

        }
    }
}
