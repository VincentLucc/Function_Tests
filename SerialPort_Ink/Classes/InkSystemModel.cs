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
        /// <summary>
        /// Regex strings
        /// </summary>
        public static string RegDeviceList = "^[0-9]{1,2},I$";
        public static string[] SystemStatus = new string[] {"Tank filling","purging","tank heater output on","ext heater output on",
                                                      "cure lamp output on","internal recirc","head lockoff valve open","System Enabled",
                                                      "preheat active","bypass active","drain system active","flush system active",
                                                      "N/A","N/A","N/A","N/A"};
        public static string[] Alarms = new string[] {"vacuum/pressure alarm","pump timeout","ink level warning","ink bottle empty",
                                                      "Tank thermocouple fault","degass fault (if fitted)","recirc fault (if recirc version)","Failsafe alarm (float switch in the air bottle)",
                                                      "N/A","N/A","N/A","N/A",
                                                      "N/A","N/A","N/A","N/A"};


        public static List<string> GetAlarmList(UInt16 iValue)
        {
            var sList = new List<string>();
            bool[] bList = csByteConvert.UInt16ToBoolArray(iValue);
            for (int i = 0; i < 16; i++)
            {
                if (bList[i]) sList.Add(Alarms[i]);
            }
            return sList;
        }


        /// <summary>
        /// Get enable degass commandvalue
        /// </summary>
        /// <returns></returns>
        public static uint EnableDegassValue()
        {
            bool[] bData = new bool[16];
            bData[13] = true;
            return csByteConvert.BoolArrayToUInt16(bData);
        }
    }

    /// <summary>
    /// System function and index
    /// </summary>
    public enum InkSystemFunction
    {
        EnableDegass = 13
    }

    public class InkResponseString
    {
        public static string Processed = ",A";
        public static string Success = ",C";
    }

    public enum InkSysCommandType
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
        GetHeaterSetpoint,
        SetHeaterSetpoint,
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
        SetBypassTime,
        GetDeviceStatus,
        GetSystemFunction,
        SetSystemFunction,
        ResetAlarms,
        PurgeInk,
        SetDrainSystem
    }


    /// <summary>
    /// Buffer settings of the ink system
    /// </summary>
    public class InkSystemDataBuffer : InkDevice
    {
        /// <summary>
        /// Network info of found devices
        /// </summary>
        public List<int> DeviceList { get; set; }
        public InkSystemDataBuffer()
        {
            DeviceList = new List<int>();
        }
    }



    public class InkDevice
    {
        /// <summary>
        /// Device network ID, 0 not in network, 1-4 matches A-D
        /// </summary>
        public int NetworkID { get; set; }
        /// <summary>
        /// Description info
        /// </summary>
        public string Name { get; set; }
        public double BackPressure { get; set; }
        public double MeniscusPressureSetPoint { get; set; }
        public double NonRecirculatingMeniscusPressureSetPoint { get; set; }
        public double RecirculationPressure { get; set; }
        public double HeaterTemp { get; set; }
        public double InkTempreture { get; set; }
        public double StatusBits { get; set; }
        public double Alarm { get; set; }
        public List<string> AlarmList => InkSystemModel.GetAlarmList(Convert.ToUInt16(Alarm));
        public double HeaterSetPoint { get; set; }
        public double FillPumpSpeedSetPoint { get; set; }
        public double FillPumpTimeout { get; set; }
        public double PurgeTimeSetPoint { get; set; }
        public double PurgePressureSetpoint { get; set; }
        public double StartUpDelay { get; set; }
        public double ByPassTime { get; set; }
        public UInt16 SystemFunction { get; set; }

        /// <summary>
        /// System status from STA?
        /// </summary>

        public bool FillPumpEnable => GetSystemStatus(SystemFunction, 0);
        public bool PressureValveEnable => GetSystemStatus(SystemFunction, 1);
        public bool TankHeaterOutput => GetSystemStatus(SystemFunction, 2);
        public bool ExternalHeaterOutput => GetSystemStatus(SystemFunction, 3);
        public bool CureLampOutput => GetSystemStatus(SystemFunction, 4);
        public bool RecirculationEnable => GetSystemStatus(SystemFunction, 5);
        public bool HeadLockoffValveEnable => GetSystemStatus(SystemFunction, 6);
        public bool InkSystemEnable => GetSystemStatus(SystemFunction, 7);
        public bool PreHeatEnable => GetSystemStatus(SystemFunction, 8);
        public bool ByPassEnable => GetSystemStatus(SystemFunction, 9);
        public bool DrainSystemEnable => GetSystemStatus(SystemFunction, 10);



        public void CopyDeviceStatus(ref InkDevice deviceData)
        {
            deviceData.BackPressure = BackPressure;
            deviceData.RecirculationPressure = RecirculationPressure;
            deviceData.HeaterTemp = HeaterTemp;
            deviceData.InkTempreture = InkTempreture;
            deviceData.StatusBits = StatusBits;
            deviceData.Alarm = Alarm;
            deviceData.SystemFunction = SystemFunction;
        }

        private bool GetSystemStatus(UInt16 systemStatusValue, int iIndex)
        {
            bool[] bData = csByteConvert.UInt16ToBoolArray(systemStatusValue);
            return bData[iIndex];
        }
    }

    /// <summary>
    /// Ink system commands status
    /// </summary>
    public class InkSystemCommand
    {
        /// <summary>
        /// Inidcate whether a response received from ink device
        /// This trigger result check
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
        public InkSysCommandType Type { get; set; }
        /// <summary>
        /// command to be sent
        /// </summary>
        public string CommandString { get; set; }
        public int IntValue { get; set; }
        /// <summary>
        /// Store value
        /// </summary>
        public double DoubleValue { get; set; }
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

        /// <summary>
        /// Prepare command
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="iNetwork">Device network ID</param>
        /// <param name="iValue">Set value if it's a set comand</param>
        public void Init(InkSysCommandType commandType, int iNetwork = 0, double dValue = -1)
        {
            IsReplied = false;
            IsSuccess = false;
            Type = commandType;
            IntValue = -1;
            DoubleValue = dValue;
            StrValue = "";
            NetworkID = iNetwork;
            CommandString = csInkSystemColor.GetCommandString(commandType, iNetwork, DoubleValue);
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
