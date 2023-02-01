
namespace FormLoad
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
            this.bFormEvent = new System.Windows.Forms.Button();
            this.bFormLoadTest = new System.Windows.Forms.Button();
            this.bReload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bFormEvent
            // 
            this.bFormEvent.Location = new System.Drawing.Point(12, 41);
            this.bFormEvent.Name = "bFormEvent";
            this.bFormEvent.Size = new System.Drawing.Size(75, 23);
            this.bFormEvent.TabIndex = 0;
            this.bFormEvent.Text = "Form Event";
            this.bFormEvent.UseVisualStyleBackColor = true;
            this.bFormEvent.Click += new System.EventHandler(this.bFormEvent_Click);
            // 
            // bFormLoadTest
            // 
            this.bFormLoadTest.Location = new System.Drawing.Point(12, 12);
            this.bFormLoadTest.Name = "bFormLoadTest";
            this.bFormLoadTest.Size = new System.Drawing.Size(93, 23);
            this.bFormLoadTest.TabIndex = 1;
            this.bFormLoadTest.Text = "Form Load Test";
            this.bFormLoadTest.UseVisualStyleBackColor = true;
            this.bFormLoadTest.Click += new System.EventHandler(this.bFormLoadTest_Click);
            // 
            // bReload
            // 
            this.bReload.Location = new System.Drawing.Point(13, 71);
            this.bReload.Name = "bReload";
            this.bReload.Size = new System.Drawing.Size(105, 23);
            this.bReload.TabIndex = 2;
            this.bReload.Text = "Form Reload Test";
            this.bReload.UseVisualStyleBackColor = true;
            this.bReload.Click += new System.EventHandler(this.bReload_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 174);
            this.Controls.Add(this.bReload);
            this.Controls.Add(this.bFormLoadTest);
            this.Controls.Add(this.bFormEvent);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bFormEvent;
        private System.Windows.Forms.Button bFormLoadTest;
        private System.Windows.Forms.Button bReload;
    }
}

