using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SocketTool_Framework
{
    public class csPublic
    {
        /// <summary>
        /// Get mac address info
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetMacAddress()
        {
            Dictionary<string, string> sList = new Dictionary<string, string>();

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    string sName = netInterface.Name;
                    byte[] bData = netInterface.GetPhysicalAddress().GetAddressBytes();
                    string sMac = BitConverter.ToString(bData);
                    sList.Add(sName, sMac);
                }
            }

            return sList;
        }
    }


    public class RegString
    {
        public const string IPAddress = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
    }
}
