using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student sTest = new Student()
                {Age=i+1,Name=$"Test{i+1}" };
                students.Add(sTest);
            }

            gridControl1.DataSource = students;

            SetEditor(false);

        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            SetEditor(toggleSwitch1.IsOn);
        }

        private void SetEditor(bool IsCustom)
        {
            if (IsCustom)
            {
                gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm; //Set edit mode
                var customEdtor = new ucEditForm();
                gridView1.OptionsEditForm.CustomEditFormLayout = customEdtor;
            }
            else
            {
                gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm; //Set edit mode
                var columns = gridView1.Columns;
                //Set visibi;ity
                gridView1.Columns[nameof(Student.Name)].Visible = true;
                gridView1.Columns[nameof(Student.List)].Visible = false;
            }
        }
    }
}
