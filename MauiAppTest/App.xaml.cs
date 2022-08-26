#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

namespace MauiAppTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetPlantForm();           
            MainPage = new AppShell();
        }

        private void GetPlantForm()
        {
#if WINDOWS
            csPublic.CurrentPlatform = PlatFormType.Windows;
#elif ANDROID
            csPublic.CurrentPlatform = PlatFormType.Android;
#endif
        }


    }



}