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

namespace ThreadingDelay
{
    public partial class Form1 : Form
    {
        Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Task delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(DoSomeTaskDelay);
            t1.Start();
        }


        private async void DoSomeTaskDelay()
        {
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {    //Minimum 15ms
                //No CPU usage changes
                await Task.Delay(5);
            }
            stopwatch.Stop();
            Debug.WriteLine("DoSomeTaskDelay:"+ stopwatch.ElapsedMilliseconds);
        }

        private void DoSomeThreadSleep()
        {
            stopwatch.Restart();
            for (int i = 0; i < 1000; i++)
            {//Minimum 2ms on , use 5ms  
                Thread.Sleep(5);
            }
            stopwatch.Stop();
            Debug.WriteLine("DoSomeThreadSleep:" + stopwatch.ElapsedMilliseconds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t2 = new Thread(DoSomeThreadSleep);
            t2.Start();
        }
    }
}
