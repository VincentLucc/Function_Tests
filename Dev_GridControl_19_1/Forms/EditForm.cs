using DevExpress.Utils;
using DevExpress.XtraEditors;
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

namespace Dev_GridControl_19_1.Forms
{
    public partial class EditForm : DevExpress.XtraEditors.XtraForm
    {
         BindingList<Student> sData;

        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            sData = new BindingList<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student stu = new Student()
                {
                    Name = "Name_" + i,
                    Class = "class",
                    Age = i + 1
                };
                sData.Add(stu);
            }

            gridControl1.DataSource = sData;
            gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            gridView1.OptionsEditForm.CustomEditFormLayout = new ucEditForm(gridView1);
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridView1.OptionsBehavior.Editable= true;
            gridView1.EditFormPrepared += GridView1_EditFormPrepared;//Happens after init new row
            gridView1.EditFormShowing += GridView1_EditFormShowing;
            gridView1.CustomRowCellEdit += GridView1_CustomRowCellEdit;
            gridView1.RowCellClick += GridView1_RowCellClick;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
            gridView1.InitNewRow += GridView1_InitNewRow;
            

        }

        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            Debug.WriteLine("GridView1_InitNewRow");
            if (gridView1.OptionsEditForm.CustomEditFormLayout is ucEditForm)
            {
                var editForm = gridView1.OptionsEditForm.CustomEditFormLayout as ucEditForm;
                editForm.LoadAction();
            }
        }

        private void GridView1_EditFormShowing(object sender, DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs e)
        {
            Debug.WriteLine("GridView1_EditFormShowing");
            var rowData = gridView1.GetFocusedRow();
        }

        private void GridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
            Debug.WriteLine("GridView1_EditFormPrepared:\r\n");
            var row = gridView1.GetRow(gridView1.FocusedRowHandle);

            if (gridView1.OptionsEditForm.CustomEditFormLayout is ucEditForm)
            {
                var editForm = gridView1.OptionsEditForm.CustomEditFormLayout as ucEditForm;
                editForm.LoadAction();
            }
        }

        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName == nameof(Student.Enable2))
            {
                var rowData = (Student)gridView1.GetRow(e.RowHandle);
                rowData.Enable2 = !rowData.Enable2;
                gridControl1.RefreshDataSource();
            }
            else if (e.Column.FieldName == nameof(Student.Enable))
            {
                var rowData = (Student)gridView1.GetRow(e.RowHandle);
                rowData.Enable = !rowData.Enable;
                gridControl1.RefreshDataSource();
            }
        }

        private void GridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == nameof(Student.Enable))
            {
                if (gridView1.OptionsBehavior.EditingMode != DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace)
                {

                }
            }
        }

        private void GridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == nameof(Student.Enable))
            {
                e.RepositoryItem = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            }
        }
    }
}