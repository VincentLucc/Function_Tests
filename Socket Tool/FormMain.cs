using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using Socket_Tool.Forms;

namespace Socket_Tool
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public SkinElement skinElement;
        private AccordionControlElement clickedGroupElement;
        public FormMain Instance;

        public FormMain()
        {
            InitializeComponent();
            Instance = this;
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.LookAndFeel.SetSkinStyle(SkinStyle.WXICompact, SkinSvgPalette.WXICompact.Clearness);

            //Init variables
            //skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, UserLookAndFeel.Default, "Item");
            skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, this.LookAndFeel, "Item");


            //Init according control
            accordionControl1.AllowItemSelection = true;//Item can be selected
            accordionControl1.ShowFilterControl = ShowFilterControl.Always; //Enable search function
            accordionControl1.CustomDrawElement += AccordionControl1_CustomDrawElement;
            accordionControl1.MouseClick += AccordionControl1_MouseClick;

        }

        private void AccordionControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var hitInfo = accordionControl1.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == AccordionControlHitTest.Item || hitInfo.HitTest == AccordionControlHitTest.Group)
            {
                var element = hitInfo.ItemInfo.Element;
                element.Tag = EventType.Click;
 

                if (clickedGroupElement != null && clickedGroupElement != element)
                {
                    clickedGroupElement.Tag = EventType.Normal;
                }
                   

                if (hitInfo.HitTest == AccordionControlHitTest.Group)
                {
                    accordionControl1.SelectedElement = null;
                    clickedGroupElement = element;
                }
            }
        }

        private void AccordionControl1_CustomDrawElement(object sender, DevExpress.XtraBars.Navigation.CustomDrawElementEventArgs e)
        {
            if (!(e.Element.Tag is EventType))
                return;

            var eventType = (EventType)e.Element.Tag;

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

        private enum EventType
        {
            Normal,
            Hover,
            Click
        }

        private void barButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormServerEdit.ShowForm("New Any");
        }
    }
}
