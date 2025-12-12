using DevExpress.Drawing;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.SpreadsheetSource.Xls;
using DevExpress.Utils.About;
using DevExpress.XtraEditors;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using _CommonCode_Framework;


namespace HalconTest
{
    /// <summary>
    /// Customized extension methods
    /// </summary>
    public static class csHalconExtension
    {


 
        public static string ToHalconColorParameter(this Color color)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("#");
            builder.Append(color.R.ToString("x2"));
            builder.Append(color.G.ToString("x2"));
            builder.Append(color.B.ToString("x2"));
            builder.Append(color.A.ToString("x2"));
            return builder.ToString();
        }

        public static HObject ToHalconCollection(this List<HObject> HobjectList)
        {
            if (HobjectList.Count == 0) return null;
            else if (HobjectList.Count == 1) return HobjectList[0];

            HOperatorSet.GenEmptyObj(out HObject newHobject);

            for (int i = 0; i < HobjectList.Count; i++)
            {
                HOperatorSet.ConcatObj(newHobject, HobjectList[i], out HObject objectTemp);
                newHobject.Dispose();
                newHobject = objectTemp;
            }


            return newHobject;
        }

        public static void ClearAndDispose(this List<HObject> HobjectList)
        {
            for (int i = 0; i < HobjectList.Count; i++)
            {
                HobjectList[i]?.Dispose();
            }

            HobjectList.Clear();
        }

        /// <summary>
        /// Read image from image file data
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        public static HObject ImageArrayToHObject(this byte[] rawData)
        {
            try
            {
                unsafe
                {
                    fixed (byte* ptr = rawData)
                    {
                        HOperatorSet.CreateMemoryBlockExtern((IntPtr)ptr, rawData.Length, 0, out HTuple memoryBlockerHanlde);
                        "ImageArrayToHObject.MemoryBlockCreated".TraceRecord();
                        HOperatorSet.MemoryBlockToImage(out HObject image, memoryBlockerHanlde);
                        memoryBlockerHanlde.ClearHandle();
                        HOperatorSet.GetImageSize(image, out HTuple imageWidth, out HTuple imageHeight);
                        $"ImageArrayToHObject.HalconImageCreated({imageWidth.D},{imageHeight.D})".TraceRecord();
                        return image;
                    }

                }
            }
            catch (Exception ex)
            {
                ex.TraceException("ImageArrayToHObject");
                return null;
            }
        }

        /// <summary>
        /// Get the image data without format
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] HobjectToRawByte(this HObject image)
        {
            try
            {
                HOperatorSet.CountChannels(image, out HTuple channels);
                if (channels.L == 1)
                {
                    HOperatorSet.GetImagePointer1(image, out HTuple pointer, out HTuple type, out HTuple width, out HTuple height);
                    long lSize = width.L * height.L;
                    byte[] array = new byte[width.L * height.L];
                    //Get old image address
                    unsafe
                    {
                        byte* imagePointer = ((byte*)pointer.L);
                        fixed (byte* arrayPointer = array)
                        {
                            Buffer.MemoryCopy(imagePointer, arrayPointer, lSize, lSize);
                        }
                    }

                    return array;

                }
                else if (channels.L == 3)
                {
                    //Get data pointer
                    HOperatorSet.GetImagePointer3(image, out HTuple pointerRed, out HTuple pointerGreen, out HTuple pointerBlue, out HTuple type, out HTuple width, out HTuple height);
                    long lSizeSingle = width.L * height.L;
                    long lSizeTotal = lSizeSingle * 3;
                    byte[] dataArray = new byte[lSizeTotal];

                    unsafe
                    {
                        //Get old image address
                        byte* r = ((byte*)pointerRed.L);
                        byte* g = ((byte*)pointerGreen.L);
                        byte* b = ((byte*)pointerBlue.L);


                        fixed (byte* arrayPointer = dataArray)
                        {
                            byte* pStartRed = arrayPointer;
                            byte* pStartGreen = arrayPointer + width.L * height.L;
                            byte* pStartBlue = arrayPointer + width.L * height.L * 2;
                            Parallel.Invoke(
                             () =>
                             { //R
                                 Buffer.MemoryCopy(r, pStartRed, lSizeSingle, lSizeSingle);
                             },
                             () =>
                             {//g
                                 Buffer.MemoryCopy(g, pStartGreen, lSizeSingle, lSizeSingle);
                             },
                             () =>
                             { //b
                                 Buffer.MemoryCopy(b, pStartBlue, lSizeSingle, lSizeSingle);
                             }
                         );
                        }
                    }

                    return dataArray;
                }
                else
                {
                    "Undefined Image type".TraceRecord();
                    return null;
                }

            }
            catch (Exception ex)
            {
                ex.TraceException("HobjectToRawByte");
                return null;
            }
        }



        public static HObject MonoBytesToHObject(this byte[] byteData, int iWdith, int iHeight)
        {
            try
            {
                //Verify the size
                int iTargetSize = iWdith * iHeight;
                if (byteData.Length != iTargetSize)
                {
                    $"The array size is not valid.[ArraySource: {byteData.Length}/{iTargetSize}, Image: {iWdith}*{iHeight}]".TraceRecord();
                    return null;
                }

                unsafe
                {
                    fixed (byte* bytePointer = byteData)
                    {
                        HOperatorSet.GenImage1(out HObject imageNew, "byte", iWdith, iHeight, (IntPtr)bytePointer);
                        return imageNew;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.TraceException("MonoBytesToHObject");
                return null;
            }
        }

        /// <summary>
        /// Only support "jpeg", "png"
        /// 'jpeg': JPEG format (lossy compression), file extension *.jpg
        /// 'png': PNG format (lossless compression), file extension *.png
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sFormat">
        /// "jpeg", "jpeg 30", "jpeg 60".-->
        /// "png", "png 7", "png none", "png best", "png fastest".
        /// 
        /// </param>
        /// <returns></returns>
        public static byte[] HObjectToImageArray(this HObject image, string sFormat)
        {
            try
            {
                "HObjectToImageArray.Start".TraceRecord();
                HOperatorSet.ImageToMemoryBlock(image, sFormat, 0, out HTuple memoryBlockHandle);
                "HObjectToImageArray.MemoryBlockReady".TraceRecord();
                HOperatorSet.GetMemoryBlockPtr(memoryBlockHandle, out HTuple pointer, out HTuple size);

                byte[] imageArray = new byte[size.L];
                unsafe
                {
                    fixed (byte* newImagePointer = imageArray)
                    {
                        byte* sourcePointer = (byte*)((IntPtr)pointer.L);
                        Buffer.MemoryCopy(sourcePointer, newImagePointer, size.L, size.L);
                    }
                }
                memoryBlockHandle.ClearHandle();
                "HObjectToImageArray.CopiedToArray".TraceRecord();
                return imageArray;
            }
            catch (Exception ex)
            {
                ex.TraceException("HObjectToImageArray");
                return null;
            }
        }

        /// <summary>
        /// Performance is acceptable
        /// </summary>
        /// <param name="imageSource"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static (Bitmap bitMap, byte[] dataArray) HImageToBitMapArray(this HObject imageSource, ImageFormat format)
        {
            try
            {

                if (imageSource == null || !imageSource.IsInitialized()) return (null, null);

                //Check image type
                HOperatorSet.CountChannels(imageSource, out HTuple hv_Channels);

                //Get Image size
                HOperatorSet.GetImageSize(imageSource, out HTuple width0, out HTuple height0);
                int iWidth = (int)width0.L;
                int iHeight = (int)height0.L;


                //Gray image
                if (hv_Channels.L == 1)
                {
                    // Get image pointer
                    HOperatorSet.GetImagePointer1(imageSource, out HTuple pointer, out HTuple type, out HTuple width, out HTuple height);

                    //Create a container 
                    long lSize = iWidth * iHeight;
                    byte[] imageBytes = new byte[lSize];

                    //Create bitmap
                    Bitmap bitmap = new Bitmap(iWidth, iHeight, PixelFormat.Format8bppIndexed);

                    //Get the locking area
                    Rectangle rect = new Rectangle(0, 0, iWidth, iHeight);
                    BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, bitmap.PixelFormat);

                    //Stride must be x%4=0, so extra byte might exist
                    if (bmpData.Stride == iWidth)
                    {//Copy directly no since no extra block in each line
                        unsafe
                        {
                            byte* sourcePointer = (byte*)((IntPtr)pointer.L);
                            byte* bmpPointer = (byte*)bmpData.Scan0;

                            fixed (byte* newImagePointer = imageBytes)
                            {
                                Buffer.MemoryCopy(sourcePointer, bmpPointer, lSize, lSize);
                            }
                        }
                    }
                    else
                    {//Extra bytes exist in each line: 【bmpData.Stride】》=【iWidth】

                        unsafe
                        {
                            byte* sourcePointer = (byte*)(pointer.L);
                            byte* bmpPointer = (byte*)bmpData.Scan0;

                            for (int lineIndex = 0; lineIndex < iHeight; lineIndex++)
                            {
                                byte* sourceStart = sourcePointer + lineIndex * iWidth;
                                byte* destinationStart = bmpPointer + lineIndex * bmpData.Stride;
                                Buffer.MemoryCopy(sourceStart, destinationStart, iWidth, iWidth);
                            }
                        }
                    }
                    bitmap.UnlockBits(bmpData);

                    //Format8bppIndexed Format need to set Palette
                    //This avoiding image become colorful, which can look different from original image
                    ColorPalette palette = bitmap.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    bitmap.Palette = palette;

                    return (bitmap, bitmap.BitmapToImageArray(format));
                }
                //RGB image
                else if (hv_Channels.L == 3)
                {
                    //Get data pointer
                    HOperatorSet.GetImagePointer3(imageSource, out HTuple pointerRed, out HTuple pointerGreen, out HTuple pointerBlue, out HTuple type, out HTuple width, out HTuple height);

                    //create new image
                    Bitmap bmpImage = new Bitmap(width.I, height.I, PixelFormat.Format32bppArgb);

                    //already contains 4 bytes each group, no need to check stride
                    BitmapData bitmapData = bmpImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    unsafe
                    {

                        //Get old image address
                        byte* r = ((byte*)pointerRed.L);
                        byte* g = ((byte*)pointerGreen.L);
                        byte* b = ((byte*)pointerBlue.L);

                        //Get new image address
                        byte* bNew = (byte*)bitmapData.Scan0;

                        int iPixels = width * height;

                        //Use 4 threads to create image
                        Parallel.Invoke(
                            //Blue
                            () => { for (int i = 0; i < iPixels; i++) bNew[i * 4] = (b)[i]; },
                            //Green
                            () => { for (int i = 0; i < iPixels; i++) bNew[i * 4 + 1] = (g)[i]; },
                            //Red
                            () => { for (int i = 0; i < iPixels; i++) bNew[i * 4 + 2] = (r)[i]; },
                            //Transparency   
                            () => { for (int i = 0; i < iPixels; i++) bNew[i * 4 + 3] = 255; }
                        );
                    }
                    bmpImage.UnlockBits(bitmapData);

                    // Convert to desired format
                    return (bmpImage, bmpImage.BitmapToImageArray(format));

                }
                else
                {
                    $"HImageToImageArray.InvalidChannelCount({hv_Channels.L})".TraceRecord();
                    return (null, null);
                }

            }
            catch (Exception ex)
            {
                ex.TraceException("HImageToImageArray");
                return (null, null);
            }
        }

        /// <summary>
        /// Very slow!!!
        ///ImageFormat.Tiff;
        ///ImageFormat.Bmp;
        ///ImageFormat.Jpeg
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="format">ImageFormat.Tiff</param>
        /// <returns></returns>
        public static byte[] BitmapToImageArray(this Bitmap bitmap, ImageFormat format)
        {
            // Create memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                //Convert to specific type
                bitmap.Save(ms, format);
                // Get byte array
                byte[] imageArray = ms.ToArray();

                return imageArray;
            }
        }

        /// <summary>
        /// Convert htuple list value to Lit<Object>
        /// Which can be easily saved in the xml file
        /// </summary>
        /// <returns></returns>
        public static List<object> ToListObjects(this HTuple hTupleList)
        {
            List<object> list = new List<object>();

            if (hTupleList == null) return null;

            if (hTupleList.Type == HTupleType.MIXED)
            {
                foreach (var item in hTupleList.ToOArr()) list.Add(item);
            }


            return list;
        }



        public static (bool IsSuccess, string Message) SaveImage(this HObject image, string sPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sPath)) return (false, "The target file path is empty.");

                //Get directory
                string sDir = Path.GetDirectoryName(sPath);
                if (string.IsNullOrWhiteSpace(sDir)) return (false, $"Invalid target folder: {sPath}");
                if (!Directory.Exists(sDir))
                {
                    Directory.CreateDirectory(sDir);
                }

                HOperatorSet.WriteImage(image, "tiff", 0, sPath);
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} File Saved:{sPath}");
                return (true, sPath);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                return (false, e.Message);
            }
        }



        /// <summary>
        /// The image directly generated using compose3 won't be treated as proper RGB image in certain cases, use this method instead
        /// </summary>
        /// <param name="imageGray"></param>
        /// <returns></returns>
        public static HObject GrayImageToRGBImage(this HObject imageGray)
        {
            try
            {
                HOperatorSet.TransFromRgb(imageGray, imageGray, imageGray, out HObject ImageResult1, out HObject imageResult2, out HObject imageResult3, "hsv");
                HOperatorSet.TransToRgb(ImageResult1, imageResult2, imageResult3, out HObject imageRead, out HObject imageGreen, out HObject imageBlue, "hsv");
                ImageResult1.Dispose();
                imageResult2.Dispose();
                imageResult3.Dispose();
                HOperatorSet.Compose3(imageRead, imageGreen, imageBlue, out HObject multiChannelImage);
                imageRead.Dispose();
                imageGreen.Dispose();
                imageBlue.Dispose();
                return multiChannelImage;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconCommonExt.GrayImageToRGBImage:{e.GetMessageDetail()}");
                return null;
            }
        }

        public static (bool? IsSuccess, string Message) SaveImageAsAction(this HObject image, string sDefaultFolder = null, string sFilter = null)
        {
            using (XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog())
            {
                //Set default folder
                if (!string.IsNullOrWhiteSpace(sDefaultFolder))
                {
                    saveFileDialog.InitialDirectory = sDefaultFolder;
                }

                //Set filter
                if (string.IsNullOrWhiteSpace(sFilter))
                {
                    saveFileDialog.Filter = "Tiff File|*.tiff|tif File|*.tif|JPG File|*.jpg|JPEG File|*.jpeg|BMP File|*.bmp|All File|*.*";
                }
                else
                {
                    saveFileDialog.Filter = sFilter;
                }



                if (saveFileDialog.ShowDialog() != DialogResult.OK) return (null, null);
                return image.SaveImage(saveFileDialog.FileName);
            }
        }

        public static HTuple GetRowTuple(this List<HalconPoint> halconPoints)
        {
            HTuple rowData = new HTuple(halconPoints.Select(a => Convert.ToDouble(a.Row)).ToArray());
            return rowData;
        }

        public static HTuple GetColumnTuple(this List<HalconPoint> halconPoints)
        {
            HTuple colData = new HTuple(halconPoints.Select(a => Convert.ToDouble(a.Column)).ToArray());
            return colData;
        }

        public static void ClearDictionary(this HTuple ht_Dict)
        {
            if (ht_Dict == null) return;
            HOperatorSet.GetDictParam(ht_Dict, "keys", new HTuple(), out HTuple ht_Keys);
            HOperatorSet.RemoveDictKey(ht_Dict, ht_Keys);
        }

        public static void ClearHObject(this HObject ho_Object)
        {
            if (ho_Object == null) return;
            ho_Object.Dispose();
            ho_Object = null;
        }



        public static bool IsValid(this HObject ho_Self)
        {
            if (ho_Self == null ||
                !ho_Self.IsInitialized())
            {
                return false;
            }

            int iCount = ho_Self.CountObj();
            if (iCount == 0) return false;

            return true;
        }

        public static (int[] Rows, int[] Columns) GetImagePoints(this HObject image)
        {
            if (!image.IsValid()) return (null, null);

            HOperatorSet.GetImageSize(image, out HTuple imageWdith, out HTuple imageHeigt);

            long lTotal = imageWdith.L * imageHeigt.L;
            var rows = new int[lTotal];
            var cols = new int[lTotal];
            for (int i = 0; i < imageHeigt.L; i++)
            {
                for (int j = 0; j < imageWdith.L; j++)
                {
                    long lPosition = i * imageWdith.L + j;
                    rows[lPosition] = i;
                    cols[lPosition] = j;
                }
            }

            return (rows, cols);
        }

        public static int ChannelCount(this HObject ho_Self)
        {
            try
            {
                HOperatorSet.CountChannels(ho_Self, out HTuple channels);
                return channels.GetIntValue();
            }
            catch (Exception e)
            {
                Trace.WriteLine($"ChannelCount:{e.GetMessageDetail()}");
                return -1;
            }
        }

        public static int GetHalconInt(this HTuple oValue)
        {
            if (oValue == null) return -1;
            switch (oValue.Type)
            {
                case HTupleType.EMPTY:
                    return -1;
                case HTupleType.INTEGER:
                    return oValue.I;
                case HTupleType.LONG:
                    return (int)oValue.L;
                case HTupleType.DOUBLE:
                    return (int)oValue.D;
                case HTupleType.STRING:
                    if (int.TryParse(oValue.S, out int iValue)) return iValue;
                    else return -1;
                case HTupleType.HANDLE:
                case HTupleType.MIXED:
                default:
                    return -1;
            }
        }

        /// <summary>
        /// List objects to htuple value
        /// </summary>
        /// <param name="listObjects"></param>
        /// <returns></returns>
        public static HTuple ToHtuple(this List<object> listObjects)
        {
            HTuple tupleValue = new HTuple();

            foreach (var item in listObjects)
            {
                var valueType = item.GetType();
                if (item is int)
                {
                    tupleValue.Append((int)item);
                }
                else if (item is Int64)
                {
                    tupleValue.Append((Int64)item);
                }
                else if (item is float)
                {
                    tupleValue.Append((float)item);
                }
                else if (item is double)
                {
                    tupleValue.Append((double)item);
                }
                else if (item is string)
                {
                    tupleValue.Append((string)item);
                }
                else
                {
                    string sType = item == null ? "" : item.ToString();
                    Trace.WriteLine($"ToHtuple:Missing Match.({sType})");
                }

            }

            return tupleValue;
        }

        public static string GetStringValue(this HTuple hv_Value)
        {
            string sValue = string.Empty;
            if (hv_Value.Type == HTupleType.STRING)
            {
                sValue = hv_Value.S;
            }
            else if (hv_Value.Type == HTupleType.LONG)
            {
                sValue = hv_Value.L.ToString();
            }
            else if (hv_Value.Type == HTupleType.DOUBLE)
            {
                sValue = hv_Value.D.ToString();
            }

            return sValue;
        }

        public static string GetStringValue(this HTupleElements hv_Value)
        {
            return GetStringValue(hv_Value);
        }


        /// <summary>
        /// Get average gray value of each column
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static List<double> GetColumnGrayHistogram(this HObject image, int iHeightLimit = 500)
        {
            List<double> colGrayList = new List<double>();

            try
            {
                if (image == null || !image.IsInitialized()) return null;

                HOperatorSet.GetImageSize(image, out HTuple hWidth, out HTuple hHeight);
                int iWidth = hWidth.I;
                int iHeight = hHeight.I;

                //Prepare the pixel count
                for (int i = 0; i < iWidth; i++)
                {

                    int[] rows = null;
                    int[] cols = null;

                    //When the size is smaller than limit, use the image size
                    if (iHeight <= iHeightLimit)
                    {
                        rows = new int[iHeight];
                        cols = new int[iHeight];

                        //Set position
                        for (int j = 0; j < iHeight; j++)
                        {
                            cols[j] = i;//Same column
                            rows[j] = j;//Position of each row        
                        }
                    }
                    //When the size is bigger than limit, only use the center area
                    else
                    {
                        rows = new int[iHeightLimit];
                        cols = new int[iHeightLimit];

                        //Get the start position
                        int iStart = (iHeight - iHeightLimit) / 2;

                        //Set position
                        for (int j = 0; j < iHeightLimit; j++)
                        {
                            cols[j] = i;//Same column
                            rows[j] = j + iStart;//Position of each row        
                        }
                    }


                    HTuple rowData = new HTuple(rows);
                    HTuple colData = new HTuple(cols);

                    HOperatorSet.GetGrayval(image, rowData, colData, out HTuple grayVal);

                    int iCOunt = grayVal.TupleLength();
                    double dAVG = grayVal.LArr.Average();

                    colGrayList.Add(dAVG);
                }

                return colGrayList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} GetColumnGrayAVG:\r\n{ex.Message}");
                return null;
            }
        }

        public static bool? IsRegion(this HObject hObject)
        {
            //Check null
            if (hObject == null) return null;

            //Must have at least one item
            int iCount = hObject.CountObj();
            if (iCount == 0) return null;

            //Get type
            string sType = hObject.GetObjClass();
            var halconType = GetHalconType(sType);
            return halconType == _hObjectType.Region;
        }



        public static bool? IsContour(this HObject hObject)
        {
            //Check null
            if (hObject == null) return null;

            //Must have at least one item
            int iCount = hObject.CountObj();
            if (iCount == 0) return null;

            //Get type
            string sType = hObject.GetObjClass();
            var halconType = GetHalconType(sType);
            return halconType == _hObjectType.Contour;
        }


        /// <summary>
        /// Get item count without exception
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        public static int GetItemCount(this HObject hObject)
        {
            try
            {
                if (hObject == null || !hObject.IsInitialized()) return 0;
                int iCount = hObject.CountObj();
                return iCount;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"csHalconCommon.GetItemCount.Exception\r\n{e.GetMessageDetail()}");
                return -1;
            }
        }

        public static _hObjectType GetHalconType(this HObject hObject)
        {
            if (hObject == null || !hObject.IsInitialized()) return _hObjectType.Undefined;
            int iCount = hObject.CountObj();
            //Empty object doesn't have class type
            if (iCount == 0) return _hObjectType.Undefined;

            string sType = hObject.GetObjClass();
            var halconType = GetHalconType(sType);
            return halconType;
        }

        public static _hObjectType GetHalconType(string sType)
        {
            if (sType == "image") return _hObjectType.Image;
            else if (sType == "region") return _hObjectType.Region;
            else if (sType == "contour" || sType == "xld_cont") return _hObjectType.Contour;
            else return _hObjectType.Undefined;
        }

        public static HTuple ToHalconAngleRad(this float fValue)
        {
            HTuple tValue = new HTuple(fValue);
            return tValue.TupleRad();
        }


        public static HTuple ToHalconAngleDegree(this float fValue)
        {
            HTuple tValue = new HTuple(fValue);
            return tValue.TupleDeg();
        }

        public static float ToAngleDegree(this float fValue)
        {
            return fValue * csHalconHelper.DegreePerRadian;
        }

        /// <summary>
        /// Modify any degree angles to the angle within +-90 range
        /// </summary>
        /// <param name="degreeList"></param>
        /// <returns></returns>
        public static HTuple ToSigned180AngleDegree(this HTuple degreeList)
        {
            List<double> doubleList = new List<double>();
            foreach (var d in degreeList.DArr)
            {
                var degree = d.ToSigned180AngleDegree();
                doubleList.Add(degree);
            }

            return new HTuple(doubleList.ToArray());
        }

        /// <summary>
        /// Modify any degree angle to angle within +-90 range
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static float ToSigned180AngleDegree(this float fValue)
        {
            if (fValue > 90)
            {
                return ToSigned180AngleDegree(fValue - 180);
            }
            else if (fValue < -90)
            {
                return ToSigned180AngleDegree(fValue + 180);
            }
            else
            {
                return fValue;
            }
        }



        /// <summary>
        /// Modify any degree angle to angle within +-90 range
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        public static double ToSigned180AngleDegree(this double dValue)
        {
            if (dValue > 90)
            {
                return ToSigned180AngleDegree(dValue - 180);
            }
            else if (dValue < -90)
            {
                return ToSigned180AngleDegree(dValue + 180);
            }
            else
            {
                return dValue;
            }
        }

        /// <summary>
        /// Modify any degree angle to angle within +-180 range
        /// This operation will remove line arrow degree, keeps only line orientation
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        public static double ToSigned360AngleDegree(this double dValue)
        {
            if (dValue > 180)
            {
                return ToSigned360AngleDegree(dValue - 360);
            }
            else if (dValue < -180)
            {
                return ToSigned360AngleDegree(dValue + 360);
            }
            else
            {
                return dValue;
            }
        }

        /// <summary>
        /// From degree angle to radius angle
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        public static double ToRadianAngle(this double dValue)
        {
            if (dValue == 0) return 0;
            return dValue / csHalconHelper.DegreePerRadian;
        }

        /// <summary>
        /// From radius angle to degree angle
        /// </summary>
        /// <param name="dValue"></param>
        /// <returns></returns>
        public static double ToDegreeAngle(this double dValue)
        {
            return dValue * csHalconHelper.DegreePerRadian;
        }

        /// <summary>
        /// Modify any degree angle to angle within +-180 range
        /// This operation will remove line arrow degree, keeps only line orientation
        /// </summary>
        /// <param name="fValue"></param>
        /// <returns></returns>
        public static float ToSigned360AngleDegree(this float fValue)
        {
            if (fValue > 180)
            {
                return ToSigned180AngleDegree(fValue - 360);
            }
            else if (fValue < -180)
            {
                return ToSigned180AngleDegree(fValue + 360);
            }
            else
            {
                return fValue;
            }
        }


        public static HTuple ToHalconTuple(this bool bValue)
        {
            var ht_Value = new HTuple(bValue);
            return ht_Value;
        }





    }


}

