// Decompiled with JetBrains decompiler
// Type: Reader.Talker
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Reader
{
    public class Talker : ITalker
    {
        private bool bIsConnect = false;
        private TcpClient client;
        private Stream streamToTran;
        private Thread waitThread;

        public event MessageReceivedEventHandler MessageReceived;

        public bool Connect(IPAddress ipAddress, int nPort, out string strException)
        {
            strException = string.Empty;
            try
            {
                this.client = new TcpClient();
                this.client.Connect(ipAddress, nPort);
                return this.Connect((Stream)this.client.GetStream());
            }
            catch (Exception ex)
            {
                strException = ex.Message;
                return false;
            }
        }

        public bool Connect(Stream otherSrc)
        {
            this.streamToTran = otherSrc;
            this.waitThread = new Thread(new ThreadStart(this.ReceivedData));
            this.waitThread.IsBackground = true;
            this.waitThread.Start();
            this.bIsConnect = true;
            return true;
        }

        private void ReceivedData()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[4096];
                    int length = this.streamToTran.Read(buffer, 0, buffer.Length);
                    if (length != 0)
                    {
                        if (this.MessageReceived != null)
                        {
                            byte[] btAryBuffer = new byte[length];
                            Array.Copy((Array)buffer, (Array)btAryBuffer, length);
                            this.MessageReceived(btAryBuffer);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Talker.ReceivedData" + ex.Message);
                }
            }
        }

        public bool SendMessage(byte[] btAryBuffer)
        {
            try
            {
                lock (this.streamToTran)
                {
                    this.streamToTran.Write(btAryBuffer, 0, btAryBuffer.Length);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void SignOut()
        {
            if (this.streamToTran != null)
                this.streamToTran.Dispose();
            if (this.client != null)
                this.client.Close();
            this.waitThread.Abort();
            this.bIsConnect = false;
        }

        public bool IsConnect()
        {
            return this.bIsConnect;
        }
    }
}
