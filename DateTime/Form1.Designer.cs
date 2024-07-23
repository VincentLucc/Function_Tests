namespace DateTimeProject
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
            this.bTimeGap = new System.Windows.Forms.Button();
            this.TimeTicksButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bTimeGap
            // 
            this.bTimeGap.Location = new System.Drawing.Point(44, 44);
            this.bTimeGap.Name = "bTimeGap";
            this.bTimeGap.Size = new System.Drawing.Size(75, 23);
            this.bTimeGap.TabIndex = 0;
            this.bTimeGap.Text = "Time Gap";
            this.bTimeGap.UseVisualStyleBackColor = true;
            this.bTimeGap.Click += new System.EventHandler(this.bTimeGap_Click);
            // 
            // TimeTicksButton
            // 
            this.TimeTicksButton.Location = new System.Drawing.Point(44, 84);
            this.TimeTicksButton.Name = "TimeTicksButton";
            this.TimeTicksButton.Size = new System.Drawing.Size(75, 23);
            this.TimeTicksButton.TabIndex = 1;
            this.TimeTicksButton.Text = "Time Ticks";
            this.TimeTicksButton.UseVisualStyleBackColor = true;
            this.TimeTicksButton.Click += new System.EventHandler(this.TimeTicksButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimeTicksButton);
            this.Controls.Add(this.bTimeGap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bTimeGap;
        private System.Windows.Forms.Button TimeTicksButton;
    }
}

