using IronBarCode;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZXing;

namespace OpenCV_Sharp4
{
    [XmlType("BarCode")]
    public class cvBarCode : csTool
    {
        public void Inspect(cvInspection inspection)
        {
            if (!Enable) return;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                var barcodeReader = new ZXing.OpenCV.BarcodeReader();
                //Read from different direction
                barcodeReader.AutoRotate = true;
                //Increase readability (Still bad, increase 200 ms processing time)
                barcodeReader.Options.TryHarder = true;
                //var blurImage= inspection.sourceImage.Clone();
                //Cv2.GaussianBlur(inspection.sourceImage, blurImage, new Size(3,3),0);
                //var bilateralImage = blurImage.Clone();
                //Cv2.BilateralFilter(blurImage, bilateralImage, 3,10,10);
                //inspection.View.SetViewImage(bilateralImage);

                var codeResults = barcodeReader.Decode(inspection.sourceImage);

                if (codeResults == null)
                {
                    watch.Stop();
                    Debug.WriteLine($"Barcode: No Read, {watch.ElapsedMilliseconds} ms.");
                    return;
                }
                Debug.WriteLine($"{codeResults.BarcodeFormat}({watch.ElapsedMilliseconds}ms):{codeResults.Text}");

                //Show result points
                foreach (var item in codeResults.ResultPoints)
                {
                    inspection.View.AddMarks(item.X, item.Y);
                }

            }
            catch (Exception ex)
            {
                watch.Stop();
                Debug.WriteLine($"BarCode.Exception ({watch.ElapsedMilliseconds}ms):\r\n" + ex.Message);
            }

        }

        public void InspectIronBarCode(cvInspection inspection)
        {
            if (!Enable) return;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                var bitMap = BitmapConverter.ToBitmap(inspection.sourceImage);
                var codeResults = IronBarCode.BarcodeReader.Read(bitMap);


                if (codeResults == null || codeResults.Count() == 0)
                {
                    watch.Stop();
                    Debug.WriteLine($"Barcode: No Read, {watch.ElapsedMilliseconds} ms.");
                    return;
                }

                var firstResult = codeResults.FirstOrDefault();
    
                Debug.WriteLine($"{firstResult.BarcodeType}({watch.ElapsedMilliseconds}ms):{firstResult.Text}");

                ////Show result points
                //foreach (var item in codeResults.ResultPoints)
                //{
                //    inspection.View.AddMarks(item.X, item.Y);
                //}

            }
            catch (Exception ex)
            {
                watch.Stop();
                Debug.WriteLine($"BarCode.Exception ({watch.ElapsedMilliseconds}ms):\r\n" + ex.Message);
            }

        }
    }
}
