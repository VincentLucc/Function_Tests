using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialPort_Ink
{
    class csInkSystem
    {
        /// <summary>
        /// Default serial port connection
        /// </summary>
        public SerialPort Port { get; set; } 
        public bool IsConnected { get { return Port.IsOpen; } } //Is connected

        /// <summary>
        /// Message queue for sending messages
        /// </summary>
        public ConcurrentQueue<string> Messages2Send { get; set; }
        /// <summary>
        /// Received message buffer used for display only
        /// </summary>
        private StringBuilder builderReceivedData = new StringBuilder();

        private object lockBuilderReceivedData=new object(); //BuilderReceivedData lock
        /// <summary>
        /// Used to get received messages for display
        /// All received message
        /// </summary>
        public string MessagesReceivedCollection
        {
            get
            {
                lock (lockBuilderReceivedData)
                {
                    return builderReceivedData.ToString();
                }
            }
        }
        public int MessagesReceivedCollectionMaxSize { set; get; } //Set the max buffer size

        private Thread tSend; //Sending thread

        public SerialDataType SendEncoding { get; set; }
        public SerialDataType ReceiveEncoding { get; set; }


        public csInkSystem(csConfig config)
        {
            //Init port
            ApplyPortSettings(config);

        }

        public bool Connect(csConfig config)
        {
            ApplyPortSettings(config);

            //Try to connect
            if (!IsConnected)
            {
                try
                {
                    Port.Open();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Connect:\r\n"+ex.Message);
                    return false;
                }
            }

            //Check open status again
            if (!IsConnected) return false;

            //Pass all steps
            return true;       
        }

        private void ApplyPortSettings(csConfig config)
        {
            Port.PortName = config.Port.PortName;
            Port.BaudRate = config.Port.BaudRate;
            Port.DataBits = config.Port.DataBits;
            Port.StopBits = config.Port.StopBits;
            Port.Parity = config.Port.Parity;
            SendEncoding = config.SendFormat;
            ReceiveEncoding = config.ReceiveFormat;
        }

        /// <summary>
        /// Send command method for public use
        /// </summary>
        /// <param name="sCommand">Command to send</param>
        public void SendCommand(string sCommand)
        {
            //Direct Send
            Messages2Send.Enqueue(sCommand);
        }

        /// <summary>
        /// Send message based on encoding require ment
        /// </summary>
        /// <param name="sMessage"></param>
        public void PortSendBasedOnEncoding(string sMessage)
        {
            switch (SendEncoding)
            {
                case SerialDataType.ASCII:
                    byte[] bDataAscii=Encoding.ASCII.GetBytes(sMessage);
                    //Port.Write(sMessage); //Directly send
                    SendIn2BytesGap(bDataAscii);
                    break;
                case SerialDataType.HEX:
                    byte[] bDataHex = csByteConvert.StringToHexByte(sMessage);
                    //Port.Write(bDataHex, 0, bDataHex.Length); //Directly send
                    SendIn2BytesGap(bDataHex);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Send bytes with 10ms gap for each 2 bytes
        /// </summary>
        private void SendIn2BytesGap(byte[] bData)
        {

        }
    }
}
