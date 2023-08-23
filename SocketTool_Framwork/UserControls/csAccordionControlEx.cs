using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketTool_Framework
{

    /// <summary>
    /// Draw group selection
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
            this.AllowItemSelection = true;
            this.OptionsMinimizing.AllowMinimizeMode = DefaultBoolean.False; //Hide the header area menu button
            this.ViewType = AccordionControlViewType.HamburgerMenu;
            skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, this.LookAndFeel, "Item"); //Must have to show selection paint

            //Used to draw group selection
            this.CustomDrawElement += AccordionControl1_CustomDrawElement;
            this.MouseClick += AccordionControl1_MouseClick;
        }

        /// <summary>
        /// Fix the display issue when first load
        /// </summary>
        public void InitSelection()
        {
            if (this.Elements.Count == 0) return;

            //Force trigger the selection value to store the init value
            for (int i = Elements.Count - 1; i > -1; i--)
            {
                var item = Elements[i];
                if (item.Style != ElementStyle.Group) continue;

                //Remove the default selection
                SetSelectedObject(item);//trigger selection change event
                item.Tag = MouseEventType.Click;

                if (clickedGroupElement != null && clickedGroupElement != item)
                {
                    clickedGroupElement.Tag = MouseEventType.Normal;
                }

                this.SelectedElement = null;
                clickedGroupElement = item;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //Expand only when double click
            var hitTest = this.CalcHitInfo(e.Location).HitTest;
            if (e.Clicks == 2 &&
                hitTest == AccordionControlHitTest.Group &&
                hitTest != AccordionControlHitTest.Button) //Allow to expand
            {
                OnMouseUp(e);
                return;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            //Expand only when double click
            //Allow expand button
            var hitTest = this.CalcHitInfo(e.Location).HitTest;
            if (e.Clicks < 2 && hitTest != AccordionControlHitTest.Button)
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

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
