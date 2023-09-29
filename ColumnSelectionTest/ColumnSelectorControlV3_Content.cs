using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
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
        /// This is the child control class that displays the content of sample text/csv file
        /// </summary>
        public class myContentControl : RichEditControl
        {

  
            private ColumnSelectorControlV3 ParentControl;

            internal Pen penMyMarker = Pens.Gray;

            public myContentControl(ColumnSelectorControlV3 p)
            {

                if (p != null) ParentControl = p;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.CacheText, true); //Increase performance
                //this.AutoScrollOffset = ScrollableControl.
                base.BackColor = SystemColors.Control;
                base.ForeColor = Color.Black;
                this.Dock = DockStyle.Left;
                base.Font = new Font("Consolas", ParentControl.FontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.Location = new Point(0, 26);
                this.Padding = new Padding(0, 0, 0, 0);
                this.Name = "myContent";
                this.Size = new Size(1, 1);
 

                //Hide the buildin ruler
                Options.VerticalScrollbar.Visibility = RichEditScrollbarVisibility.Hidden;
                Options.HorizontalRuler.Visibility = RichEditRulerVisibility.Hidden;
                Options.VerticalRuler.Visibility = RichEditRulerVisibility.Hidden;

                //Draft mode
                ActiveViewType = RichEditViewType.Simple;
                //Clean all indents
                (this.ActiveView as SimpleView).Padding = new Padding(0,0,0,0);

                //Disable right click menu
                Options.Behavior.ShowPopupMenu = DocumentCapability.Disabled;

                //Draw text selection rectangle
                CustomDrawActiveView += MyContentControl_CustomDrawActiveView;
            }
 
            /// <summary>
            /// Remove all selection
            /// </summary>
            public void ClearDrawPoint()
            {
                ParentControl.Selections.Clear();
                this.Invalidate(); //Redraw content area
                ParentControl.myRuler.Refresh(); //re-draw ruler, must refresh to be effected
            }

            private void MyContentControl_CustomDrawActiveView(object sender, RichEditViewCustomDrawEventArgs e)
            {
                if (ParentControl == null) return;

                int charWidth = ParentControl.iCharWidth;
                int LeftOffset = ParentControl.iCharWidth / 2 - 1;

                int count = ParentControl.Selections.Count;

                if (count == 0 && count > 2) return;
                //Range selected
                if (count == 2)
                {
                    int iStart = ParentControl.Selections.Min();
                    int iEnd = ParentControl.Selections.Max();
                    //Get actual draw position
                    DrawSelection(e, iStart, iEnd);
                }
            }


            private void DrawSelection(RichEditViewCustomDrawEventArgs e, int iStart, int iEnd)
            {
                var posStart = Document.CreatePosition(iStart);
                var posEnd = Document.CreatePosition(iEnd + 1);
                var boundryStart = GetLayoutPhysicalBoundsFromPosition(posStart);
                var boundryEnd = GetLayoutPhysicalBoundsFromPosition(posEnd);
                int iXStart = boundryStart.X;
                int iYStart = boundryStart.Y;
                int iWidth = Math.Abs(boundryEnd.X - boundryStart.X);
                int iHeight = 2000;
                var rect = new Rectangle(iXStart, iYStart, iWidth, iHeight);
                var color = Color.FromArgb(32, Color.Red);//Set to transparent color
                e.Cache.FillRectangle(color, rect);
            }
        }

    }
}
