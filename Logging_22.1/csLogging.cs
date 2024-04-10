using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logging_22._1
{
    public class csLogHelper
    {
        public List<OperationLog> LocalLogs { get; set; }
        public object lockLocalLogs;

        public string LogFolder { get; set; }
        public int SizeLimit { get; set; }
        public Form ParentControl { get; set; }

        public string PreFix = "log_";
        public const string Suffix = ".log";

        public string DateString => DateTime.Now.ToString("yyMMdd");

        /// <summary>
        /// Whether write the log to the file
        /// </summary>
        public bool EnableWrite { get; set; }

        /// <summary>
        /// Check frequency in ms
        /// </summary>
        public int WriteInterval { get; set; }

        public bool UIExit => ParentControl == null || ParentControl.IsDisposed || ParentControl.IsDisposed;

        private Thread WriteThread;

        public csLogHelper(Form _parentForm)
        {
            LocalLogs = new List<OperationLog>();
            lockLocalLogs = new object();
            ParentControl = _parentForm;
            WriteInterval = 1000;
            LogFolder = Application.StartupPath + @"\Log\";
            SizeLimit = 1024 * 1024 * 20; //Size limit 20 MB
                                          //Start file write thread

        }

        public async Task Start()
        {
            await Stop();

            EnableWrite = true;

            WriteThread = new Thread(ProcessWriteLog);
            WriteThread.IsBackground = true;
            WriteThread.Start();
        }

        public async Task Stop()
        {
            EnableWrite = false;
            int iTimeout = WriteInterval + 500;
            await WaitThreadAsync(WriteThread, iTimeout);
        }

        private async Task WaitThreadAsync(Thread thread, int iTimeout)
        {
            //Thread already closed
            if (thread == null) return;
            //Init
            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {//Wait to close
                while (thread.IsAlive)
                {
                    await Task.Delay(20);

                    if (watch.ElapsedMilliseconds > iTimeout)
                    {
                        Debug.WriteLine($"Close thread: Timeout({watch.ElapsedMilliseconds}/{iTimeout})");
                        thread.Abort();
                        Debug.WriteLine($"Close thread: Thread aborted.");
                        break;
                    }
                }
                thread = null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("CloseThread\r\n:" + e.Message);
            }


            //finishup
            watch.Stop();
        }

        private void ProcessWriteLog()
        {
            //Init variables
            string sFileName = "";
            string sFilePath = "";

            while (!UIExit && EnableWrite)
            {
                Thread.Sleep(WriteInterval);
                try
                {
                    //Check log exitance
                    List<OperationLog> unSavedLogs;
                    lock (lockLocalLogs)
                    {
                        unSavedLogs = LocalLogs.Where(l => !l.IsSaved).ToList();
                        if (unSavedLogs == null || unSavedLogs.Count < 1) continue;
                    }

                    //Check if last log exist
                    sFileName = GetLastLogFileName(out string sDate);
                    sFilePath = LogFolder + sFileName;
                    if (string.IsNullOrWhiteSpace(sFileName))
                    {
                        //Create log file
                        sFilePath = LogFolder + $"{PreFix}{DateString}.log";
                        var fs = File.Create(sFilePath);
                        fs.Close();
                    }

                    //Check log file size
                    var fileInfo = new FileInfo(sFilePath);
                    long length = fileInfo.Length; //Get file size in byte
                    if (length > SizeLimit)
                    {
                        if (DateString != sDate)
                        {
                            sFilePath = LogFolder + $"{PreFix}{DateString}.log";
                            var fs = File.Create(sFilePath);
                            fs.Close();
                        }
                    }

                    //Write to file
                    using (FileStream fs = new FileStream(sFilePath, FileMode.Append))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            foreach (var log in unSavedLogs)
                            {
                                string sMessage = $"{log.TimeLog} {(int)log.Type} {log.Message}";
                                writer.WriteLine(sMessage);
                                log.IsSaved = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("csInkOperationLogHelper:\r\n" + ex.Message);
                }
            }
        }

        public void AddLogMessage(string sMessage, _logType logType = _logType.General)
        {
            OperationLog log = new OperationLog()
            {
                Type = logType,
                Message = sMessage
            };

            AddLog(log);
        }


        private void AddLog(OperationLog log)
        {
            lock (lockLocalLogs)
            {
                if (LocalLogs.Count < 6000)
                {
                    LocalLogs.Add(log);
                }
                else
                {
                    if (LocalLogs.Count > 6000) 
                    {
                        LocalLogs.RemoveRange(0, 1000);
                    }             
                }
            }
        }


        public string GetLastLogFileName(out string sDate)
        {
            //Init variables
            DirectoryInfo dInfo = new DirectoryInfo(LogFolder);
            sDate = "";
            if (!dInfo.Exists) dInfo.Create();

            var files = dInfo.GetFiles();
            var fileNames = files.Select(f => f.Name);
            var pattern = "^" + PreFix + "([0-9]{6})" + Suffix + "$";
            List<string> sNameList = new List<string>();

            foreach (var file in fileNames)
            {
                if (!Regex.IsMatch(file, pattern)) continue;
                var matches = Regex.Split(file, pattern);
                foreach (var match in matches)
                    if (!string.IsNullOrWhiteSpace(match)) sNameList.Add(match);
            }

            //Get result
            if (sNameList.Count == 0)
            {
                return null;
            }
            else
            {
                sNameList.Sort();
                sDate = sNameList[sNameList.Count - 1];
                string sValue = $"{PreFix}{sDate}{Suffix}";
                return sValue;
            }
        }


    }

}
