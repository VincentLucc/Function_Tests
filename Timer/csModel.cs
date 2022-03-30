using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationBlock
{
    class csModel
    {
    }

    /// <summary>
    /// Used to fullly block operation for a timer with blocked trigger
    /// </summary>
    public class LoopBlocker
    {
        public bool Enable { get; set; }
        /// <summary>
        /// Operation successfully blocked
        /// </summary>
        public bool IsBlocked { get; set; }
        /// <summary>
        /// Block timeout
        /// </summary>
        public int TimeOut { get; set; }

        public LoopBlocker()
        {
            TimeOut = 5000;
        }

        public void StartBlock()
        {
            Enable = true;
            IsBlocked = false;
        }

        public void StopBlock()
        {
            Enable = false;
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
                if (stopwatch.ElapsedMilliseconds > TimeOut)
                {
                    Debug.WriteLine($"WaitForBlock Timeout:{stopwatch.ElapsedMilliseconds} ms");
                    return;
                }
            }

            stopwatch.Stop();
            Debug.WriteLine($"WaitForBlock:{stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
