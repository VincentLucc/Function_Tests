using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemDraw
{
    public partial class FormNoFlickPanel : Form
    {
        int iOffset = 0;
        PaintPanel pPaint;
        public Stopwatch stopwatch { get; set; }

        public bool UIExit => this == null || this.Disposing || this.IsDisposed;

        public FormNoFlickPanel()
        {
            InitializeComponent();
        }

        private void FormNoFlickPanel_Load(object sender, EventArgs e)
        {
            pPaint = new PaintPanel();
            pPaint.Parent = this;
            pPaint.Dock = DockStyle.Fill;
            stopwatch = new Stopwatch();


            pPaint.Paint += PPaint_Paint;
            Timer t1 = new Timer();
            t1.Interval = 20;
            t1.Tick += T1_Tick;
            t1.Start();
        }


        private void T1_Tick(object sender, EventArgs e)
        {
            var timer = (Timer)sender;
            timer.Enabled = false;
            if (UIExit) return;//Must have to exit

            var a = this;
 
            stopwatch.Restart();

            if (iOffset < 200) 
            {
                iOffset += 1;
            }
            else
            {
                iOffset = 0;
            }

            pPaint.Refresh();

            stopwatch.Stop();
            Debug.WriteLine("Timer:"+stopwatch.ElapsedMilliseconds);
            timer.Enabled = true;
        }

        private void PPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(csDrawTool.RedPenThin,0,0+ iOffset, 100,0+ iOffset);         
        }
    }



}
