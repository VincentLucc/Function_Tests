using DevExpress.Skins.Info;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkiaSharp
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Normal Skia control
            SkiaControl1.PaintSurface += SkiaControl1_PaintSurface;
            //Skia with open gl
            SkiaGLControl.PaintSurface += SkiaGLControl_PaintSurface;
        }

        private void DrawOnCanvas(SKCanvas canvas)
        {
            //Var color
            var blueColor = new SKColor(1, 1, 255);

            //Var linepaint
            var linePaint = new SKPaint()
            {
                Color = blueColor,
                StrokeWidth = 1,
                IsAntialias = false,
                Style = SKPaintStyle.Stroke
            };

            //Start to draw
            for (int i = 0; i < SkiaPictureBox.Height; i++)
            {
                if (i % 2 == 1) continue;
                canvas.DrawLine(0, i, SkiaPictureBox.Width, i, linePaint);
            }
        }

        private void SkiaGLControl_PaintSurface(object sender, Views.Desktop.SKPaintGLSurfaceEventArgs e)
        {
            //Init
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            DrawOnCanvas(canvas);
        }

        private void SkiaControl1_PaintSurface(object sender, Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            //Init
            var canvas = e.Surface.Canvas;
            canvas.Clear();
 
            DrawOnCanvas(canvas);

        }

        private void bDrawSkia_Click(object sender, EventArgs e)
        {
            //Init
            var imageInfo = new SKImageInfo(SkiaPictureBox.Width, SkiaPictureBox.Height);
            var surface = SKSurface.Create(imageInfo);
            var canvas = surface.Canvas;

            DrawOnCanvas(canvas);

            //Display
            using (SKImage skImage = surface.Snapshot())
            {
                using (MemoryStream stream = new MemoryStream(skImage.Encode().ToArray()))
                {
                    SkiaPictureBox.Image?.Dispose();
                    SkiaPictureBox.Image = new Bitmap(stream);
                }
            }
        }
    }
}
