using AceMicEV.Pages;

namespace AceMicEV.Views;

public partial class ForgotPass : ContentPage
{
	public ForgotPass()
	{
		InitializeComponent();
	}

    private void ForgotSubmit_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new ForgotVeriOtp());
    }
}