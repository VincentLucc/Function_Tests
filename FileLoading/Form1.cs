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
using System.Runtime;
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

        public List<string> ProcessedCollection;

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

            LoadOperation(new LoadConfig());
        }

        private void bLoadProcess_Click(object sender, EventArgs e)
        {
            var config = new LoadConfig
            {
                EnableProcess = true,
            };
            LoadOperation(config);
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

        private void LoadOperation(LoadConfig config)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            InitDisplay();
            string sPath = ofd.FileName;
            lPath.Text = sPath;

            //clear buffer
            if (ProcessedData!=null)
            {
                ProcessedData.Clear();
            }
            if (ProcessedCollection!=null)
            {
                ProcessedCollection.Clear();
            }

            //Force to clear memory, must have to free
            //ProcessedData takes a lot of memory
            GC.Collect();

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
                lMessage.Text = config.EnableProcess ? "Processing data":"Finished";
                this.Refresh();//Force UI to update  

                //Process data
                if (!config.EnableProcess) return;

                if (config.ProcessInCollection)
                {
                    ProcessData2Collection(bData);
                }
                else
                {
                    ProcessData(bData,config.PartialProcess);
                }
                this.Refresh();//Force UI to update

                //Clean up
                Array.Clear(bData,0,bData.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ProcessData(byte[] bData,bool bPartialProcess=false)
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
                    if (bPartialProcess&& sLine.Length>=256)
                    {
                        sLine = sLine.Substring(0,250)+"...";
                    }
                    row[0] = sLine;
                    ProcessedData.Rows.Add(row);
                }

                watch.Stop();
                lProcessTime.Text += $"\r\nData processing time:{watch.ElapsedMilliseconds}ms";
                lMessage.Text = "Finished";
            }
        }

        private void ProcessData2Collection(byte[] bData)
        {
            ProcessedCollection = new List<string>();
            watch.Restart();
            using (StreamReader reader = new StreamReader(new MemoryStream(bData), Encoding.UTF8))
            {
                string sLine = "";
                int iIndex = 0;
                while ((sLine = reader.ReadLine()) != null)
                {
                    iIndex += 1;
                    ProcessedCollection.Add(sLine);
                }

                watch.Stop();
                lProcessTime.Text += $"\r\nData processing time:{watch.ElapsedMilliseconds}ms";
                lMessage.Text = "Finished";
            }
        }

        private void bLoadThread_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {

            }
        }

        private void bLoadProcessList_Click(object sender, EventArgs e)
        {
            var config = new LoadConfig
            {
                EnableProcess = true,
                ProcessInCollection=true,
                PartialProcess=false,
            };
            LoadOperation(config);
        }

        private void bLoadPartial_Click(object sender, EventArgs e)
        {
            var config = new LoadConfig
            {
                EnableProcess = true,
                ProcessInCollection = false,
                PartialProcess = true,
            };
            LoadOperation(config);
        }



    }





}
