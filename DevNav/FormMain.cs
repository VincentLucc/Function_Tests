using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraNavBar;
using DevNav;


public partial class FormMain : DevExpress.XtraEditors.XtraForm
{
    /// <summary>
    /// Used for selection area display
    /// </summary>
    public SkinElement skinElement;
    private AccordionControlElement clickedGroupElement;

    public FormMain()
    {

        InitializeComponent();
        InitEvents();

    }

    private void FormMain_Load(object sender, EventArgs e)
    {

        InitControls();
    }

    private void InitEvents()
    {
        //Forms
        this.Load += FormMain_Load;

        //Normal according control
        accordionControl1.CustomDrawElement += AccordionControl1_CustomDrawElement;
        accordionControl1.MouseClick += AccordionControl1_MouseClick;

        //Custom according control
        accordionControlEx1.SelectedObjectChanged += AccordionControlEx1_SelectedObjectChanged;
    }

    private void InitControls()
    {
        //Set skins
        //this.LookAndFeel.SetSkinStyle(SkinStyle.WXICompact, SkinSvgPalette.WXICompact.Clearness);
        //skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, UserLookAndFeel.Default, "Item");
        skinElement = SkinManager.GetSkinElement(SkinProductId.AccordionControl, accordionControl1.LookAndFeel, "Item");

        //Init tab controls
        CustomNavBarControl.Appearance.ItemHotTracked.Options.UseFont = true; //Hide underline

        //Init normal according control
        accordionControl1.AllowItemSelection = true;//Item can be selected
        accordionControl1.ShowFilterControl = ShowFilterControl.Always; //Enable search function
        accordionControl1.LookAndFeel.SkinName = "Metropolis";  //From "SkinStyle" class
        accordionControl1.LookAndFeel.UseDefaultLookAndFeel = false;
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
        accordionControl1.Refresh();
 

        //Init customized accordiion control
        //Add group
        var groupCategory = new AccordionControlElement() { Text = "Category", Style = ElementStyle.Group, Expanded = true };
        accordionControlEx1.Elements.Add(groupCategory);
        //Add items
        var elementMachineSettings = new AccordionControlElement() { Text = "Test Object 1", Style = ElementStyle.Item, Tag = null };
        groupCategory.Elements.Add(elementMachineSettings);
        var elementProductionSettings = new AccordionControlElement() { Text = "Test Object 2", Style = ElementStyle.Item, Tag = null };
        groupCategory.Elements.Add(elementProductionSettings);


    }

    private void AccordionControlEx1_SelectedObjectChanged(AccordionControlElement selectedElement)
    {
        Debug.WriteLine(selectedElement.Text);
    }

    private void AccordionControl1_MouseClick(object sender, MouseEventArgs e)
    {
        var hitInfo = accordionControl1.CalcHitInfo(e.Location);
        if (hitInfo.HitTest == AccordionControlHitTest.Item || hitInfo.HitTest == AccordionControlHitTest.Group)
        {
            var element = hitInfo.ItemInfo.Element;
            element.Tag = MouseEventType.Click;

            if (clickedGroupElement != null && clickedGroupElement != element)
            {
                clickedGroupElement.Tag = MouseEventType.Normal;
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
        if (!(e.Element.Tag is MouseEventType))
            return;

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

    private enum MouseEventType
    {
        Normal,
        Hover,
        Click
    }

    private void bTestAccordion1_Click(object sender, EventArgs e)
    {
        Debug.WriteLine(accordionControl1.LookAndFeel);
        accordionControl1.Refresh();
    }

    private void accordionControlElement9_Click(object sender, EventArgs e)
    {

    }

    private void accordionControlElement1_Click(object sender, EventArgs e)
    {

    }
}

