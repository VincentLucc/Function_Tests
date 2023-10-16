using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenCV_Sharp4
{
    [XmlRoot("Inspection")]
    public class cvInspection
    {
        [XmlIgnore]
        public Mat sourceImage { get; set; }
        public int Rotate { get; set; }

        public cvInspection()
        {

        }
        public void SetSourceImage(Mat input)
        {
            if (sourceImage != null)
            {
                sourceImage.Dispose();
                sourceImage = null;
            }
            sourceImage = input.Clone();
        }
    }
}
