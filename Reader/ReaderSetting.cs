// Decompiled with JetBrains decompiler
// Type: Reader.ReaderSetting
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System.Collections.Generic;

namespace Reader
{
  public class ReaderSetting
  {
    public byte btReadId;
    public byte btMajor;
    public byte btMinor;
    public byte btIndexBaudrate;
    public byte btPlusMinus;
    public byte btTemperature;
    public byte btOutputPower;
    public byte[] btOutputPowers;
    public byte btWorkAntenna;
    public byte btDrmMode;
    public byte btRegion;
    public byte btFrequencyStart;
    public byte btFrequencyEnd;
    public byte btBeeperMode;
    public byte btGpio1Value;
    public byte btGpio2Value;
    public byte btGpio3Value;
    public byte btGpio4Value;
    public byte btAntDetector;
    public byte btMonzaStatus;
    public string btReaderIdentifier;
    public byte btAntImpedance;
    public byte btImpedanceFrequency;
    public int nUserDefineStartFrequency;
    public byte btUserDefineFrequencyInterval;
    public byte btUserDefineChannelQuantity;
    public byte btLinkProfile;
    public string mMatchEpcValue;
    public List<MaskMap> maskValues;

    public ReaderSetting()
    {
      this.btReadId = byte.MaxValue;
      this.btMajor = (byte) 0;
      this.btMinor = (byte) 0;
      this.btIndexBaudrate = (byte) 0;
      this.btPlusMinus = (byte) 0;
      this.btTemperature = (byte) 0;
      this.btOutputPower = (byte) 0;
      this.btWorkAntenna = (byte) 0;
      this.btDrmMode = (byte) 0;
      this.btRegion = (byte) 0;
      this.btFrequencyStart = (byte) 0;
      this.btFrequencyEnd = (byte) 0;
      this.btBeeperMode = (byte) 0;
      this.btGpio1Value = (byte) 0;
      this.btGpio2Value = (byte) 0;
      this.btGpio3Value = (byte) 0;
      this.btGpio4Value = (byte) 0;
      this.btAntDetector = (byte) 0;
      this.maskValues = new List<MaskMap>();
    }
  }
}
