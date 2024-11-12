using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Svg;
using System.IO;


namespace DirectXForm_2201
{
    /// <summary>
    /// Avoid creating multiple image object
    /// </summary>
    static class csImages
    {
        private static Dictionary<string, Image> ImageCollection = new Dictionary<string, Image>();
        private static Dictionary<string, SvgImage> SvgImageCollection = new Dictionary<string, SvgImage>();

        public static Image FunctionsStatistical32 => GetImage(nameof(FunctionsStatistical32));
        public static Image FunctionsStatistical64 => GetImage(nameof(FunctionsStatistical64));


        public static SvgImage svgTest01 => GetSvgImage(nameof(svgTest01));

        private static Image GetImage(string sPropertyName)
        {
            //Load the image
            if (ImageCollection.ContainsKey(sPropertyName)) return ImageCollection[sPropertyName];

            //Read from resource file
            Image imageObject = null;
            if (sPropertyName == nameof(FunctionsStatistical32))
            {
                var svgImage = Properties.Resources.functionsstatistical;
                imageObject = svgImage.Render(new Size(32, 32), null);
            }
            else if (sPropertyName == nameof(FunctionsStatistical64))
            {
                var svgImage = Properties.Resources.functionsstatistical;
                imageObject = svgImage.Render(new Size(64, 64), null);
            }

            if (imageObject == null) return null;

            ImageCollection.Add(sPropertyName, imageObject);
            return imageObject;
        }


        private static SvgImage GetSvgImage(string sPropertyName)
        {
            //Load the image
            if (SvgImageCollection.ContainsKey(sPropertyName)) return SvgImageCollection[sPropertyName];

            ////Read from resource file
            SvgImage imageObject = null;
            //if (sPropertyName == nameof(svgTest01)) imageObject = Properties.Resources.stop;
            //else if (sPropertyName == nameof(svgTest01))
            //{
            //    using (MemoryStream stream = new MemoryStream(Properties.Resources.curvedconnector1))
            //    {
            //        imageObject = SvgImage.FromStream(stream);
            //    }
            //}

            if (imageObject == null) return null;
            SvgImageCollection.Add(sPropertyName, imageObject);
            return imageObject;
        }


    }
}
