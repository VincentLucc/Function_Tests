using Reader;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// Tags read in current command
        /// </summary>
        public List<RFIDTag> Tags { get; set; }

        public ReaderCommand()
        {
            CMDTime = new Stopwatch();
            Tags = new List<RFIDTag>();
        }

        public void Init(byte Command)
        {
            IsReplied = false;
            Type = Command;
            IntValue = -1;
            ErrorCode = 0x00;
            Tags = new List<RFIDTag>();
            CMDTime.Restart();
        }

        /// <summary>
        /// Reset operation
        /// </summary>
        public void Reset()
        {
            IsReplied = false;
            Type = 0x00;
            IntValue = -1;
            ErrorCode = 0x00;
            Tags = new List<RFIDTag>();
            CMDTime.Reset();
        }
    }


    /// <summary>
    /// Contains tag info and methods
    /// </summary>
    public class RFIDTag : RXInventoryTag
    {
        /// <summary>
        /// Hex directly treated as string!!!?
        /// Keep the old style
        /// </summary>
        public int EPCNumber => CalEPCNumber();

        /// <summary>
        /// First two byte of the label
        /// </summary>
        public string EPCLabel => CalEPCLabel();

        public static string PreFix = "PS";

        /// <summary>
        /// start with 50 53, end with 10 double digit
        /// sample: 50 53 00 00 00 00 00 00 00 00 29 83
        /// </summary>
        public static string EPCPattern = @"^\s?50\s?53\s?(\s?[0-9]{2}\s?){10}$";

        /// <summary>
        /// Test Tag "50 53 00 00 00 00 00 00 00 00 00 01"
        /// </summary>
        public static string EPCTest = @"^\s?50\s?53\s?(\s?[0]{2}\s?){9}(\s?01\s?)$";

        public static string EPCEmpty = @"^\s?50\s?53\s?(\s?[0]{2}\s?){10}$";

        /// <summary>
        /// Indicate whether current epc is serialized to our format
        /// New tag or serialized tag
        /// </summary>
        public bool IsEPCUpdated => Regex.IsMatch(strEPC, EPCPattern);

        public bool IsTestTag => Regex.IsMatch(strEPC, EPCTest);

        public bool IsEmptyTag => Regex.IsMatch(strEPC, EPCEmpty);
        /// <summary>
        /// Create a tag based on epc values
        /// </summary>
        public static string GenerateTagEPC(string sLabel, int iNumber)
        {
            //Total 12 bytes
            byte[] bTagEPC = new byte[12]; //prepare empty epc bytes

            byte[] bLabel = Encoding.UTF8.GetBytes(sLabel); //First 2 bytes label area

            //Get number
            byte[] bNumber = csCRC.StringToHexByte(iNumber.ToString()); //Directly treat number as Hex value

            //Copy data
            Array.Copy(bLabel, bTagEPC, 2); //copy label
            Array.Copy(bNumber, 0, bTagEPC, bTagEPC.Length - bNumber.Length, bNumber.Length); //Copy number

            //Convert back to string
            //Add a space to match reader's epc format 
            return " " + BitConverter.ToString(bTagEPC).Replace("-", " ");
        }

        /// <summary>
        /// Read label methods
        /// </summary>
        /// <returns></returns>
        private string CalEPCLabel()
        {
            var bEPC = csCRC.StringToHexByte(strEPC);
            //Check length
            if (bEPC.Length != 12) return null;

            //Get first two byte
            byte[] bLabel = new byte[2];
            Array.Copy(bEPC, bLabel, 2); //Copy first two bytes

            //Convert to text
            string sLabel = Encoding.UTF8.GetString(bLabel);
            return sLabel;
        }

        /// <summary>
        /// Read EPC numbers
        /// </summary>
        /// <returns></returns>
        private int CalEPCNumber()
        {
            var bEPC = csCRC.StringToHexByte(strEPC);
            //Check length
            if (bEPC.Length != 12) return -1;

            //Get string
            string sNumber = strEPC.Substring(7).Replace(" ", "");

            //Try to convert
            if (!int.TryParse(sNumber, out int iResult))
            {
                return -1;
            }

            //Pass all steps
            return iResult;
        }


        /// <summary>
        /// Data convert from reader tag to operation tag
        /// </summary>
        /// <param name="InventoryTag"></param>
        public static RFIDTag Create(RXInventoryTag InventoryTag)
        {
            RFIDTag tag = new RFIDTag();

            if (InventoryTag == null) return tag;

            tag.strPC = InventoryTag.strPC;
            tag.strCRC = InventoryTag.strCRC;
            tag.strEPC = InventoryTag.strEPC;
            tag.btAntId = InventoryTag.btAntId;
            tag.strRSSI = InventoryTag.strRSSI;
            tag.mReadCount = InventoryTag.mReadCount;
            tag.cmd = InventoryTag.cmd;

            //Pass all steps
            return tag;
        }

        /// <summary>
        /// Clear tag content
        /// </summary>
        public void Clear()
        {
            strPC = "";
            strCRC = "";
            strEPC = "";
            btAntId = (byte)0;
            strRSSI = "";
            mReadCount = (byte)0;
            cmd = (byte)0;
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

    public enum LEDState
    {
        Normal, //Blink green
        GreenON, //Keep green
        RedON, //Keep red
        Disable, //Yellow
    }

}
