using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OpenCV_Sharp4
{
    [XmlRoot("Inspection")]
    public class cvInspection
    {
        [XmlIgnore]
        public Mat sourceImage { get; set; }
        public int Rotate { get; set; }

        [XmlIgnore]
        public cvView View { get; set; }

        public cvBarCode Barcode { get; set; }

        public cvInspection()
        {
            Barcode = new cvBarCode();
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

        public void RunProduction(Mat image)
        {
            View = new cvView();

            //Load main image
            if (image == null)
            {
                if (sourceImage == null) return;
                View.SetViewImage(sourceImage);
            }
            else
            {
                View.SetViewImage(image);
            }


 

            Barcode.Inspect(this);
            Barcode.InspectIronBarCode(this);
        }

    }
}
