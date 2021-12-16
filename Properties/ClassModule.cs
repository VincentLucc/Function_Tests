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

namespace Properties
{
    class Student
    {
        [Category("Test")]
        [DisplayName("sName"), Description("Name of this student.")]
        //Directly use custom editor, Type and base type
        [Editor(typeof(FilteredFileNameEditor),typeof(UITypeEditor))]
        public string Name { get; set; }
        //User to address editor manually
        [CustomEditor(EditorType.Number)]
        [Category("Test")]
        [DisplayName("sAge"), Description("Student Age")]
        public int Age { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public Certificate Cert { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))] //Show sub class properties
        [ExpandableRowSettings(false)] //Hide class root editor
        public CertificateBase Cert2 { get; set; }

        public Student()
        {
            Cert = new Certificate();
            Cert2 = new Certificate();
        }
    }

    public class Certificate: CertificateBase
    {
        [DisplayName("certID"), Description("Student Age1")]
        [CustomEditor(EditorType.Number)]
        public int CertificateID { get; set; }
        public string Name { get; set; }

        [Editor(typeof(RepositoryItemToggleSwitch), typeof(RepositoryItem))]
        public bool IsOK { get; set; }
    }

    public class CertificateBase
    {

    }

    /// <summary>
    /// Define a attribute
    /// Name+Attribute, simply use name when apply
    /// </summary>
    public class CustomEditorAttribute : Attribute
    {
        public EditorType Editor;

        public float? Min;

        public float? Max;
        public CustomEditorAttribute(EditorType editorType)
        {
            Editor = editorType;
        }
        public CustomEditorAttribute(EditorType editorType, int iMin, int iMax)
        {
            Editor = editorType;
            Min = iMin;

        }

    }

    public class FilteredFileNameEditor : UITypeEditor
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        public override UITypeEditorEditStyle GetEditStyle(
         ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(
         ITypeDescriptorContext context,
         IServiceProvider provider,
         object value)
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

    public enum EditorType
    {
        Number
    }


}
