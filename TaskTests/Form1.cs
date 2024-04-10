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

namespace TaskTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void CancelWithFlagButton_Click(object sender, EventArgs e)
        {
            bool enableFlag = true;

            Task t1 = new Task(() =>
            {

                while (enableFlag)
                {
                    Thread.Sleep(2000);
                }

                Debug.WriteLine("Task Complete");
            });
            t1.Start();
            Thread.Sleep(50); //Make sure start started!!!

            enableFlag = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            t1.GetAwaiter().GetResult();
            Debug.WriteLine($"Stop with flag:{stopwatch.ElapsedMilliseconds}");
        }

        private void CancelWIthTokenButton_Click(object sender, EventArgs e)
        {
            CancellationTokenSource t1Token = new CancellationTokenSource();

            Task t1 = new Task(() =>
            {
                t1Token.Token.ThrowIfCancellationRequested();

                while (this.Visible && !t1Token.IsCancellationRequested)
                {
                    Thread.Sleep(2000);
                    Debug.WriteLine("Looping");
                }

                Debug.WriteLine("Task Complete");
            });
            t1.Start();
          

            Thread.Sleep(50); //Make sure start started!!!

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            t1Token.Cancel();
            t1.Wait();//Wait and block main thread
            Debug.WriteLine($"Stop with flag:{stopwatch.ElapsedMilliseconds}");
        }
    }
}
