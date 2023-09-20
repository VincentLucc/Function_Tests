using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SocketTool_Framework
{
    [XmlType("TCP_Client")]
    public class csTCPClient
    {
        Socket ClientSocket; //Define the socket to connect to the server

        public string ServerIP { get; set; }
        public int ServerPort { get; set; }

        private Thread tReceive { get; set; }

        /// <summary>
        /// Protection control, used to force thread exit in exception
        /// </summary>
        private Control parentControl { get; set; }

        /// <summary>
        /// This make sure thread always exit
        /// </summary>
        [XmlIgnore]
        public bool UIExit => parentControl == null || parentControl.IsDisposed || parentControl.Disposing;

        [XmlIgnore]
        public List<string> ReceivedMessages = new List<string>();
        public object lockReceivedMessages = new object();


        public delegate void NewMessageAction(string sMessage);

        public event NewMessageAction NewMessageReceived;

        public bool IsConnected => ClientSocket != null && ClientSocket.Connected;

        /// <summary>
        /// Keep for xml serializer
        /// </summary>
        public csTCPClient()
        {

        }
        public csTCPClient(Control control, string sServerIP, int iServerPort)
        {
            parentControl = control;
            ServerIP = sServerIP;
            ServerPort = iServerPort;
        }

        public async Task<bool> ConnectToServer(Control control)
        {

            parentControl = control;

            //Connect to server
            try
            {
                //Init connection address
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIP), ServerPort);

                //Clean start
                await Disconnect();

                //Create socket
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //connect to server
                ClientSocket.Connect(endPoint);
                tReceive = new Thread(ProcessReceive);
                tReceive.IsBackground = true; //Don't block the exit action
                tReceive.Name = "Client Receive";
                tReceive.Start();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Method \"ConnectToServer\"\r\n" + e.Message);
                return false;
            }
        }

        public async Task Disconnect()
        {
            csTCPModel.CloseSocket(ClientSocket) ;
            await csThreadHelper.WaitThreadClose(tReceive);
        }


        private void ProcessReceive()
        {
            byte[] Buffer = new byte[1024]; //Receive buffer

            while (ClientSocket != null)
            {
                //receive data
                int receiveLength = 0;
                try
                {
                    receiveLength = ClientSocket.Receive(Buffer);

                    //skip this if received message if not what needed
                    if (receiveLength < 1) continue;

                    //Check received data
                    string sData = Encoding.UTF8.GetString(Buffer, 0, receiveLength);
                    Console.WriteLine("Server_" + DateTime.Now.ToString() + ":\r\n" + sData); //For test only
                    AddReceivedMessage(sData);
                    NewMessageReceived?.Invoke(sData);

                }
                catch (Exception e)
                {
                    csTCPModel.CloseSocket(ClientSocket);
                    Console.WriteLine("Method \"ProcessReceive\"\r\n" + e.Message);
                    return;
                }
            }
        }

  

        public void AddReceivedMessage(string sMessage, int iLimit = 1000)
        {
            lock (lockReceivedMessages)
            {
                if (ReceivedMessages.Count > iLimit)
                {
                    ReceivedMessages.RemoveRange(0, ReceivedMessages.Count - iLimit);
                }

                ReceivedMessages.Add(sMessage);
            }
        }

        public string GetDisplayName()
        {
            return $"{ServerIP}:{ServerPort}";
        }

        public bool SendMessage(string sMessage)
        {
            try
            {
                if (ClientSocket == null) return false;
                if (string.IsNullOrWhiteSpace(sMessage)) return false;

                byte[] bData = Encoding.UTF8.GetBytes(sMessage);
                ClientSocket.Send(bData);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SendMessage.Exception:\r\n{ex.Message}");
                return false;
            }


        }
    }
}
