using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StringBuilder
{
    public class csStringBuilderModel
    {
        public csStringBuilderModel()
        {

        }

            public enum _ASCIIControlChar
            {
                [XmlEnum("0")]
                NUL = 0,
                [XmlEnum("1")]
                SOH = 1,
                [XmlEnum("2")]
                STX = 2,
                [XmlEnum("3")]
                ETX = 3,
                [XmlEnum("4")]
                EOT = 4,
                [XmlEnum("5")]
                ENQ = 5,
                [XmlEnum("6")]
                ACK = 6,
                [XmlEnum("7")]
                BEL = 7,
                [XmlEnum("8")]
                BS = 8,
                [XmlEnum("9")]
                HT = 9,
                [XmlEnum("10")]
                LF = 10,
                [XmlEnum("11")]
                VT = 11,
                [XmlEnum("12")]
                FF = 12,
                [XmlEnum("13")]
                CR = 13,
                [XmlEnum("14")]
                SO = 14,
                [XmlEnum("15")]
                SI = 15,
                [XmlEnum("16")]
                DLE = 16,
                [XmlEnum("17")]
                DC1 = 17,
                [XmlEnum("18")]
                DC2 = 18,
                [XmlEnum("19")]
                DC3 = 19,
                [XmlEnum("20")]
                DC4 = 20,
                [XmlEnum("21")]
                NAK = 21,
                [XmlEnum("22")]
                SYN = 22,
                [XmlEnum("23")]
                ETB = 23,
                [XmlEnum("24")]
                CAN = 24,
                [XmlEnum("25")]
                EM = 25,
                [XmlEnum("26")]
                SUB = 26,
                [XmlEnum("27")]
                ESC = 27,
                [XmlEnum("28")]
                FS = 28,
                [XmlEnum("29")]
                GS = 29,
                [XmlEnum("30")]
                RS = 30,
                [XmlEnum("31")]
                US = 31,
            }
    }
}
