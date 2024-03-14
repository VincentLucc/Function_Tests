using DevExpress.Skins;
using DevExpress.Utils.DirectXPaint.Svg;
using SkiaSharp;
using SkiaSharp.Extended.Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Svg;

namespace ImageEdit
{
    public static class csImages
    {

        public static Dictionary<string, Image> ImageCollection = new Dictionary<string, Image>();
        public static Image About => GetImage(nameof(About));

        public static Image DemoSVG32 => GetImage(nameof(DemoSVG32));
        public static Image DemoSVG64 => GetImage(nameof(DemoSVG64));

        public enum _imageType
        {
            ResourceImage,
            SVGImage32
        }
        public static Image GetImage(string sPropertyName)
        {
            if (ImageCollection.ContainsKey(sPropertyName))
            {
                return ImageCollection[sPropertyName];
            }

            if (sPropertyName == nameof(About))
            {
                ImageCollection.Add(sPropertyName, Properties.Resources.About_32x32);
                return ImageCollection[sPropertyName];
            }
            else if (sPropertyName == nameof(DemoSVG32))
            {
                var svg = new SkiaSharp.Extended.Svg.SKSvg();
                using (MemoryStream stream = new MemoryStream(Properties.Resources.demo_01))
                {
                    svg.Load(stream);
                }

                // Optional: Apply any transformations if needed
                var matrix = SKMatrix.CreateScale(1, 1);

                //To SKImage
                SKImage skImage = SKImage.FromPicture(svg.Picture, new SKSizeI(32, 32), matrix);

                //Get image data
                var skData = skImage.Encode(SKEncodedImageFormat.Png, 100);
                using (var stream = skData.AsStream())
                {

                    ImageCollection.Add(sPropertyName, Image.FromStream(stream));
                    return ImageCollection[sPropertyName];
                }
            }
            else if (sPropertyName == nameof(DemoSVG64))
            {

                using (Stream stream = new MemoryStream(Properties.Resources.demo_01))
                {
                    SvgDocument svgDocument = SvgDocument.Open<SvgDocument>(stream);
                    var image = svgDocument.Draw(64, 64);
                    ImageCollection.Add(sPropertyName, image);
                    return ImageCollection[sPropertyName];
                }

            }


            return null;
        }
    }
}
