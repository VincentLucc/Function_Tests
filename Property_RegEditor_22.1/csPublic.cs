using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Property_RegEditor_22._1
{
    public class csPublic
    {
        /// <summary>
        /// Get mac address info
        /// </summary>
        /// <returns></returns>
        public static List<MacInfo> GetMacAddress()
        {
            List<MacInfo> sList = new List<MacInfo>();

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    string sName = netInterface.Name;
                    byte[] bData = netInterface.GetPhysicalAddress().GetAddressBytes();
                    string sMac = BitConverter.ToString(bData);
                    sList.Add(new MacInfo(sName, sMac));
                }
            }

            return sList;
        }


    }
}
