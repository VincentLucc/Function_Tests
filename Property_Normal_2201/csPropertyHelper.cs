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
 


namespace Property_Normal_221
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
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            propertyGrid = propertyGridControl;
            propertyGrid.DataSourceChanged += PropertyGrid_DataSourceChanged;
            InitProperty();
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

                //Get all rows
                var rows = GetAllPropertyRows();

                //Set editor
                foreach (var row in rows)
                {
                    var editor = GetEditorType(row, propertyGrid.SelectedObject);
                    if (editor == null)
                    {
                        //Trigger custom setting event
                        var data = new RowEditorData(row, editor);//prepare data
                        CustomSettingRowEditor?.Invoke(this, data);
                    }
                    else
                    {
                        SetRowEditor(row, editor);

                        //Trigger custom setting event
                        var data = new RowEditorData(row, editor);//prepare data
                        CustomSettingRowEditor?.Invoke(this, data);
                    }

                    //set row visibility
                    SetRowVisibility(row, editor);
                }          
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
        /// Get all relavent rows from property grid
        /// </summary>
        /// <returns></returns>
        private List<BaseRow> GetAllPropertyRows()
        {
            //Init variables
            List<BaseRow> rowsPre = new List<BaseRow>(); //Get all rows
            List<BaseRow> rowsPost = new List<BaseRow>(); //Required rows

            foreach (var rowLevel1 in propertyGrid.Rows)
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
                //Empry row is required!!! used for class name display
                //if (BaseRow is CategoryRow || BaseRow is PGridEmptyRow) continue;
                if (BaseRow is CategoryRow) continue;

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
        public CustomEditorAttribute GetEditorType(BaseRow propertyRow, object PropertyObject)
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


 
        public void InitProperty()
        {
            propertyGrid.ActiveViewType = PropertyGridView.Office;

            
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
                case EditorType.Cal:
                    RepositoryItemCalcEdit repositoryCalcEdit = new RepositoryItemCalcEdit();
                    repositoryCalcEdit.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                    //repositoryCalcEdit.EditValueChangedDelay = int.MaxValue;
                    row.Properties.RowEdit = repositoryCalcEdit;
                    break;

                case EditorType.Number:
                    RepositoryItemTextEdit repositoryNumberEdit = new RepositoryItemTextEdit();
                    repositoryNumberEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositoryNumberEdit.Mask.MaskType = MaskType.Numeric;
                    repositoryNumberEdit.Mask.EditMask = string.IsNullOrWhiteSpace(editor.MaskString) ? EditMasks.DigitalValue5 : editor.MaskString;
                    repositoryNumberEdit.ValidateOnEnterKey = true;
                    row.Properties.RowEdit = repositoryNumberEdit;
                    break;

                case EditorType.NumberSpin:
                    RepositoryItemSpinEdit repositorySpinEdit = new RepositoryItemSpinEdit();
                    repositorySpinEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositorySpinEdit.Mask.MaskType = MaskType.Numeric;
                    repositorySpinEdit.Mask.EditMask = string.IsNullOrWhiteSpace(editor.MaskString) ? EditMasks.DigitalValue5 : editor.MaskString;
                    repositorySpinEdit.ValidateOnEnterKey = true;
                    row.Properties.RowEdit = repositorySpinEdit;
                    break;

                case EditorType.ButtonEdit:
                    RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                    buttonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
                    buttonEdit.NullText = ""; //Null display
                    buttonEdit.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                    row.Properties.RowEdit = buttonEdit;
                    break;

                case EditorType.ButtonEditHide:
                    RepositoryItemButtonEdit buttonEditHide = new RepositoryItemButtonEdit();
                    buttonEditHide.TextEditStyle = TextEditStyles.HideTextEditor;
                    buttonEditHide.NullText = ""; //Null display
                    buttonEditHide.CustomDisplayText += ButtonEdit_CustomDisplayText; ; //Clear display
                    row.Properties.RowEdit = buttonEditHide;
                    break;

                case EditorType.Text:
                    RepositoryItemTextEdit textEdit_Text = new RepositoryItemTextEdit();
                    textEdit_Text.Tag = 101;
                    if (editor.IsCustomMaskEnable)
                    {
                        textEdit_Text.Mask.UseMaskAsDisplayFormat = true;
                        textEdit_Text.Mask.MaskType = editor.MaskType;
                        textEdit_Text.Mask.EditMask = editor.MaskString;
                        textEdit_Text.EditValueChangedFiringMode = EditValueChangedFiringMode.Buffered;
                        textEdit_Text.EditValueChangedDelay = 2000;
                    }
                    row.Properties.RowEdit = textEdit_Text;
                    break;

                case EditorType.FolderEditor:
                    RepositoryItemButtonEdit folderButtonEditor = new RepositoryItemButtonEdit();
                    folderButtonEditor.ButtonClick += FolderButtonEditor_ButtonClick;
                    row.Properties.RowEdit = folderButtonEditor;
                    break;

                case EditorType.ToggleSwitch:
                    var ToggleSwitchEditor = new RepositoryItemToggleSwitch();
                    ToggleSwitchEditor.EditValueChangedFiringMode = EditValueChangedFiringMode.Default; //No delay for toggle switch
                    ToggleSwitchEditor.EditValueChangedDelay = 0;
                    row.Properties.RowEdit = ToggleSwitchEditor;
                    break;

                case EditorType.ToggleSwitchList:
                    RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                    row.Properties.Caption = $"Device {editor.IntValue + 1}";
                    row.Properties.RowEdit = new RepositoryItemToggleSwitch();
                    Debug.Write("ToggleSwitchList:" + row.Properties.FieldName + ":");
                    break;

                case EditorType.MacList:
                    RepositoryItemLookUpEdit repositoryMacList = new RepositoryItemLookUpEdit();
                    repositoryMacList.ShowFooter = false;//Hide "X" button in bottom
                    repositoryMacList.DataSource = csPublic.GetMacAddress().Values.ToList();
                    repositoryMacList.TextEditStyle = TextEditStyles.Standard; //Enable user edit value
                    repositoryMacList.NullText = "";
                    row.Properties.RowEdit = repositoryMacList;
                    break;

                default:
                    break;
            }
        }

        private void ButtonEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }

        private void FolderButtonEditor_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            XtraFolderBrowserDialog dialog = new XtraFolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ButtonEdit bEditor = (ButtonEdit)sender;
                bEditor.EditValue = dialog.SelectedPath; //Get value               
            }
        }


    }

}

