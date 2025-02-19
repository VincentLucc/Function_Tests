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
    public partial class MainForm : csXtraFormEX
    {
        public MainForm()
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

        private async void BlockingCollection1Button_Click(object sender, EventArgs e)
        {
            await csBlockingCollectionHelper.StartService(this);
        }

        private void AddBlockingItemButton_Click(object sender, EventArgs e)
        {
            csBlockingCollectionHelper.AddItem();
        }

        private async void StopBlockingServiceButton_Click(object sender, EventArgs e)
        {
            await csBlockingCollectionHelper.StopService();
        }

        private async void StartCompletionServiceButton_Click(object sender, EventArgs e)
        {
            await csTaskCompletionSourceHelper.StartService(this);
        }

        private async void SampleCommmandButton_Click(object sender, EventArgs e)
        {
            await csTaskCompletionSourceHelper.RequestSampleJob();
        }

        private async void StopCompletionService_Click(object sender, EventArgs e)
        {
            await csTaskCompletionSourceHelper.StopService();
        }
    }
}
