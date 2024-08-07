﻿using System;
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
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraEditors.Mask;
using System.Drawing;

namespace Property_NoAutoValidate
{
    class Student
    {
        [CustomEditor(EditorType.Text)]
        [DisplayName("s Name"), Category("Test"), Description("Description Method 1 Name of this student.")]
        //Directly use custom editor, Type and base type
        [Editor(typeof(FilteredFileNameEditor), typeof(UITypeEditor))]
        public string Name { get; set; }

        //User to address editor manually
        //Ref:https://docs.devexpress.com/WindowsForms/1498/controls-and-libraries/editors-and-simple-controls/common-editor-features-and-concepts/masks/mask-type-numeric
        [CustomEditor(EditorType.Number)]
        [Category("Test")]
        [DisplayName("S Age"), Description("Description Method 2, manual address")]
        public int Age { get; set; }

        //Test text editor regex
        [CustomEditor(EditorType.Text, @"^[a-zA-Z]{1,2}[0-9]*$", MaskType.RegEx)]
        [Category("Test")]
        [DisplayName("Text1 No Mask"), Description("Text editor no mask ")]
        public string Text1NoMask { get; set; }

        //Test text editor regex
        [CustomEditor(EditorType.Text, @"^[a-zA-Z]{1,2}[0-9]*$", MaskType.RegEx)]
        [Category("Test")]
        [DisplayName("Text2 Reg Mask"), Description("Text editor with regex mask")]
        public string Text2Reg { get; set; }

        //Test text editor numeric
        [CustomEditor(EditorType.Text, "n0", MaskType.Numeric)]
        [Category("Test")]
        [DisplayName("Text3 Numeric Mask"), Description("Text editor with Numeric Mask")]
        public string Text3Num { get; set; }

        //Test text editor
        [CustomEditor(EditorType.Cal, "####0.00\\ \\m\\m", MaskType.Numeric,10,20)]
        [Category("Test")]
        [DisplayName("Numeric Cal Edit"), Description("Text editor with Numeric \r\nMask Metric_Distance5 = ####0.00\\ \\m\\m")]
        public string NumCal { get; set; }

        [CustomEditor(EditorType.NumberSpin, "#0", MaskType.Numeric, 10, 20)]
        [Category("Test")]
        [DisplayName("Numeric Spin"), Description("Spin Edit")]
        public string NumSpin { get; set; }

        //Test text editor regex
        [CustomEditor(EditorType.Cal, EditMasks.Metric_RPM, MaskType.Numeric)]
        [Category("Test")]
        [DisplayName("Numeric Positive"), Description("Positive only")]
        public string NumPositive { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public Certificate Cert { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public CertificateBase Cert2 { get; set; }

        [CustomEditor(EditorType.ToggleSwitch)]
        [Category("Test")]
        [DisplayName("Toggle Switch"), Description("Description Method 2, manual address")]
        public bool ToggleSwitch { get; set; }

        /// <summary>
        /// Must be public to be able to display on property
        /// </summary>
        [CustomEditor(EditorType.ToggleSwitchList)]
        [DisplayName("List"), Description("List Test")]
        [ExpandableRowSettings(false)] //Hide class root editor

        public bool[] List { get; set; }

        [CustomEditor(EditorType.MacLookUpList)]
        [DisplayName("Mac Lookup List")]
        public string MacAddress { get; set; }

        [CustomEditor(EditorType.MacLookupImage)]
        [DisplayName("Mac Lookup Image")]
        public string MacLookupImage { get; set; }

        [CustomEditor(EditorType.MacImageComboList)]
        [DisplayName("Mac Image Combobox")]
        public string MacImageCombo { get; set; }

        [CustomEditor(EditorType.MacGridLookUp)]
        [DisplayName("Mac Grid Lookup")]
        public string MacAddressGridLookup { get; set; }

        public Student()
        {
            Cert = new Certificate();
            Cert2 = new Certificate();
            List = new bool[3];
            Text2Reg = "CE1";
        }
    }

    public class Certificate : CertificateBase
    {
        [DisplayName("certID"), Description("Student Age1")]
        [CustomEditor(EditorType.Number)]
        public int CertificateID { get; set; }
        public string Name { get; set; }

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
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
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
        public Image image { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
