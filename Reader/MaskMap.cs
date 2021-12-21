// Decompiled with JetBrains decompiler
// Type: Reader.MaskMap
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;

namespace Reader
{
  public class MaskMap
  {
    public byte mMaskID;
    public byte mMaskQuantity;
    public byte mTarget;
    public byte mAction;
    public byte mMembank;
    public byte mStartMaskAdd;
    public byte mMaskBitLen;
    public byte[] mMaskValue;
    public byte mTruncate;

    public MaskMap(byte[] data)
    {
      this.mMaskID = data[0];
      this.mMaskQuantity = data[1];
      this.mTarget = data[2];
      this.mAction = data[3];
      this.mMembank = data[4];
      this.mStartMaskAdd = data[5];
      this.mMaskBitLen = data[6];
      this.mMaskValue = new byte[data.Length - 8];
      for (int index = 0; index < this.mMaskValue.Length; ++index)
        this.mMaskValue[index] = data[index + 7];
      data.CopyTo((Array) this.mMaskValue, 0);
      this.mTruncate = data[data.Length - 1];
    }
  }
}
