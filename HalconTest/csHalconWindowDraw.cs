using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HalconTest
{
    public class csHalconWindowDraw
    {
        /// <summary>
        /// Indicate whether a draw action is in process
        /// </summary>
        public bool IsDrawing { get; set; }

        /// <summary>
        /// Drawing object handle
        /// </summary>
        [XmlIgnore, JsonIgnore]
        public HTuple DrawHandle { get; set; }

        /// <summary>
        /// Position from origin to current position
        /// </summary>
        [XmlIgnore, JsonIgnore]
        public HTuple PositionOffsetMatrix { get; set; }

        /// <summary>
        /// Currently active draw region type
        /// </summary>
        public _drawShapeType DrawShape { get; set; }

        /// <summary>
        /// Append/Erase
        /// </summary>
        public _drawAction DrawAction { get; set; } = _drawAction.None;

        /// <summary>
        /// Currently active draw rectangle2
        /// </summary>
        public Rectangle2Data Rectangle2 { get; set; }

        /// <summary>
        /// Currently active draw line
        /// </summary>
        public csLineData Line { get; set; }


        public csSearchRegionSettings DrawSource;


    }
}
