using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconTest
{
    /// <summary>
    /// Halcon buildin methods
    /// </summary>
    public partial class csHalconHelper
    {
        /// <summary>
        /// Automatically generally function
        /// </summary>
        /// <param name="hv_WindowHandle"></param>
        /// <param name="hv_Size"></param>
        /// <param name="hv_Font"></param>
        /// <param name="hv_Bold"></param>
        /// <param name="hv_Slant"></param>
        // Chapter: Graphics / Text
        // Short Description: Set font independent of OS 
        public static void set_display_font(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
            HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_Style = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_AvailableFonts = new HTuple(), hv_Fdx = new HTuple();
            HTuple hv_Indices = new HTuple();
            HTuple hv_Font_COPY_INP_TMP = new HTuple(hv_Font);
            HTuple hv_Size_COPY_INP_TMP = new HTuple(hv_Size);

            // Initialize local and output iconic variables 
            try
            {
                //This procedure sets the text font of the current window with
                //the specified attributes.
                //
                //Input parameters:
                //WindowHandle: The graphics window for which the font will be set
                //Size: The font size. If Size=-1, the default of 16 is used.
                //Bold: If set to 'true', a bold font is used
                //Slant: If set to 'true', a slanted font is used
                //
                hv_OS.Dispose();
                HOperatorSet.GetSystem("operating_system", out hv_OS);
                if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                        new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
                {
                    hv_Size_COPY_INP_TMP.Dispose();
                    hv_Size_COPY_INP_TMP = 16;
                }

                if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
                {
                    //Restore previous behaviour
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                                ExpTmpLocalVar_Size = ((1.13677 * hv_Size_COPY_INP_TMP)).TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }
                else
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                                ExpTmpLocalVar_Size = hv_Size_COPY_INP_TMP.TupleInt()
                                ;
                            hv_Size_COPY_INP_TMP.Dispose();
                            hv_Size_COPY_INP_TMP = ExpTmpLocalVar_Size;
                        }
                    }
                }

                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Courier";
                    hv_Fonts[1] = "Courier 10 Pitch";
                    hv_Fonts[2] = "Courier New";
                    hv_Fonts[3] = "CourierNew";
                    hv_Fonts[4] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Consolas";
                    hv_Fonts[1] = "Menlo";
                    hv_Fonts[2] = "Courier";
                    hv_Fonts[3] = "Courier 10 Pitch";
                    hv_Fonts[4] = "FreeMono";
                    hv_Fonts[5] = "Liberation Mono";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Luxi Sans";
                    hv_Fonts[1] = "DejaVu Sans";
                    hv_Fonts[2] = "FreeSans";
                    hv_Fonts[3] = "Arial";
                    hv_Fonts[4] = "Liberation Sans";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Times New Roman";
                    hv_Fonts[1] = "Luxi Serif";
                    hv_Fonts[2] = "DejaVu Serif";
                    hv_Fonts[3] = "FreeSerif";
                    hv_Fonts[4] = "Utopia";
                    hv_Fonts[5] = "Liberation Serif";
                }
                else
                {
                    hv_Fonts.Dispose();
                    hv_Fonts = new HTuple(hv_Font_COPY_INP_TMP);
                }

                hv_Style.Dispose();
                hv_Style = "";
                if ((int)(new HTuple(hv_Bold.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                                ExpTmpLocalVar_Style = hv_Style + "Bold";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Bold.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }

                if ((int)(new HTuple(hv_Slant.TupleEqual("true"))) != 0)
                {
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                                ExpTmpLocalVar_Style = hv_Style + "Italic";
                            hv_Style.Dispose();
                            hv_Style = ExpTmpLocalVar_Style;
                        }
                    }
                }
                else if ((int)(new HTuple(hv_Slant.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception.Dispose();
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }

                if ((int)(new HTuple(hv_Style.TupleEqual(""))) != 0)
                {
                    hv_Style.Dispose();
                    hv_Style = "Normal";
                }

                hv_AvailableFonts.Dispose();
                HOperatorSet.QueryFont(hv_WindowHandle, out hv_AvailableFonts);
                hv_Font_COPY_INP_TMP.Dispose();
                hv_Font_COPY_INP_TMP = "";
                for (hv_Fdx = 0;
                     (int)hv_Fdx <= (int)((new HTuple(hv_Fonts.TupleLength())) - 1);
                     hv_Fdx = (int)hv_Fdx + 1)
                {
                    hv_Indices.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Indices = hv_AvailableFonts.TupleFind(
                            hv_Fonts.TupleSelect(hv_Fdx));
                    }

                    if ((int)(new HTuple((new HTuple(hv_Indices.TupleLength())).TupleGreater(
                            0))) != 0)
                    {
                        if ((int)(new HTuple(((hv_Indices.TupleSelect(0))).TupleGreaterEqual(0))) != 0)
                        {
                            hv_Font_COPY_INP_TMP.Dispose();
                            using (HDevDisposeHelper dh = new HDevDisposeHelper())
                            {
                                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(
                                    hv_Fdx);
                            }

                            break;
                        }
                    }
                }

                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(""))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter Font");
                }

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                            ExpTmpLocalVar_Font =
                                (((hv_Font_COPY_INP_TMP + "-") + hv_Style) + "-") + hv_Size_COPY_INP_TMP;
                        hv_Font_COPY_INP_TMP.Dispose();
                        hv_Font_COPY_INP_TMP = ExpTmpLocalVar_Font;
                    }
                }

                HOperatorSet.SetFont(hv_WindowHandle, hv_Font_COPY_INP_TMP);

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_Font_COPY_INP_TMP.Dispose();
                hv_Size_COPY_INP_TMP.Dispose();
                hv_OS.Dispose();
                hv_Fonts.Dispose();
                hv_Style.Dispose();
                hv_Exception.Dispose();
                hv_AvailableFonts.Dispose();
                hv_Fdx.Dispose();
                hv_Indices.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public static void create_hdr_image(HObject ho_Image1, HObject ho_Image2, out HObject ho_HDR)
        {



            // Local iconic variables 

            HObject ho_X1, ho_Y1, ho_X2, ho_Y2, ho_MaxX;
            HObject ho_MaxY, ho_VectorField;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_HDR);
            HOperatorSet.GenEmptyObj(out ho_X1);
            HOperatorSet.GenEmptyObj(out ho_Y1);
            HOperatorSet.GenEmptyObj(out ho_X2);
            HOperatorSet.GenEmptyObj(out ho_Y2);
            HOperatorSet.GenEmptyObj(out ho_MaxX);
            HOperatorSet.GenEmptyObj(out ho_MaxY);
            HOperatorSet.GenEmptyObj(out ho_VectorField);
            try
            {
                //Calculate derivatives in x and y direction
                ho_X1.Dispose(); ho_Y1.Dispose();
                derivate_image(ho_Image1, out ho_X1, out ho_Y1);
                ho_X2.Dispose(); ho_Y2.Dispose();
                derivate_image(ho_Image2, out ho_X2, out ho_Y2);
                //Combine maximum absolute gradients
                ho_MaxX.Dispose();
                max_abs_image(ho_X1, ho_X2, out ho_MaxX);
                ho_MaxY.Dispose();
                max_abs_image(ho_Y1, ho_Y2, out ho_MaxY);
                //Transform combined image back to spatial domain
                ho_VectorField.Dispose();
                HOperatorSet.RealToVectorField(ho_MaxY, ho_MaxX, out ho_VectorField, "vector_field_relative");
                ho_HDR.Dispose();
                HOperatorSet.ReconstructHeightFieldFromGradient(ho_VectorField, out ho_HDR,
                    "poisson", new HTuple(), new HTuple());
                ho_X1.Dispose();
                ho_Y1.Dispose();
                ho_X2.Dispose();
                ho_Y2.Dispose();
                ho_MaxX.Dispose();
                ho_MaxY.Dispose();
                ho_VectorField.Dispose();


                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_X1.Dispose();
                ho_Y1.Dispose();
                ho_X2.Dispose();
                ho_Y2.Dispose();
                ho_MaxX.Dispose();
                ho_MaxY.Dispose();
                ho_VectorField.Dispose();


                throw HDevExpDefaultException;
            }
        }

        public static void derivate_image(HObject ho_Image, out HObject ho_DerivativeX, out HObject ho_DerivativeY)
        {



            // Local iconic variables 

            HObject ho_ImageConverted;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_DerivativeX);
            HOperatorSet.GenEmptyObj(out ho_DerivativeY);
            HOperatorSet.GenEmptyObj(out ho_ImageConverted);
            try
            {
                //Calculate a simple derivate in x and y direction
                ho_ImageConverted.Dispose();
                HOperatorSet.ConvertImageType(ho_Image, out ho_ImageConverted, "real");
                ho_DerivativeY.Dispose();
                HOperatorSet.ConvolImage(ho_ImageConverted, out ho_DerivativeY, (((((new HTuple(3)).TupleConcat(
                    1)).TupleConcat(1)).TupleConcat(-1)).TupleConcat(0)).TupleConcat(1), "mirrored");
                ho_DerivativeX.Dispose();
                HOperatorSet.ConvolImage(ho_ImageConverted, out ho_DerivativeX, (((((new HTuple(1)).TupleConcat(
                    3)).TupleConcat(1)).TupleConcat(-1)).TupleConcat(0)).TupleConcat(1), "mirrored");
                ho_ImageConverted.Dispose();


                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageConverted.Dispose();


                throw HDevExpDefaultException;
            }
        }

        public static void max_abs_image(HObject ho_Image1, HObject ho_Image2, out HObject ho_MaxImage)
        {



            // Local iconic variables 

            HObject ho_ImageAbs1, ho_ImageAbs2, ho_Region1Greater;
            HObject ho_Image1Reduced;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_MaxImage);
            HOperatorSet.GenEmptyObj(out ho_ImageAbs1);
            HOperatorSet.GenEmptyObj(out ho_ImageAbs2);
            HOperatorSet.GenEmptyObj(out ho_Region1Greater);
            HOperatorSet.GenEmptyObj(out ho_Image1Reduced);
            try
            {
                //Combine two images by always choosing the
                //maximum absolute gray value of each pixel
                //for the output image.
                ho_ImageAbs1.Dispose();
                HOperatorSet.AbsImage(ho_Image1, out ho_ImageAbs1);
                ho_ImageAbs2.Dispose();
                HOperatorSet.AbsImage(ho_Image2, out ho_ImageAbs2);
                //
                ho_Region1Greater.Dispose();
                HOperatorSet.DynThreshold(ho_ImageAbs1, ho_ImageAbs2, out ho_Region1Greater,
                    0, "light");
                ho_Image1Reduced.Dispose();
                HOperatorSet.ReduceDomain(ho_Image1, ho_Region1Greater, out ho_Image1Reduced
                    );
                ho_MaxImage.Dispose();
                HOperatorSet.PaintGray(ho_Image1Reduced, ho_Image2, out ho_MaxImage);
                ho_ImageAbs1.Dispose();
                ho_ImageAbs2.Dispose();
                ho_Region1Greater.Dispose();
                ho_Image1Reduced.Dispose();


                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageAbs1.Dispose();
                ho_ImageAbs2.Dispose();
                ho_Region1Greater.Dispose();
                ho_Image1Reduced.Dispose();


                throw HDevExpDefaultException;
            }
        }

        // Procedures 
        // Chapter: Filters / Arithmetic
        // Short Description: Scale the gray values of an image from the interval [Min,Max] to [0,255] 
        public static void scale_image_range(HObject ho_Image, out HObject ho_ImageScaled, HTuple hv_Min,
            HTuple hv_Max)
        {

            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_ImageSelected = null, ho_SelectedChannel = null;
            HObject ho_LowerRegion = null, ho_UpperRegion = null, ho_ImageSelectedScaled = null;

            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = new HObject(ho_Image);



            // Local control variables 

            HTuple hv_LowerLimit = new HTuple(), hv_UpperLimit = new HTuple();
            HTuple hv_Mult = new HTuple(), hv_Add = new HTuple(), hv_NumImages = new HTuple();
            HTuple hv_ImageIndex = new HTuple(), hv_Channels = new HTuple();
            HTuple hv_ChannelIndex = new HTuple(), hv_MinGray = new HTuple();
            HTuple hv_MaxGray = new HTuple(), hv_Range = new HTuple();
            HTuple hv_Max_COPY_INP_TMP = new HTuple(hv_Max);
            HTuple hv_Min_COPY_INP_TMP = new HTuple(hv_Min);

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_ImageSelected);
            HOperatorSet.GenEmptyObj(out ho_SelectedChannel);
            HOperatorSet.GenEmptyObj(out ho_LowerRegion);
            HOperatorSet.GenEmptyObj(out ho_UpperRegion);
            HOperatorSet.GenEmptyObj(out ho_ImageSelectedScaled);
            //Convenience procedure to scale the gray values of the
            //input image Image from the interval [Min,Max]
            //to the interval [0,255] (default).
            //Gray values < 0 or > 255 (after scaling) are clipped.
            //
            //If the image shall be scaled to an interval different from [0,255],
            //this can be achieved by passing tuples with 2 values [From, To]
            //as Min and Max.
            //Example:
            //scale_image_range(Image:ImageScaled:[100,50],[200,250])
            //maps the gray values of Image from the interval [100,200] to [50,250].
            //All other gray values will be clipped.
            //
            //input parameters:
            //Image: the input image
            //Min: the minimum gray value which will be mapped to 0
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //Max: The maximum gray value which will be mapped to 255
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //
            //Output parameter:
            //ImageScale: the resulting scaled image.
            //
            if ((int)(new HTuple((new HTuple(hv_Min_COPY_INP_TMP.TupleLength())).TupleEqual(
                    2))) != 0)
            {
                hv_LowerLimit.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_LowerLimit = hv_Min_COPY_INP_TMP.TupleSelect(
                        1);
                }

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                            ExpTmpLocalVar_Min = hv_Min_COPY_INP_TMP.TupleSelect(
                                0);
                        hv_Min_COPY_INP_TMP.Dispose();
                        hv_Min_COPY_INP_TMP = ExpTmpLocalVar_Min;
                    }
                }
            }
            else
            {
                hv_LowerLimit.Dispose();
                hv_LowerLimit = 0.0;
            }

            if ((int)(new HTuple((new HTuple(hv_Max_COPY_INP_TMP.TupleLength())).TupleEqual(
                    2))) != 0)
            {
                hv_UpperLimit.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_UpperLimit = hv_Max_COPY_INP_TMP.TupleSelect(
                        1);
                }

                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    {
                        HTuple
                            ExpTmpLocalVar_Max = hv_Max_COPY_INP_TMP.TupleSelect(
                                0);
                        hv_Max_COPY_INP_TMP.Dispose();
                        hv_Max_COPY_INP_TMP = ExpTmpLocalVar_Max;
                    }
                }
            }
            else
            {
                hv_UpperLimit.Dispose();
                hv_UpperLimit = 255.0;
            }

            //
            //Calculate scaling parameters.
            //Only scale if the scaling range is not zero.
            if ((int)((new HTuple(((((hv_Max_COPY_INP_TMP - hv_Min_COPY_INP_TMP)).TupleAbs()
                    )).TupleLess(1.0E-6))).TupleNot()) != 0)
            {
                hv_Mult.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Mult = (((hv_UpperLimit - hv_LowerLimit)).TupleReal()
                        ) / (hv_Max_COPY_INP_TMP - hv_Min_COPY_INP_TMP);
                }

                hv_Add.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Add = ((-hv_Mult) * hv_Min_COPY_INP_TMP) + hv_LowerLimit;
                }

                //Scale image.
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ScaleImage(ho_Image_COPY_INP_TMP, out ExpTmpOutVar_0, hv_Mult,
                        hv_Add);
                    ho_Image_COPY_INP_TMP.Dispose();
                    ho_Image_COPY_INP_TMP = ExpTmpOutVar_0;
                }
            }

            //
            //Clip gray values if necessary.
            //This must be done for each image and channel separately.
            ho_ImageScaled.Dispose();
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            hv_NumImages.Dispose();
            HOperatorSet.CountObj(ho_Image_COPY_INP_TMP, out hv_NumImages);
            HTuple end_val51 = hv_NumImages;
            HTuple step_val51 = 1;
            for (hv_ImageIndex = 1;
                 hv_ImageIndex.Continue(end_val51, step_val51);
                 hv_ImageIndex = hv_ImageIndex.TupleAdd(step_val51))
            {
                ho_ImageSelected.Dispose();
                HOperatorSet.SelectObj(ho_Image_COPY_INP_TMP, out ho_ImageSelected, hv_ImageIndex);
                hv_Channels.Dispose();
                HOperatorSet.CountChannels(ho_ImageSelected, out hv_Channels);
                HTuple end_val54 = hv_Channels;
                HTuple step_val54 = 1;
                for (hv_ChannelIndex = 1;
                     hv_ChannelIndex.Continue(end_val54, step_val54);
                     hv_ChannelIndex = hv_ChannelIndex.TupleAdd(step_val54))
                {
                    ho_SelectedChannel.Dispose();
                    HOperatorSet.AccessChannel(ho_ImageSelected, out ho_SelectedChannel, hv_ChannelIndex);
                    hv_MinGray.Dispose();
                    hv_MaxGray.Dispose();
                    hv_Range.Dispose();
                    HOperatorSet.MinMaxGray(ho_SelectedChannel, ho_SelectedChannel, 0, out hv_MinGray,
                        out hv_MaxGray, out hv_Range);
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_LowerRegion.Dispose();
                        HOperatorSet.Threshold(ho_SelectedChannel, out ho_LowerRegion, ((hv_MinGray.TupleConcat(
                            hv_LowerLimit))).TupleMin(), hv_LowerLimit);
                    }

                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        ho_UpperRegion.Dispose();
                        HOperatorSet.Threshold(ho_SelectedChannel, out ho_UpperRegion, hv_UpperLimit,
                            ((hv_UpperLimit.TupleConcat(hv_MaxGray))).TupleMax());
                    }

                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.PaintRegion(ho_LowerRegion, ho_SelectedChannel, out ExpTmpOutVar_0,
                            hv_LowerLimit, "fill");
                        ho_SelectedChannel.Dispose();
                        ho_SelectedChannel = ExpTmpOutVar_0;
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.PaintRegion(ho_UpperRegion, ho_SelectedChannel, out ExpTmpOutVar_0,
                            hv_UpperLimit, "fill");
                        ho_SelectedChannel.Dispose();
                        ho_SelectedChannel = ExpTmpOutVar_0;
                    }
                    if ((int)(new HTuple(hv_ChannelIndex.TupleEqual(1))) != 0)
                    {
                        ho_ImageSelectedScaled.Dispose();
                        HOperatorSet.CopyObj(ho_SelectedChannel, out ho_ImageSelectedScaled, 1,
                            1);
                    }
                    else
                    {
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.AppendChannel(ho_ImageSelectedScaled, ho_SelectedChannel,
                                out ExpTmpOutVar_0);
                            ho_ImageSelectedScaled.Dispose();
                            ho_ImageSelectedScaled = ExpTmpOutVar_0;
                        }
                    }
                }

                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_ImageScaled, ho_ImageSelectedScaled, out ExpTmpOutVar_0
                    );
                    ho_ImageScaled.Dispose();
                    ho_ImageScaled = ExpTmpOutVar_0;
                }
            }

            ho_Image_COPY_INP_TMP.Dispose();
            ho_ImageSelected.Dispose();
            ho_SelectedChannel.Dispose();
            ho_LowerRegion.Dispose();
            ho_UpperRegion.Dispose();
            ho_ImageSelectedScaled.Dispose();

            hv_Max_COPY_INP_TMP.Dispose();
            hv_Min_COPY_INP_TMP.Dispose();
            hv_LowerLimit.Dispose();
            hv_UpperLimit.Dispose();
            hv_Mult.Dispose();
            hv_Add.Dispose();
            hv_NumImages.Dispose();
            hv_ImageIndex.Dispose();
            hv_Channels.Dispose();
            hv_ChannelIndex.Dispose();
            hv_MinGray.Dispose();
            hv_MaxGray.Dispose();
            hv_Range.Dispose();

            return;
        }

        // Local procedures 
        // Short Description: Determines scale and pose for the operator image_to_world_plane such that a given point appears in the center and that the scale of the rectified image is similar to the scale of the original image. 
        public static void parameters_image_to_world_plane_centered(HTuple hv_CamParam, HTuple hv_Pose,
            HTuple hv_CenterRow, HTuple hv_CenterCol, HTuple hv_WidthMappedImage, HTuple hv_HeightMappedImage,
            out HTuple hv_ScaleForCenteredImage, out HTuple hv_PoseForCenteredImage)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_Dist_ICS = new HTuple(), hv_CenterX = new HTuple();
            HTuple hv_CenterY = new HTuple(), hv_BelowCenterX = new HTuple();
            HTuple hv_BelowCenterY = new HTuple(), hv_RightOfCenterX = new HTuple();
            HTuple hv_RightOfCenterY = new HTuple(), hv_Dist_WCS_Vertical = new HTuple();
            HTuple hv_Dist_WCS_Horizontal = new HTuple(), hv_ScaleVertical = new HTuple();
            HTuple hv_ScaleHorizontal = new HTuple(), hv_DX = new HTuple();
            HTuple hv_DY = new HTuple(), hv_DZ = new HTuple();
            // Initialize local and output iconic variables 
            hv_ScaleForCenteredImage = new HTuple();
            hv_PoseForCenteredImage = new HTuple();
            //Determine the scale for the mapping
            //(here, the scale is determined such that in the
            //  surroundings of the given point  the image scale of the
            //  mapped image is similar to the image scale of the original image)
            hv_Dist_ICS.Dispose();
            hv_Dist_ICS = 1;
            hv_CenterX.Dispose();
            hv_CenterY.Dispose();
            HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_CenterRow, hv_CenterCol,
                1, out hv_CenterX, out hv_CenterY);
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_BelowCenterX.Dispose();
                hv_BelowCenterY.Dispose();
                HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_CenterRow + hv_Dist_ICS,
                    hv_CenterCol, 1, out hv_BelowCenterX, out hv_BelowCenterY);
            }

            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_RightOfCenterX.Dispose();
                hv_RightOfCenterY.Dispose();
                HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_CenterRow,
                    hv_CenterCol + hv_Dist_ICS,
                    1, out hv_RightOfCenterX, out hv_RightOfCenterY);
            }

            hv_Dist_WCS_Vertical.Dispose();
            HOperatorSet.DistancePp(hv_CenterY, hv_CenterX, hv_BelowCenterY, hv_BelowCenterX,
                out hv_Dist_WCS_Vertical);
            hv_Dist_WCS_Horizontal.Dispose();
            HOperatorSet.DistancePp(hv_CenterY, hv_CenterX, hv_RightOfCenterY, hv_RightOfCenterX,
                out hv_Dist_WCS_Horizontal);
            hv_ScaleVertical.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ScaleVertical = hv_Dist_WCS_Vertical / hv_Dist_ICS;
            }

            hv_ScaleHorizontal.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ScaleHorizontal = hv_Dist_WCS_Horizontal / hv_Dist_ICS;
            }

            hv_ScaleForCenteredImage.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_ScaleForCenteredImage = (hv_ScaleVertical + hv_ScaleHorizontal) / 2.0;
            }

            //Determine the parameters for set_origin_pose such
            //that the point given via get_mbutton will be in the center of the
            //mapped image
            hv_DX.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DX = hv_CenterX - ((hv_ScaleForCenteredImage * hv_WidthMappedImage) / 2.0);
            }

            hv_DY.Dispose();
            using (HDevDisposeHelper dh = new HDevDisposeHelper())
            {
                hv_DY = hv_CenterY - ((hv_ScaleForCenteredImage * hv_HeightMappedImage) / 2.0);
            }

            hv_DZ.Dispose();
            hv_DZ = 0;
            hv_PoseForCenteredImage.Dispose();
            HOperatorSet.SetOriginPose(hv_Pose, hv_DX, hv_DY, hv_DZ, out hv_PoseForCenteredImage);

            hv_Dist_ICS.Dispose();
            hv_CenterX.Dispose();
            hv_CenterY.Dispose();
            hv_BelowCenterX.Dispose();
            hv_BelowCenterY.Dispose();
            hv_RightOfCenterX.Dispose();
            hv_RightOfCenterY.Dispose();
            hv_Dist_WCS_Vertical.Dispose();
            hv_Dist_WCS_Horizontal.Dispose();
            hv_ScaleVertical.Dispose();
            hv_ScaleHorizontal.Dispose();
            hv_DX.Dispose();
            hv_DY.Dispose();
            hv_DZ.Dispose();

            return;
        }

        // Procedures 
        // Chapter: Filters / Lines
        // Short Description: Calculate the parameters Sigma, Low, and High for lines_gauss. 
        public static void calculate_lines_gauss_parameters(HTuple hv_MaxLineWidth, HTuple hv_Contrast,
            out HTuple hv_Sigma, out HTuple hv_Low, out HTuple hv_High)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_ContrastHigh = new HTuple(), hv_ContrastLow = new HTuple();
            HTuple hv_HalfWidth = new HTuple(), hv_Help = new HTuple();
            HTuple hv_MaxLineWidth_COPY_INP_TMP = new HTuple(hv_MaxLineWidth);

            // Initialize local and output iconic variables 
            hv_Sigma = new HTuple();
            hv_Low = new HTuple();
            hv_High = new HTuple();
            try
            {
                //Check control parameters
                if ((int)(new HTuple((new HTuple(hv_MaxLineWidth_COPY_INP_TMP.TupleLength()
                    )).TupleNotEqual(1))) != 0)
                {
                    throw new HalconException("Wrong number of values of control parameter: 1");
                }
                if ((int)(((hv_MaxLineWidth_COPY_INP_TMP.TupleIsNumber())).TupleNot()) != 0)
                {
                    throw new HalconException("Wrong type of control parameter: 1");
                }
                if ((int)(new HTuple(hv_MaxLineWidth_COPY_INP_TMP.TupleLessEqual(0))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter: 1");
                }
                if ((int)((new HTuple((new HTuple(hv_Contrast.TupleLength())).TupleNotEqual(
                    1))).TupleAnd(new HTuple((new HTuple(hv_Contrast.TupleLength())).TupleNotEqual(
                    2)))) != 0)
                {
                    throw new HalconException("Wrong number of values of control parameter: 2");
                }
                if ((int)(new HTuple(((((hv_Contrast.TupleIsNumber())).TupleMin())).TupleEqual(
                    0))) != 0)
                {
                    throw new HalconException("Wrong type of control parameter: 2");
                }
                //Set and check ContrastHigh
                hv_ContrastHigh.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_ContrastHigh = hv_Contrast.TupleSelect(
                        0);
                }
                if ((int)(new HTuple(hv_ContrastHigh.TupleLess(0))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter: 2");
                }
                //Set or derive ContrastLow
                if ((int)(new HTuple((new HTuple(hv_Contrast.TupleLength())).TupleEqual(2))) != 0)
                {
                    hv_ContrastLow.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_ContrastLow = hv_Contrast.TupleSelect(
                            1);
                    }
                }
                else
                {
                    hv_ContrastLow.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_ContrastLow = hv_ContrastHigh / 3.0;
                    }
                }
                //Check ContrastLow
                if ((int)(new HTuple(hv_ContrastLow.TupleLess(0))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter: 2");
                }
                if ((int)(new HTuple(hv_ContrastLow.TupleGreater(hv_ContrastHigh))) != 0)
                {
                    throw new HalconException("Wrong value of control parameter: 2");
                }
                //
                //Calculate the parameters Sigma, Low, and High for lines_gauss
                if ((int)(new HTuple(hv_MaxLineWidth_COPY_INP_TMP.TupleLess((new HTuple(3.0)).TupleSqrt()
                    ))) != 0)
                {
                    //Note that LineWidthMax < sqrt(3.0) would result in a Sigma < 0.5,
                    //which does not make any sense, because the corresponding smoothing
                    //filter mask would be of size 1x1.
                    //To avoid this, LineWidthMax is restricted to values greater or equal
                    //to sqrt(3.0) and the contrast values are adapted to reflect the fact
                    //that lines that are thinner than sqrt(3.0) pixels have a lower contrast
                    //in the smoothed image (compared to lines that are sqrt(3.0) pixels wide).
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_ContrastLow = (hv_ContrastLow * hv_MaxLineWidth_COPY_INP_TMP) / ((new HTuple(3.0)).TupleSqrt()
                                );
                            hv_ContrastLow.Dispose();
                            hv_ContrastLow = ExpTmpLocalVar_ContrastLow;
                        }
                    }
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        {
                            HTuple
                              ExpTmpLocalVar_ContrastHigh = (hv_ContrastHigh * hv_MaxLineWidth_COPY_INP_TMP) / ((new HTuple(3.0)).TupleSqrt()
                                );
                            hv_ContrastHigh.Dispose();
                            hv_ContrastHigh = ExpTmpLocalVar_ContrastHigh;
                        }
                    }
                    hv_MaxLineWidth_COPY_INP_TMP.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_MaxLineWidth_COPY_INP_TMP = (new HTuple(3.0)).TupleSqrt()
                            ;
                    }
                }
                //Convert LineWidthMax and the given contrast values into the input parameters
                //Sigma, Low, and High required by lines_gauss
                hv_HalfWidth.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_HalfWidth = hv_MaxLineWidth_COPY_INP_TMP / 2.0;
                }
                hv_Sigma.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Sigma = hv_HalfWidth / ((new HTuple(3.0)).TupleSqrt()
                        );
                }
                hv_Help.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Help = ((-2.0 * hv_HalfWidth) / (((new HTuple(6.283185307178)).TupleSqrt()
                        ) * (hv_Sigma.TuplePow(3.0)))) * (((-0.5 * (((hv_HalfWidth / hv_Sigma)).TuplePow(
                        2.0)))).TupleExp());
                }
                hv_High.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_High = ((hv_ContrastHigh * hv_Help)).TupleFabs()
                        ;
                }
                hv_Low.Dispose();
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    hv_Low = ((hv_ContrastLow * hv_Help)).TupleFabs()
                        ;
                }

                hv_MaxLineWidth_COPY_INP_TMP.Dispose();
                hv_ContrastHigh.Dispose();
                hv_ContrastLow.Dispose();
                hv_HalfWidth.Dispose();
                hv_Help.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {

                hv_MaxLineWidth_COPY_INP_TMP.Dispose();
                hv_ContrastHigh.Dispose();
                hv_ContrastLow.Dispose();
                hv_HalfWidth.Dispose();
                hv_Help.Dispose();

                throw HDevExpDefaultException;
            }
        }
    }
}
