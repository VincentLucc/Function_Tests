using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SocketTool_Framework
{
    [XmlRoot("Server Config")]
    public class csTCPServer
    {

        public int Port { get; set; }

        /// <summary>
        /// IPv4 address string
        /// </summary>
        public string IPv4 { get; set; }
        public const string IPV4Pattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

        /// <summary>
        /// Indicate whether process received TCP message as special JSON object 
        /// </summary>
        public bool IsJSONMessage { get; set; }

        public bool EnableStatusMessage { get; set; }

        public string Message_Welcome { get; set; }

        public string Message_LimitReached { get; set; }

        public string Message_Ping { get; set; }

        /// <summary>
        /// Used for large packet only, able to detect and combine the data
        /// </summary>
        public bool EnablePackageSegmentation { get; set; }

        /// <summary>
        /// Server socket
        /// </summary>
        [XmlIgnore]
        public Socket socketServer { get; set; }


        /// <summary>
        /// Socket connectivity
        /// </summary>
        [XmlIgnore]
        public bool IsConnected => socketServer == null ? false : socketServer.Connected;

        /// <summary>
        /// Store clients info <RemoteEndPoint,ClientInfo>
        /// </summary>
        [XmlIgnore]
        public ConcurrentDictionary<string, csTCPClientInfo> Clients { get; set; }

        /// <summary>
        /// Use an seperated buffer to keep data even when tcp client is closed
        /// </summary>
        [XmlIgnore]
        public List<string> ReceivedMessages { get; set; }
        public object lockReceivedMessages { get; set; }

        /// <summary>
        /// Number of client can be connected to this server, 0: No limit
        /// </summary>
        public int ClientLimit { get; set; }

        [XmlIgnore]
        /// <summary>
        /// Client requests
        /// Allow only one thread process the client request at the same time
        /// This can avoid server side action conflict
        /// </summary>
        public List<csTCPOperation> OperationQueue { get; set; }
        [XmlIgnore]
        public object LockOperationQueue { get; set; }

        /// <summary>
        /// Used for outside event handle to do the job
        /// </summary>
        /// <param name="operation"></param>
        public delegate void ClientRequestAction(csTCPServer tcpServer, csTCPOperation operation);
        public event ClientRequestAction ClientRequestReceived;


        [XmlIgnore]
        /// <summary>
        /// Accept client connection requests
        /// </summary>
        private Thread tListen { get; set; }
        [XmlIgnore]
        /// <summary>
        /// Keep alive thread
        /// </summary>
        private Thread tKeep { get; set; }
        [XmlIgnore]
        /// <summary>
        /// Main thread to process client requests
        /// </summary>
        private Thread tOperation { get; set; }

        [XmlIgnore]
        public UdpClient socketUDP { get; set; }
        [XmlIgnore]
        public ConcurrentQueue<string> UdpMessages { get; set; }
        [XmlIgnore]
        public Thread tUdpSend { get; set; }
        [XmlIgnore]
        public IPEndPoint UdpEndPoint { get; set; }

        /// <summary>
        /// Protection code
        /// </summary>
        [XmlIgnore]
        public Control parentControl { get; set; }

        /// <summary>
        /// This make sure thread always exit
        /// </summary>
        [XmlIgnore]
        public bool UIExit => parentControl == null || parentControl.IsDisposed || parentControl.Disposing;
        /// <summary>
        /// Used for internal flag only
        /// </summary>
        [XmlIgnore]
        private bool ServerEnable { get; set; }

        /// <summary>
        /// Server running status
        /// Use IsRunning for more accurate value compare with "ServerEnable"
        /// </summary>
        [XmlIgnore]
        public bool IsRunning { get; set; }

        /// <summary>
        /// Used for serializer
        /// </summary>
        public csTCPServer()
        {
            Init();
        }

        public csTCPServer(Control control)
        {
            Init();
            parentControl = control;
        }

        public csTCPServer(Control control, int iPort, string sIP = null)
        {
            Init();
            Port = iPort;
            IPv4 = sIP;
            parentControl = control;
        }

        public void Init()
        {
            Clients = new ConcurrentDictionary<string, csTCPClientInfo>();
            LockOperationQueue = new object();
            OperationQueue = new List<csTCPOperation>();
            ClientLimit = 10; //Limit number of client allowed
            UdpMessages = new ConcurrentQueue<string>();
            IPv4 = "0.0.0.0";
            Port = 54321;
            ReceivedMessages = new List<string>();
            lockReceivedMessages = new object();

            //Setup messages
            EnableStatusMessage = true;
            Message_Welcome = "Welcome";
            Message_LimitReached = "Server Limit Reached.";
            Message_Ping = "Ping";
        }


        public string GetDisplayName()
        {
            if (string.IsNullOrWhiteSpace(IPv4))
            {
                return $"Local:{Port}";
            }
            else
            {
                return $"{IPv4}:{Port}";
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool StartTCPServer(Control _parentControl, out string sMessage)
        {
            //Init socket
            parentControl = _parentControl;
            socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerEnable = true;
            IsRunning = true;
            sMessage = "";
            IPEndPoint endPoint;

            //Open port
            try
            {
                //Prepare IP end point
                //Use 0.0.0.0 (IPAddress.Any) to start server at any valid ip addresses
                //Use 127.0.0.1 to only allow access on local computer
                if (string.IsNullOrWhiteSpace(IPv4))
                {
                    endPoint = new IPEndPoint(IPAddress.Any, Port);
                }
                else
                {
                    if (!Regex.IsMatch(IPv4, IPV4Pattern))
                    {
                        sMessage = "Invalid IP Address.\r\n" + IPv4;
                        return false;
                    }

                    endPoint = new IPEndPoint(IPAddress.Parse(IPv4), Port);
                }

                socketServer.Bind(endPoint);//Bind port
                int iWaitingConnections = 10;
                socketServer.Listen(iWaitingConnections);//Start to listen
                Debug.WriteLine($"Server started at port:{Port}");

                //Listen Thread: Accept new client
                tListen = new Thread(ProcessListen);
                tListen.IsBackground = true;
                tListen.Start();

                //Operation thread: Process client request
                tOperation = new Thread(ProcessRequestOperation);
                tOperation.IsBackground = true;
                tOperation.Start();

                //Broadcast thread: Client status update
                tKeep = new Thread(ProcessBroadCast);
                tKeep.IsBackground = true;
                tKeep.Start();
            }
            catch (Exception e)
            {
                Debug.WriteLine("csTCPServer.ServerStart\r\n" + e.Message);
                sMessage = e.Message;
                return false;
            }

            //Pass all steps
            return true;
        }

        public async Task StopTCPServer()
        {
            ServerEnable = false;
            csTCPModel.CloseSocket(socketServer);

            //Make sure related threads all exit
            await Task.WhenAll(new Task[] {
                WaitThreadClose(tListen, "Listen"),
                WaitThreadClose(tOperation, "Operation Handle"),
                WaitThreadClose(tKeep, "Keep Alive"),
            });

            Cleanup();

            //Complete
            IsRunning = false;
        }

        public async Task WaitThreadClose(Thread thread, string threadName = "N/A")
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool writeAlert = true;

            if (thread == null) return;
            while (thread.IsAlive)
            {
                await Task.Delay(10);
                if (writeAlert && stopwatch.ElapsedMilliseconds > 10 * 1000)
                {
                    writeAlert = false;
                    Debug.WriteLine($"Close thread:{threadName}, timeout {stopwatch.ElapsedMilliseconds}ms.");
                }

            }

            stopwatch.Stop();
            Debug.WriteLine($"Close thread:{threadName}, Time {stopwatch.ElapsedMilliseconds}ms.");
        }

        // Protected implementation of Dispose pattern.
        private void Cleanup()
        {
            try
            {
                if (socketServer != null)
                {
                    socketServer?.Dispose();
                    socketServer = null;
                }

                //Fonts
                Clients?.Clear();

                if (OperationQueue != null)
                {
                    lock (LockOperationQueue) OperationQueue.Clear();
                }

                if (UdpMessages != null)
                {
                    while (UdpMessages.Count > 0) UdpMessages.TryDequeue(out string sMessage);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cleanup:\r\n" + ex.Message);
            }

        }

        public bool StartUDPBroadcast(out string sMessage)
        {
            sMessage = "";

            try
            {
                socketUDP = new UdpClient();
                var ipaddress = IPAddress.Parse(IPv4);
                UdpEndPoint = new IPEndPoint(ipaddress, Port);
                socketUDP.Connect(UdpEndPoint);
                tUdpSend = new Thread(ProcessUDPSend);
                tUdpSend.IsBackground = true;
                tUdpSend.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("StartUDPBroadcast:\r\n" + ex.Message);
                sMessage = ex.Message;
                return false;
            }

            //Pass all steps
            return true;

        }

        public void ProcessListen()
        {
            //Check UI exit
            while (ServerEnable && !UIExit)
            {
                try
                {

                    //Get socket
                    Socket socketClient = socketServer.Accept(); //Get client socket
                    string sRemote = socketClient.RemoteEndPoint.ToString();
                    socketClient.Send(Encoding.UTF8.GetBytes(Message_Welcome + ":" + sRemote)); ;

                    //Set socket
                    socketClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                    //Create client
                    csTCPClientInfo client = new csTCPClientInfo();
                    client.ClientSocket = socketClient;

                    //Start receiving data
                    client.tReceive = new Thread(ProcessReceive);   //Use thread instead, faster than task
                    client.tReceive.IsBackground = true;
                    client.tReceive.Start(client);

                    //Start sending thread
                    client.tSend = new Thread(ProcessSend);   //Use thread instead, faster than task
                    client.tSend.IsBackground = true;
                    client.tSend.Start(client);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("csTCPServer.ProcessListen\r\n" + e.Message);
                    //return false; //Don't return to jump out loop in any case
                }
            }

            Debug.WriteLine("ProcessListen.Complete");
        }



        /// <summary>
        /// Main thread to process client requests
        /// </summary>
        private void ProcessRequestOperation()
        {
            while (ServerEnable && !UIExit)
            {
                //process delay
                Thread.Sleep(20);

                //Get first operation
                var operation = OperationQueueGetNext();

                //Check result
                if (operation == null) continue;

                //Operate based on type
                WorkOnQueueOperation(operation);

                //Let outside thread to process user request
                ClientRequestReceived?.Invoke(this, operation);

                //Remove timeout operations
                RemoveTimeoutOperations();
            }

            Debug.WriteLine("ProcessRequestOperation.Complete");
        }

        private void RemoveTimeoutOperations()
        {
            lock (LockOperationQueue)
            {
                //Keep buffer server button low
                if (IsJSONMessage)
                {
                    var timeoutOperations = OperationQueue.Where(a =>
                    (DateTime.Now - a.CreateTime).TotalMilliseconds > a.Request.RequestTimeout);
                    foreach (var operation in timeoutOperations)
                    {
                        OperationQueue.Remove(operation);
                    }
                }
                else
                {
                    var timeoutOperations = OperationQueue.Where(a =>
                    (DateTime.Now - a.CreateTime).TotalMilliseconds > 1000);

                    //Remove time out operations
                    foreach (var operation in timeoutOperations)
                    {
                        OperationQueue.Remove(operation);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        //Only for time consuming operations
        private void WorkOnQueueOperation(csTCPOperation operation)
        {
            if (IsJSONMessage)
            {
                //Init variables
                var request = operation.Request;
                var response = operation.Response;
                var CommandID = request.CommandID;

                //Work on client request when needed
            }
            else
            {
                //Process text string command
                lock (lockReceivedMessages)
                {
                    string sMessage = $"{csPublic.TimeString} {operation.ClientInfo.RemoteEndPoint} : {operation.TextRequest}";
                    ReceivedMessages.Add(sMessage);

                    if (ReceivedMessages.Count>1500)
                    {
                        ReceivedMessages.RemoveRange(0,500);
                    }
                }
            }
        }




        private csTCPOperation OperationQueueGetNext()
        {
            lock (LockOperationQueue)
            {
                if (OperationQueue == null || OperationQueue.Count < 1) return null;
                var operation = OperationQueue[0];
                OperationQueue.Remove(operation);
                return operation;
            }
        }


        /// <summary>
        /// Used for send status info frequently
        /// </summary>
        private void ProcessBroadCast()
        {
            while (ServerEnable && !UIExit)
            {
                Thread.Sleep(100);

                try
                {
                    //Loop thread safe
                    var clientEnumerator = Clients.GetEnumerator();

                    //Get clinet
                    ClientOperation:
                    var valuePair = clientEnumerator.Current;
                    csTCPClientInfo client = valuePair.Value;
                    if (client != null && client.IsValid)
                    {
                        //Send status update message
                        //client.SendMessage(sStatus);

                        //Add keep alive message
                        //if (client.IsKeepAliveRequired())
                        //    client.SendMessage(Message_Ping);
                    }

                    //Goto next client
                    if (clientEnumerator.MoveNext()) goto ClientOperation;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("csComTCPServerBase.ProcessKeep\r\n" + e.Message);
                }
            }

            Debug.WriteLine("ProcessKeep.Complete");
        }

        /// <summary>
        /// Send message to all clients
        /// </summary>
        /// <param name="sMessage"></param>
        public void BroadCastTCP(string sMessage)
        {
            try
            {
                //Loop thread safe
                var clientEnumerator = Clients.GetEnumerator();

                //Get clinet
                ClientOperation:
                var valuePair = clientEnumerator.Current;
                csTCPClientInfo client = valuePair.Value;
                if (client != null && client.IsValid)
                {
                    //Send status update message
                    client.SendMessage(sMessage);
                }

                //Goto next client
                if (clientEnumerator.MoveNext()) goto ClientOperation;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csTCPServer.BroadCastTCP:\r\n" + ex.Message);
            }
        }

        private void ProcessReceive(object _client)
        {
            //Init variables
            csTCPClientInfo client = (csTCPClientInfo)_client;
            byte[] buffer = new byte[1024 * 100];//buffer to store data, UTF8=Size/2 maximum
            string sRemote = "";
            int iReceiveCount = 0;

            //Prepare socket
            try
            {
                sRemote = client.ClientSocket.RemoteEndPoint.ToString(); //Remote end point
                //Check client limit
                if (ClientLimit == 0 || Clients.Count < ClientLimit)
                {
                    //Update the client pool
                    //If not exist just add, if exist change value to "client"
                    Clients.AddOrUpdate(sRemote, client, (key, value) => client);

                    //Server OK command
                    if (EnableStatusMessage) client.SendMessage("Ready to receive.");
                    client.IsValid = true;
                }
                else
                {
                    //Debug info
                    if (EnableStatusMessage)
                    {//Disconnect command
                        client.SendMessage(Message_LimitReached);
                    }

                    Debug.WriteLine($"ProcessReceive.LimitReached{ClientLimit}:{sRemote}");

                    Thread.Sleep(100);
                    goto FinishUp;
                }

            }
            catch (Exception e1)
            {
                Debug.WriteLine("csTCPServer.ProcessReceive:{sRemote}\r\n" + e1.Message);
                goto FinishUp;
            }

            //Receive data and check UI exit
            while (ServerEnable && !UIExit)
            {
                try
                {
                    //When remote is closed, anexception will occur to close this thread
                    iReceiveCount = client.ClientSocket.Receive(buffer);

                    //Happens when remote is disconnected
                    if (iReceiveCount == 0)
                    {
                        if (csTCPModel.IsConnected(client.ClientSocket))
                            Thread.Sleep(10);
                        else
                            goto FinishUp;
                    }

                    string sData = Encoding.UTF8.GetString(buffer, 0, iReceiveCount); //Get data
                    Debug.WriteLine($"{csPublic.TimeString} Received from {sRemote}, count:({iReceiveCount}):\r\n" + sData); //For test only

                    //Parsing message
                    if (EnablePackageSegmentation)
                    {
                        string[] sMessages = ParsingDataString(sData); //parsing data
                        for (int i = 0; i < sMessages.Length; i++)
                        {
                            string sMessage = sMessages[i];
                            ResponseProcess(sMessage, client);
                        }
                    }
                    else
                    {//Treat as normal message
                        ResponseProcess(sData, client);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("csTCPServer.ProcessReceive:\r\n" + ex.Message);
                    goto FinishUp;
                }
            }


            FinishUp:
            csTCPModel.CloseSocket(client.ClientSocket); //close socket
            if (!string.IsNullOrWhiteSpace(sRemote))
            {
                RemoveFromList(sRemote);//remove from list
            }
            Debug.WriteLine("Client disconnected:" + sRemote);
        }



        public void ProcessSend(object _client)
        {
            //Init variables
            csTCPClientInfo client = (csTCPClientInfo)_client;
            string sRemote = "";
            string sMessage = "";

            //Try to get socket information
            try
            {
                sRemote = client.ClientSocket.RemoteEndPoint.ToString();
                if (EnableStatusMessage)
                    client.SendMessage("Ready to send");
            }
            catch (Exception e1)
            {
                Debug.WriteLine("csTCPServer.ProcessSend\r\n" + e1.Message);
                RemoveFromList(sRemote);
                return;
            }

            //Send message
            while (ServerEnable && !UIExit)
            {//Auto exit when socket exception occur

                //avoid sticky package and increase performance
                Thread.Sleep(10);

                //Try to send command
                try
                {

                    //Get the first message
                    sMessage = client.GetFirstMessage();
                    if (sMessage == null) continue;

                    //Send message
                    SendMessage(client.ClientSocket, sMessage);
                    client.RemoveFirstMessage();

                    //Remove stacked messages if exceed certain amount
                    client.RemoveStackedMessage();
                }
                catch (Exception e2)
                {
                    //error message
                    Debug.WriteLine($"csComTCPServerBase.ProcessSend:{sRemote}:{sMessage}\r\n{e2.Message}");

                    //close the client socket
                    break;
                }
            }

            //Finishup

            csTCPModel.CloseSocket(client.ClientSocket);
            //Remove this client
            if (!string.IsNullOrWhiteSpace(sRemote))
            {
                RemoveFromList(sRemote);//remove from list
            }
        }




        private void SendMessage(Socket theSocket, string sMessage)
        {
            //Get message
            if (EnablePackageSegmentation)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("��");
                sb.Append(sMessage);
                sb.Append("��");
                sMessage = sb.ToString();
            }

            theSocket.Send(Encoding.UTF8.GetBytes(sMessage));
            Debug.WriteLine($"{csPublic.TimeString} Send Message count {sMessage.Length}:\r\n{sMessage}");
        }

        /// <summary>
        /// Get message
        /// </summary>
        /// <param name="sData"></param>
        /// <returns></returns>
        private string[] ParsingDataString(string sData)
        {

            string[] stringPattern = new string[] { "��" }; //To separate commands

            string[] sResult = sData.Split(stringPattern, StringSplitOptions.RemoveEmptyEntries);

            return sResult;
        }

        /// <summary>
        /// Process received command from clients
        /// </summary>
        /// <param name="sData"></param>
        private void ResponseProcess(string sMessage, csTCPClientInfo client)
        {
            //Init variables
            csTCPRequest clientRequest;

            //Ignore debug message
            if (sMessage == Message_Ping)
                return;

            //Try get response
            try
            {
                if (IsJSONMessage)
                {
                    clientRequest = JsonConvert.DeserializeObject<csTCPRequest>(sMessage);
                    if (clientRequest == null) return;

                    //Add to operation queue if required
                }
                else
                {
                    OperationQueueAdd(client, sMessage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ProcessResponse:\r\n" + ex.Message);
                return;
            }
        }

        private void OperationQueueAdd(csTCPClientInfo client, string sText)
        {
            lock (LockOperationQueue)
            {
                //Prepare info
                csTCPOperation operation = new csTCPOperation(client, sText);
                OperationQueue.Add(operation);
            }
        }


        private void RemoveFromList(string sRemote)
        {
            //Try to remove from current list
            Clients.TryRemove(sRemote, out csTCPClientInfo client);
        }




        public void ProcessUDPSend()
        {
            while (ServerEnable && !UIExit)
            {
                //avoid sticky package and increase performance
                Thread.Sleep(50);

                //check message list
                if (UdpMessages.Count < 1) continue;

                try
                {
                    //Add log to message


                    //Get the first message
                    string sMessage = UdpMessages.First(); //Get command string

                    //Prepare message
                    sMessage = "��" + sMessage + "��";
                    byte[] bData = Encoding.UTF8.GetBytes(sMessage);

                    //Directly sends message
                    socketUDP.Send(bData, bData.Length);

                    Debug.WriteLine($"{csPublic.TimeString}:UDP Sent:{UdpEndPoint}\r\n" + sMessage);

                    UdpMessages.TryDequeue(out string sSent);//Remove sent message
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("csTCPServer.ResponseProcessConfig" + ex.Message);
                }
            }

            //Finish up
            try
            {
                socketUDP.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csTCPServer.ProcessUDPSend:\r\n" + ex.Message);
            }
        }

        public void SendUdpMessage(string sMessage)
        {
            UdpMessages.Enqueue(sMessage);
        }
    }






}
