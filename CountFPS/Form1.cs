using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountFPS
{
    public partial class Form1 : Form
    {
        csFPS itemFPS = new csFPS();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //must run frequently
            itemFPS.UpdateFPS();

            itemFPS.AddCount();

            //Show result
            FPSTextEdit.Text = itemFPS.FPS.ToString("f1");
        }
    }
}
