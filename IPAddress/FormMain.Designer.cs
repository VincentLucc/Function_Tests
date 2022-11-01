namespace IPAddressHelper
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CheckSimpleButon = new DevExpress.XtraEditors.SimpleButton();
            this.bCheck = new DevExpress.XtraEditors.SimpleButton();
            this.IPAddressSimpleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IPAddressMaskTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressSimpleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressMaskTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CheckSimpleButon);
            this.layoutControl1.Controls.Add(this.bCheck);
            this.layoutControl1.Controls.Add(this.IPAddressSimpleTextEdit);
            this.layoutControl1.Controls.Add(this.IPAddressMaskTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(387, 432);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CheckSimpleButon
            // 
            this.CheckSimpleButon.Location = new System.Drawing.Point(295, 38);
            this.CheckSimpleButon.Name = "CheckSimpleButon";
            this.CheckSimpleButon.Size = new System.Drawing.Size(80, 22);
            this.CheckSimpleButon.StyleController = this.layoutControl1;
            this.CheckSimpleButon.TabIndex = 4;
            this.CheckSimpleButon.Text = "Check";
            this.CheckSimpleButon.Click += new System.EventHandler(this.CheckSimpleButon_Click);
            // 
            // bCheck
            // 
            this.bCheck.Location = new System.Drawing.Point(295, 12);
            this.bCheck.Name = "bCheck";
            this.bCheck.Size = new System.Drawing.Size(80, 22);
            this.bCheck.StyleController = this.layoutControl1;
            this.bCheck.TabIndex = 2;
            this.bCheck.Text = "Check";
            this.bCheck.Click += new System.EventHandler(this.bCheck_Click);
            // 
            // IPAddressSimpleTextEdit
            // 
            this.IPAddressSimpleTextEdit.EditValue = "192.168.2.2";
            this.IPAddressSimpleTextEdit.Location = new System.Drawing.Point(184, 38);
            this.IPAddressSimpleTextEdit.Name = "IPAddressSimpleTextEdit";
            this.IPAddressSimpleTextEdit.Size = new System.Drawing.Size(107, 20);
            this.IPAddressSimpleTextEdit.StyleController = this.layoutControl1;
            this.IPAddressSimpleTextEdit.TabIndex = 3;
            // 
            // IPAddressMaskTextEdit
            // 
            this.IPAddressMaskTextEdit.EditValue = "192.168.11.11/24";
            this.IPAddressMaskTextEdit.Location = new System.Drawing.Point(184, 12);
            this.IPAddressMaskTextEdit.Name = "IPAddressMaskTextEdit";
            this.IPAddressMaskTextEdit.Size = new System.Drawing.Size(107, 20);
            this.IPAddressMaskTextEdit.StyleController = this.layoutControl1;
            this.IPAddressMaskTextEdit.TabIndex = 0;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(387, 432);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.IPAddressMaskTextEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(283, 26);
            this.layoutControlItem1.Text = "IP Address: (192.168.1.22/24)";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(160, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 52);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(367, 360);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.IPAddressSimpleTextEdit;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(283, 26);
            this.layoutControlItem2.Text = "IP Address Simple: (192.168.1.1)";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(160, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.bCheck;
            this.layoutControlItem4.Location = new System.Drawing.Point(283, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.CheckSimpleButon;
            this.layoutControlItem3.Location = new System.Drawing.Point(283, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(84, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 432);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressSimpleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IPAddressMaskTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit IPAddressSimpleTextEdit;
        private DevExpress.XtraEditors.TextEdit IPAddressMaskTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton bCheck;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton CheckSimpleButon;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}