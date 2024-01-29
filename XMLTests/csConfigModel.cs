using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class csConfigModel
{
    public int iValue1 { get; set; }
    public string sValue1 => "Value won't be serialized";

    private string _sValue2;
    public string sValue2 
    { 
        get { return "Test01"; }
        //Must have set method to save to xml properly
        set { _sValue2 = value; } 
    }

 
    public string sValue3
    {
        get { return "Value3"; }
        set { }//Empty "set" makes sure the property will be serialized 
    }

    public csConfigModel() 
    {
        iValue1 = 1;
    }
}
