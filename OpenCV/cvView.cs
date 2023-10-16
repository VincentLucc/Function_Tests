using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Sharp4
{
    public class cvView
    {
        public Mat viewImage;

        public List<Point> Marks;

        public cvView()
        {
            Marks=new List<Point>();
        }

        public void SetViewImage(Mat inputImage)
        {
            if (inputImage == null) return;

            if (viewImage != null)
            {
                viewImage.Dispose();
                viewImage = null;
            }
            viewImage = inputImage.Clone();
        }

        public void AddMarks(int iX, int iY)
        {
           Marks.Add(new Point(iX, iY));
        }

        public void AddMarks(double dX, double dY)
        {
            Marks.Add(new Point(dX, dY));
        }

    }

 
}
