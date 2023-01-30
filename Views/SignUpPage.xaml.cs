using AceMicEV.Services;
using AndroidX.Loader.Content;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Input;
using Color = Microsoft.Maui.Graphics.Color;
using Colors = Microsoft.Maui.Graphics.Colors;

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

    private async void SignUp_Clicked(object sender, EventArgs e)
    {
        activityIndicator.IsRunning = true;
        await Task.Delay(2000);

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
            activityIndicator.IsRunning = false;
            await Navigation.PushAsync(new VerifiyOtpPage());
        }
        else
        {
            activityIndicator.IsRunning = false;
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }
    }
    private void LoginTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
        
    }
}