namespace AceMicEV.Views;

public partial class UserType : ContentPage
{
	public UserType()
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
            Resources["lbluser"] = Resources["lbluserVivo"];
        }
    }

    private void UserBtn_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("IntroScreenKey", "No");
        Navigation.PushAsync(new SignUpPage());

        var mytest = Preferences.Get("IntroScreenKey", "No");

    }
    
}