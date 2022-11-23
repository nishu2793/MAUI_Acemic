namespace AceMicEV.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

    private void SignUp_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerifiyOtpPage());
    }
}