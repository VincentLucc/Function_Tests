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
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Navigation;
using SocketTool_Framework.Classes;
using SocketTool_Framework.Forms;
using SocketTool_Framework.UserControls;

namespace SocketTool_Framework
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {

        public FormMain Instance;
        csDevMessage messageHelper;
        BindingList<csTreeListItem> treeListItems;
        List<csTCPServer> tcpServers;
        List<csTCPClient> tcpClients;

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
            csPublic.winMain = this;

            string sMessage = "";

            //Read configuration
            if (!csConfigHelper.LoadOrCreateConfig(out sMessage))
            {
                messageHelper.Info(sMessage);
                return;
            }
            tcpServers = csConfigHelper.config.TCPServers;
            tcpClients = csConfigHelper.config.TCPClients;

            //Load the configuration to control
            PopulateServerItems();
            PopulateClientItems();

            //Init according control
            MenuAccordionControl.InitSelection();//Fix the display issue
            MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;

            //Load version info
            VersionStaticItem.Caption = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

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

            //Use customize item to get the tagExt value
            if (MenuAccordionControl.SelectedObject is AccordionControlElementEx)
            {
                var selection = MenuAccordionControl.SelectedObject as AccordionControlElementEx;
                if (selection.TagExt is csTCPServer)
                {//Show current server info
                    var serverPanel = new TCPServerXtraUserControl();
                    serverPanel.Dock = DockStyle.Fill;
                    messageHelper.ShowMainLoading();
                    UpdatePanelDisplay(serverPanel);
                    serverPanel.LoadConfig((csTCPServer)selection.TagExt);
                    messageHelper.CloseForm();
                }
                else if (selection.TagExt is csTCPClient)
                {
                    var clientPanel = new TCPClientXtraUserControl();
                    clientPanel.Dock = DockStyle.Fill;
                    messageHelper.ShowMainLoading();
                    UpdatePanelDisplay(clientPanel);
                    clientPanel.LoadConfig((csTCPClient)selection.TagExt);
                    messageHelper.CloseForm();
                }
            }
        }

        private void UpdatePanelDisplay(Control control)
        {
            //Cleanup
            foreach (UserControl item in MainSplitContainerControl.Panel2.Controls)
            {
                item.Dispose();
            }

            MainSplitContainerControl.Panel2.Controls.Clear();
            MainSplitContainerControl.Panel2.Controls.Add(control);
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
                if (ServerAddForm.ShowForm("New Any") != DialogResult.OK) return;
                var instance = ServerAddForm.Instance;


                var newElement = TCPServerAccordionControlElement.Elements.Add();
                newElement.Style = ElementStyle.Item;
                newElement.Image = Properties.Resources.iconsetredtoblack4_16x16;

                var newServer = new csTCPServer(this, instance.Port, instance.IPAddress);
                newElement.Text = newServer.GetDisplayName();
                tcpServers.Add(newServer);
            }
            else if (type == _itemType.TCPClient)
            {
                if (ServerAddForm.ShowForm("Remote Server") != DialogResult.OK) return;
                var instance = ServerAddForm.Instance;

                //Add to display
                var newElement = TCPClientAccordionControlElement.Elements.Add();
                newElement.Style = ElementStyle.Item;
                newElement.Image = Properties.Resources.iconsetredtoblack4_16x16;

                //Add config file
                var newClient = new csTCPClient(this, instance.IPAddress, instance.Port);
                newElement.Text = newClient.GetDisplayName();
                tcpClients.Add(newClient);
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
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
                parentItem.Elements.RemoveAt(iIndex);

                var client = tcpClients[iIndex];
                tcpClients.RemoveAt(iIndex);

                await client.Disconnect();
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
                //Get index
                int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
                if (iIndex == 0) return;

                //Move the source data
                var newServer = tcpClients[iIndex];
                tcpClients.RemoveAt(iIndex);
                tcpClients.Insert(iIndex - 1, newServer);

                //Recreate Items
                PopulateClientItems();

                //Force to refresh
                MenuAccordionControl.SelectedElement = null;
                //Update actual selected item
                MenuAccordionControl.SelectedObjectChanged -= MenuAccordionControl_SelectedObjectChanged;
                MenuAccordionControl.CustomSelectedItem(parentItem.Elements[iIndex - 1]);
                MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;
            }
        }

        private void moveDownButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MenuAccordionControl.SelectedObject == null) return;
            if (MenuAccordionControl.SelectedObject.Style == ElementStyle.Group) return;

            var parentItem = MenuAccordionControl.SelectedObject.OwnerElement;

            //Get index
            int iIndex = parentItem.Elements.IndexOf(MenuAccordionControl.SelectedObject);
            if (iIndex == parentItem.Elements.Count - 1) return;

            if (parentItem.Text == csGroup.TCPServer)
            {
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
            else if (parentItem.Text == csGroup.TCPServer)
            {
                //Move the source data
                var newClient = tcpClients[iIndex];
                tcpClients.RemoveAt(iIndex);
                tcpClients.Insert(iIndex + 1, newClient);

                //Recreate Items
                PopulateClientItems();

                //Force to refresh
                MenuAccordionControl.SelectedElement = null;
                //Update actual selected item
                MenuAccordionControl.SelectedObjectChanged -= MenuAccordionControl_SelectedObjectChanged;
                MenuAccordionControl.CustomSelectedItem(parentItem.Elements[iIndex + 1]);
                MenuAccordionControl.SelectedObjectChanged += MenuAccordionControl_SelectedObjectChanged;
            }

        }

        public void PopulateServerItems()
        {
            TCPServerAccordionControlElement.Elements.Clear();
            foreach (var item in csConfigHelper.config.TCPServers)
            {
                var newElement = new AccordionControlElementEx();
                TCPServerAccordionControlElement.Elements.Add(newElement);
                newElement.Style = ElementStyle.Item;
                newElement.Text = item.GetDisplayName();
                //Tag property is already used by the internal UI control
                newElement.TagExt = item;
            }
        }

        public void PopulateClientItems()
        {
            TCPClientAccordionControlElement.Elements.Clear();
            foreach (var item in csConfigHelper.config.TCPClients)
            {
                var newElement = new AccordionControlElementEx();
                TCPClientAccordionControlElement.Elements.Add(newElement);
                newElement.Style = ElementStyle.Item;
                newElement.Text = item.GetDisplayName();
                //Tag property is already used by the internal UI control
                newElement.TagExt = item;
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

        public void UpdateClientStatus()
        {
            for (int i = 0; i < tcpClients.Count; i++)
            {
                var client = tcpClients[i];
                var clientItem = TCPClientAccordionControlElement.Elements[i];
                if (client.IsConnected)
                {
                    //Avoid flashing
                    //csPublic.CompareBitmaps(serverItem.Image as Bitmap, Properties.Resources.iconsetsigns3_16x16);

                    if (!csPublic.CompareBitmaps(clientItem.Image as Bitmap, Properties.Resources.iconsetsigns3_16x16))
                    {
                        clientItem.Image = Properties.Resources.iconsetsigns3_16x16;
                    }

                }
                else
                {
                    if (!csPublic.CompareBitmaps(clientItem.Image as Bitmap, Properties.Resources.iconsetredtoblack4_16x16))
                    {
                        clientItem.Image = Properties.Resources.iconsetredtoblack4_16x16;
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

        private void UpdateDetailInfoPanel()
        {
            var controls = MainSplitContainerControl.Panel2.Controls;
            if (controls.Count == 0) return;
            if (controls[0] is TCPServerXtraUserControl)
            {
                var tcpServerControl = controls[0] as TCPServerXtraUserControl;
                tcpServerControl.UpdateUI();
            }
            else if (controls[0] is TCPClientXtraUserControl)
            {
                var tcpClientControl = controls[0] as TCPClientXtraUserControl;
                tcpClientControl.UpdateUI();
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
                UpdateClientStatus();
                UpdateDetailInfoPanel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("timer1_Tick:\r\n" + ex.Message);
            }

            timer1.Enabled = true;
        }
    }
}
