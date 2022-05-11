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

        private void PPaint_Paint(object sender, PaintEventArgs e)
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
                        e.Graphics.CopyFromScreen(0, 0, 0, 0, pPaint.Size);
                        break;

                    case DrawCommand.Arc:
                        //Will be reset next time event triggers, make sure to maintain same transformation when in same event
                        e.Graphics.TranslateTransform(100, 100);
                        var rect = new Rectangle(0, 0, 5, 5);
                        e.Graphics.DrawArc(pen, rect, 0, 165);
                        break;

                    case DrawCommand.Ellipse:
                        e.Graphics.TranslateTransform(100, 100);
                        var rect1 = new Rectangle(0, 0, 100, 20);
                        e.Graphics.DrawEllipse(pen, rect1);
                        e.Graphics.TranslateTransform(0, 100);
                        rect1 = new Rectangle(0, 0, 100, 100);
                        e.Graphics.DrawEllipse(pen, rect1);
                        break;

                    case DrawCommand.Coupler:
                        e.Graphics.TranslateTransform(100, 100);
                        var couplerDefault = Properties.Resources.chip_encoding_module_1;
                        var couplerBusy = Properties.Resources.Coupler_Encoding;
                        var couplerDisabled = Properties.Resources.Coupler_Disabled;
                        var productGreen = Properties.Resources.Product_Green;
                        var productRed = Properties.Resources.Product_Red;
                        var size = couplerDefault.Size;
                        //Draw empty
                        e.Graphics.DrawImage(couplerDefault, 50f, 0f, size.Width, size.Height);
                        //Draw disabled
                        e.Graphics.DrawImage(couplerDisabled, 150f, 0f, size.Width, size.Height);
                        //Draw green
                        e.Graphics.DrawImage(couplerDefault, 50f, 50f, size.Width, size.Height);
                        e.Graphics.DrawImage(productGreen, 50f, 50f, size.Width, size.Height);                        
                        //Draw busy
                        e.Graphics.DrawImage(couplerBusy, 50f, 100f, size.Width, size.Height);
                        e.Graphics.DrawImage(productGreen, 50f, 100f, size.Width, size.Height);
                        //draw disabled
                        e.Graphics.DrawImage(couplerDisabled, 50f, 150f, size.Width, size.Height);
                        e.Graphics.DrawImage(productRed, 50f, 150f, size.Width, size.Height);
                        break;

                    case DrawCommand.CouplerV2:
                        e.Graphics.TranslateTransform(100, 100);
                        var couplerDefaultV2 = Properties.Resources.chip_encoding_module_1;
                        var couplerBusyV2 = Properties.Resources.Coupler_EncodingV2;
                        var couplerDisabledV2 = Properties.Resources.Coupler_DisabledV2;
                        var size2 = couplerDefaultV2.Size;
                        var productLength = 32f;
                        var productStartOffset = size2.Width / 2f - productLength / 2f;
                        var productEndOffset= size2.Width / 2f + productLength / 2f;
                        var productYOffset = size2.Height/2f;


                        //Draw empty
                        e.Graphics.DrawImage(couplerDefaultV2, 50f, 0f, size2.Width, size2.Height);
                        //Draw disabled
                        e.Graphics.DrawImage(couplerDisabledV2, 150f, 0f, size2.Width, size2.Height);
                        //Draw green
                        e.Graphics.DrawImage(couplerDefaultV2, 50f, 50f, size2.Width, size2.Height);
                        e.Graphics.DrawLine(csDrawTool.GreenPen16, 50f+ productStartOffset,50f+ productYOffset, 50f + productEndOffset, 50f+ productYOffset);
                        //Draw encoding
                        e.Graphics.DrawImage(couplerBusyV2, 50f, 100f, size2.Width, size2.Height);
                        e.Graphics.DrawLine(csDrawTool.RedPen16, 50f + productStartOffset, 100f + productYOffset, 50f + productEndOffset, 100f + productYOffset);
                        //Draw disable
                        e.Graphics.DrawImage(couplerDisabledV2, 50f, 150f, size2.Width, size2.Height);
                        e.Graphics.DrawLine(csDrawTool.RedPen16, 50f + productStartOffset, 150f + productYOffset, 50f + productEndOffset, 150f + productYOffset);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("PPaint_Paint:\r\n" + ex.Message);
            }
        }

      

        private void DrawCross(PaintEventArgs e, Pen pen, int iRadius = 3)
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
            form.Show();
            //form.Close();//Must close to make sure timer exit
        }

        private void bCoupler_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.Coupler;
            pPaint.Refresh(); //Redraw
        }

        private void bCoupler2_Click(object sender, EventArgs e)
        {
            drawType = DrawCommand.CouplerV2;
            pPaint.Refresh(); //Redraw
        }
    }
}
