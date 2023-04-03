namespace AceMicEV.Views;

public partial class WelcomeScreen3 : ContentPage
{
    public WelcomeScreen3()
    {
        InitializeComponent();
    }

    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 650)
        {
            Resources["lblHeader"] = Resources["lblHeader3Vivo"];
            Resources["lblPrebtn1"] = Resources["lblBtn3FsVivo"];
            Resources["lblbtn5"] = Resources["lblbtn6Vivo"];
        }
    }

    private void PrevBtn3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen2());
    }

    private void NextBtn3_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }

    private void Skip3Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new UserType());

    }
}