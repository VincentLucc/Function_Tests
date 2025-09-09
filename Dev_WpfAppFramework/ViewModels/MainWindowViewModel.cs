using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _CommonCode_Framework;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Windows.Input;

namespace Dev_WpfAppFramework.ViewModels
{

    class MainWindowViewModel : ViewModelBase
    {
        [BindableProperty]
        public virtual ViewModelBase CurrentContent { get; set; }

        public MainWindowViewModel()
        {
            CurrentContent = new QuickTestViewModel();
        }

        [Command]
        public virtual void TestMethod1()
        {
            "TestMethod1.Click".TraceRecord();
        }
    }
}
