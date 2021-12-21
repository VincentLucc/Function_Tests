// Decompiled with JetBrains decompiler
// Type: Reader.RXOperationTag
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

namespace Reader
{
  public class RXOperationTag
  {
    public string strPC;
    public string strCRC;
    public string strEPC;
    public string strData;
    public int nDataLen;
    public byte btAntId;
    public int nOperateCount;
    public byte cmd;

    public RXOperationTag()
    {
      this.strPC = "";
      this.strCRC = "";
      this.strEPC = "";
      this.strData = "";
      this.nDataLen = 0;
      this.btAntId = (byte) 0;
      this.nOperateCount = 0;
      this.cmd = (byte) 0;
    }
  }
}
