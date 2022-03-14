using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormData
{
    class csPublic
    {
    }

    /// <summary>
    /// Deliver main form data in different controls
    /// </summary>
    public class FormData
    {
        /// <summary>
        /// application is running under debug mode or not
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// Record the mouse location when mouse pressed
        /// </summary>
        public Point MouseDownLocation;
        /// <summary>
        /// Calculated new form location
        /// </summary>
        public Point NewFormLocation;

        /// <summary>
        /// Mouse move events
        /// </summary>
        public delegate void MouseMoveAction(object sender);
        public event MouseMoveAction MouseMove;
        /// <summary>
        /// Mouse pressed event
        /// </summary>
        public event EventHandler MouseDown;

        /// <summary>
        /// Store mouse values when mouse is moving
        /// </summary>
        public MouseEventArgs MouseMoveParameters { get; set; }

        /// <summary>
        /// Main form for UI adjustment
        /// </summary>
        public Form ParentForm { get; set; }

        public FormData(Form _parentForm)
        {
            ParentForm = _parentForm;
        }

        public void NoticeMouseDown(Point mouseLocation)
        {
            MouseDownLocation = mouseLocation;

            //Ignore, if not needed
            MouseDown?.Invoke(this, new EventArgs());
        }

        public void NoticeMouseMove(MouseEventArgs e)
        {
            MouseMoveParameters = e;
            MouseMove?.Invoke(this);
        }

        public void ApplyFormDrag()
        {
            if (MouseMoveParameters.Button == MouseButtons.Left) //left click
            {
                NewFormLocation = new Point();
                NewFormLocation.X = ParentForm.Location.X + (MouseMoveParameters.X - MouseDownLocation.X); //current x + offset
                NewFormLocation.Y = ParentForm.Location.Y + (MouseMoveParameters.Y - MouseDownLocation.Y); //current y + offset
                ParentForm.Location = NewFormLocation;
            }
        }
    }
}
