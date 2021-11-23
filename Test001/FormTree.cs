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
        public List<InputField> ColumnDefinition;
        public InputField SampleNode;//Used for generate sample data
        public FormTree()
        {
            InitializeComponent();
        }

        private void FormTree_Load(object sender, EventArgs e)
        {
            SampleNode = new InputField();

            //Get data
            ColumnDefinition = ClassPublic.winMain.ColumnDefinition;

            //Add column
            CustomFieldsDefinitionTreeList.Columns.AddVisible(nameof(InputField.Name));
            CustomFieldsDefinitionTreeList.Columns.AddVisible(nameof(InputField.Description));
            CustomFieldsDefinitionTreeList.Columns.AddVisible(nameof(InputField.Position));
            CustomFieldsDefinitionTreeList.Columns.AddVisible(nameof(InputField.Length));

            //Add notes
            for (int i = 0; i < ColumnDefinition.Count; i++)
            {
                InputField inputField = ColumnDefinition[i];
                //var parentNode = treeList1.Nodes.Add(GetNodeData(inputField));
                var parentNode = CustomFieldsDefinitionTreeList.AppendNode(GetNodeData(inputField),null);

                for (int j = 0; j < inputField.CustomFields.Count; j++)
                {
                    //Add first line
                    var customField = inputField.CustomFields[j];
                    //parentNode.Nodes.Add(GetNodeData(customField));
                    CustomFieldsDefinitionTreeList.AppendNode(GetNodeData(customField), parentNode);
                }
            }

           

            //Init events
            CustomFieldsDefinitionTreeList.RowClick += CustomFieldsDefinitionTreeList_RowClick;
            CustomFieldsDefinitionTreeList.SelectionChanged += CustomFieldsDefinitionTreeList_SelectionChanged;
            CustomFieldsDefinitionTreeList.CellValueChanged += CustomFieldsDefinitionTreeList_CellValueChanged;
            CustomFieldsDefinitionTreeList.FocusedNodeChanged += CustomFieldsDefinitionTreeList_FocusedNodeChanged;
            CustomFieldsDefinitionTreeList.KeyDown += CustomFieldsDefinitionTreeList_KeyDown;
        }


        private void LoadCustomColumnConfig()
        {
            CustomFieldsDefinitionTreeList.ClearNodes();

            //Load column config
            for (int i = 0; i < ColumnDefinition.Count; i++)
            {
                InputField inputField = ColumnDefinition[i];
                //var parentNode = treeList1.Nodes.Add(GetNodeData(inputField));
                var parentNode = CustomFieldsDefinitionTreeList.AppendNode(GetNodeData(inputField), null);

                for (int j = 0; j < inputField.CustomFields.Count; j++)
                {
                    //Add first line
                    var customField = inputField.CustomFields[j];
                    //parentNode.Nodes.Add(GetNodeData(customField));
                    CustomFieldsDefinitionTreeList.AppendNode(GetNodeData(customField), parentNode);
                }
            }
        }

        private void CustomFieldsDefinitionTreeList_KeyDown(object sender, KeyEventArgs e)
        {
            //Check delete action
            if (e.KeyData == Keys.Delete)
            {
                //Check selection
                var iSelectionCount = CustomFieldsDefinitionTreeList.Selection.Count;
                if (iSelectionCount != 1) return;

                //Get node locaton
                var location = GetNodePosition(CustomFieldsDefinitionTreeList.Selection[0]);

                //Remove current node
                CustomFieldsDefinitionTreeList.DeleteSelectedNodes();

                //Remove settings
                var result = RemoveFieldDefinition(location);
                if (!result.IsSuccess)
                {
                    LoadCustomColumnConfig(); //Reload values
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
            Debug.WriteLine("Value changed");
            //Ignore program value change
            if (!e.ChangedByUser) return;

            Debug.WriteLine("Value changed");
            ModifyFieldDefinition(e.Node,e.Column);
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
                int iIndex= CustomFieldsDefinitionTreeList.GetNodeIndex(Node);
                return new Point(iIndex,-1);
            }

            //Get parent node
            var parentNode = Node.ParentNode;
            int iParent = CustomFieldsDefinitionTreeList.GetNodeIndex(parentNode);
            var iSub = CustomFieldsDefinitionTreeList.GetNodeIndex(Node);

            return new Point(iParent, iSub);
        }

        private object[] GetNodeData(InputField field)
        {
            return new object[] { field.Name, field.Description, field.Position, field.Length };
        }



        private void FormTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassPublic.winTree = null;
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
            if (FieldLocation.X<-1||FieldLocation.Y<-1)
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
                    ColumnDefinition.RemoveAt(FieldLocation.X);
                }
                else
                {
                    //Only remove custom field
                    ColumnDefinition[FieldLocation.X].CustomFields.RemoveAt(FieldLocation.Y);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RemoveFieldDefinition:\r\n"+ ex.Message);
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
            var location = GetNodePosition(CustomFieldsDefinitionTreeList.Selection[0]);

            //If sub node selected, add a sub node
            if (IsSubNode)
            {
                //No main node exist, do nothing
                if (ColumnDefinition.Count<1)
                {
                    return;
                }

                //Check if a main node selected
                if (location.X < 0 || location.X > (ColumnDefinition.Count - 1))
                {
                    //Nothing selected, simply add to first node
                    //add a sub node
                    int iCount = CustomFieldsDefinitionTreeList.Nodes[0].Nodes.Count;
                    var field = new InputField($"Custom_{1}_{iCount+1}");
                    var nodeValue = GetNodeData(field);
                    var node = CustomFieldsDefinitionTreeList.Nodes[location.X].Nodes.Add(nodeValue);//Add to UI
                    CustomFieldsDefinitionTreeList.Nodes[0].Expand();//Expand first node
                    ColumnDefinition[0].CustomFields.Add(field); //Add to config data
                }
                else
                {
                    //Add to selected node
                    //add a sub node
                    int iCount = CustomFieldsDefinitionTreeList.Nodes[location.X].Nodes.Count;
                    var field = new InputField($"Custom_{location.X+1}_{iCount + 1}");
                    var nodeValue = GetNodeData(field);
                    var node = CustomFieldsDefinitionTreeList.Nodes[location.X].Nodes.Add(nodeValue);//Add to UI
                    CustomFieldsDefinitionTreeList.Nodes[location.X].Expand();//Expand current main node
                    ColumnDefinition[location.X].CustomFields.Add(field); //Add to config data
                }
            }
            //Option to add main node
            else
            {
                int iID = ColumnDefinition.Count;
                var field = new InputField($"Field_{iID+1}");
                var nodeValue = GetNodeData(field);
                CustomFieldsDefinitionTreeList.Nodes.Add(nodeValue);//Add to UI
                ColumnDefinition.Add(field);//Add to config
            }
         
        }


        /// <summary>
        /// Update setting when value changed
        /// </summary>
        private void ModifyFieldDefinition(TreeListNode node,TreeListColumn column)
        {
            //Tree list node
            var location = GetNodePosition(node);

            //Try update config value
            try
            {
                //Main field selected
                if (location.Y == -1)
                {
                    InputField field = ColumnDefinition[location.X]; //Get main node
                    SetFieldValue(node,column, field); //Set main node value
                }
                //Sub field selected
                else
                {
                    InputField field = ColumnDefinition[location.X].CustomFields[location.Y]; //Get sub node
                    SetFieldValue(node, column, field); //Set sub node value
                }

                //Show value change
                Debug.WriteLine($"Value changed:{location.X},{location.Y},{node.GetValue(column).ToString()}");
            }
            catch (Exception ex)
            {
                LoadCustomColumnConfig(); //reload setting
                Debug.WriteLine("ModifyFieldDefinition:\r\n"+ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Auto set input field value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="column"></param>
        /// <param name="field"></param>
        private void SetFieldValue(TreeListNode node, TreeListColumn column, InputField field)
        {
            switch (column.Name)
            {
                case "col"+nameof(InputField.Name):
                    field.Name = node.GetValue(column).ToString();
                    break;
                case "col"+nameof(InputField.Description):
                    field.Description = node.GetValue(column).ToString();
                    break;
                case "col"+nameof(InputField.Position):                   
                    field.Position = int.Parse(node.GetValue(column).ToString());
                    break;
                case "col"+nameof(InputField.Length):
                    field.Length = int.Parse(node.GetValue(column).ToString());
                    break;
                default:
                    break;
            }


        }

        private void bReload_Click(object sender, EventArgs e)
        {
            LoadCustomColumnConfig();
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
            CustomFieldsDefinitionTreeList.ExpandAll();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            CustomFieldsDefinitionTreeList.CollapseAll();
        }
    }
}
