
namespace Properties
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
            this.propertyGridControl1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyDescriptionControl1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // propertyGridControl1
            // 
            this.propertyGridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridControl1.Location = new System.Drawing.Point(0, 0);
            this.propertyGridControl1.Name = "propertyGridControl1";
            this.propertyGridControl1.Size = new System.Drawing.Size(295, 515);
            this.propertyGridControl1.TabIndex = 0;
            this.propertyGridControl1.Click += new System.EventHandler(this.propertyGridControl1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyDescriptionControl1);
            this.panel1.Controls.Add(this.propertyGridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(503, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 515);
            this.panel1.TabIndex = 1;
            // 
            // propertyDescriptionControl1
            // 
            this.propertyDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.propertyDescriptionControl1.Location = new System.Drawing.Point(0, 415);
            this.propertyDescriptionControl1.Name = "propertyDescriptionControl1";
            this.propertyDescriptionControl1.Size = new System.Drawing.Size(295, 100);
            this.propertyDescriptionControl1.TabIndex = 1;
            this.propertyDescriptionControl1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(149, 515);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(183, 33);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 515);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.propertyGridControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl propertyGridControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl propertyDescriptionControl1;
        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}

