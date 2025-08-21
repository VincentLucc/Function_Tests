using _CommonCode_Framework;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dev_WpfAppFramework.Views
{
    /// <summary>
    /// Interaction logic for QuickTest1UserControl.xaml
    /// </summary>
    [POCOViewModel]
    public partial class QuickTest1UserControl : UserControl
    {
        [BindableProperty]
        public virtual string TestProperty01 { get; set; } = "Value1";
        public QuickTest1UserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            "ClickMe_Click".TraceRecord();
            TestProperty01 = DateTime.Now.ToLongTimeString();
        }
    }
}
