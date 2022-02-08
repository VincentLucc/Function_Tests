
namespace ComboBox
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
            this.cbTest01 = new System.Windows.Forms.ComboBox();
            this.bUpdate = new System.Windows.Forms.Button();
            this.icbTest = new DevExpress.XtraEditors.ImageComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.icbTest.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTest01
            // 
            this.cbTest01.FormattingEnabled = true;
            this.cbTest01.Location = new System.Drawing.Point(66, 52);
            this.cbTest01.Name = "cbTest01";
            this.cbTest01.Size = new System.Drawing.Size(121, 21);
            this.cbTest01.TabIndex = 0;
            // 
            // bUpdate
            // 
            this.bUpdate.Location = new System.Drawing.Point(66, 104);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(121, 23);
            this.bUpdate.TabIndex = 1;
            this.bUpdate.Text = "Update Items";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_Click);
            // 
            // icbTest
            // 
            this.icbTest.Location = new System.Drawing.Point(229, 52);
            this.icbTest.Name = "icbTest";
            this.icbTest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.icbTest.Size = new System.Drawing.Size(106, 20);
            this.icbTest.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.icbTest);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.cbTest01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icbTest.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTest01;
        private System.Windows.Forms.Button bUpdate;
        private DevExpress.XtraEditors.ImageComboBoxEdit icbTest;
    }
}

