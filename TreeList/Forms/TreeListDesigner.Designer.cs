namespace TreeList_Tests.Forms
{
    partial class TreeListDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.GroupColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.GroupColumn,
            this.treeListColumn1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "Or",
            null}, -1);
            this.treeList1.AppendNode(new object[] {
            "And",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            null,
            "abc=1+2"}, 1);
            this.treeList1.AppendNode(new object[] {
            null,
            "abc=1+1+1"}, 1);
            this.treeList1.AppendNode(new object[] {
            null,
            "1>5"}, 1);
            this.treeList1.AppendNode(new object[] {
            "And",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            null,
            "abc=6-3"}, 5);
            this.treeList1.EndUnboundLoad();
            this.treeList1.Size = new System.Drawing.Size(614, 519);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // GroupColumn
            // 
            this.GroupColumn.Caption = "Group Type";
            this.GroupColumn.FieldName = "Group Type";
            this.GroupColumn.Name = "GroupColumn";
            this.GroupColumn.Visible = true;
            this.GroupColumn.VisibleIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Logic";
            this.treeListColumn1.FieldName = "LogicColumn";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 1;
            // 
            // TreeListDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 519);
            this.Controls.Add(this.treeList1);
            this.Name = "TreeListDesigner";
            this.Text = "TreeListDesigner";
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn GroupColumn;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
    }
}