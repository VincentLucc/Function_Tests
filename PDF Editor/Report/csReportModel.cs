using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Editor
{
    public class csReportModel
    {
        public string Name { get; set; } = "Report.Name";
        public string DisplayName = "Report.DisplayName";

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
        }

    }

    public class csReportItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    
}
