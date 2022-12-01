using AceMicEV.Services;
using System.Windows.Input;

namespace AceMicEV.Views;

public partial class SignUpPage : ContentPage
{
    readonly ISignUpRepository _loginRepository = new SignupService();
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void SignUp_Clicked(object sender, EventArgs e)
    {
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        if (firstName == null || lastName == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _loginRepository.SignUp(firstName, lastName);
        if (userinfo)
        {
            await Navigation.PushAsync(new VerifiyOtpPage());
        }
        //else
        //{
        //    await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        //}

       
    }
    public ICommand SkipCommand => new Command(async () =>
    {

        await AppShell.Current.GoToAsync($"//{nameof(LoginPage)}");
       

    });


}