
namespace AceMicEV.Views;

public partial class WelcomeScreen : ContentPage
{

    public WelcomeScreen()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 650)
        {
            Resources["lblHeader"] = Resources["lblHeaderVivo"];
            Resources["lblBtnFs"] = Resources["lblBtnFsVivo"];
        }
    }

    protected override bool OnBackButtonPressed()
    {

        Device.BeginInvokeOnMainThread(new Action(async () =>
        {
            var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");

            if (result)
            {
                if (Device.RuntimePlatform == Device.Android)
                    DependencyService.Get<IAndroidMethods>().CloseApp();
            }
        }));
        return true;
    }

    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        statusBar.StatusBarColor = Colors.MediumSeaGreen;
        statusBar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;
        
        Navigation.PushAsync(new WelcomeScreen2());

    }

    private void SkipTapped(object sender, TappedEventArgs e)
    {
        statusBar.StatusBarColor = Colors.MediumSeaGreen;
        statusBar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;
        Navigation.PushAsync(new UserType());
    }

}