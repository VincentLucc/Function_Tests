using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevLayout_19_1
{
    public partial class ucGridDemo : UserControl
    {

        List<Student> students { get; set; }

        public ucGridDemo()
        {
            InitializeComponent();
        }

        private void gridControl1_Load(object sender, EventArgs e)
        {
            students = new List<Student>();

            for (int i = 0; i < 5; i++)
            {
                Student s = new Student()
                {
                    Name=$"STest_{i+2}",
                    Age=i+1,
                };

                students.Add(s);
            }

            gridControl1.DataSource = students;
        }
    }
}
