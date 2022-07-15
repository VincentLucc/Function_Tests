
namespace WizardControl
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
            this.bWizardFormDefault = new DevExpress.XtraEditors.SimpleButton();
            this.bWizardControlDefault = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bWizardControlTracker = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bWizardControlTracker);
            this.layoutControl1.Controls.Add(this.bWizardFormDefault);
            this.layoutControl1.Controls.Add(this.bWizardControlDefault);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(301, 250);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bWizardFormDefault
            // 
            this.bWizardFormDefault.Location = new System.Drawing.Point(129, 64);
            this.bWizardFormDefault.Name = "bWizardFormDefault";
            this.bWizardFormDefault.Size = new System.Drawing.Size(160, 22);
            this.bWizardFormDefault.StyleController = this.layoutControl1;
            this.bWizardFormDefault.TabIndex = 5;
            this.bWizardFormDefault.Text = "Start";
            this.bWizardFormDefault.Click += new System.EventHandler(this.bWizardFormDefault_Click);
            // 
            // bWizardControlDefault
            // 
            this.bWizardControlDefault.Location = new System.Drawing.Point(129, 12);
            this.bWizardControlDefault.Name = "bWizardControlDefault";
            this.bWizardControlDefault.Size = new System.Drawing.Size(160, 22);
            this.bWizardControlDefault.StyleController = this.layoutControl1;
            this.bWizardControlDefault.TabIndex = 4;
            this.bWizardControlDefault.Text = "Start";
            this.bWizardControlDefault.Click += new System.EventHandler(this.bWizardControlDefault_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(301, 250);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.bWizardControlDefault;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem1.Text = "Default Wizard Control:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(114, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 78);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(281, 152);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.bWizardFormDefault;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem2.Text = "Wizard Form:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 13);
            // 
            // bWizardControlTracker
            // 
            this.bWizardControlTracker.Location = new System.Drawing.Point(129, 38);
            this.bWizardControlTracker.Name = "bWizardControlTracker";
            this.bWizardControlTracker.Size = new System.Drawing.Size(160, 22);
            this.bWizardControlTracker.StyleController = this.layoutControl1;
            this.bWizardControlTracker.TabIndex = 6;
            this.bWizardControlTracker.Text = "Start";
            this.bWizardControlTracker.Click += new System.EventHandler(this.bWizardControlTracker_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.bWizardControlTracker;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem3.Text = "Wizard Control Tracker:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 13);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 250);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton bWizardFormDefault;
        private DevExpress.XtraEditors.SimpleButton bWizardControlDefault;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton bWizardControlTracker;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}

