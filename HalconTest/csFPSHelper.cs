using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HalconTest
{
    class csFPSHelper
    {

        private object LockFPSRecords = new object();

        private List<DateTime> FPSRecords = new List<DateTime>();

        private List<TimeSpan> UpdatePeriods = new List<TimeSpan>();

        /// <summary>
        /// Reduce this number can increase performance
        /// </summary>

        private int MaximumRecordCount = 200;
 
        /// <summary>
        /// Scan range in milliseconds used to smooth the output in certain time
        /// </summary>
        private int ScanSmoothRange = 2000;

        /// <summary>
        /// Handle condition for slow FPS
        /// </summary>
        private int MaximumDetectionRange = 20000;


        public csFPSHelper(int iScanRange, int iMaximumDetectionRange, int iMaximumRecordCount = 200)
        {
            SetParams(iScanRange, iMaximumDetectionRange, iMaximumRecordCount);
        }


        public void SetParams(int iSmoothRange, int iMaximumDetectionRange, int iMaximumRecordCount = 200)
        {
            ScanSmoothRange = iSmoothRange;
            MaximumDetectionRange = iMaximumDetectionRange;
            MaximumRecordCount = iMaximumRecordCount;
        }

        public void AddRecord(TimeSpan period)
        {
            AddRecord();

            lock (LockFPSRecords)
            {
                if (UpdatePeriods.Count > MaximumRecordCount)
                {
                    if (UpdatePeriods.Count > 10)
                    {
                        int iRemove = UpdatePeriods.Count / 5;
                        UpdatePeriods.RemoveRange(0, iRemove);
                    }
                    else UpdatePeriods.RemoveAt(0);
                }

                UpdatePeriods.Add(period);
            }
        }



        public void AddRecord()
        {
            lock (LockFPSRecords)
            {
                if (FPSRecords.Count > MaximumRecordCount)
                {
                    //Reduce remove action counts
                    if (FPSRecords.Count > 10)
                    {
                        int iRemove = FPSRecords.Count / 5;
                        FPSRecords.RemoveRange(0, iRemove);
                    }
                    else FPSRecords.RemoveAt(0);
                }

                FPSRecords.Add(csDateTimeHelper.CurrentTime);
            }
        }

        public double GetMaxDuration()
        {
            lock (LockFPSRecords)
            {
                if (UpdatePeriods.Count == 0) return -1;
                double dValue = UpdatePeriods.Select(t=>t.TotalMilliseconds).Max();
                return dValue;
            }
        }

        public double GetAverageDuration()
        {
            lock (LockFPSRecords)
            {
                if (UpdatePeriods.Count == 0) return -1;
                double dValue = UpdatePeriods.Select(t=>t.TotalMilliseconds).Average();
                return dValue;
            }
        }

        public double GetFPS()
        {
            double dFPS = 0;//Init FPS
            //Try to get at least 5 records
            int iMinimumCount = 5;


            var smoothTimeLimit = csDateTimeHelper.CurrentTime.AddMilliseconds(-ScanSmoothRange);
            var maximumRangeLimit = csDateTimeHelper.CurrentTime.AddMilliseconds(-MaximumDetectionRange);
            //Get number of images captured within last 1 second
            lock (LockFPSRecords)
            {
                //Check count, mininum 2 records required for fps counting
                if (FPSRecords.Count < 2) return 0;

                //Get scan interval
                List<TimeSpan> scanIntervals = new List<TimeSpan>();
                //When not enough samples detected in the inspection range
                for (int i = FPSRecords.Count - 1; i > 0; i--)
                {
                    var tNow = FPSRecords[i];
                    var tLast = FPSRecords[i - 1];
                    var gap = tNow - tLast;

                    //When sample within the check range, continue adding sample
                    if (tLast < smoothTimeLimit)
                    {
                        //When records outside the averaging calc range
                        //Only include into the result when the record count smaller than minimum requirement (Low FPS condition)
                        //The records also must within the muximum detection range
                        if (scanIntervals.Count >= iMinimumCount || tLast < maximumRangeLimit) break;
                    }

                    //Add sample
                    scanIntervals.Add(gap);
                }

                if (scanIntervals.Count == 0) return 0;

                //Get average gap time
                var dTicks = scanIntervals.Average(a => a.Ticks);
                var avgGap = TimeSpan.FromTicks(Convert.ToInt64(dTicks));

                //If last record within the smooth range, value can be directly used
                if (FPSRecords[FPSRecords.Count - 1] > smoothTimeLimit)
                {
                    dFPS = 1.0 / avgGap.TotalSeconds;
                }
                else
                {//When the last record outside the smooth range
                    var lastRecordGap = csDateTimeHelper.CurrentTime - FPSRecords[FPSRecords.Count - 1];
                    if (lastRecordGap < avgGap)
                    {//This condition, the average value is more accurate
                        dFPS = 1.0 / avgGap.TotalSeconds;
                    }
                    else
                    {//Include the most recent record
                        scanIntervals.Add(lastRecordGap);
                        //Get average gap time
                        dTicks = scanIntervals.Average(a => a.Ticks);
                        avgGap = TimeSpan.FromTicks(Convert.ToInt64(dTicks));
                        dFPS = 1.0 / avgGap.TotalSeconds;

                    }
                }
            }

            return dFPS;
        }
    }
}
