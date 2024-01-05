using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera_Parameters
{
    public class csResolution
    {
        public int X { get; set; }
        public int Y { get; set; }

        public long Pixels => (long)X * (long)Y;
        public string Description { get; set; }

        private static List<csResolution> _resolutionOptions;
        public static List<csResolution> ResolutionOptions => GetResolutionOptions();

        public csResolution()
        {

        }
        public csResolution(int _x, int _y, string _description = null)
        {
            X = _x;
            Y = _y;
            Description = _description;
        }

        private static List<csResolution> GetResolutionOptions()
        {
            if (_resolutionOptions != null) return _resolutionOptions;

            //Prepare values
            var resolutionList = new List<csResolution>()
            {
                new csResolution(320,240,"QVGA"),
                new csResolution(480,272,"WQVGA"),
                new csResolution(640,480,"480P"),
                new csResolution(1280,720,"720P/HD"),
                new csResolution(1280,1024,"SXGA"),
                new csResolution(1440,900,"WXGA+/WSXGA"),
                new csResolution(1440,1080,""),
                new csResolution(1600,900,"900P/HD+"),
                new csResolution(1600,1200,"UXGA"),
                new csResolution(1920,1080,"1080P/FHD"),
                new csResolution(1920,1200,"WUXGA"),
                new csResolution(3840,2160,"UHD 4K"),
                new csResolution(7680,4320,"UHD 8K"),
                new csResolution(10240,4320,"UHD 10K"),
            };

            return resolutionList;
        }


    }
}
