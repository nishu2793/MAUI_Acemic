using AceMicEV.Tab;

namespace AceMicEV.Views;

public partial class WelcomeScreen : ContentPage
{

    public WelcomeScreen()
    {
        InitializeComponent();
        BindingContext = this;
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

    private void SkipBtn_Clicked(object sender, EventArgs e)
    {
        statusBar.StatusBarColor = Colors.MediumSeaGreen;
        statusBar.StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.LightContent;
        Navigation.PushAsync(new UserType());
    }

}