using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class csConfigModel
{
    public int iValue1 { get; set; }
    public string sValue1 { get; set; }

    private string _sValue2;
    public string sValue2 
    { 
        get { return "Test01"; }
        //Must have set method to save to xml properly
        set { _sValue2 = value; } 
    }

    public csConfigModel() 
    {
        iValue1 = 1;
        sValue1 = "s1";
    }
}
