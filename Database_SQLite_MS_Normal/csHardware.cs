using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Database_SQLite_MS_Normal
{
    public class csHardware
    {
        private static ManagementObjectSearcher baseboardSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        private static ManagementObjectSearcher hardDrive = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMedia");


        /// <summary>
        /// Get the main harddrive ID
        /// </summary>
        static public string FirstHardDriveID
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in hardDrive.Get())
                    {

                        string sID = queryObj["SerialNumber"].ToString();
                        sID = sID.Trim().ToUpper();

                        //Tag="\\\.\\PHYSICALDRIVE0"
                        string sTag = queryObj["Tag"].ToString();
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

        static public string BoardSerialNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in baseboardSearcher.Get())
                    {
                        return queryObj["SerialNumber"].ToString();
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
