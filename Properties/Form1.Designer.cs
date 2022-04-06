
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
            this.pg1 = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pDescription = new System.Windows.Forms.Panel();
            this.pd1 = new DevExpress.XtraVerticalGrid.PropertyDescriptionControl();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.te1 = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pg1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te1.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pg1
            // 
            this.pg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg1.Location = new System.Drawing.Point(0, 0);
            this.pg1.Name = "pg1";
            this.pg1.OptionsBehavior.AutoPostEditorDelay = 1000;
            this.pg1.OptionsCollectionEditor.AllowMultiSelect = false;
            this.pg1.Size = new System.Drawing.Size(450, 429);
            this.pg1.TabIndex = 0;
            this.pg1.DataSourceChanged += new System.EventHandler(this.pg1_DataSourceChanged);
            this.pg1.Click += new System.EventHandler(this.propertyGridControl1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pg1);
            this.panel1.Controls.Add(this.pDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(484, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 511);
            this.panel1.TabIndex = 1;
            // 
            // pDescription
            // 
            this.pDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDescription.Controls.Add(this.pd1);
            this.pDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pDescription.Location = new System.Drawing.Point(0, 429);
            this.pDescription.Name = "pDescription";
            this.pDescription.Size = new System.Drawing.Size(450, 82);
            this.pDescription.TabIndex = 4;
            // 
            // pd1
            // 
            this.pd1.Appearance.Panel.BorderColor = System.Drawing.Color.Blue;
            this.pd1.Appearance.Panel.Options.UseBorderColor = true;
            this.pd1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pd1.Location = new System.Drawing.Point(0, 0);
            this.pd1.Name = "pd1";
            this.pd1.Size = new System.Drawing.Size(448, 80);
            this.pd1.TabIndex = 1;
            this.pd1.TabStop = false;
            // 
            // lb1
            // 
            this.lb1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb1.FormattingEnabled = true;
            this.lb1.Location = new System.Drawing.Point(0, 0);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(149, 511);
            this.lb1.TabIndex = 2;
            this.lb1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // te1
            // 
            this.te1.Location = new System.Drawing.Point(17, 19);
            this.te1.Name = "te1";
            this.te1.Size = new System.Drawing.Size(100, 20);
            this.te1.TabIndex = 3;
            this.te1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.te1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(149, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 511);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 511);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pg1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.te1.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.PropertyGridControl pg1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraVerticalGrid.PropertyDescriptionControl pd1;
        private System.Windows.Forms.ListBox lb1;
        private DevExpress.XtraEditors.TextEdit te1;
        private System.Windows.Forms.Panel pDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

