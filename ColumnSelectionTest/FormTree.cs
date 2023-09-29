using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test001
{
    public partial class FormTree : Form
    {
        private DataFileSetting m_DataFileSetting;
        public InputField SampleNode;//Used for generate sample data
        public FormTree()
        {
            InitializeComponent();
        }

        private void FormTree_Load(object sender, EventArgs e)
        {
            SampleNode = new InputField();

            //Get data
            m_DataFileSetting = new DataFileSetting();
            m_DataFileSetting.InputFields = csPublic.winMain.ColumnDefinition;

            //Set field config tree list
            InitFieldConfigTreeList();
            UpdateFieldConfigTreeListVisibility();
            LoadFieldConfigTreeList();    

            //Init events
            DataFieldsConfigTreeList.RowClick += CustomFieldsDefinitionTreeList_RowClick;
            DataFieldsConfigTreeList.SelectionChanged += CustomFieldsDefinitionTreeList_SelectionChanged;
            DataFieldsConfigTreeList.CellValueChanged += CustomFieldsDefinitionTreeList_CellValueChanged;
            DataFieldsConfigTreeList.FocusedNodeChanged += CustomFieldsDefinitionTreeList_FocusedNodeChanged;
            DataFieldsConfigTreeList.CellValueChanging += DataFieldsConfigTreeList_CellValueChanging;
            DataFieldsConfigTreeList.KeyDown += CustomFieldsDefinitionTreeList_KeyDown;
        }

        private void DataFieldsConfigTreeList_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            Debug.WriteLine("Value changing");
            //Ignore program value change
            if (!e.ChangedByUser) return;
            
            Debug.WriteLine($"Value changing:{e.Value.ToString()}");
            ModifyFieldDefinition(e.Node, e.Column,e.Value);
        }


        /// <summary>
        /// Init tree list control properties
        /// </summary>
        private void InitFieldConfigTreeList()
        {
            //Init data structure
            DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.Name));
            DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.Description));
            DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.ColumnNumber));
            DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.Position));
            DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.Length));
            var column=DataFieldsConfigTreeList.Columns.AddVisible(nameof(InputField.IsHidden));
            column.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Boolean; //Set to show checkbox
        }

        /// <summary>
        /// Set visibility of the 
        /// </summary>
        private void UpdateFieldConfigTreeListVisibility()
        {
            if (m_DataFileSetting.Delimited)
            {
                DataFieldsConfigTreeList.Columns[nameof(InputField.Position)].Visible = false;
                DataFieldsConfigTreeList.Columns[nameof(InputField.Length)].Visible = false;
                DataFieldsConfigTreeList.Columns[nameof(InputField.ColumnNumber)].Visible = true;
            }
            else
            {            
                DataFieldsConfigTreeList.Columns[nameof(InputField.Position)].Visible = true;
                DataFieldsConfigTreeList.Columns[nameof(InputField.Length)].Visible = true;
                DataFieldsConfigTreeList.Columns[nameof(InputField.ColumnNumber)].Visible = false;
            }
        }

        private void LoadFieldConfigTreeList()
        {
            DataFieldsConfigTreeList.ClearNodes();
            //Load column config
            for (int i = 0; i < m_DataFileSetting.InputFields.Count; i++)
            {
                InputField inputField = m_DataFileSetting.InputFields[i];
                //var parentNode = treeList1.Nodes.Add(GetNodeData(inputField));
                var parentNode = DataFieldsConfigTreeList.AppendNode(GetNodeData(inputField), null);

                for (int j = 0; j < inputField.CustomFields.Count; j++)
                {
                    //Add first line
                    var customField = inputField.CustomFields[j];
                    //parentNode.Nodes.Add(GetNodeData(customField));
                    DataFieldsConfigTreeList.AppendNode(GetNodeData(customField), parentNode);
                }
            }
        }

        private void CustomFieldsDefinitionTreeList_KeyDown(object sender, KeyEventArgs e)
        {
            //Check delete action
            if (e.KeyData == Keys.Delete)
            {
                //Check selection
                var iSelectionCount = DataFieldsConfigTreeList.Selection.Count;
                if (iSelectionCount != 1) return;

                //Get node locaton
                var location = GetNodePosition(DataFieldsConfigTreeList.Selection[0]);

                //Remove current node
                DataFieldsConfigTreeList.DeleteSelectedNodes();

                //Remove settings
                var result = RemoveFieldDefinition(location);
                if (!result.IsSuccess)
                {
                    LoadFieldConfigTreeList(); //Reload values
                    MessageBox.Show("Error in removing record.\r\n" + result.Message);
                }

            }
        }

        private void CustomFieldsDefinitionTreeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            Debug.WriteLine("focus changed");
           var location= GetNodePosition(e.Node);
            Debug.WriteLine($"{location.X},{location.Y}");
        }

        private void CustomFieldsDefinitionTreeList_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            //Debug.WriteLine("Value changed");
            ////Ignore program value change
            //if (!e.ChangedByUser) return;

            //Debug.WriteLine("Value changed");
            //ModifyFieldDefinition(e.Node,e.Column);
        }

        private void CustomFieldsDefinitionTreeList_SelectionChanged(object sender, EventArgs e)
        {
            //var test = CustomFieldsDefinitionTreeList.Selection[0];
            //GetNodePosition(test);
        }

        private void CustomFieldsDefinitionTreeList_RowClick(object sender, DevExpress.XtraTreeList.RowClickEventArgs e)
        {
            //var test= CustomFieldsDefinitionTreeList.Selection[0];
            //GetNodePosition(test);
            
        }

        /// <summary>
        /// Get node position 
        /// Retuen Point(MainNode Index,SubNode Index)
        /// -1 mean not exist
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        private Point GetNodePosition(TreeListNode Node)
        {
            //Null check
            if (Node == null) return new Point(-1, -1);
 
            var level = Node.Level;
            //Check if current node is parent node
            if (Node.Level==0)
            {
                int iIndex= DataFieldsConfigTreeList.GetNodeIndex(Node);
                return new Point(iIndex,-1);
            }

            //Get parent node
            var parentNode = Node.ParentNode;
            int iParent = DataFieldsConfigTreeList.GetNodeIndex(parentNode);
            var iSub = DataFieldsConfigTreeList.GetNodeIndex(Node);

            return new Point(iParent, iSub);
        }

        private object[] GetNodeData(InputField field)
        {
            return new object[] { field.Name, field.Description, field.ColumnNumber, field.Position, field.Length ,false};
        }



        private void FormTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            csPublic.winTree = null;
        }


        /// <summary>
        /// Remove filed definition based on field location
        /// </summary>
        /// <param name="FieldLocation"></param>
        private GeneralResult RemoveFieldDefinition(Point FieldLocation)
        {
            //Init variables
            var result = new GeneralResult();

            //Check value
            if (FieldLocation.X < -1 || FieldLocation.Y < -1)
            {
                result.IsSuccess = false;
                result.Message = "Invalid index.";
                return result;
            }

            //Try to remove nodes
            try
            {
                //Check if main node selected
                if (FieldLocation.Y == -1)
                {//Main node selected, remove main node and sub nodes
                    m_DataFileSetting.InputFields.RemoveAt(FieldLocation.X);
                }
                else
                {
                    //Only remove custom field
                    m_DataFileSetting.InputFields[FieldLocation.X].CustomFields.RemoveAt(FieldLocation.Y);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RemoveFieldDefinition:\r\n" + ex.Message);
                result.IsSuccess = false;
                result.Message = ex.Message;
            }


            //Pass all steps
            result.IsSuccess = true;
            return result;
        }

        /// <summary>
        /// Add a main field or sub field based on user selection
        /// </summary>
        /// <param name="IsSubNode"></param>
        private void AddFieldDefinition(bool IsSubNode=false)
        {
            //Get node locaton
            var location = GetNodePosition(DataFieldsConfigTreeList.Selection[0]);

            //If sub node selected, add a sub node
            if (IsSubNode)
            {
                //No main node exist, do nothing
                if (m_DataFileSetting.InputFields.Count < 1)
                {
                    return;
                }

                //Check if a main node selected
                if (location.X < 0 || location.X > (m_DataFileSetting.InputFields.Count - 1))
                {
                    //Nothing selected, simply add to first node
                    //add a sub node
                    int iCount = DataFieldsConfigTreeList.Nodes[0].Nodes.Count;
                    var field = new InputField($"Custom_{1}_{iCount + 1}");
                    var nodeValue = GetNodeData(field);
                    var node = DataFieldsConfigTreeList.Nodes[location.X].Nodes.Add(nodeValue);//Add to UI
                    DataFieldsConfigTreeList.Nodes[0].Expand();//Expand first node
                    m_DataFileSetting.InputFields[0].CustomFields.Add(field); //Add to config data
                }
                else
                {
                    //Add to selected node
                    //add a sub node
                    int iCount = DataFieldsConfigTreeList.Nodes[location.X].Nodes.Count;
                    var field = new InputField($"Custom_{location.X + 1}_{iCount + 1}");
                    var nodeValue = GetNodeData(field);
                    var node = DataFieldsConfigTreeList.Nodes[location.X].Nodes.Add(nodeValue);//Add to UI
                    DataFieldsConfigTreeList.Nodes[location.X].Expand();//Expand current main node
                    m_DataFileSetting.InputFields[location.X].CustomFields.Add(field); //Add to config data
                }
            }
            //Option to add main node
            else
            {
                int iID = m_DataFileSetting.InputFields.Count;
                var field = new InputField($"Field_{iID + 1}");
                var nodeValue = GetNodeData(field);
                DataFieldsConfigTreeList.Nodes.Add(nodeValue);//Add to UI
                m_DataFileSetting.InputFields.Add(field);//Add to config
            }

        }


        /// <summary>
        /// Update setting when value changed
        /// </summary>
        private void ModifyFieldDefinition(TreeListNode node,TreeListColumn column,object Value)
        {
            //Tree list node
            var location = GetNodePosition(node);

            //Try update config value
            try
            {
                //Main field selected
                if (location.Y == -1)
                {
                    InputField field = m_DataFileSetting.InputFields[location.X]; //Get main node
                    TrySetFieldValue(field, column, Value); //Set main node value
                }
                //Sub field selected
                else
                {
                    InputField field = m_DataFileSetting.InputFields[location.X].CustomFields[location.Y]; //Get sub node
                    TrySetFieldValue(field, column, Value); //Set sub node value
                }

                //Show value change
                Debug.WriteLine($"Value changed:{location.X},{location.Y},{node.GetValue(column).ToString()}");
            }
            catch (Exception ex)
            {
                LoadFieldConfigTreeList(); //reload setting
                Debug.WriteLine("ModifyFieldDefinition:\r\n" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Auto set input field value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="column"></param>
        /// <param name="field"></param>
        private void TrySetFieldValue(InputField field,TreeListColumn column,object value )
        {
            switch (column.Name)
            {
                case "col" + nameof(InputField.Name):
                    field.Name = value.ToString();

                    break;
                case "col" + nameof(InputField.Description):
                    field.Description = value.ToString();
                    break;
                case "col" + nameof(InputField.ColumnNumber):
                    field.ColumnNumber = int.Parse(value.ToString());
                    break;
                case "col" + nameof(InputField.Position):
                    field.Position = int.Parse(value.ToString());
                    break;
                case "col" + nameof(InputField.Length):
                    field.Length = int.Parse(value.ToString());
                    break;
                case "col" + nameof(InputField.IsHidden):
                    field.IsHidden = bool.Parse(value.ToString());
                    break;
                default:
                    break;
            }

        }

        private void bReload_Click(object sender, EventArgs e)
        {
            LoadFieldConfigTreeList();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

            //Add node based on location
            AddFieldDefinition();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            AddFieldDefinition(true);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataFieldsConfigTreeList.ExpandAll();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DataFieldsConfigTreeList.CollapseAll();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            m_DataFileSetting.Delimited = !m_DataFileSetting.Delimited;

            //Update view
            UpdateFieldConfigTreeListVisibility();
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {

        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            bool bDisplayCustomField = toggleSwitch1.IsOn;
            Debug.WriteLine("toggle:"+ bDisplayCustomField);
        }
    }
}
