using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Test001
{

    /// <summary>
    /// Usage summary:
    /// 1. Call LoadFile method:            myControl.LoadFile(".\\demo.txt");
    /// 2. Set SelectedIndexes property:    myControl.SelectedIndexes = "0,5,10,20";
    /// </summary>
    public partial class ColumnSelectorControl : XtraUserControl
    {
        #region private stuff

        private myRulerControl myRuler;
        private myContentControl myContent;
        const string strMarkerChar = "▼";

        /// <summary>
        /// Width of a character in pixels from the fixed size Font used for this control (Default: Consolas)
        /// </summary>
        internal int iCharWidth = 7;
        private float fCharWidth = 7f; // no use; just for debug

        /// <summary>
        /// Longest row in the sample file, which is used to set the size of the content viewer
        /// </summary>
        private int iRecordMaxLength = 1;

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

        private void IndexCollectionChanged(object sender, IndexCollectionChangedEventArgs e)
        {
            if (e.oldIndex > -1)
            {
                if (this.myIndexes.Contains(e.oldIndex)) this.myIndexes.Remove(e.oldIndex);
            }
            if (e.newIndex != e.oldIndex && e.newIndex < iRecordMaxLength && myIndexes.Count < m_MaxColumns)
            {
                if (!this.myIndexes.Contains(e.newIndex))
                {
                    this.myIndexes.Add(e.newIndex);
                    this.myIndexes.Sort();
                }
            }
            myIndexes.RemoveAll(i => i >= iRecordMaxLength); // safety;
            myContent.Invalidate();
            myRuler.Refresh();
        }

        private void IndexCollectionAdd(object sender, IndexCollectionAddEventArgs e)
        {
            if (e.index < iRecordMaxLength && myIndexes.Count < m_MaxColumns)
            {
                if (!this.myIndexes.Contains(e.index))
                {
                    this.myIndexes.Add(e.index);
                    this.myIndexes.Sort();
                }
            }
            myIndexes.RemoveAll(i => i >= iRecordMaxLength);
            myContent.Invalidate();
            myRuler.Refresh();
        }
        private void IndexCollectionRemove(object sender, IndexCollectionRemoveEventArgs e)
        {
            if (e.index > -1)
            {
                if (this.myIndexes.Contains(e.index))
                {
                    this.myIndexes.Remove(e.index);
                    this.myIndexes.Sort();
                }
            }
            myIndexes.RemoveAll(i => i >= iRecordMaxLength);
            myContent.Invalidate();
            myRuler.Refresh();
        }

        private string[] mylines;

        #endregion

        #region Constructor and Public Methods/Properties
        public ColumnSelectorControl()
        {
            InitializeComponent();
            base.Font = new System.Drawing.Font("Consolas", m_FontSize, System.Drawing.FontStyle.Regular);
            this.panelMain.SuspendLayout();
            myContent = new myContentControl(this);
            myRuler = new myRulerControl(this);
            myRuler.IndexCollectionChanged += IndexCollectionChanged;
            myRuler.IndexCollectionAdd += IndexCollectionAdd;
            myRuler.IndexCollectionRemove += IndexCollectionRemove;
            this.panelMain.Controls.Add(myContent);
            this.panelMain.Controls.Add(myRuler);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            MeasureFontSize();
        }

        /// <summary>
        /// List of selected indexes in sample data, to build "SelectedIndexes" property.
        /// this list can be empty
        /// </summary>
        public List<int> myIndexes = new List<int> { };

        /// <summary>
        /// Returns all the lines of the file.
        /// </summary>
        public string[] myLines
        {
            get
            {
                return mylines;
            }
        }

        /// <summary>
        /// To load the content of a sample text file
        /// </summary>
        public void LoadFile(string filePath, int rows, bool hasJH = false)
        {
            if (File.Exists(filePath))
            {
                bool hasTab = false, doTab = false;  // debugging: set doTab to true to switch tab characters to spaces
                int[] maxTabAreas = new int[0];
                int counter = 0;
                iRecordMaxLength = 1;
                string str0 = string.Empty;
                string str1;
                mylines = new string[rows];

                if (doTab)
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (counter < rows)
                        {
                            str1 = reader.ReadLine();
                            if (str1 == null) break;

                            if (str1.Contains("\t"))
                            {
                                hasTab = true;
                                string[] sArr = str1.Split('\t');
                                if (maxTabAreas.Length < sArr.Length) maxTabAreas = new int[sArr.Length];
                                int iTabSpaces = 6;
                                for (int i = 0; i < sArr.Length; i++)
                                {
                                    int max = (int)Math.Ceiling((double)sArr[i].Length / iTabSpaces) * iTabSpaces;
                                    if (max > maxTabAreas[i]) maxTabAreas[i] = max;
                                }
                            }
                            counter++;
                        }
                    }
                }

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
                        str1 = reader.ReadLine();
                        if (str1 == null) break;

                        if (hasTab)
                        {
                            string[] sArr = str1.Split('\t');
                            string s0 = string.Empty;
                            for (int i = 0; i < sArr.Length; i++)
                            {
                                string s1 = sArr[i];
                                if (s1.Length < maxTabAreas[i]) s1 += new string(' ', maxTabAreas[i] - s1.Length);
                                s0 += s1;

                            }
                            s0 = s0.TrimEnd();
                            if (s0.Length > iRecordMaxLength) iRecordMaxLength = s0.Length + 1;
                            mylines[counter] = s0;
                            str0 += s0 + System.Environment.NewLine;
                        }
                        else
                        {
                            if (str1.Length > iRecordMaxLength) iRecordMaxLength = str1.Length + 1;
                            str0 += str1 + System.Environment.NewLine;
                            mylines[counter] = str1;
                        }

                        counter++;
                    }
                }
                myIndexes.RemoveAll(x => x >= iRecordMaxLength);
                myContent.Width = (iRecordMaxLength + 1) * Convert.ToInt32(iCharWidth);
                myContent.Height = 1000;
                myContent.MinimumSize = new Size(myContent.Width, 1000);
                myContent.Invalidate();
                myRuler.Refresh();
                myContent.Text = str0.TrimEnd(',');
            }
        }

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
                    arr[i / 2] = new string[myLines.Length];
                    for (int j = 0; j < myLines.Length; j++)
                    {
                        p2 = myIndexes[i + 1];
                        if (p2 > myLines[j].Length) { p2 = myLines[j].Length; }
                        string workString = myLines[j];
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
        /// Returns a list with column start and stop coordinates. 
        /// </summary>
        public List<int[]> getColumnCoords()
        {
            return myContent.DrawnPoints;
        }

        #endregion

    }

    /// <summary>
    /// This is the child control class that displays the content of sample text/csv file
    /// </summary>
    internal class myContentControl : Label
    {
        private ColumnSelectorControl myParentControl;

        internal Pen penMyMarker = Pens.Gray;

        public myContentControl(ColumnSelectorControl p)
        {
            if (p != null) myParentControl = p;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
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

    /// <summary>
    /// This is the child control on top, with ruler and selection markings
    /// </summary>
    internal class myRulerControl : System.Windows.Forms.Control
    {
        public ColumnSelectorControl myParentControl;

        private MyMessageFilter msgFilter;

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
        public delegate void IndexCollectionChangedEvent(object sender, IndexCollectionChangedEventArgs e);
        public event IndexCollectionChangedEvent IndexCollectionChanged;
        public delegate void IndexCollectionAddEvent(object sender, IndexCollectionAddEventArgs e);
        public event IndexCollectionAddEvent IndexCollectionAdd;
        public delegate void IndexCollectionRemoveEvent(object sender, IndexCollectionRemoveEventArgs e);
        public event IndexCollectionRemoveEvent IndexCollectionRemove;

        protected void OnIndexCollectionChanged(IndexCollectionChangedEventArgs e)
        {
            IndexCollectionChanged?.Invoke(this, e);
        }
        protected void OnIndexCollectionAdd(IndexCollectionAddEventArgs e)
        {
            IndexCollectionAdd?.Invoke(this, e);
        }
        protected void OnIndexCollectionRemove(IndexCollectionRemoveEventArgs e)
        {
            IndexCollectionRemove?.Invoke(this, e);
        }
        #endregion

        public myRulerControl(ColumnSelectorControl p)
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

        public void UpdateIndexes(int i1 = -1)
        {
            if (_bDragged && _iDraggedIndex > -1 && _iDroppedIndex > -1)
            {
                if (myParentControl.myIndexes.Contains(_iDraggedIndex) && myParentControl.myIndexes.Contains(_iDroppedIndex))
                {
                    IndexCollectionRemoveEventArgs e;
                    e = new IndexCollectionRemoveEventArgs(_iDraggedIndex);
                    this.OnIndexCollectionRemove(e);
                    e = new IndexCollectionRemoveEventArgs(_iDroppedIndex);
                    this.OnIndexCollectionRemove(e);
                }
                else
                {
                    IndexCollectionChangedEventArgs e = new IndexCollectionChangedEventArgs(_iDraggedIndex, _iDroppedIndex);
                    this.OnIndexCollectionChanged(e);
                }
            }
            else
            {
                if (_iDraggedIndex == _iDroppedIndex && _iDraggedIndex > -1 && _iDroppedIndex > -1)
                {
                    IndexCollectionRemoveEventArgs e = new IndexCollectionRemoveEventArgs(_iDroppedIndex);
                    this.OnIndexCollectionRemove(e);
                }
                else if (_iDraggedIndex != _iDroppedIndex && _iDraggedIndex > -1 && _iDroppedIndex > -1)
                {
                    IndexCollectionChangedEventArgs e = new IndexCollectionChangedEventArgs(_iDraggedIndex, _iDroppedIndex);
                    this.OnIndexCollectionChanged(e);
                }
                else
                {
                    IndexCollectionAddEventArgs e = new IndexCollectionAddEventArgs(i1);
                    this.OnIndexCollectionAdd(e);
                }
            }
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
                if (!myRuler.Enabled)
                {
                    return false;
                }

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
                        myRuler.UpdateIndexes(index);
                    }
                }

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
                        myRuler.UpdateIndexes(myRuler._iDroppedIndex);
                    }

                    myRuler._bDragged = false;
                    myRuler._bDrawMark = true;
                    myRuler._iMouseDownMousePosition = -1;
                    myRuler._iDraggedIndex = -1;
                    myRuler._iDroppedIndex = -1;
                }

                if (m.Msg == (int)Msg.WM_NCLBUTTONUP)
                {
                    myRuler._bDragged = false;
                    myRuler._bDrawMark = true;
                    myRuler._iMouseDownMousePosition = -1;
                    myRuler._iDraggedIndex = -1;
                    myRuler._iDroppedIndex = -1;
                }
            }
            catch { }

            return false;  // Whether or not the message is filtered
        }
    }

    internal enum Msg
    {
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x201,
        WM_LBUTTONUP = 0x202,
        WM_MOUSELEAVE = 0x02A3,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_NCLBUTTONUP = 0xA2,
        WM_NCLBUTTONDOWN = 0xA1,
    }

    internal class IndexCollectionChangedEventArgs : EventArgs
    {
        public int oldIndex;
        public int newIndex;
        public IndexCollectionChangedEventArgs(int old_index, int new_index) : base()
        {
            this.oldIndex = old_index;
            this.newIndex = new_index;
        }
    }

    internal class IndexCollectionAddEventArgs : EventArgs
    {
        public int index;
        public IndexCollectionAddEventArgs(int _index) : base()
        {
            this.index = _index;
        }
    }

    internal class IndexCollectionRemoveEventArgs : EventArgs
    {
        public int index;
        public IndexCollectionRemoveEventArgs(int _index) : base()
        {
            this.index = _index;
        }
    }
}
