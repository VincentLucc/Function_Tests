using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        public FormNoFlickPanel()
        {
            InitializeComponent();
        }

        private void FormNoFlickPanel_Load(object sender, EventArgs e)
        {
            pPaint = new PaintPanel();
            pPaint.Parent = this;
            pPaint.Dock = DockStyle.Fill;
        
            pPaint.Paint += PPaint_Paint;
            Timer t1 = new Timer();
            t1.Interval = 100;
            t1.Tick += T1_Tick;
            t1.Start();
        }

        private void T1_Tick(object sender, EventArgs e)
        {
            if (iOffset < 200) 
            {
                iOffset += 1;
            }
            else
            {
                iOffset = 0;
            }

            pPaint.Refresh();
        }

        private void PPaint_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(csDrawTool.RedPenThin,0,0+ iOffset, 100,0+ iOffset);         
        }
    }


    public class PaintPanel : Panel
    {
        public PaintPanel()
        {
            //Avoid flick
            this.SetStyle(ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint |
                            ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
