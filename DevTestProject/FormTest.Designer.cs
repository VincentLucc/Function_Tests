
namespace TestProject
{
    partial class FormTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.bClose = new DevExpress.XtraEditors.SimpleButton();
            this.bSave = new DevExpress.XtraEditors.SimpleButton();
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.tab1 = new DevExpress.XtraVerticalGrid.Tab();
            this.tab2 = new DevExpress.XtraVerticalGrid.Tab();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pRight = new System.Windows.Forms.Panel();
            this.propertyDescriptionControl1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.pLeft = new System.Windows.Forms.Panel();
            this.pBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.pRight.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 0);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(540, 450);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 450);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(800, 0);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // bClose
            // 
            this.bClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bClose.ImageOptions.Image")));
            this.bClose.Location = new System.Drawing.Point(733, 17);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(61, 22);
            this.bClose.TabIndex = 7;
            this.bClose.Text = "Close";
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bSave
            // 
            this.bSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bSave.ImageOptions.Image")));
            this.bSave.Location = new System.Drawing.Point(651, 17);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(61, 22);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "Save";
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.AutoGenerateRows = false;
            this.propertyGridControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.SelectedObject = this;
            this.propertyGridControl1.SelectedTab = this.tab1;
            this.propertyGridControl1.Size = new System.Drawing.Size(604, 391);
            this.propertyGridControl1.TabIndex = 4;
            this.propertyGridControl1.Tabs.AddRange(new DevExpress.XtraVerticalGrid.Tab[] {
            this.tab1,
            this.tab2});
            // 
            // tab1
            // 
            this.tab1.Caption = "Default";
            this.tab1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tab1.ImageOptions.Image")));
            this.tab1.Name = "tab1";
            this.tab1.UseCaption = false;
            // 
            // tab2
            // 
            this.tab2.Caption = "Extra";
            this.tab2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tab2.ImageOptions.Image")));
            this.tab2.Name = "tab2";
            this.tab2.UseCaption = false;
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.pRight);
            this.groupControl1.Controls.Add(this.pLeft);
            this.groupControl1.Controls.Add(this.pBottom);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(808, 450);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Root";
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.propertyDescriptionControl1);
            this.pRight.Controls.Add(this.propertyGridControl1);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(202, 2);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(604, 391);
            this.pRight.TabIndex = 9;
            // 
            // propertyDescriptionControl1
            // 
            this.propertyDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.propertyDescriptionControl1.Location = new System.Drawing.Point(0, 319);
            this.propertyDescriptionControl1.Name = "propertyDescriptionControl1";
            this.propertyDescriptionControl1.Size = new System.Drawing.Size(604, 72);
            this.propertyDescriptionControl1.TabIndex = 5;
            this.propertyDescriptionControl1.TabStop = false;
            // 
            // pLeft
            // 
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(2, 2);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(200, 391);
            this.pLeft.TabIndex = 8;
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.bClose);
            this.pBottom.Controls.Add(this.bSave);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(2, 393);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(804, 55);
            this.pBottom.TabIndex = 10;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.accordionControl1);
            this.Name = "FormTest";
            this.ShowIcon = false;
            this.Text = "Test Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTest_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTest_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraEditors.SimpleButton bClose;
        private DevExpress.XtraEditors.SimpleButton bSave;
        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel pRight;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl1;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pBottom;
        private DevExpress.XtraVerticalGrid.Tab tab1;
        private DevExpress.XtraVerticalGrid.Tab tab2;
    }
}