using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskTests
{
    class csBlockingCollectionHelper
    {
        /// <summary>
        /// Limit size to 100
        /// </summary>
        public static BlockingCollection<(long id, string content)> BlockingQueue = new BlockingCollection<(long id, string content)>(100);

        public static Thread tConsume;
        private static bool ConsumeEnable;
        private static Form ParentForm;
        public static async Task StartService(Form parentForm)
        {
            ParentForm = parentForm;
            await StopService();
            ConsumeEnable = true;
            tConsume = new Thread(ConsumingProcess);
            tConsume.Start();
            Trace.WriteLine($"{ csPublic.DebugTimeString} StartService");
        }

        public static async Task StopService()
        {
            ConsumeEnable = false;
            if (tConsume == null) return;

            await Task.Delay(100);
            tConsume.Abort();
            tConsume = null;
            
        }

        public static void AddItem()
        {
            BlockingQueue.Add((DateTime.Now.Ticks, DateTime.Now.ToString("HH:mm:ss.fff")));
        }

        public static void ConsumingProcess()
        {
            while (ConsumeEnable &&
                ParentForm != null &&
                ParentForm.Visible &&
                !ParentForm.IsDisposed &&
                !ParentForm.Disposing)
            {
                var abc = BlockingQueue.Take();
                Trace.WriteLine($"{ csPublic.DebugTimeString} Consume: [Item:{abc.content}], [ID:{abc.id}], [Remain:{BlockingQueue.Count}]");

                //Protection
                while (BlockingQueue.Count > 50)
                {
                    BlockingQueue.Take();
                }
            }

        }
    }
}
