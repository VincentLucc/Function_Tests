using DevExpress.XtraEditors.Mask;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Properties
{
    /// <summary>
    /// Masks
    /// # any digital or nothing if empty
    /// 0 any digital or zero if empty
    /// . decimal point
    /// , thousand separator
    /// "##0.##" allow to input 000.00 format
    /// Ref:https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.PropertyEditor.EditMask
    /// </summary>
    static class EditMasks
    {
        public const string Metric_Distance2 = "#0.00\\ \\m\\m";
        public const string Metric_Distance3 = "##0.00\\ \\m\\m";
        public const string Metric_Distance4 = "###0.00\\ \\m\\m";
        public const string Metric_Distance5 = "####0.00\\ \\m\\m";

        public const string Metric_Speed = "###0.00\\ \\m\\/\\m";
        public const string Metric_RPM = "###0.00\\ \\R\\P\\M";

        public const string Imperial_Distance2 = "#0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance3 = "##0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance4 = "###0.000\\ \\I\\n\\c\\h\\e\\s";
        public const string Imperial_Distance5 = "####0.000\\ \\I\\n\\c\\h\\e\\s";

        public const string Imperial_Speed = "###0.00\\ \\F\\P\\M";

        public const string DigitalValue3 = "##0";
        public const string DigitalValue5 = "####0";
        public const string DigitalValue6 = "#####0";
        public const string DigitalValue9 = "########0";

        public const string RegNumber6NoZero = "[1-9][0-9]{0,5}";
    }

    public enum EditorType
    {
        Cal,
        Number,
        NumberReg,
        NumberSpin,
        Text,
        FolderEditor,
        ButtonEdit,
        ButtonEditHide,
        ToggleSwitch,
        ToggleSwitchList,
        MacList
    }

    /// <summary>
    /// Define a attribute
    /// Name+Attribute, simply use name when apply
    /// </summary>
    public class CustomEditorAttribute : Attribute
    {
        public EditorType Editor;
        public bool IsCustomMaskEnable;
        public MaskType MaskType;
        /// <summary>
        /// Define input masks for auto input validation
        /// </summary>
        public string MaskString;
        public float Min;

        public float Max;

        /// <summary>
        /// Min/Max value enabled
        /// </summary>
        public bool EnableRangeLimit;
        /// <summary>
        /// Current row property is sub property or root property
        /// </summary>
        public bool IsSubProperty { get; set; }
        /// <summary>
        /// Store any editor related value for customization usage
        /// </summary>
        public int IntValue { get; set; }


        public CustomEditorAttribute(EditorType editorType, string maskString = "")
        {
            Editor = editorType;
            MaskString = maskString;
        }

        public CustomEditorAttribute(EditorType editorType, int iMin, int iMax)
        {
            Editor = editorType;
            Min = iMin;
            Max = iMax;
            EnableRangeLimit = true;
        }

        public CustomEditorAttribute(EditorType editorType, float fMin, int fMax)
        {
            Editor = editorType;
            Min = fMin;
            Max = fMax;
            EnableRangeLimit = true;
        }

        public CustomEditorAttribute(EditorType editorType, bool enableCustomMask, MaskType maskType = MaskType.Custom, string maskString = "")
        {
            Editor = editorType;
            IsCustomMaskEnable = enableCustomMask;
            MaskType = maskType;
            MaskString = maskString;
        }

        /// <summary>
        /// Store int value for configuration
        /// </summary>
        /// <param name="editorType"></param>
        /// <param name="iValue"></param>
        public CustomEditorAttribute(EditorType editorType, int iValue)
        {
            Editor = editorType;
            IntValue = iValue;
        }

    }

    /// <summary>
    /// Used to set row editor
    /// </summary>
    public class RowEditorData
    {
        public BaseRow PropertyRow { get; set; }
        public CustomEditorAttribute Editor { get; set; }

        public RowEditorData(BaseRow propertyRow, CustomEditorAttribute rowEditor)
        {
            PropertyRow = propertyRow;
            Editor = rowEditor;
        }
    }

}


