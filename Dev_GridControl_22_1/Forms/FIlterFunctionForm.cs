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
            gridView1.OptionsFind.AlwaysVisible = true; //Show filter button

            //Find mode: default <10,000, auto, >10,000 manual
            //gridView1.OptionsFind.FindMode = FindMode.FindClick;
            //gridView1.OptionsFind.FindMode = FindMode.Always;

        }
    }
}