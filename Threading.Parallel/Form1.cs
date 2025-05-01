using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using _CommonCode_Framework;
using System.IO;

namespace Threading_Parallel
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ParallelForButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} ParallelForButton_Click.Enter");
            Parallel.For(0, 5, index =>
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task[{index}].Start");
                Thread.Sleep(5000);
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task[{index}].End");
            });
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Parallel.For.End");
        }

        private void ParallelForSimpleButton_Click(object sender, EventArgs e)
        {
            //对于计算密集类的loop可以限制核心数为物理核心以提高性能
            int iCount = csPublic.GetPhysicalCoreCount();
            var parallelSettings = new ParallelOptions() { MaxDegreeOfParallelism = iCount };
            Parallel.For(0, 100, parallelSettings, index =>
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task[{index}].Start");
                Thread.Sleep(5000);
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task[{index}].End");
            });
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Parallel.For.End");
        }

        private void ParallelForeachButton_Click(object sender, EventArgs e)
        {
            var dirInfo = new DirectoryInfo(Application.StartupPath);
            var fileInfos = dirInfo.GetFiles();
            Parallel.ForEach(fileInfos, fileInfo =>
            {
                Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} {fileInfo.Name}");
            });
        }

        private void ParallelInvokeButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} ParallelForeachButton1_Click.Enter");
            Parallel.Invoke(
                () => { Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task1"); },
                () => { Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task2"); },
                () => { Trace.WriteLine($"{csDateTimeHelper.TimeOnly_fff} Task3"); }
            );
        }
    }
}
