namespace RangeControls
{
    partial class Form1
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
            this.rangeTrackBarControl1 = new DevExpress.XtraEditors.RangeTrackBarControl();
            this.rangeControl1 = new DevExpress.XtraEditors.RangeControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.rangeUserControl1 = new RangeControls.RangeUserControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.valueTrackerBarUserControl1 = new RangeControls.ValueTrackerBarUserControl();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.valueTrackerBarUserControl1);
            this.layoutControl1.Controls.Add(this.rangeUserControl1);
            this.layoutControl1.Controls.Add(this.rangeTrackBarControl1);
            this.layoutControl1.Controls.Add(this.rangeControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rangeTrackBarControl1
            // 
            this.rangeTrackBarControl1.EditValue = new DevExpress.XtraEditors.Repository.TrackBarRange(15, 30);
            this.rangeTrackBarControl1.Location = new System.Drawing.Point(12, 28);
            this.rangeTrackBarControl1.Name = "rangeTrackBarControl1";
            this.rangeTrackBarControl1.Properties.DistanceFromTickToLabel = 10;
            this.rangeTrackBarControl1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.rangeTrackBarControl1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "0";
            trackBarLabel2.Label = "10";
            trackBarLabel2.Value = 10;
            trackBarLabel3.Label = "20";
            trackBarLabel3.Value = 20;
            trackBarLabel4.Label = "30";
            trackBarLabel4.Value = 30;
            trackBarLabel5.Label = "40";
            trackBarLabel5.Value = 40;
            trackBarLabel6.Label = "50";
            trackBarLabel6.Value = 50;
            trackBarLabel7.Label = "60";
            trackBarLabel7.Value = 60;
            trackBarLabel8.Label = "70";
            trackBarLabel8.Value = 70;
            trackBarLabel9.Label = "80";
            trackBarLabel9.Value = 80;
            trackBarLabel10.Label = "90";
            trackBarLabel10.Value = 90;
            trackBarLabel11.Label = "100";
            trackBarLabel11.Value = 100;
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
            this.rangeTrackBarControl1.Properties.Maximum = 100;
            this.rangeTrackBarControl1.Properties.ShowLabels = true;
            this.rangeTrackBarControl1.Properties.TickFrequency = 10;
            this.rangeTrackBarControl1.Size = new System.Drawing.Size(776, 82);
            this.rangeTrackBarControl1.StyleController = this.layoutControl1;
            this.rangeTrackBarControl1.TabIndex = 5;
            this.rangeTrackBarControl1.Value = new DevExpress.XtraEditors.Repository.TrackBarRange(15, 30);
            // 
            // rangeControl1
            // 
            this.rangeControl1.Location = new System.Drawing.Point(12, 377);
            this.rangeControl1.Name = "rangeControl1";
            this.rangeControl1.Size = new System.Drawing.Size(776, 61);
            this.rangeControl1.StyleController = this.layoutControl1;
            this.rangeControl1.TabIndex = 4;
            this.rangeControl1.Text = "rangeControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.rangeControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 365);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 65);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rangeTrackBarControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 102);
            this.layoutControlItem2.Text = "RangeTrackBarControl ";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(111, 13);
            // 
            // rangeUserControl1
            // 
            this.rangeUserControl1.iHighLimit = 0;
            this.rangeUserControl1.iLowLimit = 0;
            this.rangeUserControl1.iMaxValue = 0;
            this.rangeUserControl1.iMinValue = 0;
            this.rangeUserControl1.Location = new System.Drawing.Point(12, 114);
            this.rangeUserControl1.Name = "rangeUserControl1";
            this.rangeUserControl1.Size = new System.Drawing.Size(776, 146);
            this.rangeUserControl1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.rangeUserControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 102);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(780, 150);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // valueTrackerBarUserControl1
            // 
            this.valueTrackerBarUserControl1.Location = new System.Drawing.Point(12, 264);
            this.valueTrackerBarUserControl1.Name = "valueTrackerBarUserControl1";
            this.valueTrackerBarUserControl1.Size = new System.Drawing.Size(776, 109);
            this.valueTrackerBarUserControl1.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.valueTrackerBarUserControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 252);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(780, 113);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeTrackBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.RangeControl rangeControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.RangeTrackBarControl rangeTrackBarControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private RangeControls.RangeUserControl rangeUserControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private ValueTrackerBarUserControl valueTrackerBarUserControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}

