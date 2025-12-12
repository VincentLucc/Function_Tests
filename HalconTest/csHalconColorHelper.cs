using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media;
using System.Xml.Serialization;
using _CommonCode_Framework;
using Color = System.Drawing.Color;

namespace HalconTest
{
    public class csHalconColorHelper
    {
        public const string Red = "red";
        public const string Green = "green";
        public const string Blue = "blue";
        public const string Yellow = "yellow";

        /// <summary>
        /// Transparent color used for region display
        /// </summary>
        public const string RedTrans_80 = "#ff000080";
        public const string RedTrans_40 = "#ff000040";
        public const string GreenTrans_80 = "#00ff0080";
        public const string BlueTrans_80 = "#0000ff80";



        public static List<string> GetMultipleColorParameters(_HalconColor color, double solidness)
        {
            List<string> parameters = new List<string>();
            foreach (_HalconColor option in Enum.GetValues(typeof(_HalconColor)))
            {
                if (color.HasFlag(option))
                {
                    string sValue = GetSingleColorParameter(option, solidness);
                    parameters.Add(sValue);
                }
            }

            return parameters;
        }



        /// <summary>
        /// Convert color to rgb gray value
        /// </summary>
        public static HTuple GetSingleColorGray(_HalconColor color)
        {
            string sColor = csEnumHelper<_HalconColor>.GetDefaultValue(color).ToString();
            byte colorR = Convert.ToByte(sColor.Substring(0, 2), 16);
            byte colorG = Convert.ToByte(sColor.Substring(2, 2), 16);
            byte colorB = Convert.ToByte(sColor.Substring(4, 2), 16);
            return new HTuple(new int[] { (int)colorR, (int)colorG, (int)colorB });
        }

        public static string GetSingleColorParameter(_HalconColor color, double solidness)
        {

            string sColor = csEnumHelper<_HalconColor>.GetDefaultValue(color).ToString();
            //Get Solidness, make sure return similar format
            if (solidness <= 0)
                return $"#{sColor}10";//Return light color
            else if (solidness >= 1)
                return $"#{sColor}ff";//Return solid color

            //Get calculated color
            var ColorValue = (byte)(255 * solidness);
            string sSolid = BitConverter.ToString(new byte[] { ColorValue }).ToLower();

            return $"#{sColor}{sSolid}";
        }

    }


    /// <summary>
    /// Allow to store color in xml 
    /// </summary>
    public class csCustomColor
    {
        [XmlAttribute]
        public byte Red { get; set; }
        [XmlAttribute]
        public byte Green { get; set; }
        [XmlAttribute]
        public byte Blue { get; set; }
        [XmlAttribute]

        public byte Transparent { get; set; } = 255;

        public csCustomColor(Color winColor)
        {
            Red = winColor.R;
            Green = winColor.G;
            Blue = winColor.B;
            Transparent = winColor.A;
        }



        public string ToHalconParameter()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Red.ToString("x2"));
            builder.Append(Green.ToString("x2"));
            builder.Append(Blue.ToString("x2"));
            builder.Append(Transparent.ToString("x2"));
            return builder.ToString();
        }
    }

    [Flags]
    public enum _HalconColor
    {
        [XmlEnum("1"), DefaultValue("000000"), Description("Black")]
        Black = 1 << 0,
        [XmlEnum("2"), DefaultValue("ffffff"), Description("White")]
        White = 1 << 1,
        [XmlEnum("3"), DefaultValue("ff0000"), Description("Red")]
        Red = 1 << 2,
        [XmlEnum("4"), DefaultValue("00ff00"), Description("Green")]
        Green = 1 << 3,
        [XmlEnum("5"), DefaultValue("0000ff"), Description("Blue")]
        Blue = 1 << 4,
        [XmlEnum("6"), DefaultValue("00ffff"), Description("Cyan")]
        Cyan = 1 << 5,
        [XmlEnum("7"), DefaultValue("ff00ff"), Description("Magenta")]
        Magenta = 1 << 6,
        [XmlEnum("8"), DefaultValue("ffff00"), Description("Yellow")]
        Yellow = 1 << 7,
        [XmlEnum("9"), DefaultValue("696969"), Description("Dim Gray")]
        DimGray = 1 << 8,
        [XmlEnum("10"), DefaultValue("bebebe"), Description("Gray")]
        Gray = 1 << 9,
        [XmlEnum("11"), DefaultValue("d3d3d3"), Description("Light Gray")]
        LightGray = 1 << 10,
        [XmlEnum("12"), DefaultValue("7b68ee"), Description("Medium Slate Blue")]
        MediumSlateBlue = 1 << 11,
        [XmlEnum("13"), DefaultValue("ff7f50"), Description("Coral")]
        Coral = 1 << 12,
        [XmlEnum("14"), DefaultValue("6a5acd"), Description("Slate Blue")]
        SlateBlue = 1 << 13,
        [XmlEnum("15"), DefaultValue("00ff7f"), Description("Spring Green")]
        SpringGreen = 1 << 14,
        [XmlEnum("16"), DefaultValue("ff4500"), Description("Orange Red")]
        OrangeRed = 1 << 15,
        [XmlEnum("17"), DefaultValue("ffa500"), Description("Orange")]
        Orange = 1 << 16,
        [XmlEnum("18"), DefaultValue("556b2f"), Description("Dark Olive Green")]
        DarkOliveGreen = 1 << 17,
        [XmlEnum("19"), DefaultValue("ffc0cb"), Description("Pink")]
        Pink = 1 << 18,
        [XmlEnum("20"), DefaultValue("5f9ea0"), Description("Cadet Blue")]
        CadetBlue = 1 << 19,
    }


}
