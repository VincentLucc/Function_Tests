using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _CommonCode_Framework;

namespace HalconTest
{
    /// <summary>
    /// Make sure UI refresh minimum times and update to date
    /// </summary>
    public class csUIRefreshHelper
    {
        private List<DateTime> UpdateRequests { get; set; } = new List<DateTime>();
        private object lockUpdateRequests = new object();
  
 
        

        /// <summary>
        /// Use to wait for refreshing action
        /// </summary>
        public  Mutex refreshingActionMutex = new Mutex();

        public csUIRefreshHelper()
        {

        }

        public void WaitForComplete(int iTimeout)
        {
            
            if (refreshingActionMutex.WaitOne(iTimeout))
            {
                refreshingActionMutex.ReleaseMutex();
            }
            else
            {
                $"UIRefreshHelper.WaitForComplete.Timeout:{iTimeout}ms".TraceRecord();
            }
        }

        /// <summary>
        /// Notice UI an update is required
        /// </summary>
        public void Request()
        {
            lock (lockUpdateRequests)
            {
                UpdateRequests.Add(csDateTimeHelper.CurrentTime);
                if (UpdateRequests.Count > 10)
                {
                    UpdateRequests.RemoveRange(0, UpdateRequests.Count - 10);
                }
            }
        }

        /// <summary>
        /// Get the latest updating request
        /// </summary>
        /// <returns></returns>
        public DateTime? GetLastRequest()
        {
            lock (lockUpdateRequests)
            {
                if (UpdateRequests.Count == 0) return null;
                return UpdateRequests[UpdateRequests.Count - 1];
            }
        }

        /// <summary>
        /// Mark the request is finished and clear the unnecessary requests
        /// </summary>
        /// <param name="currentRequest"></param>
        public void CompleteRequest(DateTime? currentRequest)
        {
            //Error check
            if (currentRequest == null) return;

            var lastRequest = GetLastRequest();
            //No matched condition, ignore
            if (lastRequest == null) return;


            if (lastRequest <= currentRequest)
            {//No new request arrived, mark requests completed
                lock (lockUpdateRequests) UpdateRequests.Clear();
            }
            else
            {//One or more new request arrived
             //make sure to reload UI at least once, since the user data might be changed during UI update
                lock (lockUpdateRequests)
                {
                    int iCount = UpdateRequests.Count;
                    if (iCount == 0) return;
                    //Keep only one extra request
                    var last = UpdateRequests[iCount - 1];
                    UpdateRequests.Clear();
                    UpdateRequests.Add(last);
                }
            }
        }


    }
}
