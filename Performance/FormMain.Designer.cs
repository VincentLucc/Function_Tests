namespace Performance
{
    partial class FormMain
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
            this.ResultMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.CPUPerMultiButton = new DevExpress.XtraEditors.SimpleButton();
            this.cpuOverAllButton = new DevExpress.XtraEditors.SimpleButton();
            this.DoubleButton = new DevExpress.XtraEditors.SimpleButton();
            this.CPUIntButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.FloatButton = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.FloatButton);
            this.layoutControl1.Controls.Add(this.ResultMemoEdit);
            this.layoutControl1.Controls.Add(this.CPUPerMultiButton);
            this.layoutControl1.Controls.Add(this.cpuOverAllButton);
            this.layoutControl1.Controls.Add(this.DoubleButton);
            this.layoutControl1.Controls.Add(this.CPUIntButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(365, 372);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ResultMemoEdit
            // 
            this.ResultMemoEdit.Location = new System.Drawing.Point(12, 135);
            this.ResultMemoEdit.Name = "ResultMemoEdit";
            this.ResultMemoEdit.Size = new System.Drawing.Size(341, 225);
            this.ResultMemoEdit.StyleController = this.layoutControl1;
            this.ResultMemoEdit.TabIndex = 9;
            // 
            // CPUPerMultiButton
            // 
            this.CPUPerMultiButton.Location = new System.Drawing.Point(184, 97);
            this.CPUPerMultiButton.Name = "CPUPerMultiButton";
            this.CPUPerMultiButton.Size = new System.Drawing.Size(157, 22);
            this.CPUPerMultiButton.StyleController = this.layoutControl1;
            this.CPUPerMultiButton.TabIndex = 7;
            this.CPUPerMultiButton.Text = "Multi Thread";
            this.CPUPerMultiButton.Click += new System.EventHandler(this.CPUPerMultiButton_Click);
            // 
            // cpuOverAllButton
            // 
            this.cpuOverAllButton.Location = new System.Drawing.Point(24, 97);
            this.cpuOverAllButton.Name = "cpuOverAllButton";
            this.cpuOverAllButton.Size = new System.Drawing.Size(156, 22);
            this.cpuOverAllButton.StyleController = this.layoutControl1;
            this.cpuOverAllButton.TabIndex = 6;
            this.cpuOverAllButton.Text = "Over All";
            this.cpuOverAllButton.Click += new System.EventHandler(this.cpuOverAllButton_Click);
            // 
            // DoubleButton
            // 
            this.DoubleButton.Location = new System.Drawing.Point(184, 45);
            this.DoubleButton.Name = "DoubleButton";
            this.DoubleButton.Size = new System.Drawing.Size(157, 22);
            this.DoubleButton.StyleController = this.layoutControl1;
            this.DoubleButton.TabIndex = 5;
            this.DoubleButton.Text = "Double";
            this.DoubleButton.Click += new System.EventHandler(this.DoubleButton_Click);
            // 
            // CPUIntButton
            // 
            this.CPUIntButton.Location = new System.Drawing.Point(24, 45);
            this.CPUIntButton.Name = "CPUIntButton";
            this.CPUIntButton.Size = new System.Drawing.Size(156, 22);
            this.CPUIntButton.StyleController = this.layoutControl1;
            this.CPUIntButton.TabIndex = 4;
            this.CPUIntButton.Text = "Integer";
            this.CPUIntButton.Click += new System.EventHandler(this.CPUIntButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(365, 372);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(345, 123);
            this.layoutControlGroup1.Text = "CPU Perf.";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CPUIntButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.DoubleButton;
            this.layoutControlItem2.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(161, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cpuOverAllButton;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(160, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.CPUPerMultiButton;
            this.layoutControlItem4.Location = new System.Drawing.Point(160, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(161, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ResultMemoEdit;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(345, 229);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // FloatButton
            // 
            this.FloatButton.Location = new System.Drawing.Point(184, 71);
            this.FloatButton.Name = "FloatButton";
            this.FloatButton.Size = new System.Drawing.Size(157, 22);
            this.FloatButton.StyleController = this.layoutControl1;
            this.FloatButton.TabIndex = 10;
            this.FloatButton.Text = "Double";
            this.FloatButton.Click += new System.EventHandler(this.FloatButton_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.FloatButton;
            this.layoutControlItem5.Location = new System.Drawing.Point(160, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(161, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(160, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 372);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton CPUIntButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton DoubleButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton cpuOverAllButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton CPUPerMultiButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.MemoEdit ResultMemoEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton FloatButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}

