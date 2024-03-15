using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEditing
{
    public partial class Form1 : Form
    {
        string sFilePath = csPublic.AppPath + @"\test.txt";
        FileStream FileOnHold;

        public Form1()
        {
            InitializeComponent();
        }

        private void bHold_Click(object sender, EventArgs e)
        {
            FileOnHold = TryHoldFile();

            if (FileOnHold == null)
            {
                MessageBox.Show("fail");
            }
            else
            {
                MessageBox.Show("success");
            }
        }



        private FileStream TryHoldFile()
        {
            try
            {
                FileStream fs = new FileStream(sFilePath, FileMode.Open);
                return fs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("TryHoldFile:" + ex.Message);
                return null;
            }
        }

        private void bWriteHoldFile_Click(object sender, EventArgs e)
        {
            if (FileOnHold == null) return;

            //using (FileOnHold)
            //{
            //    string sTest = "Test Message 123";
            //    var data = Encoding.UTF8.GetBytes(sTest);
            //    FileOnHold.SetLength(data.Length);//Must have, otherwise, file may contain extra content!!!
            //    FileOnHold.Write(data, 0, data.Length);
            //}

            string sTest = "Test Message 123";
            var data = Encoding.UTF8.GetBytes(sTest);
            FileOnHold.SetLength(data.Length);//Must have, otherwise, file may contain extra content!!!
            FileOnHold.Write(data, 0, data.Length);


            //var file = File.Open(sFilePath, FileMode.Append);
            //string sApend = "Apend1,Apend2";
            //var bApend = Encoding.UTF8.GetBytes(sApend);
            //file.Write(bApend, 0, bApend.Length);
            //file.Close();
        }

        private void bCLoseHold_Click(object sender, EventArgs e)
        {
            FileOnHold.Close();
        }

        private void bFileInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = fileDialog.FileName;
                var fileInfo = new FileInfo(sFileName);

            }
        }

        private void bFolderPermission_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                string sFOlder = folderBrowserDialog.SelectedPath;
                var permissionInfo = csPermission.GetDirectoryPermission(sFOlder);
                string sMessage = $"Can Read:{permissionInfo.CanRead}\r\nCan Write:{permissionInfo.CanWrite}\r\nError Free:{permissionInfo.AllPropertyLoaded}";
                MessageBox.Show(sMessage);
            }
        }

        

}
