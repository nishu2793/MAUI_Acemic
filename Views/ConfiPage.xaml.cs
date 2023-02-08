using AceMicEV.Services;
using AceMicEV;
using Android.Views;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Java.Lang;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.SignalR.Client;
using Android.OS;
using Mopups.Services;
using AceMicEV.Models.Response;

namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage

{
    readonly HubConnection hubConnection;
    readonly ISignalRepository _signalRepository = new SIgnalRServices();
    readonly IConfiRepository _confiRepository = new ConfiService();
    readonly INotificationRepository _notificationRepository = new NotificationServices();
   // readonly IForgroundService _forground = new ForegroundService();

    public ConfiPage(string firstname,string lastname, string emailAddress, string amount, string orderId)
    {
        //string s =  _forground.StartMyForegroundService();

        InitializeComponent();

        string connectionId = Preferences.Get("ConnectionKey", null);
        var Reqname = firstname + lastname;
        var Reqemail = emailAddress; // Email Key
        var ReqAmount = amount;
        var ReqOrderId = orderId;
        webView.Source = "https://paymentdemo.azurewebsites.net?Name=" + Reqname + "&Email=" + Reqemail + "&Amount=" + ReqAmount + "&Orderid=" + ReqOrderId;
        // webView.Source = "https://paymentdemo.azurewebsites.net?Name=Disha&Email=dishas.dcs@gmail.com&Amount=1&Orderid=1837150D-9231-4C00-C38F-08DAE33CAEE6";

        WebClicked(btnexit,new EventArgs ());

    }

    private async void WebClicked(object sender, EventArgs e)
    {
        await this.SendMessage();
    }

    private void deleteClicked(object sender, EventArgs e)
    {
       // string userid = Preferences.Get("DidKey", null);
        //var hubConnectionID = hubConnection.ConnectionId;
        //var SignalInfo = _signalRepository.Signaldata(hubConnectionID, userid).Result;

        //Preferences.Set("ConnectionKey", hubConnectionID);

        btnexit.IsVisible = true;
    }
    public async Task<string> callfun()
    {
        NotificationServices notificationServices = new NotificationServices();
        DisplayAlert("hello", "heee", "heelee");
        string v = "dfvgfg";
        return v;
    }

    public async Task SendMessage()
    {
        await SignalRHubServices.OpenConnectionAsync(_signalRepository);
        // To retrive the connection
        ConcurrentDicSignalR._dictionary.TryGetValue("signalRConnection", out object signalRConnection);
        var sConnection = (HubConnection)signalRConnection;
        var ConnectionID = sConnection.ConnectionId;
        //string uniqueId = "123";
        sConnection.On<string, string>("ReceiveMessageconectionid", (ConnectionID, message) =>
        {
             var paymentNotifiction = JsonConvert.DeserializeObject<PaymentNotificationResponse>(message);

            if(paymentNotifiction != null)
            {
                MopupService.Instance.PushAsync(new MyPopupPage(paymentNotifiction.Status, paymentNotifiction.OrderId, paymentNotifiction.PaymentId, paymentNotifiction.Amount, paymentNotifiction.Email,
                                               paymentNotifiction.Paymentorderid));
            }

        });
    }

}

