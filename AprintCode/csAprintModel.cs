using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprintCode
{
    class csAprintModel
    {

    }

    public class InkInfo
    {
        /// <summary>
        /// 1L = 1,000,000,000,000 pL
        /// </summary>
        public const int VolumeRatio = 1000000000;

        public string InkType { get; set; }
        public string HeadType { get; set; }

        /// <summary>
        /// 64bits volume
        /// </summary>
        public UInt64 VolumeRaw { get; set; }
        public UInt64 VolumeML => VolumeRaw / VolumeRatio;
        public UInt32 DongleID { get; set; }

        public void Clear()
        {
            InkType = "";
            HeadType = "";
            VolumeRaw = 0;
            DongleID = 0;
        }
    }
}
