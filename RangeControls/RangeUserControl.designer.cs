
namespace RangeControls
{
    partial class RangeUserControl
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
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel4 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel5 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel6 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel7 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel8 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel9 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel10 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel11 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.MaxLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.MinLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.MaxTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MinTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.rangeTrackBarControl1 = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.MaxLabelControl);
            this.layoutControl1.Controls.Add(this.MaxTextEdit);
            this.layoutControl1.Controls.Add(this.MinLabelControl);
            this.layoutControl1.Controls.Add(this.MinTextEdit);
            this.layoutControl1.Controls.Add(this.rangeTrackBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(323, 168);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // MaxLabelControl
            // 
            this.MaxLabelControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaxLabelControl.Location = new System.Drawing.Point(158, 120);
            this.MaxLabelControl.Name = "MaxLabelControl";
            this.MaxLabelControl.Size = new System.Drawing.Size(24, 13);
            this.MaxLabelControl.StyleController = this.layoutControl1;
            this.MaxLabelControl.TabIndex = 9;
            this.MaxLabelControl.Text = "Max:";
            // 
            // MinLabelControl
            // 
            this.MinLabelControl.Location = new System.Drawing.Point(16, 120);
            this.MinLabelControl.Name = "MinLabelControl";
            this.MinLabelControl.Size = new System.Drawing.Size(20, 13);
            this.MinLabelControl.StyleController = this.layoutControl1;
            this.MinLabelControl.TabIndex = 7;
            this.MinLabelControl.Text = "Min:";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(323, 168);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem4.Control = this.MinLabelControl;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(26, 34);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.layoutControlItem5.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem5.Control = this.MaxLabelControl;
            this.layoutControlItem5.Location = new System.Drawing.Point(142, 97);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(30, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 131);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(297, 11);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MaxTextEdit
            // 
            this.MaxTextEdit.Location = new System.Drawing.Point(188, 113);
            this.MaxTextEdit.Name = "MaxTextEdit";
            this.MaxTextEdit.Size = new System.Drawing.Size(119, 28);
            this.MaxTextEdit.StyleController = this.layoutControl1;
            this.MaxTextEdit.TabIndex = 8;
            this.MaxTextEdit.EditValueChanged += new System.EventHandler(this.MaxTextEdit_EditValueChanged);
            // 
            // MinTextEdit
            // 
            this.MinTextEdit.Location = new System.Drawing.Point(42, 113);
            this.MinTextEdit.Name = "MinTextEdit";
            this.MinTextEdit.Size = new System.Drawing.Size(110, 28);
            this.MinTextEdit.StyleController = this.layoutControl1;
            this.MinTextEdit.TabIndex = 6;
            this.MinTextEdit.EditValueChanged += new System.EventHandler(this.MinTextEdit_EditValueChanged);
            // 
            // rangeTrackBarControl1
            // 
            this.rangeTrackBarControl1.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(30, 70);
            this.rangeTrackBarControl1.Location = new System.Drawing.Point(16, 35);
            this.rangeTrackBarControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.rangeTrackBarControl1.Name = "rangeTrackBarControl1";
            this.rangeTrackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.rangeTrackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "1";
            trackBarLabel1.Value = 1;
            trackBarLabel2.Label = "26";
            trackBarLabel2.Value = 26;
            trackBarLabel3.Label = "51";
            trackBarLabel3.Value = 51;
            trackBarLabel4.Label = "76";
            trackBarLabel4.Value = 76;
            trackBarLabel5.Label = "101";
            trackBarLabel5.Value = 101;
            trackBarLabel6.Label = "126";
            trackBarLabel6.Value = 126;
            trackBarLabel7.Label = "151";
            trackBarLabel7.Value = 151;
            trackBarLabel8.Label = "176";
            trackBarLabel8.Value = 176;
            trackBarLabel9.Label = "201";
            trackBarLabel9.Value = 201;
            trackBarLabel10.Label = "226";
            trackBarLabel10.Value = 226;
            trackBarLabel11.Label = "251";
            trackBarLabel11.Value = 251;
            this.rangeTrackBarControl1.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1,
            trackBarLabel2,
            trackBarLabel3,
            trackBarLabel4,
            trackBarLabel5,
            trackBarLabel6,
            trackBarLabel7,
            trackBarLabel8,
            trackBarLabel9,
            trackBarLabel10,
            trackBarLabel11});
            this.rangeTrackBarControl1.Properties.Maximum = 255;
            this.rangeTrackBarControl1.Properties.Minimum = 1;
            this.rangeTrackBarControl1.Properties.ShowLabels = true;
            this.rangeTrackBarControl1.Properties.ShowValueToolTip = true;
            this.rangeTrackBarControl1.Properties.TickFrequency = 25;
            this.rangeTrackBarControl1.Size = new System.Drawing.Size(291, 72);
            this.rangeTrackBarControl1.StyleController = this.layoutControl1;
            this.rangeTrackBarControl1.TabIndex = 4;
            this.rangeTrackBarControl1.Value = new DevExpress.XtraEditors.Repository.TrackBarRange(30, 70);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.rangeTrackBarControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(297, 97);
            this.layoutControlItem1.Text = "Scale Range";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(59, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.MinTextEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(26, 97);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(116, 34);
            this.layoutControlItem3.Text = "Max:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.MaxTextEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(172, 97);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(125, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // RangeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "RangeUserControl";
            this.Size = new System.Drawing.Size(323, 168);
            this.Load += new System.EventHandler(this.RangeUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.layoutControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        public DevExpress.XtraEditors.RangeTrackBarControl rangeTrackBarControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit MinTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LabelControl MaxLabelControl;
        private DevExpress.XtraEditors.TextEdit MaxTextEdit;
        private DevExpress.XtraEditors.LabelControl MinLabelControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
