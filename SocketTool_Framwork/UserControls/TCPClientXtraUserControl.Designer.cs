namespace SocketTool_Framework.UserControls
{
    partial class TCPClientXtraUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCPClientXtraUserControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.DisconnectButton = new DevExpress.XtraEditors.SimpleButton();
            this.ConnectButton = new DevExpress.XtraEditors.SimpleButton();
            this.PortLabelControl = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SendButton = new DevExpress.XtraEditors.SimpleButton();
            this.ReceivedGridControl = new DevExpress.XtraGrid.GridControl();
            this.ReceivedGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SendMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.IPv4LabelControl = new DevExpress.XtraEditors.LabelControl();
            this.SettingsButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.DisconnectButton);
            this.layoutControl1.Controls.Add(this.ConnectButton);
            this.layoutControl1.Controls.Add(this.PortLabelControl);
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.SendButton);
            this.layoutControl1.Controls.Add(this.ReceivedGridControl);
            this.layoutControl1.Controls.Add(this.SendMemoEdit);
            this.layoutControl1.Controls.Add(this.IPv4LabelControl);
            this.layoutControl1.Controls.Add(this.SettingsButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(603, 412);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.AllowFocus = false;
            this.DisconnectButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.DisconnectButton.Appearance.Options.UseBackColor = true;
            this.DisconnectButton.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.close_16x16;
            this.DisconnectButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.DisconnectButton.Location = new System.Drawing.Point(44, 12);
            this.DisconnectButton.MaximumSize = new System.Drawing.Size(28, 0);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(22, 22);
            this.DisconnectButton.StyleController = this.layoutControl1;
            this.DisconnectButton.TabIndex = 16;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.AllowFocus = false;
            this.ConnectButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ConnectButton.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ConnectButton.Appearance.Options.UseBackColor = true;
            this.ConnectButton.Appearance.Options.UseForeColor = true;
            this.ConnectButton.ImageOptions.Image = global::SocketTool_Framework.Properties.Resources.connect_16x16;
            this.ConnectButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.ConnectButton.Location = new System.Drawing.Point(12, 12);
            this.ConnectButton.MaximumSize = new System.Drawing.Size(28, 0);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(28, 22);
            this.ConnectButton.StyleController = this.layoutControl1;
            this.ConnectButton.TabIndex = 15;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // PortLabelControl
            // 
            this.PortLabelControl.Location = new System.Drawing.Point(573, 16);
            this.PortLabelControl.Name = "PortLabelControl";
            this.PortLabelControl.Size = new System.Drawing.Size(18, 13);
            this.PortLabelControl.StyleController = this.layoutControl1;
            this.PortLabelControl.TabIndex = 14;
            this.PortLabelControl.Text = "N/A";
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
            // SendButton
            // 
            this.SendButton.AllowFocus = false;
            this.SendButton.Location = new System.Drawing.Point(491, 39);
            this.SendButton.MaximumSize = new System.Drawing.Size(100, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(100, 22);
            this.SendButton.StyleController = this.layoutControl1;
            this.SendButton.TabIndex = 10;
            this.SendButton.Text = "Send";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ReceivedGridControl
            // 
            this.ReceivedGridControl.Location = new System.Drawing.Point(12, 154);
            this.ReceivedGridControl.MainView = this.ReceivedGridView;
            this.ReceivedGridControl.Name = "ReceivedGridControl";
            this.ReceivedGridControl.Size = new System.Drawing.Size(579, 246);
            this.ReceivedGridControl.TabIndex = 5;
            this.ReceivedGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ReceivedGridView});
            // 
            // ReceivedGridView
            // 
            this.ReceivedGridView.GridControl = this.ReceivedGridControl;
            this.ReceivedGridView.Name = "ReceivedGridView";
            this.ReceivedGridView.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.ReceivedGridView.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.ReceivedGridView.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.ReceivedGridView.OptionsCustomization.AllowSort = false;
            this.ReceivedGridView.OptionsFilter.AllowFilterEditor = false;
            this.ReceivedGridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.ReceivedGridView.OptionsSelection.MultiSelect = true;
            this.ReceivedGridView.OptionsView.RowAutoHeight = true;
            this.ReceivedGridView.OptionsView.ShowColumnHeaders = false;
            this.ReceivedGridView.OptionsView.ShowGroupPanel = false;
            this.ReceivedGridView.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.ReceivedGridView.OptionsView.ShowIndicator = false;
            this.ReceivedGridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // SendMemoEdit
            // 
            this.SendMemoEdit.Location = new System.Drawing.Point(12, 65);
            this.SendMemoEdit.Name = "SendMemoEdit";
            this.SendMemoEdit.Size = new System.Drawing.Size(579, 68);
            this.SendMemoEdit.StyleController = this.layoutControl1;
            this.SendMemoEdit.TabIndex = 4;
            // 
            // IPv4LabelControl
            // 
            this.IPv4LabelControl.Location = new System.Drawing.Point(497, 16);
            this.IPv4LabelControl.Name = "IPv4LabelControl";
            this.IPv4LabelControl.Size = new System.Drawing.Size(36, 13);
            this.IPv4LabelControl.StyleController = this.layoutControl1;
            this.IPv4LabelControl.TabIndex = 14;
            this.IPv4LabelControl.Text = "0.0.0.0";
            // 
            // SettingsButton
            // 
            this.SettingsButton.AllowFocus = false;
            this.SettingsButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.SettingsButton.Appearance.Options.UseBackColor = true;
            this.SettingsButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.ImageOptions.Image")));
            this.SettingsButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.SettingsButton.Location = new System.Drawing.Point(70, 12);
            this.SettingsButton.MaximumSize = new System.Drawing.Size(28, 0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(26, 22);
            this.SettingsButton.StyleController = this.layoutControl1;
            this.SettingsButton.TabIndex = 16;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.simpleSeparator1,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.simpleSeparator2,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(603, 412);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.SendMemoEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(583, 72);
            this.layoutControlItem1.Text = "Send Message";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ReceivedGridControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(583, 267);
            this.layoutControlItem2.Text = "Message Received:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
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
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(89, 27);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(390, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 26);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(583, 1);
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
            // layoutControlItem7
            // 
            this.layoutControlItem7.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem7.Control = this.PortLabelControl;
            this.layoutControlItem7.Location = new System.Drawing.Point(526, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(57, 26);
            this.layoutControlItem7.Text = "Port:";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(30, 20);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem8.Control = this.IPv4LabelControl;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem8.CustomizationFormText = "Lable:";
            this.layoutControlItem8.Location = new System.Drawing.Point(450, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(75, 26);
            this.layoutControlItem8.Text = "IPv4:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(30, 20);
            this.layoutControlItem8.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ConnectButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(32, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(88, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(362, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.DisconnectButton;
            this.layoutControlItem6.Location = new System.Drawing.Point(32, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(26, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // simpleSeparator2
            // 
            this.simpleSeparator2.AllowHotTrack = false;
            this.simpleSeparator2.Location = new System.Drawing.Point(525, 0);
            this.simpleSeparator2.Name = "simpleSeparator2";
            this.simpleSeparator2.OptionsPrint.AppearanceItem.ForeColor = System.Drawing.SystemColors.Control;
            this.simpleSeparator2.OptionsPrint.AppearanceItem.Options.UseForeColor = true;
            this.simpleSeparator2.Size = new System.Drawing.Size(1, 26);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.SettingsButton;
            this.layoutControlItem9.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem9.Location = new System.Drawing.Point(58, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(30, 26);
            this.layoutControlItem9.Text = "layoutControlItem6";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // TCPClientXtraUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "TCPClientXtraUserControl";
            this.Size = new System.Drawing.Size(603, 412);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceivedGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SendMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
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
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.LabelControl PortLabelControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LabelControl IPv4LabelControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton ConnectButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton DisconnectButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator2;
        private DevExpress.XtraEditors.SimpleButton SettingsButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
