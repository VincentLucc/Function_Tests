
namespace ComboBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbTest01 = new System.Windows.Forms.ComboBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.icbTest = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ComboBoxEditCustomized = new DevExpress.XtraEditors.ComboBoxEdit();
            this.icbTest2 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.comboBoxEditNormal = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.icbTest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditCustomized.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbTest2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNormal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTest01
            // 
            this.cbTest01.FormattingEnabled = true;
            this.cbTest01.Location = new System.Drawing.Point(19, 19);
            this.cbTest01.Name = "cbTest01";
            this.cbTest01.Size = new System.Drawing.Size(121, 21);
            this.cbTest01.TabIndex = 0;
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(19, 57);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(121, 23);
            this.bUpdate.TabIndex = 1;
            this.bUpdate.Text = "Update Items";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // icbTest
            // 
            this.icbTest.Location = new System.Drawing.Point(158, 84);
            this.icbTest.Name = "icbTest";
            this.icbTest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbTest.Size = new System.Drawing.Size(334, 20);
            this.icbTest.StyleController = this.layoutControl1;
            this.icbTest.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ComboBoxEditCustomized);
            this.layoutControl1.Controls.Add(this.icbTest2);
            this.layoutControl1.Controls.Add(this.comboBoxEditNormal);
            this.layoutControl1.Controls.Add(this.icbTest);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(504, 227);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ComboBoxEditCustomized
            // 
            this.ComboBoxEditCustomized.Location = new System.Drawing.Point(158, 36);
            this.ComboBoxEditCustomized.Name = "ComboBoxEditCustomized";
            this.ComboBoxEditCustomized.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxEditCustomized.Size = new System.Drawing.Size(334, 20);
            this.ComboBoxEditCustomized.StyleController = this.layoutControl1;
            this.ComboBoxEditCustomized.TabIndex = 6;
            this.ComboBoxEditCustomized.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEditCustomized_SelectedIndexChanged);
            // 
            // icbTest2
            // 
            this.icbTest2.Location = new System.Drawing.Point(158, 60);
            this.icbTest2.Name = "icbTest2";
            this.icbTest2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbTest2.Size = new System.Drawing.Size(334, 20);
            this.icbTest2.StyleController = this.layoutControl1;
            this.icbTest2.TabIndex = 5;
            // 
            // comboBoxEditNormal
            // 
            this.comboBoxEditNormal.Location = new System.Drawing.Point(158, 12);
            this.comboBoxEditNormal.Name = "comboBoxEditNormal";
            this.comboBoxEditNormal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditNormal.Size = new System.Drawing.Size(334, 20);
            this.comboBoxEditNormal.StyleController = this.layoutControl1;
            this.comboBoxEditNormal.TabIndex = 4;
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
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(504, 227);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.icbTest;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(484, 24);
            this.layoutControlItem1.Text = "Image combo box with Edit:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(143, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(484, 111);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBoxEditNormal;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(484, 24);
            this.layoutControlItem2.Text = "Normal combo box:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(143, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.icbTest2;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(484, 24);
            this.layoutControlItem3.Text = "Image Combo Box 2:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(143, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ComboBoxEditCustomized;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(484, 24);
            this.layoutControlItem4.Text = "Normal combo customize:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(143, 13);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ComboBox.Properties.Resources.Heart_Monitor, "Heart_Monitor", typeof(global::ComboBox.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "Heart_Monitor");
            this.imageCollection1.InsertImage(global::ComboBox.Properties.Resources.RingDarkBlue, "RingDarkBlue", typeof(global::ComboBox.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "RingDarkBlue");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.layoutControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 246);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DevExpress";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTest01);
            this.groupBox2.Controls.Add(this.bUpdate);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WinForm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icbTest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxEditCustomized.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icbTest2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditNormal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTest01;
        private System.Windows.Forms.Button bUpdate;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbTest;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditNormal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbTest2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxEditCustomized;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}

