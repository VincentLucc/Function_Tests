using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.Utils;
using System.Reflection;

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

        /// <summary>
        /// SIngle thread performance testing
        /// </summary>
        /// <returns></returns>
        public double GetCPUPerfAll()
        {
            Trace.WriteLine($"---CPU overall started");
            double dIntResult = TestIntProcess(19999);
            double dFloatResult = TestDoubleProcess(19999);

            double dTotal = dIntResult + dFloatResult;
            Trace.WriteLine($"CPU overall score:{dTotal.ToString("n")}");
            return dTotal;
        }


        public double TestCPUPerSingle()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var dResult = GetCPUPerfAllTimeout(watch, 10000);
            watch.Stop();
            Trace.WriteLine($"CPU Perf. Single({watch.Elapsed.TotalMilliseconds.ToString("n0")}ms):{dResult.ToString("n0")}");
            return dResult;
        }
        public async Task<double> TestCPUPerMulti()
        {
            //Init
            int iCPUCount = Environment.ProcessorCount; //CPU logical processors
            Stopwatch watch = new Stopwatch();
            watch.Start();
            List<Task<double>> taskList = new List<Task<double>>();
            List<double> Scores = new List<double>();

            //Run tasks
            taskList.Clear();
            for (int i = 0; i < iCPUCount; i++)
            {//Run the task at least 10 seconds
                taskList.Add(Task.Run(() => GetCPUPerfAllTimeout(watch, 10000)));
            }
            double[] results = await Task.WhenAll(taskList);
            double dResult = results.Sum();

            //Result
            StringBuilder builder = new StringBuilder();
            builder.Append($"CPU Multiple Threads({taskList.Count},{watch.Elapsed.TotalMilliseconds.ToString("n0")}ms):");
            builder.Append($"{dResult.ToString("n0")}-->");
            for (int i = 0; i < results.Length; i++)
            {
                if (i == 0) builder.Append($"{results[i].ToString("n0")}");
                else builder.Append($", {results[i].ToString("n0")}");
            }

            Trace.WriteLine(builder.ToString());
            return dResult;
        }

        /// <summary>
        /// Get the cpu performance with multiple attempt which will last at least certain period
        /// </summary>
        /// <param name="watch"></param>
        /// <param name="iTimeout"></param>
        /// <returns></returns>
        public double GetCPUPerfAllTimeout(Stopwatch watch, int iTimeout)
        {
            List<double> results = new List<double>();

            RunOnce:
            double dScore = GetCPUPerfAll();
            results.Add(dScore);
            if (watch.ElapsedMilliseconds < iTimeout) goto RunOnce;
            double dScoreFinal = results.Average();
            
            //Prepare display
            StringBuilder builder = new StringBuilder();
            builder.Append($"GetCPUPerfAllTimeout({results.Count}): {dScoreFinal},  Values:");
            for (int i = 0; i < results.Count; i++)
            {
                if (i == 0) builder.Append($"{results[i].ToString("n0")}");
                else builder.Append($", {results[i].ToString("n0")}");
            }
            Trace.WriteLine(builder.ToString());
            return dScoreFinal;
        }

        public int GetNumberOfCores()
        {
            var coreCount = 0;
            const string wmiQuery = "Select * from Win32_Processor";
            foreach (var item in new ManagementObjectSearcher(wmiQuery).Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }
            return coreCount;
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

        public TimeSpan TestFloatAction(float fLoopCount = 9999)
        {
            //Init 
            Stopwatch watch = new Stopwatch();
            watch.Start();
            float fValue = 0;
            float dBase = 0.6180339887f;
            //Cal result
            for (float i = dBase; i < fLoopCount; i++)
            {
                for (float j = dBase; j < fLoopCount; j++)
                {
                    fValue += i * j;
                }
            }

            watch.Stop();
            string sMessage = $"Float Result({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms/{fLoopCount}):{fValue.ToString("n0")}";
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
