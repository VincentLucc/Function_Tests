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

        public double GetScore(_cpuTestType type, TimeSpan time)
        {
            //Init 
            double dScore = -1;

            if (type == _cpuTestType.Int)
            {//Use base time line 1000ms as 100 score
                dScore = 100 * (1000 / time.TotalMilliseconds);
                Trace.WriteLine($"Int Score:{dScore.ToString("n2")}");
            }
            else if (type == _cpuTestType.Double)
            {//Use base time line 1500ms as 100 score
                dScore = 100 * (1500 / time.TotalMilliseconds);
                Trace.WriteLine($"Double Score:{dScore.ToString("n2")}");
            }


            if (dScore == -1)
            {
                Trace.WriteLine($"GetScore({type}): Not Implemented.");
            }

            return dScore;
        }

        public TimeSpan TestIntAction(int iLoopCount = 9999)
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
            return watch.Elapsed;
        }

        public double TestCPUPerf()
        {
            Trace.WriteLine($"---CPU overall started");
            double dIntResult = TestIntProcess(19999);
            double dFloatResult = TestDoubleProcess(19999);

            double dTotal = dIntResult + dFloatResult;
            Trace.WriteLine($"CPU overall score:{dTotal.ToString("n")}");
            return dTotal;
        }

        public double TestIntProcess(int iLoopCount = 9999)
        {
            var timeSpent = TestIntAction(iLoopCount);
            var score = GetScore(_cpuTestType.Int, timeSpent);
            return score;
        }

        public double TestDoubleProcess(int iLoopCount = 9999)
        {
            var timeSpent = TestDoubleAction(iLoopCount);
            var score = GetScore(_cpuTestType.Double, timeSpent);
            return score;
        }


        public TimeSpan TestDoubleAction(double dLoopCount = 9999)
        {
            //Init 
            Stopwatch watch = new Stopwatch();
            watch.Start();
            double dValue = 0;
            double dBase = 0.6180339887;
            //Cal result
            for (double i = dBase; i < dLoopCount; i++)
            {
                for (double j = dBase; j < dLoopCount; j++)
                {
                    dValue += i * j;
                }
            }

            watch.Stop();
            string sMessage = $"Double Result({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms/{dLoopCount}):{dValue.ToString("n0")}";
            Trace.WriteLine(sMessage);
            return watch.Elapsed;
        }

    }

    public enum _cpuTestType
    {
        Int = 0,
        Double = 1,
    }
}
