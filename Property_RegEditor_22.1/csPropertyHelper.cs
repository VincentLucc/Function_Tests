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

        /// <summary>
        /// Store regular unique editors
        /// </summary>
        public Dictionary<_editorType, RepositoryItem> EditorCollection;

        /// <summary>
        /// Store editors with different mask settings
        /// Don't use same editor and change masks, can cause display issue 
        /// </summary>
        public List<RepositoryItemCalcEdit> calcEditors;
        public List<RepositoryItemTextEdit> textEditors;
        public List<RepositoryItemSpinEdit> spinEditors;
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            //Init variables
            EditorCollection = new Dictionary<_editorType, RepositoryItem>();
            calcEditors = new List<RepositoryItemCalcEdit>();
            textEditors = new List<RepositoryItemTextEdit>();
            spinEditors = new List<RepositoryItemSpinEdit>();

            propertyGrid = propertyGridControl;
            propertyGrid.ActiveViewType = PropertyGridView.Office;

            propertyGrid.DataSourceChanged += PropertyGrid_DataSourceChanged;
            propertyGrid.CustomRecordCellEdit += PropertyGrid_CustomRecordCellEdit;
        }

        private void PropertyGrid_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {
            SetRowEditor(e);
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
            //Get current editor info
            var editorInfo = GetEditorInfo(e.Row, propertyGrid.SelectedObject);
            if (editorInfo == null) return;

            //Set editor based on type
            switch (editorInfo.EditorType)
            {
                case _editorType.Cal:
                    var machedCalEditor = calcEditors.FirstOrDefault(
                        a => a.UseMaskAsDisplayFormat && a.EditMask == editorInfo.MaskString);
                    if (machedCalEditor == null)
                    {
                        RepositoryItemCalcEdit repositoryCalcEdit = new RepositoryItemCalcEdit();
                        repositoryCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryCalcEdit.Mask.EditMask = editorInfo.MaskString;
                        e.RepositoryItem = repositoryCalcEdit;
                        RegEditor(_editorType.Cal, repositoryCalcEdit, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedCalEditor;
                    }
                    break;

                case _editorType.Number:
                    string sMask= string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                    var machedNumberEditor = textEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.MaskSettings.MaskExpression == sMask);
                    if (machedNumberEditor == null)
                    {
                        RepositoryItemTextEdit repositoryNumberEdit = new RepositoryItemTextEdit();
                        repositoryNumberEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberEdit.Mask.EditMask = sMask;
                        repositoryNumberEdit.ValidateOnEnterKey = true;
                        e.RepositoryItem = repositoryNumberEdit;
                        RegEditor(_editorType.Number, repositoryNumberEdit, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedNumberEditor;
                    }
                    break;

                case _editorType.NumberSpin:
                    string sNumberSpinMask= string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                    var machedNumberSpin = spinEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.MaskSettings.MaskExpression == sNumberSpinMask);
                    if (machedNumberSpin == null)
                    {
                        RepositoryItemSpinEdit repositorySpinEdit = new RepositoryItemSpinEdit();
                        repositorySpinEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositorySpinEdit.Mask.MaskType = MaskType.Numeric;
                        repositorySpinEdit.Mask.EditMask = sNumberSpinMask;
                        repositorySpinEdit.ValidateOnEnterKey = true;
                        string sDesc = $"Mask:{repositorySpinEdit.Mask.EditMask}";
                        e.RepositoryItem = repositorySpinEdit;
                        RegEditor(_editorType.Number, repositorySpinEdit, false, sDesc);
                    }
                    else
                    {
                        e.RepositoryItem = machedNumberSpin;
                    }
                    break;

                case _editorType.ButtonEdit:
                    if (EditorCollection.ContainsKey(_editorType.ButtonEdit))
                    {
                        e.RepositoryItem = EditorCollection[_editorType.ButtonEdit];
                    }
                    else
                    {
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                        buttonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
                        buttonEdit.NullText = ""; //Null display
                        buttonEdit.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEdit;
                        RegEditor(_editorType.ButtonEdit, buttonEdit, true);
                    }
                    break;

                case _editorType.ButtonEditHide:
                    if (EditorCollection.ContainsKey(_editorType.ButtonEditHide))
                    {
                        e.RepositoryItem = EditorCollection[_editorType.ButtonEditHide];
                    }
                    else
                    {
                        RepositoryItemButtonEdit buttonEditHide = new RepositoryItemButtonEdit();
                        buttonEditHide.TextEditStyle = TextEditStyles.HideTextEditor;
                        buttonEditHide.NullText = ""; //Null display
                        buttonEditHide.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEditHide;
                        RegEditor(_editorType.ButtonEditHide, buttonEditHide, true);
                    }
                    break;

                case _editorType.Text:
                    var machedTextEditor = textEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.MaskSettings.MaskExpression == editorInfo.MaskString);
                    if (machedTextEditor == null)
                    {
                        RepositoryItemTextEdit textEdit_Text = new RepositoryItemTextEdit();
                        textEdit_Text.Mask.UseMaskAsDisplayFormat = true;
                        textEdit_Text.Mask.MaskType = editorInfo.MaskType;
                        textEdit_Text.Mask.EditMask = editorInfo.MaskString;
                        textEdit_Text.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                        textEdit_Text.EditValueChangedDelay = 2000;
                        RegEditor(_editorType.Number, textEdit_Text, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedTextEditor;
                    }
                    break;


                case _editorType.ToggleSwitch:
                    if (EditorCollection.ContainsKey(editorInfo.EditorType))
                    {
                        e.RepositoryItem = EditorCollection[editorInfo.EditorType];
                    }
                    else
                    {
                        var ToggleSwitchEditor = new RepositoryItemToggleSwitch();
                        ToggleSwitchEditor.EditValueChangedFiringMode = EditValueChangedFiringMode.Default; //No delay for toggle switch
                        ToggleSwitchEditor.EditValueChangedDelay = 0;
                        e.RepositoryItem = ToggleSwitchEditor;
                        RegEditor(_editorType.ButtonEditHide, ToggleSwitchEditor, true);
                    }
                    break;

                case _editorType.ToggleSwitchList:
                    e.Row.Properties.Caption = $"Device {editorInfo.IntValue + 1}";
                    if (EditorCollection.ContainsKey(editorInfo.EditorType))
                    {
                        e.RepositoryItem = EditorCollection[editorInfo.EditorType];
                    }
                    else
                    {
                        RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                        Debug.Write("ToggleSwitchList:" + e.Row.Properties.FieldName + ":");
                        e.RepositoryItem = toggleSwitch;
                        RegEditor(_editorType.ButtonEditHide, toggleSwitch, true);
                    }
                    break;
                default:
                    break;
            }

            //Update view
            SetRowVisibility(e.Row, editorInfo);
        }

        public void RegEditor(_editorType type, RepositoryItem editor, bool isUnique, string sMessage = "")
        {
            //Add to unique colection
            if (isUnique)
            {
                if (EditorCollection.ContainsKey(type))
                {
                    Debug.WriteLine("AddEditor. Duplicated Editor");
                }
                else
                {
                    EditorCollection.Add(type, editor);
                }
            }
            //Indicate to add to seperate list
            else
            {
                if (editor is RepositoryItemCalcEdit)
                {
                    calcEditors.Add((RepositoryItemCalcEdit)editor);
                }
                else if (editor is RepositoryItemTextEdit)
                {
                    textEditors.Add((RepositoryItemTextEdit)editor);
                }
                else if (editor is RepositoryItemSpinEdit)
                {
                    spinEditors.Add((RepositoryItemSpinEdit)editor);
                }
                else
                {
                    Debug.WriteLine("AddEditor. Not implemented.");
                }
            }

            Debug.WriteLine($"Reg. Editor: {type}, {editor} {sMessage}");
        }


        private void ButtonEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }




    }

}

