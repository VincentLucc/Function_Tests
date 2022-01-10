using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Properties
{
    /// <summary>
    /// Help to set the property
    /// </summary>
    public class csPropertyHelper
    {
        public PropertyGridControl PropertyGrid { get; set; }

        /// <summary>
        /// Trigger when setting row editor for custom editor set outside the class if needed
        /// </summary>
        public event EventHandler<RowEditorData> CustomSettingRowEditor;
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            PropertyGrid = propertyGridControl;
        }

        public void ReloadAll()
        {
            //Null verification
            if (PropertyGrid == null) return;

            //Create new rows before set properties
            PropertyGrid.UpdateRows();

            //Get all rows
            var rows = GetAllPropertyRows();

            //Set editor
            foreach (var row in rows)
            {
                var editor = GetEditorType(row, PropertyGrid.SelectedObject);
                if (editor == null) continue;
                SetRowEditor(row, editor);

                //Trigger custom setting event
                var data = new RowEditorData(row, editor);//prepare data
                if (CustomSettingRowEditor != null)
                {
                    CustomSettingRowEditor(this, data);
                }
            }
        }

        /// <summary>
        /// Get all relavent rows from property grid
        /// </summary>
        /// <returns></returns>
        private List<BaseRow> GetAllPropertyRows()
        {
            //Init variables
            List<BaseRow> rowsPre = new List<BaseRow>(); //Get all rows
            List<BaseRow> rowsPost = new List<BaseRow>(); //Required rows

            foreach (var rowLevel1 in PropertyGrid.Rows)
            {
                rowsPre.Add(rowLevel1);

                foreach (var rowLevel2 in rowLevel1.ChildRows)
                {
                    rowsPre.Add(rowLevel2);

                    foreach (var rowLevel3 in rowLevel2.ChildRows)
                    {
                        rowsPre.Add(rowLevel3);
                    }
                }
            }

            //Remove null relavent row       
            foreach (var BaseRow in rowsPre)
            {
                if (BaseRow is CategoryRow || BaseRow is PGridEmptyRow)
                {
                    continue;
                }

                //Remove devexpress specific row
                string sRowName = BaseRow.Properties.FieldName;
                if (sRowName == "Appearance.Options")
                {
                    continue;
                }

                rowsPost.Add(BaseRow);
            }

            //Show rows count
            Debug.WriteLine("GetAllPropertyRows:" + rowsPost.Count);
            return rowsPost;
        }




        /// <summary>
        /// Get attribute type of a property row
        /// </summary>
        /// <param name="propertyRow"></param>
        /// <param name="PropertyObject">property grid selected object</param>
        /// <returns></returns>
        private CustomEditorAttribute GetEditorType(BaseRow propertyRow, object PropertyObject)
        {
            //Init variables
            PropertyInfo propertyInfo = null;
            CustomEditorAttribute editor = null;
            bool IsSubProperty = false;
            int iIndex = -1; //Index of a row in array

            string sName = propertyRow.Properties.FieldName;

            //Check selection
            if (PropertyObject == null) return null;

            //Check name
            if (string.IsNullOrEmpty(sName)) return null;

            try
            {
                //Array or list
                //sample format , TestList.[0]
                if (sName.Contains(".["))
                {
                    //Match result
                    string sPattern = @"\[([1-9]*[0-9])\]";
                    var splitResult = Regex.Split(sName, sPattern);

                    //Error in getting result
                    if (splitResult.Length != 3) return null;

                    //Get array name, editor, get ID
                    string sArray = sName.Substring(0, sName.IndexOf('.'));

                    //Get ID
                    iIndex = Convert.ToInt32(splitResult[1]);

                    propertyInfo = PropertyObject.GetType().GetProperty(sArray);
                    IsSubProperty = true;


                }
                //Sub class
                else if (sName.Contains("."))
                {
                    var sProperties = sName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                    if (sProperties.Length != 2) return null;

                    //Get parent info
                    PropertyInfo pParent = PropertyObject.GetType().GetProperty(sProperties[0]);

                    //Get property instance to retrive actual type such as inherit class
                    var pInstance = pParent.GetValue(PropertyObject);

                    //Get 2nd property info
                    propertyInfo = pInstance.GetType().GetProperty(sProperties[1]);

                    IsSubProperty = true;

                }
                else
                {
                    propertyInfo = PropertyObject.GetType().GetProperty(sName);
                    IsSubProperty = false;
                }

                //No property set
                if (propertyInfo == null) return null;

                //Get all attributes
                var attributes = propertyInfo.GetCustomAttributes(false).Where(a => a is CustomEditorAttribute);

                if (attributes.Count() == 1)
                {
                    editor = attributes.First() as CustomEditorAttribute;
                    editor.IntValue = iIndex; //Load the index value if valid
                    editor.IsSubProperty = IsSubProperty;
                    return editor;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetEditorType:{sName}\r\n" + ex.Message);
            }


            //Nothing found
            return null;
        }




        /// <summary>
        /// Set row editor based on edit type
        /// </summary>
        /// <param name="row"></param>
        /// <param name="editor"></param>
        private void SetRowEditor(BaseRow row, CustomEditorAttribute editor)
        {
            switch (editor.Editor)
            {
                case EditorType.Number:
                    RepositoryItemCalcEdit repositoryCalcEdit = new RepositoryItemCalcEdit();
                    repositoryCalcEdit.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                    //repositoryCalcEdit.EditValueChangedDelay = int.MaxValue;
                    row.Properties.RowEdit = repositoryCalcEdit;
                    
                    break;

                case EditorType.ToggleSwitch:
                    row.Properties.RowEdit = new RepositoryItemToggleSwitch();
                    break;

                case EditorType.ToggleSwitchList:
                    RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                    row.Properties.Caption = $"Device {editor.IntValue+1}";
                    row.Properties.RowEdit = new RepositoryItemToggleSwitch();
                    Debug.WriteLine(row.Appearance.Name);                 
                    break;

                default:
                    break;
            }
        }

    }

    public enum EditorType
    {
        Number,
        ToggleSwitch,
        ToggleSwitchList,
    }


    /// <summary>
    /// Define a attribute
    /// Name+Attribute, simply use name when apply
    /// </summary>
    public class CustomEditorAttribute : Attribute
    {
        public EditorType Editor;

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
