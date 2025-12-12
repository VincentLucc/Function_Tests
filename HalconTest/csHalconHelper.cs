using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using _CommonCode_Framework;

namespace HalconTest
{
    public partial class csHalconHelper
    {
        /// <summary>
        /// 3.1415926 Radian = 180 degree
        /// </summary>
        public static float DegreePerRadian = 57.2957795f;

        /// <summary>
        /// 45 degree in rad
        /// </summary>
        public static double HalconDegree45 = 0.7853981634;

        public static List<string> Commands = new List<string>()
        {
            "find_shape_model",
            "find_scaled_shape_model",
            "find_aniso_shape_model",
            "affine_trans_contour_xld",
            "affine_trans_region"
        };

  

        public static bool TryConcat(ref HObject itemCollection, HObject newObject)
        {

            //Check Collection
            if (itemCollection == null ||
                !itemCollection.IsInitialized()) return false;

            //Check input
            if (newObject == null ||
                !newObject.IsInitialized()) return false;

            var debugType = newObject.GetHalconType();


            var newCollection = itemCollection.ConcatObj(newObject);
            itemCollection.Dispose();
            itemCollection = newCollection;
            return true;
        }




        /// <summary>
        /// Replace the image with different mode
        /// </summary>
        /// <param name="targetObject"></param>
        /// <param name="newObject"></param>
        /// <param name="lockObject"></param>
        /// <param name="mode"></param>
        public static void SetHalconObject(ref HObject targetObject, HObject newObject, _setHObjectMode mode)
        {
            try
            {

                if (mode == _setHObjectMode.DeepCopy)
                {
                    //Verify source
                    if (newObject == null || !newObject.IsValid())
                    {
                        targetObject?.Dispose();
                        targetObject = null;
                        return;
                    }

                    //If image is the same, make sure keep the image for copying action
                    if (targetObject != newObject)
                    {
                        targetObject?.Dispose();
                        targetObject = null;
                    }

                    //Copy the new image
                    targetObject = newObject.Clone();
                }
                else if (mode == _setHObjectMode.Replace)
                {
                    if (targetObject == null) targetObject = newObject;
                    else if (targetObject == newObject) return;
                    else
                    {
                        targetObject?.Dispose();
                        targetObject = newObject;
                    }

                }

            }
            catch (Exception e)
            {
                e.TraceException("csHalconHelper.SetHalconImage");
            }
        }

        /// <summary>
        /// Replace the image with different mode
        /// </summary>
        /// <param name="targetImage"></param>
        /// <param name="newImage"></param>
        /// <param name="lockObject"></param>
        /// <param name="mode"></param>
        public static void SetHalconImage(ref HObject targetImage, HObject newImage, object lockObject, _setHObjectMode mode)
        {
            try
            {
                lock (lockObject)
                {
                    if (mode == _setHObjectMode.DeepCopy)
                    {
                        //Verify source
                        if (newImage == null || !newImage.IsValid())
                        {
                            targetImage?.Dispose();
                            targetImage = null;
                            return;
                        }

                        //If image is the same, make sure keep the image for copying action
                        if (targetImage != newImage)
                        {
                            targetImage?.Dispose();
                            targetImage = null;
                        }

                        //Copy the new image
                        HOperatorSet.CopyImage(newImage, out targetImage);
                    }
                    else if (mode == _setHObjectMode.Replace)
                    {
                        if (targetImage == null) targetImage = newImage;
                        else if (targetImage == newImage) return;
                        else
                        {
                            targetImage?.Dispose();
                            targetImage = newImage;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                e.TraceException("csHalconHelper.SetHalconImage");
            }
        }

        /// <summary>
        /// Exported
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="ho_ImageExpand"></param>
        /// <param name="hv_PaddingSize"></param>
        public static void ExpandImage(HObject ho_Image, out HObject ho_ImageExpand, HTuple hv_PaddingSize)
        {




            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_ImageFull, ho_Border, ho_CrossLeft1;
            HObject ho_CrossLeft2, ho_ImagePartLeft, ho_ImageMirrorLeft;
            HObject ho_CrossRight1, ho_CrossRight2, ho_ImagePartRight;
            HObject ho_ImageMirrorRight, ho_CrossTop1, ho_ImagePartTop;
            HObject ho_ImageMirrorTop, ho_CrossBottom1, ho_CrossBottom2;
            HObject ho_ImagePartBottom, ho_ImageMirrorBottom, ho_CrossLT1;
            HObject ho_CrossLT2, ho_ImagePartLT, ho_ImageMirrorLT, ho_CrossRT1;
            HObject ho_CrossRT2, ho_ImagePartRT, ho_ImageMirrorRT, ho_CrossLB1;
            HObject ho_CrossLB2, ho_ImagePartLB, ho_ImageMirrorLB, ho_CrossRB1;
            HObject ho_CrossRB2, ho_ImagePartRB, ho_ImageMirrorRB;

            // Local control variables 

            HTuple hv_Rows = new HTuple(), hv_Columns = new HTuple();
            HTuple hv_Grayval = new HTuple(), hv_Width = new HTuple();
            HTuple hv_Height = new HTuple(), hv_WidthExpand = new HTuple();
            HTuple hv_HeightExpand = new HTuple(), hv_LeftSideRow1 = new HTuple();
            HTuple hv_LeftSideColumn1 = new HTuple(), hv_LeftSideRow2 = new HTuple();
            HTuple hv_LeftSideColumn2 = new HTuple(), hv_RowsMirrorLeft = new HTuple();
            HTuple hv_ColumnsMirrorLeft = new HTuple(), hv_GrayvalLeftMirror = new HTuple();
            HTuple hv_rightSideRow1 = new HTuple(), hv_rightSideColumn1 = new HTuple();
            HTuple hv_rightSideRow2 = new HTuple(), hv_rightSideColumn2 = new HTuple();
            HTuple hv_RowsMirrorRight = new HTuple(), hv_ColumnsMirrorRight = new HTuple();
            HTuple hv_GrayvalRightMirror = new HTuple(), hv_topSideRow1 = new HTuple();
            HTuple hv_topSideColumn1 = new HTuple(), hv_topSideRow2 = new HTuple();
            HTuple hv_topSideColumn2 = new HTuple(), hv_RowsMirrorTop = new HTuple();
            HTuple hv_ColumnsMirrorTop = new HTuple(), hv_GrayvalTopMirror = new HTuple();
            HTuple hv_bottomSideRow1 = new HTuple(), hv_bottomSideColumn1 = new HTuple();
            HTuple hv_bottomSideRow2 = new HTuple(), hv_bottomSideColumn2 = new HTuple();
            HTuple hv_RowsMirrorBottom = new HTuple(), hv_ColumnsMirrorBottom = new HTuple();
            HTuple hv_GrayvalBottomMirror = new HTuple(), hv_cornerLTRow1 = new HTuple();
            HTuple hv_cornerLTColumn1 = new HTuple(), hv_cornerLTRow2 = new HTuple();
            HTuple hv_cornerLTColumn2 = new HTuple(), hv_RowsMirrorLT = new HTuple();
            HTuple hv_ColumnsMirrorLT = new HTuple(), hv_GrayvalLTMirror = new HTuple();
            HTuple hv_cornerRTRow1 = new HTuple(), hv_cornerRTColumn1 = new HTuple();
            HTuple hv_cornerRTRow2 = new HTuple(), hv_cornerRTColumn2 = new HTuple();
            HTuple hv_RowsMirrorRT = new HTuple(), hv_ColumnsMirrorRT = new HTuple();
            HTuple hv_GrayvalRTMirror = new HTuple(), hv_cornerLBRow1 = new HTuple();
            HTuple hv_cornerLBColumn1 = new HTuple(), hv_cornerLBRow2 = new HTuple();
            HTuple hv_cornerLBColumn2 = new HTuple(), hv_RowsMirrorLB = new HTuple();
            HTuple hv_ColumnsMirrorLB = new HTuple(), hv_GrayvalLBMirror = new HTuple();
            HTuple hv_targetRows_LB = new HTuple(), hv_cornerRBRow1 = new HTuple();
            HTuple hv_cornerRBColumn1 = new HTuple(), hv_cornerRBRow2 = new HTuple();
            HTuple hv_cornerRBColumn2 = new HTuple(), hv_RowsMirrorRB = new HTuple();
            HTuple hv_ColumnsMirrorRB = new HTuple(), hv_GrayvalRBMirror = new HTuple();
            HTuple hv_targetRows_RB = new HTuple(), hv_targetColumns_RB = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageExpand);
            HOperatorSet.GenEmptyObj(out ho_ImageFull);
            HOperatorSet.GenEmptyObj(out ho_Border);
            HOperatorSet.GenEmptyObj(out ho_CrossLeft1);
            HOperatorSet.GenEmptyObj(out ho_CrossLeft2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartLeft);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorLeft);
            HOperatorSet.GenEmptyObj(out ho_CrossRight1);
            HOperatorSet.GenEmptyObj(out ho_CrossRight2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartRight);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorRight);
            HOperatorSet.GenEmptyObj(out ho_CrossTop1);
            HOperatorSet.GenEmptyObj(out ho_ImagePartTop);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorTop);
            HOperatorSet.GenEmptyObj(out ho_CrossBottom1);
            HOperatorSet.GenEmptyObj(out ho_CrossBottom2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartBottom);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorBottom);
            HOperatorSet.GenEmptyObj(out ho_CrossLT1);
            HOperatorSet.GenEmptyObj(out ho_CrossLT2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartLT);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorLT);
            HOperatorSet.GenEmptyObj(out ho_CrossRT1);
            HOperatorSet.GenEmptyObj(out ho_CrossRT2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartRT);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorRT);
            HOperatorSet.GenEmptyObj(out ho_CrossLB1);
            HOperatorSet.GenEmptyObj(out ho_CrossLB2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartLB);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorLB);
            HOperatorSet.GenEmptyObj(out ho_CrossRB1);
            HOperatorSet.GenEmptyObj(out ho_CrossRB2);
            HOperatorSet.GenEmptyObj(out ho_ImagePartRB);
            HOperatorSet.GenEmptyObj(out ho_ImageMirrorRB);
            //Paint origin image
            hv_Rows.Dispose(); hv_Columns.Dispose();
            HOperatorSet.GetRegionPoints(ho_Image, out hv_Rows, out hv_Columns);
            hv_Grayval.Dispose();
            HOperatorSet.GetGrayval(ho_Image, hv_Rows, hv_Columns, out hv_Grayval);
            hv_Width.Dispose(); hv_Height.Dispose();
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

            //Create an expanded image
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                ho_ImageExpand.Dispose();
                HOperatorSet.GenImageConst(out ho_ImageExpand, "byte", hv_Width + (hv_PaddingSize * 2),
                    hv_Height + (hv_PaddingSize * 2));
            }
            hv_WidthExpand.Dispose(); hv_HeightExpand.Dispose();
            HOperatorSet.GetImageSize(ho_ImageExpand, out hv_WidthExpand, out hv_HeightExpand);
            if (HDevWindowStack.IsOpen())
            {
                //dev_display (ImageExpand)
            }
            //stop ()
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, hv_Rows + hv_PaddingSize, hv_Columns + hv_PaddingSize,
                    hv_Grayval);
            }
            //stop ()
            //Show image border
            ho_ImageFull.Dispose();
            HOperatorSet.FullDomain(ho_ImageExpand, out ho_ImageFull);
            ho_Border.Dispose();
            HOperatorSet.GetDomain(ho_ImageFull, out ho_Border);
            if (HDevWindowStack.IsOpen())
            {
                //dev_display (Border)
            }
            //stop ()

            //Side-Left
            hv_LeftSideRow1.Dispose();
            hv_LeftSideRow1 = new HTuple(hv_PaddingSize);
            hv_LeftSideColumn1.Dispose();
            hv_LeftSideColumn1 = new HTuple(hv_PaddingSize);
            ho_CrossLeft1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLeft1, hv_LeftSideRow1, hv_LeftSideColumn1,
                6, 0.785398);
            hv_LeftSideRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_LeftSideRow2 = (hv_PaddingSize + hv_Height) - 1;
            }
            hv_LeftSideColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_LeftSideColumn2 = hv_PaddingSize * 2;
            }
            ho_CrossLeft2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLeft2, hv_LeftSideRow2, hv_LeftSideColumn2,
                6, 0.785398);
            ho_ImagePartLeft.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartLeft, hv_LeftSideRow1,
                hv_LeftSideColumn1, hv_LeftSideRow2, hv_LeftSideColumn2);
            ho_ImageMirrorLeft.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartLeft, out ho_ImageMirrorLeft, "column");
            hv_RowsMirrorLeft.Dispose(); hv_ColumnsMirrorLeft.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorLeft, out hv_RowsMirrorLeft, out hv_ColumnsMirrorLeft);
            hv_GrayvalLeftMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorLeft, hv_RowsMirrorLeft, hv_ColumnsMirrorLeft,
                out hv_GrayvalLeftMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, hv_RowsMirrorLeft + hv_PaddingSize, hv_ColumnsMirrorLeft,
                    hv_GrayvalLeftMirror);
            }
            //stop ()

            //Side-Right
            hv_rightSideRow1.Dispose();
            hv_rightSideRow1 = new HTuple(hv_PaddingSize);
            hv_rightSideColumn1.Dispose();
            hv_rightSideColumn1 = new HTuple(hv_Width);
            ho_CrossRight1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRight1, hv_rightSideRow1, hv_rightSideColumn1,
                6, 0.785398);
            hv_rightSideRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_rightSideRow2 = (hv_PaddingSize + hv_Height) - 1;
            }
            hv_rightSideColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_rightSideColumn2 = (hv_PaddingSize + hv_Width) - 1;
            }
            ho_CrossRight2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRight2, hv_rightSideRow2, hv_rightSideColumn2,
                6, 0.785398);
            ho_ImagePartRight.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartRight, hv_rightSideRow1,
                hv_rightSideColumn1, hv_rightSideRow2, hv_rightSideColumn2);
            ho_ImageMirrorRight.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartRight, out ho_ImageMirrorRight, "column");
            hv_RowsMirrorRight.Dispose(); hv_ColumnsMirrorRight.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorRight, out hv_RowsMirrorRight, out hv_ColumnsMirrorRight);
            hv_GrayvalRightMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorRight, hv_RowsMirrorRight, hv_ColumnsMirrorRight,
                out hv_GrayvalRightMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, hv_RowsMirrorRight + hv_PaddingSize, (hv_ColumnsMirrorRight + hv_PaddingSize) + hv_Width,
                    hv_GrayvalRightMirror);
            }
            //stop ()

            //Side-Top
            hv_topSideRow1.Dispose();
            hv_topSideRow1 = new HTuple(hv_PaddingSize);
            hv_topSideColumn1.Dispose();
            hv_topSideColumn1 = new HTuple(hv_PaddingSize);
            ho_CrossTop1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossTop1, hv_topSideRow1, hv_topSideColumn1,
                6, 0.785398);
            hv_topSideRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_topSideRow2 = hv_PaddingSize * 2;
            }
            hv_topSideColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_topSideColumn2 = (hv_PaddingSize + hv_Width) - 1;
            }
            ho_CrossRight2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRight2, hv_topSideRow2, hv_topSideColumn2,
                6, 0.785398);
            ho_ImagePartTop.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartTop, hv_topSideRow1,
                hv_topSideColumn1, hv_topSideRow2, hv_topSideColumn2);
            ho_ImageMirrorTop.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartTop, out ho_ImageMirrorTop, "row");
            hv_RowsMirrorTop.Dispose(); hv_ColumnsMirrorTop.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorTop, out hv_RowsMirrorTop, out hv_ColumnsMirrorTop);
            hv_GrayvalTopMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorTop, hv_RowsMirrorTop, hv_ColumnsMirrorTop,
                out hv_GrayvalTopMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, hv_RowsMirrorTop, hv_ColumnsMirrorTop + hv_PaddingSize,
                    hv_GrayvalTopMirror);
            }
            //stop ()

            //Side-Bottom
            hv_bottomSideRow1.Dispose();
            hv_bottomSideRow1 = new HTuple(hv_Height);
            hv_bottomSideColumn1.Dispose();
            hv_bottomSideColumn1 = new HTuple(hv_PaddingSize);
            ho_CrossBottom1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossBottom1, hv_bottomSideRow1, hv_bottomSideColumn1,
                6, 0.785398);
            hv_bottomSideRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_bottomSideRow2 = (hv_Height + hv_PaddingSize) - 1;
            }
            hv_bottomSideColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_bottomSideColumn2 = (hv_PaddingSize + hv_Width) - 1;
            }
            ho_CrossBottom2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossBottom2, hv_bottomSideRow2, hv_bottomSideColumn2,
                6, 0.785398);
            ho_ImagePartBottom.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartBottom, hv_bottomSideRow1,
                hv_bottomSideColumn1, hv_bottomSideRow2, hv_bottomSideColumn2);
            ho_ImageMirrorBottom.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartBottom, out ho_ImageMirrorBottom, "row");
            hv_RowsMirrorBottom.Dispose(); hv_ColumnsMirrorBottom.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorBottom, out hv_RowsMirrorBottom, out hv_ColumnsMirrorBottom);
            hv_GrayvalBottomMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorBottom, hv_RowsMirrorBottom, hv_ColumnsMirrorBottom,
                out hv_GrayvalBottomMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, (hv_RowsMirrorBottom + hv_PaddingSize) + hv_Height,
                    hv_ColumnsMirrorBottom + hv_PaddingSize, hv_GrayvalBottomMirror);
            }
            //stop ()

            //Corner:LT
            hv_cornerLTRow1.Dispose();
            hv_cornerLTRow1 = new HTuple(hv_PaddingSize);
            hv_cornerLTColumn1.Dispose();
            hv_cornerLTColumn1 = new HTuple(hv_PaddingSize);
            ho_CrossLT1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLT1, hv_cornerLTRow1, hv_cornerLTColumn1,
                6, 0.785398);
            hv_cornerLTRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerLTRow2 = (hv_PaddingSize * 2) - 1;
            }
            hv_cornerLTColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerLTColumn2 = (hv_PaddingSize * 2) - 1;
            }
            ho_CrossLT2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLT2, hv_cornerLTRow2, hv_cornerLTColumn2,
                6, 0.785398);
            ho_ImagePartLT.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartLT, hv_cornerLTRow1,
                hv_cornerLTColumn1, hv_cornerLTRow2, hv_cornerLTColumn2);
            ho_ImageMirrorLT.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartLT, out ho_ImageMirrorLT, "column");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.MirrorImage(ho_ImageMirrorLT, out ExpTmpOutVar_0, "row");
                ho_ImageMirrorLT.Dispose();
                ho_ImageMirrorLT = ExpTmpOutVar_0;
            }
            hv_RowsMirrorLT.Dispose(); hv_ColumnsMirrorLT.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorLT, out hv_RowsMirrorLT, out hv_ColumnsMirrorLT);
            hv_GrayvalLTMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorLT, hv_RowsMirrorLT, hv_ColumnsMirrorLT,
                out hv_GrayvalLTMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            HOperatorSet.SetGrayval(ho_ImageExpand, hv_RowsMirrorLT, hv_ColumnsMirrorLT,
                hv_GrayvalLTMirror);
            //stop ()

            //Corner:RT
            hv_cornerRTRow1.Dispose();
            hv_cornerRTRow1 = new HTuple(hv_PaddingSize);
            hv_cornerRTColumn1.Dispose();
            hv_cornerRTColumn1 = new HTuple(hv_Width);
            ho_CrossRT1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRT1, hv_cornerRTRow1, hv_cornerRTColumn1,
                6, 0.785398);
            hv_cornerRTRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerRTRow2 = (hv_PaddingSize * 2) - 1;
            }
            hv_cornerRTColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerRTColumn2 = (hv_PaddingSize + hv_Width) - 1;
            }
            ho_CrossRT2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRT2, hv_cornerRTRow2, hv_cornerRTColumn2,
                6, 0.785398);
            ho_ImagePartRT.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartRT, hv_cornerRTRow1,
                hv_cornerRTColumn1, hv_cornerRTRow2, hv_cornerRTColumn2);
            ho_ImageMirrorRT.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartRT, out ho_ImageMirrorRT, "column");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.MirrorImage(ho_ImageMirrorRT, out ExpTmpOutVar_0, "row");
                ho_ImageMirrorRT.Dispose();
                ho_ImageMirrorRT = ExpTmpOutVar_0;
            }
            hv_RowsMirrorRT.Dispose(); hv_ColumnsMirrorRT.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorRT, out hv_RowsMirrorRT, out hv_ColumnsMirrorRT);
            hv_GrayvalRTMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorRT, hv_RowsMirrorRT, hv_ColumnsMirrorRT,
                out hv_GrayvalRTMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                HOperatorSet.SetGrayval(ho_ImageExpand, hv_RowsMirrorRT, (hv_ColumnsMirrorRT + hv_Width) + hv_PaddingSize,
                    hv_GrayvalRTMirror);
            }
            //stop ()

            //Corner:LB
            hv_cornerLBRow1.Dispose();
            hv_cornerLBRow1 = new HTuple(hv_Height);
            hv_cornerLBColumn1.Dispose();
            hv_cornerLBColumn1 = new HTuple(hv_PaddingSize);
            ho_CrossLB1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLB1, hv_cornerLBRow1, hv_cornerLBColumn1,
                10, 0.785398);
            hv_cornerLBRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerLBRow2 = (hv_PaddingSize + hv_Height) - 1;
            }
            hv_cornerLBColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerLBColumn2 = (hv_PaddingSize * 2) - 1;
            }
            ho_CrossLB2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossLB2, hv_cornerLBRow2, hv_cornerLBColumn2,
                10, 0.785398);
            ho_ImagePartLB.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartLB, hv_cornerLBRow1,
                hv_cornerLBColumn1, hv_cornerLBRow2, hv_cornerLBColumn2);
            ho_ImageMirrorLB.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartLB, out ho_ImageMirrorLB, "column");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.MirrorImage(ho_ImageMirrorLB, out ExpTmpOutVar_0, "row");
                ho_ImageMirrorLB.Dispose();
                ho_ImageMirrorLB = ExpTmpOutVar_0;
            }
            hv_RowsMirrorLB.Dispose(); hv_ColumnsMirrorLB.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorLB, out hv_RowsMirrorLB, out hv_ColumnsMirrorLB);
            hv_GrayvalLBMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorLB, hv_RowsMirrorLB, hv_ColumnsMirrorLB,
                out hv_GrayvalLBMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            hv_targetRows_LB.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_targetRows_LB = (hv_RowsMirrorLB + hv_PaddingSize) + hv_Height;
            }
            HOperatorSet.SetGrayval(ho_ImageExpand, hv_targetRows_LB, hv_ColumnsMirrorLB,
                hv_GrayvalLBMirror);
            //stop ()

            //Corner:RB
            hv_cornerRBRow1.Dispose();
            hv_cornerRBRow1 = new HTuple(hv_Height);
            hv_cornerRBColumn1.Dispose();
            hv_cornerRBColumn1 = new HTuple(hv_Width);
            ho_CrossRB1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRB1, hv_cornerRBRow1, hv_cornerRBColumn1,
                10, 0.785398);
            hv_cornerRBRow2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerRBRow2 = (hv_PaddingSize + hv_Height) - 1;
            }
            hv_cornerRBColumn2.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_cornerRBColumn2 = (hv_PaddingSize + hv_Width) - 1;
            }
            ho_CrossRB2.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_CrossRB2, hv_cornerRBRow2, hv_cornerRBColumn2,
                10, 0.785398);
            ho_ImagePartRB.Dispose();
            HOperatorSet.CropRectangle1(ho_ImageExpand, out ho_ImagePartRB, hv_cornerRBRow1,
                hv_cornerRBColumn1, hv_cornerRBRow2, hv_cornerRBColumn2);
            ho_ImageMirrorRB.Dispose();
            HOperatorSet.MirrorImage(ho_ImagePartRB, out ho_ImageMirrorRB, "column");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.MirrorImage(ho_ImageMirrorRB, out ExpTmpOutVar_0, "row");
                ho_ImageMirrorRB.Dispose();
                ho_ImageMirrorRB = ExpTmpOutVar_0;
            }
            hv_RowsMirrorRB.Dispose(); hv_ColumnsMirrorRB.Dispose();
            HOperatorSet.GetRegionPoints(ho_ImageMirrorRB, out hv_RowsMirrorRB, out hv_ColumnsMirrorRB);
            hv_GrayvalRBMirror.Dispose();
            HOperatorSet.GetGrayval(ho_ImageMirrorRB, hv_RowsMirrorRB, hv_ColumnsMirrorRB,
                out hv_GrayvalRBMirror);
            //Paint back to origin
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(ho_ImageExpand, HDevWindowStack.GetActive());
            }
            hv_targetRows_RB.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_targetRows_RB = ((hv_RowsMirrorRB + hv_PaddingSize) + hv_Height) - 1;
            }
            hv_targetColumns_RB.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_targetColumns_RB = ((hv_ColumnsMirrorRB + hv_PaddingSize) + hv_Width) - 1;
            }
            HOperatorSet.SetGrayval(ho_ImageExpand, hv_targetRows_RB, hv_targetColumns_RB,
                hv_GrayvalRBMirror);
            //stop ()
        }

        public static void UnionRegion(ref HObject regionBase, HObject regionAppend)
        {//
            if (regionAppend.IsRegion() != true) return;

 
            if (regionBase.IsRegion() == true)
            {
                HOperatorSet.Union2(regionBase, regionAppend, out HObject regionUnion);
                regionBase.Dispose();
                regionBase = regionUnion;
            }
            else
            {
                regionBase?.Dispose();
                regionBase = null;
                regionBase = regionAppend.Clone();
            }
        }

        /// <summary>
        /// Byte image to Hobject
        /// </summary>
        /// <param name="bImage"></param>
        /// <returns></returns>
        public static HObject BinaryImage2HalconImage(byte[] bImage)
        {
            HObject ho_Image = null;

            try
            {
                if (bImage == null) return null;

                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    stream.Write(bImage, 0, bImage.Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    ho_Image = (HObject)formatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconWindow.LoadBinaryImage:\r\n" + ex.Message);
                return null;
            }

            //Pass all steps
            return ho_Image;
        }

        public static byte[] HalconImage2ByteArray(HObject ho_Image)
        {
            if (ho_Image == null) return null;

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, ho_Image);
                return stream.ToArray();
            }
        }


        public static Bitmap Hobject2BitmapSize(HObject sourceImage, float maxWidth = 600f, float maxHeight = 400f)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {

                if (!sourceImage.IsValid()) return null;

                HOperatorSet.GetImageSize(sourceImage, out HTuple width, out HTuple height);

                double fZoom = 1;

                //Check width
                if (width > maxWidth) fZoom = maxWidth / width;

                //Check height
                if (height > maxHeight)
                {
                    var heightZoom = maxHeight / height;
                    if (heightZoom < fZoom) fZoom = heightZoom;
                }

                //Zoom the image
                HObject imageProcess = sourceImage;
                if (fZoom != 1)
                {
                    HOperatorSet.ZoomImageFactor(sourceImage, out HObject imageZoomed, fZoom, fZoom, "constant");
                    imageProcess = imageZoomed;
                }

                var result = Hobject2BitmapV2(imageProcess);
                HOperatorSet.GetImageSize(imageProcess, out HTuple hWidth, out HTuple hHeight);
                stopwatch.Stop();
                $"Hobject2BitmapSize({width.I}x{height.I},{hWidth.D}x{hHeight.D}):{stopwatch.ElapsedMilliseconds}ms".TraceRecord();
                return result;

            }
            catch (Exception ex)
            {
                ex.TraceException($"Hobject2BitmapSize({maxWidth},{maxHeight})");
                return null;
            }
        }


        /// <summary>
        /// Convert halcon image to bitmap
        /// Solve the memory access issue
        /// </summary>
        /// <param name="sourceImage"></param>
        /// <returns></returns>
        public static Bitmap Hobject2BitmapV2(HObject sourceImage)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                if (sourceImage == null || !sourceImage.IsInitialized()) return null;

                //Check image type
                HOperatorSet.CountChannels(sourceImage, out HTuple hv_Channels);

                //Get Image size
                HOperatorSet.GetImageSize(sourceImage, out HTuple width0, out HTuple height0);


                //Mono Image
                HObject imageRGB;
                if (hv_Channels.L == 1)
                {
                    //Convert gray scale image to color image
                    //bmp image are 3 channel image
                    HOperatorSet.Compose3(sourceImage, sourceImage, sourceImage, out imageRGB);
                }
                //Color image
                else if (hv_Channels.L >= 3)
                {
                    //Force to 3 channels image
                    HOperatorSet.Decompose3(sourceImage, out HObject image1, out HObject image2, out HObject image3);
                    HOperatorSet.Compose3(image1, image2, image3, out imageRGB);
                }
                else return null;

                if (imageRGB == null) return null;
                //Get data pointer
                HOperatorSet.GetImagePointer3(imageRGB, out HTuple pointerRed, out HTuple pointerGreen,
                    out HTuple pointerBlue, out HTuple type, out HTuple width, out HTuple height);

                //create new image
                Bitmap bmpImage = new Bitmap(width.I, height.I, PixelFormat.Format32bppArgb);

                BitmapData bitmapData = bmpImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);
                unsafe
                {
                    //Get new image address
                    byte* bNew = (byte*)bitmapData.Scan0;

                    //Get old image address
                    byte* r = ((byte*)pointerRed.L);
                    byte* g = ((byte*)pointerGreen.L);
                    byte* b = ((byte*)pointerBlue.L);



                    int iPixels = width * height;
                    for (int i = 0; i < iPixels; i++)
                    {
                        bNew[i * 4] = (b)[i]; //B
                        bNew[i * 4 + 1] = (g)[i]; //G
                        bNew[i * 4 + 2] = (r)[i]; //R
                        bNew[i * 4 + 3] = 255; //Transparency   
                    }
                }

                bmpImage.UnlockBits(bitmapData);
                stopwatch.Stop();
                //Trace.WriteLine($"Hobject2BitmapV2({bmpImage.Width}x{bmpImage.Height}):{stopwatch.ElapsedMilliseconds}ms");
                return bmpImage;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Hobject2Bitmap:\r\n" + ex.Message);
                return null;
            }

        }

        /// <summary>
        /// Tranform point to a new point based on mapping matrix
        /// </summary>
        /// <param name="point"></param>
        /// <param name="mappingMatrix"></param>
        /// <returns></returns>
        public static HalconPoint MapPoint(HalconPoint point, HTuple mappingMatrix)
        {
            try
            {
                HOperatorSet.AffineTransPoint2d(mappingMatrix, point.Row, point.Column, out HTuple rowOut,
                    out HTuple colOut);
                var newPoint = new HalconPoint(rowOut, colOut);
                return newPoint;
            }
            catch (Exception)
            {

                return null;
            }
        }



        /// <summary>
        /// Manual method 50~100 times faster
        /// Use c# loop instead of halcon internal method
        /// </summary>
        /// <param name="ho_SourceImage"></param>
        /// <param name="ho_ProcessedImages"></param>
        /// <param name="hv_DivisionNum"></param>
        public static HImage[] DivideImageSharp3(HImage ho_SourceImage, int iDivisionNum)
        {
            //Init variables
            HImage[] ho_ProcessedImages = new HImage[iDivisionNum];
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DivideImageSharp2.Enter");

            try
            {
                //Get all points
                var imagePointer = ho_SourceImage.GetImagePointer1(out string sType, out int iWidth, out int iHeight);
                List<(byte[] ImageData, int Height)> imageBufferList = PrepareImageButter(iWidth, iHeight, iDivisionNum);
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DivideImageSharp2.DataSet.Prepared");

                unsafe
                {
                    byte* bytePointer = (byte*)imagePointer;

                    Parallel.For(0, iDivisionNum, (iImageIndex) =>
                    {
                        //Init 
                        var BufferCurrent = imageBufferList[iImageIndex].ImageData;
                        var iDivHeight = imageBufferList[iImageIndex].Height;

                        //Copy data to buffer line by line
                        for (int iLine = iImageIndex, iLineCount = 0; iLine < iHeight; iLine += iDivisionNum, iLineCount++)
                        {
                            fixed (byte* currentData = BufferCurrent)
                            {
                                byte* sourceStart = bytePointer + iLine * iWidth;
                                byte* destinationStart = currentData + iLineCount * iWidth;
                                Buffer.MemoryCopy(sourceStart, destinationStart, iWidth, iWidth);
                            }
                        }

                        //Create image in the thread
                        fixed (byte* pBuffer = BufferCurrent)
                        {
                            IntPtr ptr = (IntPtr)pBuffer;
                            HImage fImage = new HImage("byte", iWidth, iDivHeight, ptr);
                            ho_ProcessedImages[iImageIndex] = fImage;
                        }

                    });
                }

                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DivideImageSharp2.Image.Generated");

            }
            catch (Exception ex)
            {
                //Always show exception
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DivideImageSharp.Exception:\r\n{ex.Message}");
                return null;
            }

            return ho_ProcessedImages;
        }

        private static List<(byte[] ImageData, int Height)> PrepareImageButter(int iWidth, int iHeight, int iDivisionNum)
        {

            //Get size of the images         
            int iHeightAvg = iHeight / iDivisionNum;
            int iExtraLines = iHeight % iDivisionNum;
            List<(byte[] ImageData, int Height)> imageBufferList = new List<(byte[] ImageData, int Height)>();

            for (int i = 0; i < iDivisionNum; i++)
            {
                int iSubImageHeight = 0;
                int iPixels = 0;

                //Get height of each images
                if (i >= iExtraLines) iSubImageHeight = iHeightAvg;
                else iSubImageHeight = iHeightAvg + 1;

                //Prepare buffer list
                iPixels = iSubImageHeight * iWidth;
                imageBufferList.Add((new byte[iPixels], iSubImageHeight));
            }

            return imageBufferList;
        }

        /// <summary>
        /// Get the angle from (0,0) to point (x,y)
        /// Get degree from 0~ +180 and 0~ -180
        /// </summary>
        /// <returns></returns>
        public static double GetPointAngle(HalconPoint point)
        {
            try
            {
                //Line orientation result is -90 to 90
                HOperatorSet.LineOrientation(0, 0, point.Row, point.Column, out HTuple phi);

                //Convert angle result from -90 ~ +90 to -180 ~ +180
                //Get angle in different quadrant
                if ((point.Row > 0 && point.Column > 0) ||
                    (point.Row < 0 && point.Column > 0))
                {
                    return phi.TupleDeg();
                }
                else if (point.Row > 0 && point.Column < 0)
                {
                    return phi.TupleDeg() - 180;
                }
                else if (point.Row < 0 && point.Column < 0)
                {
                    //180-(-phi.TupleDeg())
                    return 180 + phi.TupleDeg();
                }
                else return 0;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Get the center of two angles
        /// Result is -180 to +180
        /// </summary>
        /// <param name="angle1"></param>
        /// <param name="angle2"></param>
        /// <returns></returns>
        public static double GetAngleCenter(double angle1, double angle2)
        {
            if (angle1 == 0 && angle2 == 0) return 0;

            //Both angle in range 0 ~ +180
            if (angle1 > 0 && angle2 > 0)
            {
                var offset = Math.Abs(angle1 - angle2);
                return Math.Min(angle1, angle2) + offset / 2;
            }
            //Both angle in range 0 ~ -180
            else if (angle1 < 0 && angle2 < 0)
            {
                var offset = Math.Abs(angle1 - angle2);
                return Math.Max(angle1, angle2) - offset / 2;
            }
            //One angle is 0 ~ 180 and another is 0 ~ -180
            else if ((angle1 > 0 && angle2 < 0) ||
                     (angle1 < 0 && angle2 > 0))
            {
                var absAngle1 = Math.Abs(angle1);
                var absAngle2 = Math.Abs(angle2);
                var offset = absAngle1 + absAngle2;
                var positiveAngle = Math.Max(angle1, angle2);

                //Angle difference is smaller than 180, center angle is on right side
                if (offset < 180)
                {
                    return positiveAngle - offset / 2;
                }
                //Angle difference is bigger than 180, center angle is on left side
                else if (offset > 180)
                {
                    //Get angle on another side
                    var oppositeAngle1 = 180 - absAngle1;
                    var oppositeAngle2 = 180 - absAngle2;
                    var oppositeRangle = oppositeAngle1 + oppositeAngle2;
                    var resultAngle = positiveAngle + oppositeRangle / 2;

                    //Convert result angle to with in 0~180 to 0~-180
                    if (resultAngle > 180)
                    {
                        //-(180- (actual - 180))
                        return resultAngle - 360;
                    }
                    //Actual<180
                    else return resultAngle;
                }
                else return 0;
            }
            else return 0;
        }

        public static HalconPoint GetLinesIntersection(csLineData line1, csLineData line2)
        {
            try
            {
                if (line1 == null ||
                    line2 == null ||
                    !line1.IsInit ||
                    !line2.IsInit)
                {
                    Trace.WriteLine($"csHalconCommon.GetLinesIntersection: Invalid source line.");
                    return null;
                }

                //Get intersection
                HOperatorSet.IntersectionLines(line1.Row1, line1.Column1, line1.Row2, line1.Column2,
                                               line2.Row1, line2.Column1, line2.Row2, line2.Column2,
                                               out HTuple RowInter, out HTuple ColumnInter, out HTuple IsOverlapping);

                if (RowInter.Length == 0)
                {
                    Trace.WriteLine($"csHalconCommon.GetLinesIntersection: No intersection found.");
                    return null;
                }

                //Save position
                HalconPoint pIntersection = new HalconPoint(RowInter.D, ColumnInter.D);
                return pIntersection;
            }
            catch (Exception ex)
            {
                ex.TraceException("csHalconCommon.GetLinesIntersection");
                return null;
            }

        }

        public static void GetTextOrderCommand(_textOrder textOrder, out string sOrder, out string sRowOrColumn)
        {
            sOrder = "true";
            sRowOrColumn = "row";

            switch (textOrder)
            {
                case _textOrder.Left2RightTop2Bottom:
                    sOrder = "true";
                    sRowOrColumn = "row";
                    break;
                case _textOrder.Right2LeftBottom2Top:
                    sOrder = "false";
                    sRowOrColumn = "row";
                    break;
                case _textOrder.Top2BottomLeft2Right:
                    sOrder = "true";
                    sRowOrColumn = "column";
                    break;
                case _textOrder.Bottom2TopRight2Left:
                    sOrder = "false";
                    sRowOrColumn = "column";
                    break;
                default:
                    break;
            }
        }

        public static Rectangle2Data CreateImageSampleRegion(HObject image)
        {
            HOperatorSet.GetImageSize(image, out HTuple hWidth, out HTuple hHeight);


            var drawObject = new Rectangle2Data()
            {
                Row = (float)(hHeight.D) / 2f,
                Column = (float)(hWidth.D) / 2f,
                Phi = 0,
                Length1 = (float)(hWidth.D) / 4f,
                Length2 = (float)(hHeight.D) / 4f,
                IsInit = true
            };

            return drawObject;
        }


        public static List<string> ToValue()
        {
            var list = new List<string>();
            return list;
        }



        public static List<string> GetAccDevices()
        {
            var deviceList = new List<string>();

            try
            {
                HOperatorSet.QueryAvailableComputeDevices(out HTuple deviceIdentifier);
                if (deviceIdentifier == null || deviceIdentifier.Length == 0) return deviceList;

                for (int i = 0; i < deviceIdentifier.Length; i++)
                {
                    HOperatorSet.GetComputeDeviceInfo(deviceIdentifier[i], "name", out HTuple deviceName);
                    deviceList.Add(deviceName.S);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("TryGetAccDevices:\r\n" + ex.Message);
            }

            return deviceList;
        }


        /// <summary>
        /// Notice:
        /// This call should in a clean thread
        /// If other thread is using halcon, this command will cause exception.
        /// Make sure to close all cameras before project start.
        /// </summary>
        /// <param name="iThreadNumber"></param>
        public static void SetThreadNumberLimit(int iThreadNumber)
        {
            try
            {

                //Get current setting before apply settings again
                var value = HSystem.GetSystem("thread_num");

                if (iThreadNumber < 1)
                {
                    //Skip setting if value is the same
                    if (value.Type == HTupleType.STRING && value.S == "default") return;

                    HOperatorSet.SetSystem("thread_num", "default");
                }
                else
                {
                    if (iThreadNumber > Environment.ProcessorCount)
                    {
                        iThreadNumber = Environment.ProcessorCount - 1;
                        if (iThreadNumber < 1) iThreadNumber = 1;
                    }

                    //Skip setting if value is the same
                    if ((value.Type == HTupleType.INTEGER || value.Type == HTupleType.LONG)
                        && value.I == iThreadNumber) return;

                    HOperatorSet.SetSystem("thread_num", iThreadNumber);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"SetThreadNumberLimit:({iThreadNumber},{Environment.ProcessorCount})\r\n" +
                                ex.Message);
            }
        }

        public static HObject ReadImageFile(string sFileName, out string sMessage)
        {
            sMessage = string.Empty;

            try
            {
                if (string.IsNullOrWhiteSpace(sFileName))
                {
                    sMessage = $"The file path is empty.";
                    return null;
                }



                if (!File.Exists(sFileName))
                {
                    sMessage = $"Image file doesn't exist.\r\n{sFileName}";
                    return null;
                }

                HOperatorSet.ReadImage(out HObject image, sFileName);
                return image;
            }
            catch (Exception e)
            {
                e.TraceException($"csHalconCommon.GetImage:{sFileName}");
                return null;
            }
        }

        public static HObject ReadImageFile(string sFilePath)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(sFilePath)) return null;
                if (!File.Exists(sFilePath)) return null;
                HOperatorSet.ReadImage(out HObject image, sFilePath);
                return image;
            }
            catch (Exception e)
            {
                e.TraceException("ReadImageFile");
                return null;
            }
        }

    }
}
