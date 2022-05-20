// Decompiled with JetBrains decompiler
// Type: Reader.ReaderProcessor
// Assembly: Reader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 182B58F8-B8D7-4B30-BB9C-B240289457A7
// Assembly location: C:\Users\Administrator\Desktop\C#RFID\UHFSDK\Reader.dll

using System;
using System.Diagnostics;

namespace Reader
{
    public class ReaderProcessor
    {
        public ReaderSetting m_curSetting = new ReaderSetting();
        private int mOperationTagCount = 0;
        private int mMaskQuantity = 0;
        private ReaderMethod readMethod;

        public ReaderProcessor(ReaderMethod read)
        {
            this.readMethod = read;
        }

        public void AnalyData(MessageTran msgTran)
        {
            if ((int)msgTran.PacketType != 160)
                return;
            switch (msgTran.Cmd)
            {
                case (byte)96: //0x61
                    this.ProcessReadGpioValue(msgTran);
                    break;
                case (byte)97://0x62
                    this.ProcessWriteGpioValue(msgTran);
                    break;
                case (byte)98://0x63
                    this.ProcessSetAntDetector(msgTran);
                    break;
                case (byte)99://0x64
                    this.ProcessGetAntDetector(msgTran);
                    break;
                case (byte)103://0x67
                    this.ProcessSetReaderIdentifier(msgTran);
                    break;
                case (byte)104://0x68
                    this.ProcessGetReaderIdentifier(msgTran);
                    break;
                case (byte)105://0x69
                    this.ProcessSetProfile(msgTran);
                    break;
                case (byte)106://0x6A
                    this.ProcessGetProfile(msgTran);
                    break;
                case (byte)113://0x71
                    this.ProcessSetUartBaudrate(msgTran);
                    break;
                case (byte)114://0x72
                    this.ProcessGetFirmwareVersion(msgTran);
                    break;
                case (byte)115://0x73
                    this.ProcessSetReadAddress(msgTran);
                    break;
                case (byte)116://0x74
                    this.ProcessSetWorkAntenna(msgTran);
                    break;
                case (byte)117://0x75
                    this.ProcessGetWorkAntenna(msgTran);
                    break;
                case (byte)118://0x76
                    this.ProcessSetOutputPower(msgTran);
                    break;
                case (byte)119://0x77
                    this.ProcessGetOutputPower(msgTran);
                    break;
                case (byte)120://0x78
                    this.ProcessSetFrequencyRegion(msgTran);
                    break;
                case (byte)121://0x79
                    this.ProcessGetFrequencyRegion(msgTran);
                    break;
                case (byte)122://0x7A
                    this.ProcessSetBeeperMode(msgTran);
                    break;
                case (byte)123://0x7B
                    this.ProcessGetReaderTemperature(msgTran);
                    break;
                case (byte)124://0x7C
                    this.ProcessSetDrmMode(msgTran);
                    break;
                case (byte)125://0x7D
                    this.ProcessGetDrmMode(msgTran);
                    break;
                case (byte)126://0x7E
                    this.ProcessGetImpedanceMatch(msgTran);
                    break;
                case (byte)128://0x80
                    this.ProcessInventory(msgTran);
                    break;
                case (byte)129://0x81
                    this.ProcessReadTag(msgTran);
                    break;
                case (byte)130://0x82
                    this.ProcessWriteTag(msgTran);
                    break;
                case (byte)131://0x83
                    this.ProcessLockTag(msgTran);
                    break;
                case (byte)132://0x84
                    this.ProcessKillTag(msgTran);
                    break;
                case (byte)133://0x85
                    this.ProcessSetAccessEpcMatch(msgTran);
                    break;
                case (byte)134://0x86
                    this.ProcessGetAccessEpcMatch(msgTran);
                    break;
                case (byte)137://0x89
                case (byte)139://0x8B
                    this.ProcessInventoryReal(msgTran);
                    break;
                case (byte)138://0x8A
                    this.ProcessFastSwitch(msgTran);
                    break;
                case (byte)141://0x8D
                    this.ProcessSetMonzaStatus(msgTran);
                    break;
                case (byte)142://0x8E
                    this.ProcessGetMonzaStatus(msgTran);
                    break;
                case (byte)144://0x90
                    this.ProcessGetInventoryBuffer(msgTran);
                    break;
                case (byte)145://0x91
                    this.ProcessGetAndResetInventoryBuffer(msgTran);
                    break;
                case (byte)146://0x92
                    this.ProcessGetInventoryBufferTagCount(msgTran);
                    break;
                case (byte)147://0x93
                    this.ProcessResetInventoryBuffer(msgTran);
                    break;
                case (byte)152://0x98
                    this.ProcessTagMask(msgTran);
                    break;
                case (byte)176://0xB0
                    this.ProcessInventoryISO18000(msgTran);
                    break;
                case (byte)177://0xB1
                    this.ProcessReadTagISO18000(msgTran);
                    break;
                case (byte)178://0xB2
                    this.ProcessWriteTagISO18000(msgTran);
                    break;
                case (byte)179://0xB3
                    this.ProcessLockTagISO18000(msgTran);
                    break;
                case (byte)180://0xB4
                    this.ProcessQueryISO18000(msgTran);
                    break;
            }
        }

        private void ProcessSetReadAddress(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetFirmwareVersion(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                this.m_curSetting.btMajor = msgTran.AryData[0];
                this.m_curSetting.btMinor = msgTran.AryData[1];
                this.m_curSetting.btReadId = msgTran.ReadId;
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetUartBaudrate(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetReaderTemperature(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btPlusMinus = msgTran.AryData[0];
                this.m_curSetting.btTemperature = msgTran.AryData[1];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetOutputPower(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btOutputPower = msgTran.AryData[0];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 8)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btOutputPowers = msgTran.AryData;
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetOutputPower(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetWorkAntenna(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 0 || (int)msgTran.AryData[0] == 1 || (int)msgTran.AryData[0] == 2 || (int)msgTran.AryData[0] == 3)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btWorkAntenna = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetWorkAntenna(MessageTran msgTran)
        {
            string str = string.Empty;
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetDrmMode(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 0 || (int)msgTran.AryData[0] == 1)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btDrmMode = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetDrmMode(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private string GetFreqString(byte btFreq)
        {
            string str = string.Empty;
            if ((int)this.m_curSetting.btRegion == 4)
                return ((float)this.m_curSetting.nUserDefineStartFrequency / 1000f + (float)((int)btFreq * (int)this.m_curSetting.btUserDefineFrequencyInterval * 10) / 1000f).ToString("0.000");
            if ((int)btFreq < 7)
                return ((float)(865.0 + (double)Convert.ToInt32(btFreq) * 0.5)).ToString("0.00");
            return ((float)(902.0 + (double)(Convert.ToInt32(btFreq) - 7) * 0.5)).ToString("0.00");
        }

        private void ProcessGetFrequencyRegion(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 3)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btRegion = msgTran.AryData[0];
                this.m_curSetting.btFrequencyStart = msgTran.AryData[1];
                this.m_curSetting.btFrequencyEnd = msgTran.AryData[2];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 6)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btRegion = msgTran.AryData[0];
                this.m_curSetting.btUserDefineFrequencyInterval = msgTran.AryData[1];
                this.m_curSetting.btUserDefineChannelQuantity = msgTran.AryData[2];
                this.m_curSetting.nUserDefineStartFrequency = (int)msgTran.AryData[3] * 256 * 256 + (int)msgTran.AryData[4] * 256 + (int)msgTran.AryData[5];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetFrequencyRegion(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetBeeperMode(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessReadGpioValue(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btGpio1Value = msgTran.AryData[0];
                this.m_curSetting.btGpio2Value = msgTran.AryData[1];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessWriteGpioValue(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetAntDetector(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btAntDetector = msgTran.AryData[0];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetMonzaStatus(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 0 || (int)msgTran.AryData[0] == 141)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btMonzaStatus = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetMonzaStatus(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btAntDetector = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetProfile(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btLinkProfile = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetProfile(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] >= 208 && (int)msgTran.AryData[0] <= 211)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    this.m_curSetting.btLinkProfile = msgTran.AryData[0];
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetReaderIdentifier(MessageTran msgTran)
        {
            string str = "";
            if (msgTran.AryData.Length == 12)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                for (short index = (short)0; (int)index < 12; ++index)
                    str = str + string.Format("{0:X2}", (object)msgTran.AryData[(int)index]) + " ";
                this.m_curSetting.btReaderIdentifier = str;
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetImpedanceMatch(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                this.m_curSetting.btReadId = msgTran.ReadId;
                this.m_curSetting.btAntImpedance = msgTran.AryData[0];
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetReaderIdentifier(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] != 16)
                    return;
                this.m_curSetting.btReadId = msgTran.ReadId;
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetAntDetector(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    this.m_curSetting.btReadId = msgTran.ReadId;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessFastSwitch(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (msgTran.AryData.Length == 2)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (msgTran.AryData.Length == 7)
            {
                int num1 = Convert.ToInt32(msgTran.AryData[0]) * (int)byte.MaxValue * (int)byte.MaxValue + Convert.ToInt32(msgTran.AryData[1]) * (int)byte.MaxValue + Convert.ToInt32(msgTran.AryData[2]);
                int num2 = Convert.ToInt32(msgTran.AryData[3]) * (int)byte.MaxValue * (int)byte.MaxValue * (int)byte.MaxValue + Convert.ToInt32(msgTran.AryData[4]) * (int)byte.MaxValue * (int)byte.MaxValue + Convert.ToInt32(msgTran.AryData[5]) * (int)byte.MaxValue + Convert.ToInt32(msgTran.AryData[6]);
                RXFastSwitchAntInventoryTagEnd end = new RXFastSwitchAntInventoryTagEnd();
                end.mTotalRead = num1;
                end.mCommandDuration = num2;
                if (this.readMethod.m_OnFastSwitchAntInventoryTagEnd == null)
                    return;
                this.readMethod.m_OnFastSwitchAntInventoryTagEnd(end);
            }
            else
            {
                int length = msgTran.AryData.Length;
                int nLen = length - 4;
                string str1 = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, nLen);
                string str2 = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 2);
                string str3 = msgTran.AryData[length - 1].ToString();
                byte num1 = msgTran.AryData[0];
                byte num2 = (byte)(((int)num1 & 3) + 1);
                string freqString = this.GetFreqString((byte)(((int)num1 & (int)byte.MaxValue) >> 2));
                RXInventoryTag tag = new RXInventoryTag();
                tag.strPC = str2;
                tag.strEPC = str1;
                tag.strRSSI = str3;
                tag.strFreq = freqString;
                tag.btAntId = num2;
                tag.cmd = msgTran.Cmd;
                if (this.readMethod.m_OnInventoryTag != null)
                    this.readMethod.m_OnInventoryTag(tag);
            }
        }

        private void ProcessInventoryReal(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (msgTran.AryData.Length == 7)
            {
                RXInventoryTagEnd end = new RXInventoryTagEnd();
                end.mCurrentAnt = (int)msgTran.AryData[0];
                end.mReadRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                end.mTotalRead = Convert.ToInt32(msgTran.AryData[3]) * 256 * 256 * 256 + Convert.ToInt32(msgTran.AryData[4]) * 256 * 256 + Convert.ToInt32(msgTran.AryData[5]) * 256 + Convert.ToInt32(msgTran.AryData[6]);
                end.cmd = msgTran.Cmd;
                if (this.readMethod.m_OnInventoryTagEnd == null)
                    return;
                this.readMethod.m_OnInventoryTagEnd(end);
            }
            else
            {
                int length = msgTran.AryData.Length;
                int nLen = length - 4;
                string str1 = "";
                if (nLen != 0)
                    str1 = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, nLen);
                string str2 = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 2);
                string str3 = msgTran.AryData[length - 1].ToString();
                byte num1 = msgTran.AryData[0];
                byte num2 = (byte)(((int)num1 & 3) + 1);
                string freqString = this.GetFreqString((byte)((uint)num1 >> 2));
                RXInventoryTag tag = new RXInventoryTag();
                tag.strPC = str2;
                tag.strEPC = str1;
                tag.strRSSI = str3;
                tag.strFreq = freqString;
                tag.btAntId = num2;
                tag.cmd = msgTran.Cmd;
                if (this.readMethod.m_OnInventoryTag != null)
                    this.readMethod.m_OnInventoryTag(tag);
            }
        }

        private void ProcessInventory(MessageTran msgTran)
        {
            byte cmd = msgTran.Cmd;
            byte[] aryData = msgTran.AryData;
            if (aryData.Length == 9)
            {
                RXInventoryTagEnd end = new RXInventoryTagEnd();
                end.mCurrentAnt = (int)aryData[0];
                end.mTagCount = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                end.mReadRate = Convert.ToInt32(msgTran.AryData[3]) * 256 + Convert.ToInt32(msgTran.AryData[4]);
                end.mTotalRead = Convert.ToInt32(msgTran.AryData[5]) * 256 * 256 * 256 + Convert.ToInt32(msgTran.AryData[6]) * 256 * 256 + Convert.ToInt32(msgTran.AryData[7]) * 256 + Convert.ToInt32(msgTran.AryData[8]);
                end.cmd = cmd;
                if (this.readMethod.m_OnInventoryTagEnd == null)
                    return;
                this.readMethod.m_OnInventoryTagEnd(end);
            }
            else if (aryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(cmd, aryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(cmd, (byte)88);
        }

        private void ProcessGetInventoryBuffer(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else
            {
                int length = msgTran.AryData.Length;
                int nLen = Convert.ToInt32(msgTran.AryData[2]) - 4;
                string str1 = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, 2);
                string str2 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5, nLen);
                string str3 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5 + nLen, 2);
                string str4 = msgTran.AryData[length - 3].ToString();
                byte num1 = (byte)(((int)msgTran.AryData[length - 2] & 3) + 1);
                int num2 = Convert.ToInt32(msgTran.AryData[length - 1]);
                RXInventoryTag tag = new RXInventoryTag();
                tag.strPC = str1;
                tag.strCRC = str3;
                tag.strEPC = str2;
                tag.btAntId = num1;
                tag.strRSSI = str4;
                tag.mReadCount = num2;
                tag.cmd = msgTran.Cmd;
                if (this.readMethod.m_OnInventoryTag != null)
                    this.readMethod.m_OnInventoryTag(tag);
            }
        }

        private void ProcessGetAndResetInventoryBuffer(MessageTran msgTran)
        {
            this.ProcessGetInventoryBuffer(msgTran);
        }

        private void ProcessGetInventoryBufferTagCount(MessageTran msgTran)
        {
            byte cmd = msgTran.Cmd;
            byte[] aryData = msgTran.AryData;
            if (aryData.Length == 2)
            {
                if (this.readMethod.m_OnGetInventoryBufferTagCount == null)
                    return;
                this.readMethod.m_OnGetInventoryBufferTagCount(Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]));
            }
            else if (aryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(cmd, aryData[0]);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(cmd, (byte)88);
        }

        private void ProcessResetInventoryBuffer(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessGetAccessEpcMatch(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 1)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if ((int)msgTran.AryData[0] == 0)
            {
                this.m_curSetting.mMatchEpcValue = CCommondMethod.ByteArrayToString(msgTran.AryData, 2, Convert.ToInt32(msgTran.AryData[1]));
                this.m_curSetting.btReadId = msgTran.ReadId;
                if (this.readMethod.m_RefreshSetting != null)
                    this.readMethod.m_RefreshSetting(this.m_curSetting);
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessSetAccessEpcMatch(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
                }
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessReadTag(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else
            {
                ++this.mOperationTagCount;
                int length = msgTran.AryData.Length;
                int nLen1 = Convert.ToInt32(msgTran.AryData[length - 3]);
                int nLen2 = Convert.ToInt32(msgTran.AryData[2]) - nLen1 - 4;
                string str1 = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, 2);
                string str2 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5, nLen2);
                string str3 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5 + nLen2, 2);
                string str4 = CCommondMethod.ByteArrayToString(msgTran.AryData, 7 + nLen2, nLen1);
                byte num1 = (byte)(((int)msgTran.AryData[length - 2] & 3) + 1);
                int num2 = Convert.ToInt32(msgTran.AryData[length - 1]);
                RXOperationTag opTag = new RXOperationTag();
                opTag.strPC = str1;
                opTag.strCRC = str3;
                opTag.strEPC = str2;
                opTag.strData = str4;
                opTag.nDataLen = nLen1;
                opTag.btAntId = num1;
                opTag.nOperateCount = num2;
                opTag.cmd = msgTran.Cmd;
                if (this.readMethod.m_OnOperationTag != null)
                    this.readMethod.m_OnOperationTag(opTag);
                if (this.mOperationTagCount == Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]))
                {
                    this.mOperationTagCount = 0;
                    if (this.readMethod.m_OnOperationTagEnd != null)
                        this.readMethod.m_OnOperationTagEnd(Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]));
                }
            }
        }

        private void ProcessWriteTag(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else
            {
                int length = msgTran.AryData.Length;
                int nLen = Convert.ToInt32(msgTran.AryData[2]) - 4;
                if ((int)msgTran.AryData[length - 3] != 16)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[length - 3]);
                }
                else
                {
                    ++this.mOperationTagCount;
                    string str1 = CCommondMethod.ByteArrayToString(msgTran.AryData, 3, 2);
                    string str2 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5, nLen);
                    string str3 = CCommondMethod.ByteArrayToString(msgTran.AryData, 5 + nLen, 2);
                    string str4 = string.Empty;
                    byte num1 = (byte)(((int)msgTran.AryData[length - 2] & 3) + 1);
                    int num2 = Convert.ToInt32(msgTran.AryData[length - 1]);
                    RXOperationTag opTag = new RXOperationTag();
                    opTag.strPC = str1;
                    opTag.strCRC = str3;
                    opTag.strEPC = str2;
                    opTag.strData = str4;
                    opTag.nDataLen = msgTran.AryData.Length;
                    opTag.btAntId = num1;
                    opTag.nOperateCount = num2;
                    opTag.cmd = msgTran.Cmd;
                    if (this.readMethod.m_OnOperationTag != null)
                        this.readMethod.m_OnOperationTag(opTag);
                    if (this.mOperationTagCount == Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]))
                    {
                        this.mOperationTagCount = 0;
                        if (this.readMethod.m_OnOperationTagEnd != null)
                            this.readMethod.m_OnOperationTagEnd(Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]));
                    }
                }
            }
        }

        private void ProcessLockTag(MessageTran msgTran)
        {
            this.ProcessWriteTag(msgTran);
        }

        private void ProcessKillTag(MessageTran msgTran)
        {
            this.ProcessWriteTag(msgTran);
        }

        private void ProcessInventoryISO18000(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == (int)byte.MaxValue || this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (msgTran.AryData.Length == 9)
            {
                byte nAntID = msgTran.AryData[0];
                string strUID = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, 8);
                if (this.readMethod.m_OnInventory6BTag == null)
                    return;
                this.readMethod.m_OnInventory6BTag(nAntID, strUID);
            }
            else if (msgTran.AryData.Length == 2)
            {
                if (this.readMethod.m_OnInventory6BTagEnd == null)
                    return;
                this.readMethod.m_OnInventory6BTagEnd(Convert.ToInt32(msgTran.AryData[1]));
            }
            else if (this.readMethod.m_OnExeCMDStatus != null)
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
        }

        private void ProcessReadTagISO18000(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else
            {
                byte nAntID = msgTran.AryData[0];
                string strData = CCommondMethod.ByteArrayToString(msgTran.AryData, 1, msgTran.AryData.Length - 1);
                if (this.readMethod.m_OnRead6BTag != null)
                    this.readMethod.m_OnRead6BTag(nAntID, strData);
            }
        }

        private void ProcessWriteTagISO18000(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnWrite6BTag != null)
                this.readMethod.m_OnWrite6BTag(msgTran.AryData[0], msgTran.AryData[1]);
        }

        private void ProcessLockTagISO18000(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnLock6BTag != null)
                this.readMethod.m_OnLock6BTag(msgTran.AryData[0], msgTran.AryData[1]);
        }

        private void ProcessQueryISO18000(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (this.readMethod.m_OnExeCMDStatus == null)
                    return;
                this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[0]);
            }
            else if (this.readMethod.m_OnLockQuery6BTag != null)
                this.readMethod.m_OnLockQuery6BTag(msgTran.AryData[0], msgTran.AryData[1]);
        }

        private void ProcessTagMask(MessageTran msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if ((int)msgTran.AryData[0] == 16)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)16);
                }
                else if ((int)msgTran.AryData[1] == 65)
                {
                    if (this.readMethod.m_OnExeCMDStatus == null)
                        return;
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, msgTran.AryData[1]);
                }
                else if (this.readMethod.m_OnExeCMDStatus != null)
                    this.readMethod.m_OnExeCMDStatus(msgTran.Cmd, (byte)88);
            }
            else if (msgTran.AryData.Length > 7)
            {
                ++this.mMaskQuantity;
                MaskMap maskMap = new MaskMap(msgTran.AryData);
                this.m_curSetting.maskValues.Add(maskMap);
                if (this.mMaskQuantity == (int)maskMap.mMaskQuantity)
                {
                    this.mMaskQuantity = 0;
                    if (this.readMethod.m_RefreshSetting != null)
                        this.readMethod.m_RefreshSetting(this.m_curSetting);
                }
            }
        }
    }
}
