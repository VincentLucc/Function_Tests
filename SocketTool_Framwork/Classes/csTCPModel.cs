using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketTool_Framework
{


    public class csTCPModel
    {
        /// <summary>
        /// socket close
        /// </summary>
        /// <param name="socket"></param>
        public static void CloseSocket(Socket socket)
        {
            try
            {
                if (socket != null)
                {
                    //avoid none error
                    if (socket.Connected)
                        socket.Shutdown(SocketShutdown.Both);

                    socket.Close();
                    socket = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csTCPModel.CloseSocket:\r\n" + ex.Message);
            }
        }

        /// <summary>
        /// Socket.Connected only shows last recorded status
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool IsConnected(Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csTCPModel.IsConnected:\r\n" + ex.Message);
                return false;
            }
        }
    }

    /// <summary>
    /// Used to handle user request in JSON format
    /// Use request to get detailed request info
    /// Use response to send detailed feedback info
    /// </summary>
    public class csTCPOperation
    {

        /// <summary>
        /// Always use local time to avoid time-mismatch
        /// </summary>
        public DateTime CreateTime { get; set; }
        public csTCPClientInfo ClientInfo { get; set; }

        /// <summary>
        /// JSON format request
        /// </summary>
        public csTCPRequest Request { get; set; }
        public csTCPResponse Response { get; set; }

        /// <summary>
        /// Plain text request
        /// </summary>
        public string TextRequest { get; set; }

        public csTCPOperation()
        {
            Request = new csTCPRequest();
            Response = new csTCPResponse();
            CreateTime = DateTime.Now;
        }

        public csTCPOperation(csTCPClientInfo client, string sText)
        {
            CreateTime = DateTime.Now;
            ClientInfo = client;
            TextRequest = sText;
        }
    }

    public class csTCPRequest
    {

        /// <summary>
        /// Unique command ID to Make sure command can run in async mode.
        /// </summary>
        public long CommandID { get; set; }

        /// <summary>
        /// Request parameter
        /// </summary>
        public double DoubleValue { get; set; }
        /// <summary>
        /// Request parameter
        /// </summary>
        public string StrValue { get; set; }

        /// <summary>
        /// Time out in ms, remote time out include the time when process stopped.
        /// </summary>
        public int RequestTimeout { get; set; }

        public csTCPRequest(int iTimeout = 3000)
        {
            CommandID = DateTime.Now.Ticks;
            RequestTimeout = iTimeout;
        }
    }

    /// <summary>
    /// Client receive from server 
    /// </summary>
    public class csTCPResponse
    {

        /// <summary>
        /// Unique command ID to Make sure command can run in async mode.
        /// </summary>
        public long CommandID { get; set; }

        /// <summary>
        /// Indicate whether a reply is received from server, set locally
        /// </summary>
        [JsonIgnore]
        public bool IsReplied { get; set; }
        /// <summary>
        /// Set in remote to indicate command exe OK
        /// </summary>
        public bool IsSuccess { get; set; }

        public string StrValue { get; set; }

        public double DoubleValue { get; set; }


        public csTCPResponse()
        {

        }
    }

    public class csTCPClientInfo
    {
        public Socket ClientSocket { get; set; }

        public string RemoteEndPoint => GetRemoteEndPoint();

        private List<string> Messages2Send { get; set; }

        public object lockMessages2Send { get; set; }

        private DateTime LastMessageTime { get; set; }
        /// <summary>
        /// Time span between each keep alive signal in ms
        /// </summary>
        private double KeepAliveGap { get; set; }

        /// <summary>
        /// Sending thread
        /// </summary>
        public Thread tSend { get; set; }
        /// <summary>
        /// receiving thread
        /// </summary>
        public Thread tReceive { get; set; }

        /// <summary>
        /// Indicate whether current client is valid
        /// </summary>
        public bool IsValid { get; set; }

        public csTCPClientInfo()
        {
            Messages2Send = new List<string>();
            lockMessages2Send = new object();
            KeepAliveGap = 60000;
        }

        public void SendMessage(string sMessage)
        {
            lock (lockMessages2Send)
            {
                Messages2Send.Add(sMessage);
                LastMessageTime = DateTime.Now;
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
            TimeSpan timeSpan = DateTime.Now - LastMessageTime;
            if (timeSpan.TotalMilliseconds > KeepAliveGap)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetRemoteEndPoint()
        {
            if (ClientSocket == null) return "";
            if (ClientSocket.RemoteEndPoint == null) return "";
            return ClientSocket.RemoteEndPoint.ToString();
        }
    }
}
