namespace AceMicEV.Views;

public partial class PassWordPage : ContentPage
{
	public PassWordPage()
	{
		InitializeComponent();
	}

    private void PassSubmit_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }
}