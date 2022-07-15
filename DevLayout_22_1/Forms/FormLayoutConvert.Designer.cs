
namespace DevLayout_22_1
{
    partial class FormLayoutConvert
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.FormLayoutConvertlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.panel1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel2item = new DevExpress.XtraLayout.LayoutControlItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormLayoutConvertlayoutControl1ConvertedLayout)).BeginInit();
            this.FormLayoutConvertlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2item)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textEdit1);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 287);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Location = new System.Drawing.Point(12, 303);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 135);
            this.panel2.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(689, 39);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "OK";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(334, 218);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 0;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(203, 103);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(349, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // FormLayoutConvertlayoutControl1ConvertedLayout
            // 
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Controls.Add(this.panel1);
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Controls.Add(this.panel2);
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Name = "FormLayoutConvertlayoutControl1ConvertedLayout";
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.FormLayoutConvertlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(800, 450);
            this.FormLayoutConvertlayoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.panel1item,
            this.panel2item});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // panel1item
            // 
            this.panel1item.Control = this.panel1;
            this.panel1item.Location = new System.Drawing.Point(0, 0);
            this.panel1item.Name = "panel1item";
            this.panel1item.Size = new System.Drawing.Size(780, 291);
            this.panel1item.TextSize = new System.Drawing.Size(0, 0);
            this.panel1item.TextVisible = false;
            // 
            // panel2item
            // 
            this.panel2item.Control = this.panel2;
            this.panel2item.Location = new System.Drawing.Point(0, 291);
            this.panel2item.Name = "panel2item";
            this.panel2item.Size = new System.Drawing.Size(780, 139);
            this.panel2item.TextSize = new System.Drawing.Size(0, 0);
            this.panel2item.TextVisible = false;
            // 
            // FormLayoutConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormLayoutConvertlayoutControl1ConvertedLayout);
            this.Name = "FormLayoutConvert";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FormLayoutConvertlayoutControl1ConvertedLayout)).EndInit();
            this.FormLayoutConvertlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraLayout.LayoutControl FormLayoutConvertlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem panel1item;
        private DevExpress.XtraLayout.LayoutControlItem panel2item;
    }
}