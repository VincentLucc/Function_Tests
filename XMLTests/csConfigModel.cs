using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLTests;

public class csConfigModel
{
    public int iValue1 { get; set; }
    public string sValue1 => "Value won't be serialized";

    private string _sValue2;

    [XmlIgnore]
    public Color ColorTest
    {
        get => Color.FromArgb(ColorArgb);
        set => ColorArgb = value.ToArgb();
    }
 
    public int ColorArgb
    {
        get => ColorTest.ToArgb();
        set => ColorTest = Color.FromArgb(value);
    }

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

    public types typeValue1 { get; set; }
    public types typeValue2 { get; set; }
    public types typeValue3 { get; set; }


    public _type1 TestType1 { get; set; }
    public _type2 TestType2 { get; set; }

    public subClass SubItem { get; set; }

    public ParentClass ParentItem { get; set; }

    public csConfigModel()
    {
        iValue1 = 1;
        //直接存值： <TestType1>AB CD</TestType1>
        TestType1 = _type1.AB | _type1.CD;
        //存取替代值： <TestType2>1 2</TestType2>
        TestType2 = _type2.AB | _type2.CD;
        typeValue1 = types.type1;
        typeValue2 = types.type2;
        typeValue3 = types.type3;

        SubItem = new subClass();
        ParentItem = new ParentClass();
    }
}

public class subClass
{
    public string StringA { get; set; }

    public string StringB { get; set; }

    public subClass()
    {
        StringA = "a";
        StringB = "b";
    }
}

[Flags]
public enum _type1
{
    AB = 0b00000001,
    CD = 0b00000010,
    EF = 0b00000100,
}

[Flags]
public enum _type2
{
    [XmlEnum("1")]
    AB = 0b00000001,
    [XmlEnum("2")]
    CD = 0b00000010,
    [XmlEnum("3")]
    EF = 0b00000100,
}

public enum types
{
    [XmlEnum(Name = "1")]
    type1,
    [XmlEnum("2")]
    type2,
    //Value won't change, will store "type3"
    type3 = 100,
}
