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
using _CommonCode_Framework;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Property_RegEditor_22._1;

namespace Hardware
{
    public partial class FluentDesignForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        object targetObject;
        private csPropertyHelper propertyHelper;

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
            propertyHelper = new csPropertyHelper(propertyGridControl1);
            propertyGridControl1.OptionsView.ShowRootCategories = false;
            propertyHelper.CustomSettingRowEditor += PropertyHelper_CustomSettingRowEditor;
        }

        private void PropertyHelper_CustomSettingRowEditor(DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs eventArg, CustomEditorAttribute editorInfo)
        {
            switch (propertyGridControl1.SelectedObject)
            {
                case csCPUSettings cpuSettings:
                    SetCPUEditor(cpuSettings,eventArg);
                    break;
            }
        }

        private void SetCPUEditor(csCPUSettings cpuSettings, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs eventArg)
        {
            string sName = eventArg.Row.Properties.FieldName;
            $"SetCPUEditor[{sName}]".TraceRecord();
            switch (eventArg.Row.Properties.FieldName)
            {
                case nameof(csCPUSettings.CPUCoresEnableView):
                    {
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                        buttonEdit.TextEditStyle = TextEditStyles.DisableTextEditor;
                        buttonEdit.Click += ButtonEdit_Click;
                        eventArg.RepositoryItem = buttonEdit;
                    }
                    break;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            //Get current settings
            var coreSettings = csCPUHelper.CoreSettings;
            using (CPUAffinitySettingsForm cpuAffinitySettingsForm = new CPUAffinitySettingsForm(coreSettings))
            {
                cpuAffinitySettingsForm.ShowDialog();
            }
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

            //Add disk
            var CPUSettings = new AccordionControlElement(ElementStyle.Item);
            CPUSettings.Tag = new csCPUSettings();
            CPUSettings.Text = "CPU Settings";
            settingMenu.Elements.Add(CPUSettings);

            accordionControl1.ExpandAll();
            accordionControl1.SelectedElementChanged += AccordionControl1_SelectedElementChanged;
        }

        private void AccordionControl1_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
        {
            Trace.WriteLine("AccordionControl1_SelectedElementChanged.Selection Changed");
            switch ( e.Element.Tag)
            {
                case csMotherBoard motherBoard:
                    propertyGridControl1.SelectedObject = motherBoard;
                    break;
                case csDisk disk:
                    propertyGridControl1.SelectedObject = disk;
                    break;
                case csCPUSettings cpuSettings:
                    propertyGridControl1.SelectedObject = cpuSettings;
                    break;
                default:
                    propertyGridControl1.SelectedObject = null;
                    break;
            }
 

            targetObject = propertyGridControl1.SelectedObject;
        }
    }
}
