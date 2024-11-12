
namespace Dev_Theme
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
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.MainAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.OpenAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.SaveAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.SaveAsAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.CloseAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.OperationAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.RunProjectAccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.MainAccordionControlElement,
            this.OperationAccordionControlElement});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always;
            this.accordionControl1.ShowItemExpandButtons = false;
            this.accordionControl1.Size = new System.Drawing.Size(250, 427);
            this.accordionControl1.TabIndex = 0;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            this.accordionControl1.Click += new System.EventHandler(this.accordionControl1_Click);
            // 
            // MainAccordionControlElement
            // 
            this.MainAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.OpenAccordionControlElement,
            this.SaveAccordionControlElement,
            this.SaveAsAccordionControlElement,
            this.CloseAccordionControlElement,
            this.accordionControlElement1});
            this.MainAccordionControlElement.Expanded = true;
            this.MainAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("MainAccordionControlElement.ImageOptions.SvgImage")));
            this.MainAccordionControlElement.Name = "MainAccordionControlElement";
            this.MainAccordionControlElement.Text = "Main";
            // 
            // OpenAccordionControlElement
            // 
            this.OpenAccordionControlElement.HeaderIndent = 10;
            this.OpenAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("OpenAccordionControlElement.ImageOptions.SvgImage")));
            this.OpenAccordionControlElement.Name = "OpenAccordionControlElement";
            this.OpenAccordionControlElement.Text = "Open";
            // 
            // SaveAccordionControlElement
            // 
            this.SaveAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveAccordionControlElement.ImageOptions.SvgImage")));
            this.SaveAccordionControlElement.Name = "SaveAccordionControlElement";
            this.SaveAccordionControlElement.Text = "Save";
            // 
            // SaveAsAccordionControlElement
            // 
            this.SaveAsAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("SaveAsAccordionControlElement.ImageOptions.SvgImage")));
            this.SaveAsAccordionControlElement.Name = "SaveAsAccordionControlElement";
            this.SaveAsAccordionControlElement.Text = "Save As";
            // 
            // CloseAccordionControlElement
            // 
            this.CloseAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("CloseAccordionControlElement.ImageOptions.SvgImage")));
            this.CloseAccordionControlElement.Name = "CloseAccordionControlElement";
            this.CloseAccordionControlElement.Text = "Close";
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("accordionControlElement1.ImageOptions.SvgImage")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Test";
            // 
            // OperationAccordionControlElement
            // 
            this.OperationAccordionControlElement.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.RunProjectAccordionControlElement});
            this.OperationAccordionControlElement.Expanded = true;
            this.OperationAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("OperationAccordionControlElement.ImageOptions.SvgImage")));
            this.OperationAccordionControlElement.Name = "OperationAccordionControlElement";
            this.OperationAccordionControlElement.Text = "Element2";
            // 
            // RunProjectAccordionControlElement
            // 
            this.RunProjectAccordionControlElement.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("RunProjectAccordionControlElement.ImageOptions.SvgImage")));
            this.RunProjectAccordionControlElement.Name = "RunProjectAccordionControlElement";
            this.RunProjectAccordionControlElement.Text = "Start Project";
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(250, 30);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(490, 427);
            this.fluentDesignFormContainer1.TabIndex = 2;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(740, 30);
            this.fluentDesignFormControl1.TabIndex = 3;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 457);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "Form1";
            this.NavigationControl = this.accordionControl1;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MainAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement OpenAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement SaveAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement SaveAsAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement CloseAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement OperationAccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement RunProjectAccordionControlElement;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
    }
}

