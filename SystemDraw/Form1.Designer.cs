
namespace SystemDraw
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
            this.pPaint = new System.Windows.Forms.Panel();
            this.pControl = new System.Windows.Forms.Panel();
            this.bDrawEllipse = new System.Windows.Forms.Button();
            this.bDrawArc = new System.Windows.Forms.Button();
            this.bScreenShot = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pPaint
            // 
            this.pPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPaint.Location = new System.Drawing.Point(200, 0);
            this.pPaint.Name = "pPaint";
            this.pPaint.Size = new System.Drawing.Size(600, 450);
            this.pPaint.TabIndex = 0;
            // 
            // pControl
            // 
            this.pControl.Controls.Add(this.button1);
            this.pControl.Controls.Add(this.bDrawEllipse);
            this.pControl.Controls.Add(this.bDrawArc);
            this.pControl.Controls.Add(this.bScreenShot);
            this.pControl.Controls.Add(this.bClear);
            this.pControl.Controls.Add(this.bTest);
            this.pControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pControl.Location = new System.Drawing.Point(0, 0);
            this.pControl.Name = "pControl";
            this.pControl.Size = new System.Drawing.Size(200, 450);
            this.pControl.TabIndex = 0;
            // 
            // bDrawEllipse
            // 
            this.bDrawEllipse.Location = new System.Drawing.Point(28, 298);
            this.bDrawEllipse.Name = "bDrawEllipse";
            this.bDrawEllipse.Size = new System.Drawing.Size(112, 23);
            this.bDrawEllipse.TabIndex = 4;
            this.bDrawEllipse.Text = "Draw Ellipse";
            this.bDrawEllipse.UseVisualStyleBackColor = true;
            this.bDrawEllipse.Click += new System.EventHandler(this.bDrawEllipse_Click);
            // 
            // bDrawArc
            // 
            this.bDrawArc.Location = new System.Drawing.Point(28, 269);
            this.bDrawArc.Name = "bDrawArc";
            this.bDrawArc.Size = new System.Drawing.Size(112, 23);
            this.bDrawArc.TabIndex = 3;
            this.bDrawArc.Text = "Draw Arc";
            this.bDrawArc.UseVisualStyleBackColor = true;
            this.bDrawArc.Click += new System.EventHandler(this.bDrawArc_Click);
            // 
            // bScreenShot
            // 
            this.bScreenShot.Location = new System.Drawing.Point(28, 240);
            this.bScreenShot.Name = "bScreenShot";
            this.bScreenShot.Size = new System.Drawing.Size(112, 23);
            this.bScreenShot.TabIndex = 2;
            this.bScreenShot.Text = "ScreenShot";
            this.bScreenShot.UseVisualStyleBackColor = true;
            this.bScreenShot.Click += new System.EventHandler(this.bScreenShot_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(28, 194);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(112, 23);
            this.bClear.TabIndex = 1;
            this.bClear.Text = "ClearScreen";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(28, 24);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(112, 23);
            this.bTest.TabIndex = 0;
            this.bTest.Text = "GraphicsContainer ";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "No Flick";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pPaint);
            this.Controls.Add(this.pControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pPaint;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bScreenShot;
        private System.Windows.Forms.Button bDrawArc;
        private System.Windows.Forms.Button bDrawEllipse;
        private System.Windows.Forms.Button button1;
    }
}

