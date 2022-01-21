using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemDraw
{
    public partial class Form1 : Form
    {
        public DrawCommand drawType { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pPaint.Paint += PPaint_Paint;
            
        }

        private async void PPaint_Paint(object sender, PaintEventArgs e)
        {
            //Get current pen
            var pen = csDrawTool.RedPenThin;
            try
            {
                switch (drawType)
                {
                    case DrawCommand.Null:
                        e.Graphics.TranslateTransform(100, 100);
                        DrawCross(e, pen, 10);
                        e.Graphics.TranslateTransform(100, 0); //Shift to right 100, thi is vector
                        DrawCross(e, pen, 10);

                        //Draw path
                        e.Graphics.TranslateTransform(50, 0);
                        GraphicsPath graphPath = new GraphicsPath();     // Create graphics path object and add ellipse.
                        int iRadius = 3;
                        graphPath.AddLine(iRadius, iRadius, -iRadius, -iRadius);
                        graphPath.AddLine(iRadius, -iRadius, -iRadius, iRadius);
                        e.Graphics.DrawPath(pen, graphPath);
                        break;

                    case DrawCommand.GraphicsContainer:
                        GraphicsContainer containerState = e.Graphics.BeginContainer();
                        e.Graphics.TranslateTransform(200, 200);
                        DrawCross(e, pen, 10);
                        Thread.Sleep(2000);
                        e.Graphics.EndContainer(containerState);
                        break;

                    case DrawCommand.Clear:
                        e.Graphics.Clear(pPaint.BackColor);//Clear all drawing
                        break;

                    case DrawCommand.ScreenShot:
                        e.Graphics.CopyFromScreen(0, 0, 0, 0,pPaint.Size);
                        break;

                    case DrawCommand.Arc:
                        //Will be reset next time event triggers, make sure to maintain same transformation when in same event
                        e.Graphics.TranslateTransform(100, 100); 
                        var rect = new Rectangle(0, 0, 100, 20);
                        e.Graphics.DrawArc(pen,rect,0,165);
                        break;

                    case DrawCommand.Ellipse:
                        e.Graphics.TranslateTransform(100, 100);
                        var rect1 = new Rectangle(0, 0, 100, 20);
                        e.Graphics.DrawEllipse(pen,rect1);
                        e.Graphics.TranslateTransform(0, 100);
                        rect1 = new Rectangle(0, 0, 100, 100);
                        e.Graphics.DrawEllipse(pen, rect1);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("PPaint_Paint:\r\n"+ex.Message);
            }
        
            
           
        }

        private void DrawCross(PaintEventArgs e, Pen pen, int iRadius=3)
        {
            e.Graphics.DrawLine(pen, iRadius, iRadius, -iRadius, -iRadius);
            e.Graphics.DrawLine(pen, iRadius, -iRadius, -iRadius, iRadius);
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            // Begin graphics container.
            drawType = DrawCommand.GraphicsContainer;
            pPaint.Refresh();

           
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.Clear;
            pPaint.Refresh(); //Redraw
        }

        private void bScreenShot_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.ScreenShot;
            pPaint.Refresh(); //Redraw
        }

        private void bDrawArc_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.Arc;

            pPaint.Refresh(); //Redraw
        }

        private void bDrawEllipse_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.Ellipse;
            pPaint.Refresh(); //Redraw
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNoFlickPanel form = new FormNoFlickPanel();
            form.ShowDialog();
        }
    }
}
