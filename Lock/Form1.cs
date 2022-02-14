using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
            t1.Interval = 200;
            t1.Enabled = true;
            t1.Tick += T1_Tick;
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            var t1 = (System.Windows.Forms.Timer)sender;
            t1.Enabled = false;

            DoSth();

            t1.Enabled = true;
        }

        public object operationLock = new object();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DoSth();
        }

        private void DoSth()
        {

            lock (operationLock)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        Thread.Sleep(10);
                        Application.DoEvents();
                    }

                    Debug.WriteLine(i + 1);
                }
            }

        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            DoSth();
        }
    }
}
