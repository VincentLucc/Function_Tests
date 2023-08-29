namespace ThreadingDelay
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
            this.TaskDelayButton = new System.Windows.Forms.Button();
            this.ThreadDelayButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TaskDelayButton
            // 
            this.TaskDelayButton.Location = new System.Drawing.Point(12, 63);
            this.TaskDelayButton.Name = "TaskDelayButton";
            this.TaskDelayButton.Size = new System.Drawing.Size(135, 23);
            this.TaskDelayButton.TabIndex = 0;
            this.TaskDelayButton.Text = "Task Delay";
            this.TaskDelayButton.UseVisualStyleBackColor = true;
            this.TaskDelayButton.Click += new System.EventHandler(this.TaskDelayButton_Click);
            // 
            // ThreadDelayButton
            // 
            this.ThreadDelayButton.Location = new System.Drawing.Point(12, 92);
            this.ThreadDelayButton.Name = "ThreadDelayButton";
            this.ThreadDelayButton.Size = new System.Drawing.Size(135, 23);
            this.ThreadDelayButton.TabIndex = 1;
            this.ThreadDelayButton.Text = "Thread Sleep";
            this.ThreadDelayButton.UseVisualStyleBackColor = true;
            this.ThreadDelayButton.Click += new System.EventHandler(this.ThreadDelayButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 139);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(388, 299);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = ">>>I7-6700, 1000 cycles\n//10ms\nDoSomeTaskDelay:15644\nDoSomeThreadSleep:11067\n\n//5" +
    "ms\nDoSomeTaskDelay:15654\nDoSomeThreadSleep:6115\n\n//2ms\nDoSomeTaskDelay:15643\nDoS" +
    "omeThreadSleep:3015\n\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ThreadDelayButton);
            this.Controls.Add(this.TaskDelayButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TaskDelayButton;
        private System.Windows.Forms.Button ThreadDelayButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

