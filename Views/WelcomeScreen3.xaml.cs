namespace AceMicEV.Views;

public partial class WelcomeScreen3 : ContentPage
{
    public WelcomeScreen3()
    {
        InitializeComponent();
    }

    private void PrevBtn3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen2());
    }

    private void NextBtn3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }

    private void SkipBtn3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }
}