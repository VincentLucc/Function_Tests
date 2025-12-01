using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace TreeList.Forms
{
    public partial class PopupEditorForm : DevExpress.XtraEditors.XtraForm
    {
        public List<csTreeItem> TreeItems = new List<csTreeItem>();

        public PopupEditorForm()
        {
            InitializeComponent();

            //Add some sample
            //for (int i = 0; i < 3; i++)
            //{
            //    var sItem = new csTreeItem();
            //    sItem.Name = $"Main_{i}";

            //    for (int j = 0; j < 3; j++)
            //    {
            //        var subItem = new csTreeItem()
            //        {
            //            Name = $"Sub_{i}",
            //        };

            //        sItem.SubItems.Add(subItem);
            //    }

            //    TreeItems.Add(sItem);
            //}

            //Init events
            treeList1.EditFormShowing += TreeList1_EditFormShowing; //Trigger before [EditFormPrepared]
            treeList1.EditFormPrepared += TreeList1_EditFormPrepared; //Trigger after [EditFormShowing]
        }

        private void TreeList1_EditFormPrepared(object sender, EditFormPreparedEventArgs e)
        {

        }

        private void PopupEditor_Load(object sender, EventArgs e)
        {

            treeList1.OptionsView.NewItemRowPosition = TreeListNewItemRowPosition.Bottom;
            treeList1.OptionsBehavior.Editable = true;
            treeList1.ChildListFieldName = nameof(csTreeItem.SubItems);
            treeList1.DataSource = TreeItems;

            //Enable edit
            treeList1.PopulateColumns();
            foreach (var treeCOlumn in treeList1.Columns)
            {
                treeCOlumn.OptionsColumn.AllowEdit = true;
                treeCOlumn.OptionsColumn.ReadOnly = false;
            }


            //Set custom form
            treeList1.OptionsEditForm.CustomEditFormLayout?.Dispose();
            treeList1.OptionsBehavior.EditingMode = TreeListEditingMode.EditForm;
            treeList1.OptionsEditForm.CustomEditFormLayout = new PropertyEditorUserControl();

            //手动处理新行
            //数据为0时，新行不显示
            treeList1.MouseDoubleClick += TreeList1_MouseDoubleClick;
            //New iTem row only click once
            treeList1.MouseClick += TreeList1_MouseClick;
        }



        private void TreeList1_EditFormShowing(object sender, EditFormShowingEventArgs e)
        {//Prepare data
            //Get editor
            if (!(treeList1.OptionsEditForm.CustomEditFormLayout is PropertyEditorUserControl propertyEditorUserControl)) return;

            var record = treeList1.GetDataRecordByNode(e.Node);
            if (record is csTreeItem treeItem)
            {
                propertyEditorUserControl.UpdateSelection(treeItem);
            }
        }


        private void TreeList1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }

        private void TreeList1_MouseClick(object sender, MouseEventArgs e)
        {
            //When click
            var hitInfo = treeList1.CalcHitInfo(e.Location);

            //Only handle the first note
            //Must have at least one note to trigger [EditForm]
            if (hitInfo.Node is TreeListNewItemNode newItemNode && TreeItems.Count == 0)
            {
                //Binding list,自动显示EditForm
                TreeItems.Add(new csTreeItem());
            }

        }
    }
}