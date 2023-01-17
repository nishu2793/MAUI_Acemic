using AceMicEV.Services;
using Android.Views;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Java.Lang;
using System.Runtime.CompilerServices;

<<<<<<< HEAD
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

=======
>>>>>>> bb15536990754e0058760dc2fa1a2d10f7712e38
namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage

{
    private readonly HubConnection hubConnection;
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
       // webView.Source = "https://paymentdemo.azurewebsites.net?Name=Disha&Email=dishas.dcs@gmail.com&Amount=1&Orderid=1837150D-9231-4C00-C38F-08DAE33CAEE6";

        // SignalR

        var baseUrl = "";

        // Android can't connect to localhost
        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
        {
            baseUrl = "https://acemicapi.azurewebsites.net/";
        }

        hubConnection = new HubConnectionBuilder()
            .WithUrl($"{baseUrl}/chatHub")
            .Build();

        hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
        {
            lblChat.Text += $"<b>{user}</b>: {message}<br/>";
        });

        Task.Run(() =>
        {
            Dispatcher.Dispatch(async () =>
            {
                await hubConnection.StartAsync();
            });
        });

        // signalR

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
<<<<<<< HEAD

=======
>>>>>>> bb15536990754e0058760dc2fa1a2d10f7712e38
}

