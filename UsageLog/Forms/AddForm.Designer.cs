namespace UsageLog
{
    partial class AddForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.catagoryTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ValueSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.OKButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ValuelayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.catagoryTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuelayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.catagoryTextEdit);
            this.layoutControl1.Controls.Add(this.ValueSpinEdit);
            this.layoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.layoutControl1.Controls.Add(this.TypeLookUpEdit);
            this.layoutControl1.Controls.Add(this.OKButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(321, 283);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // catagoryTextEdit
            // 
            this.catagoryTextEdit.Location = new System.Drawing.Point(81, 64);
            this.catagoryTextEdit.Name = "catagoryTextEdit";
            this.catagoryTextEdit.Size = new System.Drawing.Size(228, 22);
            this.catagoryTextEdit.StyleController = this.layoutControl1;
            this.catagoryTextEdit.TabIndex = 8;
            this.catagoryTextEdit.EditValueChanged += new System.EventHandler(this.catagoryTextEdit_EditValueChanged);
            // 
            // ValueSpinEdit
            // 
            this.ValueSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ValueSpinEdit.Location = new System.Drawing.Point(81, 90);
            this.ValueSpinEdit.Name = "ValueSpinEdit";
            this.ValueSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ValueSpinEdit.Size = new System.Drawing.Size(228, 22);
            this.ValueSpinEdit.StyleController = this.layoutControl1;
            this.ValueSpinEdit.TabIndex = 7;
            this.ValueSpinEdit.EditValueChanged += new System.EventHandler(this.ValueSpinEdit_EditValueChanged);
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.Location = new System.Drawing.Point(81, 38);
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(228, 22);
            this.DescriptionTextEdit.StyleController = this.layoutControl1;
            this.DescriptionTextEdit.TabIndex = 6;
            this.DescriptionTextEdit.EditValueChanged += new System.EventHandler(this.DescriptionTextEdit_EditValueChanged);
            // 
            // TypeLookUpEdit
            // 
            this.TypeLookUpEdit.Location = new System.Drawing.Point(81, 12);
            this.TypeLookUpEdit.Name = "TypeLookUpEdit";
            this.TypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TypeLookUpEdit.Properties.DropDownRows = 2;
            this.TypeLookUpEdit.Properties.NullText = "";
            this.TypeLookUpEdit.Properties.ShowFooter = false;
            this.TypeLookUpEdit.Size = new System.Drawing.Size(228, 22);
            this.TypeLookUpEdit.StyleController = this.layoutControl1;
            this.TypeLookUpEdit.TabIndex = 5;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(209, 249);
            this.OKButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 22);
            this.OKButton.StyleController = this.layoutControl1;
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.ValuelayoutControlItem,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(321, 283);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 104);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(301, 133);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.OKButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(197, 237);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 237);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(197, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.TypeLookUpEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(301, 26);
            this.layoutControlItem2.Text = "Type:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.DescriptionTextEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(301, 26);
            this.layoutControlItem3.Text = "Description:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(57, 13);
            // 
            // ValuelayoutControlItem
            // 
            this.ValuelayoutControlItem.Control = this.ValueSpinEdit;
            this.ValuelayoutControlItem.Location = new System.Drawing.Point(0, 78);
            this.ValuelayoutControlItem.Name = "ValuelayoutControlItem";
            this.ValuelayoutControlItem.Size = new System.Drawing.Size(301, 26);
            this.ValuelayoutControlItem.Text = "Value:";
            this.ValuelayoutControlItem.TextSize = new System.Drawing.Size(57, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.catagoryTextEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(301, 26);
            this.layoutControlItem4.Text = "Catagory:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(57, 13);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 283);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.catagoryTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValuelayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton OKButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraEditors.LookUpEdit TypeLookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SpinEdit ValueSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem ValuelayoutControlItem;
        private DevExpress.XtraEditors.TextEdit catagoryTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}