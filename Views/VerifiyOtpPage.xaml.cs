using AceMicEV.Services;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AceMicEV.Views;

public partial class VerifiyOtpPage : ContentPage
{

    readonly IOtpRepository _otpRepository = new VerifyServices();

    public VerifiyOtpPage()
	{
		InitializeComponent();
        OtpShow.Text = Preferences.Get("OtpKey", "Empty");
    }


    string var;

    private async void VerifyBtn_Clicked(object sender, EventArgs e)
    {
        var = entry1.Text + entry2.Text + entry3.Text + entry4.Text;
        string email = Preferences.Get("EmailKey", "Ok");
        string otp = Preferences.Get("OtpKey", "Ok");
        string did = Preferences.Get("DidKey", "Ok");

        if (entry1.Text == null || entry2.Text == null || entry3.Text == null || entry4.Text == null)
        {
            await DisplayAlert("Warning", "Please Input OTP", "Ok");
            return;
        }
        var userinfo = await _otpRepository.VerOtp(did, otp, null, email);
        if (userinfo)
        {
            await Navigation.PushAsync(new PassWordPage());
        }
        else
        {
            await DisplayAlert("Invalid OTP", "Please Valid OTP", "Ok");
        }

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