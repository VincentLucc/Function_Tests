using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHelper
{
    public class csSystemInfo
    {
        private static ManagementObjectSearcher hardDrive = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

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
