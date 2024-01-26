
    partial class ValueTrackerBarUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.trackBarControl1 = new DevExpress.XtraEditors.TrackBarControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ValueCalcEdit = new DevExpress.XtraEditors.CalcEdit();
            this.ValueLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueLayoutControlItem)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ValueCalcEdit);
            this.layoutControl1.Controls.Add(this.trackBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(228, 93);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // trackBarControl1
            // 
            this.trackBarControl1.EditValue = null;
            this.trackBarControl1.Location = new System.Drawing.Point(12, 36);
            this.trackBarControl1.Name = "trackBarControl1";
            this.trackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.trackBarControl1.Properties.TickFrequency = 2;
            this.trackBarControl1.Size = new System.Drawing.Size(204, 45);
            this.trackBarControl1.StyleController = this.layoutControl1;
            this.trackBarControl1.TabIndex = 5;
            this.trackBarControl1.EditValueChanged += new System.EventHandler(this.trackBarControl1_EditValueChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.ValueLayoutControlItem});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(228, 93);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.trackBarControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(208, 49);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ValueCalcEdit
            // 
            this.ValueCalcEdit.Location = new System.Drawing.Point(54, 12);
            this.ValueCalcEdit.Name = "ValueCalcEdit";
            this.ValueCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ValueCalcEdit.Size = new System.Drawing.Size(162, 20);
            this.ValueCalcEdit.StyleController = this.layoutControl1;
            this.ValueCalcEdit.TabIndex = 6;
            this.ValueCalcEdit.EditValueChanged += new System.EventHandler(this.ValueCalcEdit_EditValueChanged);
            // 
            // ValueLayoutControlItem
            // 
            this.ValueLayoutControlItem.Control = this.ValueCalcEdit;
            this.ValueLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.ValueLayoutControlItem.Name = "ValueLayoutControlItem";
            this.ValueLayoutControlItem.Size = new System.Drawing.Size(208, 24);
            this.ValueLayoutControlItem.Text = "Value:";
            this.ValueLayoutControlItem.TextSize = new System.Drawing.Size(30, 13);
            // 
            // ValueTrackerBarUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ValueTrackerBarUserControl";
            this.Size = new System.Drawing.Size(228, 93);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValueLayoutControlItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        public DevExpress.XtraEditors.TrackBarControl trackBarControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    private DevExpress.XtraEditors.CalcEdit ValueCalcEdit;
    private DevExpress.XtraLayout.LayoutControlItem ValueLayoutControlItem;
}

