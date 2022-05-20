using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoading
{
    public class WriteData
    {
        public List<byte[]> DataList { get; set; }
        public List<long> IndexList { get; set; }
        public long FullLength { get; set; }


        public WriteData()
        {
            DataList = new List<byte[]>();
            IndexList = new List<long>();
        }

    }

    public class LoadInfo
    {
        
    }
}
