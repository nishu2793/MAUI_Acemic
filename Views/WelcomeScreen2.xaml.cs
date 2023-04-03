
namespace AceMicEV.Views;

public partial class WelcomeScreen2 : ContentPage
{
	public WelcomeScreen2()
	{
		InitializeComponent();
	}
    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height<=650)
        {
            Resources["lblHeade2"] = Resources["lblHeader2Vivo"];
            Resources["lblPrebtn"] = Resources["lblBtn2FsVivo"];
            Resources["lblbtn5"] = Resources["lblbtn5Vivo"];
        }
    }

    private void NextBtn2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen3());

    }
    private void PreBtn2_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new WelcomeScreen());
    }

    private void Skip1Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new UserType());
    }

}