using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev_WpfAppFramework.ViewModels
{
    [POCOViewModel]
    class QuickTestViewModel : ViewModelBase
    {
    
        public virtual string TestStr1 { get; set; }

   
        public virtual void ClickTest1Command()
        {
            TestStr1 = DateTime.Now.ToShortTimeString();
        }
    }
}
