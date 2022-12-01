using AceMicEV.Pages;
using AceMicEV.Services;

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
        string userName = txtUserID.Text;
        string password = txtPassword.Text;
        if (userName == null || password == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _loginRepository.Login(userName, password);
        if (userinfo)
        {
            await Navigation.PushAsync(new AboutPage());
        }
        else
        {
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }

    }
}