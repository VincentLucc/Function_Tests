namespace TextEdit
{
    partial class RichEditXMLForm
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
            this.components = new System.ComponentModel.Container();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.tsAutoText = new DevExpress.XtraEditors.ToggleSwitch();
            this.bApend = new DevExpress.XtraEditors.SimpleButton();
            this.teInput = new DevExpress.XtraEditors.TextEdit();
            this.bInsert = new DevExpress.XtraEditors.SimpleButton();
            this.bLoad = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsAutoText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditControl1.Location = new System.Drawing.Point(200, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Options.VerticalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Visible;
            this.richEditControl1.Size = new System.Drawing.Size(600, 450);
            this.richEditControl1.TabIndex = 0;
            this.richEditControl1.Views.DraftView.AllowDisplayLineNumbers = true;
            this.richEditControl1.Views.PrintLayoutView.MaxHorizontalPageCount = 1;
            this.richEditControl1.Views.SimpleView.AllowDisplayLineNumbers = true;
            this.richEditControl1.Views.SimpleView.WordWrap = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 450);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "groupControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.tsAutoText);
            this.layoutControl1.Controls.Add(this.bApend);
            this.layoutControl1.Controls.Add(this.teInput);
            this.layoutControl1.Controls.Add(this.bInsert);
            this.layoutControl1.Controls.Add(this.bLoad);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 29);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(196, 419);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // tsAutoText
            // 
            this.tsAutoText.Location = new System.Drawing.Point(102, 84);
            this.tsAutoText.Name = "tsAutoText";
            this.tsAutoText.Properties.OffText = "Off";
            this.tsAutoText.Properties.OnText = "On";
            this.tsAutoText.Size = new System.Drawing.Size(78, 24);
            this.tsAutoText.StyleController = this.layoutControl1;
            this.tsAutoText.TabIndex = 5;
            this.tsAutoText.Toggled += new System.EventHandler(this.tsAutoText_Toggled);
            // 
            // bApend
            // 
            this.bApend.Location = new System.Drawing.Point(101, 50);
            this.bApend.Name = "bApend";
            this.bApend.Size = new System.Drawing.Size(79, 28);
            this.bApend.StyleController = this.layoutControl1;
            this.bApend.TabIndex = 4;
            this.bApend.Text = "Append";
            this.bApend.Click += new System.EventHandler(this.bApend_Click);
            // 
            // teInput
            // 
            this.teInput.Location = new System.Drawing.Point(102, 114);
            this.teInput.Name = "teInput";
            this.teInput.Size = new System.Drawing.Size(78, 28);
            this.teInput.StyleController = this.layoutControl1;
            this.teInput.TabIndex = 2;
            // 
            // bInsert
            // 
            this.bInsert.Location = new System.Drawing.Point(16, 50);
            this.bInsert.Name = "bInsert";
            this.bInsert.Size = new System.Drawing.Size(79, 28);
            this.bInsert.StyleController = this.layoutControl1;
            this.bInsert.TabIndex = 1;
            this.bInsert.Text = "Insert";
            this.bInsert.Click += new System.EventHandler(this.bInsert_Click);
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(16, 16);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(164, 28);
            this.bLoad.StyleController = this.layoutControl1;
            this.bLoad.TabIndex = 0;
            this.bLoad.Text = "Load";
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(196, 419);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.bLoad;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(170, 34);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 132);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(170, 261);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.bInsert;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(85, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.teInput;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(170, 34);
            this.layoutControlItem3.Text = "Input:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(70, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bApend;
            this.layoutControlItem4.Location = new System.Drawing.Point(85, 34);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(85, 34);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.tsAutoText;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(170, 30);
            this.layoutControlItem5.Text = "Auto Add Text";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(70, 13);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // RichEditXMLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.groupControl1);
            this.Name = "RichEditXMLForm";
            this.Text = "RichEditXMLForm";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsAutoText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton bLoad;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit teInput;
        private DevExpress.XtraEditors.SimpleButton bInsert;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton bApend;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.ToggleSwitch tsAutoText;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}