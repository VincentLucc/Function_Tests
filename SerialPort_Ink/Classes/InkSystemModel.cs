using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPort_Ink
{
    class InkSystemModel
    {
        public static string RegDeviceList = "^[0-9]{1,2},I$";
    }



    public enum InkSystemCommandType
    {
        GetNetworkDevices,
        SetNetworkID,
        GetMeniscusPressure,
        SetMeniscusPressure,
        GetMeniscusPumpLoad,
        SetMeniscusPumpLoad,
        GetRecircMeniscusPressure,
        SetRecircMeniscusPressure,
        GetNonRecircMeniscusPressure,
        SetNonRecircMeniscusPressure,
        GetReturnPressure,
        SetReturnPressure,
        GetReturnPumpLoad,
        SetReturnPumpLoad,
        GetHeater,
        SetHeater,
        GetFillPumpSpeed,
        SetFillPumpSpeed,
        GetFillPumpTimeout,
        SetFillPumpTimeout,
        GetPurgeTime,
        SetPurgeTime,
        GetPurgePressure,
        SetPurgePressure,
        GetStartupDelay,
        SetStartupDelay,
        GetBypassTime,
        SetBypassTime
    }


    /// <summary>
    /// Buffer settings of the ink system
    /// </summary>
    public class InkSystemDataBuffer
    {
        public List<int> Devices { get; set; }
        public InkSystemDataBuffer()
        {
            Devices = new List<int>();
        }

        public void Init(InkSystemCommandType commandType)
        {
            switch (commandType)
            {
                case InkSystemCommandType.GetNetworkDevices:
                    Devices = new List<int>();
                    break;
                case InkSystemCommandType.SetNetworkID:
                    break;
                case InkSystemCommandType.GetMeniscusPressure:
                    break;
                case InkSystemCommandType.SetMeniscusPressure:
                    break;
                case InkSystemCommandType.GetMeniscusPumpLoad:
                    break;
                case InkSystemCommandType.SetMeniscusPumpLoad:
                    break;
                case InkSystemCommandType.GetRecircMeniscusPressure:
                    break;
                case InkSystemCommandType.SetRecircMeniscusPressure:
                    break;
                case InkSystemCommandType.GetNonRecircMeniscusPressure:
                    break;
                case InkSystemCommandType.SetNonRecircMeniscusPressure:
                    break;
                case InkSystemCommandType.GetReturnPressure:
                    break;
                case InkSystemCommandType.SetReturnPressure:
                    break;
                case InkSystemCommandType.GetReturnPumpLoad:
                    break;
                case InkSystemCommandType.SetReturnPumpLoad:
                    break;
                case InkSystemCommandType.GetHeater:
                    break;
                case InkSystemCommandType.SetHeater:
                    break;
                case InkSystemCommandType.GetFillPumpSpeed:
                    break;
                case InkSystemCommandType.SetFillPumpSpeed:
                    break;
                case InkSystemCommandType.GetFillPumpTimeout:
                    break;
                case InkSystemCommandType.SetFillPumpTimeout:
                    break;
                case InkSystemCommandType.GetPurgeTime:
                    break;
                case InkSystemCommandType.SetPurgeTime:
                    break;
                case InkSystemCommandType.GetPurgePressure:
                    break;
                case InkSystemCommandType.SetPurgePressure:
                    break;
                case InkSystemCommandType.GetStartupDelay:
                    break;
                case InkSystemCommandType.SetStartupDelay:
                    break;
                case InkSystemCommandType.GetBypassTime:
                    break;
                case InkSystemCommandType.SetBypassTime:
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Ink system commands status
    /// </summary>
    public class InkSystemCommand
    {
        /// <summary>
        /// Inidcate whether a response received from ink device
        /// </summary>
        public bool IsReplied { get; set; }

        /// <summary>
        /// Indicate if the command is successfully finished
        /// </summary>
        public bool IsSuccess { get; set; }

        public int NetworkID { get; set; }

        /// <summary>
        /// Command error code
        /// </summary>
        public byte ErrorCode { get; set; }
        public InkSystemCommandType Type { get; set; }
        /// <summary>
        /// command to be sent
        /// </summary>
        public string CommandString { get; set; }
        public int IntValue { get; set; }
        /// <summary>
        /// String result of current command
        /// </summary>
        public string StrValue { get; set; }
        /// <summary>
        /// Time spent on this command
        /// </summary>
        private Stopwatch CMDTime { get; set; }

        /// <summary>
        /// Time span in ms
        /// </summary>
        public long SpanMs => CMDTime.ElapsedMilliseconds;

        public InkSystemCommand()
        {
            CMDTime = new Stopwatch();
        }

        public void Init(InkSystemCommandType Command, int iNetwork = 0)
        {
            IsReplied = false;
            Type = Command;
            IntValue = -1;
            StrValue = null;
            NetworkID = iNetwork;
            CommandString = csInkSystem.GetCommandString(Command, iNetwork);
            CMDTime.Restart();
        }

        /// <summary>
        /// Reset operation
        /// </summary>
        public void Reset()
        {
            IsReplied = false;
            Type = 0;
            IntValue = -1;
            StrValue = null;
            CMDTime.Reset();
        }
    }
}
