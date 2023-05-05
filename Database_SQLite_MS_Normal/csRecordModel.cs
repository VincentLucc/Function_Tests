using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_SQLite_MS_Normal
{
    public class RecordRow
    {
        public int SerialNumber { get; set; }
        public int CustomerID { get; set; }
        public string RecordType { get; set; }
        public int HeadType { get; set; }
        public int Volume { get; set; }
        public string ExpDate { get; set; }
        public string Description { get; set; }

        public RecordRow()
        {

        }

        public RecordRow(int iSerialNumber, int iCustomerID, int iHeadType, int iVolume, string sExpDate, string sDesc)
        {
            SerialNumber = iSerialNumber;
            CustomerID = iCustomerID;
            HeadType = iHeadType;
            Volume = iVolume;
            ExpDate = sExpDate;
            Description = sDesc;
        }
    }
}
