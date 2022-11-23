namespace AceMicEV.Views;

public partial class VerifiyOtpPage : ContentPage
{
	public VerifiyOtpPage()
	{
		InitializeComponent();
	}

    private void VerifyBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PassWordPage());
    }
}