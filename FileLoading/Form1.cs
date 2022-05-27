using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoading
{
    public partial class Form1 : UIForm
    {
 

 

        public static string sMemoryName = "DeltaX_MemoryData";

        public MemoryMappedFile MappedFile;

        public Stopwatch watch;

        public DataTable ProcessedData;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            watch = new Stopwatch();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            LoadOperation();
        }

        private void bLoadProcess_Click(object sender, EventArgs e)
        {
            LoadOperation(true);
        }

        private void Save2Memory(byte[] bData,string sName)
        {
            try
            {
                MappedFile = MemoryMappedFile.CreateOrOpen(sName, bData.Length);
                //View stream is must than "MemoryMappedViewAccessor"
                var viewStream = MappedFile.CreateViewStream(0, bData.Length);
                viewStream.Write(bData, 0, bData.Length);
                viewStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private WriteData PrepareData(List<string> sList)
        {
            WriteData writeData = new WriteData();

            long iAddress = 0;
            for (int i = 0; i < sList.Count; i++)
            {
                writeData.IndexList.Add(iAddress);
                byte[] bData = Encoding.UTF8.GetBytes(sList[i]);
                writeData.DataList.Add(bData);
                iAddress += bData.Length;
            }

            writeData.FullLength = iAddress;

            //Clear memory
            sList.Clear();

            return writeData;
        }

        private void InitDisplay()
        {
            lPath.Text = "N/A";
            lProcessTime.Text = "N/A";
            lMessage.Text = "N/A";
        }

        private void LoadOperation(bool EnableProcess=false)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            InitDisplay();
            string sPath = ofd.FileName;
            lPath.Text = sPath;

            try
            {
                //Read bytes
                watch.Restart();
                lMessage.Text = "Reading file";
                this.Refresh();//Force UI to update
                byte[] bData = File.ReadAllBytes(sPath);
                watch.Stop();
                lProcessTime.Text = $"File Read: {watch.ElapsedMilliseconds}";
                lMessage.Text = "Saving to memory";
                this.Refresh();//Force UI to update

                //Save to memory
                watch.Restart();
                Save2Memory(bData, sMemoryName);
                lProcessTime.Text += $"\r\nMemory time:{watch.ElapsedMilliseconds}";
                lMessage.Text = EnableProcess?"Processing data":"Finished";

                //Process data
                if (EnableProcess)
                {
                    this.Refresh();//Force UI to update
                    ProcessData(bData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ProcessData(byte[] bData)
        {
            ProcessedData = new DataTable();
            ProcessedData.Columns.Add("Test");
            watch.Restart();
            using (StreamReader reader=new StreamReader(new MemoryStream(bData),Encoding.UTF8))
            {
                string sLine = "";
                int iIndex = 0;
                while ((sLine = reader.ReadLine()) != null)
                {
                    iIndex += 1;
                    var row = ProcessedData.NewRow();
                    row[0] = sLine;
                    ProcessedData.Rows.Add(row);
                }

                watch.Stop();
                lProcessTime.Text += $"\r\nData processing time:{watch.ElapsedMilliseconds}ms";
                lMessage.Text = "Finished";
            }

            var stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream,Encoding.UTF8);

        }

        private void bLoadThread_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {

            }
        }
    }





}
