namespace AceMicEV;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

	public void Next_Clicked(object sender, EventArgs e)
	{
        Navigation.PushAsync(new HomePage());
    }

}
