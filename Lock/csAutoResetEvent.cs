using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    public class csAutoResetEvent
    {
        public AutoResetEvent autoResetEvent;
        Mutex mutex1;
        Semaphore semaphore1;
        ReaderWriterLock readerWriter;
        ReaderWriterLockSlim readerWriterLockSlim;
      

        public static void test()
        {
            lock (new object())
            {

            }
            Monitor.Enter(new object());

        }

    }
}
