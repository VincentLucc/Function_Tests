using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket_TCP_UDP
{


    namespace InkInterface
    {
        public class csComUDPServerBase
        {
            ///// <summary>
            ///// Server socket
            ///// </summary>
            //public Socket socketServer { get; set; }

            ///// <summary>
            ///// Socket connectivity
            ///// </summary>
            //public bool IsConnected => socketServer == null ? false : socketServer.Connected;

            ///// <summary>
            ///// Store clients info
            ///// </summary>
            //public ConcurrentDictionary<string, ClientInfo> Clients { get; set; }

            ///// <summary>
            ///// Accept client connection requests
            ///// </summary>
            //private Thread tListen { get; set; }

            ///// <summary>
            ///// Keep alive thread
            ///// </summary>
            //private Thread tKeep { get; set; }

            ///// <summary>
            ///// related display UI
            ///// </summary>
            //private Control ParentControl { get; set; }

            ///// <summary>
            ///// Server enable flag
            ///// </summary>
            //public bool ServerEnable { get; set; }

            ///// <summary>
            ///// Indicate whether UI exited.
            ///// </summary>
            //private bool UIExit => (ParentControl == null || ParentControl.Disposing ||
            //                        ParentControl.IsDisposed || (!ServerEnable));

            ///// <summary>
            ///// Send and received data, used only when communication mode set to DeviceSerial
            ///// </summary>
            //public InkSystemDataBuffer DataBuffer { get; set; }

            ///// <summary>
            ///// Current device command, used only when communication mode set to DeviceSerial
            ///// </summary>
            //public InkSystemCommand CurrentCommand { get; set; }

            //public csComTCPServerBase()
            //{
            //    Clients = new ConcurrentDictionary<string, ClientInfo>();
            //    ParentControl = csPublic.layoutData.ParentForm;
            //}


            //public bool StartServer(string sIP, int iPort)
            //{
            //    //Init socket
            //    socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp);
            //    ServerEnable = true;

            //    //Open port
            //    try
            //    {
            //        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(sIP), iPort);  //Get endpoints
            //        socketServer.Bind(endPoint);//Bind port
            //        socketServer.Listen(iPort);//Start to listen
            //        Debug.WriteLine($"Server started:{sIP}:{iPort}");

            //        //Listen thread
            //        tListen = new Thread(ProcessListen);
            //        tListen.IsBackground = true;
            //        tListen.Start();

            //        //Keep alive thread
            //        tKeep = new Thread(ProcessKeep);
            //        tKeep.IsBackground = true;
            //        tKeep.Start();
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.WriteLine("csComTCPServerBase.ServerStart\r\n" + e.Message);
            //        return false;
            //    }

            //    //Pass all steps
            //    return true;
            //}

            //public void ProcessListen()
            //{
            //    while (true)
            //    {

            //        try
            //        {
            //            //Check UI exit
            //            if (UIExit) return;

            //            //Get socket
            //            Socket socketClient = socketServer.Accept(); //Get client socket
            //            socketClient.Send(Encoding.UTF8.GetBytes(TCPDefaultMessage.Server_ClientConnected));

            //            //Create client
            //            ClientInfo client = new ClientInfo();
            //            client.ClientSocket = socketClient;

            //            //Start receiving data
            //            Thread tReceive = new Thread(ProcessReceive);   //Use thread instead, faster than task
            //            tReceive.IsBackground = true;
            //            tReceive.Start(client);

            //            //Start sending thread
            //            Thread tSend = new Thread(ProcessSend);   //Use thread instead, faster than task
            //            tSend.IsBackground = true;
            //            tSend.Start(client);

            //        }
            //        catch (Exception e)
            //        {
            //            Debug.WriteLine("csComTCPServerBase.ServerStart\r\n" + e.Message);
            //            //return false; //Don't return to jump out loop in any case
            //        }
            //    }
            //}

            //private void ProcessKeep()
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(100);
            //        try
            //        {
            //            //Loop thread safe
            //            var threadSafe = Clients.GetEnumerator();

            //        //Get clinet
            //        ClientOperation:
            //            var valuePair = threadSafe.Current;
            //            ClientInfo client = valuePair.Value;
            //            if (client != null)
            //            {
            //                //Add keep alive message
            //                if (client.IsKeepAliveRequired())
            //                    client.AddMessage(TCPDefaultMessage.Server_Ping);

            //                //Send ink device status
            //                client.AddMessage(TCPDefaultMessage.GetInkSystemStatus());
            //            }

            //            //Goto next client
            //            if (threadSafe.MoveNext()) goto ClientOperation;

            //        }
            //        catch (Exception e)
            //        {
            //            Debug.WriteLine("csComTCPServerBase.ProcessKeep\r\n" + e.Message);
            //        }
            //    }
            //}

            //private void ProcessReceive(object _client)
            //{
            //    //Init variables
            //    ClientInfo client = (ClientInfo)_client;
            //    byte[] buffer = new byte[4096];//buffer to store data, UTF8=Size/2 maximum
            //    string sRemote = "";

            //    //Get socket
            //    try
            //    {
            //        sRemote = client.ClientSocket.RemoteEndPoint.ToString(); //Remote end point
            //                                                                 //Update the client pool
            //                                                                 //If not exist just add, if exist change value to "client"
            //        Clients.AddOrUpdate(sRemote, client, (key, value) => client);
            //    }
            //    catch (Exception e1)
            //    {
            //        Debug.WriteLine("csComTCPServerBase.ProcessReceive.\r\n" + e1.Message);
            //        return;
            //    }

            //    //Receive data
            //    while (true)
            //    {
            //        //Check UI exit
            //        if (UIExit) return;

            //        try
            //        {
            //            //Check connection
            //            if (client.ClientSocket == null || (!client.ClientSocket.Connected)) return;

            //            int iCount = client.ClientSocket.Receive(buffer);
            //            string sResponse = Encoding.UTF8.GetString(buffer, 0, iCount); //Get data
            //            string[] sMessageList = ParsingData(sResponse); //parsing data

            //            //Read data
            //            for (int i = 0; i < sMessageList.Length; i++)
            //            {

            //                Debug.WriteLine("Received message from:" + sRemote + "\r\n" + sResponse);
            //                ResponseProcess(sResponse);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //Receive error, disconnect
            //            CloseSocket(client.ClientSocket); //close socket
            //            RemoveFromList(sRemote);//remove from list
            //            Debug.WriteLine("csComTCPServerBase.ProcessReceive:\r\n" + ex.Message);
            //            return; //End loop
            //        }
            //    }
            //}

            //public void ProcessSend(object _client)
            //{
            //    //Init variables
            //    ClientInfo client = (ClientInfo)_client;
            //    string sRemote = "";
            //    string sMessage = "";

            //    //Try to get socket information
            //    try
            //    {
            //        sRemote = client.ClientSocket.RemoteEndPoint.ToString();
            //        client.AddMessage(TCPDefaultMessage.Server_Hello);
            //    }
            //    catch (Exception e1)
            //    {
            //        Debug.WriteLine("csComTCPServerBase.ProcessSend\r\n" + e1.Message);
            //        RemoveFromList(sRemote);
            //        return;
            //    }

            //    //Send message
            //    while (true)
            //    {

            //        //avoid sticky package and increase performance
            //        Thread.Sleep(20);

            //        //Check UI exit
            //        if (UIExit) return;

            //        //Try to send command
            //        try
            //        {
            //            //Get the first message
            //            sMessage = client.GetFirstMessage();
            //            if (sMessage == null) continue;

            //            //Send message
            //            SendMessage(client.ClientSocket, sMessage);
            //            client.RemoveFirstMessage();

            //            //Remove stacked messages if exceed certain amount
            //            client.RemoveStackedMessage();
            //        }
            //        catch (Exception e2)
            //        {
            //            //error message
            //            Debug.WriteLine("Send message error to:" + sRemote + "\r\n" + sMessage);
            //            Debug.WriteLine(e2.Message);

            //            //close the client socket
            //            CloseSocket(client.ClientSocket);

            //            //Remove this client
            //            RemoveFromList(sRemote);



            //            return;
            //        }
            //    }
            //}

            //private void SendMessage(Socket theSocket, string sMessage)
            //{
            //    //Get message
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("��");
            //    sb.Append(sMessage);
            //    sb.Append("��");
            //    sMessage = sb.ToString();

            //    theSocket.Send(Encoding.UTF8.GetBytes(sMessage));
            //}

            ///// <summary>
            ///// Get message
            ///// </summary>
            ///// <param name="sData"></param>
            ///// <returns></returns>
            //private string[] ParsingData(string sData)
            //{

            //    string[] stringPattern = new string[] { "��" }; //To separate commands

            //    string[] sResult = sData.Split(stringPattern, StringSplitOptions.RemoveEmptyEntries);

            //    return sResult;
            //}

            //private void ResponseProcess(string sData)
            //{

            //}

            ///// <summary>
            ///// Close the socket if it's open
            ///// </summary>
            ///// <param name="theSocket"></param>
            //private void CloseSocket(Socket theSocket)
            //{
            //    if (theSocket == null)
            //    {//avoid none error, avoid multiple exec error.
            //        return;
            //    }

            //    //Make sure socket has content
            //    if (!theSocket.Connected)
            //    {
            //        theSocket.Close();
            //        theSocket = null; //clear socket
            //        return;
            //    }

            //    //Close the socket and remove from list
            //    try
            //    {
            //        theSocket.Shutdown(SocketShutdown.Both);//disconnect the socket
            //        theSocket.Close();
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.WriteLine("csComTCPServerBase.CloseSocket:\r\n" + e.Message);
            //    }
            //}

            //private void RemoveFromList(string sRemote)
            //{
            //    //Try to remove from current list
            //    Clients.TryRemove(sRemote, out ClientInfo client);
            //}

        }

        public class ClientInfo
        {
            public Socket ClientSocket { get; set; }

            private List<string> Messages2Send { get; set; }

            public object lockMessages2Send { get; set; }

            private DateTime LastCommandTime { get; set; }
            /// <summary>
            /// Time span between each keep alive signal in ms
            /// </summary>
            private double KeepAliveGap { get; set; }

            public ClientInfo()
            {
                Messages2Send = new List<string>();
                lockMessages2Send = new object();
                KeepAliveGap = 3000;
            }

            public void AddMessage(string sMessage)
            {
                lock (lockMessages2Send)
                {
                    Messages2Send.Add(sMessage);
                    LastCommandTime = DateTime.Now;
                }
            }

            public string GetFirstMessage()
            {
                lock (lockMessages2Send)
                {
                    if (Messages2Send.Count < 1) return null;
                    return Messages2Send[0];
                }
            }


            public void RemoveFirstMessage()
            {
                lock (lockMessages2Send)
                {
                    Messages2Send.RemoveAt(0);
                }
            }

            public void RemoveStackedMessage()
            {
                lock (lockMessages2Send)
                {
                    while (Messages2Send.Count > 50)
                    {
                        Messages2Send.RemoveAt(0);
                    }
                }
            }

            /// <summary>
            /// Indicate whether the time span of last command sent is bigger than pre-defined gap
            /// </summary>
            /// <returns></returns>
            public bool IsKeepAliveRequired()
            {
                //Check if already have message
                if (Messages2Send.Count > 0) return false;

                //Check last message sent time
                TimeSpan timeSpan = DateTime.Now - LastCommandTime;
                if (timeSpan.TotalMilliseconds > KeepAliveGap)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
