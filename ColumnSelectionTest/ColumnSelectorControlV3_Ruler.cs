using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test001
{
    public partial class ColumnSelectorControlV3
    {
        /// <summary>
        /// This is the child control on top, with ruler and selection markings
        /// </summary>
        class myRulerControl : Control
        {
            public ColumnSelectorControlV3 myParentControl;

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

            public myRulerControl(ColumnSelectorControlV3 p)
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
                var indexlist = myParentControl.Selections;

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
                var indexlist = myParentControl.Selections;

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
                var indexlist = myParentControl.Selections;
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
                            foreach (int i in myParentControl.Selections)
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
    }
}
