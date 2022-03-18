using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLTests
{
    [XmlRoot("InkManagerSetup")]
    public class InkSysConfig
    {
        public _commInterfaces CommInterface { get; set; }
        public string IPAddress { get; set; }
        public string COMPortName { get; set; }
        public List<InkDeviceConfig> DeviceCollection { get; set; }

        public InkSysConfig()
        {
            DeviceCollection = new List<InkDeviceConfig>();
            CommInterface = _commInterfaces.Serial;
        }
    }

    public class InkDeviceConfig
    {
        public string Name { get; set; }
        public int NetworkID { get; set; }
        public _inkSysType Type { get; set; }

        /// <summary>
        /// Contains heater or not
        /// </summary>
        public bool HeaterFuntion { get; set; }
        /// <summary>
        /// Degass function visibility
        /// </summary>
        public bool DegassFuntion { get; set; }
    }

    /// <summary>
    /// Type of ink system
    /// </summary>
    public enum _inkSysType
    {
        Regular, //150,75
        Recirculating //75R
    }

    public enum _commInterfaces
    {
        Ethernet,
        Serial
    }


}
