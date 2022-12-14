using AceMicEV.Pages;
using AceMicEV.Services;
using System.Windows.Input;

namespace AceMicEV.Views;

public partial class LoginPage : ContentPage
{
    readonly IUserRepository _loginRepository = new LoginService();
    public LoginPage()
    {
        InitializeComponent();
    }
    //protected override bool OnBackButtonPressed()
    //{

    //    Device.BeginInvokeOnMainThread(new Action(async () => {
    //        var result = await this.DisplayAlert("Alert!", "Do you really want to exit?", "Yes", "No");

    //        if (result)
    //        {
    //            if (Device.RuntimePlatform == Device.Android)
    //                DependencyService.Get<IAndroidMethods>().CloseApp();
    //        }
    //    }));
    //    return true;
    //}

    private async void LogIn_Clicked(object sender, EventArgs e)
    {
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
            await Navigation.PushAsync(new DashBoardPage());
        }
        else
        {
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }

    }
    private void Check_Btn(object sender, CheckedChangedEventArgs e)
    {
        if(e.Value==true)
        {
            DisplayAlert("ohk", "Yes Ofcourse", "Cancel");
        }
        else
        {
            DisplayAlert("No","No Never", "Ok");
        }
    }
    public ICommand SignUpCommand => new Command(async () =>
    {
       
      await AppShell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        

    });
}