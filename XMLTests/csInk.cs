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

        public List<ModelInfo> ABC;

        public InkSysConfig()
        {
            DeviceCollection = new List<InkDeviceConfig>();
            CommInterface = _commInterfaces.Serial;
            ABC = new List<ModelInfo>();
            for (int i = 0; i < 3; i++)
            {
                string sName = "ABC" + i.ToString("D2");
                ModelInfo modelInfo = new ModelInfo() { 
                  Name = sName, Description=new List<int>() { 1,2}
                };
                ABC.Add(modelInfo);

            }
        }

        public class ModelInfo
        {
            [XmlAttribute]
            public string Name;
            [XmlAttribute]
            public List<int> Description;

            public ModelInfo() 
            {

            }
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

        public InkDeviceConfig()
        {

        }
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
