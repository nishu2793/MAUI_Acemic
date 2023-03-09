namespace AceMicEV.Views;

public partial class UserType : ContentPage
{
	public UserType()
	{
		InitializeComponent();
	}

    private void UserBtn_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("IntroScreenKey", "Yes");
        Navigation.PushAsync(new SignUpPage());

        var mytest = Preferences.Get("IntroScreenKey", "No");

    }
    
}