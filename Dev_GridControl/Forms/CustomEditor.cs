using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl
{
    public partial class CustomEditor : Form
    {
        public List<DataRowView> TemplateListBuffer { get; set; }
        public string sCommandCaption { get; set; }
        public CustomEditor()
        {
            InitializeComponent();
        }

        private void CustomEditor_Load(object sender, EventArgs e)
        {
            InitVariables();
            InitControls();
        }

        private void InitVariables()
        {
            //Create sample data
            TemplateListBuffer = new List<DataRowView>();
            for (int i = 0; i < 3; i++)
            {
                var RowView = new DataRowView();
                RowView.Name = $"ABC_{ 0 + i}";
                RowView.Description = "ABC_123";
                RowView.GridLookup = "TestLookup";
                TemplateListBuffer.Add(RowView);

            }

            sCommandCaption = "Command";
        }

        private void InitControls()
        {
            //Init variables
            csPublic.InitGridviewWithDefaultSettings(TemplateGridView, true);

            //Set grid properties
            TemplateGridControl.DataSource = TemplateListBuffer;
            TemplateGridView.RowHeight = 32;
            int iCMDColumn = TemplateGridView.Columns.Add(new GridColumn());
            var descColumn = TemplateGridView.Columns[nameof(DataRowView.Description)];
            descColumn.OptionsColumn.ReadOnly = true; //Diable edit
            TemplateGridView.OptionsView.ShowIndicator = true; //show row header
            TemplateGridView.OptionsView.ShowButtonMode = ShowButtonModeEnum.ShowAlways; //Always show button

            //Set column
            TemplateGridView.Columns[iCMDColumn].Caption = sCommandCaption;
            TemplateGridView.Columns[iCMDColumn].MaxWidth = 160;
            TemplateGridView.Columns[iCMDColumn].Visible = true; //Must have to be seen
            TemplateGridView.OptionsCustomization.AllowFilter = false;
            TemplateGridView.OptionsCustomization.AllowSort = false;


            //Preview keydown
            TemplateGridControl.PreviewKeyDown += TemplateGridControl_PreviewKeyDown;
            TemplateGridView.RowCellStyle += TemplateGridView_RowCellStyle;

            //Create ImageComboEdit
            var comboBoxEdit = InitImageComboBoxEditor();

            //Set custom editor
            var buttonEditor = InitButtonEdit();

            //Create switch
            RepositoryItemToggleSwitch toggleSwitch = new RepositoryItemToggleSwitch();

            //Set gridlookupedit
            var gridLookup = InitGridLookupEdit();


            TemplateGridView.CustomRowCellEdit += (s, e) =>
            {
                if (e.Column.Caption == sCommandCaption)
                {
                    e.RepositoryItem = buttonEditor;

                }
                //ComboBox Edit
                else if (e.Column.FieldName == nameof(DataRowView.Function))
                {
                    e.RepositoryItem = comboBoxEdit;
                }
                else if (e.Column.FieldName == nameof(DataRowView.Enable))
                {
                    e.RepositoryItem = toggleSwitch;
                }
                else if (e.Column.FieldName == nameof(DataRowView.GridLookup))
                {
                    e.RepositoryItem = gridLookup;
                }
            };

        }



        private RepositoryItemGridLookUpEdit InitGridLookupEdit()
        {
            RepositoryItemGridLookUpEdit gridLookUpEdit = new RepositoryItemGridLookUpEdit();
            List<LookupRow> rows = new List<LookupRow>();
            for (int i = 0; i < 5; i++)
            {
                var row1 = new LookupRow();
                row1.Index = i;
                row1.Value = "Value_" + i;
                rows.Add(row1);
            }
            //gridLookUpEdit.
            gridLookUpEdit.ShowFooter = false;//Hide "X" button in bottom
            gridLookUpEdit.TextEditStyle = TextEditStyles.Standard; //Enable user edit value
            gridLookUpEdit.DataSource = rows;
            gridLookUpEdit.ValueMember = nameof(LookupRow.Value);
            gridLookUpEdit.DisplayMember = nameof(LookupRow.Value);
            gridLookUpEdit.AcceptEditorTextAsNewValue = DefaultBoolean.True;//User input can be accepted
            gridLookUpEdit.View.CustomDrawCell += View_CustomDrawCell;


            return gridLookUpEdit;
        }

        private void View_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            var image = Properties.Resources.apply_32x32;
            var image2 = Properties.Resources.apply_16x16;

            if (e.Column.FieldName == nameof(LookupRow.Index))
            {
                //e.DefaultDraw();
                e.Cache.DrawImage(image2, 20, 20, 16, 16);
                //e.Handled = true;//Disable default draw
            }



        }

        private void TemplateGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var columnDesc = TemplateGridView.Columns[nameof(DataRowView.Description)];
            if (columnDesc == null) return;

            if (e.Column == columnDesc)
            {
                e.Appearance.ForeColor = Color.Green;
            }
        }

        private void TemplateGridControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Debug.WriteLine("TemplateGridControl_PreviewKeyDown:" + e.KeyCode);

            if (e.KeyCode == Keys.Delete)
            {
                DeleteKeyDownOperation();
            }
        }

        private void DeleteKeyDownOperation()
        {
            int iSelection = TemplateGridView.FocusedRowHandle;
            if (iSelection >= 0)
            {//Delete current row
                TemplateListBuffer.RemoveAt(iSelection);
            }
            else
            {//No selection
                if (TemplateListBuffer.Count > 0)
                {
                    //Delate last row
                    TemplateListBuffer.RemoveAt(TemplateListBuffer.Count - 1);
                }
                else
                {
                    //do nothing
                }
            }

            TemplateGridControl.RefreshDataSource();
        }

        private RepositoryItemImageComboBox InitImageComboBoxEditor()
        {
            //Set combo box editor
            RepositoryItemImageComboBox templateSelectionComboBox = new RepositoryItemImageComboBox();
            templateSelectionComboBox.Items.Clear();
            templateSelectionComboBox.SmallImages = imageCollection1;


            for (int i = 0; i < 3; i++)
            {
                ImageComboBoxItem item = new ImageComboBoxItem();
                item.Description = $"Function{i + 1}"; //Display Value
                item.Value = item.Description; //Must have, actual value
                item.ImageIndex = i;
                templateSelectionComboBox.Items.Add(item);
            }

            //Forcely set text editor
            FieldInfo field = templateSelectionComboBox.GetType().GetField("fTextEditStyle", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            if (field != null) field.SetValue(templateSelectionComboBox, TextEditStyles.Standard);


            templateSelectionComboBox.CustomDrawButton += TemplateSelectionComboBox_CustomDrawButton;

            //Enable custom display
            //var button = (RepositoryItemButtonEdit)templateSelectionComboBox;
            //button.Tag = templateSelectionComboBox;
            //button.CustomDrawButton += Button_CustomDrawButton;


            //Set combobox event
            templateSelectionComboBox.SelectedIndexChanged += TemplateSelectionComboBox_SelectedIndexChanged;
            templateSelectionComboBox.CustomDisplayText += TemplateSelectionComboBox_CustomDisplayText;


            return templateSelectionComboBox;
        }

        private void TemplateSelectionComboBox_CustomDrawButton(object sender, CustomDrawButtonEventArgs e)
        {
            var comboBox = sender as RepositoryItemImageComboBox;

            var areaButton = e.Bounds;
            var newFont = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);

            e.Graphics.DrawString("ABC", newFont, new SolidBrush(Color.Black), areaButton.Location.X-50, areaButton.Location.Y+10);
        }

        private void Button_CustomDrawButton(object sender, CustomDrawButtonEventArgs e)
        {
            var buttonEdit = sender as RepositoryItemButtonEdit;
            var areaButton = e.Bounds;
            var newFont = new Font(new FontFamily("Arial"), 8, FontStyle.Regular);

            e.Graphics.DrawString("123", newFont, new SolidBrush(Color.Black), areaButton.Location);
        }

 

        private void TemplateSelectionComboBox_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
        }

        private void TemplateSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get row value
                int iRow = TemplateGridView.FocusedRowHandle;
                var ComboBox = (ImageComboBoxEdit)sender;
                var selectedItem = (ImageComboBoxItem)ComboBox.SelectedItem;

                //Add or create row based on selection
                if (iRow >= 0)
                {
                    //Get current row
                    var selectedRow = TemplateListBuffer[iRow];

                    //Edit current row
                    UpdateSelectionRowView(selectedItem, ref selectedRow);
                }
                else
                {
                    //No selection, directly create layout
                    var newRow = CreateSelectionRowView(selectedItem);
                    TemplateListBuffer.Add(newRow);
                }

                //Refresh display
                TemplateGridView.RefreshData();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TemplateSelectionComboBox_SelectedIndexChanged:\r\n" + ex.Message);
            }
        }

        private DataRowView CreateSelectionRowView(ImageComboBoxItem selectedItem)
        {
            DataRowView rowView = new DataRowView();
            rowView.Name = $"Type{selectedItem.ImageIndex + 1}";
            rowView.Function = selectedItem.Value.ToString();
            return rowView;
        }

        private void UpdateSelectionRowView(ImageComboBoxItem selectedItem, ref DataRowView selectedRow)
        {
            //No related value change required

        }




        private RepositoryItemButtonEdit InitButtonEdit()
        {
            //Set custom editor
            RepositoryItemButtonEdit buttonEditor = new RepositoryItemButtonEdit();
            buttonEditor.Buttons.Clear();
            buttonEditor.Buttons.Add(new EditorButton(ButtonPredefines.Plus, "Add the cell"));
            buttonEditor.Buttons.Add(new EditorButton(ButtonPredefines.Glyph, "Delete the cell"));
            buttonEditor.Buttons[0].Caption = "Text1";
            buttonEditor.Buttons[1].Caption = "Text2";
            buttonEditor.Buttons[1].ImageOptions.SvgImage = Properties.Resources.open;
            buttonEditor.Buttons[0].Appearance.ForeColor = Color.Green;
            buttonEditor.Buttons[1].Appearance.ForeColor = Color.Red;
            buttonEditor.Buttons[0].ImageOptions.Location = ImageLocation.MiddleRight;
            buttonEditor.Buttons[1].ImageOptions.Location = ImageLocation.MiddleRight;
            buttonEditor.Buttons[0].Click += CustomEditorButton1_Click;
            buttonEditor.Buttons[1].Click += CustomEditorButton2_Click;
            buttonEditor.TextEditStyle = TextEditStyles.HideTextEditor; //Only display button
            return buttonEditor;
        }

        private void CustomEditorButton1_Click(object sender, EventArgs e)
        {
            EditorButton editorButton = (EditorButton)sender;
            int iRow = TemplateGridView.FocusedRowHandle;
            // string sValue = TemplateGridView.GetRowCellValue(iRow, TemplateGridView.Columns[0]).ToString();

        }

        private void CustomEditorButton2_Click(object sender, EventArgs e)
        {
            //Select new item row
            TemplateGridView.FocusedRowHandle = GridControl.NewItemRowHandle;
        }

        public class DataRowView
        {
            [DisplayName("Template Name")]
            public string Name { get; set; }
            public string Description { get; set; }
            [DisplayName("Function ImageComboBox")]
            public string Function { get; set; }
            [DisplayName("Enable Switch")]
            public bool Enable { get; set; }

            [DisplayName("String GridLookup")]
            public string GridLookup { get; set; }

            public DataRowView()
            {
                GridLookup = "";
            }


        }

        public class LookupRow
        {
            public int Index { get; set; }
            public string Value { get; set; }

        }

        private void bMultiSelect_Click(object sender, EventArgs e)
        {
            bool bMultiSelection = TemplateGridView.OptionsSelection.MultiSelect;
            TemplateGridView.OptionsSelection.MultiSelect = !bMultiSelection;
        }
    }
}
