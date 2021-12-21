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
        /// Tag access key
        /// </summary>
        private const string AccessString = "50 30 43 4b";
        /// <summary>
        /// Byte format access code
        /// </summary>
        public static byte[] AccessCode => csCRC.StringToHexByte(AccessString);

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
        public const int TimeoutShort = 500;

        /// <summary>
        /// Long timeout for specific operation
        /// </summary>
        public const int Timeout = 1000;

        //Extra large wait time
        public const int TimeoutLong = 2000;

        /// <summary>
        /// 01-FF
        /// Samll value will cause multiple tags can't be detected
        /// Too big value will cause detection time increase
        /// About 500 ms, 5 times is tested OK
        /// </summary>
        public const byte InventoryTryCount = 0x05;
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
        public void InitCommand(byte CommandType,bool IsLoop=false)
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
            Console.WriteLine("Inventory EPC:" + tag.strEPC + $"({tag.mReadCount})");

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

            if (CurrentCommand.Type == CMD.WRITE_TAG)
            {
                if (operationTagCount == 1)
                {
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
            else if (CurrentCommand.Type == CMD.READ_TAG)
            {
                if (operationTagCount == 1)
                {
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
            Console.WriteLine("Operation Tag:" + tag.strEPC);
            Console.WriteLine("Operation Data:" + tag.strData);
            CurrentCommand.StrValue = tag.strData;
           
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

            if (!WaitForReply(Timeout))
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
            if (!WaitForReply(TimeoutLong))
            {
                Debug.WriteLine($"TryInventoryReal.Timeout:{TimeoutLong}");
                return -1;
            }

            //Get result
            List<RXInventoryTag> tempList;
            lock (DetectedTagsLock)
            {
                DetectedTags = CurrentCommand.Tags.ToList();
                tempList= CurrentCommand.Tags.ToList(); //Copy out for display  
            }

            Debug.WriteLine($"TryInventoryReal.Count:{tempList.Count}");

            return DetectedTags.Count;
        }


        /// <summary>
        /// Try to get real time tags
        /// </summary>
        /// <param name="iRecord">Number of times before stop operation</param>
        /// <returns></returns>
        public int TryInventoryReal2(int iRecord=5)
        {
            InitCommand(CMD.REAL_TIME_INVENTORY,true);
            InventoryReal(DeviceID, 0x01);

            Thread.Sleep(TimeoutLong); //Wait for result

            //Wait for 10 times reply
            while (CurrentCommand.ExecACC< iRecord)
            {
                //Check timeout
                if (CurrentCommand.SpanMs>TimeoutLong)
                {
                    //Time out
                    Debug.WriteLine("TryInventoryReal2 time out");
                    return -1;
                }
            }

            //Show search time
            CurrentCommand.IsLoop = false; //Close loop operation
            Debug.WriteLine($"TryInventoryReal2:Time:{TimeoutLong}");

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

            bool bResult = WaitForReply(TimeoutShort);

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

            if (WaitForReply(TimeoutShort))
            {
                CurrentCommand.StrValue = Settings.mMatchEpcValue;
                Debug.WriteLine("Matched EPC:"+ CurrentCommand.StrValue);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool TryReadTag(TagDataType ReadType, ref string sResult)
        {
            //Init variables
            byte DataCount = 0x02;
            byte DataAdd = 0x00;

            //Get read count
            switch (ReadType)
            {
                case TagDataType.Reserved:
                    DataCount = 0x04; //8 bytes
                    break;
                case TagDataType.EPC:
                    DataCount = 0x06; //12 bytes
                    DataAdd = 0x02; //Start from number 4 byte
                    break;
                case TagDataType.TID:
                    break;
                case TagDataType.User:
                    DataCount = (byte)20; //20 words 40bytes
                    break;
                default:
                    break;
            }

            //try to read data
            CurrentCommand.Init(CMD.READ_TAG); //init command
            ReadTag(DeviceID, (byte)ReadType, DataAdd, DataCount, AccessCode);

            if (!WaitForReply(Timeout))
            {
                return false;
            }


            //Pass all steps
            sResult = CurrentCommand.StrValue;
            return true;
        }


        /// <summary>
        /// Try to write data into tag
        /// </summary>
        /// <param name="writeType"></param>
        /// <param name="Data"></param>
        /// <returns></returns>
        public bool TryWriteTag(TagDataType writeType, byte[] Data)
        {
            //Init variables
            byte[] writeData = null; //Data to be write
            byte[] writeDataEnd = null;//Second half of the data, used for long user data 32<x<=64 only
            byte bStart = 0x00; //Write start address

            //Null avoid
            if (Data == null) return false;

            //Check length
            if (Data.Length < 1)
            {
                return false;
            }
            //Make it even
            else if (Data.Length % 2 == 1)
            {
                writeData = new byte[Data.Length + 1];
                Data.CopyTo(writeData, 0);
                writeData[writeData.Length - 1] = 0x00; //Add last byte
            }
            else
            {
                writeData = Data;
            }



            //Set parameters by data type
            switch (writeType)
            {
                case TagDataType.Reserved:
                    break;

                case TagDataType.EPC:
                    //Length limit
                    if (writeData.Length > 12)
                    {
                        Debug.WriteLine("TryWriteTag:EPC length error.");
                        return false;
                    }
                    bStart = 0x02;
                    break;

                case TagDataType.TID:
                    break;

                case TagDataType.User:
                    if (!PrepareUserData(writeData, writeDataEnd))
                    {
                        Debug.WriteLine("TryWriteTag:Process user data error.");
                        return false;
                    }
                    break;
            }


            //Set command
            CurrentCommand.Init(CMD.WRITE_TAG);

            //Write first part
            WriteTag(DeviceID, AccessCode, (byte)writeType, bStart, (byte)(writeData.Length / 2), writeData);

            //Wait for reply
            if (!WaitForReply(TimeoutShort))
            {
                Debug.WriteLine($"TryWriteTag:Timeout:{TimeoutShort}");
                return false;
            }

            //Check if second half of data exist
            if (writeDataEnd == null) return true;

            //Reset command
            CurrentCommand.Init(CMD.WRITE_TAG);

            //Send second part
            //start from 32(byte,16word), length 32byte(16word)
            WriteTag(DeviceID, AccessCode, (byte)writeType, (byte)(16), (byte)16, writeDataEnd);

            //Wait for reply
            if (!WaitForReply(TimeoutShort))
            {
                Debug.WriteLine($"TryWriteTag:Timeout Second:{TimeoutShort}");
                return false;
            }

            //Pass all steps
            return true;

        }

        /// <summary>
        /// Get two parts of user data of total 64 bytes
        /// </summary>
        /// <param name="UserDataFront">Unprocessed data, output will be first 32 bytes of data</param>
        /// <param name="UserDataEnd"></param>
        private bool PrepareUserData(byte[] UserDataFront, byte[] UserDataEnd)
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
                UserDataEnd = new byte[32];
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
