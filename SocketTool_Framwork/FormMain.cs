using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
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
        bool bUpdateRecivedMessage = false;
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
            csPublic.messageHelper = messageHelper;

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
            PopulateServerItems();

            //Load version info
            VersionStaticItem.Caption = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Load client
            TCPClientAccordionControlElement.Elements.Clear();

            //Timer 
            timer1.Start();
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
                serverPanel.LoadConfig(csConfigHelper.config.TCPServers[iIndex]);
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
                if (parentItem == null)
                {
                    return _itemType.None;
                }
                else
                {
                    return csGroup.GetType(parentItem.Text);
                }

            }
        }


        private void ExitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void HelpButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AboutDialog about = new AboutDialog())
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
                newElement.Image = Properties.Resources.iconsetredtoblack4_16x16;

                var newServer = new csTCPServer(this, instance.Port, instance.IPAddress);
                newElement.Text = newServer.GetDisplayName();
                tcpServers.Add(newServer);
            }
            else
            {
                messageHelper.Info("Future");
            }
        }

        private async void barButtonDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuAccordionControl.SelectedObject == null) return;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;

            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;

            if (parentItem.Text == csGroup.TCPServer)
            {
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
                parentItem.Elements.RemoveAt(iIndex);

                var newServer = tcpServers[iIndex];
                tcpServers.RemoveAt(iIndex);

                await newServer.StopTCPServer();
            }
            else
            {
                messageHelper.Info("Future");
            }
        }

        private void moveUpButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuAccordionControl.SelectedObject == null) return;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;

            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;

            if (parentItem.Text == csGroup.TCPServer)
            {
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
                if (iIndex == 0) return;

                //Move the source data
                var newServer = tcpServers[iIndex];
                tcpServers.RemoveAt(iIndex);
                tcpServers.Insert(iIndex - 1, newServer);

                //Recreate Items
                PopulateServerItems();
                //Force to refresh
                MenuAccordionControl.SelectedElement = null;
                //Update actual selected item
                MenuAccordionControl.SelectedObjectChanged -= MenuAccordionControl_SelectedObjectChanged;
                MenuAccordionControl.CustomSelectedItem(parentItem.Elements[iIndex - 1]);
                MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;
            }
            else
            {
                messageHelper.Info("Future");
            }
        }

        private void moveDownButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuAccordionControl.SelectedObject == null) return;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;

            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;

            if (parentItem.Text == csGroup.TCPServer)
            {
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
                if (iIndex == parentItem.Elements.Count - 1) return;

                //Move the source data
                var newServer = tcpServers[iIndex];
                tcpServers.RemoveAt(iIndex);
                tcpServers.Insert(iIndex + 1, newServer);

                //Recreate Items
                PopulateServerItems();
                //Force to refresh
                MenuAccordionControl.SelectedElement = null;
                //Update actual selected item
                MenuAccordionControl.SelectedObjectChanged -= MenuAccordionControl_SelectedObjectChanged;
                MenuAccordionControl.CustomSelectedItem(parentItem.Elements[iIndex + 1]);
                MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;
            }
            else
            {
                messageHelper.Info("Future");
            }
        }

        public void PopulateServerItems()
        {
            TCPServerAccordionControlElement.Elements.Clear();
            foreach (var item in csConfigHelper.config.TCPServers)
            {
                var newElement = TCPServerAccordionControlElement.Elements.Add();
                newElement.Style = ElementStyle.Item;
                newElement.Text = item.GetDisplayName();
            }
        }

        public void UpdateServerStatus()
        {
            for (int i = 0; i < tcpServers.Count; i++)
            {
                var tcpServer = tcpServers[i];
                var serverItem = TCPServerAccordionControlElement.Elements[i];
                if (tcpServer.IsRunning)
                {
                    //Avoid flashing
                    //csPublic.CompareBitmaps(serverItem.Image as Bitmap, Properties.Resources.iconsetsigns3_16x16);

                    if (!csPublic.CompareBitmaps(serverItem.Image as Bitmap, Properties.Resources.iconsetsigns3_16x16))
                    {
                        serverItem.Image = Properties.Resources.iconsetsigns3_16x16;
                    }

                }
                else
                {
                    if (!csPublic.CompareBitmaps(serverItem.Image as Bitmap, Properties.Resources.iconsetredtoblack4_16x16))
                    {
                        serverItem.Image = Properties.Resources.iconsetredtoblack4_16x16;
                    }

                }

            }
        }



        private void TCPServerAccordionControlElement_Click(object sender, EventArgs e)
        {

        }

        private void moveUpButton_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private object GetCurrentItem()
        {
            var controls = MainSplitContainerControl.Panel2.Controls;
            if (controls.Count == 0) return null;
            if (controls[0] is TCPServerXtraUserControl)
            {
                return (controls[0] as TCPServerXtraUserControl).server;
            }
            else return null;
        }

        private void UpdateTCPServerControl()
        {
            var controls = MainSplitContainerControl.Panel2.Controls;
            if (controls.Count == 0) return;
            if (controls[0] is TCPServerXtraUserControl)
            {
                var tcpServerControl = controls[0] as TCPServerXtraUserControl;
                tcpServerControl.UpdateUI();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                if (this == null || this.IsDisposed || this.Disposing) return;

                //Server in the list
                UpdateServerStatus();
                UpdateTCPServerControl();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("timer1_Tick:\r\n" + ex.Message);
            }

            timer1.Enabled = true;
        }
    }
}
