using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance
{
    public class csCPUTest
    {
        public Dictionary<_testType, TimeSpan> Results = new Dictionary<_testType, TimeSpan>();

        public void TestInt(int iLoopCount = 9999)
        {
            //Init 
            Stopwatch watch = new Stopwatch();
            watch.Start();
            long lValue = 0;
            //Cal result
            for (int i = 0; i < iLoopCount; i++)
            {
                for (int j = 0; j < iLoopCount; j++)
                {
                    lValue += i * j;
                }
            }
         
            watch.Stop();
            string sMessage = $"Int Result({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms/{iLoopCount}):{lValue.ToString("n0")}";
            Trace.WriteLine(sMessage);
        }

        public enum _testType
        {
            Int = 0,
        }
    }
}
