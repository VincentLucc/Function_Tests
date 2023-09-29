using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test001
{
    /// <summary>
    /// First 20 lines of the data file
    /// </summary>
    public class csFileData
    {
        public string JobInfoHeader { get; set; }
        public string JobInfoData { get; set; }
        /// <summary>
        /// Line represent the data row header
        /// </summary>
        public string DataHeader { get; set; }
        /// <summary>
        /// Include only data lines
        /// </summary>
        public List<string> DataLines { get; set; }
        /// <summary>
        /// Include all lines (First 20 lines)
        /// </summary>
        public List<string> AllLines { get; set; }

        /// <summary>
        /// Store keys for unique key check
        /// </summary>
        public HashSet<string> Key1s { get; set; }
        public HashSet<string> Key2s { get; set; }
        public HashSet<string> Key3s { get; set; }
        /// <summary>
        /// Unique product ID check
        /// Used only in Predefined || DynamicAllocation mode
        /// </summary>
        public HashSet<string> ProdValues { get; set; }

        public csFileData()
        {
            DataLines = new List<string>();
            AllLines = new List<string>();
            Key1s = new HashSet<string>();
            Key2s = new HashSet<string>();
            Key3s = new HashSet<string>();
            ProdValues = new HashSet<string>();
        }

        public void ClearAll()
        {
            AllLines?.Clear();
            Clear();
        }

        /// <summary>
        /// Clear user setting related data
        /// </summary>
        public void Clear()
        {
            JobInfoHeader = null;
            JobInfoData = null;
            DataHeader = null;
            DataLines?.Clear();
            Key1s?.Clear();
            Key2s?.Clear();
            Key3s?.Clear();
            ProdValues?.Clear();
        }
    }
}
