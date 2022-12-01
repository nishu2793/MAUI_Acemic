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

    private void textChangeentry1(object sender, EventArgs e)
    {
        entry1.Unfocus();
        entry2.Focus();
    }
    private void textChangeentry2(object sender, EventArgs e)
    {
        entry2.Unfocus();
        entry3.Focus();
    }
    private void textChangeentry3(object sender, EventArgs e)
    {
        entry3.Unfocus();
        entry4.Focus();
    }
    private void textChangeentry4(object sender, EventArgs e)
    {
        entry4.Unfocus();
        Verify1.Focus();
    }
}