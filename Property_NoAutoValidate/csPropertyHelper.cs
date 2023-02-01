using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Property_NoAutoValidate
{
    /// <summary>
    /// Help to set the property
    /// </summary>
    public class csPropertyHelper
    {
        public PropertyGridControl propertyGrid { get; set; }
        public bool EnablePropertyValidate { get; set; }

        public bool IsValidationOK { get; set; }

        /// <summary>
        /// Trigger when setting row editor for custom editor set outside the class if needed
        /// </summary>
        public event EventHandler<RowEditorData> CustomSettingRowEditor;
        public csPropertyHelper(PropertyGridControl propertyGridControl)
        {
            propertyGrid = propertyGridControl;        
            propertyGrid.ActiveViewType = PropertyGridView.Office;
            propertyGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort; //Disable auto sort
            propertyGrid.DataSourceChanged += PropertyGrid_DataSourceChanged;
        }



        private void PropertyGrid_DataSourceChanged(object sender, EventArgs e)
        {
            ReloadAll();
        }

        public void ReloadAll()
        {
            try
            {
                //Null verification
                if (propertyGrid == null) return;


                propertyGrid.BeginUpdate();

                //Create new rows before set properties
                propertyGrid.UpdateRows();

                //Get all rows
                var rows = GetAllPropertyRows();

                //Set editor
                foreach (var row in rows)
                {
                    var editorConfig = GetEditorConfig(row, propertyGrid.SelectedObject);
                    if (editorConfig == null) continue;
                    SetRowEditor(row, editorConfig);

                    //Trigger custom setting event
                    var data = new RowEditorData(row, editorConfig);//prepare data
                    if (CustomSettingRowEditor != null) CustomSettingRowEditor(this, data);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("PropertyHelper.ReloadAll:\r\n" + ex.Message);
            }

            propertyGrid.EndUpdate();
        }


        /// <summary>
        /// Only reload in specific situation when value been changed.
        /// </summary>
        /// <param name="e"></param>
        public void ReloadBasedOnChangedValueType(CellValueChangedEventArgs e)
        {
            var propName = e.Row.Properties.FieldName;

            //Special row need to be updated
            //Feeder.FeederCount: value may be changed before validating been triggered, this will refershed updated value
            string[] sUpdateList = new string[] { "PropertyOne"};

            //Type change, list change, visible properties which needs to be refreshed
            if (e.Row is PGridEnumEditorRow ||
                e.Row is PGridBooleanEditorRow ||
                e.Row.Properties.RowEdit is RepositoryItemLookUpEdit ||
                sUpdateList.Contains(propName)) //Partial text match
            {
                ReloadAll();
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

            foreach (var rowLevel1 in propertyGrid.Rows)
            {
                rowsPre.Add(rowLevel1);
                foreach (var rowLevel2 in rowLevel1.ChildRows)
                {
                    rowsPre.Add(rowLevel2);
                    foreach (var rowLevel3 in rowLevel2.ChildRows) rowsPre.Add(rowLevel3);
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
                if (sRowName == "Appearance.Options") continue;
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
        public CustomEditorAttribute GetEditorConfig(BaseRow propertyRow, object PropertyObject)
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

        public CustomEditorAttribute GetUserEditor(string sPropertyName, object Instance)
        {
            PropertyInfo propertyInfo = Instance.GetType().GetProperty(sPropertyName);

            //Get all attributes
            var attributes = propertyInfo.GetCustomAttributes(false).Where(a => a is CustomEditorAttribute);

            if (attributes != null && attributes.Count() == 1)
            {
                var editor = attributes.First() as CustomEditorAttribute;
                return editor;
            }

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
                case EditorType.Cal:
                    RepositoryItemCalcEdit repositoryCalcEdit = new RepositoryItemCalcEdit();
                    //Load mask settings
                    repositoryCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositoryCalcEdit.Mask.MaskType = editor.MaskType;
                    repositoryCalcEdit.Mask.EditMask = editor.MaskString;
                    row.Properties.RowEdit = repositoryCalcEdit;
                    break;

                case EditorType.MacLookUpList:
                    RepositoryItemLookUpEdit repositoryMacList = new RepositoryItemLookUpEdit();
                    repositoryMacList.TextEditStyle = TextEditStyles.Standard; //Enable user edit value
                    repositoryMacList.ShowFooter = false;
                    repositoryMacList.DataSource = GetMacAddress().Values.ToList();
                    repositoryMacList.NullText = "";
                    row.Properties.RowEdit = repositoryMacList;
                    break;

                case EditorType.MacLookupImage:
                    RepositoryItemLookUpEdit macLookupImage = new RepositoryItemLookUpEdit();
                    macLookupImage.ShowFooter = false;
                    macLookupImage.NullText = "";
                    macLookupImage.TextEditStyle = TextEditStyles.Standard; //Enable edit
                    var macSource = GetMacAddress().Values.ToList();
                    macLookupImage.DropDownRows = macSource.Count > 8 ? 8 : macSource.Count; //Limit rows
                    macLookupImage.DataSource = macSource;
                    macLookupImage.CustomDrawCell += MacLookupImage_CustomDrawCell;
                    macLookupImage.CustomDisplayText += MacLookupImage_CustomDisplayText;
                    row.Properties.RowEdit = macLookupImage;
                    break;

                case EditorType.MacGridLookUp:
                    RepositoryItemGridLookUpEdit macGridLookup = new RepositoryItemGridLookUpEdit();
                    macGridLookup.ShowFooter = false;//Hide "X" button in bottom
                    macGridLookup.NullText = "";
                    macGridLookup.TextEditStyle = TextEditStyles.Standard; //Enable user edit value
                    macGridLookup.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True; //Accept text value

                    //Create sample data
                    var macList = GetMacAddress();
                    List<MacInfo> macInfoList = new List<MacInfo>();
                    int iImageIndex = 0;
                    foreach (var item in macList)
                    {
                        iImageIndex += 1;
                        var info = new MacInfo();
                        info.image = csPublic.imageCollection.Images[iImageIndex % 4];
                        info.Name = item.Key;
                        info.Value = item.Value;
                        macInfoList.Add(info);
                    }
                    macGridLookup.DataSource = macInfoList;

                    //Set value members (Must have)
                    macGridLookup.DisplayMember = nameof(MacInfo.Value);
                    macGridLookup.ValueMember = nameof(MacInfo.Value);

                    //Set view
                    macGridLookup.View.OptionsView.ShowColumnHeaders = false; //Hide header
                    macGridLookup.View.OptionsView.ShowIndicator = false;
                    macGridLookup.View.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
                    macGridLookup.View.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;

                    //Set column
                    macGridLookup.PopulateViewColumns();//Must have to make sure column exist
                    macGridLookup.View.Columns[nameof(MacInfo.image)].Width = 20;//Set image width

                    macGridLookup.CustomDrawButton += MacGridLookup_CustomDrawButton;


                    row.Properties.RowEdit = macGridLookup;
                    break;



                case EditorType.MacImageComboList:
                    RepositoryItemImageComboBox MacImageComboList = new RepositoryItemImageComboBox();
                    MacImageComboList.SmallImages = csPublic.imageCollection;
                    var dictData = GetMacAddress();
                    int iIndex = 0;
                    foreach (var item in dictData)
                    {
                        iIndex += 1;
                        ImageComboBoxItem imageItem = new ImageComboBoxItem();
                        imageItem.Value = item.Value;
                        imageItem.Description = item.Value;
                        imageItem.ImageIndex = iIndex % 4;
                        MacImageComboList.Items.Add(imageItem);
                    }

                    //Forcely set text editor, won't show text if not focused
                    //FieldInfo field = MacImageComboList.GetType().GetField("fTextEditStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                    //if (field != null) field.SetValue(MacImageComboList, TextEditStyles.Standard);

                    row.Properties.RowEdit = MacImageComboList;
                    break;

                case EditorType.Number:
                    RepositoryItemTextEdit repositoryNumberEdit = new RepositoryItemTextEdit();

                    //Load mask settings
                    repositoryNumberEdit.Mask.MaskType = editor.MaskType;
                    repositoryNumberEdit.Mask.UseMaskAsDisplayFormat = true;
                    repositoryNumberEdit.Mask.EditMask = editor.MaskString;

                    repositoryNumberEdit.ValidateOnEnterKey = true;
                    row.Properties.RowEdit = repositoryNumberEdit;
                    break;

                case EditorType.NumberSpin:
                    RepositoryItemSpinEdit repositoryNumberSpin = new RepositoryItemSpinEdit();

                    //Load mask settings
                    repositoryNumberSpin.Mask.MaskType = editor.MaskType;
                    repositoryNumberSpin.Mask.UseMaskAsDisplayFormat = true;
                    repositoryNumberSpin.Mask.EditMask = editor.MaskString;
                    repositoryNumberSpin.MinValue = (decimal)editor.Min;
                    repositoryNumberSpin.MaxValue = (decimal)editor.Max;
                    row.Properties.RowEdit = repositoryNumberSpin;
                    break;

                case EditorType.Text:
                    string sText = row.Properties.FieldName;
                    RepositoryItemTextEdit textEdit_Text = new RepositoryItemTextEdit();
                    if (editor.IsCustomMaskEnable)
                    {
                        textEdit_Text.Mask.UseMaskAsDisplayFormat = true;
                        textEdit_Text.Mask.MaskType = editor.MaskType;
                        textEdit_Text.Mask.EditMask = editor.MaskString;
                    }
                    row.Properties.RowEdit = textEdit_Text;
                    break;

                case EditorType.ToggleSwitch:
                    row.Properties.RowEdit = new RepositoryItemToggleSwitch();
                    break;

                case EditorType.ToggleSwitchList:
                    RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();
                    row.Properties.Caption = $"Device {editor.IntValue + 1}";
                    row.Properties.RowEdit = new RepositoryItemToggleSwitch();
                    Debug.Write("ToggleSwitchList:" + row.Properties.FieldName + ":");
                    break;

                default:
                    break;
            }
        }

        private void MacGridLookup_CustomDrawButton(object sender, CustomDrawButtonEventArgs e)
        {
            var x = e.Bounds;
        }

        private void MacLookupImage_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            //e.DisplayText = "      " + e.DisplayText; //Save space for image
        }

        private void MacLookupImage_CustomDrawCell(object sender, DevExpress.XtraEditors.Popup.LookUpCustomDrawCellArgs e)
        {
            int iImageIndex = e.RowIndex < 0 ? 0 : e.RowIndex % 4;
            var rect = e.Bounds; //Get current cell location
            var img = csPublic.imageCollection.Images[iImageIndex];
            e.Cache.DrawImage(img, rect.X, rect.Y, 16, 16);
            e.DisplayText = "      " + e.DisplayText; //Save space for image
        }



        /// <summary>
        /// Get mac address info
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetMacAddress()
        {
            Dictionary<string, string> sList = new Dictionary<string, string>();

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    string sName = netInterface.Name;
                    byte[] bData = netInterface.GetPhysicalAddress().GetAddressBytes();
                    string sMac = BitConverter.ToString(bData);
                    sList.Add(sName, sMac);
                }
            }

            return sList;
        }

    }






}
