namespace WebClient.Forms
{
    partial class GTINEditForm
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
            this.CancelButton = new DevExpress.XtraEditors.SimpleButton();
            this.OKButton = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.AutoReserveToggleSwitch = new DevExpress.XtraEditors.ToggleSwitch();
            this.ReserveSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.DescriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.GTINTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ProductNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoReserveToggleSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTINTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CancelButton);
            this.layoutControl1.Controls.Add(this.AutoReserveToggleSwitch);
            this.layoutControl1.Controls.Add(this.ReserveSpinEdit);
            this.layoutControl1.Controls.Add(this.DescriptionTextEdit);
            this.layoutControl1.Controls.Add(this.GTINTextEdit);
            this.layoutControl1.Controls.Add(this.ProductNameTextEdit);
            this.layoutControl1.Controls.Add(this.OKButton);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(452, 321);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(360, 287);
            this.CancelButton.MaximumSize = new System.Drawing.Size(80, 0);
            this.CancelButton.MinimumSize = new System.Drawing.Size(80, 0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 22);
            this.CancelButton.StyleController = this.layoutControl1;
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(276, 287);
            this.OKButton.MaximumSize = new System.Drawing.Size(80, 0);
            this.OKButton.MinimumSize = new System.Drawing.Size(80, 0);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 22);
            this.OKButton.StyleController = this.layoutControl1;
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(452, 321);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.OKButton;
            this.layoutControlItem1.Location = new System.Drawing.Point(264, 275);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 275);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(264, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 106);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(432, 169);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.CancelButton;
            this.layoutControlItem7.Location = new System.Drawing.Point(348, 275);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // AutoReserveToggleSwitch
            // 
            this.AutoReserveToggleSwitch.Location = new System.Drawing.Point(108, 90);
            this.AutoReserveToggleSwitch.Name = "AutoReserveToggleSwitch";
            this.AutoReserveToggleSwitch.Properties.OffText = "Off";
            this.AutoReserveToggleSwitch.Properties.OnText = "On";
            this.AutoReserveToggleSwitch.Properties.ShowText = false;
            this.AutoReserveToggleSwitch.Size = new System.Drawing.Size(81, 24);
            this.AutoReserveToggleSwitch.StyleController = this.layoutControl1;
            this.AutoReserveToggleSwitch.TabIndex = 9;
            this.AutoReserveToggleSwitch.Toggled += new System.EventHandler(this.AutoReserveToggleSwitch_Toggled);
            // 
            // ReserveSpinEdit
            // 
            this.ReserveSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ReserveSpinEdit.Location = new System.Drawing.Point(289, 90);
            this.ReserveSpinEdit.Name = "ReserveSpinEdit";
            this.ReserveSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReserveSpinEdit.Properties.IsFloatValue = false;
            this.ReserveSpinEdit.Properties.MaskSettings.Set("mask", "N00");
            this.ReserveSpinEdit.Size = new System.Drawing.Size(151, 22);
            this.ReserveSpinEdit.StyleController = this.layoutControl1;
            this.ReserveSpinEdit.TabIndex = 8;
            this.ReserveSpinEdit.EditValueChanged += new System.EventHandler(this.ReserveSpinEdit_EditValueChanged);
            // 
            // DescriptionTextEdit
            // 
            this.DescriptionTextEdit.Location = new System.Drawing.Point(108, 64);
            this.DescriptionTextEdit.Name = "DescriptionTextEdit";
            this.DescriptionTextEdit.Size = new System.Drawing.Size(332, 22);
            this.DescriptionTextEdit.StyleController = this.layoutControl1;
            this.DescriptionTextEdit.TabIndex = 7;
            this.DescriptionTextEdit.EditValueChanged += new System.EventHandler(this.DescriptionTextEdit_EditValueChanged);
            // 
            // GTINTextEdit
            // 
            this.GTINTextEdit.Location = new System.Drawing.Point(108, 38);
            this.GTINTextEdit.Name = "GTINTextEdit";
            this.GTINTextEdit.Size = new System.Drawing.Size(332, 22);
            this.GTINTextEdit.StyleController = this.layoutControl1;
            this.GTINTextEdit.TabIndex = 6;
            this.GTINTextEdit.EditValueChanged += new System.EventHandler(this.GTINTextEdit_EditValueChanged);
            // 
            // ProductNameTextEdit
            // 
            this.ProductNameTextEdit.Location = new System.Drawing.Point(108, 12);
            this.ProductNameTextEdit.Name = "ProductNameTextEdit";
            this.ProductNameTextEdit.Size = new System.Drawing.Size(332, 22);
            this.ProductNameTextEdit.StyleController = this.layoutControl1;
            this.ProductNameTextEdit.TabIndex = 5;
            this.ProductNameTextEdit.EditValueChanged += new System.EventHandler(this.ProductNameTextEdit_EditValueChanged);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ProductNameTextEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(432, 26);
            this.layoutControlItem2.Text = "Product Name:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.GTINTextEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(432, 26);
            this.layoutControlItem3.Text = "GTIN";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.DescriptionTextEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(432, 26);
            this.layoutControlItem4.Text = "Description:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.AutoReserveToggleSwitch;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(181, 28);
            this.layoutControlItem6.Text = "Auto Reserve:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(84, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ReserveSpinEdit;
            this.layoutControlItem5.Location = new System.Drawing.Point(181, 78);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(251, 28);
            this.layoutControlItem5.Text = "Reserve Amount:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(84, 13);
            // 
            // GTINEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 321);
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "GTINEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit GTIN";
            this.Load += new System.EventHandler(this.GTINEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoReserveToggleSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReserveSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GTINTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton OKButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.TextEdit ProductNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit GTINTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.ToggleSwitch AutoReserveToggleSwitch;
        private DevExpress.XtraEditors.SpinEdit ReserveSpinEdit;
        private DevExpress.XtraEditors.TextEdit DescriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton CancelButton;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}