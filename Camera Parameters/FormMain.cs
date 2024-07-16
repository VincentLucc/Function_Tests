using Camera_Parameters.UserControls;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Camera_Parameters
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public bool isFormLoad;
        public csDevMessage messageHelper;
        public FormMain()
        {
            InitializeComponent();
            this.FormClosed += FormMain_FormClosed;
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init 
            string sMessage = "";
            messageHelper = new csDevMessage(this);

            if (!csConfigureHelper.LoadOrCreateConfig(out sMessage))
            {
                messageHelper.Info(sMessage);
                this.Close();
                return;
            }

            InitControls();

            //Fisnish
            isFormLoad = true;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isFormLoad)
            {
                if (!csConfigureHelper.SaveConfig(out string sMessage))
                {
                    messageHelper.Info(sMessage);
                    return;
                }
            }


        }

        private void InitControls()
        {
            //this.contentPanel.Controls.Clear();
            //var calPage = new CalUserControl();
            //calPage.Dock = DockStyle.Fill;
            //this.contentPanel.Controls.Add(calPage);
            InitNavigationMenu();


            contentPanel.Controls.Clear();
            var func = new Func1UserControl();
            func.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(func);
        }

        private void InitNavigationMenu()
        {

            accordionControl1.Elements.Clear();
            accordionControl1.AllowItemSelection = true;

            var groupGeneral = accordionControl1.Elements.Add();
            groupGeneral.Text = "General";
            groupGeneral.Expanded = true;

            var elementCal= groupGeneral.Elements.Add();
            elementCal.Text = "Calculation1";
            elementCal.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            elementCal.Tag = new CalUserControl();

            var elementFunc1 = groupGeneral.Elements.Add();
            elementFunc1.Text = "Function1";
            elementFunc1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            elementFunc1.Tag = new Func1UserControl();

            var elementUnit = groupGeneral.Elements.Add();
            elementUnit.Text = "Unit Conversion";
            elementUnit.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            elementUnit.Tag = new ConversionUserControl();

            //Force trigger once
            SelectionChangeAction();

            accordionControl1.SelectedElementChanged += AccordionControl1_SelectedElementChanged;
        }

        private void AccordionControl1_SelectedElementChanged(object sender, DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs e)
        {
            SelectionChangeAction();
        }

        private void SelectionChangeAction()
        {
            var selection = accordionControl1.SelectedElement;
            if (selection == null || !(selection.Tag is XtraUserControl)) 
            {
                contentPanel.Controls.Clear();
                return;
            }

            contentPanel.Controls.Clear();
            var userControl = selection.Tag as XtraUserControl;
            userControl.Dock = DockStyle.Fill;        
            contentPanel.Controls.Add(userControl);
            //userControl.LookAndFeel.UseDefaultLookAndFeel = true;

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }
    }
}
