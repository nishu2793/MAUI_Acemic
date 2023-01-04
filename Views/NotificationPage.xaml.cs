using AceMicEV.Services;

namespace AceMicEV.Views;

public partial class NotificationPage : ContentPage
{
    readonly IForgroundService _forground = new ForegroundService();

    public NotificationPage()
	{
		InitializeComponent();
	}

    private async void btnforgroundservice_Clicked(object sender, EventArgs e)
    {
      

       _forground.StartMyForegroundService();

       
    }
    
}