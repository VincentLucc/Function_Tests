using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _CommonCode_Framework;

namespace HalconTest
{
    /// <summary>
    /// Rectangle area with orientation
    /// Match the Halcon rect2 type
    /// </summary>
    public class Rectangle2Data
    {

        [Browsable(false)]
        public float Row { get; set; }
        [Browsable(false)]
        public float Column { get; set; }

        /// <summary>
        /// Angle in radian
        /// </summary>
        [Browsable(false)]

        public float Phi { get; set; }



        /// <summary>
        /// half width
        /// </summary>
        [Browsable(false)]
        public float Length1 { get; set; }
        /// <summary>
        /// Half height
        /// </summary>
        [Browsable(false)]
        public float Length2 { get; set; }

        /// <summary>
        /// Indicate this rectangle is previouly defined or not
        /// </summary>
        public bool IsInit { get; set; }

        public Rectangle2Data()
        {

        }

        public void Init(float fRow, float fColumn, float fPhi, float fLength1, float fLength2)
        {
            Row = fRow;
            Column = fColumn;
            Phi = fPhi;
            Length1 = fLength1;
            Length2 = fLength2;
            IsInit = true;


        }



        public HTuple ToHtuple()
        {

            List<float> parameters = new List<float>() { Row, Column, Phi, Length1, Length2 };
            HTuple ht_Value = new HTuple(parameters.ToArray());
            return ht_Value;
        }

       

        public void Init(HTuple hRow, HTuple hColumn, HTuple hPhi, HTuple hLength1, HTuple hLength2)
        {
            Row = (float)hRow.D;
            Column = (float)hColumn.D;
            Phi = (float)hPhi.D;
            Length1 = (float)hLength1.D;
            Length2 = (float)hLength2.D;
            IsInit = true;
        }


        /// <summary>
        /// create from rect1 data
        /// </summary>
        /// <param name="rectange1Data"></param>
        public void Init(Rectangle1Data rectange1Data)
        {
            float fRowMax = Math.Max(rectange1Data.Row1, rectange1Data.Row2);
            float fRowMin = Math.Max(rectange1Data.Row1, rectange1Data.Row2);
            float fColumnMax = Math.Max(rectange1Data.Column1, rectange1Data.Column2);
            float fColumnMin = Math.Max(rectange1Data.Column1, rectange1Data.Column2);

            Row = fRowMax - fRowMin;
            Column = fColumnMax - fColumnMin;
            Phi = 0;
            Length1 = (fColumnMax - fColumnMin) / 2f;
            Length2 = (fRowMax - fRowMin) / 2f;
            IsInit = true;
        }

        /// <summary>
        /// Only works without scale
        /// </summary>
        /// <param name="mappingMatrix"></param>
        /// <returns></returns>
        public bool MapRegion(HTuple mappingMatrix)
        {
            try
            {
                //Don't map the whole rect2 directly since it will lose the angle info
                //Alignment angle +-180， when mapping rectangle the angle range will be +-90

                //Transfor the center point
                HOperatorSet.AffineTransPoint2d(mappingMatrix, Row, Column, out HTuple centerRow, out HTuple centerColumn);


                //Default angle range is +-90, calculate the actual orientation (+-180) by using a reference line
                var originRefPoint = GetDirectionPoint();
                //Shift the reference point
                HOperatorSet.AffineTransPoint2d(mappingMatrix, originRefPoint.Row, originRefPoint.Column, out HTuple newRefRow, out HTuple newRefCOlumn);


                //Get the new angle
                csLineData refLine = new csLineData();
                refLine.Init(centerRow, centerColumn, newRefRow, newRefCOlumn);



                //Read result
                Row = (float)centerRow.D;
                Column = (float)centerColumn.D;
                Phi = refLine.RotationRadian;
                //Keep len1 and len2 the same

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Rectange2Data.Exception:{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Get point from the center of the rectangel2 to the center point of the edge
        /// </summary>
        private HalconPoint GetDirectionPoint()
        {
            try
            {

                //Get the reference point
                //Assume the phi is 0
                var referencePoint = new HalconPoint(Row, Column + Length1);
                HOperatorSet.VectorAngleToRigid(Row, Column, 0, Row, Column, Phi, out HTuple horiMat);

                //Get actual point by mapping
                HOperatorSet.AffineTransPoint2d(horiMat, referencePoint.Row, referencePoint.Column, out HTuple newRow, out HTuple newCol);

                referencePoint.Row = (float)newRow.D;
                referencePoint.Column = (float)newCol.D;

                return referencePoint;


            }
            catch (Exception ex)
            {

                Trace.WriteLine("GetDirectionPoint:\r\n" + ex.Message);
                return null;
            }
        }

        public void CreateSampleRegion(HTuple halconWindow)
        {
            HOperatorSet.GetPart(halconWindow, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
            float iHeightSegment = (float)(row2.D - row1.D) / 4;
            float iWidthSegment = (float)(column2.D - column1.D) / 4;

            Row = (float)row1.D + 2 * iHeightSegment;
            Column = (float)column1.D + 2 * iWidthSegment;
            Phi = 0;
            Length1 = iWidthSegment;
            Length2 = iHeightSegment;
            IsInit = true;
        }

        public HObject CreateRegion()
        {
            try
            {
                HOperatorSet.GenRectangle2(out HObject Rectangle, Row, Column, Phi, Length1, Length2);
                return Rectangle;
            }
            catch (Exception ex)
            {

                Trace.WriteLine("Rectange2Data.CreateRegion\r\n" + ex.Message);
                return null;
            }

        }

        public bool LoadFromRectRegion(HObject hoRegion)
        {
            try
            {
                if (hoRegion == null ||
                    !hoRegion.IsInitialized())
                {
                    return false;
                }

                HOperatorSet.SmallestRectangle2(hoRegion, out HTuple row, out HTuple col, out HTuple phi, out HTuple length1, out HTuple length2);
                Init(row, col, phi, length1, length2);
            }
            catch (Exception e)
            {
                e.TraceException("LoadFromRectRegion");
                return false;
            }

            //Pass all
            return true;
        }

        public bool LoadFromRectContour(HObject hoContour)
        {
            try
            {
                if (hoContour == null ||
                    !hoContour.IsInitialized())
                {
                    return false;
                }

                HOperatorSet.SmallestRectangle2Xld(hoContour, out HTuple row, out HTuple col, out HTuple phi, out HTuple length1, out HTuple length2);
                Init(row, col, phi, length1, length2);
            }
            catch (Exception e)
            {
                e.TraceException("Rect2.LoadFromRectContour");
                return false;
            }

            //Pass all
            return true;
        }


        /// <summary>
        /// Control the orientation to be <=45 deg
        /// When height>width, rect2 can be close to +-90, this method can avoid this condition 
        /// </summary>
        public void LimitOrientationWithin45Deg()
        {
            //Result can be +-90 
            //Avoid rect2 or rotation due to detected angle is vertical
            var degOrigin = new HTuple(Phi).TupleDeg();

            //must remove the extra angle to keep the result image close to the region orientation
            if (degOrigin > 45)
            {//Make sure cropped image stay in same orientation
                Phi = (float)(degOrigin - 90.0).TupleRad().D;
                (Length1, Length2) = (Length2, Length1);
            }
            else if (degOrigin < -45)
            {//Make sure cropped image stay in same orientation
                Phi = (float)(degOrigin + 90.0).TupleRad().D;
                (Length1, Length2) = (Length2, Length1);
            }

        }

        public HObject CropImage(HObject sourceImage, _interpolationType interpolation)
        {
            string sInterpolation = interpolation.ToString();
            HOperatorSet.CropRectangle2(sourceImage, out HObject imagePart, (double)Row, (double)Column, (double)Phi, (double)Length1, (double)Length2, "true", sInterpolation);
            return imagePart;
        }
    }

    /// <summary>
    /// Rectangle without angle info (Angle=0) 
    /// </summary>
    public class Rectangle1Data
    {
        [Browsable(false)]
        public float Row1 { get; set; }
        [Browsable(false)]
        public float Column1 { get; set; }
        [Browsable(false)]
        public float Row2 { get; set; }
        [Browsable(false)]
        public float Column2 { get; set; }

        [DisplayName("Row")]
        public float RowCenter { get; set; }

        [DisplayName("Column")]
        public float ColumnCenter { get; set; }

        [DisplayName("Width")]
        public float Width { get; set; }

        [DisplayName("Height")]
        public float Height { get; set; }

        /// <summary>
        /// Top position of the char, used to show text
        /// </summary>
        [Browsable(false)]
        public HalconPoint charTop { get; set; }
        /// <summary>
        /// Bottom position of the char, used to show text
        /// </summary>
        [Browsable(false)]
        public HalconPoint charBottom { get; set; }

        public Rectangle1Data()
        {

        }

        public void Display(HTuple window)
        {
            HOperatorSet.DispRectangle1(window, (double)Row1, (double)Column1, (double)Row2, (double)Column2);
        }

        public void Load(double r1, double c1, double r2, double c2)
        {
            Load((float)r1, (float)c1, (float)r2, (float)c2);
        }

        public void Load(float r1, float c1, float r2, float c2)
        {
            Row1 = r1; Column1 = c1; Row2 = r2; Column2 = c2;
            Width = Math.Abs(Column1 - Column2);
            Height = Math.Abs(Row1 - Row2);
            RowCenter = Math.Max(Row1, Row2) - Height / 2;
            ColumnCenter = Math.Max(Column1, Column2) - Width / 2;
            charTop = new HalconPoint(Row1 - 25, ColumnCenter - 5);
            charBottom = new HalconPoint(Row2 + 5, ColumnCenter - 5);
        }

        public bool MapRectangle1(HTuple mapMatrix)
        {
            try
            {
                //Affine center point
                HOperatorSet.AffineTransPoint2d(mapMatrix, RowCenter, ColumnCenter, out HTuple newRowCenter, out HTuple newColumnCenter);
                RowCenter = (float)newRowCenter.D;
                ColumnCenter = (float)newColumnCenter.D;

                //Affine left point
                HOperatorSet.AffineTransPoint2d(mapMatrix, Row1, Column1, out HTuple newRow1, out HTuple newCol1);
                Row1 = (float)newRow1.D;
                Column1 = (float)newCol1.D;

                //Affine right point
                HOperatorSet.AffineTransPoint2d(mapMatrix, Row2, Column2, out HTuple newRow2, out HTuple newCol2);
                Row2 = (float)newRow2.D;
                Column2 = (float)newCol2.D;

                //Map top point
                HOperatorSet.AffineTransPoint2d(mapMatrix, charTop.Row, charTop.Column, out HTuple newTopRow, out HTuple newTopColumn);
                charTop.Row = (float)newTopRow.D;
                charTop.Column = (float)newTopColumn.D;

                //Map bottom point
                HOperatorSet.AffineTransPoint2d(mapMatrix, charBottom.Row, charBottom.Column, out HTuple newBottomRow, out HTuple newBottomColumn);
                charBottom.Row = (float)newBottomRow.D;
                charBottom.Column = (float)newBottomColumn.D;

                //Complete
                return true;
            }
            catch (Exception ex)
            {
                string sMessage = $"MapRectangle1.Exception:\r\n{ex.Message}";
                Trace.WriteLine(sMessage);
                return false;
            }

        }
    }



    [XmlType("LineData")]
    public class csLineData
    {
        public float Row1 { get; set; }

        [DisplayName("Col.1")]
        public float Column1 { get; set; }

        public float Row2 { get; set; }
        [DisplayName("Col.2")]
        public float Column2 { get; set; }

        public float RotationRadian { get; set; }
        /// <summary>
        /// Line angle is same when using as horizontal degree by default
        /// 90~0~-90 Degree, with continuous degrees
        /// </summary>
        [DisplayName("Degree")]
        public float RotationDegree => GetRotationDegree();


        public float CenterRow { get; set; }
        public float CenterColumn { get; set; }

        /// <summary>
        /// Line length
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// Indicate whether this line object been first initialized
        /// </summary>
        [Browsable(false)]
        public bool IsInit { get; set; }


        public csLineData() { }

        public csLineData(HTuple hRow1, HTuple hColumn1, HTuple hRow2, HTuple hColumn2)
        {
            Init(hRow1, hColumn1, hRow2, hColumn2);
        }



        public void Init(HTuple hRow1, HTuple hColumn1, HTuple hRow2, HTuple hColumn2)
        {
            Row1 = (float)hRow1.D;
            Column1 = (float)hColumn1.D;
            Row2 = (float)hRow2.D;
            Column2 = (float)hColumn2.D;
            GenLinePosition();
            IsInit = true;
        }


        public void Init(float fRow1, float fColumn1, float fRow2, float fColumn2)
        {
            Row1 = fRow1;
            Column1 = fColumn1;
            Row2 = fRow2;
            Column2 = fColumn2;
            GenLinePosition();
            IsInit = true;
        }

        /// <summary>
        /// Line angle is same when using as horizental degree by default
        /// 90~0~-90 Degree, with continous degrees
        /// When in vertical angle will jump from -90 to +90 without gap
        /// Causing alignment function not working properly
        /// </summary>
        private float GetVerticalSafeDegree()
        {
            if (RotationDegree < 0)
            {
                var degree = 180 - (-RotationDegree);
                return degree;
            }
            else
            {
                return RotationDegree;
            }
        }

        /// <summary>
        /// Line angle is same when using as horizental degree by default
        /// 90~0~-90 Degree, with continous degrees
        /// When in vertical angle will jump from -90 to +90 without gap
        /// Causing alignment function not working properly
        /// </summary>
        public float GetVerticalSafePhi()
        {
            HTuple safeDegree = GetVerticalSafeDegree();
            return (float)safeDegree.TupleRad().D;
        }


        private float GetRotationDegree()
        {
            HTuple rad = RotationRadian;
            float degree = (float)rad.TupleDeg().D;

            return degree;
        }

        /// <summary>
        /// Generate line position data for future usage
        /// </summary>
        public void GenLinePosition()
        {
            try
            {
                HOperatorSet.LinePosition(Row1, Column1, Row2, Column2, out HTuple centerRow, out HTuple centerColumn, out HTuple length, out HTuple phi);
                CenterRow = (float)centerRow.D;
                CenterColumn = (float)centerColumn.D;
                Length = (float)length.D;

                //Line orientation angle from position is +-90, to match the alignment +-180, transformation is required
                HTuple degreeRead = phi.TupleDeg();
                if ((degreeRead.D > 0 && degreeRead.D <= 90) || degreeRead.D == -90)
                {//Check verticial orientation 
                    if (Row1 - Row2 > 0)
                    {
                        RotationRadian = (float)phi.D;
                    }
                    else
                    {
                        HTuple valueDegree = -(180 - degreeRead.D);
                        RotationRadian = (float)valueDegree.TupleRad().D;
                    }
                }
                else if (degreeRead.D <= 0 && degreeRead.D > -90)
                {//Check horizontal orientation
                    if (Column2 - Column1 > 0)
                    {
                        RotationRadian = (float)phi.D;
                    }
                    else
                    {
                        HTuple valueDegree = 180 - (-degreeRead.D);
                        RotationRadian = (float)valueDegree.TupleRad().D;
                    }
                }
                else
                {
                    RotationRadian = (float)phi.D;
                }

            }
            catch (Exception ex)
            {
                Trace.WriteLine("LineData.GenLinePosition:\r\n" + ex.Message);
            }
        }

        public void LoadSampleLine(HTuple halconWindow, bool IsVertical)
        {
            HOperatorSet.GetPart(halconWindow, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
            float iHeightSegment = (float)(row2.D - row1.D) / 4;
            float iWidthSegment = (float)(column2.D - column1.D) / 4;

            if (IsVertical)
            {//Set default vertical line
                Row1 = (float)row1.D + 3 * iHeightSegment;
                Column1 = (float)column1.D + iWidthSegment;
                Row2 = (float)row1.D + iHeightSegment;
                Column2 = (float)column1.D + iWidthSegment;
            }
            else
            {//Set default horizontal line
                Row1 = (float)row1.D + 3 * iHeightSegment;
                Column1 = (float)column1.D + iWidthSegment;
                Row2 = (float)row1.D + 3 * iHeightSegment;
                Column2 = (float)column1.D + 3 * iWidthSegment;
            }

            IsInit = true;

            GenLinePosition();
        }

        public string GetLineDisplayText()
        {
            if (!IsInit) return "N/A";

            return $"{Row1.ToString("f0")},{Column1.ToString("f0")},{Row2.ToString("f0")},{Column2.ToString("f0")}";

        }

        public bool MapRegion(HTuple mappingMatrix)
        {
            try
            {
                HOperatorSet.AffineTransPixel(mappingMatrix, Row1, Column1, out HTuple newRow1, out HTuple newCol1);
                HOperatorSet.AffineTransPixel(mappingMatrix, Row2, Column2, out HTuple newRow2, out HTuple newCol2);
                Init(Row1, Column1, Row2, Column2);
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"LineData.Exception:{ex.Message}");
                return false;
            }
        }



        /// <summary>
        /// XLD display object is sub-pixel based
        /// </summary>
        /// <returns></returns>
        public HObject GetLineXld()
        {
            if (!IsInit) return null;

            try
            {
                var row = new HTuple(new double[] { Row1, Row2 });
                var col = new HTuple(new double[] { Column1, Column2 });
                HOperatorSet.GenContourPolygonXld(out HObject contourLine, row, col);
                return contourLine;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return null;
            }
        }
    }

    public class HalconPoint
    {
        public float Row { get; set; }
        public float Column { get; set; }

        public HalconPoint()
        {
            Reset();
        }

        public HalconPoint(int iRow, int iColumn)
        {
            Row = iRow;
            Column = iColumn;
        }

        public HalconPoint(long lRow, long lColumn)
        {
            Row = (int)lRow;
            Column = (int)lColumn;
        }

        public HalconPoint(float fRow, float fColumn)
        {
            Row = fRow;
            Column = fColumn;
        }

        public HalconPoint(double dRow, double dColumn)
        {
            Row = (float)dRow;
            Column = (float)dColumn;
        }

        public HalconPoint(HTuple fRow, HTuple fColumn)
        {
            Row = (float)fRow.D;
            Column = (float)fColumn.D;
        }

        public void Reset()
        {
            Row = -1;
            Column = -1;
        }

        public bool IsValid()
        {
            return Row != -1 && Column != -1;
        }

        public bool WithInImage(HObject image)
        {
            try
            {
                HOperatorSet.GetImageSize(image, out HTuple width, out HTuple height);

                if (Row < 0 || Row > height.L) return false;

                if (Column < 0 || Column > width.L) return false;

                return true;

            }
            catch (Exception e)
            {
                e.TraceException("HalconPoint.WithInImage");
                return false;
            }
        }

        public bool WidthInRect1(HTuple row1, HTuple col1, HTuple row2, HTuple col2)
        {
            if (this.Row > row2.D || this.Row < row1.D) return false;
            if (this.Column > col2.D || this.Column < col1.D) return false;
            return true;
        }
    }
}
