namespace SocketTool_Framework.UserControls
{
    partial class TCPServerXtraUserControl
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
            this.IPAddressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SendButton = new DevExpress.XtraEditors.SimpleButton();
            this.PortSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.ReceivedGridControl = new DevExpress.XtraGrid.GridControl();
            this.ReceivedGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SendMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.IPAddressTextEdit);
            this.layoutControl1.Controls.Add(this.SendButton);
            this.layoutControl1.Controls.Add(this.PortSpinEdit);
            this.layoutControl1.Controls.Add(this.ReceivedGridControl);
            this.layoutControl1.Controls.Add(this.SendMemoEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(603, 412);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // IPAddressTextEdit
            // 
            this.IPAddressTextEdit.Location = new System.Drawing.Point(47, 12);
            this.IPAddressTextEdit.Name = "IPAddressTextEdit";
            this.IPAddressTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.IPAddressTextEdit.Properties.MaskSettings.Set("mask", "(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(" +
        "25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[0-4][0-9])|(25[0-5]))\\.(([01]?[0-9]?[0-9])|(2[" +
        "0-4][0-9])|(25[0-5]))");
            this.IPAddressTextEdit.Properties.MaskSettings.Set("MaskManagerSignature", "isOptimistic=False");
            this.IPAddressTextEdit.Properties.UseMaskAsDisplayFormat = true;
            this.IPAddressTextEdit.Size = new System.Drawing.Size(94, 22);
            this.IPAddressTextEdit.StyleController = this.layoutControl1;
            this.IPAddressTextEdit.TabIndex = 12;
            this.IPAddressTextEdit.EditValueChanged += new System.EventHandler(this.IPAddressTextEdit_EditValueChanged);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(491, 39);
            this.SendButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 22);
            this.SendButton.StyleController = this.layoutControl1;
            this.SendButton.TabIndex = 10;
            this.SendButton.Text = "Send";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // PortSpinEdit
            // 
            this.PortSpinEdit.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortSpinEdit.Location = new System.Drawing.Point(180, 12);
            this.PortSpinEdit.Name = "PortSpinEdit";
            this.PortSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PortSpinEdit.Properties.IsFloatValue = false;
            this.PortSpinEdit.Properties.MaskSettings.Set("mask", "####0");
            this.PortSpinEdit.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortSpinEdit.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortSpinEdit.Size = new System.Drawing.Size(72, 22);
            this.PortSpinEdit.StyleController = this.layoutControl1;
            this.PortSpinEdit.TabIndex = 9;
            this.PortSpinEdit.EditValueChanged += new System.EventHandler(this.PortSpinEdit_EditValueChanged);
            // 
            // ReceivedGridControl
            // 
            this.ReceivedGridControl.Location = new System.Drawing.Point(12, 179);
            this.ReceivedGridControl.MainView = this.ReceivedGridView;
            this.ReceivedGridControl.Name = "ReceivedGridControl";
            this.ReceivedGridControl.Size = new System.Drawing.Size(579, 221);
            this.ReceivedGridControl.TabIndex = 5;
            this.ReceivedGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ReceivedGridView});
            // 
            // ReceivedGridView
            // 
            this.ReceivedGridView.GridControl = this.ReceivedGridControl;
            this.ReceivedGridView.Name = "ReceivedGridView";
            this.ReceivedGridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.ReceivedGridView.OptionsView.ShowGroupPanel = false;
            this.ReceivedGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.ReceivedGridView.OptionsView.ShowIndicator = false;
            this.ReceivedGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // SendMemoEdit
            // 
            this.SendMemoEdit.Location = new System.Drawing.Point(12, 65);
            this.SendMemoEdit.Name = "SendMemoEdit";
            this.SendMemoEdit.Size = new System.Drawing.Size(579, 93);
            this.SendMemoEdit.StyleController = this.layoutControl1;
            this.SendMemoEdit.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.simpleSeparator1,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(603, 412);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.SendMemoEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(583, 97);
            this.layoutControlItem1.Text = "Send Message";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ReceivedGridControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(583, 242);
            this.layoutControlItem2.Text = "Message Received:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(244, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(339, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.PortSpinEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(133, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(111, 26);
            this.layoutControlItem6.Text = "Port:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.SendButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(479, 27);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(104, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.IPAddressTextEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(133, 26);
            this.layoutControlItem5.Text = "IPv4:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(30, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(89, 27);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(388, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 26);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(583, 1);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Message to send:";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem4.Control = this.labelControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // TCPServerXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "TCPServerXtraUserControl";
            this.Size = new System.Drawing.Size(603, 412);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl ReceivedGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ReceivedGridView;
        private DevExpress.XtraEditors.MemoEdit SendMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton SendButton;
        private DevExpress.XtraEditors.SpinEdit PortSpinEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit IPAddressTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
