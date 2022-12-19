namespace AceMicEV.Views;

public partial class DashBoardPage : ContentPage
{
	public DashBoardPage()
	{
		InitializeComponent();
        var LoginName= Preferences.Get("EmailKey", "Null");
        UserName.Text = LoginName;
    }

    private void BarcodClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanPage());
    }

    private void Pay_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PaymentPage());
    }

    private void ScanClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanPage());
    }

    private void PayClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanPage());
    }
}
