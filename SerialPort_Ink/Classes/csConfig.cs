﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SerialPort_Ink
{
    public class csConfig
    {
        public PortConfig Port { get; set; }
        public SerialDataType SendFormat { get; set; }
        public SerialSendMode SendMode { get; set; }
        public SerialDataType ReceiveFormat { get; set; }

        [XmlIgnore]
        public List<string> InitCommands { get; set; }

        public BindingList<CommandInfo> Commands { get; set; }

        [XmlIgnore]
        public static string DefaultPath => GetDefaultPath();
        /// <summary>
        /// Used for display, escape convertted to visible string
        /// </summary>
        public string EndSuffixView { get; set; }
        /// <summary>
        /// Used for display only
        /// </summary>
        [XmlIgnore]
        public static string[] EndSuffixCollection = new string[] { "", "\\r", "\\r\\n" };
        /// <summary>
        /// Replace "\\r\\n" to "\r\n"
        /// </summary>
        [XmlIgnore]
        public string EndSuffixValue => Regex.Unescape(EndSuffixView);

        [XmlIgnore]
        public bool EnableUpdate { get; set; }
        public csConfig()
        {
            Port = new PortConfig();
            SendFormat = SerialDataType.ASCII;
            ReceiveFormat = SerialDataType.ASCII;
            EndSuffixView = "";
            InitCommands = new List<string>() {
            "@SNI#","@SNI?","@SNI,00","@SNI,01","@SNI,02","@SNI,03","@SNI,04",
            "STA?0","ASTA?","BSTA?","CSTA?","DSTA?",
            "SEB?0"
            };
            Commands = new BindingList<CommandInfo>();
        }

        private static string GetDefaultPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath)
                + @"\SerialPort.xml";
        }

        public void AddSampleCommands()
        {
            Commands.Add(new CommandInfo() { Command = "@SNI#", Description = "" });
            Commands.Add(new CommandInfo() { Command = "@SNI?", Description = "" });
            Commands.Add(new CommandInfo() { Command = "@SNI,00", Description = "Set device to network 0." });
            Commands.Add(new CommandInfo() { Command = "@SNI,01", Description = "Set device to network 1." });
            Commands.Add(new CommandInfo() { Command = "@SNI,02", Description = "Set device to network 2." });
            Commands.Add(new CommandInfo() { Command = "@SNI,03", Description = "Set device to network 3." });
            Commands.Add(new CommandInfo() { Command = "@SNI,04", Description = "Set device to network 4." });
            Commands.Add(new CommandInfo() { Command = "STA?0", Description = "Get device 0 general status." });
            Commands.Add(new CommandInfo() { Command = "ASTA?", Description = "Get device 1 general status." });
            Commands.Add(new CommandInfo() { Command = "BSTA?", Description = "Get device 2 general status." });
            Commands.Add(new CommandInfo() { Command = "CSTA?", Description = "Get device 3 general status." });
            Commands.Add(new CommandInfo() { Command = "DSTA?", Description = "Get device 4 general status." });
            Commands.Add(new CommandInfo() { Command = "SEB?0", Description = "Get device 0 function state." });
        }
    }

    public class PortConfig
    {

        [XmlIgnore]
        public string PortName { get; set; }
        [XmlIgnore]
        public int BaudRate => (int)GetValueByIndex<int>(BaudRateCollection, BaudRateIndex);
        public int BaudRateIndex { get; set; }

        /// <summary>
        /// Stop bit can't be set to none
        /// </summary>
        [XmlIgnore]
        public StopBits StopBits => StopBitsIndex < 0 ? StopBits.One : (StopBits)(StopBitsIndex + 1);
        public int StopBitsIndex { get; set; }

        [XmlIgnore]
        public int DataBits => (int)GetValueByIndex<int>(DataBitsCollection, DataBitsIndex);
        public int DataBitsIndex { get; set; }
        [XmlIgnore]
        public Parity Parity => ParityIndex < 0 ? Parity.None : (Parity)ParityIndex;
        public int ParityIndex { get; set; }

        /// <summary>
        /// Software flow control
        /// If Enabled, set 
        /// Handshake to XON/XOFF
        /// Port.DtrEnable = true;
        /// Port.RtsEnable = true;
        /// </summary>
        public bool EnableFlowControl { get; set; }

        //Statics
        [XmlIgnore]
        public static int[] BaudRateCollection = new int[] { 2400, 4800, 9600, 11520, 19200, 38400, 57600, 115200 };
        [XmlIgnore]
        public static int[] DataBitsCollection = new int[] { 6, 7, 8 };
        [XmlIgnore]
        public static string[] StopBitsCollection = new string[] { "1", "2", "1.5" };
        [XmlIgnore]
        public static string[] ParityCollection = new string[] { "None", "Odd", "Even" };


        public PortConfig()
        {
            PortName = "";
        }

        private object GetValueByIndex<T>(IList<T> DataSource, int iIndex)
        {
            //Exist directly get value
            if (iIndex >= 0 && iIndex < DataSource.Count)
            {
                return DataSource[iIndex];
            }
            //Not exist get value based on situation
            else
            {
                if (typeof(T).Name == typeof(string).Name)
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

    public class CommandInfo
    {
        [XmlAttribute]
        public string Command { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
    }

    public enum SerialDataType
    {
        ASCII,
        HEX
    }

    public enum SerialSendMode
    {
        Normal,
        ByByte2
    }

}
