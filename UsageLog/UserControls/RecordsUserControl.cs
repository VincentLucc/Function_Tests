using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
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

namespace UsageLog.UserControls
{
    public partial class RecordsUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        public BindingList<csRecord> records = new BindingList<csRecord>();
        RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
        RepositoryItemButtonEdit catagoeyButtonEdit = new RepositoryItemButtonEdit();

        public RecordsUserControl()
        {
            InitializeComponent();
            this.Load += RecordsUserControl_Load;
        }

        private void RecordsUserControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitTreelist();
        }

        private void InitTreelist()
        {
            long lTick = DateTime.Now.Ticks;
            for (int i = 0; i < 10; i++)
            {
                var newRecord = new csRecord()
                {
                    UniqueID = lTick + i,
                    ParentID = -1,
                    Catagory = $"Category{(i + 1).ToString("d2")}",
                    Description = "",
                    Value = i,
                    RecordType = _recordType.Catagory
                };

                records.Add(newRecord);
            }

            InitRepositoryItem();

            treeList1.Columns.Clear();
            treeList1.DataSource = records;
            treeList1.PopulateColumns();
            treeList1.KeyFieldName = nameof(csRecord.UniqueID);
            treeList1.ParentFieldName = nameof(csRecord.ParentID);
            treeList1.StateImageList = NodeStateImageCollection;

            treeList1.CustomNodeCellEdit += TreeList1_CustomNodeCellEdit;
            treeList1.CustomColumnDisplayText += TreeList1_CustomColumnDisplayText;
            treeList1.ShowingEditor += TreeList1_ShowingEditor;
            treeList1.GetStateImage += TreeList1_GetStateImage;
            treeList1.CustomDrawNodeCell += TreeList1_CustomDrawNodeCell;
        }

        private void TreeList1_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node == null) return;
            var record = (csRecord)treeList1.GetDataRecordByNode(e.Node);
            if (record.RecordType==_recordType.Catagory)
            {
                e.NodeImageIndex = 0;
            }
            else if (record.RecordType==_recordType.Item)
            {
                e.NodeImageIndex = 1;
            }
        }

        /// <summary>
        /// Paint the item type icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
             
        }

        /// <summary>
        /// Disable editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void TreeList1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var curColumn = treeList1.FocusedColumn;
            var curNode = treeList1.FocusedNode;
            if (curColumn.FieldName == nameof(csRecord.Time))
            {
                var record = (csRecord)treeList1.GetDataRecordByNode(curNode);
                if (record.RecordType == _recordType.Catagory)
                {//Don't show editors
                    e.Cancel = true;
                }
            }
        }

        private void InitRepositoryItem()
        {
            catagoeyButtonEdit.Buttons.Clear();
            var addButton = new EditorButton(ButtonPredefines.Plus);
            var clearButton = new EditorButton(ButtonPredefines.Search);
            var deleteButton = new EditorButton(ButtonPredefines.Delete);
            catagoeyButtonEdit.Buttons.AddRange(new EditorButton[] { addButton, clearButton, deleteButton });
            addButton.Click += AddButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var curNode = treeList1.FocusedNode;
            var record = (csRecord)treeList1.GetDataRecordByNode(curNode);
            using (AddForm add = new AddForm(record.UniqueID))
            {
                if (add.ShowDialog() == DialogResult.OK)
                {
                    records.Add(add.Record);
                    if (!curNode.Expanded) curNode.Expand();
                }
            }
        }

        /// <summary>
        /// Set display text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Node == null) return;
                var record = (csRecord)treeList1.GetDataRecordByNode(e.Node);

                if (e.Column.FieldName == nameof(csRecord.Time))
                {
                    if (record.RecordType == _recordType.Catagory)
                    {
                        e.DisplayText = "";
                    }
                    else if (record.RecordType == _recordType.Item)
                    {//Show local time
                        if (e.Value is DateTimeOffset)
                        {
                            var timeOffset = (DateTimeOffset)e.Value;
                            var timeLocal = timeOffset.ToLocalTime();
                            e.DisplayText = timeLocal.ToString();
                        }
                    }
                }
                else if (e.Column.FieldName == nameof(csRecord.Value))
                {
                    if (record.RecordType == _recordType.Catagory)
                    {
                        e.DisplayText = GetNoteTotalValue(e.Node).ToString("F2");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RecordsUserControl.TreeList1_CustomColumnDisplayText:\r\n" + ex.ToString());
            }

        }

        private double GetNoteTotalValue(TreeListNode treeNode)
        {
            //Get total value
            double dTotal = 0;
            foreach (TreeListNode subNode in treeNode.Nodes)
            {
                var subRecord = (csRecord)treeList1.GetDataRecordByNode(subNode);
                if (subRecord.RecordType == _recordType.Catagory)
                {
                    dTotal += GetNoteTotalValue(subNode);
                }
                else if (subRecord.RecordType == _recordType.Item)
                {
                    dTotal += subRecord.Value;
                }
            }
            return dTotal;
        }

        /// <summary>
        /// Set editors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeList1_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {

            var record = (csRecord)treeList1.GetDataRecordByNode(e.Node);

            if (e.Column.FieldName == nameof(csRecord.Time))
            {

                if (record.RecordType == _recordType.Catagory)
                {
                    e.RepositoryItem = textEdit;
                }
                else
                {
                    //Use default editor
                }

            }
            else if (e.Column.FieldName == nameof(csRecord.Catagory))
            {
                if (record.RecordType == _recordType.Catagory)
                {
                    e.RepositoryItem = catagoeyButtonEdit;
                }
            }

        }
    }
}
