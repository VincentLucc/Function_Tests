
namespace _QuickTest_Framwork472
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbGapInput = new System.Windows.Forms.TextBox();
            this.bThreadGapTest = new System.Windows.Forms.Button();
            this.bDateTimeOffset = new System.Windows.Forms.Button();
            this.bQUickStringTest = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbGapInput);
            this.groupBox1.Controls.Add(this.bThreadGapTest);
            this.groupBox1.Controls.Add(this.bDateTimeOffset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tbGapInput
            // 
            this.tbGapInput.Location = new System.Drawing.Point(122, 50);
            this.tbGapInput.Name = "tbGapInput";
            this.tbGapInput.Size = new System.Drawing.Size(51, 20);
            this.tbGapInput.TabIndex = 2;
            this.tbGapInput.Text = "10";
            // 
            // bThreadGapTest
            // 
            this.bThreadGapTest.Location = new System.Drawing.Point(6, 48);
            this.bThreadGapTest.Name = "bThreadGapTest";
            this.bThreadGapTest.Size = new System.Drawing.Size(98, 23);
            this.bThreadGapTest.TabIndex = 1;
            this.bThreadGapTest.Text = "Thread Gap Test";
            this.bThreadGapTest.UseVisualStyleBackColor = true;
            this.bThreadGapTest.Click += new System.EventHandler(this.bThreadGapTest_Click);
            // 
            // bDateTimeOffset
            // 
            this.bDateTimeOffset.Location = new System.Drawing.Point(6, 19);
            this.bDateTimeOffset.Name = "bDateTimeOffset";
            this.bDateTimeOffset.Size = new System.Drawing.Size(98, 23);
            this.bDateTimeOffset.TabIndex = 0;
            this.bDateTimeOffset.Text = "DateTime Offset";
            this.bDateTimeOffset.UseVisualStyleBackColor = true;
            this.bDateTimeOffset.Click += new System.EventHandler(this.bDateTimeOffset_Click);
            // 
            // bQUickStringTest
            // 
            this.bQUickStringTest.Location = new System.Drawing.Point(6, 19);
            this.bQUickStringTest.Name = "bQUickStringTest";
            this.bQUickStringTest.Size = new System.Drawing.Size(98, 23);
            this.bQUickStringTest.TabIndex = 3;
            this.bQUickStringTest.Text = "Quick String Test";
            this.bQUickStringTest.UseVisualStyleBackColor = true;
            this.bQUickStringTest.Click += new System.EventHandler(this.bQUickStringTest_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(348, 146);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bQUickStringTest);
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 214);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bDateTimeOffset;
        private System.Windows.Forms.Button bThreadGapTest;
        private System.Windows.Forms.TextBox tbGapInput;
        private System.Windows.Forms.Button bQUickStringTest;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

