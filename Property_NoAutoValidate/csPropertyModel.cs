using DevExpress.XtraEditors.Mask;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_NoAutoValidate
{

    public enum EditorType
    {
        Cal,
        Number,
        NumberSpin,
        Text,
        ToggleSwitch,
        ToggleSwitchList,
        MacLookUpList,
        MacLookupImage,
        MacImageComboList,
        MacGridLookUp
    }


    /// <summary>
    /// Define a attribute
    /// Name+Attribute, simply use name when apply
    /// </summary>
    public class CustomEditorAttribute : Attribute
    {
        public EditorType Editor;
        public MaskType MaskType;
        /// <summary>
        /// Define input masks for auto input validation
        /// </summary>
        public string MaskString;
        /// <summary>
        /// Whether custom editor is used
        /// </summary>
        public bool IsCustomMaskEnable => string.IsNullOrWhiteSpace(MaskString) ? false : true;
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

        public CustomEditorAttribute(EditorType editorType)
        {
            Editor = editorType;
            SetDefaultMask(editorType);
        }

        public CustomEditorAttribute(EditorType editorType, string maskString, MaskType maskType)
        {
            Editor = editorType;
            MaskType = maskType;
            MaskString = maskString;
        }

        public CustomEditorAttribute(EditorType editorType, string maskString, MaskType maskType, float iMin, float iMax)
        {
            Editor = editorType;
            MaskType = maskType;
            MaskString = maskString;
            EnableRangeLimit = true;
            Min = iMin;
            Max = iMax;
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

        private void SetDefaultMask(EditorType editorType)
        {
            switch (editorType)
            {
                case EditorType.Cal:
                    MaskType = MaskType.Numeric;
                    MaskString = EditMasks.DigitalValue6;
                    break;
                case EditorType.Number:
                    MaskType = MaskType.Numeric;
                    MaskString = EditMasks.DigitalValue6;
                    break;
                case EditorType.Text:
                    MaskType = MaskType.None;
                    break;
                case EditorType.ToggleSwitch:
                    break;
                case EditorType.ToggleSwitchList:
                    break;
                case EditorType.MacLookUpList:
                    break;
                case EditorType.MacImageComboList:
                    break;
                default:
                    break;
            }
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
