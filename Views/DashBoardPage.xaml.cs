using AceMicEV.ViewModels;
using Android.Icu.Text;
using DocumentFormat.OpenXml.Drawing;

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
    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 650)
        {
            Resources["lblUserName"] = Resources["lblUserNameVivo"];
            Resources["lblImageKey"] = Resources["lblImageKeyVivo"];
            Resources["lblOrientation"] = Resources["lblOrientationVivo"];
            Resources["lblOrientation1"] = Resources["lblOrientation1Vivo"];
            Resources["lblBookSlot"] = Resources["lblBookSlotVivo"];

        }
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

    private void Tab_Clicked(object sender, EventArgs e)
    {
        //Shell.Current.FlyoutIsPresented = true;

    }

    private void logoutClicked(object sender, EventArgs e)
    {
        Preferences.Set("TokenKey", null);
        Preferences.Set("EmailKey", null);
        Navigation.PushAsync(new LoginPage());

    }
}
