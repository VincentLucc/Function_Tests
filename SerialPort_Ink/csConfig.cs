using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SerialPort_Ink
{
    public class csConfig
    {
        public PortConfig Port { get; set; }
        public SerialDataType SendFormat { get; set; }
        public SerialDataType ReceiveFormat { get; set; }
        [XmlIgnore]
        public static string DefaultPath => GetDefaultPath();
        public csConfig()
        {
            Port = new PortConfig();
            SendFormat = SerialDataType.ASCII;
            ReceiveFormat = SerialDataType.ASCII;
        }

        private static string GetDefaultPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath)
                + @"\SerialPort.xml";
        }
    }

    public class PortConfig
    {
        public int PortName { get; set; }
        public int BaudRate { get; set; }
        public int StopBits { get; set; }
        public int DataBits { get; set; }
        public int Parity { get; set; }
    }

    public enum SerialDataType
    {
        ASCII,
        HEX
    }
}
