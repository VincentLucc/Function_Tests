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

namespace FormLoad
{
    public partial class FormEvent : Form
    {
        public FormEvent()
        {
            InitializeComponent();
        }

        private void FormEvent_Load(object sender, EventArgs e)
        {
            bTest.Click += BTest_Click;
        }

        private void BTest_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":Output Test");
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(DateTime.Now.ToString() + ":Output Once");
        }
    }
}
