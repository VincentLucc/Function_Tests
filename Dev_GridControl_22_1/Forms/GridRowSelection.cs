using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl_22_1.Forms
{
    public partial class GridRowSelection : DevExpress.XtraEditors.XtraForm
    {
        public GridRowSelection()
        {
            InitializeComponent();
        }

        private void GridRowSelection_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                var student = new Student()
                {
                    Name = "Stu_" + i.ToString("d2"),
                    Age = i,
                    Class = "C_" + i.ToString("d2"),
                };
                students.Add(student);
            }

            
            gridControl1.DataSource = students;
            
        }

        private void tsSelectionEnable_Toggled(object sender, EventArgs e)
        {
            if (tsSelectionEnable.IsOn)
            {
                gridView1.OptionsSelection.MultiSelect= true;
                //Show check box
                gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
            else
            {
                gridView1.OptionsSelection.MultiSelect = false;
            }
        }

        private void bGetSelection_Click(object sender, EventArgs e)
        {
            //Selection is in order by default
            var selections= gridView1.GetSelectedRows();
            
        }
    }
}