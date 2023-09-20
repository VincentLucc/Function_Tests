using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketTool_Framework
{
    public class csThreadHelper
    {
        public static async Task WaitThreadClose(Thread thread)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool writeAlert = true;

            if (thread == null) return;
            while (thread.IsAlive)
            {
                await Task.Delay(10);
                if (writeAlert && stopwatch.ElapsedMilliseconds > 10 * 1000)
                {
                    writeAlert = false;
                    if (string.IsNullOrWhiteSpace(thread.Name))
                    {
                        Debug.WriteLine($"Close thread timeout: {stopwatch.ElapsedMilliseconds}ms.");
                    }
                    else
                    {
                        Debug.WriteLine($"Close thread:{thread.Name}, timeout {stopwatch.ElapsedMilliseconds}ms.");
                    }

                }

            }


            stopwatch.Stop();
            if (string.IsNullOrWhiteSpace(thread.Name))
            {
                Debug.WriteLine($"Thread closed:{stopwatch.ElapsedMilliseconds}ms.");
            }
            else
            {
                Debug.WriteLine($"Thread closed:{thread.Name}, {stopwatch.ElapsedMilliseconds}ms.");
            }

        }
    }
}
