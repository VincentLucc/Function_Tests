using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using _CommonCode_Framework;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using HalconDotNet;
using Newtonsoft.Json;
using Property_RegEditor_22._1;


namespace HalconTest
{


    [XmlType("SearchRegionSettings")]
    public class csSearchRegionSettings
    {
 
        public string Description { get; set; }


        [DisplayName("Enable Free Region")]
        public bool FreeRegionEnable { get; set; }


        [Browsable(false)]
        public HObject FreeRegionData;


        /// <summary>
        /// Local search region
        /// </summary>
        [Browsable(false)]
        public Rectangle2Data LocalRegion { get; set; }



        /// <summary>
        /// The image reducing is time-consuming
        /// Use this flag to avoid performance impact in certain tools
        /// </summary>
        ///
        [Browsable(false)]
        [XmlIgnore, JsonIgnore]
        public bool DisableImageReduceAction { get; set; }

        [XmlIgnore, JsonIgnore]
        public csHalconWindow ParentWindow;

        public csSearchRegionSettings()
        {
            LocalRegion = new Rectangle2Data();

        }



        public void InitEnvironment(csHalconWindow window)
        {
            ParentWindow = window;
        }





        public string GetRegionDefinitionDisplay()
        {
            if (FreeRegionEnable)
            {
                return "Free Region";
            }
            else
            {
                return "Local Region";
            }
        }

       






 

    







  
        public string GetValidDescription(int iRegion)
        {
            if (string.IsNullOrWhiteSpace(Description))
            {
                return $"Region_{iRegion}";
            }
            else
            {
                return Description;
            }
        }
    }



}
