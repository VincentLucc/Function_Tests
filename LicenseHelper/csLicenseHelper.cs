using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHelper
{
    public class csLicenseHelper
    {
        public Stopwatch AppStartWatch { get; set; }

        /// <summary>
        /// Expiring time in seconds
        /// </summary>
        public int ExpireTime { get; set; }

        public bool IsLicensed { get; set; }



        public csLicenseHelper()
        {
            AppStartWatch = new Stopwatch();
            AppStart();
        }

        public void AppStart(int expSecs = 3600)
        {
            AppStartWatch.Restart();
            ExpireTime = expSecs; //One hour
        }

        public TimeSpan GetTimeLeft()
        {
            var timeAllowed = TimeSpan.FromSeconds(ExpireTime);

            var timeLeft = timeAllowed - AppStartWatch.Elapsed;

            return timeLeft < TimeSpan.Zero ? TimeSpan.Zero : timeLeft;

        }

        public string CreateLicense(string sMachineID)
        {
            if (string.IsNullOrWhiteSpace(sMachineID))
            {
                Trace.WriteLine("Empty Machine ID.");
                return null;
            }

            //Unify the format
            sMachineID = sMachineID.Replace(" ", "").Replace("-", "").Replace("_", "").Replace(".", "");

            //Get the last letters
            string sValue = string.Empty;
            int iLength = 30;
            if (sMachineID.Length >= iLength)
            {//Grab the last for letters
                sValue = sMachineID.Substring(sMachineID.Length - iLength, iLength);
            }
            else
            {//Make sure al least 4 letter exist
                sValue = sMachineID;
                while (sValue.Length < iLength) sValue += "0";
            }

            byte[] bValue = Encoding.UTF8.GetBytes(sValue);

            string sABC = Encoding.UTF8.GetString(bValue);

            return BitConverter.ToString(bValue);

        }

        public void ValidateLicense()
        {

        }

    }
}
