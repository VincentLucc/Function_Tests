// Decompiled with JetBrains decompiler
// Type: Reader.MessageTran
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;

namespace Reader
{
  public class MessageTran
  {
    private byte btPacketType;
    private byte btDataLen;
    private byte btReadId;
    private byte btCmd;
    private byte[] btAryData;
    private byte btCheck;
    private byte[] btAryTranData;

    public byte[] AryTranData
    {
      get
      {
        return this.btAryTranData;
      }
    }

    public byte[] AryData
    {
      get
      {
        return this.btAryData;
      }
    }

    public byte ReadId
    {
      get
      {
        return this.btReadId;
      }
    }

    public byte Cmd
    {
      get
      {
        return this.btCmd;
      }
    }

    public byte PacketType
    {
      get
      {
        return this.btPacketType;
      }
    }

    public MessageTran()
    {
    }

    public MessageTran(byte btReadId, byte btCmd, byte[] btAryData)
    {
      int length = btAryData.Length;
      this.btPacketType = (byte) 160;
      this.btDataLen = Convert.ToByte(length + 3);
      this.btReadId = btReadId;
      this.btCmd = btCmd;
      this.btAryData = new byte[length];
      btAryData.CopyTo((Array) this.btAryData, 0);
      this.btAryTranData = new byte[length + 5];
      this.btAryTranData[0] = this.btPacketType;
      this.btAryTranData[1] = this.btDataLen;
      this.btAryTranData[2] = this.btReadId;
      this.btAryTranData[3] = this.btCmd;
      this.btAryData.CopyTo((Array) this.btAryTranData, 4);
      this.btCheck = this.CheckSum(this.btAryTranData, 0, length + 4);
      this.btAryTranData[length + 4] = this.btCheck;
    }

    public MessageTran(byte btReadId, byte btCmd)
    {
      this.btPacketType = (byte) 160;
      this.btDataLen = (byte) 3;
      this.btReadId = btReadId;
      this.btCmd = btCmd;
      this.btAryTranData = new byte[5];
      this.btAryTranData[0] = this.btPacketType;
      this.btAryTranData[1] = this.btDataLen;
      this.btAryTranData[2] = this.btReadId;
      this.btAryTranData[3] = this.btCmd;
      this.btCheck = this.CheckSum(this.btAryTranData, 0, 4);
      this.btAryTranData[4] = this.btCheck;
    }

    public MessageTran(byte[] btAryTranData)
    {
      int length = btAryTranData.Length;
      this.btAryTranData = new byte[length];
      btAryTranData.CopyTo((Array) this.btAryTranData, 0);
      if ((int) this.CheckSum(this.btAryTranData, 0, this.btAryTranData.Length - 1) != (int) btAryTranData[length - 1])
        return;
      this.btPacketType = btAryTranData[0];
      this.btDataLen = btAryTranData[1];
      this.btReadId = btAryTranData[2];
      this.btCmd = btAryTranData[3];
      this.btCheck = btAryTranData[length - 1];
      if (length > 5)
      {
        this.btAryData = new byte[length - 5];
        for (int index = 0; index < length - 5; ++index)
          this.btAryData[index] = btAryTranData[4 + index];
      }
    }

    public byte CheckSum(byte[] btAryBuffer, int nStartPos, int nLen)
    {
      byte num = (byte) 0;
      for (int index = nStartPos; index < nStartPos + nLen; ++index)
        num += btAryBuffer[index];
      return Convert.ToByte((int) ~num + 1 & (int) byte.MaxValue);
    }
  }
}
