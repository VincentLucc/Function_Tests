namespace MauiAppTest
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public csMessage messageHelper;

        public MainPage()
        {
            InitializeComponent();

            messageHelper=new csMessage(this); 
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void bTestPage_Clicked(object sender, EventArgs e)
        {
            UIHelper.ShowTestWindow();
        }

        private async void bTestAlert_Clicked(object sender, EventArgs e)
        {
            await messageHelper.ShowMessage("Test Message");
        }

        private async void bSelectionSimple_Clicked(object sender, EventArgs e)
        {
            string sResult = await messageHelper.ShowSelection("Test Message","Option1", "Option2", "Option3");
        }

        private void MenuFlyoutItem_Clicked(object sender, EventArgs e)
        {

        }

        private void menuClose_Clicked(object sender, EventArgs e)
        {

        }
    }
}