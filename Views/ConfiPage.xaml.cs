using AceMicEV.Services;
using Android.Views;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Java.Lang;
using System.Runtime.CompilerServices;

namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage
{
    readonly IConfiRepository _confiRepository = new ConfiService();
    readonly INotificationRepository _notificationRepository = new NotificationServices();
    readonly IForgroundService _forground = new ForegroundService();

    public ConfiPage(string firstname,string lastname, string emailAddress, string amount, string orderId)
    {
        InitializeComponent();
    //    string s =  _forground.StartMyForegroundService();

        var Reqname = firstname+lastname;
        var Reqemail = emailAddress; // Email Key
        var ReqAmount = amount;
        var ReqOrderId = orderId;
        webView.Source = "https://paymentdemo.azurewebsites.net?Name="+Reqname+"&Email="+Reqemail+"&Amount="+ReqAmount+"&Orderid="+ReqOrderId;
        webView.Source = "https://paymentdemo.azurewebsites.net?Name=Disha&Email=dishas.dcs@gmail.com&Amount=1&Orderid=1837150D-9231-4C00-C38F-08DAE33CAEE6";

    }

    private void WebClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen());
    }

    private void deleteClicked(object sender, EventArgs e)
    {
        btnexit.IsVisible = true;
    }
    public async Task<string> callfun()
    {
        NotificationServices notificationServices = new NotificationServices();
        DisplayAlert("hello", "heee", "heelee");
        string v = "dfvgfg";
        return v;
    }
}

