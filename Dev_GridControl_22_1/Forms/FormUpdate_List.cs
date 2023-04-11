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
    public partial class FormUpdate_List : DevExpress.XtraEditors.XtraForm
    {

        List<Student> students = new List<Student>();

        public FormUpdate_List()
        {
            InitializeComponent();
        }

        private void FormUpdateTest_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var stu = new Student()
               {
                   Age=i,
                   Name="Stu_"+i.ToString(),
                   Class=i.ToString()
               };

                students.Add(stu);
            }

            gridControl1.DataSource = students;
        }

        private void bInsert_Click(object sender, EventArgs e)
        {

            //Scroll bar change will force the grid view to update it's source

            int iSTu = students.Count;
            var stu = new Student()
            {
                Age = iSTu,
                Name = "Stu_" + iSTu.ToString(),
                Class = iSTu.ToString()
            };

            students.Add(stu);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            gridControl1.Refresh();
        }
    }
}