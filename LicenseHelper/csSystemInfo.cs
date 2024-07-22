using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;


namespace LicenseHelper
{
    public class csSystemInfo
    {
        private static ManagementObjectSearcher hardDrive = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");


        public static string GetSystemID()
        {
            Stopwatch watch = Stopwatch.StartNew();
            try
            {
                //Init
                //string sSearchCMD = "SELECT * FROM Win32_OperatingSystem"; //First Time:206ms,after:163ms
                string sSearchCMD = "SELECT SerialNumber FROM Win32_OperatingSystem"; //First Time:163ms, after:27.7ms
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", sSearchCMD);
                string sResult = null;
                Trace.WriteLine($"GetSystemID({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms): Init.");
                var enumerator= searcher.Get();
                Trace.WriteLine($"GetSystemID({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms): Get enumerator.");

                foreach (var item in enumerator)
                {
                    sResult = item["SerialNumber"].ToString();
                    Trace.WriteLine($"GetSystemID({watch.Elapsed.TotalMilliseconds.ToString("f1")}ms): {sResult}");
                    return sResult;
                }

                return null;
            }
            catch (Exception ex)
            {
               Trace.WriteLine($"GetSystemID:{ex.Message}");
               return null;
            }
        }

        /// <summary>
        /// OK but too slow
        /// </summary>
        /// <returns></returns>
        public static string GetCPUId()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        /// <summary>
        /// 使用命令行
        /// </summary>
        /// <returns></returns>
        public static string GetUUID()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }

        /// <summary>
        /// Get the main harddrive ID
        /// </summary>
        public static string FirstHardDriveID
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in hardDrive.Get())
                    {

                        string sID = queryObj["SerialNumber"].ToString();
                        if (string.IsNullOrWhiteSpace(sID)) return "";
                        sID = sID.Trim().ToUpper();

                        //Tag="\\\.\\PHYSICALDRIVE0"
                        string sTag = queryObj["DeviceID"].ToString();
                        sTag = sTag.Trim().ToUpper();
                        if (sTag.EndsWith("PHYSICALDRIVE0")) return sID;

                    }
                    return "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
        }
    }
}
