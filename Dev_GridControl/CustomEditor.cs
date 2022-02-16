using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev_GridControl
{
    public partial class CustomEditor : Form
    {
        public Dictionary<string,string> TemplateListBuffer { get; set; }
        public string sTemplateCaptain { get; set; }
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
            TemplateListBuffer = new Dictionary<string,string>();
            for (int i = 0; i < 3; i++)
            {
                TemplateListBuffer.Add($"ABC_{0 + i}","");
            }

            sTemplateCaptain = "Template";
            sCommandCaption = "Command";
        }

        private void InitControls()
        {
            //Set grid properties
            TemplateGridControl.DataSource = TemplateListBuffer;
            TemplateGridView.OptionsView.ShowGroupPanel = false; //User don't see group panel
            TemplateGridView.OptionsView.ShowIndicator = false; //Hide row header
            TemplateGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom; //New row can be added
            TemplateGridView.OptionsView.ShowButtonMode = ShowButtonModeEnum.ShowAlways; //Always show button
            TemplateGridView.OptionsBehavior.Editable = true; //Enable input
            TemplateGridView.Columns[0].Caption = sTemplateCaptain;
            TemplateGridView.Columns.Add(new GridColumn());
            TemplateGridView.Columns[1].Caption = sCommandCaption;
            TemplateGridView.Columns[1].MaxWidth = 160;
         
            TemplateGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;//Center header text
            TemplateGridView.Appearance.Row.TextOptions.HAlignment = HorzAlignment.Near;//Center header text
            TemplateGridView.OptionsCustomization.AllowFilter = false;
            TemplateGridView.OptionsCustomization.AllowSort = false;
            //TemplateGridView.OptionsBehavior.EditingMode = GridEditingMode.EditFormInplace;

            //Set custom editor
            RepositoryItemButtonEdit buttonEditor = new RepositoryItemButtonEdit();
            buttonEditor.Buttons.Clear();
            //buttonEditor.Buttons.AddRange(new EditorButton[] {
            //new EditorButton(ButtonPredefines.Plus, "Edit", -1, true, true, false, ImageLocation.MiddleLeft, DemoHelper.GetEditImage()),
            //new EditorButton(ButtonPredefines.Delete, "Delete", -1, true, true, false, ImageLocation.MiddleLeft, DemoHelper.GetDeleteImage())});

            buttonEditor.Buttons.Add(new EditorButton(ButtonPredefines.Plus, "Add the cell"));
            buttonEditor.Buttons.Add(new EditorButton(ButtonPredefines.Delete, "Delete the cell"));
            buttonEditor.Buttons[0].Caption = "Text1";
            buttonEditor.Buttons[1].Caption = "Text2";
            buttonEditor.Buttons[0].Appearance.ForeColor = Color.Green;
            buttonEditor.Buttons[1].Appearance.ForeColor = Color.Red;
            buttonEditor.Buttons[0].ImageOptions.Location = ImageLocation.MiddleRight;
            buttonEditor.Buttons[1].ImageOptions.Location = ImageLocation.MiddleRight;
            buttonEditor.Buttons[0].Click += CustomEditorButton1_Click;
            buttonEditor.Buttons[1].Click += CustomEditorButton2_Click;
            buttonEditor.TextEditStyle = TextEditStyles.HideTextEditor; //Only display button

            TemplateGridView.CustomRowCellEdit += (s, e) =>
            {
                if (e.Column.Caption == sCommandCaption)
                {
                    e.RepositoryItem = buttonEditor;
                }
            };
        }

        private void CustomEditorButton1_Click(object sender, EventArgs e)
        {
            EditorButton editorButton = (EditorButton)sender;
            int iRow = TemplateGridView.FocusedRowHandle;
            // string sValue = TemplateGridView.GetRowCellValue(iRow, TemplateGridView.Columns[0]).ToString();

        }

        private void CustomEditorButton2_Click(object sender, EventArgs e)
        {

        }


    }
}
