// Decompiled with JetBrains decompiler
// Type: Reader.RXInventoryTag
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

namespace Reader
{
  public class RXInventoryTag
  {
    public string strPC;
    public string strCRC;
    public string strEPC;
    public byte btAntId;
    public string strRSSI;
    public string strFreq;
    public int mReadCount;
    public byte cmd;

    public RXInventoryTag()
    {
      this.strPC = "";
      this.strCRC = "";
      this.strEPC = "";
      this.btAntId = (byte) 0;
      this.strRSSI = "";
      this.strFreq = "";
      this.cmd = (byte) 0;
    }
  }
}
