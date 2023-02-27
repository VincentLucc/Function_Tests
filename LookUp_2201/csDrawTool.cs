using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LookUpEdit_2201
{
    class csDrawTool
    {
        //Pens
        public static Pen RedPen = new Pen(new SolidBrush(Color.FromArgb(197, 19, 1))) { Width = 8 };
        public static Pen RedPenThin = new Pen(new SolidBrush(Color.FromArgb(197, 19, 1))) { Width = 1 };
        public static Pen RedPen16 = new Pen(new SolidBrush(Color.FromArgb(197, 19, 1))) { Width = 16 };
        public static Pen GreenPen = new Pen(new SolidBrush(Color.FromArgb(19, 115, 0))) { Width = 8 };
        public static Pen GreenPen16 = new Pen(new SolidBrush(Color.FromArgb(19, 115, 0))) { Width = 16 };
        public static Pen GreenThin = new Pen(new SolidBrush(Color.FromArgb(19, 115, 0))) { Width = 1 };
        public static Pen PurplePen = new Pen(new SolidBrush(Color.FromArgb(127, 28, 155))) { Width = 8 };

        //Brushes
        public static Brush GrayBrush = new SolidBrush(Color.FromArgb(230, 230, 230));
        public static Brush BlueBrush = new SolidBrush(Color.DarkBlue);
    }
}
