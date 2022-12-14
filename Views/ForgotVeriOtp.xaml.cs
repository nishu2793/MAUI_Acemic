namespace AceMicEV.Views;

public partial class ForgotVeriOtp : ContentPage
{
	public ForgotVeriOtp()
	{
		InitializeComponent();
	}
    private void ForVeriOtpBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ResetPassPage());
    }

    private void textChangeentry5(object sender, EventArgs e)
    {
        entry5.Unfocus();
        entry6.Focus();
    }
    private void textChangeentry6(object sender, EventArgs e)
    {
        entry6.Unfocus();
        entry7.Focus();
    }
    private void textChangeentry7(object sender, EventArgs e)
    {
        entry7.Unfocus();
        entry8.Focus();
    }
    private void textChangeentry8(object sender, EventArgs e)
    {
        entry8.Unfocus();
        Verify2.Focus();
    }
}