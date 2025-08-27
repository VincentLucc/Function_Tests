using _CommonCode_Framework;
using Dev_WpfAppFramework.Views;
using System;
using System.Collections.Generic;
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

namespace Dev_WpfAppFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<csAccordingItem> accordingItems = new List<csAccordingItem>();

        public MainWindow()
        {
            InitializeComponent();
            //Events
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Init controls
            mainContentControl.Content = new QuickTest1UserControl();
        }

        private void accordion01_SelectedItemChanged(object sender, DevExpress.Xpf.Accordion.AccordionSelectedItemChangedEventArgs e)
        {
            "accordion01_SelectedItemChanged.CLicked".TraceRecord();
            if (accordion01.SelectedItem == item1AccordionItem)
            {
                mainContentControl.Content = new QuickTest1UserControl();
            }
            else if (accordion01.SelectedItem == item2AccordionItem)
            {
                mainContentControl.Content = new Item2UserControl();
            }
        }
    }
}
