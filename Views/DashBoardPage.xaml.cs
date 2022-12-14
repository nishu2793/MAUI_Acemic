namespace AceMicEV.Views;

public partial class DashBoardPage : ContentPage
{
	public DashBoardPage()
	{
		InitializeComponent();
	}

	private void ScanClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}
}