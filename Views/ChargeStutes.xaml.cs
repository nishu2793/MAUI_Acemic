namespace AceMicEV.Views;

public partial class ChargeStutes : ContentPage
{
	public ChargeStutes()
	{
		InitializeComponent();
	}

    private void homeClicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new WelcomeScreen());
    }
}