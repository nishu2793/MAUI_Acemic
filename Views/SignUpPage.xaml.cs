using AceMicEV.Services;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Input;

namespace AceMicEV.Views;

public partial class SignUpPage : ContentPage
{
    readonly ISignUpRepository _signUpRepository = new SignupService();
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = this;
        //txtFirstName.Text = Preferences.Get("FirstKey", "Not Valid");
        //txtLastName.Text = Preferences.Get("LastKey", "Empty");
        //txtEmail.Text = Preferences.Get("EmailKey", "Empty");
           
    }

    private async void SignUp_Clicked(object sender, EventArgs e)
    {
        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string email = txtEmail.Text;
            
        if (firstName == null || lastName == null || email == null)
        {
            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _signUpRepository.SignUp(firstName, lastName, email);
        if (userinfo)
        {
            await Navigation.PushAsync(new VerifiyOtpPage());
        }
        else
        {
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }


    }
    //public ICommand Logincommand => new Command(async() =>
    //{

    //    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");


    //});

    private void LogClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
}