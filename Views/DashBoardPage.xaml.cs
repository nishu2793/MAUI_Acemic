using AceMicEV.ViewModels;

namespace AceMicEV.Views;


public partial class DashBoardPage : ContentPage
{

    public DashBoardPage()
    {
        InitializeComponent();
        BindingContext = this;

        var LoginName = Preferences.Get("EmailKey", "Null");
        UserName.Text = LoginName;
    }
    private async void BarcodeClicked(object sender, EventArgs e)
    {
        bool allowed = false;
        allowed = await BarcodeScanner.Mobile.Maui.Methods.AskForRequiredPermission();
        if (allowed)
            Navigation.PushModalAsync(new NavigationPage(new ScanPage()));
        else DisplayAlert("Alert", "You have to provide Camera permission", "Ok");
    }

    private void ScanClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanPage());
    }

    private void slotClicked(object sender, EventArgs e)
    {

    }

    private void PayClicked(object sender, EventArgs e)
    {

    }
}
