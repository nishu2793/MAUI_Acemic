namespace AceMicEV.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
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

    private void ProClicked_Clicked(object sender, EventArgs e)
    {
        //string FirstName = txtfirst.Text;
        Navigation.PushAsync(new LoginPage());
    }
}