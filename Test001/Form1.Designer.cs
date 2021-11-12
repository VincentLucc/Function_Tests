
namespace Test001
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.columnSelectorControl1 = new Test001.ColumnSelectorControlSingle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bAdd = new DevExpress.XtraEditors.SimpleButton();
            this.bClear = new DevExpress.XtraEditors.SimpleButton();
            this.bReload = new DevExpress.XtraEditors.SimpleButton();
            this.bModify = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(295, 399);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // columnSelectorControl1
            // 
            this.columnSelectorControl1.Appearance.Font = new System.Drawing.Font("Consolas", 12F);
            this.columnSelectorControl1.Appearance.Options.UseFont = true;
            this.columnSelectorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnSelectorControl1.FontSize = 12F;
            this.columnSelectorControl1.Location = new System.Drawing.Point(0, 0);
            this.columnSelectorControl1.Margin = new System.Windows.Forms.Padding(4);
            this.columnSelectorControl1.MarkerColor = System.Drawing.Color.Gray;
            this.columnSelectorControl1.MaxAllowedColumns = 32;
            this.columnSelectorControl1.Name = "columnSelectorControl1";
            this.columnSelectorControl1.Padding = new System.Windows.Forms.Padding(4);
            this.columnSelectorControl1.Size = new System.Drawing.Size(814, 450);
            this.columnSelectorControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(519, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 450);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bModify);
            this.panel2.Controls.Add(this.bAdd);
            this.panel2.Controls.Add(this.bClear);
            this.panel2.Controls.Add(this.bReload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 399);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 51);
            this.panel2.TabIndex = 5;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(30, 12);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(54, 23);
            this.bAdd.TabIndex = 5;
            this.bAdd.Text = "Add";
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(148, 12);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(54, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bReload
            // 
            this.bReload.Location = new System.Drawing.Point(208, 12);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(75, 23);
            this.bReload.TabIndex = 4;
            this.bReload.Text = "Reload";
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // bModify
            // 
            this.bModify.Location = new System.Drawing.Point(90, 12);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(54, 23);
            this.bModify.TabIndex = 6;
            this.bModify.Text = "Modify";
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.columnSelectorControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private ColumnSelectorControlSingle columnSelectorControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton bClear;
        private DevExpress.XtraEditors.SimpleButton bReload;
        private DevExpress.XtraEditors.SimpleButton bAdd;
        private DevExpress.XtraEditors.SimpleButton bModify;
    }
}

