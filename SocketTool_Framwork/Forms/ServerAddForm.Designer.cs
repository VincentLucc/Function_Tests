namespace SocketTool_Framework.Forms
{
    partial class ServerAddForm
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
            this.bCancel = new DevExpress.XtraEditors.SimpleButton();
            this.bOK = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.teIP = new DevExpress.XtraEditors.TextEdit();
            this.sePort = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bCancel);
            this.layoutControl1.Controls.Add(this.teIP);
            this.layoutControl1.Controls.Add(this.bOK);
            this.layoutControl1.Controls.Add(this.sePort);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(267, 258);
            this.layoutControl1.TabIndex = 8;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(196, 224);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(59, 22);
            this.bCancel.StyleController = this.layoutControl1;
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Cancel";
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(135, 224);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(57, 22);
            this.bOK.StyleController = this.layoutControl1;
            this.bOK.TabIndex = 4;
            this.bOK.Text = "OK";
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(267, 258);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 212);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(123, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bOK;
            this.layoutControlItem4.Location = new System.Drawing.Point(123, 212);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(61, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.bCancel;
            this.layoutControlItem5.Location = new System.Drawing.Point(184, 212);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(63, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(247, 160);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // teIP
            // 
            this.teIP.Location = new System.Drawing.Point(97, 12);
            this.teIP.Name = "teIP";
            this.teIP.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.teIP.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(" +
        "25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[" +
        "0-4][0-9])|(25[0-5]))");
            this.teIP.Size = new System.Drawing.Size(158, 22);
            this.teIP.StyleController = this.layoutControl1;
            this.teIP.TabIndex = 3;
            this.teIP.EditValueChanged += new System.EventHandler(this.teIP_EditValueChanged);
            // 
            // sePort
            // 
            this.sePort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sePort.Location = new System.Drawing.Point(97, 38);
            this.sePort.Name = "sePort";
            this.sePort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePort.Properties.IsFloatValue = false;
            this.sePort.Properties.MaskSettings.Set("mask", "####0");
            this.sePort.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.sePort.Size = new System.Drawing.Size(158, 22);
            this.sePort.StyleController = this.layoutControl1;
            this.sePort.TabIndex = 0;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teIP;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(247, 26);
            this.layoutControlItem3.Text = "Server IP:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sePort;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(247, 26);
            this.layoutControlItem1.Text = "Server Port:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // ServerAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 258);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "ServerAddForm";
            this.Text = "Add Client";
            this.Load += new System.EventHandler(this.FormServerAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton bCancel;
        private DevExpress.XtraEditors.SimpleButton bOK;
        private DevExpress.XtraEditors.TextEdit teIP;
        private DevExpress.XtraEditors.SpinEdit sePort;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}