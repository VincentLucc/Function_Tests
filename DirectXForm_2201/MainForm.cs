using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;
using System.Drawing.Drawing2D;

namespace DirectXForm_2201
{
    public partial class MainForm : DevExpress.XtraEditors.DirectXForm
    {
        csFPSHelper fpsHelper;
        Stopwatch watch = new Stopwatch();

        public MainForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            this.Load += MainForm_Load;
            var diagramHelper = new DiagramHelper(diagramControl1);
            diagramControl1.CustomDrawItem += DiagramControl1_CustomDrawItem;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {

            //FPS
            fpsHelper = new csFPSHelper(2000, 5000);

            timer1.Interval = 10;
            timer1.Start();

            Thread t1 = new Thread(ProcessPosition);
            t1.Start();
        }

        private void DiagramControl1_CustomDrawItem(object sender, DevExpress.XtraDiagram.CustomDrawItemEventArgs e)
        {
            if (e.Item is csItem1)
            {
                (e.Item as csItem1).Draw(e);
            }
        }

        PointFloat position = new PointFloat();
        private void ProcessPosition()
        {
            //根据图像中不共线的 3 个点在变换前后的对应位置坐标
            List<Point2f> pointSource = new List<Point2f>() { new Point2f(0, 0), new Point2f(10, 20), new Point2f(20, 10) };
            List<Point2f> pointDestination = new List<Point2f>() { new Point2f(10, 0), new Point2f(20, 20), new Point2f(30, 10) };


            //Mat mappingMatrix = Cv2.GetAffineTransform(pointSource, pointDestination);

 
            ////Get affine 
            //List<Point2f> pointsStart = new List<Point2f> { new Point2f(200, 200) };

            //Point2f pointStart=new Point2f(200,200);
            //var abc=new Mat(pointsStart);

            Matrix matrix = new Matrix();
            matrix.Translate(200, 200);
            var centerPoint = new PointF(100, 100);

            //matrix.Scale(1, 2, MatrixOrder.Append);
            //matrix.Translate(5, 0, MatrixOrder.Append);


            while (!this.Disposing && !this.IsDisposed)
            {
                //for (int i = 0; i < 200; i++)
                //{
                //    for (int j = 0; j < 200; j++)
                //    {
                //        position = new PointFloat(i, j);
                //        Thread.Sleep(1);
                //    }
                //}

                //for (float i = 0; i < 360; i += 0.1f)
                //{
                //    //var mapping = Cv2.GetRotationMatrix2D(new Point2f(100, 100), i, 1);
                //    //var resultPoint = (mapping * abc).ToMat().ToPointF();
                //    //var resultPoints = Cv2.PerspectiveTransform(pointsStart, mapping);
                //    //position = new PointFloat(resultPoints[0].X, resultPoints[0].Y);


                //}

                matrix.RotateAt(1, centerPoint);
                //Must be the same
                var startPoints = new PointF[] { new PointF(0, 0) };
                matrix.TransformPoints(startPoints);
                position = new PointFloat(startPoints[0].X, startPoints[0].Y);
                Thread.Sleep(10);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                watch.Restart();

                var items = diagramControl1.Items;

                if (items.Count > 0)
                {
                    var item = items[0].Position = position;
                }

                diagramControl1.Refresh();
                fpsHelper.AddRecord(watch.Elapsed);

                FPSStaticItem.Caption = $"FPS:{fpsHelper.GetFPS().ToString("f1")}";
                DurationButtonItem.Caption = $"Duration:[Avg:{fpsHelper.GetAverageDuration().ToString("f1")}, Max:{fpsHelper.GetMaxDuration().ToString("f1")}]";
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"timer1_Tick:{ex.Message}");
            }
            finally
            {
                timer1.Enabled = true;
            }
        }
    }
}
