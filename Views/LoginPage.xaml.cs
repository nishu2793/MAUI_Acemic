using AceMicEV.Pages;
using AceMicEV.Services;
using System.Windows.Input;
using AceMicEV.Views;
using Microsoft.AspNetCore.SignalR.Client;
using Android.Graphics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core.Views;

namespace AceMicEV.Views;

public partial class LoginPage : ContentPage
{
    readonly HubConnection hubConnection;
    readonly ISignalRepository _signalRepository = new SIgnalRServices();
    readonly IUserRepository _loginRepository = new LoginService();
    public LoginPage()
    {
        InitializeComponent();

    }

    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width != this.width || height != this.height)
        {
            this.width = width;
            this.height = height;
            outerStack1.WidthRequest = width;
            outerStack1.HeightRequest = height;
        }
    }
    private async void LogIn_Clicked(object sender, EventArgs e)
    {

        var popup = new ActivityPopup();
        Shell.Current.ShowPopup(popup);
       

        string userName = txtUserID.Text;
        string password = txtPassword.Text;
        string userid = Preferences.Get("DidKey", null);

        if (userName == null || password == null)
        {
            popup.Close();

            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");

            return;
        }
        var userinfo = await _loginRepository.login(userName, password);
        if (userinfo)
        {
            popup.Close();


            await SignalRHubServices.OpenConnectionAsync(_signalRepository);

            await Shell.Current.GoToAsync($"//{nameof(TabbarPage)}");
        }
        else
        {

            popup.Close();


            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
            LoginIndicator.IsRunning = false;


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