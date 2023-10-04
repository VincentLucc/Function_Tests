using DevExpress.Office.Internal;
using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Internal.PrintLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Test001
{

    /// <summary>
    /// Select only one pair of data one time
    /// Usage summary:
    /// 1. Call LoadFile method:            myControl.LoadFile(".\\demo.txt");
    /// 2. Set SelectedIndexes property:    myControl.SelectedIndexes = "0,5,10,20";
    /// </summary>
    public partial class ColumnSelectorControlV3 : XtraUserControl
    {
        #region ColumnSelectorControlSingle_Properties

        //private myRulerControl myRuler;
        private string[] mylines;

        /// <summary>
        /// List of selected indexes in sample data, to build "SelectedIndexes" property.
        /// this list can be empty
        /// </summary>
        public List<int> Selections = new List<int> { };


        const string strMarkerChar = "▼";

        /// <summary>
        /// Width of a character in pixels from the fixed size Font used for this control (Default: Consolas)
        /// </summary>
        internal int iCharWidth = 7;
        private float fCharWidth = 7f; // no use; just for debug

        private float m_FontSize = 12f;


        private int m_MaxColumns = 32;
        /// <summary>
        /// Max indexes. Each data column is 2 indexes.
        /// </summary>
        public int MaxAllowedColumns
        {
            get
            {
                return m_MaxColumns;
            }
            set
            {
                m_MaxColumns = value;
            }
        }



        /// <summary>
        /// Longest row in the sample file, which is used to set the size of the content viewer
        /// </summary>
        private int MaxLineLength = 1;

        public EventHandler SelectionReady;



        private int RulerHeight = 28;

        private int CharWidth = 9;

        /// <summary>
        /// The indent of the ruler and text
        /// </summary>
        private int StartIndent = 5;

        /// <summary>
        /// Start point of the sub divisions
        /// </summary>
        public List<int> DivisionSub = new List<int>();
        /// <summary>
        /// Main division show text
        /// </summary>
        public List<int> DivisionMain = new List<int>();

        /// <summary>
        /// Read editcontrol's horizontal scroll bar
        /// </summary>
        IOfficeScrollbar horizontalScrollBar;

        public ColumnSelectorControlV3()
        {
            InitializeComponent();
            base.Font = new Font("Consolas", m_FontSize, FontStyle.Regular);
            toolTip1.SetToolTip(ContentRichEditControl, "");

            //myRuler = new myRulerControl(this);
            //myRuler.IndexCollectionChanged += IndexCollectionChanged;
            InitTextEditControl();
            //RulerPanel.Controls.Add(myRuler);

            //ScrollControl.Scroll += ScrollControl_Scroll;


            MeasureFontSize();
        }

        private void ScrollControl_Scroll(object sender, XtraScrollEventArgs e)
        {
            Debug.WriteLine($"ScrollControl_Scroll:{e.NewValue}");
        }

        private void InitTextEditControl()
        {

            //Load fake data
            LoadString(csPublic.FakeText);

            //Setup Text
            Font = new Font("Consolas", m_FontSize, FontStyle.Regular);

            //Setup layout
            ContentRichEditControl.ActiveViewType = RichEditViewType.Simple;

            //Setup the view
            var simpleView = ContentRichEditControl.ActiveView as SimpleView;
            simpleView.WordWrap = false;
            simpleView.Padding = new Padding(0, RulerHeight, 0, 0);

            //GET HORIZENTAL SCROLL
            RichEditViewHorizontalScrollController horizontalScrollController = (RichEditViewHorizontalScrollController)ContentRichEditControl.ActiveView.GetType()
                                                   .InvokeMember("HorizontalScrollController", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance, null, ContentRichEditControl.ActiveView, null);
            horizontalScrollBar = horizontalScrollController.ScrollBar;
            horizontalScrollBar.Scroll += HorizontalScroll_Scroll;


            //Setup document
            ContentRichEditControl.DocumentLoaded += ContentRichEditControl_DocumentLoaded;

            //Disable right click menu
            ContentRichEditControl.Options.Behavior.ShowPopupMenu = DocumentCapability.Disabled;

            //Draw text selection rectangle and ruler
            ContentRichEditControl.CustomDrawActiveView += MyContentControl_CustomDrawActiveView;
            //Show notice
            ContentRichEditControl.MouseHover += ContentRichEditControl_MouseHover;
        }

        private void HorizontalScroll_Scroll(object sender, ScrollEventArgs e)
        {
            Debug.WriteLine("HorizontalScroll_Scroll");
        }

        private void ContentRichEditControl_MouseHover(object sender, EventArgs e)
        {
            //Check if selection ready
            var selection = GetSelection();
            string sMessage = "";
            if (selection != null)
            {//Trigger selection ready event
                sMessage = "Click mouse right button to cancel selection.";
            }
            else
            {
                sMessage = "Click ruler area to select a range.";
            }
            toolTip1.SetToolTip(ContentRichEditControl, sMessage);
        }




        private void ContentRichEditControl_DocumentLoaded(object sender, EventArgs e)
        {
            ContentRichEditControl.Document.DefaultCharacterProperties.FontName = "Consolas";
            ContentRichEditControl.Document.DefaultCharacterProperties.FontSize = m_FontSize;

            //Get actual char width
            if (ContentRichEditControl.Document.Length == 0)
            {
                CharWidth = 8; //Use default value
            }
            else
            {
                //Get actual char width
                var posStart = ContentRichEditControl.Document.CreatePosition(0);
                var boundryStart = ContentRichEditControl.GetLayoutPhysicalBoundsFromPosition(posStart);
                CharWidth = boundryStart.Width;
            }

            //Get all division points
            for (int i = 0; i < MaxLineLength; i++)
            {
                int iPoint = i * CharWidth + StartIndent;

                //Add sub division
                if (!DivisionSub.Contains(iPoint)) DivisionSub.Add(iPoint);

                //Add main division
                if (i % 10 == 0)
                {
                    if (!DivisionMain.Contains(iPoint))
                    {
                        DivisionMain.Add(iPoint);
                    }

                }
            }


        }





        /// <summary>
        /// Draw selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyContentControl_CustomDrawActiveView(object sender, RichEditViewCustomDrawEventArgs e)
        {

            //Always paint ruler
            PaintRuler(e);

            //Paint range
            int count = Selections.Count;
            if (count == 0 && count > 2) return;
            //Range selected
            if (count == 2)
            {
                int iStart = Selections.Min();
                int iEnd = Selections.Max();
                //Get actual draw position
                DrawSelection(e, iStart, iEnd);
            }
        }


        private void PaintRuler(RichEditViewCustomDrawEventArgs e)
        {
            if (!ContentRichEditControl.Visible) return;
            if (ContentRichEditControl.Width < 1 || ContentRichEditControl.Height < 1) return;

            //Only paint visible area
            int iStart = horizontalScrollBar.Value;
            int iWidth = this.Width;
             

            //Draw paint area
            var rect = new Rectangle(iStart, -RulerHeight, iWidth, RulerHeight);
            var color = Color.WhiteSmoke;//Set to transparent color
            e.Cache.FillRectangle(color, rect);

            //Draw two lines
            e.Cache.DrawLine(iStart, -RulerHeight, iStart + iWidth, -RulerHeight, Color.DarkGray, 2); //Draw top line
            e.Cache.DrawLine(iStart, -1, iStart + iWidth, -1, Color.DarkGray, 2); //Draw bottom line

            //Check all points
            for (int i = iStart; i < iStart + iWidth; i++)
            {
                int iLineIndex = 0;

                //Draw division lines
                if (DivisionSub.Contains(i))
                {
                    iLineIndex = DivisionSub.IndexOf(i);

                    if (!DivisionMain.Contains(i))
                    {
                        e.Cache.DrawLine(i, -2, i, -10, Color.Black, 1);
                    }
                }

                //Draw division text mark
                if (DivisionMain.Contains(i))
                {
                    //Draw higher line
                    e.Cache.DrawLine(i, -1, i, -12, Color.Black, 2);

                    //Draw text
                    var textPoint = new Point(i - 4, -30);
                    e.Cache.DrawString(iLineIndex.ToString(), this.Font, new SolidBrush(this.ForeColor), textPoint);

                }
            }



            //var boundryStart = ContentRichEditControl.GetLayoutPhysicalBoundsFromPosition(iStart);
            //var boundryEnd = ContentRichEditControl.GetLayoutPhysicalBoundsFromPosition(iStart+);
        }

        private void DrawSelection(RichEditViewCustomDrawEventArgs e, int iStart, int iEnd)
        {
            var posStart = ContentRichEditControl.Document.CreatePosition(iStart);
            var posEnd = ContentRichEditControl.Document.CreatePosition(iEnd + 1);
            var boundryStart = ContentRichEditControl.GetLayoutPhysicalBoundsFromPosition(posStart);
            var boundryEnd = ContentRichEditControl.GetLayoutPhysicalBoundsFromPosition(posEnd);
            int iXStart = boundryStart.X;
            int iYStart = boundryStart.Y;
            int iWidth = Math.Abs(boundryEnd.X - boundryStart.X);
            int iHeight = 1000;
            var rect = new Rectangle(iXStart, iYStart, iWidth, iHeight);
            var color = Color.FromArgb(32, Color.Red);//Set to transparent color
            e.Cache.FillRectangle(color, rect);
        }


        public bool IsSelectionValid()
        {
            //Check size
            if (Selections.Count != 2)
            {
                return false;
            }

            //Check start/end point
            if (Selections.Any(a => a < 0))
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Calculates the character size for current (fixed size) font of this control.
        /// </summary>
        private void MeasureFontSize()
        {
            using (Bitmap b1 = new Bitmap(100, 100))
            {
                using (Graphics g = Graphics.FromImage(b1))
                {
                    fCharWidth = g.MeasureString(strMarkerChar, base.Font, new Size(100, 100), StringFormat.GenericTypographic).Width;
                    iCharWidth = Convert.ToInt32(Math.Round(fCharWidth + .25f, 0));
                }
            }
        }



        private void IndexCollectionChanged(object sender, IndexCollectionChangeEventArgs e)
        {
            //Check if right mouse clicked
            if (e.Button == MouseButtons.Right)
            {
                Selections.Clear();
                UpdateView();
                return;
            }

            UpdateView(); //Update view before trigger operation

            //Check if selection ready
            var updateResult = GetSelection();
            if (updateResult != null)
            {//Trigger selection ready event
                if (SelectionReady != null)
                {
                    SelectionReady(this, e);
                }
            }
        }

        /// <summary>
        /// Refresh UI display
        /// </summary>
        private void UpdateView()
        {
            Selections.RemoveAll(i => i >= MaxLineLength); // safety;
            ContentRichEditControl.Invalidate();
            //myRuler.Refresh();
        }



        public void LoadJobInfoRows(csFileData sampleData)
        {
            //Init 
            mylines = new string[2];
            MaxLineLength = 0;
            int iLineCharLimit = 65535 / 9; //Ccontrol maximum width/char size

            //Job header
            string sJobHeader = sampleData.JobInfoHeader;
            if (sJobHeader.Length > MaxLineLength) MaxLineLength = sJobHeader.Length + 1;
            //Limit line length
            if (sJobHeader.Length > iLineCharLimit) sJobHeader = sJobHeader.Substring(0, iLineCharLimit - 3) + "...";
            mylines[0] = sJobHeader;

            //Job data
            string sJobData = sampleData.JobInfoData;
            if (sJobData.Length > MaxLineLength) MaxLineLength = sJobData.Length + 1;
            //Limit line length
            if (sJobData.Length > iLineCharLimit) sJobData = sJobData.Substring(0, iLineCharLimit - 3) + "...";
            mylines[1] = sJobData;

            //Update view
            Selections.RemoveAll(x => x >= MaxLineLength);
            ContentRichEditControl.Height = 1000;
            ContentRichEditControl.Invalidate();
            //myRuler.Refresh();
            LoadString($"{sJobHeader}\r\n{sJobData}");
        }


        public void LoadString(string sText)
        {
            if (string.IsNullOrWhiteSpace(sText)) return;

            var options = sText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            //Get longest line
            MaxLineLength = options.Max(a => a.Length);

            byte[] bData = Encoding.UTF8.GetBytes(sText);
            using (MemoryStream stream = new MemoryStream(bData))
            {
                ContentRichEditControl.LoadDocument(stream);
            }

        }


        public void LoadDataRows(csFileData sampleData)
        {
            //Initial varibales
            MaxLineLength = 1;
            int iRowCount = 20;
            mylines = new string[iRowCount];
            int[] maxTabAreas = new int[0];
            int counter = 0;
            int iLineCharLimit = 65535 / 9; //Control maximum width/char size

            StringBuilder sBuilder = new StringBuilder();

            //Add data header
            if (!string.IsNullOrWhiteSpace(sampleData.DataHeader))
            {
                string sHeader = sampleData.DataHeader;

                //Record max length to adjust control width
                if (sHeader.Length > MaxLineLength) MaxLineLength = sHeader.Length + 1;

                //Limit line length
                if (sampleData.DataHeader.Length > iLineCharLimit)
                {
                    sHeader = sampleData.DataHeader.Substring(0, iLineCharLimit - 3) + "...";
                }

                //Add to display
                sBuilder.AppendLine(sHeader);
                mylines[counter] = sHeader;
                counter++;
            }


            //Add each line
            foreach (var item in sampleData.DataLines)
            {
                //Record max length to adjust control width
                if (item.Length > MaxLineLength) MaxLineLength = item.Length + 1;

                //Limit line length
                string sLine = item;
                if (item.Length > iLineCharLimit)
                {
                    sLine = item.Substring(0, iLineCharLimit - 3) + "...";
                }

                //Add to display
                mylines[counter] = sLine;
                sBuilder.AppendLine(sLine);
                counter++;
            }


            Selections.RemoveAll(x => x >= MaxLineLength);


            ContentRichEditControl.Invalidate();
            //myRuler.Refresh();
            LoadString(sBuilder.ToString());
        }


        /// <summary>
        /// Returns a list with column start and stop coordinates. 
        /// </summary>
        public List<int> GetSelection()
        {

            //Check size
            if (Selections.Count == 0 || Selections.Count != 2)
            {
                return null;
            }

            //Check start/end point
            if (Selections.Any(a => a < 0))
            {
                return null;
            }

            //Operation fail
            Selections.Sort();
            return Selections;
        }

        /// <summary>
        /// Set the column coordinates
        /// </summary>
        /// <param name="ColumnSelection"></param>
        public void SetColumnCoords(List<Tuple<SolidBrush, int, int>> ColumnSelection)
        {
            //myRuler.Refresh(); //Reload ruler marker
        }

        /// <summary>
        /// Clear selected points.
        /// </summary>
        public void ClearColumnCoords()
        {
            Selections.Clear();
            this.Invalidate(); //Redraw content area
            //myRuler.Refresh(); //re-draw ruler, must refresh to be effected
        }




        /// <summary>
        /// Parsing application mouse event message
        /// This affect application performace 10-15% cpu
        /// </summary>
        class MyMessageFilter : IMessageFilter
        {
            myRulerControl myRuler;

            public MyMessageFilter(myRulerControl ruler)
            {
                this.myRuler = ruler;
            }

            public bool PreFilterMessage(ref Message m)
            {
                try
                {
                    //Enable check
                    if (!myRuler.Enabled)
                    {
                        return false;
                    }

                    //Mouse move
                    if (m.Msg == (int)Msg.WM_MOUSEMOVE)
                    {
                        if (myRuler.IsDisposed) return false;

                        Point pointScreen = Control.MousePosition;
                        Point pointClientOrigin = myRuler.PointToScreen(Point.Empty);
                        int X = pointScreen.X - pointClientOrigin.X;
                        int Y = pointScreen.Y - pointClientOrigin.Y;

                        myRuler._bDrawMark = true;
                        myRuler._bDrawMark = (pointScreen.X >= pointClientOrigin.X) && (pointScreen.X <= pointClientOrigin.X + myRuler.Width);

                        if (myRuler._bDrawMark)
                        {
                            X = pointScreen.X - pointClientOrigin.X;
                            Y = pointScreen.Y - pointClientOrigin.Y;
                            myRuler._iMousePosition = X;
                        }
                        else
                        {
                            myRuler._iMousePosition = -1;
                        }

                        PaintEventArgs e = null;
                        try
                        {
                            e = new PaintEventArgs(myRuler.CreateGraphics(), myRuler.ClientRectangle);
                            myRuler.onPaint(e);

                        }
                        finally
                        {
                            e.Graphics.Dispose();
                        }
                    }

                    //Mouse leave
                    if ((m.Msg == (int)Msg.WM_MOUSELEAVE) ||
                        (m.Msg == (int)Msg.WM_NCMOUSELEAVE))
                    {
                        if (myRuler.IsDisposed) return false;

                        myRuler._bDrawMark = false;
                        myRuler._bDragged = false;
                        myRuler._iMouseDownMousePosition = -1;
                        myRuler._iDraggedIndex = -1;
                        myRuler._iDroppedIndex = -1;
                        PaintEventArgs paintArgs = null;
                        try
                        {
                            paintArgs = new PaintEventArgs(myRuler.CreateGraphics(), myRuler.ClientRectangle);
                            myRuler.onPaint(paintArgs);
                        }
                        finally
                        {
                            paintArgs.Graphics.Dispose();
                        }
                    }

                    //Mouse left button down
                    if (m.Msg == (int)Msg.WM_LBUTTONDOWN)
                    {
                        if (myRuler.IsDisposed) return false;

                        Point pointScreen = Control.MousePosition;
                        Point pointClientOrigin = myRuler.PointToScreen(Point.Empty);
                        int X = pointScreen.X - pointClientOrigin.X;
                        int Y = pointScreen.Y - pointClientOrigin.Y;
                        if (myRuler.ClientRectangle.Contains(new Point(X, Y)))
                        {
                            myRuler._iMouseDownMousePosition = X;
                            int index = Convert.ToInt32(Math.Round((float)(X - myRuler.myParentControl.iCharWidth / 2) / myRuler.myParentControl.iCharWidth));
                            if (myRuler.myParentControl.Selections.Contains(index))
                            {
                                myRuler._iDraggedIndex = index;
                            }

                            if (myRuler._iDraggedIndex > -1 && myRuler.myParentControl.Selections.Count % 2 == 0)
                            {
                                myRuler._bDragged = true;
                            }
                            else
                            {
                                myRuler._bDragged = false;
                            }
                            myRuler.UpdateIndexes(MouseButtons.Left, index);
                        }
                    }

                    //Mouse left button up
                    if (m.Msg == (int)Msg.WM_LBUTTONUP)
                    {
                        if (myRuler.IsDisposed) return false;

                        Point pointScreen = Control.MousePosition;
                        Point pointClientOrigin = myRuler.PointToScreen(Point.Empty);
                        int X = pointScreen.X - pointClientOrigin.X;
                        int Y = pointScreen.Y - pointClientOrigin.Y;

                        myRuler._iDroppedIndex = Convert.ToInt32(Math.Round((float)(X - myRuler.myParentControl.iCharWidth / 2) / myRuler.myParentControl.iCharWidth));

                        if ((myRuler._iDraggedIndex > -1) && myRuler.ClientRectangle.Contains(new Point(X, Y)))
                        {
                            if ((myRuler._iDraggedIndex != myRuler._iDroppedIndex) && myRuler.myParentControl.Selections.Count % 2 == 0)
                            {
                                myRuler._bDragged = true;
                            }
                            else
                            {
                                myRuler._bDragged = false;
                            }
                            myRuler.UpdateIndexes(MouseButtons.Left, myRuler._iDroppedIndex);
                        }

                        myRuler._bDragged = false;
                        myRuler._bDrawMark = true;
                        myRuler._iMouseDownMousePosition = -1;
                        myRuler._iDraggedIndex = -1;
                        myRuler._iDroppedIndex = -1;
                    }

                    //If right mouse down
                    if (m.Msg == (int)Msg.WM_RBUTTONDOWN || m.Msg == (int)Msg.WM_NCRBUTTONDOWN)
                    {
                        //Right mouse click operation
                        myRuler.UpdateIndexes(MouseButtons.Right, -2);
                    }


                    //Mouse up in nonclient area
                    if (m.Msg == (int)Msg.WM_NCLBUTTONUP)
                    {
                        myRuler._bDragged = false;
                        myRuler._bDrawMark = true;
                        myRuler._iMouseDownMousePosition = -1;
                        myRuler._iDraggedIndex = -1;
                        myRuler._iDroppedIndex = -1;
                    }
                }

                catch (Exception e)
                {
                    Debug.WriteLine("ColumnSelectorControlSingle.PreFilterMessage:\r\n" + e.Message);
                }

                return false;  // Whether or not the message is filtered
            }
        }
        #endregion MyMessageFilter

        #region Msg
        /// <summary>
        /// Reference
        /// https://docs.microsoft.com/en-us/windows/win32/inputdev/mouse-input-notifications
        /// </summary>
        internal enum Msg
        {
            WM_MOUSEMOVE = 0x0200, //Mouse move
            WM_LBUTTONDOWN = 0x201, //Mouse left button down
            WM_LBUTTONUP = 0x202,  //mouse left button up
            WM_MOUSELEAVE = 0x02A3, //mouse leave
            WM_NCMOUSELEAVE = 0x02A2, //None-client area (Titlebar, menue bar, frame) mouse leave
            WM_NCLBUTTONUP = 0xA2, //None-client area button up
            WM_NCLBUTTONDOWN = 0xA1, //none client area button down
            WM_RBUTTONDOWN = 0x0204, //Right mouse down
            WM_NCRBUTTONDOWN = 0x00A4 //Right mouse down in none-client area
        }
        #endregion Msg

        /// <summary>
        /// Button type of the event
        /// </summary>
        public class IndexCollectionChangeEventArgs : EventArgs
        {
            public MouseButtons Button;
            public IndexCollectionChangeEventArgs(MouseButtons _button) : base()
            {
                this.Button = _button;
            }
        }
    }

}
