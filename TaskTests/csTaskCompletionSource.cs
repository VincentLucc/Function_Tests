using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTests
{
    public class csTaskCompletionSourceHelper
    {
        /// <summary>
        /// 注意此Object是一次性的！！！
        /// 不要重复使用
        /// </summary>
        public static TaskCompletionSource<bool> CompletionSource = new TaskCompletionSource<bool>();


        public static string Data;

        public static Thread ServiceThread;

        public static csXtraFormEX ParentItem;

        private static bool ServiceEnable;

        public static async Task StartService(csXtraFormEX form)
        {
            ParentItem = form;
            await StopService();
            //Start new service
            ServiceEnable = true;
            ServiceThread = new Thread(ProcessAction);
            ServiceThread.Start();
        }

        public static async Task StopService()
        {
            ServiceEnable = false;
            if (ServiceThread == null) return;
            await Task.Delay(100);
            ServiceThread.Abort();
        }

        public static void ProcessAction()
        {
            Trace.WriteLine($"{csPublic.DebugTimeString} ProcessAction.Start");

            while (ServiceEnable && !ParentItem.UIExit)
            {
                Thread.Sleep(2000);
                Data = csPublic.DebugTimeString;
                CompletionSource?.TrySetResult(true);
            }

            Trace.WriteLine($"{csPublic.DebugTimeString} ProcessAction.End");
        }

        public static async Task RequestSampleJob(int iTimeoutMS)
        {
            // 注意此Object是一次性的！！！
            CompletionSource = new TaskCompletionSource<bool>();
            Trace.WriteLine($"{csPublic.DebugTimeString} RequestSampleJob.Start");
            var taskAction = CompletionSource.Task;
            var taskDelay = Task.Delay(iTimeoutMS);
            var taskComplete = await Task.WhenAny(new Task[] { taskAction, taskDelay });
            if (taskComplete == taskAction)
            {//Finished without issue
                Trace.WriteLine($"{csPublic.DebugTimeString} RequestSampleJob.Complete:{Data}");
            }
            else
            {//Timeout
                Trace.WriteLine($"{csPublic.DebugTimeString} RequestSampleJob.Timeout: {iTimeoutMS}ms");
            }
           
        }
    }
}
