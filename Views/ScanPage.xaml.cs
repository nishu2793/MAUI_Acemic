using AceMicEV.Views;

namespace AceMicEV;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
	}

    private void Scan_Clicked(object sender, EventArgs e)
    {
       Navigation.PushAsync(new MainPage());
    }

    private void Pay_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OrderPage());
    }
}