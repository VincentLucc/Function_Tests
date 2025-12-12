using DevExpress.Utils.DirectXPaint;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HalconTest
{
        [XmlType("ViewSettings")]
    public class csViewSettings
    {
        [Browsable(false)]
        public bool ShowFPS { get; set; }

        [Browsable(false)]
        public bool ShowCPULoad { get; set; }

        [Browsable(false)]
        public bool ShowImageBorder { get; set; }

        /// <summary>
        /// WHen the tool's selected, always show all related graph
        /// </summary>
        public bool ShowSelectedToolAllElements { get; set; }

        public bool HideUnselectedToolsElements { get; set; }

        /// <summary>
        /// This value can't be serialized properly, use the ARGB value instead
        /// </summary>
        [Browsable(false), XmlIgnore, JsonIgnore]
        public Color ImageBorderColor
        {
            get { return Color.FromArgb(ImageBorderColorARGB); }
            set { ImageBorderColorARGB = value.ToArgb(); }
        }
        /// <summary>
        /// Value saved in the xml file
        /// </summary>
        [Browsable(false)]
        public int ImageBorderColorARGB { get; set; }

        /// <summary>
        /// This value can't be serialized properly, use the ARGB value instead
        /// </summary>
        [Browsable(false), XmlIgnore, JsonIgnore]
        public Color ImageTextColor
        {
            get { return Color.FromArgb(ImageTextColorARGB); }
            set { ImageTextColorARGB = value.ToArgb(); }
        }

        /// <summary>
        /// Value saved in the xml file
        /// </summary>
        [Browsable(false)]
        public int ImageTextColorARGB { get; set; }

        /// <summary>
        /// The text size inside an image
        /// </summary>
        [Browsable(false)]
        public int ImageTextSize { get; set; }

        /// <summary>
        /// The text size inside an image
        /// </summary>
        [Browsable(false)]
        public int WindowTextSize { get; set; }

        public bool SeparationColorEnable { get; set; }

        /// <summary>
        /// Separation color options
        /// </summary>
        public _HalconColor SeparationColor { get; set; }

        /// <summary>
        /// When display the region/contour feature, show pixel value / physical unit
        /// </summary>
        public bool UsePhysicalUnit { get; set; }
        public csViewSettings()
        {
            ShowFPS = true;
            ShowCPULoad = false;
            ShowImageBorder = false;
            ShowSelectedToolAllElements = true;
            HideUnselectedToolsElements = true;
            ImageBorderColor = Color.Blue;
            ImageTextColor = Color.Green;
            ImageTextSize = 12;
            WindowTextSize = 14;
            //20 Units Set all to 1
            SeparationColor = (_HalconColor)0x0FFFFF;
        }


    }
    public class csViewPortLayout
    {
        /// <summary>
        /// Link to window forms nothing to do with actual image
        /// </summary>
        public float ExtRow { get; set; }
        public float ExtCol { get; set; }
        public float ExtWidth { get; set; }
        public float ExtHeight { get; set; }

        /// <summary>
        /// View mapping to the actual image
        /// </summary>
        public int PartRow1 { get; set; }
        public int PartRow2 { get; set; }
        public int PartCol1 { get; set; }
        public int PartCol2 { get; set; }

        /// <summary>
        /// Mouse position linked to the window pixels
        /// </summary>
        public int MouseX { get; set; }
        public int MouseY { get; set; }
        public int MouseDelta { get; set; }

        /// <summary>
        /// Mouse position inside the Halcon window
        /// </summary>
        public int MouseX_Halcon { get; set; }
        public int MouseY_Halcon { get; set; }

        /// <summary>
        /// Ext defined win display window size irrelavent to the actual image
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetExtendInfo(HTuple row, HTuple col, HTuple width, HTuple height)
        {
            ExtRow = row;
            ExtCol = col;
            ExtWidth = width;
            ExtHeight = height;
        }

        /// <summary>
        /// Part info connect the actual image to the view port
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetPartInfo(HTuple row1, HTuple col1, HTuple row2, HTuple col2)
        {
            PartRow1 = (int)row1.D;
            PartCol1 = (int)col1.D;
            PartRow2 = (int)row2.D;
            PartCol2 = (int)col2.D;
        }

        public void SetMouseWindowPosition(MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            MouseDelta = e.Delta;
        }

        public void SetMouseHalconPosition(HMouseEventArgs e)
        {
            MouseX_Halcon = (int)e.X;
            MouseY_Halcon = (int)e.Y;
        }
    }

    /// <summary>
    /// Record the display port
    /// </summary>
    public class csViewPortBoundary
    {
        public float Row1 { get; set; }
        public float Col1 { get; set; }
        public float Row2 { get; set; }
        public float Col2 { get; set; }
        public csViewPortBoundary()
        {

        }

        public csViewPortBoundary(float _row1, float _col1, float _row2, float _col2)
        {
            Init(_row1, _col1, _row2, _col2);
        }


        public csViewPortBoundary(int _row1, int _col1, int _row2, int _col2)
        {
            Init(_row1, _col1, _row2, _col2);
        }

        public csViewPortBoundary(double _row1, double _col1, double _row2, double _col2)
        {
            Init((float)_row1, (float)_col1, (float)_row2, (float)_col2);
        }



        private void Init(float _row1, float _col1, float _row2, float _col2)
        {
            Row1 = _row1;
            Col1 = _col1;
            Row2 = _row2;
            Col2 = _col2;
        }

        public string GetDisplay()
        {
            return $"{Row1.ToString("f1")},{Col1.ToString("f1")},{Row2.ToString("f1")},{Col2.ToString("f1")}";
        }
    }

    public enum _imageTextType
    {
        /// <summary>
        /// Show text at defined position
        /// </summary>
        [XmlEnum("0")]
        Default = 0,
        /// <summary>
        /// Adjust the text to allow show text in the center of the defined position
        /// </summary>
        [XmlEnum("1")]
        TextBox_GreenText = 1,
        [XmlEnum("2")]
        TextBox_RedText = 2,
    }

    /// <summary>
    /// Drawing shape type
    /// </summary>
    public enum _drawShapeType
    {
        Line,
        Rectangle2,
        Custom
    }

    public enum _hObjectType
    {
        [XmlEnum("0")]
        Image,
        [XmlEnum("1")]
        Region,
        [XmlEnum("2")]
        Contour,
        [XmlEnum("99")]
        Undefined
    }

    public enum _drawAction
    {
        None,//Default
        Append,//Add to current region
        Erase,//remove from current region
    }

 

    [XmlType("WindowText")]
    public class csDisplayWindowText : csDisplayItemBase
    {
        public string Text { get; set; }

        /// <summary>
        /// Valid color parameter can be directly used by the halcon
        /// </summary>
        public string HalconColor { get; set; }

        public csDisplayWindowText(string sText, string sHalconColor, string sToolID = null)
        {
            Text = sText;
            HalconColor = sHalconColor;
            ToolID = sToolID;
        }
    }

  

}
