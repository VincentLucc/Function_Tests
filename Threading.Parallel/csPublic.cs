using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Threading_Parallel
{
    class csPublic
    {

        /// <summary>
        /// Successs: Return physical core
        /// Fail: Return logic core
        /// </summary>
        /// <returns></returns>
        public static int GetPhysicalCoreCount()
        {

            try
            {
                var query = "SELECT NumberOfCores FROM Win32_Processor";
                var searcher = new ManagementObjectSearcher(query);
                foreach (var item in searcher.Get())
                {
                    return int.Parse(item["NumberOfCores"].ToString());
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} GetPhysicalCoreCount.Exception:{ex.Message}");
            }

            //Default value
            return Environment.ProcessorCount; // Fallback
        }
    }
}
