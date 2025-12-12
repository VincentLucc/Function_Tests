using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HalconTest
{
    public enum _textOrder
    {
        [Description("Left to right, top to bottom")]
        Left2RightTop2Bottom,
        [Description("Right to left, bottom to top")]
        Right2LeftBottom2Top,
        [Description("Top to bottom, left to right")]
        Top2BottomLeft2Right,
        [Description("Bottom to top, right to left")]
        Bottom2TopRight2Left
    }

    public enum _setHObjectMode
    {
        [XmlEnum("0")]
        Replace = 0,
        [XmlEnum("1")]
        DeepCopy = 1
    }

    /// <summary>
    /// Used in affine trans image or zooming..etc.
    /// </summary>
    public enum _interpolationType
    {
        /// <summary>
        /// Time Consumption:1
        /// Condition: Increase size only
        /// </summary>
        [XmlEnum("0")]
        nearest_neighbor = 0,
        /// <summary>
        /// Time Consumption:3
        /// Condition: Increase size only
        /// </summary>
        [XmlEnum("1")]
        bilinear = 1,
        /// <summary>
        /// Time Consumption:6
        /// Condition: Increase size only
        /// </summary>
        [XmlEnum("2")]
        bicubic = 2,
        /// <summary>
        /// Time Consumption:3~10
        /// Condition: Quality increased when reduce size
        /// </summary>
        [XmlEnum("3")]
        constant = 3,
        /// <summary>
        /// Time Consumption:3~20
        /// Condition: Quality increased when reduce size
        /// </summary>
        [XmlEnum("4")]
        weighted = 4,
    }
}
