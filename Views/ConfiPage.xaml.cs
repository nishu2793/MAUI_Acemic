using AceMicEV.Services;
using Android.Views;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Java.Lang;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.SignalR.Client;

namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage

{
    private readonly HubConnection hubConnection;
    readonly ISignalRepository _signalRepository = new SIgnalRServices();
    readonly IConfiRepository _confiRepository = new ConfiService();
    readonly INotificationRepository _notificationRepository = new NotificationServices();
    readonly IForgroundService _forground = new ForegroundService();

    public ConfiPage(string firstname,string lastname, string emailAddress, string amount, string orderId)
    {
        //string s =  _forground.StartMyForegroundService();

        InitializeComponent();

        string connectionId = Preferences.Get("ConnectionKey", null);
        var Reqname = firstname+lastname;
        var Reqemail = emailAddress; // Email Key
        var ReqAmount = amount;
        var ReqOrderId = orderId;
        webView.Source = "https://paymentdemo.azurewebsites.net?Name="+Reqname+"&Email="+Reqemail+"&Amount="+ReqAmount+"&Orderid="+ReqOrderId;
        // webView.Source = "https://paymentdemo.azurewebsites.net?Name=Disha&Email=dishas.dcs@gmail.com&Amount=1&Orderid=1837150D-9231-4C00-C38F-08DAE33CAEE6";

        // SignalR

            var baseUrl = "";

            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            {
                baseUrl = "https://acemicapi.azurewebsites.net/";
            }

            hubConnection = new HubConnectionBuilder()
            .WithUrl($"{baseUrl}/chatHub")
            .Build();

            hubConnection.On<string, string>("ReceiveMessageconectionid", (connectionid, message) =>
            {
                lblChat.Text += $"<b>: {connectionid}</b>: {message}<br/>";
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
        string userid = Preferences.Get("DidKey", null);
        var hubConnectionID = hubConnection.ConnectionId;
        var SignalInfo = _signalRepository.Signaldata(hubConnectionID, userid).Result;

        Preferences.Set("ConnectionKey", hubConnectionID);

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

