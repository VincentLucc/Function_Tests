using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using _CommonCode_Framework;
using DevExpress.Charts.Native;
using DevExpress.Utils.Design;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using HalconDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HalconTest
{
    public class csHalconWindow
    {
        /// <summary>
        /// Main window
        /// </summary>
        [XmlIgnore, JsonIgnore]
        public HTuple hv_WindowHandle;

        /// <summary>
        /// Current display objects
        /// </summary>
        public HalconView View;

        public csUIRefreshHelper RefreshHelper { get; set; }

        /// <summary>
        /// Parent window if exist
        /// </summary>
        public HWindowControl windowControl;

        private bool ControlInvalid => windowControl == null ||
                                windowControl.Disposing ||
                                windowControl.IsDisposed ||
                                !windowControl.Visible ||
                                DisposeRequest;


        //Point when mouse move
        public HalconPoint MouseMovePosition;
        public int MouseGrayValue;

        //Point when mouse key down
        public HalconPoint MouseDownPosition;

        /// <summary>
        /// Value type
        /// </summary>
        public System.Drawing.Size LastWindowSize;

        /// <summary>
        /// Last image shown
        /// </summary>
        public System.Drawing.Size LastImageSize;

        public DateTime LastMouseUpTime;


        /// <summary>
        /// Actual display area
        /// </summary>
        public csViewPortBoundary DisplayPort;

        /// <summary>
        /// Windows view window layout
        /// </summary>
        private csViewPortLayout ViewLayout { get; set; }

        /// <summary>
        /// Indicate whether set the view port of the image is required
        /// </summary>
        public bool IsImageViewPortInit { get; set; }


        /// <summary>
        /// Store current drawing items
        /// </summary>
        public csHalconWindowDraw DrawData { get; set; }


        public csViewSettings ViewSettings = new csViewSettings();


        /// <summary>
        /// Check display view time consumption
        /// </summary>
        public Stopwatch watchView = new Stopwatch();

        /// <summary>
        /// User selection related to window objects
        /// Used to highlight user selections
        /// </summary>
        public csHalconWindowSelection Selection = new csHalconWindowSelection();


        public event EventHandler ManualMouseDoubleClick;
        public event EventHandler ManualMouseClick;

        private csFPSHelper FPSHelper;

        /// <summary>
        /// Mark the window to be disposed
        /// </summary>
        public bool DisposeRequest;

        public csHalconWindow()
        {
            FPSHelper = new csFPSHelper(2000, 3000, 300);
            MouseDownPosition = new HalconPoint();
            MouseMovePosition = new HalconPoint();
            RefreshHelper = new csUIRefreshHelper();
        }

        /// <summary>
        /// Use halcon window, time-consuming
        /// </summary>
        /// <param name="hWindow"></param>

        public bool LinkWindow(HWindowControl hWindow)
        {
            //Clean up
            if (windowControl != null) ClearEvents();

            //Init variables
            windowControl = hWindow;
            hv_WindowHandle = hWindow.HalconWindow;
            View = new HalconView();
            ViewLayout = new csViewPortLayout();
            DrawData = new csHalconWindowDraw();

            ClearLastSize();

            try
            {
                //Set draw
                HOperatorSet.SetColor(hv_WindowHandle, csHalconColorHelper.Red);
                HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                csHalconHelper.set_display_font(hv_WindowHandle, 14, "mono", "true", "false");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconWindow.LinkWindow:\r\n" + ex.Message);
                return false;
            }

            //Reload the events
            windowControl.SizeChanged += WindowControl_SizeChanged;
            windowControl.MouseMove += WindowControl_MouseMove;
            windowControl.MouseWheel += WindowControl_MouseWheel;
            windowControl.MouseDown += WindowControl_MouseDown;
            windowControl.MouseUp += WindowControl_MouseUp;


            //Finish up
            Clear();
            return true;
        }


        private void WindowControl_MouseUp(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine("WindowControl_MouseUp");

            //Click event doesn't trigger, added manual double click
            int iDoubleClickGap = 250;
            if ((csDateTimeHelper.CurrentTime - LastMouseUpTime) > TimeSpan.FromMilliseconds(iDoubleClickGap))
            {//Mouse is moving
                LastMouseUpTime = csDateTimeHelper.CurrentTime;
                //Clicked once
                ManualMouseClick?.Invoke(this, e);
            }
            else
            {//Clicked twice or above
                ManualMouseDoubleClick?.Invoke(this, e);
            }
        }


        public void AddDisplayRecord()
        {
            FPSHelper.AddRecord();
        }

        public double GetDisplayFPS()
        {
            return FPSHelper.GetFPS();
        }

        private void WindowControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (ControlInvalid) return;

            //Ignore action when drawing
            if (DrawData.IsDrawing)
            {
                "WindowControl_MouseDown.IgnoreAction".TraceRecord();
                return;
            }

            var position = GetMouseImagePosition(e);
            if (position == null) return;

            //Remember current mouse position as scale point
            MouseDownPosition = position;
        }


        private void HandleDrawEvents()
        {

        }



        private void WindowControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ControlInvalid) return;

            // Mouse wheel event might grab an error X reading, use previouly save mouse position for mouse wheel event
            var position = GetMouseImagePosition();
            if (position == null) return;

            if (e.Delta > 0)
            {
                ZoomOut(position);
            }
            else if (e.Delta < 0)
            {
                ZoomIn(position);
            }
        }

        public HObject GetCurrentViewImage()
        {
            if (View == null) return null;
            return View.GetViewImage();
        }

        public void Clear()
        {
            HOperatorSet.ClearWindow(hv_WindowHandle);
            View.ClearAll();
        }

        private void ClearEvents()
        {
            windowControl.SizeChanged -= WindowControl_SizeChanged;
            windowControl.MouseMove -= WindowControl_MouseMove;
            windowControl.MouseWheel -= WindowControl_MouseWheel;
            windowControl.MouseDown -= WindowControl_MouseDown;
            windowControl.MouseUp -= WindowControl_MouseUp;
        }

        public void Dispose()
        {
            ClearEvents();
            //Init memory
            HOperatorSet.ClearWindow(hv_WindowHandle);
            View.ClearAll();

            windowControl.Dispose(); //will auto dispose
        }

        private void WindowControl_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("WindowControl_Click");
        }

        /// <summary>
        /// Init size memory will cause a re-fit when image shown
        /// </summary>
        public void ClearLastSize()
        {
            LastImageSize = new System.Drawing.Size(0, 0);
            LastWindowSize = new System.Drawing.Size(0, 0);
        }




        /// <summary>
        /// Zoom 30% by default, magenify the image
        /// </summary>
        /// <param name="zoomRatio"></param>
        public void ZoomIn(HalconPoint zoomPosition)
        {
            //Set Image Scale
            ZoomImageViewPort(zoomPosition, 1.2f);

            DisplayView();
        }


        /// <summary>
        /// Zoom 50% by default, shrink the image
        /// </summary>
        public void ZoomOut(HalconPoint zoomPosition)
        {
            //Set Image Scale
            ZoomImageViewPort(zoomPosition, 0.8f);

            DisplayView();
        }

        public void ZoomOrigin()
        {
            //ZoomImageViewPort(null, null);
            IsImageViewPortInit = false;//Force reset the display area
            DisplayView();
        }

     
        /// <summary>
        /// If "offSetMatrix" exist, the region draw will reversely affined to the image
        /// </summary>
        /// <param name="drawObject"></param>
        /// <param name="offSetMatrix"></param>
        public void DrawRectRegion(Rectangle2Data drawObject, HTuple offSetMatrix)
        {
            DrawData.IsDrawing = true;
            DrawData.DrawShape = _drawShapeType.Rectangle2;
            DrawData.PositionOffsetMatrix = offSetMatrix;



            //Clear previous draw
            if (DrawData.DrawHandle != null)
            {
                HOperatorSet.DetachDrawingObjectFromWindow(hv_WindowHandle, DrawData.DrawHandle);
                DrawData.DrawHandle.Dispose();
                DrawData.DrawHandle = null;
            }

            if (drawObject == null || !drawObject.IsInit)
            {//Create an sample drawing object area, load the object without chaning the reference link
                drawObject.CreateSampleRegion(hv_WindowHandle);
            }

            //Save current target
            DrawData.Rectangle2 = drawObject;

            //Define draw while checking the alignment existence
            HTuple drawHandle = null;
            if (offSetMatrix == null)
            {//Create from origin
                HOperatorSet.CreateDrawingObjectRectangle2(drawObject.Row, drawObject.Column, drawObject.Phi, drawObject.Length1, drawObject.Length2, out drawHandle);
            }
            else
            {//Offset exist, create draw based on current mapped position
                var rect2 = new Rectangle2Data();
                rect2.CopyInstanceValues(drawObject);
                rect2.MapRegion(offSetMatrix);
                HOperatorSet.CreateDrawingObjectRectangle2(rect2.Row, rect2.Column, rect2.Phi, rect2.Length1, rect2.Length2, out drawHandle);
            }

            DrawData.DrawHandle = drawHandle;
            HOperatorSet.AttachDrawingObjectToWindow(hv_WindowHandle, drawHandle);
        }

 
        public void DrawLineRegion(csLineData line, HTuple offSetMatrix, bool isVertical = false)
        {
            DrawData.IsDrawing = true;
            DrawData.DrawShape = _drawShapeType.Line;
            DrawData.PositionOffsetMatrix = offSetMatrix;


            if (DrawData.DrawHandle != null)
            {
                HOperatorSet.DetachDrawingObjectFromWindow(hv_WindowHandle, DrawData.DrawHandle);
                DrawData.DrawHandle.Dispose();
                DrawData.DrawHandle = null;
            }

            if (line == null || !line.IsInit)
            {//Create an sample drawing object area, load the object without changing the reference link
                line.LoadSampleLine(hv_WindowHandle, isVertical);
            }

            //Set current draw region reference
            DrawData.Line = line;

            //Define draw while checking the alignment existence
            HTuple drawHandle = null;
            if (offSetMatrix == null)
            {//Create from origin
                HOperatorSet.CreateDrawingObjectLine(line.Row1, line.Column1, line.Row2, line.Column2, out drawHandle);
            }
            else
            {//Offset exist, create draw based on current mapped position
                var newLine = new csLineData();
                newLine.CopyInstanceValues(line);
                newLine.MapRegion(offSetMatrix);
                HOperatorSet.CreateDrawingObjectLine(line.Row1, line.Column1, line.Row2, line.Column2, out drawHandle);
            }

            DrawData.DrawHandle = drawHandle;
            HOperatorSet.AttachDrawingObjectToWindow(hv_WindowHandle, drawHandle);
        }

        public Rectangle2Data CreateSampleRegionRectangle()
        {

            HOperatorSet.GetPart(hv_WindowHandle, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
            float iHeightSegment = (float)(row2.D - row1.D) / 4;
            float iWidthSegment = (float)(column2.D - column1.D) / 4;

            var drawObject = new Rectangle2Data()
            {
                Row = (float)row1.D + 2 * iHeightSegment,
                Column = (float)column1.D + 2 * iWidthSegment,
                Phi = 0,
                Length1 = iWidthSegment,
                Length2 = iHeightSegment,
                IsInit = true
            };

            return drawObject;
        }

        public csLineData CreateSampleRegionLine()
        {

            HOperatorSet.GetPart(hv_WindowHandle, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
            float iHeightSegment = (float)(row2.D - row1.D) / 4;
            float iWidthSegment = (float)(column2.D - column1.D) / 4;

            var drawObject = new csLineData()
            {
                Row1 = (float)row1.D + 2 * iHeightSegment,
                Column1 = (float)column1.D + iWidthSegment,
                Row2 = (float)row1.D + 2 * iHeightSegment,
                Column2 = (float)column2.D - iWidthSegment,
                IsInit = true,
            };


            return drawObject;
        }

        /// <summary>
        /// Close and get current draw location
        /// </summary>
        /// <param name="drawObject"></param>
        public void CloseDrawRegion()
        {
            try
            {
                if (DrawData.DrawHandle == null) return;

                switch (DrawData.DrawShape)
                {
                    case _drawShapeType.Rectangle2:
                        {
                            if (DrawData.Rectangle2 == null) return;

                            //Get current rectangle
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "row", out HTuple row);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "column", out HTuple column);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "phi", out HTuple phi);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "length1", out HTuple length1);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "length2", out HTuple length2);

                            //Show draw result
                            Trace.WriteLine($"Draw:R({row.D.ToString("f0")}),C({column.D.ToString("f0")})," +
                                            $"Deg({phi.TupleDeg().D.ToString("f0")}),L1({length1.D.ToString("f0")}),L2({length2.D.ToString("f0")})");
                            //Load values
                            DrawData.Rectangle2.Init(row, column, phi, length1, length2);

                            //Check if alignment exist
                            if (DrawData.PositionOffsetMatrix != null)
                            {
                                HOperatorSet.HomMat2dInvert(DrawData.PositionOffsetMatrix, out HTuple matrixInvert);
                                DrawData.Rectangle2.MapRegion(matrixInvert);
                            }


                            //Handle special request
                            switch (DrawData.DrawAction)
                            {
                                case _drawAction.Append:
                                    {
                                        //Check region
                                        if (DrawData.DrawSource == null) break;

                                        if (DrawData.DrawSource.FreeRegionData.IsRegion() != true)
                                            HOperatorSet.GenEmptyRegion(out DrawData.DrawSource.FreeRegionData);

                                        //Union the draw object
                                        var newRegion = DrawData.Rectangle2.CreateRegion();
                                        HOperatorSet.Union2(DrawData.DrawSource.FreeRegionData, newRegion, out HObject regionUnion);
                                        newRegion.Dispose();
                                        DrawData.DrawSource.FreeRegionData.Dispose();
                                        DrawData.DrawSource.FreeRegionData = regionUnion;

                                        //if (DrawData.DrawSource.ParentTool is csToolPrintingInspection printTool)
                                        //{
                                        //    if (DrawData.DrawSource.Description == "Normal")
                                        //    {
                                        //        printTool.NormalRegion.Dispose();
                                        //        printTool.NormalRegion = regionUnion;
                                        //    }
                                        //    else if (DrawData.DrawSource.Description == "Strict")
                                        //    {
                                        //        printTool.StrictRegion.Dispose();
                                        //        printTool.StrictRegion = regionUnion;
                                        //    }
                                        //    else if (DrawData.DrawSource.Description == "Loose")
                                        //    {
                                        //        printTool.LooseRegion.Dispose();
                                        //        printTool.LooseRegion = regionUnion;
                                        //    }

                                        //    printTool.UIRequest.UIRequest = _PrintCheckUIRequestType.UpdateTemplate;
                                        //}
                                    }
                                    break;
                                case _drawAction.Erase:
                                    {
                                        //Check region
                                        if (DrawData.DrawSource == null) break;

                                        if (DrawData.DrawSource.FreeRegionData.IsRegion() != true)
                                        {//No region, return new region
                                            HOperatorSet.GenEmptyRegion(out DrawData.DrawSource.FreeRegionData);
                                            break;
                                        }

                                        var newRegion = DrawData.Rectangle2.CreateRegion();
                                        HOperatorSet.Intersection(DrawData.DrawSource.FreeRegionData, newRegion, out HObject intersection);
                                        newRegion.Dispose();
                                        if (intersection.IsRegion() == true)
                                        {
                                            HOperatorSet.Difference(DrawData.DrawSource.FreeRegionData, intersection, out HObject difference);
                                            intersection.Dispose();
                                            DrawData.DrawSource.FreeRegionData.Dispose();
                                            DrawData.DrawSource.FreeRegionData = difference;

                                            //if (DrawData.DrawSource.ParentTool is csToolPrintingInspection printTool)
                                            //{
                                            //    if (DrawData.DrawSource.Description == "Normal")
                                            //    {
                                            //        printTool.NormalRegion.Dispose();
                                            //        printTool.NormalRegion = difference;
                                            //    }
                                            //    else if (DrawData.DrawSource.Description == "Strict")
                                            //    {
                                            //        printTool.StrictRegion.Dispose();
                                            //        printTool.StrictRegion = difference;
                                            //    }
                                            //    else if (DrawData.DrawSource.Description == "Loose")
                                            //    {
                                            //        printTool.LooseRegion.Dispose();
                                            //        printTool.LooseRegion = difference;
                                            //    }

                                            //    printTool.UIRequest.UIRequest = _PrintCheckUIRequestType.UpdateTemplate;
                                            //}
                                        }

                                    }
                                    break;
                            }

                            //The assignment is finished -> clear reference
                            DrawData.Rectangle2 = null;
                            DrawData.DrawSource = null;
                        }
                        break;

                    case _drawShapeType.Line:
                        {
                            if (DrawData.Line == null) return;

                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "row1", out HTuple row1);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "column1", out HTuple col1);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "row2", out HTuple row2);
                            HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "column2", out HTuple col2);

                            //Load values
                            DrawData.Line.Init(row1, col1, row2, col2);
                            DrawData.Line.GenLinePosition(); //generate line position info

                            //Check if alignment exist
                            if (DrawData.PositionOffsetMatrix != null)
                            {
                                HOperatorSet.HomMat2dInvert(DrawData.PositionOffsetMatrix, out HTuple matrixInvert);
                                DrawData.Line.MapRegion(matrixInvert);
                            }

                            //The assignment is finished -> clear reference
                            DrawData.Line = null;

                        }
                        break;

                    case _drawShapeType.Custom:
                        HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "row", out HTuple rowNew);
                        HOperatorSet.GetDrawingObjectParams(DrawData.DrawHandle, "column", out HTuple colNew);

                        //HOperatorSet.GenRegionPoints(out HObject region, rowNew, colNew);
                        HOperatorSet.GenRegionPolygon(out HObject region, rowNew, colNew);
                        DrawData.DrawSource.FreeRegionData = region;
                        break;
                }


                HOperatorSet.DetachDrawingObjectFromWindow(hv_WindowHandle, DrawData.DrawHandle);
                DrawData.PositionOffsetMatrix = null;
                DrawData.DrawHandle.Dispose();
                DrawData.DrawHandle = null;

            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconWindow.CloseDrawRegion\r\n" + ex.Message);
            }
            finally
            {
                DrawData.IsDrawing = false;
            }
        }


        private void WindowControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (ControlInvalid) return;

            try
            {
                //Get image gray value
                if (!GetMouseImagePositionAndGray(e)) return;

                //Disable image move when drawing
                if (DrawData.IsDrawing) return;


                //Check shift required
                if (e.Button == MouseButtons.Left)
                {
                    if (MouseMovePosition.Row != MouseDownPosition.Row || MouseMovePosition.Column != MouseDownPosition.Column)
                    {//Shift the image
                        //Get offset
                        var rowOffset = MouseDownPosition.Row - MouseMovePosition.Row;
                        var columnOffset = MouseDownPosition.Column - MouseMovePosition.Column;
                        HOperatorSet.GetPart(hv_WindowHandle, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);

                        HOperatorSet.SetPart(hv_WindowHandle, row1 + rowOffset, column1 + columnOffset, row2 + rowOffset, column2 + columnOffset);
                        Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} WindowControl_MouseMove.SetPart");
                        DisplayView();
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine($"csHalconWindow.WindowControl_MouseMove.Exception:\r\n{exception.GetMessageDetail()}");
            }

        }


        public bool TryDrawRectangle2(out Rectangle2Data rectange2)
        {
            rectange2 = new Rectangle2Data();

            try
            {
                //Draw method
                HOperatorSet.DrawRectangle2(hv_WindowHandle, out HTuple row, out HTuple column, out HTuple phi, out HTuple length1, out HTuple length2);
                rectange2.Init(row, column, phi, length1, length2);

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconView.TryDrawRectangle2:\r\n" + ex.Message);
                return false;
            }
        }



        public bool TryDrawLine(out csLineData Line)
        {
            Line = new csLineData();
            try
            {
                //Draw line
                windowControl.HalconWindow.DrawLine(out double row1, out double column1, out double row2, out double column2);
                Line.Init(row1, column1, row2, column2);

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconView.TryDrawLine:\r\n" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Mouse wheel event might grab an error X reading, use previouly save mouse position for mouse wheel event
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private HalconPoint GetMouseImagePosition(MouseEventArgs e = null)
        {
            var mousePosition = new HalconPoint();

            try
            {
                //Get current window size
                if (ControlInvalid)
                {
                    Trace.WriteLine("csHalconWindow.GetMouseImagePosition:Window disposed");
                    return null;
                }

                //Notice row ,col value is not correct, ignore
                HOperatorSet.GetWindowExtents(hv_WindowHandle, out HTuple row, out HTuple col, out HTuple width, out HTuple height);

                //Read from mouse move record instead, since the mouse X position might change only in the mouse wheel event
                int mouseX = ViewLayout.MouseX;
                int mouseY = ViewLayout.MouseY;
                if (e != null)
                {
                    mouseX = e.X;
                    mouseY = e.Y;
                    ViewLayout.SetMouseWindowPosition(e);
                }


                //Check mouse X in the halcon window or not (Edge is window, not the image itself)
                double gapX = (windowControl.Size.Width - width.D) / 2.0;
                if (mouseX <= gapX || mouseX >= (gapX + width.D)) return null;

                //Check mouse Y in the halcon window or not (Edge is window, not the image itself)
                double gapY = (windowControl.Size.Height - height.D) / 2.0;
                if (mouseY <= gapY || mouseY >= (gapY + height.D)) return null;


                HOperatorSet.GetMposition(hv_WindowHandle, out HTuple iRow, out HTuple iColumn, out HTuple iButton);
                mousePosition.Row = (int)iRow.D;
                mousePosition.Column = (int)iColumn.D;

                return mousePosition;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconWindow.GetMouseImagePosition:\r\n" + ex.Message);
                return null;
            }
        }

        private bool GetMouseImagePositionAndGray(MouseEventArgs e)
        {
            //Init variables
            try
            {
                //Get current window size
                if (ControlInvalid)
                {
                    Trace.WriteLine("csHalconWindow.GetMouseImagePositionGray:Window disposed");
                    return false;
                }

                //Get current window size
                //Notice row ,col value is not correct, ignore
                HOperatorSet.GetWindowExtents(hv_WindowHandle, out HTuple row, out HTuple col, out HTuple width, out HTuple height);

                ViewLayout.SetExtendInfo(row, col, width, height);
                ViewLayout.SetMouseWindowPosition(e);


                //Check image valid
                if (!View.IsViewImageValid)
                {
                    ResetMouseMovePosition();
                    return false;
                }

                //Directly get the mouse position
                HOperatorSet.GetMposition(hv_WindowHandle, out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Button);

                //Check mouse inside the image
                if (hv_Row.D < 0 ||
                    hv_Row.D >= LastImageSize.Height ||
                    hv_Column.D < 0 ||
                    hv_Column.D >= LastImageSize.Width)
                {
                    ResetMouseMovePosition();
                    return false;
                }

                //Always set the mouse position
                MouseMovePosition.Row = hv_Row;
                MouseMovePosition.Column = hv_Column;
                //Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.GetMouseImagePositionGray.Position: {MouseMovePosition.Row}, {MouseMovePosition.Column}.");

                //Get the mouse gray value
                var dispImage = View.GetLastDisplayImageItem();
                if (dispImage == null) dispImage = View.ViewImage;
                HOperatorSet.GetGrayval(dispImage, hv_Row, hv_Column, out HTuple hv_Grayval);

                //Save the gray value
                MouseGrayValue = hv_Grayval;
                //Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.GetMouseImagePositionGray.Gray: {MouseGrayValue}.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csHalconWindow.GetMouseImagePositionGray:\r\n" + ex.Message);
                ResetMouseMovePosition();
                return false;
            }

            //Pass all steps
            return true;
        }

        private void ResetMouseMovePosition()
        {
            MouseMovePosition.Reset();
            MouseGrayValue = -1;
        }

        private void WindowControl_SizeChanged(object sender, EventArgs e)
        {
            if (ControlInvalid) return;
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} WindowControl_SizeChanged:{windowControl.Size}");

            try
            {
                if (!View.IsViewImageValid) return;

                //Only reset the image view port when size change is large
                if (this.LastWindowSize.Width == 0 ||
                    this.LastWindowSize.Height == 0)
                {//Size always reset 
                    IsImageViewPortInit = false;
                }
                else
                {
                    float minimumChangeRatio = 0.1f;
                    var currentSize = this.windowControl.Size;
                    var widthDiff = Math.Abs((float)currentSize.Width / (float)this.LastWindowSize.Width - 1);
                    var heightDiff = Math.Abs((float)currentSize.Height / (float)this.LastWindowSize.Height - 1);
                    string sSizeInfo = $"{LastWindowSize},{currentSize},[{widthDiff},{heightDiff}]";

                    if (widthDiff > minimumChangeRatio || heightDiff > minimumChangeRatio)
                    {
                        //Only change the view port when the window size changes is large
                        //This avoids false resetting the viewport when window control has overlapping items
                        IsImageViewPortInit = false;
                        Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} WindowControl_SizeChanged.UpdateViewPort: {sSizeInfo}");
                    }
                    else
                    {
                        Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} WindowControl_SizeChanged.IgnoreViewPort: {sSizeInfo}");
                    }

                }
                DisplayView();

            }
            catch (Exception exception)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.WindowControl_SizeChanged:\r\n" + exception.Message);
            }
            finally
            {
                this.LastWindowSize = this.windowControl.Size;
            }
        }



        public void DisplayImage(HObject image)
        {
            var newView = new HalconView(image);
            this.View = newView;
            DisplayView();
        }

        /// <summary>
        /// Internal usage only, for image without view
        /// </summary>
        /// <param name="Image"></param>
        private void DisplayBaseImage(HObject Image)
        {
            //Check image
            if (Image == null || !Image.IsInitialized())
            {
                HOperatorSet.SetSystem("flush_graphic", "false");//Minimum screen blink
                HOperatorSet.ClearWindow(hv_WindowHandle);
                return;
            }

            HOperatorSet.SetSystem("flush_graphic", "false");//Minimum screen blink
            HOperatorSet.ClearWindow(hv_WindowHandle);



            //Set image view port
            if (!IsImageViewPortInit || !IsImageSizeEqual(Image))
            {
                InitImageViewPort(Image);
                IsImageViewPortInit = true;
            }

            HOperatorSet.DispObj(Image, hv_WindowHandle);
            ShowImageBorderAction(Image);
            HOperatorSet.SetSystem("flush_graphic", "true");
        }

        private void ShowImageBorderAction(HObject image)
        {
            if (ViewSettings == null) return;
            if (!ViewSettings.ShowImageBorder) return;

            //Only show the image in certain condition
            HOperatorSet.GetImageSize(image, out HTuple width, out HTuple height);
            HOperatorSet.GetPart(hv_WindowHandle, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2);


            HOperatorSet.GenRectangle1(out HObject rectBorder, -1, -1, height + 1, width + 1);

            //Get color
            var sColor = ViewSettings.ImageBorderColor.ToHalconColorParameter();
            HOperatorSet.SetColor(hv_WindowHandle, sColor);

            //Display border
            HOperatorSet.SetDraw(hv_WindowHandle, "margin");
            HOperatorSet.DispObj(rectBorder, hv_WindowHandle);
        }

        private bool IsImageSizeEqual(HObject hImage)
        {
            HOperatorSet.GetImageSize(hImage, out HTuple width, out HTuple height);
            int iWidth = (int)width.D;
            int iHeight = (int)height.D;

            if (LastImageSize.Width == iWidth &&
                LastImageSize.Height == iHeight)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// Keep the image in ratio
        /// </summary>
        public void InitImageViewPort(HObject Image)
        {
            try
            {
                if (!Image.IsValid())
                {
                    Trace.WriteLine("csHalconWindow.InitImageViewPort.InvalidImage");
                    return;
                }

                //Get current window size
                if (ControlInvalid)
                {
                    Trace.WriteLine("GetMouseImagePosition:Window disposed");
                    return;
                }

                //Get image and window size ratio
                HOperatorSet.GetImageSize(Image, out HTuple hv_WidthImage, out HTuple hv_HeightImage);
                HOperatorSet.GetWindowExtents(hv_WindowHandle, out HTuple row, out HTuple column, out HTuple hv_WidthWindow, out HTuple hv_HeightWindow);
                double dRatioImage = hv_WidthImage.D / hv_HeightImage.D;
                double dRatioWindow = hv_WidthWindow.D / hv_HeightWindow.D;
                csViewPortBoundary displayPort = new csViewPortBoundary();
                

                //Save the image size
                LastImageSize = new System.Drawing.Size((int)hv_WidthImage.D, (int)hv_HeightImage.D);

                //Set the view port based on the window and image ratio
                if (dRatioImage == dRatioWindow)
                {//Same ratio, directly display the whole image
                    displayPort.Row1 = 0;
                    displayPort.Col1 = 0;
                    displayPort.Row1 = 0;
                    displayPort.Row1 = 0;
                    HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightImage, hv_WidthImage);
                }
                else if (dRatioWindow > dRatioImage)
                {//Image fill top and bottom, but left and right is empty

                    //Set top and bottom
                    double dRow1 = 0;
                    double dRow2 = hv_HeightImage.D - 1;

                    //Get the image display width inside the window(< Window Width)
                    double dImageWidthInWindow = (hv_HeightWindow.D * hv_WidthImage.D) / hv_HeightImage.D;

                    //Get full window width inside the image(> Image Width)
                    double dWindowWidthInImage = (hv_WidthImage.D * hv_WidthWindow.D) / dImageWidthInWindow;

                    //Calculate the left and right start points
                    double dCol1 = hv_WidthImage.D / 2 - dWindowWidthInImage / 2;
                    double dCol2 = hv_WidthImage.D / 2 + dWindowWidthInImage / 2;
                    HOperatorSet.SetPart(hv_WindowHandle, dRow1, dCol1, dRow2, dCol2);
                }
                else if (dRatioWindow < dRatioImage)
                {//Image fill left and right, but top and bottom is empty
                 //Set left and right
                    double dCol1 = 0;
                    double dCol2 = hv_WidthImage.D - 1;

                    //Get the image display height inside the window(< Window Height)
                    double dImageHeightInWindow = (hv_WidthWindow.D * hv_HeightImage.D) / hv_WidthImage.D;

                    //Get full window width inside the image(> Image Height)
                    double dWindowHeightInImage = (hv_HeightImage.D * hv_HeightWindow.D) / dImageHeightInWindow;

                    //Calculate the left and right start points
                    double dRow1 = hv_HeightImage.D / 2 - dWindowHeightInImage / 2;
                    double dRow2 = hv_HeightImage.D / 2 + dWindowHeightInImage / 2;
                    HOperatorSet.SetPart(hv_WindowHandle, dRow1, dCol1, dRow2, dCol2);
                }

                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} InitImageViewPort.SetPart");
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} InitImageViewPort.Exception:\r\n{e.GetMessageDetail()}");
            }
        }

        /// <summary>
        /// Must remove all int calculation replace with float or double
        /// </summary>
        /// <param name="zoomPosition"></param>
        /// <param name="isZoomIn">Zoom in/Zoom out/Reset</param>
        public void ZoomImageViewPort(HalconPoint zoomPosition, float fZoomFactor)
        {
            if (!View.IsViewImageValid) return;

            try
            {
                //Init variables
                if (fZoomFactor < 0f || fZoomFactor > 10f)
                {
                    Trace.WriteLine($"ZoomImageViewPort: Input out of range.{fZoomFactor}");
                    return;
                }


                //Get current view port location
                HOperatorSet.GetPart(hv_WindowHandle, out HTuple hRow1, out HTuple hColumn1, out HTuple hRow2, out HTuple hColumn2);
                //Trace.WriteLine($"ZoomImageViewPort.ImagePart: [Row1:{hRow1.D},Col1:{hColumn1.D},Row2:{hRow2.D},Col2:{hColumn2.D}]");

                //View height
                float preHeight = (float)(hRow2.D - hRow1.D);
                float preWidth = (float)(hColumn2.D - hColumn1.D);

                //Check the zoom position
                //Already loaded in the "WindowControl_MouseWheel" event
                if (zoomPosition == null)
                {//Use center position to zoom
                    zoomPosition = new HalconPoint()
                    {
                        Row = (float)(hRow1.D + preHeight / 2),
                        Column = (float)(hColumn1.D + preWidth / 2)
                    };
                }

                //Caculate window location and size
                //Compare with fit whole window,zoomed image gap between image and window edge changed by a zoom ratio 
                float fRowGapLeft = zoomPosition.Row - (float)hRow1.D; //Gap of mouse point to left view port edge
                float fColumnGapTop = zoomPosition.Column - (float)hColumn1.D;//Gap of mouse point to top view port edge

                //New window start point
                float newRow1 = zoomPosition.Row - (fRowGapLeft / fZoomFactor); //New view left position, mouse point minus new left gap
                float newColumn1 = zoomPosition.Column - (fColumnGapTop / fZoomFactor);//New view top position, mouse point minus new top gap

                //Define end point:
                //End point = Scaled start + scaled size)
                float newRow2 = newRow1 + preHeight / fZoomFactor;
                float newColumn2 = newColumn1 + preWidth / fZoomFactor;

                //Protection
                //Halcon support maximum 32K*32K pixel, exceeded will cause exception
                if (preHeight * fZoomFactor > 32000 || preWidth * fZoomFactor > 32000)
                {//Set back to normal, avoid stuck in minimum size
                    Trace.WriteLine("ZoomImageViewPort: Limit Reached.");
                    var displayPort = new csViewPortBoundary(hRow1.D * 0.7, hColumn1.D * 0.7, hRow2.D * 0.7, hColumn2.D * 0.7);
                    SetViewPort(displayPort);
                }
                else
                {//Directly set 
                    var displayPort = new csViewPortBoundary(newRow1, newColumn1, newRow2, newColumn2);
                    SetViewPort(displayPort);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"ZoomImageViewPort.Exception:\r\n{ex.GetMessageDetail()}");
            }
        }



        private void SetViewPort(csViewPortBoundary displayPort)
        {
            HOperatorSet.SetPart(hv_WindowHandle, displayPort.Row1, displayPort.Col1, displayPort.Row2, displayPort.Col2);
            DisplayPort = displayPort;
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.SetViewPort: [{displayPort.GetDisplay()}]");
        }


        public void DisplayView()
        {
            watchView.Restart();
            try
            {
                //Check clear screen request
                if (View.ViewType == _viewType.ClearScreen)
                {
                    HOperatorSet.ClearWindow(hv_WindowHandle);
                    return;
                }

                lock (View.ViewImageLock)
                {
                    DisplayBaseImage(View.ViewImage);
                }


                DisplayGenericObjects();
                DisplayWindowInfo();

         
                //Finish up, show changes
                HOperatorSet.SetSystem("flush_graphic", "true");
            }

            catch (Exception ex)
            {
                ex.TraceException("csHalconWindow.DisplayView");
            }

            watchView.Stop();
            AddDisplayRecord();
            //Trace.WriteLine("View Update:" + watchView.ElapsedMilliseconds);
        }


        private void DisplayWindowInfo()
        {
            try
            {
                if (ControlInvalid)
                {
                    Trace.WriteLine("csHalconWindow.DisplayWindowInfo: Window disposed");
                    return;
                }

                //Display window handle
                if (csPublic.IsDebug)
                {
                    string sHandle = hv_WindowHandle.H.ToString();
                    HOperatorSet.GetWindowExtents(hv_WindowHandle, out HTuple winRow, out HTuple winCol, out HTuple winWidth, out HTuple winHeight);
                    HOperatorSet.GetPart(hv_WindowHandle, out HTuple partRow1, out HTuple partCol1, out HTuple partRow2, out HTuple partCol2);
                    //Must set font before show text to make sure size won't change
                    csHalconHelper.set_display_font(hv_WindowHandle, 14, "mono", "true", "false");
                    HOperatorSet.DispText(hv_WindowHandle, sHandle, "window", 20, winWidth - 150, csHalconColorHelper.Blue, null, null);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DisplayWindowInfo:\r\n{ex.GetMessageDetail()}");

            }
        }

        private void DisplayGenericObjects()
        {
            try
            {
                HOperatorSet.SetSystem("flush_graphic", "false");//Minimum screen blink
                int iWinTextRow = 0;//Record number of window text alread displayed
                HOperatorSet.SetLineWidth(hv_WindowHandle, 2);
                //Always show images first
                View.SortDisplayObjects();

                lock (View.lockDisplayItems)
                {
                    foreach (var item in View.DisplayItems)
                    {


                        //Check tool selection
                        if (string.IsNullOrEmpty(Selection.FocusedToolID))
                        {//When no tool is selected, show all tool in normal color
                            item.IsFocused = true;
                        }
                        else
                        {//When there is a selected tool, only show the selected tool in original color
                            item.IsFocused = Selection.FocusedToolID == item.ToolID;
                        }
                        int iLineWidth = item.IsFocused ? 3 : 2;
                        HOperatorSet.SetLineWidth(hv_WindowHandle, iLineWidth);


                        switch (item)
                        {
                            case csDisplayHObject dispObjectItem:
                                DisplayHobjectAction(dispObjectItem);
                                break;

                            case csDisplayMark markItem:
                                {
                                    if (!markItem.MarkPoint.IsValid()) continue;
                                    string sColor = item.IsFocused ? csHalconColorHelper.Green : csHalconColorHelper.GreenTrans_80;
                                    HOperatorSet.SetColor(hv_WindowHandle, sColor);
                                    HOperatorSet.DispCross(hv_WindowHandle, markItem.MarkPoint.Row, markItem.MarkPoint.Column, 30, csHalconHelper.HalconDegree45);
                                    break;
                                }

                            case csDisplayWindowText textItem:
                                {
                                    DisplayWindowTextAction(textItem, iWinTextRow);
                                    iWinTextRow += 1;
                                    break;
                                }

                            case csDisplayImageText imageTextItem:
                                DisplayImageText(imageTextItem);
                                break;

                            case csDisplayRect1 rect1Item:
                                {
                                    string sColor = item.IsFocused ? csHalconColorHelper.Green : csHalconColorHelper.GreenTrans_80;
                                    HOperatorSet.SetColor(hv_WindowHandle, sColor);
                                    rect1Item.Rect1.Display(hv_WindowHandle);
                                    break;
                                }
                        }

                    }

                    //Resume settings
                    HOperatorSet.SetLineWidth(hv_WindowHandle, 2);
                    HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine($"csHalconWindow.DisplayGenericObjects.Exception\r\n {e.GetMessageDetail()}");
            }
        }

        private void DisplayImageText(csDisplayImageText item)
        {
            if (item == null || string.IsNullOrEmpty(item.Text)) return;

            try
            {
                //Display image text: Only when the image source is valid
                if (!View.IsViewImageValid) return;

                //Image text size changes when zoom, must re-match
                string sColor = ViewSettings.ImageTextColor.ToHalconColorParameter();
                HOperatorSet.GetPart(hv_WindowHandle, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);

                //Get the image text size
                int iFontSize = ViewSettings.ImageTextSize;
                if (iFontSize < 3 || iFontSize > 100) iFontSize = 3;
                csHalconHelper.set_display_font(hv_WindowHandle, iFontSize, "mono", "false", "false");
                //show the text
                if (item.TextType == _imageTextType.Default)
                {
                    HOperatorSet.DispText(hv_WindowHandle, item.Text, "image", item.Row, item.Column, sColor, "box", "false");
                }
                else if (item.TextType == _imageTextType.TextBox_GreenText ||
                         item.TextType == _imageTextType.TextBox_RedText)
                {//Calculate proper text position
                    //Get font size
                    //int iLength = item.Text.Length;
                    //double dRow = item.Row.D -  (double)iFontSize / 2;
                    //double dTextWidthRatio = 1.0;
                    //double dColumn = item.Column.D - iFontSize * dTextWidthRatio;
                    HOperatorSet.DispText(hv_WindowHandle, item.Text, "image", item.Row, item.Column, sColor, null, null);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} DisplayImageText: Exception.\r\n{e.GetMessageDetail()}");
            }


        }

        private void DisplayWindowTextAction(csDisplayWindowText item, int iWinTextRow)
        {
            if (item == null) return;
            //Show maximum 10 lines
            if (iWinTextRow > 10) return;
            int iTextSize = ViewSettings.WindowTextSize;
            if (iTextSize < 2 || iTextSize > 100) iTextSize = 14;
            csHalconHelper.set_display_font(hv_WindowHandle, iTextSize, "mono", "true", "false");
            string sMessage = item.Text;
            string sColor = item.HalconColor;
            sMessage = sMessage.Length > 100 ? sMessage.Substring(0, 100) + "..." : sMessage;

            //Start position
            int iRow = 20 + iWinTextRow * (int)(iTextSize * 1.5);
            int iColumn = 20;
            HOperatorSet.DispText(hv_WindowHandle, sMessage, "window", iRow, iColumn, sColor, null, null);
        }

        private void DisplayHobjectAction(csDisplayHObject dispObject)
        {
            try
            {
                //Make sure display item is valid
                if (dispObject == null ||
                    dispObject.ViewItem == null ||
                    !dispObject.ViewItem.IsInitialized())
                {
                    $"DisplayHobjectAction.InvalidObject:[Type:{dispObject.Type}]".TraceRecord();
                    return;
                }


                string sColor = string.Empty;
                int iCount = dispObject.ViewItem.CountObj();
                var ColorsSolid = csHalconColorHelper.GetMultipleColorParameters(ViewSettings.SeparationColor, 1).ToArray();
                var ColorsTrans50 = csHalconColorHelper.GetMultipleColorParameters(ViewSettings.SeparationColor, 0.5).ToArray();
                var ColorsTrans25 = csHalconColorHelper.GetMultipleColorParameters(ViewSettings.SeparationColor, 0.25).ToArray();

                switch (dispObject.Type)
                {
                    case _DisplayObjectType.General:
                        sColor = dispObject.IsFocused ? csHalconColorHelper.Green : csHalconColorHelper.GreenTrans_80;
                        HOperatorSet.SetColor(hv_WindowHandle, sColor);
                        HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                        break;
                    case _DisplayObjectType.Image:
                        break;
                    case _DisplayObjectType.RegionBorder:
                    case _DisplayObjectType.Contour:
                    case _DisplayObjectType.RegionSearchBorder:
                        {
                            HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                            if (iCount == 1 ||
                                (iCount > 1 && !ViewSettings.SeparationColorEnable))
                            {//Display region in green color
                                sColor = dispObject.IsFocused ? csHalconColorHelper.Green : csHalconColorHelper.GreenTrans_80;
                                HOperatorSet.SetColor(hv_WindowHandle, sColor);
                            }
                            else
                            {
                                var colors = dispObject.IsFocused ? ColorsSolid : ColorsTrans50;
                                HOperatorSet.SetColor(hv_WindowHandle, colors);
                            }

                            //Add arrow
                            if (dispObject.Type == _DisplayObjectType.RegionSearchBorder)
                            {//Only process with high rect

                            }
                        }

                        break;
                    case _DisplayObjectType.RegionTrans:
                        HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                        if (iCount == 1 ||
                            (iCount > 1 && !ViewSettings.SeparationColorEnable))
                        {
                            sColor = dispObject.IsFocused ? csHalconColorHelper.RedTrans_80 : csHalconColorHelper.RedTrans_40;
                            HOperatorSet.SetColor(hv_WindowHandle, sColor);
                        }
                        else
                        {
                            var colors = dispObject.IsFocused ? ColorsTrans50 : ColorsTrans25;
                            var colorValues = new HTuple(colors);
                            HOperatorSet.SetColor(hv_WindowHandle, colorValues);
                        }
                        break;
                    case _DisplayObjectType.RegionSolid:
                        HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                        if (iCount == 1 ||
                            (iCount > 1 && !ViewSettings.SeparationColorEnable))
                        {
                            sColor = dispObject.IsFocused ? csHalconColorHelper.Red : csHalconColorHelper.RedTrans_80;
                            HOperatorSet.SetColor(hv_WindowHandle, sColor);
                        }
                        else
                        {
                            var colors = dispObject.IsFocused ? ColorsSolid : ColorsTrans50;
                            HOperatorSet.SetColor(hv_WindowHandle, colors);
                        }
                        break;

                    default:
                        break;
                }

                //Display the item 
                var itemType = dispObject.ViewItem.GetHalconType();//Debug view
                var itemData = dispObject.ViewItem;//Debug view
                HOperatorSet.DispObj(dispObject.ViewItem, hv_WindowHandle);
                //Resume to default after display
                HOperatorSet.SetDraw(hv_WindowHandle, "margin");
            }
            catch (Exception e)
            {
                Trace.WriteLine($"csHalconWindow.DisplayHobjectAction.Exception:\r\n" + e.GetMessageDetail());
            }

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
                Trace.WriteLine("csHalconWindow.SaveImage:\r\n" + e.Message);
                return false;
            }

            //Pass all steps
            return true;
        }

        public (csDisplayHObject displayHObject, int SubItemOrder) GetMousePointObject()
        {
            if (MouseDownPosition == null) return (null, -1);
            var watch = Stopwatch.StartNew();
            "HalconWindow.GetMousePointObject.Enter".TraceRecord();
            csDisplayHObject currentObject = null;

            try
            {
                lock (View.lockDisplayItems)
                {
                    //Record a reference to avoid value change
                    var mousePosition = MouseDownPosition;

                    //Use none-precised rect1 to get a quick list
                    var possibleItems = GetQuickCheckPossibleSelections(mousePosition);
                    $"HalconWindow.GetMousePointObject.PossibleItemsReady:{watch.ElapsedMilliseconds}ms".TraceRecord();

                    PrepareDispObjectInteractionRegions();

                    //Check first filter result
                    if (possibleItems.Count == 0) return (null, -1);
                    if (possibleItems.Count == 1) return possibleItems[0];

                    //IF region A contains in region B, Keep A
                    RemoveParentContainerV2(ref possibleItems);

                    //Final selection if overlapped
                    //When multiple items close to the mouse position, select the closest item
                    return GetClosestDispItem(possibleItems, MouseDownPosition);

                }
            }
            catch (Exception e)
            {
                string sObjectInfo = "Null";
                if (currentObject != null)
                {
                    int iCount = currentObject.ViewItem.GetItemCount();
                    var type = currentObject.ViewItem.GetHalconType();
                    sObjectInfo = $"Count:{iCount}, Type:{type}";
                }

      
                e.TraceException($"GetMousePointObject:{sObjectInfo}");
            }
            finally
            {
                watch.Stop();
                $"HalconWindow.GetMousePointObject.Complete:{watch.ElapsedMilliseconds}ms".TraceRecord();
            }

            //No matches
            return (null, -1);
        }

        /// <summary>
        /// Including the sub-items
        /// </summary>
        /// <returns></returns>
        private List<(csDisplayHObject displayHObject, int SubItemOrder)> GetQuickCheckPossibleSelections(HalconPoint mousePosition)
        {
            List<(csDisplayHObject displayHObject, int SubItemOrder)> possibleItems = new List<(csDisplayHObject displayHObject, int SubItemOrder)>();

            int iItemCount = 0;//Avoid CPU overload
            csDisplayHObject currentObject = null;
            int iLimit = 1000;

            foreach (var displayItem in View.DisplayItems)
            {
                iItemCount += 1;
                if (iItemCount > iLimit)
                {//Maximum item count reached
                    $"Maximum item count reached({iItemCount}).".TraceRecord();
                    break;
                }

                currentObject = displayItem as csDisplayHObject;
                if (currentObject == null) continue;

                var objectType = currentObject.ViewItem.GetHalconType();
                int iCount = currentObject.ViewItem.CountObj();
                if (iCount < 1) continue;

                if (objectType == _hObjectType.Region)
                {
                    for (int i = 1; i <= currentObject.ViewItem.CountObj(); i++)
                    {
                        if (i > iLimit)
                        {//Maximum item count reached
                            $"Maximum item count reached({iItemCount}).".TraceRecord();
                            break;
                        }
                        HObject selection = currentObject.ViewItem.SelectObj(i);
                        HOperatorSet.SmallestRectangle1(selection, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
                        if (mousePosition.WidthInRect1(row1, column1, row2, column2))
                        {
                            possibleItems.Add((currentObject, i));
                        }
                    }
                }
                else if (objectType == _hObjectType.Contour)
                {
                    for (int i = 1; i <= currentObject.ViewItem.CountObj(); i++)
                    {
                        if (i > iLimit)
                        {//Maximum item count reached
                            $"Maximum item count reached({iItemCount}).".TraceRecord();
                            break;
                        }

                        HObject selection = currentObject.ViewItem.SelectObj(i);
                        HOperatorSet.SmallestRectangle1Xld(selection, out HTuple row1, out HTuple column1, out HTuple row2, out HTuple column2);
                        if (mousePosition.WidthInRect1(row1, column1, row2, column2))
                        {
                            possibleItems.Add((currentObject, i));
                        }
                    }
                }

            }


            return possibleItems;
        }




        private void PrepareDispObjectInteractionRegions()
        {
            try
            {
                foreach (var itemSelection in View.DisplayItems)
                {
                    if (itemSelection is csDisplayHObject displayItem)
                    {
                        displayItem.ClearInteractionRegions();
                        displayItem.PrepareInteractionRegions();
                    }

                }
            }
            catch (Exception e)
            {
                e.TraceException("PrepareInteractionRegion");
            }
        }

        /// <summary>
        /// Remove a region if it's parent of another region
        /// </summary>
        /// <param name="possibleItems"></param>
        private void RemoveParentContainerV2(ref List<(csDisplayHObject displayHObject, int SubItemOrder)> possibleItems)
        {

            try
            {
            RemoveStart:
                if (possibleItems.Count <= 1) return;
                foreach (var currentItem in possibleItems)
                {
                    //Only process items with interaction region
                    var currentInteractionRegion = currentItem.displayHObject.GetInteractionRegion(currentItem.SubItemOrder);
                    if (currentInteractionRegion == null)
                    {
                        //Keep at least one item
                        if (possibleItems.Count == 1) return;

                        //Remove item
                        possibleItems.Remove(currentItem);
                        goto RemoveStart;
                    }

                    foreach (var testItem in possibleItems)
                    {
                        //Ignore same item
                        if (currentItem == testItem) continue;

                        var testInteractionRegion = testItem.displayHObject.GetInteractionRegion(testItem.SubItemOrder);
                        //Ignore on sub item level, item will be removed on parent level
                        if (testInteractionRegion == null) continue;

                        //Check container relation
                        HOperatorSet.TestSubsetRegion(currentInteractionRegion, testInteractionRegion, out HTuple ht_IsSubset);
                        if (ht_IsSubset.I != 1) continue;

                        //Show the removed item
                        HOperatorSet.AreaCenter(testInteractionRegion, out HTuple areaParent, out HTuple rowParent, out HTuple colParent);
                        HOperatorSet.AreaCenter(currentInteractionRegion, out HTuple areaSub, out HTuple rowSub, out HTuple colSub);

                        Trace.WriteLine($"Remove Parent Region: " +
                                        $"(Parent: R{rowParent.D.ToString("f1")},C{colParent.D.ToString("f1")},S{areaParent.L}), " +
                                        $"(Subitem: R{rowSub.D.ToString("f1")},C{colSub.D.ToString("f1")},S{areaSub.L})");

                        possibleItems.Remove(testItem);
                        goto RemoveStart;
                    }
                }
            }
            catch (Exception e)
            {
                e.TraceException("HalconWinow.RemoveParentRegion");
            }
        }


        /// <summary>
        /// Use precise region for calculation [TimeConsuming]
        /// This method needs to be optimized
        /// No time, leave to future
        /// </summary>
        /// <param name="possibleItems"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        private (csDisplayHObject displayHObject, int SubItemOrder) GetClosestDispItem(List<(csDisplayHObject displayHObject, int SubItemOrder)> possibleItems, HalconPoint position)
        {
            try
            {
                if (possibleItems == null) return (null, -1);
                if (possibleItems.Count == 1) return possibleItems[0];

                var distanceResults = possibleItems.Select((item, itemIndex) =>
                {
                    var interactionRegion = item.displayHObject.GetInteractionRegion(item.SubItemOrder);
                    HOperatorSet.AreaCenter(interactionRegion, out HTuple area, out HTuple row, out HTuple col);
                    //HOperatorSet.DistancePr(interactionRegion, (double)position.Row, (double)position.Column, out HTuple distanceMin, out HTuple distanceMax);
                    //var distance = distanceMin.TupleMax().D;
                    //return (distance, itemIndex);
                    HOperatorSet.DistancePp(row, col, (double)position.Row, (double)position.Column, out HTuple distance);
                    return (distance.D, itemIndex);

                }).OrderBy(a => a.D).ToList();

                //Get close distance
                var closestItem = distanceResults.First();
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Region Selection: " +
                                $"(Mouse: R{position.Row.ToString("f0")},C{position.Column.ToString("f0")}), " +
                                $"(Distance: {closestItem.D})");
                return possibleItems[closestItem.itemIndex];
            }
            catch (Exception e)
            {
                e.TraceException("GetClosestRegion");
                return (null, -1);
            }

        }
    }
}

