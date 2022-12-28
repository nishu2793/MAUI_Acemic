using AceMicEV.Services;
using Android.Views;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage
{
    readonly IConfiRepository _confiRepository = new ConfiService();
    public ConfiPage()
	{
		InitializeComponent();

        var name = "Disha";
        var email = "dishas.dcs@gmail.com";
        webView.Source = "https://paymentdemo.azurewebsites.net?Name=" + name + "&Email=" + email + "&Amount=1&Orderid=3FA85F64-5717-4562-B3FC-2C963F66AFA6";
        //webView.Source = "https://paymentdemo.azurewebsites.net?Name=Disha&Email=dishas.dcs@gmail.com&Amount=1&Orderid=1837150D-9231-4C00-C38F-08DAE33CAEE6";

    }

    private void WebClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen());
    }
}
