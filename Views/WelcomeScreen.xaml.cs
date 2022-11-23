namespace AceMicEV.Views;

public partial class WelcomeScreen : ContentPage
{
    public WelcomeScreen()
    {
        InitializeComponent();
    }

    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen2());
    }

    private void SkipBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }
}