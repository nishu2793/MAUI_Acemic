using AceMicEV.Services;

namespace AceMicEV.Views;

public partial class PassWordPage : ContentPage
{
    readonly IPasswordRepository _passwordRepository = new PasswordServices();
	public PassWordPage()
	{
        InitializeComponent();
        Preferences.Set("PasswordKey", txtPassword.Text);
    }

    private async void PassSubmit_Clicked(object sender, EventArgs e)
    {
        string did = Preferences.Get("DidKey", "Ok");
        string password = txtPassword.Text;

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblerror.Text = "Password not Matched";
            lblerror.IsVisible = true;
        }
        var userinfo = await _passwordRepository.Passmatch(password, did);
        var getinfo = await _passwordRepository.getall(did);
        if (userinfo)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
    }

   
}