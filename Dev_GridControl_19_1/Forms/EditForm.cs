using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_19_1.Forms
{
    public partial class EditForm : DevExpress.XtraEditors.XtraForm
    {
        List<Student> sData;

        public EditForm()
        {
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            sData = new List<Student>();
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
            gridView1.OptionsEditForm.CustomEditFormLayout = new ucEditForm();
            gridView1.EditFormPrepared += GridView1_EditFormPrepared;//Run before visible
            gridView1.CustomRowCellEdit += GridView1_CustomRowCellEdit;
            gridView1.RowCellClick += GridView1_RowCellClick;
            gridView1.CellValueChanging += GridView1_CellValueChanging;
        }

        private void GridView1_EditFormPrepared(object sender, DevExpress.XtraGrid.Views.Grid.EditFormPreparedEventArgs e)
        {
             
        }

        private void GridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (e.Column.FieldName== nameof(Student.Enable2))
            {
                var rowData=(Student)gridView1.GetRow(e.RowHandle);
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