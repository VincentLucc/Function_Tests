using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Reader;

namespace UHFSDKTest
{
    public class csReader : ReaderMethod
    {
        public string PortNum { get; set; }
        public bool IsConnected => iSerialPort.IsOpen;  //Check port open


        public static byte DeviceID = 0xFF; //Default device ID

        /// <summary>
        /// Byte format access code
        /// </summary>
        //public static byte[] AccessCode => csCRC.StringToHexByte("00 00 00 00");

        public static byte[] AccessCode => csCRC.StringToHexByte("50 30 43 4b");

        public static byte[] AccessCodeEmpty => csCRC.StringToHexByte("00 00 00 00");

        /// <summary>
        /// Current command operation command
        /// </summary>
        public ReaderCommand CurrentCommand { get; set; }

        public ReaderSetting Settings { get; set; }

        /// <summary>
        /// Currently detected tags
        /// </summary>
        public List<RXInventoryTag> DetectedTags { get; set; }
        public object DetectedTagsLock => new object();

        /// <summary>
        /// Default timeout for command
        /// </summary>
        public const int TimeoutMS = 1000;

        /// <summary>
        /// Extra large wait time
        /// </summary>
        public const int TimeoutLongMS = 2000;

        /// <summary>
        /// 01-FF
        /// Samll value will cause multiple tags can't be detected
        /// Too big value will cause detection time increase
        /// About 500 ms, 5 times is tested OK
        /// </summary>
        public const byte InventoryTryCount = 0x08;
        public csReader()
        {
            CurrentCommand = new ReaderCommand();
            DetectedTags = new List<RXInventoryTag>();
            Settings = m_Processor.m_curSetting;//Setting alias
            m_OnExeCMDStatus += onExeCMDStatus;
            m_OnInventoryTag += onInventoryTag; //Tag read out
            m_OnInventoryTagEnd += onInventoryTagEnd;
            m_OnOperationTag += onOperationTag; //When tag read, get tag data
            m_OnOperationTagEnd += onOperationTagEnd;
       
        }




        public void InitReaderDevice()
        {
            //Set device to be quite
            csStatic.RFIDReader.SetBeeperMode(DeviceID, 0x00);
        }

        /// <summary>
        /// Init current command, prepare to store reply data
        /// </summary>
        /// <param name="CommandType"></param>
        public void InitCommand(byte CommandType, bool IsLoop = false)
        {
            CurrentCommand.Init(CommandType, IsLoop);
        }


        void onExeCMDStatus(byte cmd, byte status)
        {
            //Show result
            Debug.WriteLine("CMD execute:" + CMD.format(cmd) + "\r\nStatus code:" + ERROR.format(status));

            //get general command result
            if (cmd == CurrentCommand.Type)
            {
                CurrentCommand.IsReplied = true;
                CurrentCommand.ErrorCode = status;
            }
            else
            {
                Debug.WriteLine("csReader.onExeCMDStatus:Command type mis-match.");
                return;
            }

            CommandResponseProcess(cmd, status);
        }

        void onInventoryTag(RXInventoryTag tag)
        {
            Debug.WriteLine("Inventory EPC:" + tag.strEPC + $"({tag.mReadCount})");

            //

            if (CurrentCommand.Tags.Where(t => t.strEPC == tag.strEPC).Count() == 0)
            {
                CurrentCommand.Tags.Add(tag);
            }

        }


        void onInventoryTagEnd(RXInventoryTagEnd tagEnd)
        {
            Debug.WriteLine($"Tag Inventory finish:{tagEnd.mTagCount}:" + CurrentCommand.SpanMs);

            //Check command type
            if (tagEnd.cmd != CurrentCommand.Type) return;

            //Loop process
            switch (tagEnd.cmd)
            {
                case CMD.INVENTORY:
                    //Save Tagcount
                    CurrentCommand.IsReplied = true;
                    CurrentCommand.IntValue = tagEnd.mTagCount; //Store Tag count
                    break;

                case CMD.REAL_TIME_INVENTORY:
                    if (CurrentCommand.IsLoop)
                    {
                        CurrentCommand.ExecACC += 1;
                        InventoryReal(DeviceID, (byte)0x01);
                        //Tag count always zero in real time
                        Debug.WriteLine("Realtime end");
                    }
                    else
                    {
                        CurrentCommand.IsReplied = true;
                    }
                    break;
                default:
                    break;
            }


        }

        void onOperationTagEnd(int operationTagCount)
        {
            Debug.WriteLine($"Operation Tag End:{CurrentCommand.SpanMs}:" + operationTagCount);

            //Tag write OK triggers onOperationTagEnd
            //Tag write error will trigger onExeCMDStatus instead
            if (CurrentCommand.Type == CMD.WRITE_TAG)
            {
                if (operationTagCount == 1)
                {
                    CurrentCommand.ErrorCode = ERROR.SUCCESS; //Set as sucess
                    CurrentCommand.IsReplied = true;
                }
                else if (operationTagCount < 1)
                {
                    Debug.WriteLine($"Operation Fail!");
                }
                else if (operationTagCount > 2)
                {
                    Debug.WriteLine($"Operation Fail! Multiple Tags Written.");
                }
            }
            //Tag read OK triggers onOperationTagEnd
            //Tag read error will trigger onExeCMDStatus instead
            else if (CurrentCommand.Type == CMD.READ_TAG)
            {
                if (operationTagCount == 1)
                {
                    CurrentCommand.ErrorCode = ERROR.SUCCESS; //Set as sucess
                    CurrentCommand.IsReplied = true;
                }
                else
                {
                    Debug.WriteLine($"Operation Fail!");
                }
            }


        }


        void onOperationTag(RXOperationTag tag)
        {
            Debug.WriteLine("Operation Tag:" + tag.strEPC + ", Data:" + tag.strData);
            CurrentCommand.StrValue = tag.strData;

            //Lock tag operation success only trigger this event
            if (CurrentCommand.Type==CMD.LOCK_TAG)
            {        
                CurrentCommand.ErrorCode = ERROR.SUCCESS;
                CurrentCommand.IsReplied = true;
                Debug.WriteLine("Tag Lock Operation Success");
            }
        }

        /// <summary>
        /// Response based on command type
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="status"></param>
        private void CommandResponseProcess(byte cmd, byte status)
        {
            switch (cmd)
            {
                case CMD.SET_OUTPUT_POWER:
                case CMD.GET_OUTPUT_POWER:
                    //Show current power
                    if (status == ERROR.SUCCESS)
                    {
                        var power = Settings.btOutputPower;
                        var powers = Settings.btOutputPowers;
                        Debug.WriteLine($"Current power:{power}");

                        //Show multi-power setting
                        if (powers == null) break;
                        for (int i = 0; i < powers.Length; i++)
                        {
                            Debug.WriteLine($"Power {i + 1}:{powers[i]}");
                        }
                    }
                    break;
                case CMD.SET_BEEPER_MODE:
                    Debug.WriteLine($"Beep:{Settings.btBeeperMode}");
                    break;
                default:
                    break;
            }
        }


        public bool TrySetPower(byte bPower)
        {
            CurrentCommand.Init(CMD.SET_OUTPUT_POWER);
            SetOutputPower(DeviceID, bPower);

            if (!WaitForReply(TimeoutMS))
            {
                return false;
            }

            //Pass all steps
            return true;
        }

        /// <summary>
        /// Get real time tag counts
        /// </summary>
        /// <returns></returns>
        public int TryInventoryReal()
        {
            CurrentCommand.Init(CMD.REAL_TIME_INVENTORY);
            InventoryReal(DeviceID, InventoryTryCount);

            //Wait for result
            if (!WaitForReply(TimeoutLongMS))
            {
                Debug.WriteLine($"TryInventoryReal.Timeout:{TimeoutLongMS}");
                return -1;
            }

            //Get result
            List<RXInventoryTag> tempList;
            lock (DetectedTagsLock)
            {
                DetectedTags = CurrentCommand.Tags.ToList();
                tempList = CurrentCommand.Tags.ToList(); //Copy out for display  
            }

            Debug.WriteLine($"TryInventoryReal.Count:{tempList.Count}");

            return DetectedTags.Count;
        }


        /// <summary>
        /// Try to get real time tags
        /// </summary>
        /// <param name="iRecord">Number of times before stop operation</param>
        /// <returns></returns>
        public int TryInventoryReal2(int iRecord = 5)
        {
            InitCommand(CMD.REAL_TIME_INVENTORY, true);
            InventoryReal(DeviceID, 0x01);

            Thread.Sleep(TimeoutLongMS); //Wait for result

            //Wait for 10 times reply
            while (CurrentCommand.ExecACC < iRecord)
            {
                //Check timeout
                if (CurrentCommand.SpanMs > TimeoutLongMS)
                {
                    //Time out
                    Debug.WriteLine("TryInventoryReal2 time out");
                    return -1;
                }
            }

            //Show search time
            CurrentCommand.IsLoop = false; //Close loop operation
            Debug.WriteLine($"TryInventoryReal2:Time:{TimeoutLongMS}");

            //Get result
            lock (DetectedTagsLock)
            {
                DetectedTags = CurrentCommand.Tags.ToList();
            }

            return DetectedTags.Count;
        }

        /// <summary>
        /// Try set operation tag
        /// </summary>
        public bool TrySetOperationTag()
        {
            //Get first tag
            if (DetectedTags.Count < 1) return false;

            //Get  tag
            var tag = DetectedTags[0];
            var bEpc = csCRC.StringToHexByte(tag.strEPC);

            //Set current command
            CurrentCommand.Init(CMD.SET_ACCESS_EPC_MATCH);

            //0x00, set
            //0x01,clear
            SetAccessEpcMatch(DeviceID, 0x00, (byte)bEpc.Length, bEpc);

            bool bResult = WaitForReply(TimeoutMS);

            return bResult;
        }

        /// <summary>
        /// Try set operation tag
        /// </summary>
        public bool TryGetOperationTag()
        {
            //Set current command
            CurrentCommand.Init(CMD.GET_ACCESS_EPC_MATCH);

            //0x00, set
            //0x01,clear
            GetAccessEpcMatch(DeviceID);

            if (WaitForReply(TimeoutMS))
            {
                CurrentCommand.StrValue = Settings.mMatchEpcValue;
                Debug.WriteLine("Matched EPC:" + CurrentCommand.StrValue);
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Try to read tag based on tag data type
        /// </summary>
        /// <param name="ReadType"></param>
        /// <param name="sResult"></param>
        /// <returns></returns>
        /// <summary>
        /// Try to read tag based on tag data type
        /// </summary>
        /// <param name="ReadType"></param>
        /// <param name="sResult"></param>
        /// <returns></returns>
        public GeneralResult TryReadTag(TagDataType ReadType, int iRetry = 1)
        {
            //Init variables
            var result = new GeneralResult();

            //Get read count
            switch (ReadType)
            {
                case TagDataType.Reserved:
                    //Read 8 bytes of data
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.Reserved, 0x00, 0x04))
                        {
                            result.StrValue = CurrentCommand.StrValue;
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                case TagDataType.EPC:
                    //Read 12 bytes of data, Start from number 4 byte
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.EPC, 0x02, 0x06))
                        {
                            result.StrValue = CurrentCommand.StrValue;
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                case TagDataType.TID:
                    //Read 24 bytes of data
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.TID, 0x00, (byte)12))
                        {
                            result.StrValue = CurrentCommand.StrValue.Trim();
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                case TagDataType.User:
                    //20 words 40bytes
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.User, 0x00, (byte)20))
                        {
                            result.StrValue = CurrentCommand.StrValue;
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                case TagDataType.AccessCode:
                    //Read 4 bytes of data
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.Reserved, 0x02, 0x02))
                        {
                            result.StrValue = CurrentCommand.StrValue;
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                case TagDataType.OdooEncryptedData:
                    //Read 4 bytes of reserve data, 0-3 bytes
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.Reserved, 0x00, 0x02))
                        {
                            result.StrValue = CurrentCommand.StrValue;
                            break;
                        }
                    }
                    //Read 64 bytes of user data
                    for (int i = 0; i < iRetry; i++)
                    {
                        if (ReadTagAndCheckReply((byte)TagDataType.User, 0x00, (byte)32))
                        {
                            result.StrValue += CurrentCommand.StrValue;
                            result.StrValue = RemoveEnding(result.StrValue);
                            result.IsSuccess = true;
                            break;
                        }
                    }
                    break;

                default:
                    return result; //Not implemented
            }

            //Pass all steps
            return result;
        }


        /// <summary>
        /// remove "00 ending"
        /// </summary>
        /// <param name="sData"></param>
        private string RemoveEnding(string sData)
        {
            if (sData == null) return null;
            sData = sData.Trim();
            while (sData.Contains(" 00"))
            {
                sData = sData.Substring(0, sData.Length - 3);
            }
            return sData;
        }

        /// <summary>
        /// Read tag and check for reply
        /// </summary>
        /// <param name="ReadType"></param>
        /// <param name="DataAdd"></param>
        /// <param name="DataCount"></param>
        /// <returns></returns>
        private bool ReadTagAndCheckReply(byte ReadType, byte DataAdd, byte DataCount)
        {
            //try to read data
            CurrentCommand.Init(CMD.READ_TAG); //init command
            ReadTag(DeviceID, ReadType, DataAdd, DataCount, AccessCode);

            //Tag read OK triggers onOperationTagEnd
            //Tag read error will trigger onExeCMDStatus instead
            if (!WaitForReply(TimeoutMS))
            {
                return false;
            }

            //Check success
            if (!CurrentCommand.IsSuccess)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Try to write data into tag
        /// </summary>
        /// <param name="writeType"></param>
        /// <param name="Data"></param>
        /// <param name="iRetry">Retry count</param>
        /// <returns></returns>
        public bool TryWriteTag(TagDataType writeType, byte[] Data,int iRetry=1)
        {
            //Check length and make data even as a word (2 bytes) 
            byte[] writeData = PrepareInputData(Data);

            //Check result, access code data can be empty, will use default value
            if (writeType!= TagDataType.AccessCode)
            {
                if (writeData == null) return false;
            }         

            //Write data based on type
            switch (writeType)
            {
                case TagDataType.Reserved:
                    //Write 12 bytes reserve area data
                    if (!WriteReserveData(writeData, iRetry)) return false;
                    break;

                case TagDataType.EPC:
                    //Write 8 bytes EPC area data
                    if (!WriteEPCData(writeData, iRetry)) return false;
                    break;


                case TagDataType.TID:
                    return false; //Not implemented

                case TagDataType.User:
                    //Write 64 bytes user area data
                    if (!WriteUserData(writeData, iRetry)) return false;
                    break;

                case TagDataType.AccessCode:
                    //Write 4 bytes access code into reserve area address 4-8 byte
                    if (!WriteAccessCode(iRetry)) return false;
                    break;

                case TagDataType.OdooEncryptedData:
                    //Write Odoo encrypted data into reserve and user area
                    if (!WriteOdooEncryptedData(writeData, iRetry)) return false;
                    break;

                default:
                    return false; //Not implemented
            }

            //Pass all steps
            return true;
        }

        /// <summary>
        /// Write 4 bytes reserve area data
        /// Reserve area has 8 bytes, make sure only write first 4 bytes
        /// </summary>
        /// <param name="bReserve"></param>
        /// <returns></returns>
        private bool WriteReserveData(byte[] bReserve,int iRetry=1)
        {
            //Length limit
            if (bReserve.Length != 4)
            {
                Debug.WriteLine($"WriteReserveData:length error.{bReserve.Length}");
                return false;
            }

            //8 bytes
            if (!WriteTagAndCheckReply((byte)TagDataType.Reserved, 0x00, 0x02, bReserve, iRetry))
            {
                Debug.WriteLine($"WriteReserveData:Timeout Second:{TimeoutMS}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Write 12 bytes EPC area data
        /// </summary>
        /// <param name="bReserve"></param>
        /// <returns></returns>
        private bool WriteEPCData(byte[] bEPC,int iRetry=1)
        {
            //Length limit
            if (bEPC.Length > 12)
            {
                Debug.WriteLine("WriteEPCData:EPC length error.");
                return false;
            }

            //12 bytes, start from 4th byte=0x02 word
            if (!WriteTagAndCheckReply((byte)TagDataType.EPC, 0x02, 0x06, bEPC, iRetry))
            {
                Debug.WriteLine($"WriteEPCData:Timeout Second:{TimeoutMS}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Write user area dat, fill full 64 bytes
        /// </summary>
        /// <param name="bEPC"></param>
        /// <returns></returns>
        private bool WriteUserData(byte[] bUser, int iRetry = 1)
        {
            //Prepare two parts of data in user section since certain tag user data area can only write 32 bytes once
            byte[] userDataEnd = new byte[32];
            if (!PrepareUserData(ref bUser,ref userDataEnd))
            {
                Debug.WriteLine("TryWriteTag:Process user data error.");
                return false;
            }

            //Write first part of data
            Debug.WriteLine("WriteUserData.Part 1:");
            if (!WriteTagAndCheckReply((byte)TagDataType.User, 0x00, (byte)16, bUser,iRetry))
            {
                Debug.WriteLine($"TryWriteTag:Timeout Second:{TimeoutMS}");
                return false;
            }

            //Write second part of data
            Debug.WriteLine("WriteUserData.Part 2:");
            if (!WriteTagAndCheckReply((byte)TagDataType.User, (byte)(16), (byte)16, userDataEnd,iRetry))
            {
                Debug.WriteLine($"TryWriteTag:Timeout Second:{TimeoutMS}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Write Odoo encrypted data into reserve and user area
        /// 4 bytes in reserve + 40 bytes in user area
        /// </summary>
        /// <param name="bOdoo"></param>
        private bool WriteOdooEncryptedData(byte[] bOdoo,int iRetry=1)
        {
            //prepare data 
            byte[] bReserve = new byte[4]; //First 4 bytes of the data
            byte[] bUser1 = new byte[32]; //1st half user data
            byte[] bUser2 = new byte[32]; //2nd half user data

            //Set data by length
            if (bOdoo.Length < 5)
            {
                Debug.WriteLine($"OdooEncryptedData.Length mis-match ({bOdoo.Length})");
                return false;
            }
            else if (bOdoo.Length <= (32 + 4))
            {
                Array.Copy(bOdoo, 0, bReserve, 0, 4); //Reserve area
                Array.Copy(bOdoo, 4, bUser1, 0, bOdoo.Length - 4); //User area 1
            }
            else if (bOdoo.Length <= (64 + 4))
            {
                Array.Copy(bOdoo, 0, bReserve, 0, 4); //Reserve area
                Array.Copy(bOdoo, 4, bUser1, 0, 32); //User area 1
                Array.Copy(bOdoo, 4 + 32, bUser2, 0, bOdoo.Length - -32 - 4); //User area 2
            }
            else
            {
                //Data length >64+4
                Debug.WriteLine($"OdooEncryptedData.Length mis-match ({bOdoo.Length})");
                return false;
            }

            //Start to write data
            //Write reserve
            if (!WriteTagAndCheckReply((byte)TagDataType.Reserved, 0x00, 0x02, bReserve, iRetry))
            {
                Debug.WriteLine($"OdooEncryptedData.Reserved:Timeout Second:{TimeoutMS}");
                return false;
            }

            //Write user part 1
            if (!WriteTagAndCheckReply((byte)TagDataType.User, 0x00, (byte)16, bUser1, iRetry))
            {
                Debug.WriteLine($"OdooEncryptedData.User1:Timeout Second:{TimeoutMS}");
                return false;
            }

            //Write user part 2
            if (!WriteTagAndCheckReply((byte)TagDataType.User, (byte)(16), (byte)16, bUser2, iRetry))
            {
                Debug.WriteLine($"OdooEncryptedData.User2:Timeout Second:{TimeoutMS}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Write 4 bytes access code into reserve area address 4-8 byte
        /// Use empty password to write pre-defined 4 bytes access code
        /// </summary>
        private bool WriteAccessCode(int iRetry=1)
        {
            //Write AccessCode, byte 4-7, word 2-3
            for (int i = 0; i < iRetry; i++)
            {
                //Reset command
                CurrentCommand.Init(CMD.WRITE_TAG);

                //Use empty pass word to write password
                WriteTag(DeviceID, AccessCodeEmpty, (byte)TagDataType.Reserved, 0x02, 0x02, AccessCode);

                //Wait for reply
                if (WaitForReply(TimeoutMS))
                {
                    //Check success
                    if (CurrentCommand.IsSuccess) return true;
                }

                //Show retry 
                if (i > 0) Debug.Write($"WriteAccessCode.Fail.TryCount:{i}");
            }

            //No success
            return false;
        }


        /// <summary>
        /// Lock tag use pre-set password
        /// </summary>
        /// <returns></returns>
        public bool TryLockTag(int iRetry=1)
        {
            for (int i = 0; i < iRetry; i++)
            {
                //Reset command
                CurrentCommand.Init(CMD.LOCK_TAG);

                //Set password
                LockTag(DeviceID, AccessCode, 0x04, 0x01);

                //wait response
                if (!WaitForReply(TimeoutMS))
                {
                    Debug.WriteLine($"TryLockTag.Timeout,Count:{i+1}");
                    continue;
                }

                //Check result
                if (CurrentCommand.IsSuccess)
                {
                    return true;
                }

                //Fail
                Debug.WriteLine($"TryLockTag.Fail,Count:{i + 1}");
            }

            //Fail when tried all times
            return false;

        }

        /// <summary>
        /// Lock tag use pre-set password
        /// </summary>
        /// <returns></returns>
        public bool TryUnLockTag(int iRetry=1)
        {
            for (int i = 0; i < iRetry; i++)
            {
                //Reset command
                CurrentCommand.Init(CMD.LOCK_TAG);

                //Set password
                LockTag(DeviceID, AccessCode, 0x04, 0x00);

                //wait response
                if (!WaitForReply(TimeoutMS))
                {
                    Debug.WriteLine($"TryLockTag.Timeout,retry:{i+1}");
                    continue;
                }

                //Check result
                if (CurrentCommand.IsSuccess) return true;

                Debug.WriteLine($"TryLockTag.Fail,retry:{i+1}");
            }

            //Fail to operate
            return false;
        }

        /// <summary>
        /// Check length and make data even as a word (2 bytes) 
        /// </summary>
        /// <param name="bInput"></param>
        /// <returns></returns>
        private byte[] PrepareInputData(byte[] bInput)
        {
            //Null avoid
            if (bInput == null) return null;

            //Check length and make data even as a word (2 bytes) 
            if (bInput.Length < 1)
            {
                return null;
            }
            //Make it even
            else if (bInput.Length % 2 == 1)
            {
                byte[] bResult = new byte[bInput.Length + 1];
                bInput.CopyTo(bResult, 0); //Last byte=0x00
                return bResult;
            }
            else
            {
                return bInput;
            }
        }

        /// <summary>
        /// Write data to tag and get replay
        /// </summary>
        /// <param name="writeType"></param>
        /// <param name="startAddress"></param>
        /// <param name="writeLength"></param>
        /// <param name="writeData"></param>
        /// <param name="iRetry">Retry count</param>
        /// <returns></returns>
        private bool WriteTagAndCheckReply(byte writeType, byte startAddress, byte writeLength, byte[] writeData,int iRetry=1)
        {
            //Null verification
            if (writeData == null) return false;

            //Try n times
            for (int i = 0; i < iRetry; i++)
            {
                //Reset command
                CurrentCommand.Init(CMD.WRITE_TAG);

                //Send second command
                WriteTag(DeviceID, AccessCode, (byte)writeType, startAddress, writeLength, writeData);

                //Wait for reply
                if (WaitForReply(TimeoutMS))
                {
                    //Check success
                    if (CurrentCommand.IsSuccess) return true;
                }

                //Show retry 
                if (i>0) Debug.Write($"WriteTagAndCheckReply.Fail.TryCount:{i}");
            }
          
            //No success operation
            return false;
        }

        /// <summary>
        /// Get two parts of user data of total 64 bytes
        /// </summary>
        /// <param name="UserDataFront">Unprocessed data, output will be first 32 bytes of data</param>
        /// <param name="UserDataEnd"></param>
        private bool PrepareUserData(ref byte[] UserDataFront,ref byte[] UserDataEnd)
        {
            //Check if user data is type
            if (UserDataFront.Length > 32)
            {
                //Max limit
                if (UserDataFront.Length > 64)
                {
                    Debug.WriteLine($"TryWriteTag:User data size > 64, {UserDataFront.Length}");
                    return false;
                }

                //Get second part of data
                Array.Copy(UserDataFront, 32, UserDataEnd, 0, UserDataFront.Length - 32);

                //Get first part of data
                var temp = new byte[32];
                Array.Copy(UserDataFront, 0, temp, 0, 32);
                UserDataFront = temp;
            }
            else
            {
                byte[] temp = new byte[32];
                UserDataFront.CopyTo(temp, 0);
                UserDataFront = temp;//Make sure all 32 bytes fill!
                UserDataEnd = new byte[32]; //Create an empty 32 byte block to clear anything behind
            }

            //Pass all steps
            return true;
        }


        /// <summary>
        /// Try open port
        /// </summary>
        public bool OpenPort(string PortName)
        {
            int i = OpenCom(PortName, 115200, out string sError);

            if (i == 0)
            {
                Debug.WriteLine($"Port {PortName} is open.");
                return true;
            }
            else
            {
                Debug.WriteLine("Error in open port.\r\n" + sError);
                return false;
            }
        }


        public bool WaitForReply(int iTimeout = 0, bool IsDoEvents = false)
        {
            //Init variables
            Stopwatch watch = new Stopwatch();
            watch.Start();


            //Wait for flag
            while (!CurrentCommand.IsReplied)
            {
                Thread.Sleep(10);
                if (IsDoEvents) Application.DoEvents();
                if (iTimeout > 0)
                {
                    if (watch.ElapsedMilliseconds > iTimeout)
                    {
                        watch.Stop();
                        return false;
                    }
                }

            }

            //Signal received
            watch.Stop();
            return true;
        }

        public async Task<bool> WaitForReplyAsync(bool bFlag, int iTimeout = 0)
        {
            return await Task.Run(() => WaitForReply(iTimeout, false));
        }

    }
}
