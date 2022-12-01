namespace AceMicEV.Views;

public partial class PassWordPage : ContentPage
{
	public PassWordPage()
	{
		InitializeComponent();
	}



    private void PassSubmit_Clicked(object sender, EventArgs e)
    {

        if (txtPassword.Text != txtConfirmPassword.Text)
        {
            lblerror.Text = "Password not Matched";
            lblerror.IsVisible = true;
        }
        else
        {

            string password = txtPassword.Text;
            Preferences.Set("PasswordKey", txtPassword.Text);

            
            Navigation.PushAsync(new ProfilePage());
        }


    }

   
}