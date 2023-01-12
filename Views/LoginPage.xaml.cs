using AceMicEV.Pages;
using AceMicEV.Services;
using System.Windows.Input;
using AceMicEV.Views;

namespace AceMicEV.Views;

public partial class LoginPage : ContentPage
{
    readonly IUserRepository _loginRepository = new LoginService();
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LogIn_Clicked(object sender, EventArgs e)
    {
        LoginIndicator.IsRunning = true;
        await Task.Delay(2000);

        string userName = txtUserID.Text;
        string password = txtPassword.Text;
        if (userName == null || password == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _loginRepository.login(userName, password);
        if (userinfo)
        {
            LoginIndicator.IsRunning = false;
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