using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _CommonCode_Framework
{
    public class csGeoInfo
    {

    }

    /// <summary>
    /// Leave value gap for possible changes
    /// </summary>
    public enum _CAProvince
    {
        [XmlEnum("0"), Description("Alberta")]
        Alberta = 0,
        [XmlEnum("10"), Description("British Columbia")]
        BritishColumbia = 10,
        [XmlEnum("20"), Description("Manitoba")]
        Manitoba = 20,
        [XmlEnum("30"), Description("New Brunswick")]
        NewBrunswick = 30,
        [XmlEnum("40"), Description("Newfoundland and Labrador")]
        NewfoundlandAndLabrador = 40,
        [XmlEnum("50"), Description("Nova Scotia")]
        NovaScotia = 50,
        [XmlEnum("60"), Description("Ontario")]
        Ontario = 60,
        [XmlEnum("70"), Description("Prince Edward Island")]
        PrinceEdwardIsland = 70,
        [XmlEnum("80"), Description("Quebec")]
        Quebec = 80,
        [XmlEnum("90"), Description("Saskatchewan")]
        Saskatchewan = 90
    }


}
