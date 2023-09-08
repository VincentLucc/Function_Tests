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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileLoading
{
    public partial class Form1 : UIForm
    {


        public const string sMemoryName = "DeltaX_MemoryData";
        public const string sMemoryReference = "DeltaX_MemoryReference";

        public MemoryMappedFile MappedFile;

        public Stopwatch watch;

        public DataTable ProcessedDataTable;

        public List<string> ProcessedCollection;

        private static IntPtr byteMemory; //Used to store unmanaged byte array

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

        private void Save2Memory(byte[] bData, string sName)
        {
            try
            {
                //When create again if file size is larger, you can't write data to the file
                if (MappedFile != null) MappedFile.Dispose();
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




        private void InitDisplay()
        {
            lPath.Text = "N/A";
            lProcessTime.Text = "N/A";
            lMessage.Text = "N/A";
        }

        private void LoadOperation(LoadConfig config)
        {
            //Init variables
            long fileLimit = 1024 * 1024 * 1280; //Max allow size

            //Check current memory usage
            var process = Process.GetCurrentProcess();
            long memUsage = process.PrivateMemorySize64;
            if (memUsage > fileLimit * 2)
            {
                MessageBox.Show("Not enough memory for operation");
                return;
            }

            //Open file
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            InitDisplay();
            string sPath = ofd.FileName;
            lPath.Text = sPath;

            //Check file size
            var fileInfo = new FileInfo(sPath);
            if (fileInfo.Length > fileLimit)
            {
                MessageBox.Show("Size limit 1G.");
                return;
            }

            //clear buffer
            if (ProcessedDataTable != null) ProcessedDataTable.Clear();
            if (ProcessedCollection != null) ProcessedCollection.Clear();

            //Force to clear memory, must have to free
            //ProcessedData takes a lot of memory
            GC.Collect();

            try
            {
                //Read bytes
                watch.Restart();
                lMessage.Text = "Reading file";
                this.Refresh();//Force UI to update
                byte[] bData = File.ReadAllBytes(sPath); //read to unmanaged buffer intead

                watch.Stop();
                lProcessTime.Text = $"File Read: {watch.ElapsedMilliseconds}";
                lMessage.Text = "Saving to memory";
                this.Refresh();//Force UI to update

                //Save to memory
                watch.Restart();
                Save2Memory(bData, sMemoryName);
                lProcessTime.Text += $"\r\nMemory time:{watch.ElapsedMilliseconds}";
                lMessage.Text = config.EnableProcess ? "Processing data" : "Finished";
                this.Refresh();//Force UI to update  

                //Process data
                if (!config.EnableProcess) return;

                if (config.ProcessInCollection)
                {
                    ProcessData2Collection(bData);
                }
                else
                {
                    ProcessData(bData, config.PartialProcess);
                }

                this.Refresh();//Force UI to update
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void LoadOperationUnManaged(LoadConfig config)
        {
            //Init variables
            long fileLimit = 1024 * 1024 * 1280; //Max allow size

            //Check current memory usage
            var process = Process.GetCurrentProcess();
            long memUsage = process.PrivateMemorySize64;
            if (memUsage > fileLimit * 2)
            {
                MessageBox.Show("Not enough memory for operation");
                return;
            }

            //Check avialiable memory (require Microsoft.VisualBasic)
            var freeMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;

            //Open file
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            InitDisplay();
            string sPath = ofd.FileName;
            lPath.Text = sPath;


            //Check file size
            var fileInfo = new FileInfo(sPath);
            if (fileInfo.Length > fileLimit)
            {
                MessageBox.Show("Size limit 1G.");
                return;
            }

            //clear buffer
            if (ProcessedDataTable != null)
            {
                ProcessedDataTable.Clear();
            }
            if (ProcessedCollection != null)
            {
                ProcessedCollection.Clear();
            }


            Marshal.FreeHGlobal(byteMemory);

            //Force to clear memory, must have to free
            //ProcessedData takes a lot of memory
            GC.Collect();

            //Update display
            lMessage.Text = "Reading file";
            watch.Restart();
            this.Refresh();//Force UI to update

            //prepare file read variables
            int iSize = Convert.ToInt32(fileInfo.Length);
            byteMemory = Marshal.AllocHGlobal(iSize);
            int iSegmentSize = 1024 * 1024;//read segment every 1M
            byte[] byteSegment = new byte[1024 * 1024];
            int iTotalCount = iSize / iSegmentSize;
            int iLastCount = iSize % iSegmentSize;
            byte[] bLast = new byte[iLastCount]; //Extra data outside the segment
            int iOffset = 0;

            try
            {
                //Start to read
                using (var reader = File.OpenRead(sPath))
                {

                    for (int i = 0; i < iTotalCount; i++)
                    {
                        iOffset = i * iSegmentSize;
                        reader.Read(byteSegment, 0, iSegmentSize);
                        Marshal.Copy(byteSegment, 0, byteMemory + iOffset, iSegmentSize);

                    }

                    //Read last segment
                    if (iLastCount > 0)
                    {
                        reader.Read(bLast, 0, iLastCount);
                        Marshal.Copy(byteSegment, 0, byteMemory + (iSize - iLastCount), iLastCount);
                    }
                }





                watch.Stop();
                lProcessTime.Text = $"File Read: {watch.ElapsedMilliseconds}";
                lMessage.Text = "Saving to memory";
                this.Refresh();//Force UI to update

                //Save to memory
                watch.Restart();
                //Save2Memory(bData, sMemoryName);
                lProcessTime.Text += $"\r\nMemory time:{watch.ElapsedMilliseconds}";
                lMessage.Text = config.EnableProcess ? "Processing data" : "Finished";
                this.Refresh();//Force UI to update  

                //Process data
                if (!config.EnableProcess) return;

                if (config.ProcessInCollection)
                {
                    //ProcessData2Collection(bData);
                }
                else
                {
                    //ProcessData(bData, config.PartialProcess);
                }
                this.Refresh();//Force UI to update

                //Clean up

                //Array.Clear(bData, 0, bData.Length);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                //Try clean up
                Marshal.FreeHGlobal(byteMemory);
            }
        }

        private void ProcessData(byte[] bData, bool bPartialProcess = false)
        {
            ProcessedDataTable = new DataTable();
            ProcessedDataTable.Columns.Add("Test");
            watch.Restart();
            using (StreamReader reader = new StreamReader(new MemoryStream(bData), Encoding.UTF8))
            {
                string sLine = "";
                int iIndex = 0;
                while ((sLine = reader.ReadLine()) != null)
                {
                    iIndex += 1;

                    if (iIndex >= 1000000)
                    {
                        MessageBox.Show("Maximum record reached! Limit 1,000,000");
                        return;
                    }

                    var row = ProcessedDataTable.NewRow();
                    if (bPartialProcess && sLine.Length >= 256)
                    {
                        sLine = sLine.Substring(0, 250) + "...";
                    }
                    row[0] = sLine;
                    ProcessedDataTable.Rows.Add(row);
                }

                watch.Stop();
                lProcessTime.Text += $"\r\nData processing time:{watch.ElapsedMilliseconds}ms";
                lMessage.Text = $"Finished, Line:{iIndex}";
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
                ProcessInCollection = true,
                PartialProcess = false,
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

        private void bTRackerLoad_Click(object sender, EventArgs e)
        {
            var config = new LoadConfig
            {
                EnableProcess = true,
                ProcessInCollection = false,
                PartialProcess = true,
            };
            LoadOperation(config);
        }

        private void bLoadUnManaged_Click(object sender, EventArgs e)
        {
            var config = new LoadConfig
            {
                EnableProcess = true,
                ProcessInCollection = false,
                PartialProcess = true,
            };
            LoadOperationUnManaged(config);
        }

        private void bLoadOnly_Click(object sender, EventArgs e)
        {
            //Init variables
            long fileLimit = 1024 * 1024 * 1280; //Max allow size

            //Check current memory usage
            var process = Process.GetCurrentProcess();
            long memUsage = process.PrivateMemorySize64;
            if (memUsage > fileLimit * 2)
            {
                MessageBox.Show("Not enough memory for operation");
                return;
            }

            //Check avialiable memory (require Microsoft.VisualBasic)
            ulong freeMemory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            if (freeMemory < Convert.ToUInt64(fileLimit * 3))
            {
                MessageBox.Show("Not enough free memory for operation");
                return;
            }

            //Open file
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            InitDisplay();
            string sPath = ofd.FileName;
            lPath.Text = sPath;


            //Check file size
            var fileInfo = new FileInfo(sPath);
            if (fileInfo.Length > fileLimit)
            {
                MessageBox.Show("Size limit 1G.");
                return;
            }


            //Read indication
            watch.Restart();
            lMessage.Text = "Reading file";
            this.Refresh();//Force UI to update

            //prepare file read variables
            int iSize = Convert.ToInt32(fileInfo.Length);
            int iSegmentSize = 1024 * 1024;//read segment every 1M
            int iMemSizeMax = iSegmentSize * 1300; //Create a maximum 1.3G memory space
            byte[] byteSegment = new byte[1024 * 1024];
            int iSegmentCount = iSize / iSegmentSize;
            int iLastCount = iSize % iSegmentSize;
            byte[] bLast = new byte[iLastCount]; //Extra data outside the segment
            int iOffset = 0;
            int iLengthSize = 4;//Int length value

            //prepare memory file
            MappedFile = MemoryMappedFile.CreateOrOpen(sMemoryName, iMemSizeMax);


            //Start to read
            using (var reader = File.OpenRead(sPath))
            {
                //Write
                using (var viewStream = MappedFile.CreateViewStream(0, iLengthSize))
                {
                    byte[] bLength = BitConverter.GetBytes(iSize);
                    viewStream.Write(bLength, 0, iLengthSize);
                }


                for (int i = 0; i < iSegmentCount; i++)
                {
                    iOffset = iLengthSize + i * iSegmentSize;
                    reader.Read(byteSegment, 0, iSegmentSize);

                    //Copy to memory
                    using (var viewStream = MappedFile.CreateViewStream(iOffset, iSegmentSize))
                    {
                        viewStream.Write(byteSegment, 0, iSegmentSize);
                    }
                }

                //Read last segment
                if (iLastCount > 0)
                {
                    reader.Read(bLast, 0, iLastCount);
                    int iLastIndex = iSize + iLengthSize - iLastCount;
                    //Copy to memory
                    using (var viewStream = MappedFile.CreateViewStream(iLastIndex, iLastCount))
                    {
                        viewStream.Write(bLast, 0, iLastCount);
                    }
                }
            }


            watch.Stop();
            lProcessTime.Text = $"File Read: {watch.ElapsedMilliseconds}";
            lMessage.Text = "Saving to memory";
            this.Refresh();//Force UI to update

            //Save to memory
            watch.Restart();
            lProcessTime.Text += $"\r\nMemory time:{watch.ElapsedMilliseconds}";
            lMessage.Text = "Finished";
            this.Refresh();//Force UI to update  



        }

        private void bReadMemory_Click(object sender, EventArgs e)
        {
            List<string> lData = new List<string>();


            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(sMemoryName))
                {
                    using (var accessor = mmf.CreateViewStream())
                    {
                        //ulong Length = accessor.SafeMemoryMappedViewHandle.ByteLength;

                        //Read to list
                        using (var reader = new StreamReader(accessor))
                        {
                            string slIne = null;
                            while ((slIne = reader.ReadLine()) != null)
                            {
                                lData.Add(slIne);
                            }
                        }


                        Debug.WriteLine("Read Data Lines:"+ lData.Count);

 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception.\r\n" + ex.Message);
                Debug.WriteLine("bReadMemory_Click:\r\n" + ex.Message);
            }



        }
    }





}
