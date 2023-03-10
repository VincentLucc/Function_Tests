using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGeneration
{
    /// <summary>
    /// Used to add order mark of a sequence without impacting performance
    /// No actual ordering will be perform during operation
    /// Don't use datetime.now.ticks since it may return same value!!!
    /// </summary>
    public class csOrderGenerator
    {
        public int Order { get; set; }

        public csOrderGenerator()
        {
            Reset();
        }

        public int GetNext()
        {
            Order += 1;
            return Order;
        }

        public void Reset()
        {
            Order = 0;
        }
    }
}
