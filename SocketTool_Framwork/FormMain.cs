using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using SocketTool_Framework.Forms;
using SocketTool_Framework.UserControls;

namespace SocketTool_Framework
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public FormMain Instance;
        csDevMessage messageHelper;
        List<csTCPServer> tcpServers;

        public FormMain()
        {
            InitializeComponent();
            Instance = this;
            this.Load += FormMain_Load;
            this.FormClosed += FormMain_FormClosed;
        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            //Init variables
            messageHelper = new csDevMessage(this);
            string sMessage = "";

            if (!csConfigHelper.LoadOrCreateConfig(out sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }
            tcpServers = csConfigHelper.config.TCPServers;

            //Init according control
            MenuAccordionControl.InitSelection();//Fix the display issue
            MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;

            //Load the configuration value
            TCPServerAccordionControlElement.Elements.Clear();
            foreach (var item in csConfigHelper.config.TCPServers)
            {
                var newElement = TCPServerAccordionControlElement.Elements.Add();
                newElement.Style = ElementStyle.Item;
                newElement.Text = item.GetDisplayName();
            }

            //Load client
            TCPClientAccordionControlElement.Elements.Clear();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!csConfigHelper.SaveConfig(out string msg))
            {
                messageHelper.Info(msg);
            }
        }

        private void MenuAccordionControl_SelectedObjectChanged(AccordionControlElement selectedElement)
        {
            if (MenuAccordionControl.SelectedObject == null) return;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;
            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;
            if (parentItem.Style != ElementStyle.Group) return;

            //Get item index
            int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);

            if (parentItem.Text == csGroup.TCPServer)
            {//Get ip endpoint
             //Get item index
             //Show current server info
                var serverPanel = new TCPServerXtraUserControl();
                serverPanel.Dock = DockStyle.Fill;
                MainSplitContainerControl.Panel2.Controls.Clear();
                MainSplitContainerControl.Panel2.Controls.Add(serverPanel);
            }
            if (parentItem.Text == csGroup.TCPClient)
            {
                //IPAddress.TryParse();
            }
        }

        public void LoadConfigFile()
        {

        }

        private _itemType GetCurrentGroup()
        {
            if (MenuAccordionControl.SelectedObject == null) return _itemType.None;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group)
            {
                return csGroup.GetType(MenuAccordionControl.SelectedObject.Text);
            }
            else
            {
                var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;
                return csGroup.GetType(parentItem.Text);
            }
        }


        private void ExitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void HelpButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AboutDialog about=new AboutDialog())
            {
                about.ShowDialog();
            }
        }

        private void barButtonAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var type = GetCurrentGroup();
            if (type == _itemType.TCPServer)
            {
                if (FormServerEdit.ShowForm("New Any") != DialogResult.OK) return;
                var instance = FormServerEdit.Instance;


                var newElement = TCPServerAccordionControlElement.Elements.Add();
                newElement.Style = ElementStyle.Item;

                var newServer = new csTCPServer(instance.Port, instance.IPAddress);
                newElement.Text = newServer.GetDisplayName();
                tcpServers.Add(newServer);
            }
            else
            {
                messageHelper.Info("Future");
            }
        }

        private void barButtonDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;

            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;

            if (parentItem.Text == csGroup.TCPServer)
            {
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);

                var newServer = tcpServers[iIndex];
 
            }
            else
            {
                messageHelper.Info("Future");
            }
        }



        private void TCPServerAccordionControlElement_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
