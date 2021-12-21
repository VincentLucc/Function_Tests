// Decompiled with JetBrains decompiler
// Type: Reader.ITalker
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System.IO;
using System.Net;

namespace Reader
{
  internal interface ITalker
  {
    event MessageReceivedEventHandler MessageReceived;

    bool Connect(IPAddress ip, int port, out string strException);

    bool Connect(Stream otherSrc);

    bool SendMessage(byte[] btAryBuffer);

    void SignOut();

    bool IsConnect();
  }
}
