using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenCV_Sharp4
{
    [XmlType("BarCode")]
    public class cvBarCode : csTool
    {
        public void Inspect(cvInspection inspection)
        {
            if (!Enable) return;

            try
            {
                var barcodeReader = new ZXing.OpenCV.BarcodeReader();

                barcodeReader.AutoRotate = true;
                barcodeReader.Options.TryHarder = true;
                var codeResults = barcodeReader.Decode(inspection.sourceImage);

                if (codeResults == null) return;
                Debug.WriteLine($"{codeResults.BarcodeFormat}:{codeResults.Text}");

                //Show result points
                foreach (var item in codeResults.ResultPoints)
                {
                    inspection.View.AddMarks(item.X, item.Y);
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine("BarCode.Inspect:\r\n" + ex.Message);
            }

        }
    }
}
