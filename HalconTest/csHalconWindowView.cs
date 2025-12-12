using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using _CommonCode_Framework;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraBars.Docking2010.Views;
using HalconDotNet;
using Newtonsoft.Json;


namespace HalconTest
{
    [Serializable]
    public class HalconView
    {
        public _viewType ViewType;

        public DateTime CreateTime = csDateTimeHelper.CurrentTime;

        public HObject ViewImage;
        public object ViewImageLock = new object();
        public bool IsViewImageValid => CheckViewImageValid();

        /// <summary>
        /// Halcon objects for display
        /// </summary>
        public List<csDisplayItemBase> DisplayItems { get; set; }
        public object lockDisplayItems = new object();

        public HalconView()
        {
            InitObjects();
        }

        public HalconView(HObject viewImage, _setHObjectMode mode = _setHObjectMode.DeepCopy)
        {
            InitObjects();
            SetViewImage(viewImage, mode);
        }

        public override string ToString()
        {
            int iDispObject = 0;
            int iDispOBject_Img = 0;
            int iDispObject_Reg = 0;
            int iDispObject_Cont = 0;
            int iImageText = 0;
            int iWinText = 0;

            lock (lockDisplayItems)
            {


                foreach (var item in DisplayItems)
                {
                    switch (item)
                    {
                        case csDisplayHObject displayHObject:
                            iDispObject += 1;
                            switch (displayHObject.Type)
                            {
                                case _DisplayObjectType.General:
                                    break;
                                case _DisplayObjectType.Image:
                                    iDispOBject_Img += 1;
                                    break;
                                case _DisplayObjectType.Contour:
                                    iDispObject_Cont += 1;
                                    break;
                                case _DisplayObjectType.RegionTrans:
                                case _DisplayObjectType.RegionSolid:
                                case _DisplayObjectType.RegionBorder:
                                case _DisplayObjectType.RegionSearchBorder:
                                    iDispObject_Reg += 1;
                                    break;
                            }
                            break;
                        case csDisplayWindowText _:
                            iWinText += 1;
                            break;
                        case csDisplayImageText _:
                            iImageText += 1;
                            break;
                    }
                }
            }

            //Debug display
            string sMessage = $"[ItemCount:{DisplayItems.Count}], [HObject:{iDispObject} -> Img:{iDispOBject_Img}, Reg:{iDispObject_Reg}, Con:{iDispObject_Cont}], [WinText:{iWinText}], [ImgText:{iImageText}]";
            return sMessage;
        }

        private void InitObjects()
        {
            ViewType = _viewType.General;
            DisplayItems = new List<csDisplayItemBase>();
        }

        public List<csDisplayWindowText> GetWindowsTexts()
        {
            List<csDisplayWindowText> windowTexts = new List<csDisplayWindowText>();
            lock (lockDisplayItems)
            {
                foreach (var dispItem in DisplayItems)
                {
                    if (dispItem is csDisplayWindowText windowText)
                    {
                        windowTexts.Add(windowText);
                    }
                }
            }

            return windowTexts;
        }

        public HObject GetLastDisplayImageItem()
        {
            lock (lockDisplayItems)
            {
                //Get from last to front
                for (int i = DisplayItems.Count - 1; i >= 0; i--)
                {
                    var dispItem = DisplayItems[i];
                    if (dispItem is csDisplayHObject dispObject)
                    {
                        if (dispObject.Type == _DisplayObjectType.Image)
                        {
                            return dispObject.ViewItem;
                        }
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Making sure image always shown before other objects
        /// </summary>
        public void SortDisplayObjects()
        {
            lock (lockDisplayItems)
            {
                List<csDisplayItemBase> imageItems = new List<csDisplayItemBase>();
                List<csDisplayItemBase> otherItems = new List<csDisplayItemBase>();

                foreach (var displayItem in DisplayItems)
                {
                    var dispObject = displayItem as csDisplayHObject;
                    if (dispObject == null || dispObject.Type != _DisplayObjectType.Image)
                    {
                        otherItems.Add(displayItem);
                    }
                    else
                    {
                        imageItems.Add(displayItem);
                    }
                }

                DisplayItems.Clear();
                DisplayItems.AddRange(imageItems);
                DisplayItems.AddRange(otherItems);
            }
        }



        public void AddImageText(string sText, HTuple hRow, HTuple hColumn, string sToolID = null, _imageTextType textType = _imageTextType.Default)
        {
            if (string.IsNullOrWhiteSpace(sText)) return;

            var newText = new csDisplayImageText(sText, hRow, hColumn, sToolID, textType);

            lock (lockDisplayItems)
            {
                DisplayItems.Add(newText);
            }
        }



        public void AddMappedImageText(string sText, HTuple hRow, HTuple hColumn, HTuple mapMatrix)
        {
            try
            {

                HOperatorSet.AffineTransPoint2d(mapMatrix, hRow, hColumn, out HTuple newRow, out HTuple newColumn);
                AddImageText(sText, newRow, newColumn);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("AddMappedImageText.Exception:\r\n" + ex.Message);
            }
        }


        public void SetViewImage(HObject Image, _setHObjectMode mode)
        {
            "HalconView.SetViewImage.Enter".TraceRecord();
            csHalconHelper.SetHalconImage(ref ViewImage, Image, ViewImageLock, mode);
        }


        public HObject GetViewImage()
        {
            lock (ViewImageLock)
            {
                try
                {
                    //Avoid source image been changed
                    if (ViewImage == null || !ViewImage.IsInitialized()) return null;
                    return ViewImage.Clone();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("GetViewImage:\r\n" + ex.Message);
                    return null;
                }
            }
        }

        public void ClearViewImage()
        {
            lock (ViewImageLock)
            {
                if (ViewImage != null)
                {
                    ViewImage?.Dispose();
                    ViewImage = null;
                }
            }
        }


        public bool CheckViewImageValid()
        {
            lock (ViewImageLock)
            { return ViewImage != null && ViewImage.IsInitialized(); }
        }

        public void SetDisplayObject(HObject ho_Display, string sToolID, _DisplayObjectType displayType = _DisplayObjectType.General)
        {

            ClearDisplayItems();

            lock (lockDisplayItems)
            {
                if (ho_Display == null) return;
                var displayObject = new csDisplayHObject()
                {
                    ViewItem = ho_Display.Clone(),
                    Type = displayType,
                    ToolID = sToolID
                };

                DisplayItems.Add(displayObject);
            }
        }

        public void AddDisplayRect1(Rectangle1Data displayItem, string sToolID)
        {

            var rect1 = new Rectangle1Data();
            rect1.Load(displayItem.Row1, displayItem.Column1, displayItem.Row2, displayItem.Column2);

            var dispItem = new csDisplayRect1()
            {
                Rect1 = rect1,
                ToolID = sToolID
            };


            lock (lockDisplayItems)
            {
                DisplayItems.Add(dispItem);
            }
        }

        public void AddDisplayHalconObject(HObject ho_Display, string sToolID, _DisplayObjectType displayType = _DisplayObjectType.General, int iItemOrder = 0)
        {

            lock (lockDisplayItems)
            {
                if (ho_Display == null) return;
                var displayObject = new csDisplayHObject()
                {
                    ViewItem = ho_Display.Clone(),
                    Type = displayType,
                    ToolID = sToolID,
                    ItemOrder = iItemOrder
                };

                DisplayItems.Add(displayObject);
            }
        }

        public void AddMappedDisplayRegion(HObject ho_Display, HTuple mapMatrix, string sToolID, _DisplayObjectType displayType = _DisplayObjectType.General)
        {
            try
            {
                if (ho_Display == null) return;
                HOperatorSet.AffineTransRegion(ho_Display, out HObject ho_Affine, mapMatrix, "nearest_neighbor");
                AddDisplayHalconObject(ho_Affine, sToolID, displayType);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("AddMappedDisplayObject.Exception:" + ex.Message);
                return;
            }
        }

        public void ClearDisplayItems()
        {

            lock (lockDisplayItems)
            {
                //Init all
                //Manual dispose
                foreach (var item in DisplayItems)
                {
                    if (item is csDisplayHObject displayHObject)
                    {
                        displayHObject.Dispose();
                    }
                }
                DisplayItems.Clear();
            }

            "HalconView.ClearDisplayItems.Complete".TraceRecord();
        }


        /// <summary>
        /// Int,float,double,htuple
        /// </summary>
        /// <param name="oRow"></param>
        /// <param name="oColumn"></param>
        public void AddMark(object oRow, object oColumn, string sToolID = null)
        {
            //Htuple might contains multiple marks
            if (oRow is HTuple && oColumn is HTuple)
            {
                var hRow = (HTuple)oRow;
                var hCol = (HTuple)oColumn;

                if (hRow.Type == HTupleType.DOUBLE)
                {
                    if (hRow.DArr.Length != hCol.DArr.Length) return;

                    lock (lockDisplayItems)
                    {
                        for (int i = 0; i < hRow.DArr.Length; i++)
                        {
                            var pData = new HalconPoint(hRow.DArr[i], hCol.DArr[i]);
                            DisplayItems.Add(new csDisplayMark(pData, sToolID));
                        }
                    }
                }
                else if (hRow.Type == HTupleType.INTEGER)
                {
                    if (hRow.IArr.Length != hCol.IArr.Length) return;

                    lock (lockDisplayItems)
                    {
                        for (int i = 0; i < hRow.IArr.Length; i++)
                        {
                            var pData = new HalconPoint(hRow.IArr[i], hCol.IArr[i]);
                            DisplayItems.Add(new csDisplayMark(pData, sToolID));
                        }
                    }
                }
            }
            else
            {
                var newMark = new csDisplayMark(oRow, oColumn);

                lock (lockDisplayItems)
                {
                    DisplayItems.Add(newMark);
                }
            }
        }


 

        public void AddWindowText(string sText, string sHalconColor = csHalconColorHelper.Red, string sToolID = null)
        {
            var winText = new csDisplayWindowText(sText, sHalconColor, sToolID);
            lock (lockDisplayItems)
            {
                DisplayItems.Add(winText);
            }
        }




        public void ClearAll()
        {
            "HalconView.ClearAll.Enter".TraceRecord();
            ClearViewImage();
            ClearDisplayItems();
        }


        public HalconView CloneView()
        {
            var newView = new HalconView();

            lock (ViewImageLock)
            {
                if (ViewImage != null)
                    newView.ViewImage = ViewImage.Clone();
            }

            newView.DisplayItems = CloneDisplayItems();

            return newView;

        }

        public List<csDisplayItemBase> CloneDisplayItems()
        {
            List<csDisplayItemBase> newItems = new List<csDisplayItemBase>();

            lock (lockDisplayItems)
            {
                foreach (var item in DisplayItems)
                {
                    if (item is csDisplayHObject displayHObject)
                    {
                        displayHObject.Clone();
                        newItems.Add(displayHObject);
                    }
                    else
                    {//No dispose method, directly copy
                        newItems.Add(item);
                    }
                }
            }

            return newItems;
        }


        /// <summary>
        /// The image is only used for saving purpose
        /// The output image is a rgb image
        /// </summary>
        /// <returns></returns>
        public HObject GenerateViewImage(out string sMessage)
        {
            //Create an empty
            HObject displayImage;
            sMessage = string.Empty;

            try
            {
                //Check clear screen request
                if (this.ViewType == _viewType.ClearScreen) return null;

                //Copy the base image
                lock (this.ViewImageLock)
                {
                    if (!this.ViewImage.IsValid())
                    {
                        sMessage = "The view image is empty.";
                        return null;
                    }

                    displayImage = this.ViewImage.Clone();
                }

                //Make sure the image is a rgb image
                if (displayImage.ChannelCount() == 1)
                {
                    var imageRGB = displayImage.GrayImageToRGBImage();
                    displayImage = imageRGB;
                }

                //Paint generic objects
                PaintGenericObjects(displayImage);
                //Paint window info
                return displayImage;
            }

            catch (Exception ex)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.GenerateViewImage:\r\n{ex.ToString()}");

                return null;
            }
        }


        /// <summary>
        /// Paint object on the image
        /// </summary>
        /// <param name="displayImage"></param>
        private void PaintGenericObjects(HObject displayImage)
        {
            try
            {
                SortDisplayObjects();

                lock (this.lockDisplayItems)
                {
                    foreach (var item in this.DisplayItems)
                    {
                        if (item is csDisplayHObject dispObjectItem)
                        {
                            PaintGenericHobjectAction(displayImage, dispObjectItem);
                        }
                        else if (item is csDisplayMark markItem)
                        {
                            if (!markItem.MarkPoint.IsValid()) continue;
                            HTuple hv_Green = csHalconColorHelper.GetSingleColorGray(_HalconColor.Green);
                            HOperatorSet.GenCrossContourXld(out HObject cross, markItem.MarkPoint.Row, markItem.MarkPoint.Column, 30, csHalconHelper.HalconDegree45);
                            HOperatorSet.GenRegionContourXld(cross, out HObject regionContour, "margin");
                            HOperatorSet.OverpaintRegion(displayImage, regionContour, hv_Green, "fill");
                            regionContour.Dispose();
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} csHalconWindow.PaintGenericObjects.Exception\r\n {e.GetMessageDetail()}");
            }
        }



        /// <summary>
        /// Directly paint on the origin image
        /// fast process speed
        /// </summary>
        /// <param name="displayImage"></param>
        /// <param name="dispObject"></param>
        private void PaintGenericHobjectAction(HObject displayImage, csDisplayHObject dispObject)
        {
            try
            {
                //Make sure display item is valid
                if (dispObject == null ||
                    dispObject.ViewItem == null ||
                    !dispObject.ViewItem.IsInitialized())
                {
                    return;
                }

                HTuple hv_Green = csHalconColorHelper.GetSingleColorGray(_HalconColor.Green);


                switch (dispObject.ViewItem.GetHalconType())
                {
                    case _hObjectType.Image:
                        HOperatorSet.OverpaintGray(dispObject.ViewItem, displayImage);
                        break;
                    case _hObjectType.Region:
                        HOperatorSet.OverpaintRegion(displayImage, dispObject.ViewItem, hv_Green, "margin");
                        break;
                    case _hObjectType.Contour:
                        HOperatorSet.GenRegionContourXld(dispObject.ViewItem, out HObject regionContour, "margin");
                        HOperatorSet.OverpaintRegion(displayImage, regionContour, hv_Green, "fill");
                        regionContour.Dispose();
                        break;
                    case _hObjectType.Undefined:
                        break;
                }


            }
            catch (Exception e)
            {
                Trace.WriteLine($"csHalconView.PaintGenericHobjectAction.Exception:\r\n" + e.GetMessageDetail());
            }

        }

    }


    public class HalconViewBuffer
    {
        /// <summary>
        /// Used by other thread to request view update, 
        /// No direct view update to avoid UI Jam
        /// If inspection exist, buffer saves
        /// No view changes after adding to buffer!
        /// </summary>
        public ConcurrentQueue<HalconView> Buffers { get; set; }
        public int BufferLimit = 5;
        public int BufferCount => Buffers.Count;


        /// <summary>
        /// memory control object: Clear when new object arrive
        /// </summary>

        public HalconView LastView;

        public HalconViewBuffer()
        {
            Buffers = new ConcurrentQueue<HalconView>();
        }

        public HalconView AddImageView(HObject ho_Image)
        {
            //Create new view
            HalconView view = new HalconView(ho_Image);

            AddView(view, "NewImage");
            return view;
        }

        public HalconView AddEmptyView()
        {
            HalconView view = new HalconView();
            view.ViewType = _viewType.ClearScreen;

            AddView(view, "ClearScreen");
            return view;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newView"></param>
        /// <param name="sViewSource">Debug usage</param>
        public void AddView(HalconView newView, string sViewSource)
        {

            string sView = newView.ToString(); //Debug usage
            $"[{sViewSource}].View.Adding:{sView}".TraceRecord();

            // UI interaction Display
            while (Buffers.Count > BufferLimit)
            {
                if (Buffers.TryDequeue(out HalconView bufferView))
                {
                    bufferView.ClearAll();
                    bufferView = null;
                }
            }

            //Let main thread to control refresh speed if called from another thread.
            Buffers.Enqueue(newView);
        }

        public HalconView GetNextView()
        {
            if (Buffers.Count == 0) return null;

            if (Buffers.TryDequeue(out HalconView view))
            {
                //Save the view for future
                if (LastView != null)
                {
                    LastView.ClearAll();
                    LastView = null;
                }
                LastView = view;
                return view;
            }

            return null;
        }

        public HalconView GetLastView()
        {
            if (LastView == null)
            {
                HalconView view = new HalconView();
                view.ViewType = _viewType.ClearScreen;
                return view;
            }

            return LastView;
        }

        public void ClearBuffer()
        {
            while (Buffers.Count > 0)
            {
                if (Buffers.TryDequeue(out HalconView view))
                {
                    view.ClearAll();
                }
            }
        }
    }

    public class csDisplayItemBase
    {

        /// <summary>
        /// Indicate item belong to which tool
        /// </summary>
        public string ToolID { get; set; }

        /// <summary>
        /// True: show original color
        /// False: show transparent color
        /// </summary>
        public bool IsFocused { get; set; }
    }




    public class csDisplayHObject : csDisplayItemBase
    {
        public HObject ViewItem { get; set; }

        public _DisplayObjectType Type { get; set; }
        /// <summary>
        /// Used to locate the search region type in a tool
        /// </summary>
        public int ItemOrder { get; set; }

        /// <summary>
        /// Used for verify user interaction domain
        /// </summary>
        [XmlIgnore, JsonIgnore]
        public List<HObject> InteractionRegions = new List<HObject>();

        public csDisplayHObject()
        {
            Type = _DisplayObjectType.General;
        }

        public HObject GetInteractionRegion(int itemOrder)
        {
            if (InteractionRegions.Count == 0) return null;
            if (itemOrder == 0) return InteractionRegions[0];
            if (itemOrder < 0 || itemOrder > InteractionRegions.Count) return null;
            return InteractionRegions[itemOrder - 1];
        }

        public void ClearInteractionRegions()
        {
            foreach (var item in InteractionRegions)
            {
                item?.Dispose();
            }

            InteractionRegions.Clear();
        }

        public csDisplayHObject Clone()
        {
            csDisplayHObject displayObject = new csDisplayHObject();
            displayObject.CopyInstanceValues(this);
            if (ViewItem != null && ViewItem.IsInitialized())
            {
                displayObject.ViewItem = this.ViewItem.Clone();
            }
            return displayObject;
        }


        /// <summary>
        /// New object from the view item
        /// Response is new object
        /// </summary>
        /// <returns></returns>
        public void PrepareInteractionRegions()
        {
            var objectType = ViewItem.GetHalconType();
            int iCount = ViewItem.GetItemCount();
            if (iCount < 0) return;

            if (objectType == _hObjectType.Region)
            {
                if (iCount == 1)
                {
                    InteractionRegions.Add(ViewItem.Clone());
                    return;
                }

                for (int i = 1; i <= iCount; i++)
                {
                    var subItem = ViewItem.SelectObj(i);
                    InteractionRegions.Add(subItem);
                }
            }
            else if (objectType == _hObjectType.Contour)
            {//Only select the first item
                HOperatorSet.GenRegionContourXld(ViewItem, out HObject regionContour, "margin");
                HOperatorSet.DilationRectangle1(regionContour, out HObject regionDilation, 10, 10);
                regionContour.Dispose();
                iCount = regionDilation.CountObj();
                for (int i = 1; i <= iCount; i++)
                {
                    var subItem = regionDilation.SelectObj(i);
                    InteractionRegions.Add(subItem);
                }
            }
        }

        public void Dispose()
        {
            ViewItem?.Dispose();
            ViewItem = null;
            ClearInteractionRegions();
        }
    }

    public class csDisplayMark : csDisplayItemBase
    {
        public HalconPoint MarkPoint { get; set; }

        public csDisplayMark()
        {

        }

        public csDisplayMark(HalconPoint point, string sToolID = null)
        {
            MarkPoint = point;
            ToolID = sToolID;
        }

        public csDisplayMark(object Row, object Column, string sToolID = null)
        {
            ToolID = sToolID;

            if ((Row is float && Column is float) || (Row is double && Column is double))
            {
                MarkPoint = new HalconPoint(Convert.ToDouble(Row), Convert.ToDouble(Column));
            }
            else if (Row is int && Column is int)
            {
                MarkPoint = new HalconPoint((int)Row, (int)Column);
            }
            else if (Row is HTuple && Column is HTuple)
            {
                var hRow = (HTuple)Row;
                var hCol = (HTuple)Column;

                if (hRow.Type == HTupleType.DOUBLE)
                {
                    if (hRow.DArr.Length < 1 || hRow.DArr.Length != hCol.DArr.Length) return;
                    //Only add one result
                    MarkPoint = new HalconPoint(hRow.DArr[0], hCol.DArr[0]);
                }
                else if (hRow.Type == HTupleType.INTEGER)
                {
                    if (hRow.IArr.Length < 1 || hRow.IArr.Length != hCol.IArr.Length) return;
                    //Only add one result
                    MarkPoint = new HalconPoint(hRow.DArr[0], hCol.DArr[0]);
                }
                else
                {
                    MarkPoint = new HalconPoint();
                }
            }
            else
            {
                MarkPoint = new HalconPoint();
            }

        }
    }

    public class csDisplayRect1 : csDisplayItemBase
    {
        public Rectangle1Data Rect1;

        public csDisplayRect1()
        {

        }
    }

    public class csDisplayRect2 : csDisplayItemBase
    {
        public Rectangle2Data Rect2;

        public csDisplayRect2(Rectangle2Data _rect2)
        {
            Rect2 = _rect2;
        }
    }

    /// <summary>
    /// Text in coordinates of the image
    /// </summary>
    public class csDisplayImageText : csDisplayItemBase
    {

        public string Text { get; set; }

        [XmlIgnore, JsonIgnore]
        public HTuple Row { get; set; }

        [XmlIgnore, JsonIgnore]
        public HTuple Column { get; set; }

        public _imageTextType TextType { get; set; }


        public csDisplayImageText()
        {
            Text = "";
            TextType = _imageTextType.Default;
        }

        public csDisplayImageText(string sText, HTuple row, HTuple col, string sToolID = null, _imageTextType textType = _imageTextType.Default)
        {
            Text = sText;
            Row = row;
            Column = col;
            this.ToolID = sToolID;
            TextType = textType;
        }

        public string GetTextColor_Halcon()
        {

            string sColor = IsFocused ? csHalconColorHelper.Green : csHalconColorHelper.GreenTrans_80;

            if (TextType == _imageTextType.TextBox_RedText)
            {
                sColor = IsFocused ? csHalconColorHelper.Red : csHalconColorHelper.RedTrans_80;
            }

            return sColor;

        }

    }

    public enum _viewType
    {
        /// <summary>
        /// Show all items
        /// </summary>
        General,
        //Init screen only
        ClearScreen,
    }

    public enum _DisplayObjectType
    {
        /// <summary>
        /// Show in green color if color required
        /// </summary>
        General,
        /// <summary>
        /// Image Items needs to be displayed before other others
        /// </summary>
        Image,
        /// <summary>
        /// Regular region show as border
        /// Show various color if color required
        /// </summary>
        RegionBorder,
        Contour,
        /// <summary>
        /// Regular filled region show in half trans color
        /// Show red and fill the display
        /// </summary>
        RegionTrans,
        /// <summary>
        /// Show in solid red color
        /// </summary>
        RegionSolid,
        /// <summary>
        /// Inspection Region of the tool
        /// </summary>
        RegionSearchBorder,
    }
}
