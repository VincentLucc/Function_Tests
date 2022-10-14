using DevExpress.Data.Filtering.Helpers;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HalconTest
{
    public class csHalconWindow
    {
        /// <summary>
        /// Main window
        /// </summary>
        public HTuple hv_WindowHandle;

        /// <summary>
        /// Current display objects
        /// </summary>
        public HalconView View;

        /// <summary>
        /// Source image for live image
        /// </summary>
        public HObject ho_ImageSource;

        /// <summary>
        /// Image for model creation
        /// </summary>
        public HObject ho_ImageModel;

        /// <summary>
        /// Inspection area, only use for once now, quick development
        /// </summary>
        public HObject ho_RegionSelection;

        /// <summary>
        /// Flag to avoid read file multiple times
        /// </summary>
        public bool IsModelImageLoaded;

        /// <summary>
        /// Model position found
        /// </summary>
        public PositionData PositionModel;

        /// <summary>
        /// Alignment image position
        /// </summary>
        public PositionData PositionLive;

        /// <summary>
        /// Offset between model position and new image position
        /// </summary>
        public HTuple PositionOffsetMatrix;

        /// <summary>
        /// Degree offset in unit Radion
        /// </summary>
        public float AngleOffsetRadian;

        /// <summary>
        /// Parent window if exist
        /// </summary>
        public HWindowControl windowControl;

 
        public int MouseGrayValue;
        public int MouseRow;
        public int MouseColumn;

        /// <summary>
        /// Used to resize the window when display the first image
        /// </summary>
        public bool IsWindowSizeAdjusted;



        /// <summary>
        /// Push to picture box
        /// </summary>
        /// <param name="DisplayBox"></param>
        /// <param name="hv_WindowHandle"></param>
        public void InitHalconWindow(PictureBox DisplayBox)
        {
            HOperatorSet.SetWindowAttr("background_color", "gray");
            HOperatorSet.OpenWindow(0, 0, DisplayBox.Width, DisplayBox.Height, DisplayBox.Handle, "visible", "", out hv_WindowHandle); //Init halcon window
            HDevWindowStack.Push(hv_WindowHandle); //Push window

            //Init variables
            View = new HalconView();

            windowControl.SizeChanged += WindowControl_SizeChanged;
            windowControl.HMouseMove += WindowControl_HMouseMove;

        }

        /// <summary>
        /// Use halcon window
        /// </summary>
        /// <param name="hWindow"></param>
        public bool LinkWindow(HWindowControl hWindow)
        {
            //Init variables
            windowControl = hWindow;
            hv_WindowHandle = hWindow.HalconWindow;
            View = new HalconView();

            try
            {
                //Set draw
                HOperatorSet.SetColor(hv_WindowHandle, HalconColor.Red);
                HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                csHalconCommon.set_display_font(hv_WindowHandle, 14, "mono", "true", "false");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconWindow.LinkWindow:\r\n" + ex.Message);
                return false;
            }

            windowControl.SizeChanged += WindowControl_SizeChanged;
            windowControl.HMouseMove += WindowControl_HMouseMove;

            //Finish up
            Clear();
            return true;
        }

        public void Clear()
        {
            HOperatorSet.ClearWindow(hv_WindowHandle);
            View.ClearAll();
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdatedPositionOffset()
        {
            if (PositionModel == null || PositionLive == null)
            {
                PositionOffsetMatrix = null;
                return;
            }

            try
            {
                HOperatorSet.VectorAngleToRigid(PositionModel.Row, PositionModel.Column, PositionModel.RotationRadian,
                                PositionLive.Row, PositionLive.Column, PositionLive.RotationRadian, out PositionOffsetMatrix);
                AngleOffsetRadian = PositionLive.RotationRadian - PositionModel.RotationRadian;
            }
            catch (Exception)
            {
                PositionOffsetMatrix = null;
                return;
            }
        }


        private void WindowControl_HMouseMove(object sender, HMouseEventArgs e)
        {
            GetMousePosition(e);
        }

        public bool TryDrawRectangle2(out Rectange2Data rectange2)
        {
            rectange2 = new Rectange2Data();

            try
            {
                //Draw method
                HOperatorSet.DrawRectangle2(hv_WindowHandle, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2);
                rectange2.Row = (float)row.D;
                rectange2.Column = (float)column.D;
                rectange2.Phi = (float)phi.D;
                rectange2.Length1 = (float)length1.D;
                rectange2.Length2 = (float)length2.D;


                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconView.TryDrawRectangle2:\r\n" + ex.Message);
                return false;
            }
        }



        public bool TryDrawLine(out LineData Line)
        {
            Line = new LineData();
            try
            {
                //Draw line
                windowControl.HalconWindow.DrawLine(out double row1, out double column1, out double row2, out double column2);
                Line.Row1 = (float)row1;
                Line.Column1 = (float)column1;
                Line.Row2 = (float)row2;
                Line.Column2 = (float)column2;

                //Get line info
                HOperatorSet.LinePosition(row1, column1, row2, column2, out HTuple rowCenter, out HTuple colCenter, out HTuple length, out HTuple phi);
                Line.RotationRadian = (float)phi.D;
                Line.CenterRow = (int)rowCenter.D;
                Line.CenterColumn = (int)colCenter.D;
                Line.Length = (float)length.D;

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconView.TryDrawLine:\r\n" + ex.Message);
                return false;
            }
        }



        private bool GetMousePosition(HMouseEventArgs e)
        {
            //Init variables

            try
            {
                HOperatorSet.GetMposition(hv_WindowHandle, out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Button);

                if (View.ViewImage == null)
                {
                    ResetMousePosition();
                    return false;
                }
                else
                {
                    HOperatorSet.GetGrayval(View.ViewImage, hv_Row, hv_Column, out HTuple hv_Grayval);
                    MouseRow = hv_Row;
                    MouseColumn = hv_Column;
                    MouseGrayValue = hv_Grayval;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconView.GetMousePosition:\r\n" + ex.Message);
                ResetMousePosition();
                return false;
            }

            //Pass all steps
            return true;
        }

        private void ResetMousePosition()
        {
            MouseRow = -1;
            MouseColumn = -1;
            MouseGrayValue = -1;
        }

        private void WindowControl_SizeChanged(object sender, EventArgs e)
        {
            if (View.ViewImage != null)
            {
                IsWindowSizeAdjusted = false;//Force to resize
                DisplayView();
            }
            else
            {
                HOperatorSet.SetWindowExtents(hv_WindowHandle, 0, 0, windowControl.Width - 1, windowControl.Height - 1);
            }
        }

 
        public void DisposeHObject(HObject _object)
        {
            if (_object != null)
            {
                _object.Dispose();
                _object = null;
            }
        }

        public void DisplayImage(HObject Image)
        {
            //Check image
            if (Image == null)
            {
                HOperatorSet.ClearWindow(hv_WindowHandle);
                return;
            }

            //Resize the window when display the image for the first time
            if (!IsWindowSizeAdjusted)
            {
                ResizeWindowToImageRatio(Image);
                IsWindowSizeAdjusted = true;
            }

            HTuple hv_Width1, hv_Height1;

            HOperatorSet.ClearWindow(hv_WindowHandle);
            HOperatorSet.SetSystem("flush_graphic", "false");//Minimum screen blink
            HOperatorSet.GetImageSize(Image, out hv_Width1, out hv_Height1);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_Height1, hv_Width1); //Image display area set, setted to display whole image         
            HOperatorSet.DispObj(Image, hv_WindowHandle);
            HOperatorSet.SetSystem("flush_graphic", "true");
        }



        public void DisplayView()
        {
            try
            {
                DisplayImage(View.ViewImage);

                //Display regions
                HOperatorSet.SetColor(hv_WindowHandle, HalconColor.RedTrans);
                if (View.Regions != null) HOperatorSet.DispObj(View.Regions, hv_WindowHandle);

                //Display contours
                HOperatorSet.SetColor(hv_WindowHandle, HalconColor.Green);
                if (View.Contours != null) HOperatorSet.DispObj(View.Contours, hv_WindowHandle);

                //Display marks
                foreach (var item in View.Marks)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, HalconColor.Green);
                    HOperatorSet.DispCross(hv_WindowHandle, item.X, item.Y, 30, csPublic.HalconDegree45);
                }

                //Display text
                for (int i = 0; i < View.Texts.Count; i++)
                {
                    if (i > 10) return;
                    string sMessage = View.Texts[i];
                    int iRow = 20 + i * 25;
                    int iColumn = 20;
                    HOperatorSet.DispText(hv_WindowHandle, sMessage, "window", iRow, iColumn, HalconColor.Red, null, null);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconWindow.DisplayView:\r\n" + ex.ToString());
            }

        }

        public HTuple CancelDrawAction()
        {
            HTuple result = null;
            try
            {
                //Right mouse up
                int iMouseButton = 4; //Right button
                HOperatorSet.SendMouseUpEvent(hv_WindowHandle, 10, 10, iMouseButton, out result);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("csHalconCommon.CancelDrawAction:\r\n" + ex.Message);
            }

            return result;
        }

        public void ResizeWindowToImageRatio(HObject Image)
        {
            HTuple hv_WidthImage, hv_HeightImage;
            int iWidthNew = windowControl.Size.Width - 1, iHeightNew = windowControl.Size.Height - 1;
            int iStartRow = 0, iStartColumn = 0;
            HOperatorSet.GetImageSize(Image, out hv_WidthImage, out hv_HeightImage);

            //Check ratio
            float fImageRatio = (float)hv_WidthImage / (float)hv_HeightImage; //Image Ratio
            float fWindowRatio = (float)windowControl.Size.Width / (float)windowControl.Size.Height; //Window Ratio
            if (fWindowRatio > fImageRatio)
            {
                iHeightNew = windowControl.Size.Height; //Keep height shrink width
                iWidthNew = (int)(windowControl.Size.Height * fImageRatio);
            }
            else if (fWindowRatio < fImageRatio)
            {
                iWidthNew = windowControl.Size.Width; //Keep width shrink height
                iHeightNew = (int)(windowControl.Size.Width / fImageRatio);
            }


            //Move window to center
            //Move row
            if ((windowControl.Size.Width - iWidthNew) > 2)
            {
                iStartColumn = (windowControl.Size.Width - iWidthNew) / 2;
            }

            //Move column
            if ((windowControl.Size.Height - iHeightNew) > 2)
            {
                iStartRow = (windowControl.Size.Height - iHeightNew) / 2;
            }


            //Set window size
            HOperatorSet.SetWindowExtents(hv_WindowHandle, iStartRow, iStartColumn, iWidthNew, iHeightNew);
        }

        /// <summary>
        /// Keep a alone, this image is used multiple times
        /// </summary>
        /// <param name="newImage"></param>
        public void SetModelImage(HObject newImage)
        {
            if (ho_ImageModel != null)
            {
                ho_ImageModel.Dispose();
                ho_ImageModel = null;
            }

            if (newImage != null)
            {
                ho_ImageModel = newImage.Clone();
            }
        }

        /// <summary>
        /// Live image, only copy to increase speed
        /// </summary>
        /// <param name="newImage"></param>
        public void SetSourceImage(HObject newImage)
        {
            if (ho_ImageSource != null)
            {
                ho_ImageSource.Dispose();
                ho_ImageSource = null;
            }

            if (newImage != null)
            {
                ho_ImageSource = newImage;
            }
        }

        public bool LoadImageAndDisplay(string sFileName, bool isModelImage = false)
        {
            //Init image
            ho_ImageSource = null;

            //Try to read image
            try
            {
                HOperatorSet.ReadImage(out ho_ImageSource, sFileName);
            }
            catch (Exception e)
            {
                Debug.WriteLine("csHalconWindow.ReadImage:\r\n" + e.Message);
                return false;
            }

            //Display image
            if (ho_ImageSource != null)
            {
                IsWindowSizeAdjusted = false;
                DisplayImage(ho_ImageSource); //Display image
            }

            //Check if model image
            if (isModelImage)
            {
                //Set process and view
                if (ho_ImageModel != null) ho_ImageModel.Dispose();
                ho_ImageModel = ho_ImageSource.Clone();
            }

            //Set view
            View.SetViewImage(ho_ImageSource);

            //Pass all steps
            return true;
        }


        public bool LoadModelImage(string sPath)
        {
            try
            {
                if (!IsModelImageLoaded || ho_ImageModel == null)
                {//Try to load image
                    if (string.IsNullOrWhiteSpace(sPath)) return false;
                    if (ho_ImageModel != null)
                    {
                        ho_ImageModel.Dispose();
                        ho_ImageModel = null;
                    }
                    HOperatorSet.ReadImage(out ho_ImageModel, sPath);
                }

                //Set view
                View.SetViewImage(ho_ImageModel);

                IsModelImageLoaded = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("csHalconWindow.LoadModelImage:\r\n" + e.Message);
                return false;
            }

            //Pass all steps
            return true;
        }

        public bool SaveImage(HObject ho_Image, string sPath)
        {
            //Try to read image
            try
            {
                //Check folder
                string sDirectory = Path.GetDirectoryName(sPath);
                if (!Directory.Exists(sDirectory)) Directory.CreateDirectory(sDirectory);

                HOperatorSet.WriteImage(ho_Image, "tiff", 0, sPath);
            }
            catch (Exception e)
            {
                Debug.WriteLine("csHalconWindow.SaveImage:\r\n" + e.Message);
                return false;
            }

            //Pass all steps
            return true;
        }
    }
}

