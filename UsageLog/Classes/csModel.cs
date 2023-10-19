using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UsageLog
{
    /// <summary>
    /// Easier to save in the database
    /// </summary>
    public class csRecord
    {
        /// <summary>
        /// ID of each record
        /// Use Datetime.Tick value
        /// 10K ticks in 1 milliseconds
        /// </summary>
        [Browsable(false)]
        public long UniqueID { get; set; }
        /// <summary>
        /// ID of the parent record, -1 means root record
        /// </summary>
        public long ParentID { get; set; }

        /// <summary>
        /// If con
        /// </summary>
        public string Catagory { get; set; }
        public string Description { get; set; }

        public double Value { get; set; }

        [Browsable(false)]
        public _recordType RecordType { get; set; }

        /// <summary>
        /// When is this event happens
        /// </summary>
        public DateTimeOffset Time { get; set; }
    }


    public enum _recordType
    {
        [XmlEnum(Name = "0")]
        Catagory = 0,
        [XmlEnum(Name = "1")]
        Item = 1,
    }

}
