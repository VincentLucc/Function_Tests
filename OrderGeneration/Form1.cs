using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderGeneration
{
    public partial class Form1 : Form
    {

        List<Student> Students= new List<Student>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                var stu = new Student(i);
                Students.Add(stu);
            }

            var stu2 = Students[2];
            Students.Remove(stu2);
            stu2.Description = "LocationChanged";
            Students.Add(stu2);
        }
    }
}
