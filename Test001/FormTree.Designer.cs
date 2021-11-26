
namespace Test001
{
    partial class FormTree
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
            this.DataFieldsConfigTreeList = new DevExpress.XtraTreeList.TreeList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.bAdd = new DevExpress.XtraEditors.SimpleButton();
            this.bReload = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataFieldsConfigTreeList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DataFieldsConfigTreeList
            // 
            this.DataFieldsConfigTreeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.DataFieldsConfigTreeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DataFieldsConfigTreeList.Appearance.Row.Options.UseTextOptions = true;
            this.DataFieldsConfigTreeList.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DataFieldsConfigTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataFieldsConfigTreeList.Location = new System.Drawing.Point(0, 100);
            this.DataFieldsConfigTreeList.Name = "DataFieldsConfigTreeList";
            this.DataFieldsConfigTreeList.OptionsCustomization.AllowFilter = false;
            this.DataFieldsConfigTreeList.OptionsCustomization.AllowSort = false;
            this.DataFieldsConfigTreeList.Size = new System.Drawing.Size(800, 350);
            this.DataFieldsConfigTreeList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toggleSwitch1);
            this.panel1.Controls.Add(this.simpleButton4);
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Controls.Add(this.bReload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(635, 38);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = "Show MainFields";
            this.toggleSwitch1.Properties.OnText = "Show CustomFields";
            this.toggleSwitch1.Size = new System.Drawing.Size(153, 24);
            this.toggleSwitch1.TabIndex = 6;
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(464, 35);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(98, 23);
            this.simpleButton4.TabIndex = 5;
            this.simpleButton4.Text = "Switch Columns";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(368, 36);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(58, 23);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Collapse";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(304, 36);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(58, 23);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Expand";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(207, 36);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(58, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Add Sub";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(125, 36);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(58, 23);
            this.bAdd.TabIndex = 1;
            this.bAdd.Text = "Add Main";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bReload
            // 
            this.bReload.Location = new System.Drawing.Point(40, 36);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(58, 23);
            this.bReload.TabIndex = 0;
            this.bReload.Text = "Reload";
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // FormTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataFieldsConfigTreeList);
            this.Controls.Add(this.panel1);
            this.Name = "FormTree";
            this.Text = "FormTree";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTree_FormClosing);
            this.Load += new System.EventHandler(this.FormTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataFieldsConfigTreeList)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList DataFieldsConfigTreeList;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton bReload;
        private DevExpress.XtraEditors.SimpleButton bAdd;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
    }
}