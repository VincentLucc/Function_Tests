// Decompiled with JetBrains decompiler
// Type: Reader.RXInventoryTagEnd
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

namespace Reader
{
  public class RXInventoryTagEnd
  {
    public int mCurrentAnt;
    public int mTagCount;
    public int mReadRate;
    public int mTotalRead;
    public byte cmd;

    public RXInventoryTagEnd()
    {
      this.mCurrentAnt = 0;
      this.mTagCount = 0;
      this.mReadRate = 0;
      this.mTotalRead = 0;
      this.cmd = (byte) 0;
    }
  }
}
