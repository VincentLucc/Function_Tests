using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolTip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Winform tip
            toolTip1.SetToolTip(panel1,"Test");

            //Devexpress
            toolTipController1.SetToolTip(bTipTest2201,"Test2");
        }

        private void bTipTest2201_Click(object sender, EventArgs e)
        {

        }
    }
}
