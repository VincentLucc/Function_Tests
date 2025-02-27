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
using System.Xml.Serialization;

public class csLogging
{
    public List<OperationLog> LocalLogs { get; set; }
    [XmlIgnore]
    public object lockLocalLogs = new object();

    public string LogFolder { get; set; }
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
    public int WriteInterval { get; set; } = 1000;

    public bool UIExit => ParentControl == null || ParentControl.IsDisposed || ParentControl.IsDisposed;

    private Thread WriteThread;

    public csLogging(Form _parentForm)
    {
        LocalLogs = new List<OperationLog>();
        ParentControl = _parentForm;
        LogFolder = Application.StartupPath + @"\Log\";
    }

    public async Task Start()
    {
        await Stop();

        EnableWrite = true;

        WriteThread = new Thread(ProcessWriteLog);
        WriteThread.Name = "Thread_Write";
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
        string sName = thread.Name != null ? thread.Name : string.Empty;

        try
        {//Wait to close
            while (thread.IsAlive)
            {
                await Task.Delay(20);

                if (watch.ElapsedMilliseconds > iTimeout)
                {
                    Trace.WriteLine($"WaitThreadAsync.Timeout: {watch.ElapsedMilliseconds}/{iTimeout}");
                    thread.Abort();
                    Trace.WriteLine($"WaitThreadAsync.Thread aborted: {sName}");
                    break;
                }
            }
            thread = null;
        }
        catch (Exception e)
        {
            Trace.WriteLine("csLogging.CloseThread.Exception\r\n:" + e.Message);
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

            try
            {
                //Check log exitance
                List<OperationLog> unSavedLogs;
                lock (lockLocalLogs)
                {
                    unSavedLogs = LocalLogs.Where(l => !l.IsSaved).ToList();
                    if (unSavedLogs == null || unSavedLogs.Count < 1) continue;
                }

                //Always check the log folder
                if (!Directory.Exists(LogFolder))
                    Directory.CreateDirectory(LogFolder);

                //Check if last log exist
                sFileName = GetLastLogFileName(out string sDate);
                sFilePath = LogFolder + sFileName;

                //If the file doesn't exist, create a new file.
                //If the file is not up-to-date, create a new file
                if (string.IsNullOrWhiteSpace(sFileName) || 
                    DateString != sDate)
                { //Create log file
                    sFilePath = LogFolder + $"{PreFix}{DateString}.log";
                    var fs = File.Create(sFilePath);
                    fs.Close();
                }
 
                //Write to file
                using (FileStream fs = new FileStream(sFilePath, FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        foreach (var log in unSavedLogs)
                        {
                            string sMessage = log.GetMessage();
                            writer.WriteLine(sMessage);
                            log.IsSaved = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("csInkOperationLogHelper:\r\n" + ex.Message);
            }
            finally
            {
                Thread.Sleep(WriteInterval);
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
            if (LocalLogs.Count > 2500)
            {
                LocalLogs.RemoveRange(0, 500);
            }
            LocalLogs.Add(log);
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
        if (sNameList.Count == 0) return null;
        sNameList.Sort();
        sDate = sNameList[sNameList.Count - 1];
        string sValue = $"{PreFix}{sDate}{Suffix}";
        return sValue;

    }


}