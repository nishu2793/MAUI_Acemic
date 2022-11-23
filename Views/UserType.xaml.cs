namespace AceMicEV.Views;

public partial class UserType : ContentPage
{
	public UserType()
	{
		InitializeComponent();
	}

    private void UserBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SignUpPage());
    }
    
}