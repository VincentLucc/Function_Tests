using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebClient
{
    public class csConfigModel
    {

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gap of each attempt in second
        /// </summary>
        public int CheckInverval { get; set; }

        public BindingList<csGTINConfig> GTINs { get; set; }

        public csConfigModel()
        {
            GTINs = new BindingList<csGTINConfig>();
        }
    }

    [XmlType("GTIN")]
    public class csGTINConfig
    {
        public string Description { get; set; }

        /// <summary>
        /// Number of gtin
        /// </summary>
        public string GTIN { get; set; }

        /// <summary>
        /// Automatic receive the GTIN
        /// </summary>
        public bool AutoFetch { get; set; }

        /// <summary>
        /// Number of the code for each request
        /// </summary>
        [Browsable(false)]
        public int NumberPerRequest { get; set; }
        /// <summary>
        /// Number of the code to request
        /// </summary>
        
        public int NumberOfCodes { get; set; }

        /// <summary>
        /// Memory usage only
        /// </summary>
        [XmlIgnore]
        public _codeStatus Status { get; set; }

        [XmlIgnore, Browsable(false)]
        public DateTime LastAttempt { get; set; }
    }

    public enum _codeStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Standby = 0,
        Requested = 1,
        Received = 2,
        Recorded = 3
    }

}
