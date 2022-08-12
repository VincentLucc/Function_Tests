using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperationBlock;

namespace SerialPort_Ink
{
    class csInkSystemColor : IDisposable
    {
        /// <summary>
        /// Default serial port connection
        /// </summary>
        public SerialPort Port { get; set; }
        public bool IsConnected { get { return Port.IsOpen; } } //Is connected

        /// <summary>
        /// Message queue for sending messages
        /// </summary>
        public ConcurrentQueue<string> Messages2Send { get; set; }
        /// <summary>
        /// Received message buffer used for display only
        /// </summary>
        public List<string> ComLog = new List<string>();

        public object lockComLog = new object(); //BuilderReceivedData lock

        public int ComLogMaxSize { set; get; } //Set the max buffer size

        private Task tSend; //Sending thread

        /// <summary>
        /// During receiving process
        /// </summary>
        public bool IsReceiving { get; set; }
        public bool EnableDispose { get; set; }

        /// <summary>
        /// Temporarily block the thread
        /// </summary>
        private LoopBlocker SendBlocker { get; set; }

        /// <summary>
        /// Network start from 1 which matches a-z
        /// </summary>
        private static List<string> NetworkName = new List<string> { "", "A", "B", "C", "D", "E", "F", "G", "H" };
        /// <summary>
        /// Communication flag to avoid communication conflict.
        /// </summary>
        private bool IsBusy { get; set; }

        /// <summary>
        /// Send and received data 
        /// </summary>
        public InkSystemDataBuffer DataBuffer { get; set; }
        public InkSystemCommand CurrentCommand { get; set; }

        /// <summary>
        /// Default communication timeout
        /// </summary>
        public int TimeoutMS { get; set; }

        /// <summary>
        /// Store devices in the network
        /// </summary>
        public List<InkDevice> Devices { get; set; }

        /// <summary>
        /// Current config
        /// </summary>
        public csConfig SysConfig { get; set; }
        public csInkSystemColor(csConfig config)
        {
            //Init variables
            SysConfig = config;
            SendBlocker = new LoopBlocker();
            Port = new SerialPort();
            ComLogMaxSize = 10000; //Max size of log info
            ApplyPortSettings(config);
            Messages2Send = new ConcurrentQueue<string>();
            DataBuffer = new InkSystemDataBuffer();
            TimeoutMS = 2000;
            CurrentCommand = new InkSystemCommand();
            Devices = new List<InkDevice>();

            //Start sending thread.
            tSend = new Task(ProcessSerialSend);
            tSend.Start();
        }

        public void Dispose()
        {
            EnableDispose = true;
        }

        public bool Connect(csConfig config)
        {
            SysConfig = config;

            //Try to connect
            if (!IsConnected)
            {
                try
                {
                    ApplyPortSettings(config);//Make sure set values while port is not connected
                    SendBlocker.StopBlock();//Make sure sending thread is alive
                    Port.Open();

                    //Must set after connected
                    if (config.Port.EnableFlowControl)
                    {
                        Port.DtrEnable = true;
                        Port.RtsEnable = true;
                    }

                    Port.DataReceived -= Port_DataReceived;
                    Port.DataReceived += Port_DataReceived;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Connect:\r\n" + ex.Message);
                    AppendComLog(csPublic.TimeString + ": Fail to connect.\r\n");
                    return false;
                }
            }

            //Check open status again
            if (!IsConnected) return false;

            //Pass all steps
            AppendComLog(csPublic.TimeString + ":Connected.\r\n");
            return true;
        }

        //Close in different thread
        public async Task Disconnect()
        {
            if (!IsConnected)
            {
                Debug.WriteLine("Serial Port is not connected.");
                return;
            }

            try
            {
                //Stop sending operation
                if (tSend != null && (!tSend.IsCompleted))
                {
                    await SendBlocker.BlockAndWaitAsync();
                }

                Debug.WriteLine("Serial Port is closing.");
                Port.Close();
                Debug.WriteLine("Serial Port is closed.");
                AppendComLog(csPublic.TimeString + ":Port closed.\r\n");
            }
            catch (Exception e)
            {
                Debug.WriteLine("Method:Disconnect\r\n" + e.Message);
            }

        }

        private void ApplyPortSettings(csConfig config)
        {
            //Check empty port
            if (string.IsNullOrWhiteSpace(config.Port.PortName))
            {
                Port.PortName = "ComEmpty"; //Fake com name
            }
            else
            {
                Port.PortName = config.Port.PortName;
            }

            Port.BaudRate = config.Port.BaudRate;
            Port.DataBits = config.Port.DataBits;
            Port.StopBits = config.Port.StopBits;
            Port.Parity = config.Port.Parity;

            if (config.Port.EnableFlowControl)
            {
                Port.Handshake = Handshake.XOnXOff;
            }
            else
            {
                Port.Handshake = Handshake.None;
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Receiving status
            IsReceiving = true;


            //In case port closed by user while transfer
            if (!Port.IsOpen)
            {
                IsReceiving = false; //Receiving status
                return;
            }

            //Init variables
            List<byte> ResultList = new List<byte>(); //save received message
            string sData = ""; //string format data info

            //Read data
            try
            {
                //Read multiple times until meet empty gap
                while (Port.BytesToRead > 0)
                {
                    byte[] buffer = new byte[Port.BytesToRead]; //define a buffer
                    Port.Read(buffer, 0, Port.BytesToRead); //read data to buffer
                    ResultList.AddRange(buffer); //Add buffer to result

                    //Auto break when size too long
                    if (ResultList.Count > 10000)
                    {
                        break;
                    }

                    //This is needed to receive full message
                    //Adjust this value for specific device
                    // 15ms is tested to be threshold of the muscle motor, use 20ms to gave more overhead.
                    Thread.Sleep(20);  //Wait to see if more data is on the way
                }
            }
            catch (Exception e1)
            {
                Debug.WriteLine(csPublic.TimeString + "Port_DataReceived:\r\n" + e1.Message);
                IsReceiving = false; //Receiving status
                return; //Do not proceed while error occurs
            }

            //Data processing
            try
            {
                //Get all received data result
                byte[] byteData = ResultList.ToArray();

                //Fetch data and store to buffer
                GetDataString(byteData, ref sData);

                //Seperate to command list
                string[] sDataGroup = sData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                //Process Data
                InspectData(sDataGroup);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Port_DataReceived.DataProcessing:\r\n" + ex.Message);
            }


            //Receiving status
            IsReceiving = false;
        }

        /// <summary>
        /// Display Receive Data In Console
        /// </summary>
        private void GetDataString(byte[] byteData, ref string sData)
        {
            //Get Data
            if (SysConfig.ReceiveFormat == SerialDataType.HEX)
            {
                sData = BitConverter.ToString(byteData).Replace("-", " ");
            }
            else
            {
                sData = Encoding.ASCII.GetString(byteData);
            }

            //debug info
            string sDebug = $"{csPublic.TimeString}:Received:{sData}";
            Debug.WriteLine(sDebug);
            AppendComLog(sDebug);
        }

        /// <summary>
        /// Add log messages to the log buffer
        /// </summary>
        /// <param name="sMessage"></param>
        public void AppendComLog(string sMessage)
        {
            //Add to received data buffer
            lock (lockComLog)
            {
                //Update messages collection for form view to use
                ComLog.Add(sMessage);

                //Limit builder size
                while (ComLog.Count > ComLogMaxSize)
                {
                    //Get reduce amount
                    int ReduceAmount = ComLogMaxSize / 10;

                    //Remove fisrt 5000 data
                    ComLog.RemoveRange(0, ReduceAmount);
                }
            }
        }

        /// <summary>
        /// Process received data
        /// </summary>
        /// <param name="DataList"></param>
        private void InspectData(string[] DataList)
        {
            //Check length
            if (DataList.Length < 1)
            {
                return;
            }

            //Check based on command
            switch (CurrentCommand.Type)
            {
                case InkSysCommandType.SetHeaterSetpoint:
                case InkSysCommandType.SetMeniscusPressure:
                case InkSysCommandType.SetMeniscusPumpLoad:
                case InkSysCommandType.SetReturnPumpLoad:
                case InkSysCommandType.SetNonRecircMeniscusPressure:
                case InkSysCommandType.SetRecircMeniscusPressure:
                case InkSysCommandType.SetReturnPressure:
                case InkSysCommandType.SetFillPumpSpeed:
                case InkSysCommandType.SetFillPumpTimeout:
                case InkSysCommandType.SetPurgeTime:
                case InkSysCommandType.SetPurgePressure:
                case InkSysCommandType.SetBypassTime:
                case InkSysCommandType.SetStartupDelay:
                case InkSysCommandType.SetNetworkID:
                case InkSysCommandType.ResetAlarms:
                case InkSysCommandType.SetDrainSystem:
                case InkSysCommandType.SetSystemFunction:
                    ResponseProcess_SetParameter(DataList);
                    break;

                case InkSysCommandType.GetMeniscusPressure:
                case InkSysCommandType.GetHeaterSetpoint:
                case InkSysCommandType.GetFillPumpSpeed:
                case InkSysCommandType.GetFillPumpTimeout:
                case InkSysCommandType.GetPurgeTime:
                case InkSysCommandType.GetStartupDelay:
                case InkSysCommandType.GetPurgePressure:
                case InkSysCommandType.GetBypassTime:
                case InkSysCommandType.GetSystemFunction:
                case InkSysCommandType.GetMeniscusPumpLoad:
                case InkSysCommandType.GetRecircMeniscusPressure:
                case InkSysCommandType.GetNonRecircMeniscusPressure:
                case InkSysCommandType.GetReturnPumpLoad:
                case InkSysCommandType.GetReturnPressure:
                    ResponseProcess_ReadData(DataList);
                    break;

                case InkSysCommandType.GetNetworkDevices:
                    ResponseProcess_GetNetworkDevices(DataList);
                    break;

                case InkSysCommandType.GetDeviceStatus:
                    ResponseProcess_GetDeviceStatus(DataList);
                    break;

                default:
                    break;
            }
        }


        private void ResponseProcess_SetParameter(string[] dataList)
        {
            if (dataList.Length == 0)
            {
                return;
            }
            else if (dataList.Length == 2)
            {
                if (dataList[0] == InkResponseString.Processed &&
                    dataList[1] == InkResponseString.Success)
                {
                    CurrentCommand.IsSuccess = true; //Set result first
                    CurrentCommand.IsReplied = true;
                }
            }
            else
            {
                CurrentCommand.IsSuccess = false;//Set result first
                CurrentCommand.IsReplied = true;
                return;
            }
        }

        private void ResponseProcess_ReadData(string[] dataList)
        {
            if (dataList.Length == 0)
            {
                CurrentCommand.IsReplied = false;
                return;
            }
            else if (dataList.Length == 2)
            {
                if (dataList[0] == InkResponseString.Processed)
                {
                    if (ParsingNumberValue(dataList[1], "C", out double dValue))
                    {
                        AssignValueBasedOnCommandType(dValue);
                        CurrentCommand.IsSuccess = true;//Set result first
                        CurrentCommand.IsReplied = true;
                        return;
                    }
                }
            }
            else
            {
                CurrentCommand.IsSuccess = false;//Set result first
                CurrentCommand.IsReplied = true;
                return;
            }

            //No result
            CurrentCommand.IsReplied = false;
        }

        private void AssignValueBasedOnCommandType(double dValue)
        {
            switch (CurrentCommand.Type)
            {
                case InkSysCommandType.GetMeniscusPressure:
                    DataBuffer.MeniscusPressureSetPoint = dValue;
                    break;

                case InkSysCommandType.GetMeniscusPumpLoad:
                    break;

                case InkSysCommandType.GetRecircMeniscusPressure:
                    break;

                case InkSysCommandType.GetNonRecircMeniscusPressure:
                    break;

                case InkSysCommandType.GetReturnPressure:
                    break;

                case InkSysCommandType.GetReturnPumpLoad:
                    break;

                case InkSysCommandType.GetHeaterSetpoint:
                    DataBuffer.HeaterSetPoint = dValue;
                    break;

                case InkSysCommandType.GetFillPumpSpeed:
                    DataBuffer.FillPumpSpeedSetPoint = dValue;
                    break;

                case InkSysCommandType.GetFillPumpTimeout:
                    DataBuffer.FillPumpTimeout = dValue;
                    break;

                case InkSysCommandType.GetPurgeTime:
                    DataBuffer.PurgeTimeSetPoint = dValue;
                    break;

                case InkSysCommandType.GetPurgePressure:
                    DataBuffer.PurgePressureSetpoint = dValue;
                    break;

                case InkSysCommandType.GetStartupDelay:
                    DataBuffer.StartUpDelay = dValue;
                    break;

                case InkSysCommandType.GetDeviceStatus:
                    break;

                case InkSysCommandType.GetBypassTime:
                    DataBuffer.ByPassTime = dValue;
                    break;

                case InkSysCommandType.GetSystemFunction:
                    DataBuffer.SystemFunction = Convert.ToUInt16(dValue);
                    break;

                default:
                    break;
            }
        }


        private void ResponseProcess_GetDeviceStatus(string[] dataList)
        {
            //Check length
            if (dataList.Length != 8) return;

            if (dataList[0] == InkResponseString.Processed &&
                dataList[7] == InkResponseString.Success)
            {
                //Fetch data to buffer
                if (ParsingNumberValue(dataList[1], "B", out double dBackPressure))
                    DataBuffer.BackPressure = dBackPressure;
                if (ParsingNumberValue(dataList[2], "R", out double dRecirculationPressure))
                    DataBuffer.RecirculationPressure = dRecirculationPressure;
                if (ParsingNumberValue(dataList[3], "T", out double dHeaterTemp))
                    DataBuffer.HeaterTemp = dHeaterTemp;
                if (ParsingNumberValue(dataList[4], "E", out double dInkTempreture))
                    DataBuffer.InkTempreture = dInkTempreture;
                if (ParsingNumberValue(dataList[5], "S", out double dStatusBits))
                    DataBuffer.StatusBits = dStatusBits;
                if (ParsingNumberValue(dataList[6], "W", out double dAlarm))
                    DataBuffer.Alarm = dAlarm;

                CurrentCommand.IsSuccess = true;
                CurrentCommand.IsReplied = true;
            }
            else
            {
                CurrentCommand.IsSuccess = false;
                CurrentCommand.IsReplied = true;
            }
        }

        /// <summary>
        /// Attempt to read value out from response string
        /// 120,B  backpressure
        /// 16,R
        /// 40,T
        /// 40,E
        /// 0,S
        /// 0,W
        /// </summary>
        /// <param name="sData">Input string</param>
        /// <param name="ValueMark">mark, sample "B"</param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        private bool ParsingNumberValue(string sData, string ValueMark, out double dValue)
        {
            dValue = -1;
            sData = sData.Replace(" ", "");
            string sPattern = @"^-?[0-9]+.?[0-9]*," + ValueMark + "$";
            //Check matches
            if (Regex.IsMatch(sData, sPattern))
            {
                string sValue = sData.Substring(0, sData.IndexOf(","));
                dValue = double.Parse(sValue);
                return true;
            }
            else
            {//No matches
                return false;
            }
        }

        private void ResponseProcess_GetNetworkDevices(string[] dataList)
        {
            if (dataList.Length < 1) return;

            for (int i = 0; i < dataList.Length; i++)
            {
                string sData = dataList[i];
                if (Regex.IsMatch(sData, InkSystemModel.RegDeviceList))
                {
                    //Try to add to list
                    string sID = sData.Substring(0, sData.IndexOf(","));
                    int iID = int.Parse(sID);
                    if (!DataBuffer.DeviceList.Contains(iID))
                    {
                        DataBuffer.DeviceList.Add(iID);
                    }

                    CurrentCommand.IsSuccess = true;//Set result first
                    CurrentCommand.IsReplied = true;
                }
            }
        }



        /// <summary>
        /// Thread to send message
        /// </summary>
        private void ProcessSerialSend()
        {

            //loop process
            while (!EnableDispose)
            {
                //Loopping delay, minimize this value to minimize reaction time
                Thread.Sleep(10);

                //Check pause flag
                if (SendBlocker.EnableBlock)
                {
                    SendBlocker.IsBlocked = true;
                    continue;
                }

                //Try to send message
                try
                {
                    //check port
                    if (Port == null || (!Port.IsOpen))
                    {
                        continue;
                    }

                    //Send Message
                    SendQueueMessages();

                    Thread.Sleep(20); //Avoid sticky package
                }
                catch (Exception e1)
                {
                    //Perform socket error operations
                    Debug.WriteLine("ProcessSerialSend:\r\n" + e1.Message);
                }
            }
        }

        //Message sending process
        private void SendQueueMessages()
        {
            //check message list
            if (Messages2Send.Count < 1)
            {
                return;
            }

            //Try to send command
            try
            {
                //Get the first message
                string sMessage = Messages2Send.First(); //Get command string

                // Directly sends message
                PortSendBasedOnEncoding(sMessage);

                //Remove first message
                Messages2Send.TryDequeue(out string RemovedMessage); //Remove first message

                //Remove queue messages if exceed certain amount
                while (Messages2Send.Count > 50)
                {
                    Messages2Send.TryDequeue(out string RemovedMessage1); //Remove first message
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("SendQueueMessages:\r\n" + e.Message);

                if (Messages2Send.Count > 0)
                {
                    //Remove first message
                    Messages2Send.TryDequeue(out string RemovedMessageExp); //Remove first message
                }

                return;
            }
        }


        public async Task<bool> TryReadData2(InkSysCommandType commandType, int iNetworkID = 0)
        {
            //Try multiple times, read might fail by chance
            for (int i = 0; i < 2; i++)
            {
                //Prepare variables
                CurrentCommand.Init(commandType, iNetworkID); //init command
                DataBuffer = new InkSystemDataBuffer();//prepare data buffer

                //send command
                SendCommand(CurrentCommand.CommandString);

                //Wait for reply
                if (!await WaitForReply(TimeoutMS)) continue;

                //Check result
                if (CurrentCommand.IsSuccess) return true;
            }

            //No success
            return false;
        }

        public async Task<bool> TrySetParameter(InkSysCommandType commandType, int iNetworkID = 0, double dValue = 0)
        {
            //Prepare variables
            CurrentCommand.Init(commandType, iNetworkID, dValue); //init command

            //send command
            SendCommand(CurrentCommand.CommandString);

            //Wait for reply
            if (!await WaitForSuccess(TimeoutMS)) return false;

            //Check for result
            return CurrentCommand.IsSuccess;
        }


        /// <summary>
        /// Attempt to request device list
        /// </summary>
        /// <returns></returns>
        public async Task<bool> TryGetDeviceList()
        {
            //Prepare variables
            CurrentCommand.Init(InkSysCommandType.GetNetworkDevices); //init command
            DataBuffer = new InkSystemDataBuffer();//Clear all devices

            //send command
            SendCommand(CurrentCommand.CommandString);

            //Wait for reply
            if (!await WaitForReply(TimeoutMS)) return false;

            //Wait for more devices
            //Check success, default gap is about 500ms, set 1000ms to make sure receive all devices
            while (CurrentCommand.IsSuccess)
            {
                CurrentCommand.IsReplied = false;
                CurrentCommand.IsSuccess = false;
                Debug.WriteLine("TryGetDeviceList:WaitForNextDevice");
                await WaitForReply(1000);
            }

            //Finish scan, update current devices
            Devices.Clear();
            DataBuffer.DeviceList.Sort();
            for (int i = 0; i < DataBuffer.DeviceList.Count; i++)
            {
                InkDevice device = new InkDevice();
                device.NetworkID = DataBuffer.DeviceList[i];
                Devices.Add(device);
            }

            return true;
        }


        public async Task<bool> TrySetSystemFunction(int FunctionIndex, bool Enable, int iNetworkID = 0)
        {
            UInt16 currentFunctions = 0;

            //Read current state first 
            if (!await TryReadData2(InkSysCommandType.GetSystemFunction, iNetworkID)) return false;

            //Get current function
            currentFunctions = DataBuffer.SystemFunction;

            //Convert function
            bool[] bFunctions = csByteConvert.UInt16ToBoolArray(currentFunctions);

            //Set value
            bFunctions[FunctionIndex] = Enable;

            //Convert back to uint settings
            UInt16 targetFunctions = csByteConvert.BoolArrayToUInt16(bFunctions);

            //Try set this value
            if (!await TrySetParameter(InkSysCommandType.SetSystemFunction, iNetworkID, targetFunctions)) return false;


            //Pass all steps
            return true;

        }

        public async Task<bool> WaitForReply(int iTimeout = 0)
        {
            //Init variables
            Stopwatch watch = new Stopwatch();
            watch.Start();

            //Wait for flag
            while (!CurrentCommand.IsReplied)
            {
                await Task.Delay(10);
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

        public async Task<bool> WaitForSuccess(int iTimeout = 0)
        {
            //Init variables
            Stopwatch watch = new Stopwatch();
            watch.Start();


            //Wait for flag
            while (!CurrentCommand.IsSuccess)
            {
                await Task.Delay(10);
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


        /// <summary>
        /// Send command method for public use
        /// </summary>
        /// <param name="sCommand">Command to send</param>
        public void SendCommand(string sCommand)
        {
            //Direct Send
            Messages2Send.Enqueue(sCommand);
        }

        /// <summary>
        /// Send message based on encoding require ment
        /// </summary>
        /// <param name="sMessage"></param>
        private void PortSendBasedOnEncoding(string sMessage)
        {
            string sLogInfo = "";

            switch (SysConfig.SendFormat)
            {
                case SerialDataType.ASCII:
                    byte[] bDataAscii = Encoding.ASCII.GetBytes(sMessage);
                    if (SysConfig.SendMode==SerialSendMode.Normal)
                    {
                       Port.Write(sMessage+ SysConfig.EndSuffixValue); //Directly send
                    }
                    else
                    {
                        SendWith2BytesGap(bDataAscii);
                    }

                    sLogInfo = $"{csPublic.TimeString}:Send ASCII Message:{sMessage}"; //Display message
                    break;

                case SerialDataType.HEX:
                    byte[] bDataHex = csByteConvert.StringToHexByte(sMessage);

                    if (SysConfig.SendMode == SerialSendMode.Normal)
                    {
                        Port.Write(bDataHex, 0, bDataHex.Length); //Directly send
                    }
                    else
                    {
                        SendWith2BytesGap(bDataHex);
                    }
                    sLogInfo = $"{csPublic.TimeString}:Send HEX Message:{sMessage}"; //Display message
                    
                    break;
                default:
                    break;
            }

            //Show message
            Debug.WriteLine(sLogInfo);
            AppendComLog(sLogInfo + "\r\n\r\n");
        }

        /// <summary>
        /// Get command for 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="iNetworkID"></param>
        /// <param name="iValue">Values that need to be set, only use when send set request</param>
        public static string GetCommandString(InkSysCommandType command, int iNetworkID = 0, double dValue = 0)
        {
            //Stand alone devie
            string sNetwork = NetworkName[iNetworkID];

            switch (command)
            {
                case InkSysCommandType.GetNetworkDevices:
                    return "@SNI#"; //Get all device in the network, format ID,I, sample 1,I

                case InkSysCommandType.SetNetworkID:
                    return $"@SNI,{iNetworkID.ToString("D2")}"; //Keep 2 digits, sample: @SNI,01

                case InkSysCommandType.GetDeviceStatus:
                    return iNetworkID == 0 ? "STA?0" : $"{sNetwork}STA?";

                case InkSysCommandType.GetMeniscusPressure:
                case InkSysCommandType.GetRecircMeniscusPressure:
                    return iNetworkID == 0 ? "SVP?0" : $"{sNetwork}SVP?";

                case InkSysCommandType.SetMeniscusPressure: //current target vacuum pressure
                case InkSysCommandType.SetRecircMeniscusPressure:
                    return iNetworkID == 0 ? $"SVP,{dValue}" : $"{sNetwork}SVP,{dValue}";

                case InkSysCommandType.GetMeniscusPumpLoad:
                    return iNetworkID == 0 ? "SVM?0" : $"{sNetwork}SVM?";

                case InkSysCommandType.SetMeniscusPumpLoad:
                    break;

                case InkSysCommandType.GetNonRecircMeniscusPressure:
                    return iNetworkID == 0 ? "SVP?0" : $"{sNetwork}SVP?";

                case InkSysCommandType.SetNonRecircMeniscusPressure:
                    break;

                case InkSysCommandType.GetReturnPressure:
                    return iNetworkID == 0 ? "SRS?0" : $"{sNetwork}SRS?";

                case InkSysCommandType.SetReturnPressure:
                    break;

                case InkSysCommandType.GetReturnPumpLoad:
                    return iNetworkID == 0 ? "SVR?0" : $"{sNetwork}SVR?";

                case InkSysCommandType.SetReturnPumpLoad:
                    break;

                case InkSysCommandType.GetHeaterSetpoint:
                    return iNetworkID == 0 ? "SHT?0" : $"{sNetwork}SHT?";

                case InkSysCommandType.SetHeaterSetpoint:
                    return iNetworkID == 0 ? $"SHT,{dValue}" : $"{sNetwork}SHT,{dValue}";

                case InkSysCommandType.GetFillPumpSpeed:
                    return iNetworkID == 0 ? "SFS?0" : $"{sNetwork}SFS?";

                case InkSysCommandType.SetFillPumpSpeed:
                    return iNetworkID == 0 ? $"SFS,{dValue}" : $"{sNetwork}SFS,{dValue}";

                case InkSysCommandType.GetFillPumpTimeout:
                    return iNetworkID == 0 ? "STO?0" : $"{sNetwork}STO?";

                case InkSysCommandType.SetFillPumpTimeout:
                    return iNetworkID == 0 ? $"STO,{dValue}" : $"{sNetwork}STO,{dValue}";

                case InkSysCommandType.GetPurgeTime:
                    return iNetworkID == 0 ? "SPT?0" : $"{sNetwork}SPT?";

                case InkSysCommandType.SetPurgeTime:
                    return iNetworkID == 0 ? $"SPT,{dValue}" : $"{sNetwork}SPT,{dValue}";

                case InkSysCommandType.GetPurgePressure:
                    return iNetworkID == 0 ? "SPP?0" : $"{sNetwork}SPP?";

                case InkSysCommandType.SetPurgePressure:
                    return iNetworkID == 0 ? $"SPP,{dValue}" : $"{sNetwork}SPP,{dValue}";

                case InkSysCommandType.GetStartupDelay:
                    return iNetworkID == 0 ? "SPH?0" : $"{sNetwork}SPH?";

                case InkSysCommandType.SetStartupDelay:
                    return iNetworkID == 0 ? $"SPH,{dValue}" : $"{sNetwork}SPH,{dValue}";

                case InkSysCommandType.GetBypassTime:
                    return iNetworkID == 0 ? "SBT?0" : $"{sNetwork}SBT?";

                case InkSysCommandType.SetBypassTime:
                    return iNetworkID == 0 ? $"SBT,{dValue}" : $"{sNetwork}SBT,{dValue}";

                case InkSysCommandType.ResetAlarms:
                    return iNetworkID == 0 ? @"SA1,0" : $"{sNetwork}SA1,0";

                case InkSysCommandType.GetSystemFunction:
                    return iNetworkID == 0 ? "SEB?0" : $"{sNetwork}SEB?";

                case InkSysCommandType.SetSystemFunction:
                    return iNetworkID == 0 ? $"SEB,{dValue}" : $"{sNetwork}SEB,{dValue}";

                case InkSysCommandType.PurgeInk:
                    //1, soft purge
                    //2, hard purge
                    //3, cancel purge
                    //4, head de-airing purge
                    //5, release pressure
                    return iNetworkID == 0 ? $"STP,{dValue}" : $"{sNetwork}STP,{dValue}";

                case InkSysCommandType.SetDrainSystem:
                    //1 active, 0 inactive
                    return iNetworkID == 0 ? $"SDS,{dValue}" : $"{sNetwork}SDS,{dValue}";

                default:
                    break;
            }

            //default
            return "";
        }

        /// <summary>
        /// Ink system requires to send 2 bytes by 2 bytes and with a 10ms gap 
        /// </summary>
        private void SendWith2BytesGap(byte[] bData)
        {
            //Verify size
            if (bData.Length > 200)
            {
                Debug.WriteLine("SendWith2BytesGap: size limit reached.");
                return;
            }

            int iIndex = 0;

            //Send 2 bytes by two bytes
            while (iIndex < (bData.Length - 1))
            {
                byte[] b2Bytes = new byte[] { bData[iIndex], bData[iIndex + 1] };
                Port.Write(b2Bytes, 0, 2);
                iIndex += 2;
                Thread.Sleep(10); //Must have
            }

            //Check if left over exist
            if (iIndex < bData.Length)
            {
                //Send last byte
                byte[] b2Bytes = new byte[] { bData[iIndex], 0x00 };
                Port.Write(b2Bytes, 0, 2);
                Thread.Sleep(10); //Must have
            }
        }


    }





}
