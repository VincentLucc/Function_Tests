using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationBlock
{
    class csModel
    {
    }

    public class ButtonOperationGroup
    {
        public bool IsOperating { get; set; }
        public string WorkingOn { get; set; }

        /// <summary>
        /// Indicate wether allow form closing during operation, default false
        /// </summary>
        public bool AllowFormClose { get; set; }

        public bool RequestButtonOperation(string sCurrentOperation)
        {
            //Check button busy
            if (IsOperating)
            {
                MessageBox.Show($"Operating on {sCurrentOperation}, please wait.");
                return false;
            }

            WorkingOn = sCurrentOperation;
            IsOperating = true;
            AllowFormClose = false;
            return true;
        }
    }

    /// <summary>
    /// Used to fullly block operation for a timer with blocked trigger
    /// </summary>
    public class LoopBlocker
    {

        public bool EnableBlock { get; set; }

        public Stopwatch MonitorWatch { get; set; }

        /// <summary>
        /// Use main thread timer, this is performance intensive
        /// </summary>
        public Timer MonitorTimer { get; set; }
 
        /// <summary>
        /// Operation successfully blocked
        /// </summary>
        public bool IsBlocked { get; set; }
        /// <summary>
        /// Block timeout
        /// </summary>
        public int BlockTimeOut { get; set; }

        /// <summary>
        /// Whether automatically stop blocking after certain amount of duration
        /// Incase no further request is received
        /// </summary>
        public bool AutoResumeEnable { get; set; }
        public int AutoResumeTime { get; set; }

        public LoopBlocker()
        {
            BlockTimeOut = 5000;
            AutoResumeEnable = true;
            AutoResumeTime = 30000; //Will automatically stop blocking, incase no further resume request received
            MonitorWatch = new Stopwatch();
            MonitorTimer = new Timer();
            MonitorTimer.Interval = 200;//Not critical
            MonitorTimer.Tick += MonitorTimer_Tick;
            MonitorTimer.Start();
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            //Only process when block is enabled
            if (!EnableBlock || !AutoResumeEnable) return;

            if (MonitorWatch.ElapsedMilliseconds> AutoResumeTime)
            {
                StopBlock();
            }        
        }

        public void StartBlock()
        {
            EnableBlock = true;
            IsBlocked = false;
            MonitorWatch.Restart();
        }

        public void StopBlock()
        {
            EnableBlock = false;
            MonitorWatch.Stop();
        }

        public async Task BlockAndWaitAsync()
        {
            StartBlock();
            await WaitForBlockAsync();
        }

        public async Task WaitForBlockAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!IsBlocked)
            {
                await Task.Delay(20);
                if (stopwatch.ElapsedMilliseconds > BlockTimeOut)
                {
                    Debug.WriteLine($"LoopBlocker.WaitForBlock Timeout:{stopwatch.ElapsedMilliseconds} ms");
                    return;
                }
            }

            stopwatch.Stop();
            Debug.WriteLine($"LoopBlocker.WaitForBlock:{stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
