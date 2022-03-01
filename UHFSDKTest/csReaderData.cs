using Reader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHFSDKTest
{
    public class ReaderCommand
    {

        /// <summary>
        /// Inidcate whether a response received from reader
        /// </summary>
        public bool IsReplied { get; set; }

        /// <summary>
        /// Indicate if the command is successfully finished
        /// </summary>
        public bool IsSuccess => ErrorCode == ERROR.SUCCESS ? true : false;

        /// <summary>
        /// Command error code
        /// </summary>
        public byte ErrorCode { get; set; }
        public byte Type { get; set; }
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

        /// <summary>
        /// Is this a loop command
        /// </summary>
        public bool IsLoop { get; set; }
        /// <summary>
        /// How many times current command exec
        /// </summary>
        public int ExecACC { get; set; }

        /// <summary>
        /// Tags read in current command
        /// </summary>
        public List<RXInventoryTag> Tags { get; set; }

        public ReaderCommand()
        {
            CMDTime = new Stopwatch();
            Tags = new List<RXInventoryTag>();
        }

        public void Init(byte Command, bool IsCommandLoop = false)
        {
            IsReplied = false;
            Type = Command;
            IntValue = -1;
            StrValue = null;
            IsLoop = IsCommandLoop;
            ExecACC = 0;
            Tags = new List<RXInventoryTag>();

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
            Tags = new List<RXInventoryTag>();
            ExecACC = 0;
            IsLoop = false;
            CMDTime.Reset();
        }
    }
    /// <summary>
    /// Device data
    /// </summary>
    public class ReaderByteData
    {
        public byte btReadId;
        public byte btMajor;
        public byte btMinor;
        public byte btIndexBaudrate;
        public byte btPlusMinus;
        public byte btTemperature;
        public byte btOutputPower;
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
    }


    /// <summary>
    /// Data type when write
    /// </summary>
    public enum TagDataType
    {
        //Tag default types
        Reserved = 0, //Password
        EPC = 1,//custmized Tag ID
        TID = 2, //manufacture ID
        User = 3, //User data
        //Customized types
        OdooEncryptedData = 4, //Combined data, write in both reserve and user data area (4 bytes+40 bytes)
        AccessCode = 5 //write in reserved area, but only from addresses 4-7 (4 bytes) of data
    }


    public class GeneralResult
    {
        public bool IsSuccess { get; set; } //Method is succes or not
        public int IntResult { get; set; } //Return int result if value needed
        /// <summary>
        /// String value of the result
        /// </summary>
        public string StrValue { get; set; }
        public String Message { get; set; }
    }

}
