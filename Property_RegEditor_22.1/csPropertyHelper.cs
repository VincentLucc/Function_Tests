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
using System.Text.RegularExpressions;
using DevExpress.XtraVerticalGrid.Events;

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
        public event CustomSettingRowEditorAction CustomSettingRowEditor;
        public delegate void CustomSettingRowEditorAction(GetCustomRowCellEditEventArgs eventArg, CustomEditorAttribute editorInfo);

        /// <summary>
        /// Store regular unique editors
        /// One editor for one type
        /// </summary>
        public Dictionary<_editorType, RepositoryItem> UniqueEditors;

        /// <summary>
        /// These editors can be reused by different type or same type with different settings
        /// Store editors with different mask settings
        /// Don't use same editor and change masks, can cause display issue 
        /// </summary>
        public List<RepositoryItemCalcEdit> calcEditors;
        public List<RepositoryItemTextEdit> textEditors;
        public List<RepositoryItemSpinEdit> spinEditors;
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            //Init variables
            UniqueEditors = new Dictionary<_editorType, RepositoryItem>();
            calcEditors = new List<RepositoryItemCalcEdit>();
            textEditors = new List<RepositoryItemTextEdit>();
            spinEditors = new List<RepositoryItemSpinEdit>();

            propertyGrid = propertyGridControl;
            propertyGrid.ActiveViewType = PropertyGridView.Office;
            //Disable auto sort based on aphabet
            propertyGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;

            propertyGrid.DataSourceChanged += PropertyGrid_DataSourceChanged;
            propertyGrid.CustomRecordCellEdit += PropertyGrid_CustomRecordCellEdit;
            propertyGrid.CellValueChanged += PropertyGrid_CellValueChanged;
        }

        private void PropertyGrid_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //Update row visibility
            if (e.Row is PGridBooleanEditorRow)
            {
                ReloadAll();
            }
        }

        private void PropertyGrid_CustomRecordCellEdit(object sender, GetCustomRowCellEditEventArgs e)
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
                        RegisterEditor(editorInfo.EditorType, repositoryCalcEdit, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedCalEditor;
                    }
                    break;

                case _editorType.Number:
                    string sMask = string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                    var machedNumberEditor = textEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.Mask.EditMask == sMask);
                    if (machedNumberEditor == null)
                    {
                        RepositoryItemTextEdit repositoryNumberEdit = new RepositoryItemTextEdit();
                        repositoryNumberEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberEdit.Mask.EditMask = sMask;
                        repositoryNumberEdit.ValidateOnEnterKey = true;
                        e.RepositoryItem = repositoryNumberEdit;
                        RegisterEditor(editorInfo.EditorType, repositoryNumberEdit, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedNumberEditor;
                    }
                    break;

                case _editorType.NumberSpin:
                    string sNumberSpinMask = string.IsNullOrWhiteSpace(editorInfo.MaskString) ? EditMasks.DigitalValue5 : editorInfo.MaskString;
                    var machedNumberSpin = spinEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.Mask.EditMask == sNumberSpinMask);
                    if (machedNumberSpin == null)
                    {
                        RepositoryItemSpinEdit repositorySpinEdit = new RepositoryItemSpinEdit();
                        repositorySpinEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositorySpinEdit.Mask.MaskType = MaskType.Numeric;
                        repositorySpinEdit.Mask.EditMask = sNumberSpinMask;
                        repositorySpinEdit.ValidateOnEnterKey = true;
                        string sDesc = $"Mask:{repositorySpinEdit.Mask.EditMask}";
                        e.RepositoryItem = repositorySpinEdit;
                        RegisterEditor(editorInfo.EditorType, repositorySpinEdit, false, sDesc);
                    }
                    else
                    {
                        e.RepositoryItem = machedNumberSpin;
                    }
                    break;

                case _editorType.ButtonEdit:
                    if (UniqueEditors.ContainsKey(_editorType.ButtonEdit))
                    {
                        e.RepositoryItem = UniqueEditors[_editorType.ButtonEdit];
                    }
                    else
                    {
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                        buttonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
                        buttonEdit.NullText = ""; //Null display
                        buttonEdit.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEdit;
                        RegisterEditor(editorInfo.EditorType, buttonEdit, true);
                    }
                    break;

                case _editorType.ButtonEditHide:
                    if (UniqueEditors.ContainsKey(_editorType.ButtonEditHide))
                    {
                        e.RepositoryItem = UniqueEditors[_editorType.ButtonEditHide];
                    }
                    else
                    {
                        RepositoryItemButtonEdit buttonEditHide = new RepositoryItemButtonEdit();
                        buttonEditHide.TextEditStyle = TextEditStyles.HideTextEditor;
                        buttonEditHide.NullText = ""; //Null display
                        buttonEditHide.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                        e.RepositoryItem = buttonEditHide;
                        RegisterEditor(editorInfo.EditorType, buttonEditHide, true);
                    }
                    break;

                case _editorType.Text:
                    var machedTextEditor = textEditors.FirstOrDefault(a =>
                        a.UseMaskAsDisplayFormat &&
                        a.Mask.EditMask == editorInfo.MaskString);
                    //foreach (var item in textEditors)
                    //{
                    //    string sTest = $"Text:{item.UseMaskAsDisplayFormat},{item.Mask.EditMask}";
                    //    Debug.WriteLine(sTest);
                    //}
                    if (machedTextEditor == null)
                    {
                        RepositoryItemTextEdit textEdit_Text = new RepositoryItemTextEdit();
                        textEdit_Text.Mask.UseMaskAsDisplayFormat = true;
                        textEdit_Text.Mask.MaskType = editorInfo.MaskType;
                        textEdit_Text.Mask.EditMask = editorInfo.MaskString;
                        textEdit_Text.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                        textEdit_Text.EditValueChangedDelay = 2000;
                        RegisterEditor(editorInfo.EditorType, textEdit_Text, false);
                    }
                    else
                    {
                        e.RepositoryItem = machedTextEditor;
                    }
                    break;


                case _editorType.ToggleSwitch:
                    if (UniqueEditors.ContainsKey(editorInfo.EditorType))
                    {
                        e.RepositoryItem = UniqueEditors[editorInfo.EditorType];
                    }
                    else
                    {
                        var ToggleSwitchEditor = new RepositoryItemToggleSwitch();
                        ToggleSwitchEditor.EditValueChangedFiringMode = EditValueChangedFiringMode.Default; //No delay for toggle switch
                        ToggleSwitchEditor.EditValueChangedDelay = 0;
                        e.RepositoryItem = ToggleSwitchEditor;
                        RegisterEditor(editorInfo.EditorType, ToggleSwitchEditor, true);
                    }
                    break;

                case _editorType.ToggleSwitchList:
                    if (e.Row is PGridEmptyRow)
                    {
                        e.Row.Properties.Caption = "Device List";
                    }
                    else
                    {
                        e.Row.Properties.Caption = $"Device {editorInfo.IntValue + 1}";
                    }           
                    if (UniqueEditors.ContainsKey(editorInfo.EditorType))
                    {
                        e.RepositoryItem = UniqueEditors[editorInfo.EditorType];
                    }
                    else
                    {
                        RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                        Debug.Write("ToggleSwitchList:" + e.Row.Properties.FieldName + ":");
                        e.RepositoryItem = toggleSwitch;
                        RegisterEditor(editorInfo.EditorType, toggleSwitch, true);
                    }
                    break;

                case _editorType.MacList:
                    if (UniqueEditors.ContainsKey(editorInfo.EditorType))
                    {
                        e.RepositoryItem = UniqueEditors[editorInfo.EditorType];
                    }
                    else
                    {
                        RepositoryItemLookUpEdit repositoryMacList = new RepositoryItemLookUpEdit();
                        repositoryMacList.ShowFooter = false;//Hide "X" button in bottom
                        repositoryMacList.DataSource = csPublic.GetMacAddress();
                        repositoryMacList.TextEditStyle = TextEditStyles.Standard; //Enable user edit value
                        repositoryMacList.DisplayMember = nameof(MacInfo.Name);
                        repositoryMacList.ValueMember = nameof(MacInfo.Address);
                        e.RepositoryItem = repositoryMacList;
                        RegisterEditor(editorInfo.EditorType, repositoryMacList, true);
                    }
                    break;

                default:
                    break;
            }

            CustomSettingRowEditor?.Invoke(e, editorInfo);

            //Update view
            SetRowLayout(e.Row, editorInfo);
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

        private void SetRowLayout(BaseRow row, CustomEditorAttribute editor)
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
            if (sName==nameof(Student.List))
            {
                row.Visible = student.CheckBox;
            }


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
        /// Can used to check whether duplicated registration appear
        /// </summary>
        /// <param name="type"></param>
        /// <param name="editor"></param>
        /// <param name="isUnique"></param>
        /// <param name="sMessage"></param>
        public void RegisterEditor(_editorType type, RepositoryItem editor, bool isUnique, string sMessage = "")
        {
            //Add to unique colection
            if (isUnique)
            {
                if (UniqueEditors.ContainsKey(type))
                {
                    Debug.WriteLine("AddEditor. Duplicated Editor");
                }
                else
                {
                    UniqueEditors.Add(type, editor);
                }
            }
            //Indicate to add to seperate list
            else
            {
                //Don't use is to avoid matching parent class type
                if (editor.GetType() == typeof(RepositoryItemCalcEdit))
                {
                    calcEditors.Add((RepositoryItemCalcEdit)editor);
                    sMessage += $"({calcEditors.Count})";
                }
                else if (editor.GetType() == typeof(RepositoryItemTextEdit))
                {
                    textEditors.Add((RepositoryItemTextEdit)editor);
                    sMessage += $"({textEditors.Count})";
                }
                else if (editor.GetType() == typeof(RepositoryItemSpinEdit))
                {
                    spinEditors.Add((RepositoryItemSpinEdit)editor);
                    sMessage += $"({spinEditors.Count})";
                }
                else
                {
                    Debug.WriteLine("AddEditor. Not implemented.");
                }
            }

            Debug.WriteLine($"Reg. Editor: {type}, {editor.GetType()} {sMessage}");
        }


        private void ButtonEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }




    }

}

