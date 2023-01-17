
namespace AceMicEV.Views;

public partial class WelcomeScreen2 : ContentPage
{
	public WelcomeScreen2()
	{
		InitializeComponent();
	}
    private void NextBtn2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen3());

    }
    private void PreBtn2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen());
    }

    private void SkipBtn2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }
    
}