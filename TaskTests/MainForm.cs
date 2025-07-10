using _CommonCode_Framework;
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

        private async void CancelWIthTokenButton_Click(object sender, EventArgs e)
        {
            //Global variable
            CancellationTokenSource t1Token = new CancellationTokenSource();

            //Start the task
            var Task1= Task.Run(async () =>
            {
                "CancelWithToken.TaskStarted".TraceRecord();
                while (this.Visible && !t1Token.IsCancellationRequested)
                {
                    try
                    {
                        t1Token.Token.ThrowIfCancellationRequested();

                        //Time consuming action
                        await Task.Delay(1000, t1Token.Token);
                    }
                    catch (TaskCanceledException ex)
                    {//Break the loop
                        "CancelWithToken.TaskCancelled".TraceRecord();
                        break;
                    }
                    catch (Exception ex)
                    {//Allow other exception
                        ex.TraceException("CancelWithToken.OtherException.Continue");
                        continue;
                    }
                 
                    "CancelWithToken.Looping".TraceRecord();
                }

                "CancelWithToken.Complete".TraceRecord();
            });
         

            //Start control call
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            t1Token.CancelAfter(3000);
            await Task1;
            $"CancelWithToken.CallEnd:{stopwatch.ElapsedMilliseconds}ms".TraceRecord();

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
            await csTaskCompletionSourceHelper.RequestSampleJob(1000);
        }

        private async void StopCompletionService_Click(object sender, EventArgs e)
        {
            await csTaskCompletionSourceHelper.StopService();
        }
    }
}
