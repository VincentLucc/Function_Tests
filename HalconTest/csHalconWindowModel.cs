using DevExpress.Utils.DirectXPaint;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconTest
{

    public class HalconView
    {
        public HObject ViewImage;
        public HObject Regions;
        public HObject Contours;
        public List<Point> Marks;
        public List<string> Texts;

        public HalconView()
        {
            Texts = new List<string>();
            Marks = new List<Point>();
        }


        public void SetViewImage(HObject Image)
        {
            ClearAll();

            try
            {
                //Avoid source image been changed
                if (Image != null)
                {
                    ViewImage = Image.Clone();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("SetViewImage:\r\n" + ex.Message);
            }


        }


        public void SetRegion(HObject ho_region)
        {
            if (Regions != null)
            {
                Regions.Dispose();
                Regions = null;
            }

            Regions = ho_region;
        }

        public void AddRegion(HObject ho_region)
        {
            if (ho_region == null) return;
            if (Regions == null) HOperatorSet.GenEmptyObj(out Regions);
            HOperatorSet.ConcatObj(Regions, ho_region, out Regions);
        }

        public void SetContour(HObject ho_Contours)
        {
            if (Contours != null)
            {
                Contours.Dispose();
                Contours = null;
            }

            Contours = ho_Contours;
        }

        public void AddContour(HObject ho_Contours)
        {
            if (ho_Contours == null) return;
            if (Contours == null) HOperatorSet.GenEmptyObj(out Contours);
            HOperatorSet.ConcatObj(Contours, ho_Contours, out Contours);
        }

        public void ClearAll()
        {
            if (ViewImage != null)
            {
                ViewImage.Dispose();
                ViewImage = null;
            }

            if (Regions != null)
            {
                Regions.Dispose();
                Regions = null;
            }

            if (Contours != null)
            {
                Contours.Dispose();
                Contours = null;
            }

            Marks.Clear();
            Texts.Clear();
        }

    }

    public class HalconColor
    {
        public static string Red = "red";
        public static string Green = "green";
        public static string Blue = "blue";

        /// <summary>
        /// Tranparent color used for region display
        /// </summary>
        public static string RedTrans = "#ff000060";
        public static string GreenTrans = "#00ff0060";
        public static string BlueTrans = "#00ff0060";
    }

    public class Rectange2Data
    {

        [Browsable(false)]
        public float Row { get; set; }
        [Browsable(false)]
        public float Column { get; set; }
        [Browsable(false)]
        public float Phi { get; set; }
        [Browsable(false)]
        public float Length1 { get; set; }
        [Browsable(false)]
        public float Length2 { get; set; }

        public Rectange2Data()
        {

        }
    }


    public class LineData
    {
        public float Row1 { get; set; }
        public float Column1 { get; set; }

        public float Row2 { get; set; }
        public float Column2 { get; set; }

        public float RotationRadian { get; set; }
        public float RotationDegree => new HTuple(RotationRadian).TupleDeg();

        public float CenterRow { get; set; }
        public float CenterColumn { get; set; }

        /// <summary>
        /// Line length
        /// </summary>
        public float Length { get; set; }
    }

    public class PositionData
    {
        public float Row { get; set; }
        public float Column { get; set; }
        public float RotationRadian { get; set; }
        public float RotationDegree => (float)(new HTuple(RotationRadian).TupleDeg().D);
    }


}
