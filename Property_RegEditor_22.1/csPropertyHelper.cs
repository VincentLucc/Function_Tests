using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
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
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Net.NetworkInformation;



namespace Property_RegEditor_22._1
{
    /// <summary>
    /// Help to set the property
    /// </summary>
    public class csPropertyHelper
    {
        public PropertyGridControl propertyGrid { get; set; }
        /// <summary>
        /// Trigger when setting row editor for custom editor set outside the class if needed
        /// </summary>
        public event EventHandler<RowEditorData> CustomSettingRowEditor;
        public Dictionary<_editorType, object> EditorCollection;
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            propertyGrid = propertyGridControl;
            propertyGrid.DataSourceChanged += PropertyGrid_DataSourceChanged;
            propertyGrid.CustomRecordCellEdit += PropertyGrid_CustomRecordCellEdit;
            InitProperty();
        }

        private void PropertyGrid_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {
            SetRowEditor(e);
        }

        public void InitProperty()
        {
            propertyGrid.ActiveViewType = PropertyGridView.Office;
            EditorCollection = new Dictionary<_editorType, object>();
        }

        private void PropertyGrid_DataSourceChanged(object sender, EventArgs e)
        {
            ReloadAll();
        }

        public void ReloadAll()
        {
            //Null verification
            if (propertyGrid == null) return;

            try
            {
                propertyGrid.BeginUpdate();

                //Create new rows before set properties
                propertyGrid.UpdateRows();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PropertyHelper.ReloadAll:\r\n" + ex.Message);
            }

            propertyGrid.EndUpdate();
        }

        private void SetRowVisibility(BaseRow row, CustomEditorAttribute editor)
        {
            SetStudentVisibility(row);
        }

        private void SetStudentVisibility(BaseRow row)
        {
            //check current selection
            var selectedObject = propertyGrid.SelectedObject;
            if (!(selectedObject is Student)) return;

            //Prepare variable
            var student = propertyGrid.SelectedObject as Student;
            string sName = row.Properties.FieldName;


        }

        /// <summary>
        /// Get attribute type of a property row
        /// </summary>
        /// <param name="propertyRow"></param>
        /// <param name="PropertyObject">property grid selected object</param>
        /// <returns></returns>
        public CustomEditorAttribute GetEditorInfo(BaseRow propertyRow, object PropertyObject)
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
        private void SetRowEditor(DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {
            var editorInfo = GetEditorInfo(e.Row, propertyGrid.SelectedObject);
            if (editorInfo == null) return;
            var existEditor = TryGetEditor(editorInfo);

            switch (editorInfo.EditorType)
            {
                case _editorType.Cal:
                    if (existEditor == null)
                    {
                        RepositoryItemCalcEdit repositoryCalcEdit = new RepositoryItemCalcEdit();
                        repositoryCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryCalcEdit.Mask.EditMask = editorInfo.MaskString;
                        e.RepositoryItem = repositoryCalcEdit;
                        RegEditor(_editorType.Cal, repositoryCalcEdit);
                    }
                    break;

                case _editorType.Number:
                    if (existEditor == null)
                    {
                        RepositoryItemTextEdit repositoryNumberEdit = new RepositoryItemTextEdit();
                        repositoryNumberEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberEdit.Mask.EditMask = string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                        repositoryNumberEdit.ValidateOnEnterKey = true;
                        e.RepositoryItem = repositoryNumberEdit;
                        RegEditor(_editorType.Number, repositoryNumberEdit);
                    }
                    break;

                case _editorType.NumberSpin:
                    if (existEditor == null)
                    {
                        RepositoryItemSpinEdit repositorySpinEdit = new RepositoryItemSpinEdit();
                        repositorySpinEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositorySpinEdit.Mask.MaskType = MaskType.Numeric;
                        repositorySpinEdit.Mask.EditMask = string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                        repositorySpinEdit.ValidateOnEnterKey = true;
                        e.RepositoryItem = repositorySpinEdit;
                        string sDesc = $"Mask:{repositorySpinEdit.Mask.EditMask}";
                        RegEditor(_editorType.Number, repositorySpinEdit, sDesc);
                    }
                    break;

                case _editorType.ButtonEdit:
                    if (existEditor == null)
                    {
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                        buttonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
                        buttonEdit.NullText = ""; //Null display
                        buttonEdit.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEdit;
                        RegEditor(_editorType.ButtonEdit, buttonEdit);
                    }

                    break;

                case _editorType.ButtonEditHide:
                    if (existEditor == null)
                    {
                        RepositoryItemButtonEdit buttonEditHide = new RepositoryItemButtonEdit();
                        buttonEditHide.TextEditStyle = TextEditStyles.HideTextEditor;
                        buttonEditHide.NullText = ""; //Null display
                        buttonEditHide.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEditHide;
                        RegEditor(_editorType.Number, buttonEditHide);
                    }
                    break;

                case _editorType.Text:
                    if (existEditor == null)
                    {
                        RepositoryItemTextEdit textEdit_Text = new RepositoryItemTextEdit();

                        if (editorInfo.IsCustomMaskEnable)
                        {
                            textEdit_Text.Mask.UseMaskAsDisplayFormat = true;
                            textEdit_Text.Mask.MaskType = editorInfo.MaskType;
                            textEdit_Text.Mask.EditMask = editorInfo.MaskString;
                            textEdit_Text.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                            textEdit_Text.EditValueChangedDelay = 2000;
                        }
                        e.RepositoryItem = textEdit_Text;
                        RegEditor(_editorType.Number, textEdit_Text);
                    }
                    break;


                case _editorType.ToggleSwitch:
                    if (existEditor == null)
                    {
                        var ToggleSwitchEditor = new RepositoryItemToggleSwitch();
                        ToggleSwitchEditor.EditValueChangedFiringMode = EditValueChangedFiringMode.Default; //No delay for toggle switch
                        ToggleSwitchEditor.EditValueChangedDelay = 0;
                        e.RepositoryItem = ToggleSwitchEditor;
                        RegEditor(_editorType.Number, ToggleSwitchEditor);
                    }

                    break;

                case _editorType.ToggleSwitchList:
                    e.Row.Properties.Caption = $"Device {editorInfo.IntValue + 1}";
                    if (existEditor == null)
                    {
                        RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                        Debug.Write("ToggleSwitchList:" + e.Row.Properties.FieldName + ":");
                        e.RepositoryItem = toggleSwitch;
                        RegEditor(_editorType.ToggleSwitchList, toggleSwitch);
                    }
                    break;
                default:
                    break;
            }

            //Update view
            SetRowVisibility(e.Row, editorInfo);
        }

        public void RegEditor(_editorType type, RepositoryItem editor, string sDesc = null)
        {
            if (EditorCollection == null) EditorCollection = new Dictionary<_editorType, object>();
            if (EditorCollection.ContainsKey(type))
            {
                if (EditorCollection[type] is RepositoryItem)
                {
                    var oldItem = EditorCollection[type] as RepositoryItem;
                    List<RepositoryItem> lItems = new List<RepositoryItem>();
                    lItems.Add(oldItem);
                    lItems.Add(editor);
                    EditorCollection[type] = lItems;
                }
                else if (EditorCollection[type] is List<RepositoryItem>)
                {
                    var lItems = EditorCollection[type] as List<RepositoryItem>;
                    lItems.Add(editor);
                }
                else
                {
                    Debug.WriteLine("AddEditor.Error");
                }
            }
            else
            {
                EditorCollection.Add(type, editor);
            }

            Debug.WriteLine($"Reg. Editor: {type}, {editor} {sDesc}");
        }

        public RepositoryItem TryGetEditor(CustomEditorAttribute editorInfo)
        {
            if (EditorCollection == null) return null;
            if (!EditorCollection.ContainsKey(editorInfo.EditorType)) return null;
            object editorValue = EditorCollection[editorInfo.EditorType];
            if (editorValue is RepositoryItem) return (RepositoryItem)editorValue;
            //Get items in collection
            if (editorValue is List<RepositoryItemCalcEdit>)
            {
                //Check mask
                var calc = (editorValue as List<RepositoryItemCalcEdit>).
                    FirstOrDefault(a => a.EditMask == editorInfo.MaskString);
                return calc;
            }
            else if (editorValue is List<RepositoryItemTextEdit>)
            {
                var text = (editorValue as List<RepositoryItemTextEdit>).
                         FirstOrDefault(a => a.MaskSettings.MaskExpression == editorInfo.MaskString);
                return text;
            }
            return null;
        }

        private void ButtonEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }




    }

}

