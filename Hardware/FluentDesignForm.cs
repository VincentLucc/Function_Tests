using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Hardware
{
    public partial class FluentDesignForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        object targetObject;

        public FluentDesignForm()
        {
            InitializeComponent();
            InitEvents();
        }




        private void InitEvents()
        {
            this.Load += FluentDesignForm_Load;
        }

        private void FluentDesignForm_Load(object sender, EventArgs e)
        {
            InitPropertyGrid();
            InitMenu();
            InitReader();
        }

        private void InitReader()
        {
            Thread tRead = new Thread(ProcessReading);
            tRead.IsBackground = true;
            tRead.Start();
        }

        private void ProcessReading()
        {
            while (this != null && !this.Disposing && !this.IsDisposed)
            {
                if (targetObject is csMotherBoard motherBoard)
                {

                }
                else if (targetObject is csDisk diskInfo)
                {
                    diskInfo.FirstDiskID = csHardwareHelper.FirstHardDriveID;

                }

                Thread.Sleep(10);
            }
        }

        private void InitPropertyGrid()
        {
            var propertyHelper = new csPropertyHelper(propertyGridControl1);
            propertyGridControl1.OptionsView.ShowRootCategories = false;
        }

        private void InitMenu()
        {
            accordionControl1.Elements.Clear();
            accordionControl1.AllowItemSelection = true;

            //Add hardware
            var hardwareMenu = new AccordionControlElement(ElementStyle.Group);
            hardwareMenu.Text = "HardWare Monitor";
            accordionControl1.Elements.Add(hardwareMenu);

            //Add mother board
            var motherBoardItem = new AccordionControlElement(ElementStyle.Item);
            motherBoardItem.Tag = new csMotherBoard();
            motherBoardItem.Text = "Motherboard";
            hardwareMenu.Elements.Add(motherBoardItem);

            //Add disk
            var diskItem = new AccordionControlElement(ElementStyle.Item);
            diskItem.Tag = new csDisk();
            diskItem.Text = "Disk";
            hardwareMenu.Elements.Add(diskItem);


            //Add Settings
            var settingMenu = new AccordionControlElement(ElementStyle.Group);
            settingMenu.Text = "Settings";
            accordionControl1.Elements.Add(settingMenu);

            accordionControl1.SelectedElementChanged += AccordionControl1_SelectedElementChanged;
        }

        private void AccordionControl1_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            Trace.WriteLine("AccordionControl1_SelectedElementChanged.Selection Changed");
            var selectedObject = e.Element.Tag;
            if (selectedObject is csMotherBoard motherBoard)
            {
                propertyGridControl1.SelectedObject = motherBoard;
            }
            else if (selectedObject is csDisk disk)
            {
                propertyGridControl1.SelectedObject = disk;
            }
            else
            {
                propertyGridControl1.SelectedObject = null;
            }

            targetObject = propertyGridControl1.SelectedObject;
        }
    }
}
