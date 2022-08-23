using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevNav
{
    /// <summary>
    /// Only expand when double click
    /// </summary>
    [ToolboxItem(true)]
    public class AccordionControlEx : AccordionControl
    {
        /// <summary>
        /// Used for selection area display
        /// </summary>
        private SkinElement skinElement;
        /// <summary>
        /// Selected group object
        /// </summary>
        private AccordionControlElement clickedGroupElement;
        /// <summary>
        /// Selected object, element or group
        /// </summary>
        public AccordionControlElement SelectedObject;
        public delegate void SelectedObjectChangeAction(AccordionControlElement selectedElement);
        public event SelectedObjectChangeAction SelectedObjectChanged;

        public AccordionControlEx() : base()
        {
            this.ShowFilterControl = ShowFilterControl.Always; //Enable search function
            this.ViewType = AccordionControlViewType.HamburgerMenu;
            skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, this.LookAndFeel, "Item"); //Must have to show selection paint

            //Used to draw group selection
            this.CustomDrawElement += AccordionControl1_CustomDrawElement;
            this.MouseClick += AccordionControl1_MouseClick;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //Expand only when double click
            if (e.Clicks == 2 && this.CalcHitInfo(e.Location).HitTest == AccordionControlHitTest.Group)
            {
                OnMouseUp(e);
                return;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //Expand only when double click
            if (e.Clicks < 2)
            {
                this.Refresh();//Force to redraw group selection
                return;
            }
            base.OnMouseUp(e);
        }

        private void SetSelectedObject(AccordionControlElement element)
        {
            if (element == SelectedObject) return;
            SelectedObject = element;
            SelectedObjectChanged?.Invoke(element);
        }

        private void AccordionControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var hitInfo = this.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == AccordionControlHitTest.Item || hitInfo.HitTest == AccordionControlHitTest.Group)
            {
                var element = hitInfo.ItemInfo.Element;
                SetSelectedObject(element);//trigger selection change event
                element.Tag = MouseEventType.Click;


                if (clickedGroupElement != null && clickedGroupElement != element)
                {
                    clickedGroupElement.Tag = MouseEventType.Normal;
                }


                if (hitInfo.HitTest == AccordionControlHitTest.Group)
                {
                    this.SelectedElement = null;
                    clickedGroupElement = element;
                }
            }
        }

        private void AccordionControl1_CustomDrawElement(object sender, CustomDrawElementEventArgs e)
        {
            //Get event type
            if (!(e.Element.Tag is MouseEventType)) return;
            var eventType = (MouseEventType)e.Element.Tag;

            //Draw group element selection
            if (e.Element.Style == ElementStyle.Group)
            {
                var info = new SkinElementInfo(skinElement, e.ObjectInfo.HeaderBounds) { Cache = e.Cache, ImageIndex = (int)eventType };
                SkinElementPainter.Default.DrawObject(info);

                e.DrawExpandCollapseButton();
                e.DrawText();
                e.Handled = true;
            }
        }



        public enum MouseEventType
        {
            Normal,
            Hover,
            Click
        }

    }
}
