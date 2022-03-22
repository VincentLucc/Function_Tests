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
        System.Windows.Forms.Timer tTest1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tTest1 = new System.Windows.Forms.Timer();
            tTest1.Interval = 200;
            tTest1.Tick += T1_Tick;
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            var t1 = (System.Windows.Forms.Timer)sender;
            t1.Enabled = false;

            DoSth();

            t1.Enabled = true;
        }

        public object operationLock = new object();

        public static bool IsBusy { get; private set; }
        public static string WorkingON { get; private set; }

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
            tTest1.Enabled = true;
            DoSth();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void bAwaitTime_Click(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            long[] spans = new long[10];
            watch.Start();
            DoSthAsync();
            spans[0] = watch.ElapsedMilliseconds;
            
            await WaitForBlockAsync();
            DoSth();
            spans[1] = watch.ElapsedMilliseconds;

            //Get operation time
            Debug.WriteLine($"Opeartion time s0:{spans[0]}:s1:{spans[1]}");
        }

        private async Task DoSthAsync()
        {
            IsBusy = true;

            lock (operationLock)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                      Task.Delay(10);
                    }

                    Debug.WriteLine(i + 1);
                }
            }

            IsBusy = false;
        }

        public static async Task<bool> WaitForBlockAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool IsShown = false;

            while (IsBusy)
            {
                //Display wait target once
                while (!IsShown)
                {
                    Debug.WriteLine("WaitForBlockAsync:" + WorkingON);
                    IsShown = true;
                }
                await Task.Delay(20);
                if (stopwatch.ElapsedMilliseconds > 30000)
                {
                    Debug.WriteLine($"WaitForBlockAsync.Timeout:{stopwatch.ElapsedMilliseconds} ms");
                    return false;
                }
            }

            Debug.WriteLine("WaitForBlockAsync:" + stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();
            return true;
        }
    }
}
