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
        private string[] DataRows;

        /// <summary>
        /// List of selected indexes in sample data, to build "SelectedIndexes" property.
        /// this list can be empty
        /// </summary>
        public List<int> Selections = new List<int> { };
        /// <summary>
        /// Save current mouse position
        /// </summary>
        private int MouseCharPosition { get; set; }

        const string strMarkerChar = "▼";

        private float FontSize = 12f;


        /// <summary>
        /// Longest row in the sample file, which is used to set the size of the content viewer
        /// </summary>
        private int MaxLineLength = 1;

        private int RulerHeight = 28;

        private int CharWidth = 9;

        /// <summary>
        /// The indent of the ruler and text
        /// </summary>
        private int StartIndent = 5;
        private int EndIndent = 5;

        /// <summary>
        /// Start point of the sub divisions
        /// </summary>
        public List<int> DivisionSub = new List<int>();
        /// <summary>
        /// Main division show text
        /// </summary>
        public List<int> DivisionMain = new List<int>();


        public event EventHandler RangeSelected;

        public event EventHandler SelectionChanged;

        /// <summary>
        /// Transparent gray color
        /// </summary>
        private SolidBrush brushGrayTrans;
        private SolidBrush brushForeColor;
        private Pen penDashGray;

        public ColumnSelectorControlV3()
        {
            InitializeComponent();
            base.Font = new Font("Consolas", FontSize, FontStyle.Regular);
            toolTip1.SetToolTip(ContentRichEditControl, "");

            //Init variables
            var transGray = Color.FromArgb(32, Color.Gray);
            brushGrayTrans = new SolidBrush(transGray);
            brushForeColor = new SolidBrush(this.ForeColor);

            penDashGray = new Pen(Color.Gray, 1);
            penDashGray.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;


            InitTextEditControl();
        }


        private void InitTextEditControl()
        {
            //Load fake data
            LoadString(csPublic.FakeText);

            //Setup Text
            Font = new Font("Consolas", FontSize, FontStyle.Regular);

            //Setup layout
            ContentRichEditControl.ActiveViewType = RichEditViewType.Simple;

            //Setup the view
            var simpleView = ContentRichEditControl.ActiveView as SimpleView;
            simpleView.WordWrap = false;
            simpleView.Padding = new Padding(StartIndent, RulerHeight, EndIndent, 0);

            //Setup document
            ContentRichEditControl.DocumentLoaded += ContentRichEditControl_DocumentLoaded;

            //Disable right click menu
            ContentRichEditControl.Options.Behavior.ShowPopupMenu = DocumentCapability.Disabled;

            //Draw text selection rectangle and ruler
            ContentRichEditControl.CustomDrawActiveView += MyContentControl_CustomDrawActiveView;

            //Move click
            ContentRichEditControl.MouseClick += ContentRichEditControl_MouseClick;
            ContentRichEditControl.MouseMove += ContentRichEditControl_MouseMove;


            //Show notice
            ContentRichEditControl.MouseHover += ContentRichEditControl_MouseHover;

            //Disable buildin text selection
            ContentRichEditControl.SelectionChanged += ContentRichEditControl_SelectionChanged;
        }

        private void ContentRichEditControl_SelectionChanged(object sender, EventArgs e)
        {//Force to select nothing
            try
            {
                var myStart = ContentRichEditControl.Document.CreatePosition(0);
                var myRange = ContentRichEditControl.Document.CreateRange(myStart, 0);
                ContentRichEditControl.Document.Selection = myRange;
            }
            catch { }
        }

        private void ContentRichEditControl_MouseMove(object sender, MouseEventArgs e)
        {
            //Force cursor
            ContentRichEditControl.Cursor = Cursors.Arrow;

            //Only paint visible area, get start point
            int iVisibleStart = GetVisibleStart();
            var newPosition = (e.X + iVisibleStart + ContentRichEditControl.Left) / CharWidth;
            Debug.WriteLine($"Current Row:{newPosition}");

            //Only paint when position changed
            if (newPosition != MouseCharPosition)
            {
                MouseCharPosition = newPosition;
                ContentRichEditControl.Invalidate();
            }

        }

        private int GetVisibleStart()
        {
            //Get current display boundary
            //Get layout info
            List<PageLayoutInfo> pages = ContentRichEditControl.ActiveView.GetVisiblePageLayoutInfos();
            var borderInfo = pages[0].Bounds;
            //Only paint visible area, get start point
            int iVisibleStart = -borderInfo.X;

            return iVisibleStart;
        }

        private void ContentRichEditControl_MouseClick(object sender, MouseEventArgs e)
        {
            //Get selection
            //Get current display boundary
            int iVisibleStart = GetVisibleStart();
            var posX = (e.X + iVisibleStart + ContentRichEditControl.Left) / CharWidth;
            Debug.WriteLine($"Click:{posX}");

            //Add selection
            if (e.Button == MouseButtons.Left)
            {
                if (Selections.Count < 2 && !Selections.Contains(posX))
                {
                    Selections.Add(posX);
                    Selections.Sort();
                    SelectionChanged?.Invoke(null, null);
                    ContentRichEditControl.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (Selections.Count > 0)
                {
                    Selections.Clear();
                    SelectionChanged?.Invoke(null, null);
                    ContentRichEditControl.Invalidate();
                }
            }

            //Push result        
            if (Selections.Count == 2)
                RangeSelected?.Invoke(null, null);
        }

        public void ClearSelection()
        {
            Selections.Clear();
            ContentRichEditControl.Invalidate();
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
            ContentRichEditControl.Document.DefaultCharacterProperties.FontSize = FontSize;

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
            for (int i = 0; i <= MaxLineLength; i++)
            {
                int iPoint = i * CharWidth;

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
            //Only paint visible area, get start point
            int iVisibleStart = GetVisibleStart();

            PaintRuler(e, iVisibleStart);
            PaintContentArea(e, iVisibleStart);
        }

        private void PaintContentArea(RichEditViewCustomDrawEventArgs e, int iVisibleStart)
        {
            //Paint range
            int count = Selections.Count;
            if (count == 0 && count > 2) return;
            //Range selected
            if (count == 2)
            {
                int iStart = Selections.Min();
                int iEnd = Selections.Max();
                //Get actual draw position
                DrawContentSelection(e, iStart, iEnd);
            }
        }


        private void PaintRuler(RichEditViewCustomDrawEventArgs e, int iVisibleStart)
        {
            try
            {
                if (!ContentRichEditControl.Visible) return;
                if (ContentRichEditControl.Width < 1 || ContentRichEditControl.Height < 1) return;

                //Draw paint area
                int iWidth = ContentRichEditControl.Width;
                var rect = new Rectangle(iVisibleStart, -RulerHeight, iWidth, RulerHeight);
                var color = Color.WhiteSmoke;//Set to transparent color
                e.Cache.FillRectangle(color, rect);

                //Draw two lines
                e.Cache.DrawLine(iVisibleStart, -RulerHeight, iVisibleStart + iWidth, -RulerHeight, Color.DarkGray, 2); //Draw top line
                e.Cache.DrawLine(iVisibleStart, -1, iVisibleStart + iWidth, -1, Color.DarkGray, 2); //Draw bottom line

                //Check all saved division points
                for (int pageX = iVisibleStart; pageX < iVisibleStart + iWidth; pageX++)
                {
                    int iLineIndex = 0;

                    //Draw division lines
                    if (DivisionSub.Contains(pageX))
                    {
                        iLineIndex = DivisionSub.IndexOf(pageX);

                        if (!DivisionMain.Contains(pageX))
                        {
                            e.Cache.DrawLine(pageX, -2, pageX, -8, Color.Black, 1);
                        }
                    }

                    //Draw division text mark
                    if (DivisionMain.Contains(pageX))
                    {
                        //Draw higher line
                        e.Cache.DrawLine(pageX, -1, pageX, -13, Color.Black, 1);

                        //Draw text
                        int iViewPortX = pageX - iVisibleStart - StartIndent;
                        string sText = iLineIndex.ToString();
                        var textPoint = new Point(iViewPortX - (CharWidth * sText.Length / 2), -30);
                        e.Cache.DrawString(sText, this.Font, brushForeColor, textPoint);
                    }
                }

                //Draw saved slection marks and current mouse position
                DrawMarks(e, iVisibleStart);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ColumnSelector.PaintRuler.Exception:\r\n" + ex.Message);
            }

        }

        private void DrawMarks(RichEditViewCustomDrawEventArgs e, int iVisibleStart)
        {
            try
            {
                //Draw current mouse position mark
                if (DivisionSub.Count > 0 &&
                    MouseCharPosition > -1 &&
                    MouseCharPosition < DivisionSub.Count &&
                    this.Enabled)
                {
                    int iDrawPosition = DivisionSub[MouseCharPosition];

                    //Text x axis start from current view port
                    //Line x axis start from 0
                    var markTextPoint = new Point(iDrawPosition - CharWidth / 2 - iVisibleStart - StartIndent, -16);
                    e.Cache.DrawString(strMarkerChar, this.Font, brushGrayTrans, markTextPoint);

                    //Draw vertical dash line
                    e.Cache.DrawLine(penDashGray, new Point(iDrawPosition, 0), new Point(iDrawPosition, this.Height));
                }


                //Draw current selection markers
                foreach (var item in Selections)
                {
                    //Verification
                    if (DivisionSub.Count < 0 || MouseCharPosition >= DivisionSub.Count) continue;
                    int iDrawPosition = DivisionSub[item];
                    var markTextPoint = new Point(iDrawPosition - CharWidth / 2 - iVisibleStart - StartIndent, -16);
                    e.Cache.DrawString(strMarkerChar, this.Font, brushForeColor, markTextPoint);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ColumnSelector.DrawMarks:\r\n" + ex.Message);
            }

        }

        private void DrawContentSelection(RichEditViewCustomDrawEventArgs e, int iStart, int iEnd)
        {
            //Verification
            if (DivisionSub.Count <= iStart || DivisionSub.Count <= iEnd) return;
            int xStart = DivisionSub[iStart];
            int xEnd = DivisionSub[iEnd];

            //Get X axis start point and range
            int iWidth = Math.Abs(xEnd - xStart);
            int iHeight = ContentRichEditControl.Height;

            //Draw selection area
            var rect = new Rectangle(xStart, 0, iWidth, iHeight);
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


        public void LoadJobInfoRows(csFileData sampleData)
        {
            //Init 
            DataRows = new string[2];
            MaxLineLength = 0;
            int iLineCharLimit = 65535 / 9; //Ccontrol maximum width/char size

            //Job header
            string sJobHeader = sampleData.JobInfoHeader;
            if (sJobHeader.Length > MaxLineLength) MaxLineLength = sJobHeader.Length + 1;
            //Limit line length
            if (sJobHeader.Length > iLineCharLimit) sJobHeader = sJobHeader.Substring(0, iLineCharLimit - 3) + "...";
            DataRows[0] = sJobHeader;

            //Job data
            string sJobData = sampleData.JobInfoData;
            if (sJobData.Length > MaxLineLength) MaxLineLength = sJobData.Length + 1;
            //Limit line length
            if (sJobData.Length > iLineCharLimit) sJobData = sJobData.Substring(0, iLineCharLimit - 3) + "...";
            DataRows[1] = sJobData;

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
            DataRows = new string[iRowCount];
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
                DataRows[counter] = sHeader;
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
                DataRows[counter] = sLine;
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
    }
}