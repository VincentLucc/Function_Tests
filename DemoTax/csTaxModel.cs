using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DemoTax
{
    public class TaxBracket
    {
        public double Margin { get; set; }
        public double Rate { get; set; }

        public TaxBracket(double margin, double rate)
        {
            Margin=margin; 
            Rate= rate;
        }
    }

    public class csPrivintialBracket
    {
        public _CanadaProvince Province { get; set; } = _CanadaProvince.ON;
        public List<TaxBracket> Brackets { get; set; } = new List<TaxBracket>();
    }

    [XmlType("TaxYearSettings")]
    public class csTaxYearSettings
    {

        public int TaxYear { get; set; }
        public List<TaxBracket> FederalBrackets { get; set; } = new List<TaxBracket>();

        public List<csPrivintialBracket> ProvincialBrackets { get; set; } = new List<csPrivintialBracket>();
    }


}
