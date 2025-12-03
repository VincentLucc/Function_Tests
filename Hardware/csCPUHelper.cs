using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hardware
{
    public class csCPUHelper
    {
        public static bool[] CoreSettings { get; set; } = new bool[64];

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll")]
        static extern bool SetProcessAffinityMask(IntPtr hProcess, IntPtr dwAffinityMask);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CoreSettings"></param>
        public static bool SetProcessAffinity(bool[] CoreSettings, out string sMessage)
        {
            //Init
            sMessage = string.Empty;

            try
            {
                BitArray bitArray = new BitArray(CoreSettings);
                //Sample data is: 0x00FFFFFF,Byte[4]
                byte[] byteSettings = new byte[8];
                bitArray.CopyTo(byteSettings, 0);
                IntPtr affinityMask = new IntPtr(BitConverter.ToInt64(byteSettings, 0)); // 0b00000011
 
                //Set process
                var currentProcess = GetCurrentProcess();
                bool success = SetProcessAffinityMask(currentProcess, affinityMask);
                if (!success)
                {
                    sMessage = "Set CPU affinity error.";
                    return false;
                }
                    

                //Pass all
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                sMessage = e.Message;
                return false;
            }

        }

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
