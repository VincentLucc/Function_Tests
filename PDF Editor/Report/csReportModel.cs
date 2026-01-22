using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data;

namespace PDF_Editor
{
    public class csReportModel
    {
        public csJobInfo JobInfo { get; set; } = new csJobInfo();
 
        public List<csNamedInt> JobStatistics { get; set; } = new List<csNamedInt>();
        public List<csReportItem> Items { get; set; } = new List<csReportItem>();

        public void InitRecords()
        {
            Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                var item = new csReportItem()
                {
                    ID = i+1,
                    Name = $"Item_{i.ToString("d3")}",
                };
                Items.Add(item);
            }

            //Job statistics
            JobStatistics.Clear();
            JobStatistics.Add(new csNamedInt("Good Products",100));
            JobStatistics.Add(new csNamedInt("Bad Products",20));
            JobStatistics.Add(new csNamedInt("Undefined Products",2));

        }



    }

    public class csReportItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }


    public class csJobInfo
    {
        public string ProductName { get; set; } = "Product Name";
        public DateTime ReportTime { get; set; } = DateTime.Now;
        public string UserName { get; set; } = "Test User";
    }

 

    public class csNamedInt
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public csNamedInt(string sName, int iValue)
        {
            Name = sName;
            Value = iValue;
        }
    }

    
}
