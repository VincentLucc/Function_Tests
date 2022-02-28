using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
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
        public string EndSuffix { get; set; }
        [XmlIgnore]
        public static string DefaultPath => GetDefaultPath();

        [XmlIgnore]
        public static string[] EndSuffixCollection = new string[] { "", @"\r", @"\r\n" };
        public csConfig()
        {
            Port = new PortConfig();
            SendFormat = SerialDataType.ASCII;
            ReceiveFormat = SerialDataType.ASCII;
            EndSuffix = "";
        }

        private static string GetDefaultPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath)
                + @"\SerialPort.xml";
        }
    }

    public class PortConfig
    {
     
        [XmlIgnore]
        public string PortName { get; set; }
        [XmlIgnore]
        public int BaudRate => (int)GetValueByIndex<int>(BaudRateCollection, BaudRateIndex);
        public int BaudRateIndex { get; set; }
        [XmlIgnore]
        public StopBits StopBits => StopBitsIndex<0? StopBits.None: (StopBits)StopBitsIndex;
        public int StopBitsIndex { get; set; }

        [XmlIgnore]
        public int DataBits => (int)GetValueByIndex<int>(DataBitsCollection, DataBitsIndex);
        public int DataBitsIndex { get; set; }
        [XmlIgnore]
        public Parity Parity => ParityIndex<0? Parity.None : (Parity)ParityIndex;
        public int ParityIndex { get; set; }

        //Statics
        [XmlIgnore]
        public static int[] BaudRateCollection = new int[] { 2400, 4800, 9600, 11520, 19200, 38400 };
        [XmlIgnore]
        public static int[] DataBitsCollection = new int[] { 6, 7, 8};
        [XmlIgnore]
        public static string[] StopBitsCollection = new string[] { "None", "1", "2", "1.5"};
        [XmlIgnore]
        public static string[] ParityCollection = new string[] { "None", "Odd", "Even"};

        private object GetValueByIndex<T>(IList<T> DataSource,int iIndex)
        {
            //Exist directly get value
            if (iIndex >= 0 && iIndex < DataSource.Count)
            {
                return DataSource[iIndex];
            }
            //Not exist get value based on situation
            else
            {
                if (typeof(T).Name ==typeof(string).Name)
                {
                    return "";
                }
                else 
                {
                    return -1;
                }

               
            }
        }
    }

    public enum SerialDataType
    {
        ASCII,
        HEX
    }


}
