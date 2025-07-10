namespace TaskTests
{
    partial class MainForm
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.PageGeneral = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.StopBlockingServiceButton = new DevExpress.XtraEditors.SimpleButton();
            this.AddBlockingItemButton = new DevExpress.XtraEditors.SimpleButton();
            this.BlockingCollection1Button = new DevExpress.XtraEditors.SimpleButton();
            this.CancelWIthTokenButton = new DevExpress.XtraEditors.SimpleButton();
            this.CancelWithFlagButton = new DevExpress.XtraEditors.SimpleButton();
            this.StartCompletionServiceButton = new DevExpress.XtraEditors.SimpleButton();
            this.SampleCommmandButton = new DevExpress.XtraEditors.SimpleButton();
            this.StopCompletionService = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.PageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.PageGeneral;
            this.xtraTabControl1.Size = new System.Drawing.Size(800, 450);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.PageGeneral,
            this.xtraTabPage2});
            // 
            // PageGeneral
            // 
            this.PageGeneral.Controls.Add(this.layoutControl1);
            this.PageGeneral.Name = "PageGeneral";
            this.PageGeneral.Size = new System.Drawing.Size(798, 425);
            this.PageGeneral.Text = "General";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.StopBlockingServiceButton);
            this.layoutControl1.Controls.Add(this.AddBlockingItemButton);
            this.layoutControl1.Controls.Add(this.BlockingCollection1Button);
            this.layoutControl1.Controls.Add(this.CancelWIthTokenButton);
            this.layoutControl1.Controls.Add(this.CancelWithFlagButton);
            this.layoutControl1.Controls.Add(this.StartCompletionServiceButton);
            this.layoutControl1.Controls.Add(this.SampleCommmandButton);
            this.layoutControl1.Controls.Add(this.StopCompletionService);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(798, 425);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // StopBlockingServiceButton
            // 
            this.StopBlockingServiceButton.Location = new System.Drawing.Point(145, 45);
            this.StopBlockingServiceButton.Name = "StopBlockingServiceButton";
            this.StopBlockingServiceButton.Size = new System.Drawing.Size(240, 22);
            this.StopBlockingServiceButton.StyleController = this.layoutControl1;
            this.StopBlockingServiceButton.TabIndex = 8;
            this.StopBlockingServiceButton.Text = "Stop Service";
            this.StopBlockingServiceButton.Click += new System.EventHandler(this.StopBlockingServiceButton_Click);
            // 
            // AddBlockingItemButton
            // 
            this.AddBlockingItemButton.Location = new System.Drawing.Point(24, 71);
            this.AddBlockingItemButton.Name = "AddBlockingItemButton";
            this.AddBlockingItemButton.Size = new System.Drawing.Size(117, 22);
            this.AddBlockingItemButton.StyleController = this.layoutControl1;
            this.AddBlockingItemButton.TabIndex = 7;
            this.AddBlockingItemButton.Text = "AddItem";
            this.AddBlockingItemButton.Click += new System.EventHandler(this.AddBlockingItemButton_Click);
            // 
            // BlockingCollection1Button
            // 
            this.BlockingCollection1Button.Location = new System.Drawing.Point(24, 45);
            this.BlockingCollection1Button.Name = "BlockingCollection1Button";
            this.BlockingCollection1Button.Size = new System.Drawing.Size(117, 22);
            this.BlockingCollection1Button.StyleController = this.layoutControl1;
            this.BlockingCollection1Button.TabIndex = 6;
            this.BlockingCollection1Button.Text = "Start Service";
            this.BlockingCollection1Button.Click += new System.EventHandler(this.BlockingCollection1Button_Click);
            // 
            // CancelWIthTokenButton
            // 
            this.CancelWIthTokenButton.Location = new System.Drawing.Point(198, 142);
            this.CancelWIthTokenButton.Name = "CancelWIthTokenButton";
            this.CancelWIthTokenButton.Size = new System.Drawing.Size(171, 22);
            this.CancelWIthTokenButton.StyleController = this.layoutControl1;
            this.CancelWIthTokenButton.TabIndex = 5;
            this.CancelWIthTokenButton.Text = "CancellationTokenSource";
            this.CancelWIthTokenButton.Click += new System.EventHandler(this.CancelWIthTokenButton_Click);
            // 
            // CancelWithFlagButton
            // 
            this.CancelWithFlagButton.Location = new System.Drawing.Point(24, 142);
            this.CancelWithFlagButton.Name = "CancelWithFlagButton";
            this.CancelWithFlagButton.Size = new System.Drawing.Size(170, 22);
            this.CancelWithFlagButton.StyleController = this.layoutControl1;
            this.CancelWithFlagButton.TabIndex = 4;
            this.CancelWithFlagButton.Text = "Cancel With Flag";
            this.CancelWithFlagButton.Click += new System.EventHandler(this.CancelWithFlagButton_Click);
            // 
            // StartCompletionServiceButton
            // 
            this.StartCompletionServiceButton.Location = new System.Drawing.Point(413, 45);
            this.StartCompletionServiceButton.Name = "StartCompletionServiceButton";
            this.StartCompletionServiceButton.Size = new System.Drawing.Size(251, 22);
            this.StartCompletionServiceButton.StyleController = this.layoutControl1;
            this.StartCompletionServiceButton.TabIndex = 6;
            this.StartCompletionServiceButton.Text = "Start Service";
            this.StartCompletionServiceButton.Click += new System.EventHandler(this.StartCompletionServiceButton_Click);
            // 
            // SampleCommmandButton
            // 
            this.SampleCommmandButton.Location = new System.Drawing.Point(413, 71);
            this.SampleCommmandButton.Name = "SampleCommmandButton";
            this.SampleCommmandButton.Size = new System.Drawing.Size(251, 22);
            this.SampleCommmandButton.StyleController = this.layoutControl1;
            this.SampleCommmandButton.TabIndex = 7;
            this.SampleCommmandButton.Text = "Sample COmmand";
            this.SampleCommmandButton.Click += new System.EventHandler(this.SampleCommmandButton_Click);
            // 
            // StopCompletionService
            // 
            this.StopCompletionService.Location = new System.Drawing.Point(668, 45);
            this.StopCompletionService.Name = "StopCompletionService";
            this.StopCompletionService.Size = new System.Drawing.Size(106, 22);
            this.StopCompletionService.StyleController = this.layoutControl1;
            this.StopCompletionService.TabIndex = 8;
            this.StopCompletionService.Text = "Stop Service";
            this.StopCompletionService.Click += new System.EventHandler(this.StopCompletionService_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup1,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(798, 425);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(373, 97);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(405, 308);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(389, 97);
            this.layoutControlGroup1.Text = "Blocking Collection";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.BlockingCollection1Button;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(121, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.StopBlockingServiceButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(121, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(244, 52);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.AddBlockingItemButton;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(121, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Blocking Collection";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem7});
            this.layoutControlGroup3.Location = new System.Drawing.Point(389, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 3;
            this.layoutControlGroup3.Size = new System.Drawing.Size(389, 97);
            this.layoutControlGroup3.Text = "Task Completion Source";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.StartCompletionServiceButton;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(255, 26);
            this.layoutControlItem6.Text = "layoutControlItem3";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.StopCompletionService;
            this.layoutControlItem8.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem8.Location = new System.Drawing.Point(255, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(110, 52);
            this.layoutControlItem8.Text = "layoutControlItem5";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.SampleCommmandButton;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(255, 26);
            this.layoutControlItem7.Text = "layoutControlItem4";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "Blocking Collection";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 97);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.OptionsItemText.TextToControlDistance = 3;
            this.layoutControlGroup4.Size = new System.Drawing.Size(373, 308);
            this.layoutControlGroup4.Text = "Task Cancellation";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CancelWIthTokenButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(174, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(175, 263);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CancelWithFlagButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(174, 263);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(798, 425);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.PageGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage PageGeneral;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton CancelWithFlagButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton CancelWIthTokenButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton BlockingCollection1Button;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton AddBlockingItemButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton StopBlockingServiceButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton StartCompletionServiceButton;
        private DevExpress.XtraEditors.SimpleButton SampleCommmandButton;
        private DevExpress.XtraEditors.SimpleButton StopCompletionService;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
    }
}

