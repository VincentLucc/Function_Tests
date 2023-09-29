using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
    public partial class ColumnSelectorControlV2 : XtraUserControl
    {
        #region ColumnSelectorControlSingle_Properties

        private myRulerControl myRuler;
        private myContentControl myContent;
        private string[] mylines;

        /// <summary>
        /// Returns all the lines of the file.
        /// </summary>
        public string[] MyLines
        {
            get
            {
                return mylines;
            }
        }
        /// <summary>
        /// List of selected indexes in sample data, to build "SelectedIndexes" property.
        /// this list can be empty
        /// </summary>
        public List<int> myIndexes = new List<int> { };

        const string strMarkerChar = "▼";

        /// <summary>
        /// Width of a character in pixels from the fixed size Font used for this control (Default: Consolas)
        /// </summary>
        internal int iCharWidth = 7;
        private float fCharWidth = 7f; // no use; just for debug
        /// <summary>
        /// Hides the Font property
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get { return base.Font; }
            set { }
        }

        private float m_FontSize = 12f;


        /// <summary>
        /// Set Font size, Font Family will be always Consolas
        /// </summary>
        public float FontSize
        {
            get
            {
                return m_FontSize;
            }
            set
            {
                if (m_FontSize != value)
                {
                    m_FontSize = value;
                    base.Font = new System.Drawing.Font("Consolas", m_FontSize, System.Drawing.FontStyle.Regular);
                    MeasureFontSize();
                    myContent.Font = base.Font;
                    myContent.Width = 8 + (iRecordMaxLength + 1) * Convert.ToInt32(iCharWidth);
                    myRuler.Refresh();
                }
            }
        }

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
        /// Option to set the color of vertical marker lines
        /// </summary>
        public Color MarkerColor
        {
            get { return myContent.penMyMarker.Color; }
            set
            {
                myContent.penMyMarker = new Pen(value);
                myContent.Invalidate();
            }
        }

        /// <summary>
        /// Longest row in the sample file, which is used to set the size of the content viewer
        /// </summary>
        private int iRecordMaxLength = 1;

        public EventHandler SelectionReady;

        #endregion ColumnSelectorControlSingle_Properties
        public ColumnSelectorControlV2()
        {
            InitializeComponent();
            base.Font = new System.Drawing.Font("Consolas", m_FontSize, System.Drawing.FontStyle.Regular);
            this.panelMain.SuspendLayout();
            myContent = new myContentControl(this);
            myRuler = new myRulerControl(this);
            myRuler.IndexCollectionChanged += IndexCollectionChanged;
            this.panelMain.Controls.Add(myContent);
            this.panelMain.Controls.Add(myRuler);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            MeasureFontSize();
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


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Etched);
        }

        private void IndexCollectionChanged(object sender, IndexCollectionChangeEventArgs e)
        {
            //Check if right mouse clicked
            if (e.Button == MouseButtons.Right)
            {
                ClearColumnCoords();//Remove all selection and update view
                return;
            }

            UpdateView(); //Update view before trigger operation

            //Check if selection ready
            var updateResult = getSingleColumnCoords();
            if (updateResult.IsSuccess)
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
            myIndexes.RemoveAll(i => i >= iRecordMaxLength); // safety;
            myContent.Invalidate();
            myRuler.Refresh();
        }



        /// <summary>
        /// Returns a list with column start and stop coordinates. 
        /// </summary>
        public SelectionResult getSingleColumnCoords()
        {
            //Init reuslt
            var result = new SelectionResult();

            //Check size
            if (myContent.DrawnPoints.Count == 0 || myContent.DrawnPoints.Count != 1)
            {
                result.IsSuccess = false;
                result.Message = "Invalid selection.";
                return result;
            }

            //Check start/end point
            if (myContent.DrawnPoints[0][0] > -1 && myContent.DrawnPoints[0][1] > -1)
            {
                result.IsSuccess = true;
                result.Selection = myContent.DrawnPoints;
                return result;
            }



            //Operation fail
            result.IsSuccess = false;
            return result;
        }

        /// <summary>
        /// To load the content of a sample text file
        /// Replaced string with string builder
        /// </summary>
        public void LoadFile(string filePath, int rows, bool hasJH = false)
        {
            //Init variables
            StringBuilder sBuilder = new StringBuilder(); //Full text
            string sLine; //Line text
            Stopwatch watch = new Stopwatch(); //Load file tester
            watch.Start();

            //Check file existance
            if (!File.Exists(filePath))
            {
                watch.Stop();
                return;
            }

            //Try to load file
            int[] maxTabAreas = new int[0];
            int counter = 0;
            iRecordMaxLength = 1;
            mylines = new string[rows];

            counter = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                if (hasJH)
                {
                    reader.ReadLine();
                    reader.ReadLine();
                }

                while (counter < rows)
                {
                    sLine = reader.ReadLine();
                    if (sLine == null) break;


                    if (sLine.Length > iRecordMaxLength) iRecordMaxLength = sLine.Length + 1;
                    mylines[counter] = sLine;
                    sBuilder.Append(sLine);
                    sBuilder.Append(System.Environment.NewLine);


                    counter++;
                    Debug.WriteLine("Fullstring:" + sBuilder.Length);
                }
            }
            myIndexes.RemoveAll(x => x >= iRecordMaxLength);
            myContent.Width = (iRecordMaxLength + 1) * Convert.ToInt32(iCharWidth); //Max=65535
            myContent.Height = 1000;
            myContent.MinimumSize = new Size(myContent.Width, 1000);
            myContent.Invalidate();
            myRuler.Refresh();

            //When string size to big,Limit string size
            if (sBuilder.Length > 65535) sBuilder.Remove(65535, sBuilder.Length - 65535);
            myContent.Text = sBuilder.ToString().TrimEnd();

            //output watch
            watch.Stop();
            Debug.WriteLine("File Load time:" + watch.ElapsedMilliseconds);
        }


        /// <summary>
        /// Returns two dimensional array that is the data collection of selected columns. First column is between minimum two indexes, and columns are between consecutive indexes.
        /// </summary>
        public string[][] getColumnData()
        {
            if (myIndexes.Count > 1 && myIndexes.Count % 2 == 0)
            {
                string[][] arr = new string[myIndexes.Count / 2][];
                for (int i = 0; i < myIndexes.Count; i += 2)
                {
                    int p1 = myIndexes[i], p2 = myIndexes[i + 1];
                    arr[i / 2] = new string[MyLines.Length];
                    for (int j = 0; j < MyLines.Length; j++)
                    {
                        p2 = myIndexes[i + 1];
                        if (p2 > MyLines[j].Length) { p2 = MyLines[j].Length; }
                        string workString = MyLines[j];
                        if (p2 > p1)
                            arr[i / 2][j] = workString.Substring(p1, p2 - p1);
                    }
                    p1 = p2;
                }
                return arr;
            }
            else
            {
                return null;
            }
        }



 

        /// <summary>
        /// Set the column coordinates
        /// </summary>
        /// <param name="ColumnSelection"></param>
        public void SetColumnCoords(List<Tuple<SolidBrush, int, int>> ColumnSelection)
        {
            myContent.SetDrawPoint(ColumnSelection);
            myRuler.Refresh(); //Reload ruler marker
        }

        /// <summary>
        /// Clear selected points.
        /// </summary>
        public void ClearColumnCoords()
        {
            myContent.ClearDrawPoint();
        }

        /// <summary>
        /// Manual set scroll bar location and update the view 
        /// </summary>
        /// <param name="iValue"></param>
        public void SetScrollLocation(List<Tuple<SolidBrush, int, int>> ColumnSelection)
        {
            //Empty check
            if (ColumnSelection==null||ColumnSelection.Count != 1) return;

            //Get text pixel locaton
            int iStart = ColumnSelection[0].Item2 * iCharWidth;
            int iEnd= ColumnSelection[0].Item3 * iCharWidth;
            int iScroll = 0;
            //Set based on range
            //Leave a gap
            if ((iStart - 50) > 0) iScroll = iStart - 50;

            //Apply scroll location
            panelMain.HorizontalScroll.Value = iScroll;
            panelMain.PerformLayout(); //Force scroll location to be redraw
        }


        #region myContentControl
        /// <summary>
        /// This is the child control class that displays the content of sample text/csv file
        /// </summary>
        internal class myContentControl : Label
        {

            /// <summary>
            /// Helps draw selected text colored areas.
            /// </summary>
            private List<Tuple<SolidBrush, int, int>> drawPoints;
            public List<int[]> DrawnPoints
            {
                get
                {
                    List<int[]> list = new List<int[]>();
                    foreach (var drawPoint in drawPoints)
                    {
                        list.Add(new int[2] { drawPoint.Item2, drawPoint.Item3 });
                    }
                    return list;
                }
            }

            private ColumnSelectorControlV2 myParentControl;

            internal Pen penMyMarker = Pens.Gray;

            public myContentControl(ColumnSelectorControlV2 p)
            {

                if (p != null) myParentControl = p;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.CacheText, true); //Increase performance
                //this.AutoScrollOffset = ScrollableControl.
                base.BackColor = System.Drawing.SystemColors.Control;
                base.ForeColor = System.Drawing.Color.Black;
                this.Dock = System.Windows.Forms.DockStyle.Left;
                base.Font = new System.Drawing.Font("Consolas", myParentControl.FontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Location = new System.Drawing.Point(0, 26);
                this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                this.Name = "myContent";
                this.Size = new System.Drawing.Size(1, 1);
            }

 
            /// <summary>
            /// Apply draw points to interface
            /// </summary>
            public void SetDrawPoint(List<Tuple<SolidBrush, int, int>> DrawPoints)
            {
                //Value to readout
                drawPoints = DrawPoints;

                //Set index (value for UI draw)
                myParentControl.myIndexes.Clear();
                for (int i = 0; i < drawPoints.Count; i++)
                {
                    myParentControl.myIndexes.Add(drawPoints[i].Item2); //Start point
                    myParentControl.myIndexes.Add(drawPoints[i].Item3); //End point
                }

                this.Refresh();
            }


            /// <summary>
            /// Remove all selection
            /// </summary>
            public void ClearDrawPoint()
            {
                drawPoints = new List<Tuple<SolidBrush, int, int>>();
                myParentControl.myIndexes.Clear();
                this.Invalidate(); //Redraw content area
                myParentControl.myRuler.Refresh(); //re-draw ruler, must refresh to be effected
            }


            /// <summary>
            ///
            /// </summary>
            /// <param name="e"></param>
            protected override void OnPaint(PaintEventArgs e)
            {

                base.OnPaint(e);
                if (myParentControl != null)
                {
                    int charWidth = myParentControl.iCharWidth;
                    int LeftOffset = myParentControl.iCharWidth / 2 - 1;

                    SolidBrush brush;
                    SolidBrush red = new SolidBrush(Color.FromArgb(32, 255, 0, 0));
                    SolidBrush blue = new SolidBrush(Color.FromArgb(32, 0, 0, 255));
                    int count = 0;
                    if (myParentControl.myIndexes.Count % 2 == 0)
                    {
                        drawPoints = new List<Tuple<SolidBrush, int, int>>();
                        for (int i = 1; i < myParentControl.myIndexes.Count; i += 2)
                        {
                            int p1 = LeftOffset + myParentControl.myIndexes[i - 1] * charWidth;
                            int p2 = LeftOffset + myParentControl.myIndexes[i] * charWidth;
                            if (count % 2 == 0)
                            {
                                brush = red;
                            }
                            else
                            {
                                brush = blue;
                            }
                            e.Graphics.FillRectangle(brush, p1, 0, p2 - p1, this.Height);
                            count++;
                            drawPoints.Add(new Tuple<SolidBrush, int, int>(brush, myParentControl.myIndexes[i - 1], myParentControl.myIndexes[i]));
                        }
                    }
                    else
                    {
                        if (drawPoints != null && drawPoints.Count > 0)
                        {
                            Tuple<SolidBrush, int, int> toRemove = null;
                            foreach (var drawPoint in drawPoints)
                            {
                                brush = drawPoint.Item1;
                                int p1 = LeftOffset + drawPoint.Item2 * charWidth;
                                int p2 = LeftOffset + drawPoint.Item3 * charWidth;
                                if (myParentControl.myIndexes.Contains(drawPoint.Item2) && myParentControl.myIndexes.Contains(drawPoint.Item3))
                                {
                                    e.Graphics.FillRectangle(brush, p1, 0, p2 - p1, this.Height);
                                }
                                else
                                {
                                    toRemove = new Tuple<SolidBrush, int, int>(drawPoint.Item1, drawPoint.Item2, drawPoint.Item3);
                                }
                            }

                            if (toRemove != null)
                            {
                                drawPoints.Remove(toRemove);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region myRulerControl
        /// <summary>
        /// This is the child control on top, with ruler and selection markings
        /// </summary>
        internal class myRulerControl : System.Windows.Forms.Control
        {
            public ColumnSelectorControlV2 myParentControl;

            private MyMessageFilter msgFilter; //Filter and trigger mouse event

            private static Pen myDashPen;
            private Bitmap _Bitmap = null;
            private SizeF myMarkersize;
            const string strMarkerChar = "▼";
            public bool _bDrawMark = false;
            public bool _bDragged = false;
            public int _iMousePosition = 1;
            public int _iMouseDownMousePosition = -1;
            public int _iDraggedIndex = -1;
            public int _iDroppedIndex = -1;

            #region Events and Delegates
            public delegate void IndexCollectionChangedEvent(object sender, IndexCollectionChangeEventArgs e);
            public event IndexCollectionChangedEvent IndexCollectionChanged;

            protected void OnIndexCollectionChanged(IndexCollectionChangeEventArgs e)
            {
                IndexCollectionChanged?.Invoke(this, e);
            }

            #endregion

            public myRulerControl(ColumnSelectorControlV2 p)
            {

                if (p != null) myParentControl = p;

                msgFilter = new MyMessageFilter(this);
                AddMessageFilter();
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                base.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                base.BackColor = System.Drawing.Color.White;
                this.Dock = System.Windows.Forms.DockStyle.Top;
                base.ForeColor = System.Drawing.Color.Black;
                base.Location = new System.Drawing.Point(0, 0);
                this.Margin = new System.Windows.Forms.Padding(4);
                this.Name = "myRuler";
                this.Text = "";
                this.Size = new System.Drawing.Size(1, 26);

                using (Graphics g = this.CreateGraphics())
                {
                    this.myMarkersize = g.MeasureString(strMarkerChar, this.Font, 100, StringFormat.GenericTypographic);
                }

                myDashPen = new Pen(Color.DarkBlue, 1)
                {
                    DashPattern = new float[] { 1f, 1f }
                };
            }

            ~myRulerControl()
            {
                RemoveMessageFilter();
            }

            private void AddMessageFilter()
            {
                try
                {
                    Application.AddMessageFilter(msgFilter);
                }
                catch { }
            }

            private void RemoveMessageFilter()
            {
                try
                {
                    Application.RemoveMessageFilter(msgFilter);
                }
                catch { }
            }

            public void UpdateIndexes(MouseButtons OperationButton, int NewIndex = -1)
            {
                //Alias for current index
                var indexlist = myParentControl.myIndexes;

                //Get event arg
                var e = new IndexCollectionChangeEventArgs(OperationButton);

                //avoid null error
                if (NewIndex == -1) return;

                //Check if same index exist
                if (indexlist.Contains(NewIndex)) return;

                //Handle right mouse operation
                if (e.Button == MouseButtons.Right)
                {
                    //trigger event
                    this.OnIndexCollectionChanged(e);
                    return;
                }

                //Handle drag and drop operation
                if (_bDragged)
                {
                    Debug.WriteLine($"Handle drag and drop drag:{_iDraggedIndex},drop:{_iDroppedIndex}");
                    HandleDragAndDropOperation(e);
                    return;
                }

                //Handle mouse left button selection (Normal selection)
                HandleNormalIndexClickOperation(NewIndex, e);
            }


            /// <summary>
            /// Update selection when drag and drop happened
            /// </summary>
            private void HandleDragAndDropOperation(IndexCollectionChangeEventArgs e)
            {
                //Get index
                var indexlist = myParentControl.myIndexes;

                //Check drag and drop value
                if (_iDraggedIndex < 0 || _iDroppedIndex < 0 || _iDraggedIndex == _iDroppedIndex)
                {
                    return;
                }

                //Check if user clicked on existing index
                if (!indexlist.Contains(_iDraggedIndex))
                {
                    return;
                }

                //If clicked existing index, modify selected index
                indexlist[indexlist.IndexOf(_iDraggedIndex)] = _iDroppedIndex;

                //Update draw points, so value can be read out right away
                if (indexlist.Count == 2)
                {
                    Tuple<SolidBrush, int, int> t1 = new Tuple<SolidBrush, int, int>(new SolidBrush(Color.Red), indexlist[0], indexlist[1]);
                    myParentControl.SetColumnCoords(new List<Tuple<SolidBrush, int, int>>() { t1 });
                }

                //trigger event
                this.OnIndexCollectionChanged(e);
            }

            /// <summary>
            /// Modify index selection based on mouse left click
            /// </summary>
            /// <param name="NewIndex"></param>
            private void HandleNormalIndexClickOperation(int NewIndex, IndexCollectionChangeEventArgs e)
            {
                //Get index size
                var indexlist = myParentControl.myIndexes;
                int iSize = indexlist.Count;

                //Empty indexlist simply add
                if (iSize == 0)
                {
                    indexlist.Add(NewIndex);
                }
                //One exist, compare and add
                else if (iSize == 1)
                {
                    //compare size, make sure value in order
                    if (NewIndex > indexlist[0])
                    {
                        indexlist.Add(NewIndex);
                    }
                    else
                    {
                        int iTemp = indexlist[0];
                        indexlist = new List<int>() { iSize, iTemp };
                    }
                }
                //Two exist, replace one
                else if (iSize == 2)
                {
                    //If new index is bigger than end, replace end
                    if (NewIndex > indexlist[1]) indexlist[1] = NewIndex;
                    //If new index smaller than start, replace start
                    else if (NewIndex < indexlist[0]) indexlist[0] = NewIndex;
                    //If new index in middle, just replace end
                    else indexlist[1] = NewIndex;
                }
                else if (iSize > 2)
                {
                    //error, just remove extra record
                    indexlist.RemoveRange(2, indexlist.Count - 2);
                }


                //Update draw points, so value can be read out right away
                if (indexlist.Count == 2)
                {
                    Tuple<SolidBrush, int, int> t1 = new Tuple<SolidBrush, int, int>(new SolidBrush(Color.Red), indexlist[0], indexlist[1]);
                    myParentControl.SetColumnCoords(new List<Tuple<SolidBrush, int, int>>() { t1 });
                }

                //trigger event
                this.OnIndexCollectionChanged(e);
            }

            private void DrawControl(Graphics graphics)
            {
                Graphics g = null;
                if (!this.Visible) return;
                if (this.Width < 1 || this.Height < 1) return;

                if (_Bitmap == null)
                {
                    _Bitmap = new Bitmap(this.Width, this.Height);
                    g = Graphics.FromImage(_Bitmap);

                    try
                    {
                        g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, _Bitmap.Width, _Bitmap.Height);
                        g.DrawLine(Pens.DarkGray, 0, this.Height - 1, this.Width, this.Height - 1);

                        int iStep = myParentControl.iCharWidth;
                        int iStart = myParentControl.iCharWidth / 2;
                        int iEnd = Width;
                        int charIndex = 0;

                        for (int j = iStart; j <= iEnd; j += iStep)
                        {
                            if (charIndex % 10 == 0)
                            {
                                DivisionMark(g, j, 2); // 1/2 height
                                int pX = 0;
                                if (j == iStart)
                                {
                                    pX = myParentControl.iCharWidth / 2 + j - 1 - (int)myMarkersize.Width / 2;
                                }
                                else
                                {
                                    pX = myParentControl.iCharWidth / 2 + j - iStart - (int)myMarkersize.Width / 2;
                                }
                                Point drawingPoint = new Point(pX, -1);
                                g.DrawString(charIndex.ToString(), this.Font, new SolidBrush(this.ForeColor), drawingPoint, StringFormat.GenericTypographic);
                            }
                            else if (charIndex % 2 == 0)
                            {
                                DivisionMark(g, j, 3); // 1/3 height
                            }
                            else
                            {
                                DivisionMark(g, j, 4); // 1/4 height
                            }
                            charIndex++;
                        }

                        if (myParentControl != null)
                        {
                            int charWidth = myParentControl.iCharWidth;
                            foreach (int i in myParentControl.myIndexes)
                            {
                                Point drawingPoint = new Point(myParentControl.iCharWidth / 2 + i * charWidth - (int)myMarkersize.Width / 2, this.Height - (int)myMarkersize.Height);
                                g.DrawString(strMarkerChar, this.Font, new SolidBrush(this.ForeColor), drawingPoint, StringFormat.GenericTypographic);
                            }
                        }
                    }
                    catch { }
                    finally
                    {
                        g.Dispose();
                    }
                }

                g = graphics;

                try
                {
                    g.DrawImage(_Bitmap, this.ClientRectangle);
                    if (_bDrawMark)
                    {
                        int p = myParentControl.iCharWidth / 2 + (int)Math.Floor((double)_iMousePosition / myParentControl.iCharWidth) * myParentControl.iCharWidth;
                        g.DrawLine(myDashPen, p, 0, p, Height);

                        Point drawingPoint = new Point(p - (int)myMarkersize.Width / 2, this.Height - (int)myMarkersize.Height);
                        g.DrawString(strMarkerChar, this.Font, new SolidBrush(Color.Gray), drawingPoint, StringFormat.GenericTypographic);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {
                    GC.Collect();
                }
            }

            private void DivisionMark(Graphics g, int iPosition, int iProportion)
            {
                int iMarkStart = 0, iMarkEnd = 0;

                iMarkStart = Height - Height / iProportion;
                iMarkEnd = Height;

                g.DrawLine(Pens.Black, iPosition, iMarkStart, iPosition, iMarkEnd);
            }

            #region overrides

            protected override void OnEnter(EventArgs e)
            {
                base.OnEnter(e);
                _bDrawMark = false;
                Invalidate();
            }

            protected override void OnLeave(EventArgs e)
            {
                base.OnLeave(e);
                Invalidate();
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);
                // Take private resize actions here
                _Bitmap = null;
                this.Invalidate();
            }

            public override void Refresh()
            {
                base.Refresh();
                _Bitmap = null;
                this.Invalidate();
            }

            public void onPaint(PaintEventArgs e)
            {
                OnPaint(e);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                DrawControl(e.Graphics);
            }

            protected override void OnHandleDestroyed(EventArgs e)
            {
                base.OnHandleDestroyed(e);
                RemoveMessageFilter();

            }

            protected override void OnControlRemoved(ControlEventArgs e)
            {
                base.OnControlRemoved(e);
                RemoveMessageFilter();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_Bitmap != null)
                    {
                        _Bitmap.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            #endregion

        }
        #endregion myRulerControl

        #region MyMessageFilter
        /// <summary>
        /// Parsing application mouse event message
        /// This affect application performace 10-15% cpu
        /// </summary>
        internal class MyMessageFilter : IMessageFilter
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
                            if (myRuler.myParentControl.myIndexes.Contains(index))
                            {
                                myRuler._iDraggedIndex = index;
                            }

                            if (myRuler._iDraggedIndex > -1 && myRuler.myParentControl.myIndexes.Count % 2 == 0)
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
                            if ((myRuler._iDraggedIndex != myRuler._iDroppedIndex) && myRuler.myParentControl.myIndexes.Count % 2 == 0)
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
