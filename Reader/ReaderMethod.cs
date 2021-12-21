// Decompiled with JetBrains decompiler
// Type: Reader.ReaderMethod
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Net;

namespace Reader
{
    public class ReaderMethod
    {
        /// <summary>
        /// network type, 0:com, 1: TCP,-1 not set
        /// </summary>
        private int m_nType = -1;
        private byte[] m_btAryBuffer = new byte[4096];
        private int m_nLenth = 0;
        private ITalker italker;
        public SerialPort iSerialPort;
        public ReaderProcessor m_Processor;
        public ReciveDataCallback ReceiveCallback;
        public SendDataCallback SendCallback;
        private AnalyDataCallback AnalyCallback;
        public OnExeCMDStatus m_OnExeCMDStatus;
        public RefreshSetting m_RefreshSetting;
        public OnInventoryTag m_OnInventoryTag;
        public OnInventoryTagEnd m_OnInventoryTagEnd;
        public OnFastSwitchAntInventoryTagEnd m_OnFastSwitchAntInventoryTagEnd;
        public OnGetInventoryBufferTagCount m_OnGetInventoryBufferTagCount;
        public OnOperationTag m_OnOperationTag;
        public OnOperationTagEnd m_OnOperationTagEnd;
        public OnInventory6BTag m_OnInventory6BTag;
        public OnInventory6BTagEnd m_OnInventory6BTagEnd;
        public OnRead6BTag m_OnRead6BTag;
        public OnWrite6BTag m_OnWrite6BTag;
        public OnLock6BTag m_OnLock6BTag;
        public OnLockQuery6BTag m_OnLockQuery6BTag;

        public ReaderMethod()
        {
            this.italker = (ITalker)new Talker();
            this.italker.MessageReceived += new MessageReceivedEventHandler(this.ReceivedTcpData);
            this.iSerialPort = new SerialPort();
            this.iSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.ReceivedComData);
            this.m_Processor = new ReaderProcessor(this);
            this.AnalyCallback = new AnalyDataCallback(this.m_Processor.AnalyData);
        }

        public int OpenCom(string strPort, int nBaudrate, out string strException)
        {
            strException = string.Empty;
            if (this.iSerialPort.IsOpen)
                this.iSerialPort.Close();
            try
            {
                this.iSerialPort.PortName = strPort;
                this.iSerialPort.BaudRate = nBaudrate;
                this.iSerialPort.ReadTimeout = 200;
                this.iSerialPort.Open();
            }
            catch (Exception ex)
            {
                strException = ex.Message;
                return -1;
            }
            this.m_nType = 0;
            return 0;
        }

        public void CloseCom()
        {
            if (this.iSerialPort.IsOpen)
                this.iSerialPort.Close();
            this.m_nType = -1;
        }

        public int ConnectServer(IPAddress ipAddress, int nPort, out string strException)
        {
            strException = string.Empty;
            if (!this.italker.Connect(ipAddress, nPort, out strException))
                return -1;
            this.m_nType = 1;
            return 0;
        }

        public int Connect(Stream otherSrc)
        {
            if (!this.italker.Connect(otherSrc))
                return -1;
            this.m_nType = 1;
            return 0;
        }

        public void SignOut()
        {
            this.italker.SignOut();
            this.m_nType = -1;
        }

        private void ReceivedTcpData(byte[] btAryBuffer)
        {
            this.RunReceiveDataCallback(btAryBuffer);
        }

        private void ReceivedComData(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = this.iSerialPort.BytesToRead;
                if (bytesToRead == 0)
                    return;
                byte[] numArray = new byte[bytesToRead];
                this.iSerialPort.Read(numArray, 0, bytesToRead);
                this.RunReceiveDataCallback(numArray);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ReaderMethod.ReceivedComData:\r\n" + ex.Message);
            }
        }

        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            try
            {
                if (this.ReceiveCallback != null)
                    this.ReceiveCallback(btAryReceiveData);
                byte[] numArray = new byte[btAryReceiveData.Length + this.m_nLenth];
                Array.Copy((Array)this.m_btAryBuffer, (Array)numArray, this.m_nLenth);
                Array.Copy((Array)btAryReceiveData, 0, (Array)numArray, this.m_nLenth, btAryReceiveData.Length);
                int sourceIndex1 = 0;
                int num1 = 0;
                for (int sourceIndex2 = 0; sourceIndex2 < numArray.Length; ++sourceIndex2)
                {
                    if (numArray.Length > sourceIndex2 + 1)
                    {
                        if ((int)numArray[sourceIndex2] == 160)
                        {
                            int num2 = Convert.ToInt32(numArray[sourceIndex2 + 1]);
                            if (sourceIndex2 + 1 + num2 < numArray.Length)
                            {
                                byte[] btAryTranData = new byte[num2 + 2];
                                Array.Copy((Array)numArray, sourceIndex2, (Array)btAryTranData, 0, num2 + 2);
                                MessageTran msgTran = new MessageTran(btAryTranData);
                                if (this.AnalyCallback != null)
                                    this.AnalyCallback(msgTran);
                                sourceIndex2 += 1 + num2;
                                sourceIndex1 = sourceIndex2 + 1;
                            }
                            else
                                sourceIndex2 += 1 + num2;
                        }
                        else
                            num1 = sourceIndex2;
                    }
                }
                if (sourceIndex1 < num1)
                    sourceIndex1 = num1 + 1;
                if (sourceIndex1 < numArray.Length)
                {
                    this.m_nLenth = numArray.Length - sourceIndex1;
                    Array.Clear((Array)this.m_btAryBuffer, 0, 4096);
                    Array.Copy((Array)numArray, sourceIndex1, (Array)this.m_btAryBuffer, 0, numArray.Length - sourceIndex1);
                }
                else
                    this.m_nLenth = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ReaderMethod.RunReceiveDataCallback:\r\n" + ex.Message);
            }
        }

        public int SendMessage(byte[] btArySenderData)
        {
            if (this.m_nType == 0)
            {
                if (!this.iSerialPort.IsOpen)
                    return -1;
                this.iSerialPort.Write(btArySenderData, 0, btArySenderData.Length);
                if (this.SendCallback != null)
                    this.SendCallback(btArySenderData);
                return 0;
            }
            if (this.m_nType != 1 || !this.italker.IsConnect() || !this.italker.SendMessage(btArySenderData))
                return -1;
            if (this.SendCallback != null)
                this.SendCallback(btArySenderData);
            return 0;
        }

        private int SendMessage(byte btReadId, byte btCmd)
        {
            return this.SendMessage(new MessageTran(btReadId, btCmd).AryTranData);
        }

        private int SendMessage(byte btReadId, byte btCmd, byte[] btAryData)
        {
            return this.SendMessage(new MessageTran(btReadId, btCmd, btAryData).AryTranData);
        }

        public byte CheckValue(byte[] btAryData)
        {
            return new MessageTran().CheckSum(btAryData, 0, btAryData.Length);
        }

        public int Reset(byte btReadId)
        {
            byte btCmd = (byte)112;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetUartBaudrate(byte btReadId, int nIndexBaudrate)
        {
            byte btCmd = (byte)113;
            byte[] btAryData = new byte[1]
            {
        Convert.ToByte(nIndexBaudrate)
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetFirmwareVersion(byte btReadId)
        {
            byte btCmd = (byte)114;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            byte btCmd = (byte)115;
            byte[] btAryData = new byte[1]
            {
        btNewReadId
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            byte btCmd = (byte)116;
            byte[] btAryData = new byte[1]
            {
        btWorkAntenna
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetWorkAntenna(byte btReadId)
        {
            byte btCmd = (byte)117;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetOutputPower(byte btReadId, byte btOutputPower)
        {
            byte btCmd = (byte)118;
            byte[] btAryData = new byte[1]
            {
        btOutputPower
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetOutputPower(byte btReadId, byte ant1Power, byte ant2Power, byte ant3Power, byte ant4Power)
        {
            byte btCmd = (byte)118;
            byte[] btAryData = new byte[4]
            {
        ant1Power,
        ant2Power,
        ant3Power,
        ant4Power
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetOutputPower(byte btReadId, byte[] btOutputPower)
        {
            byte btCmd = (byte)118;
            return this.SendMessage(btReadId, btCmd, btOutputPower);
        }

        public int GetOutputPower(byte btReadId)
        {
            byte btCmd = (byte)119;
            return this.SendMessage(btReadId, btCmd);
        }

        public int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            byte btCmd = (byte)126;
            byte[] btAryData = new byte[1]
            {
        btFrequency
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion)
        {
            byte btCmd = (byte)120;
            byte[] btAryData = new byte[3]
            {
        btRegion,
        btStartRegion,
        btEndRegion
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity)
        {
            byte btCmd = (byte)120;
            byte[] numArray = new byte[3];
            byte[] btAryData = new byte[6];
            byte[] bytes = BitConverter.GetBytes(nStartFreq);
            btAryData[0] = (byte)4;
            btAryData[1] = btFreqInterval;
            btAryData[2] = btChannelQuantity;
            btAryData[3] = bytes[2];
            btAryData[4] = bytes[1];
            btAryData[5] = bytes[0];
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetFrequencyRegion(byte btReadId)
        {
            byte btCmd = (byte)121;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetBeeperMode(byte btReadId, byte btMode)
        {
            byte btCmd = (byte)122;
            byte[] btAryData = new byte[1]
            {
        btMode
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetReaderTemperature(byte btReadId)
        {
            byte btCmd = (byte)123;
            return this.SendMessage(btReadId, btCmd);
        }

        public int GetAntImpedanceMatch(byte btReadId, byte btFrequency)
        {
            byte btCmd = (byte)126;
            byte[] btAryData = new byte[1]
            {
        btFrequency
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            byte btCmd = (byte)124;
            byte[] btAryData = new byte[1]
            {
        btDrmMode
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetDrmMode(byte btReadId)
        {
            byte btCmd = (byte)125;
            return this.SendMessage(btReadId, btCmd);
        }

        public int ReadGpioValue(byte btReadId)
        {
            byte btCmd = (byte)96;
            return this.SendMessage(btReadId, btCmd);
        }

        public int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            byte btCmd = (byte)97;
            byte[] btAryData = new byte[2]
            {
        btChooseGpio,
        btGpioValue
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetAntDetector(byte btReadId, byte btDetectorStatus)
        {
            byte btCmd = (byte)98;
            byte[] btAryData = new byte[1]
            {
        btDetectorStatus
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetAntDetector(byte btReadId)
        {
            byte btCmd = (byte)99;
            return this.SendMessage(btReadId, btCmd);
        }

        public int GetMonzaStatus(byte btReadId)
        {
            byte btCmd = (byte)142;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetMonzaStatus(byte btReadId, byte btMonzaStatus)
        {
            byte btCmd = (byte)141;
            byte[] btAryData = new byte[1]
            {
        btMonzaStatus
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetRadioProfile(byte btReadId, byte btProfile)
        {
            byte btCmd = (byte)105;
            byte[] btAryData = new byte[1]
            {
        btProfile
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetRadioProfile(byte btReadId)
        {
            byte btCmd = (byte)106;
            return this.SendMessage(btReadId, btCmd);
        }

        public int GetReaderIdentifier(byte btReadId)
        {
            byte btCmd = (byte)104;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetReaderIdentifier(byte btReadId, byte[] identifier)
        {
            byte btCmd = (byte)103;
            return this.SendMessage(btReadId, btCmd, identifier);
        }

        public int Inventory(byte btReadId, byte byRound)
        {
            byte btCmd = (byte)128;
            byte[] btAryData = new byte[1]
            {
        byRound
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int CustomizedInventory(byte btReadId, byte session, byte target, byte SL, byte byRound)
        {
            byte btCmd = (byte)139;
            byte[] btAryData = new byte[4]
            {
        session,
        target,
        SL,
        byRound
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btPassword)
        {
            byte btCmd = (byte)129;
            byte[] btAryData = btPassword != null ? new byte[3 + btPassword.Length] : new byte[3];
            btAryData[0] = btMemBank;
            btAryData[1] = btWordAdd;
            btAryData[2] = btWordCnt;
            if (btPassword != null)
                btPassword.CopyTo((Array)btAryData, 3);
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
            byte btCmd = (byte)130;
            byte[] btAryData1 = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo((Array)btAryData1, 0);
            btAryData1[4] = btMemBank;
            btAryData1[5] = btWordAdd;
            btAryData1[6] = btWordCnt;
            btAryData.CopyTo((Array)btAryData1, 7);
            return this.SendMessage(btReadId, btCmd, btAryData1);
        }

        public int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType)
        {
            byte btCmd = (byte)131;
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo((Array)btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int KillTag(byte btReadId, byte[] btAryPassWord)
        {
            byte btCmd = (byte)132;
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo((Array)btAryData, 0);
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc)
        {
            byte btCmd = (byte)133;
            byte[] btAryData = new byte[Convert.ToInt32(btEpcLen) + 2];
            btAryData[0] = btMode;
            btAryData[1] = btEpcLen;
            btAryEpc.CopyTo((Array)btAryData, 2);
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int CancelAccessEpcMatch(byte btReadId, byte btMode)
        {
            byte btCmd = (byte)133;
            byte[] btAryData = new byte[1]
            {
        btMode
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetAccessEpcMatch(byte btReadId)
        {
            byte btCmd = (byte)134;
            return this.SendMessage(btReadId, btCmd);
        }

        public int InventoryReal(byte btReadId, byte byRound)
        {
            byte btCmd = (byte)137;
            byte[] btAryData = new byte[1]
            {
        byRound
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int FastSwitchInventory(byte btReadId, byte[] btAryData)
        {
            byte btCmd = (byte)138;
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetInventoryBuffer(byte btReadId)
        {
            byte btCmd = (byte)144;
            return this.SendMessage(btReadId, btCmd);
        }

        public int GetAndResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = (byte)145;
            return this.SendMessage(btReadId, btCmd);
        }

        public int GetInventoryBufferTagCount(byte btReadId)
        {
            byte btCmd = (byte)146;
            return this.SendMessage(btReadId, btCmd);
        }

        public int ResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = (byte)147;
            return this.SendMessage(btReadId, btCmd);
        }

        public int SetBufferDataFrameInterval(byte btReadId, byte btInterval)
        {
            byte btCmd = (byte)148;
            byte[] btAryData = new byte[1]
            {
        btInterval
            };
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int GetBufferDataFrameInterval(byte btReadId)
        {
            byte btCmd = (byte)149;
            return this.SendMessage(btReadId, btCmd);
        }

        public int InventoryISO18000(byte btReadId)
        {
            byte btCmd = (byte)176;
            return this.SendMessage(btReadId, btCmd);
        }

        public int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt)
        {
            byte btCmd = (byte)177;
            int length = btAryUID.Length + 2;
            byte[] btAryData = new byte[length];
            btAryUID.CopyTo((Array)btAryData, 0);
            btAryData[length - 2] = btWordAdd;
            btAryData[length - 1] = btWordCnt;
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer)
        {
            byte btCmd = (byte)178;
            byte[] btAryData = new byte[btAryUID.Length + 2 + btAryBuffer.Length];
            btAryUID.CopyTo((Array)btAryData, 0);
            btAryData[btAryUID.Length] = btWordAdd;
            btAryData[btAryUID.Length + 1] = btWordCnt;
            btAryBuffer.CopyTo((Array)btAryData, btAryUID.Length + 2);
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = (byte)179;
            int length = btAryUID.Length + 1;
            byte[] btAryData = new byte[length];
            btAryUID.CopyTo((Array)btAryData, 0);
            btAryData[length - 1] = btWordAdd;
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = (byte)180;
            int length = btAryUID.Length + 1;
            byte[] btAryData = new byte[length];
            btAryUID.CopyTo((Array)btAryData, 0);
            btAryData[length - 1] = btWordAdd;
            return this.SendMessage(btReadId, btCmd, btAryData);
        }

        public int setTagMask(byte btReadId, byte btMaskNo, byte btTarget, byte btAction, byte btMembank, byte btStartAdd, byte btMaskLen, byte[] maskValue)
        {
            byte[] btAryData = new byte[7 + maskValue.Length];
            btAryData[0] = btMaskNo;
            btAryData[1] = btTarget;
            btAryData[2] = btAction;
            btAryData[3] = btMembank;
            btAryData[4] = btStartAdd;
            btAryData[5] = btMaskLen;
            maskValue.CopyTo((Array)btAryData, 6);
            btAryData[btAryData.Length - 1] = (byte)0;
            return this.SendMessage(btReadId, (byte)152, btAryData);
        }

        public int getTagMask(byte btReadId)
        {
            byte[] btAryData = new byte[1]
            {
        (byte) 32
            };
            return this.SendMessage(btReadId, (byte)152, btAryData);
        }

        public int clearTagMask(byte btReadId, byte btMaskNO)
        {
            byte[] btAryData = new byte[1]
            {
        btMaskNO
            };
            return this.SendMessage(btReadId, (byte)152, btAryData);
        }
    }
}
