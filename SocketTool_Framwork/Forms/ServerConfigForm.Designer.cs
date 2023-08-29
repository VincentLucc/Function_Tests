namespace SocketTool_Framework.Forms
{
    partial class ServerConfigForm
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
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.separatorControl1);
            this.layoutControl1.Controls.Add(this.toggleSwitch1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(298, 270);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(298, 270);
            this.Root.TextVisible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(206, 236);
            this.simpleButton1.MaximumSize = new System.Drawing.Size(80, 0);
            this.simpleButton1.MinimumSize = new System.Drawing.Size(30, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "OK";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.Location = new System.Drawing.Point(194, 224);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 81);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(278, 143);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 224);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(194, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(117, 12);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(169, 24);
            this.toggleSwitch1.StyleController = this.layoutControl1;
            this.toggleSwitch1.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.toggleSwitch1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(278, 28);
            this.layoutControlItem2.Text = "Segmentation:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // separatorControl1
            // 
            this.separatorControl1.LineColor = System.Drawing.SystemColors.Control;
            this.separatorControl1.Location = new System.Drawing.Point(12, 66);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(274, 23);
            this.separatorControl1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.separatorControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(278, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(117, 40);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(169, 22);
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookUpEdit1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(278, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(93, 13);
            // 
            // ServerConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 270);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "ServerConfigForm";
            this.Text = "Server Config";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}