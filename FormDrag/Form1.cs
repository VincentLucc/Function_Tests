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

namespace FormData
{
    public partial class Form1 : Form
    {

        FormData formData { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formData = new FormData(this);
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            groupBox1.MouseDown += GroupBox1_MouseDown;
            groupBox1.MouseMove += GroupBox1_MouseMove;
            formData.MouseMove += FormData_MouseMove1;
            textBox1.Focus();
        }

        private void GroupBox1_MouseMove(object sender, MouseEventArgs e)
        {
            formData.NoticeMouseMove(e);
        }

        private void GroupBox1_MouseDown(object sender, MouseEventArgs e)
        {
            formData.NoticeMouseDown(e.Location);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
           formData.NoticeMouseDown(e.Location);
        }

        private void FormData_MouseMove1(object sender)
        {
           formData.ApplyFormDrag();
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            formData.NoticeMouseMove(e);
        }
    }
}
