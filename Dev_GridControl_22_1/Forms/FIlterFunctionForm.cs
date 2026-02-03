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
using _CommonCode_Dev22;

namespace Dev_GridControl_22_1.Forms
{
    public partial class FIlterFunctionForm : DevExpress.XtraEditors.XtraForm
    {
        public FIlterFunctionForm()
        {
            InitializeComponent();
        }

        private void FIlterFunctionForm_Load(object sender, EventArgs e)
        {
            //Prepare data

            List<Student> students = new List<Student>();
            for (int i = 0; i < 119000; i++)
            {
                var stu = new Student();
                stu.Age = i;
                stu.Name = i.ToString();
                stu.Class = i.ToString();
                stu.Enable = true;
                students.Add(stu);
            }

            gridControl1.DataSource = students;
            //This option is different from the filter function
            gridView1.OptionsFind.AlwaysVisible = true; //Show the find panel

            //Find mode: default <10,000, auto, >10,000 manual
            //gridView1.OptionsFind.FindMode = FindMode.FindClick;
            //gridView1.OptionsFind.FindMode = FindMode.Always;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void ForceVisibleButton_Click(object sender, EventArgs e)
        {
            gridView1.ForceVisible((int)TargetIndexSpinEdit.Value);
        }
    }
}