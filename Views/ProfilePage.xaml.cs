using AceMicEV.Services;
using DocumentFormat.OpenXml.Bibliography;

namespace AceMicEV.Views;

public partial class ProfilePage : ContentPage
{
     IProfileRepository _profileRepository = new ProfileServices();
    string Gender;

    public ProfilePage()
	{
		InitializeComponent();
        var GetDid = Preferences.Get("DidKey", "Ok");

        var abc = Preferences.Get("FirstKey", "Ok");
        FName.Text = Preferences.Get("FirstKey", "Null").ToString();
        LName.Text = Preferences.Get("LastKey", "NUll").ToString();
        txtEmail.Text = Preferences.Get("EmailKey", "Null").ToString();

    }
    public async void Image_Clicked(object sender, EventArgs e)
    {
        PickOptions options = new PickOptions();
        try
        {

            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                    ImgBtn.Source = image;

                }
                else
                {
                    ImgBtn.Source = "imagebox.png";

                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton Radiogender = (RadioButton)sender;
        Gender = Radiogender.Content.ToString();

    }
    private async void ProClicked_Clicked(object sender, EventArgs e)
    {
        string Did = Preferences.Get("DidKey", "Ok");

        string FstName = FName.Text;
        string LstName = LName.Text;
        string EmailName = txtEmail.Text;
        string Mobile = txtPhone.Text;
        var userinfo = await _profileRepository.Prodata(Did, FstName, LstName, EmailName, Mobile, Gender);
        if (userinfo)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        

       
    }

   
}