using AceMicEV.Pages;
using AceMicEV.Services;
using System.Windows.Input;
using AceMicEV.Views;
using Microsoft.AspNetCore.SignalR.Client;

namespace AceMicEV.Views;

public partial class LoginPage : ContentPage
{
    private readonly HubConnection hubConnection;
    readonly ISignalRepository _signalRepository = new SIgnalRServices();
    readonly IUserRepository _loginRepository = new LoginService();
    public LoginPage()
    {
        InitializeComponent();

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
    }

    private async void LogIn_Clicked(object sender, EventArgs e)
    {
        LoginIndicator.IsRunning = true;
        await Task.Delay(2000);

        string userName = txtUserID.Text;
        string password = txtPassword.Text;
        string userid = Preferences.Get("DidKey", null);

        if (userName == null || password == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _loginRepository.login(userName, password);
        if (userinfo)
        {
            LoginIndicator.IsRunning = false;
            var hubConnectionID = hubConnection.ConnectionId;
            var SignalInfo = await _signalRepository.Signaldata(hubConnectionID, userid);

            Preferences.Set("ConnectionKey", hubConnectionID);

            await Navigation.PushAsync(new DashBoardPage());
        }
        else
        {
            LoginIndicator.IsRunning = false;
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }

    }
    private void Check_Btn(object sender, CheckedChangedEventArgs e)
    {
        if(e.Value==true)
        {
            
        }
        else
        {

        }
    }

    private void SignTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUpPage());
    }
}