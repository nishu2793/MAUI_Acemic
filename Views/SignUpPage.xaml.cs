using AceMicEV.Services;
using AndroidX.Loader.Content;
using CommunityToolkit.Maui.Views;
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
        var popup = new ActivityPopup();
        Shell.Current.ShowPopup(popup);

        string firstName = txtFirstName.Text;
        string lastName = txtLastName.Text;
        string email = txtEmail.Text;
            
        if (firstName == null || lastName == null || email == null)
        {
            popup.Close();

            await DisplayAlert("Warning", "Please Input Username & Password", "Ok");
            return;
        }
        var userinfo = await _signUpRepository.SignUp(firstName, lastName, email);
        if (userinfo)
        {
            popup.Close();
            await Navigation.PushAsync(new VerifiyOtpPage());
        }
        else
        {
            popup.Close();
            await DisplayAlert("Invalid User", " Username or Password incorrect", "Ok");
        }
    }
    private void LoginTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
        
    }
}