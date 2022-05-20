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
        /// <summary>
        /// This list must exist to keep MemoryMappedFile in memory, otherwise it will be automatically GC
        /// </summary>
        List<MemoryMappedFile> MemList = new List<MemoryMappedFile>();

        public bool IsSave2Memory { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void StoreLineTextToMemory(string sText,long lIndex)
        {
            byte[] bDataBuffer = Encoding.UTF8.GetBytes(sText);
            string sMemName = $"DeltaX_MemoryData_{lIndex}";

            //Write current memory section
            //First 8 byte, empty, second 8 byte length of data
            MemoryMappedFile mappedData = MemoryMappedFile.CreateOrOpen(sMemName, bDataBuffer.Length + 8);
            MemoryMappedViewAccessor accessorData = mappedData.CreateViewAccessor();
            accessorData.Write(0, (long)bDataBuffer.Length);//Write length
            accessorData.WriteArray(8, bDataBuffer, 0, bDataBuffer.Length); //Write to data

            //Notice, this will automatically disposed!!!
            MemList.Add(mappedData);
        }

        private void StoreLineCountToMemory(long lCount)
        {
            //Write memory list count
            MemoryMappedFile mappedIndex = MemoryMappedFile.CreateOrOpen($"DeltaX_MemoryCount", 8);
            MemoryMappedViewAccessor accessorIndex = mappedIndex.CreateViewAccessor();
            accessorIndex.Write(0, lCount);//Write length
           
            MemList.Add(mappedIndex);
        }


        /// <summary>
        /// Copy data to memory
        /// 2G file, 20 sec
        /// </summary>
        /// <param name="sDataList"></param>
        private void StoreToMemory(List<string> sDataList)
        {
            MemList.Clear(); //Must save to keep the data in mem

            //Save to memory one by one
            for (int i = 0; i < sDataList.Count; i++)
            {
                byte[] bDataBuffer = Encoding.UTF8.GetBytes(sDataList[i]);
                string sMemName = $"DeltaX_MemoryData_{i}";
                

                //Write current memory section
                //First 8 byte, empty, second 8 byte length of data
                MemoryMappedFile mappedData = MemoryMappedFile.CreateOrOpen(sMemName, bDataBuffer.Length+8);
                MemoryMappedViewAccessor accessorData = mappedData.CreateViewAccessor();
                accessorData.Write(0,(long)bDataBuffer.Length);//Write length
                accessorData.WriteArray(8, bDataBuffer, 0, bDataBuffer.Length); //Write to data

                //Notice, this will automatically disposed!!!
                MemList.Add(mappedData);


            }

            //Write memory list count
            MemoryMappedFile mappedIndex = MemoryMappedFile.CreateOrOpen($"DeltaX_MemoryCount", 8);
            MemoryMappedViewAccessor accessorIndex = mappedIndex.CreateViewAccessor();
            accessorIndex.Write(0, (long)sDataList.Count);//Write length
                                                          //
            MemList.Add(mappedIndex);
        }

        
        /// <summary>
        /// Copy data to memory
        /// 2G file, 16 sec
        /// </summary>
        /// <param name="sDataList"></param>
        private void StoreToMemory2(List<string> sDataList)
        {
            MemList.Clear(); //Must save to keep the data in mem

            string sMemName = $"DeltaX_MemoryData";

            //Cal length
            long lLength = sDataList.Sum(s=>s.Length);
           

            MemoryMappedFile mappedData = MemoryMappedFile.CreateOrOpen(sMemName, lLength + 8);
            MemoryMappedViewAccessor accessorData = mappedData.CreateViewAccessor();
         

            accessorData.Write(0, lLength);//Write length

            //Save to memory one by one
            long lAddress = 8;
            for (int i = 0; i < sDataList.Count; i++)
            {
                byte[] bDataBuffer = Encoding.UTF8.GetBytes(sDataList[i]);

                //accessorData.WriteArray(lAddress, bDataBuffer, 0, bDataBuffer.Length); //Write to data

                //Use MemoryMappedViewStream instead of MemoryMappedViewAccessor, much faster
                var viewStream = mappedData.CreateViewStream(lAddress, bDataBuffer.Length);
                viewStream.Write(bDataBuffer, 0, bDataBuffer.Length);
                viewStream.Close();

                //Cal new address
                lAddress += bDataBuffer.Length;
            }

            //Notice, this will automatically disposed!!!
            MemList.Add(mappedData);
        }


        /// <summary>
        /// Copy data to memory, using 
        /// 2G file, 16 sec
        /// </summary>
        /// <param name="sDataList"></param>
        private void StoreToMemory3(List<string> sDataList)
        {
            MemList.Clear(); //Must save to keep the data in mem

            string sMemName = $"DeltaX_MemoryData";

            //Cal length
            var writeData = PrepareData(sDataList);

            //Create map
            MemoryMappedFile mappedData = MemoryMappedFile.CreateOrOpen(sMemName, writeData.FullLength + 8);
            var viewStreamCount = mappedData.CreateViewStream(0, 8); //First 8 bytes used to store length
            byte[] bLength = BitConverter.GetBytes(writeData.FullLength+8);
            viewStreamCount.Write(bLength,0,bLength.Length);//Write length

            //Save to memory one by one
            for (int i = 0; i < writeData.DataList.Count; i++)
            {
                //Use MemoryMappedViewStream instead of MemoryMappedViewAccessor, much faster
                var viewStream = mappedData.CreateViewStream(writeData.IndexList[i]+8, writeData.DataList[i].Length + 8);
                //mappedData.
                //Use async write
                //viewStream.Write(writeData.DataList[i], 0, writeData.DataList[i].Length);
            }

            //Notice, this will automatically disposed!!!
            MemList.Add(mappedData);
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

        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            lMessage.Text = "N/A";

            string sPath = ofd.FileName;
            StringBuilder builder = new StringBuilder();

            DataTable dt = new DataTable();
            dt.Columns.Add("Test");

            List<string> sDataList = new List<string>();

            IsSave2Memory = false; //Save to memoty
            MemList.Clear();//Clear current memory

            using (StreamReader reader = new StreamReader(sPath, Encoding.Default))
            {
                string sLine = "";
                int iIndex = 0;
                while ((sLine = reader.ReadLine()) != null)
                {
                    //Save to memory
                    if (IsSave2Memory) StoreLineTextToMemory(sLine, iIndex);

                    iIndex += 1;

                    var row = dt.NewRow();
                    row[0] = sLine;
                    dt.Rows.Add(row);

                    //Show only per 100 line
                    if (iIndex % 100 == 0)
                    {
                        Console.WriteLine($"Read line {iIndex}");
                    }

                    sDataList.Add(sLine);
                }

                //Write last line
                Console.WriteLine($"Read line {iIndex}");

                //save memory count to memory
                if (IsSave2Memory) StoreLineCountToMemory(iIndex);
            }

            //Save to memory
            //For time consume calculation
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("StoreToMemory:Start");
            StoreToMemory3(sDataList);
            stopwatch.Stop();
            Console.WriteLine("StoreToMemory:End:" + stopwatch.ElapsedMilliseconds);
        }
    }





}
