using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid;
using DevExpress.Utils.Serializing;
using System.Drawing.Design;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Mask;

namespace Property_RegEditor_22._1
{
  public  class Student
    {
        [Category("Test")]
        [DisplayName("sName"), Description("Description Method 1 Name of this student.")]
        //Directly use custom editor, Type and base type
        [Editor(typeof(FilteredFileNameEditor),typeof(UITypeEditor))]
        public string Name { get; set; }

        //User to address editor manually
        [CustomEditor(_editorType.Number)]
        [Category("Test")]
        [DisplayName("iAge"), Description("Description Method 2, manual address")]
        public int Age { get; set; }

        [CustomEditor(_editorType.NumberSpin)]
        [Category("Test")]
        [DisplayName("iAge2"), Description("Age")]
        public int Age2 { get; set; }

        //Test text editor regex
        [CustomEditor(_editorType.Text, true, MaskType.RegEx, @"[a-zA-Z]{1,2}[0-9]*")]
        [Category("Test")]
        [DisplayName("Text1 No Mask"), Description("Text editor no mask ")]
        public string Text1Normal { get; set; }

        //Test text editor regex
        [CustomEditor(_editorType.Text,true,MaskType.RegEx, @"[a-zA-Z]{1,2}[0-9]*")]
        [Category("Test")]
        [DisplayName("Text2 Reg Mask"), Description("Text editor with regex mask")]
        public string Text2Reg { get; set; }

        //Test text editor regex
        [CustomEditor(_editorType.Number, "#####0")]
        [Category("Test")]
        [DisplayName("Text3 Numeric Mask"), Description("Text editor with Numeric Mask")]
        public string Text3Num { get; set; }

        [CustomEditor(_editorType.Number,EditMasks.DigitalValue5)]
        [Category("Test")]
        [DisplayName("Text4 Numeric Mask"), Description("Text editor with Numeric Mask")]
        public string Text4Num { get; set; }

        [CustomEditor(_editorType.ButtonEdit)]
        [Category("Test")]
        [DisplayName("Button Edit"), Description("Button Edit General")]
        public string ButtonEditGeneral { get; set; }

        [CustomEditor(_editorType.ButtonEdit)]
        [Category("Test")]
        [DisplayName("Button Edit Class"), Description("Button Edit object define as a class")]
        public Student ButtonEditClass { get; set; }

        [CustomEditor(_editorType.ButtonEditHide)]
        [Category("Test")]
        [DisplayName("Button Edit Hide"), Description("Button Edit Hide")]
        public string ButtonEditHide { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public Certificate Cert { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public CertificateBase Cert2 { get; set; }

        [CustomEditor(_editorType.ToggleSwitch)]
        [Category("Test"), DisplayName("Toggle Switch"), Description("Description Method 2, manual address")]
        public bool ToggleSwitch { get; set; }

        [Category("Test"), DisplayName("Check Box"), Description("Description Method 2, manual address")]
        public bool CheckBox { get; set; }

        /// <summary>
        /// Must be public to be able to display on property
        /// </summary>
        [CustomEditor(_editorType.ToggleSwitchList)]
        [Category("Test"), DisplayName("List"), Description("List Test")]
        [ExpandableRowSettings(false)] //Hide class root editor
    
        public bool[] List { get; set; }

        //Test text editor regex
        [CustomEditor(_editorType.FolderEditor, true, MaskType.Numeric, "#####0")]
        [Category("Test")]
        [DisplayName("Folder Mask"), Description("Folder find.")]
        public string TextFolder { get; set; }

        [CustomEditor(_editorType.MacList)]
        [Category("Test"), DisplayName("Ethernet Adapter"), Description("Ethernet Adapter Mac Address")]
        public string NetworkAdapter { get; set; }

     

        public Student()
        {
            Cert = new Certificate();
            Cert2 = new Certificate();
            List = new bool[3];
            Text2Reg = "CE1";
        }
    }

    public class Certificate: CertificateBase
    {
        [DisplayName("certID"), Description("Student Age1")]
        [CustomEditor(_editorType.Number)]
        public int CertificateID { get; set; }
        public string Name { get; set; }

        [DisplayName("ButtonEdit"), Description("ButtonEdit")]
        [CustomEditor(_editorType.ButtonEdit)]
        public string ButtonEdit { get; set; }

        [DisplayName("ButtonEdit Class"), Description("ButtonEdit class")]
        [CustomEditor(_editorType.ButtonEdit)]
        public Student ButtonEditClass { get; set; }

        public bool IsOK { get; set; }
    }

    public class CertificateBase
    {

    }

    

 

    public class FilteredFileNameEditor : UITypeEditor
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context,IServiceProvider provider,object value)
        {
            ofd.FileName = value.ToString();
            ofd.Filter = "Text File|*.txt|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return base.EditValue(context, provider, value);
        }
    }

    public class MacInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public MacInfo(string sName, string sAddress)
        {
            Name = sName;
            Address = sAddress;
        }
    }


}
