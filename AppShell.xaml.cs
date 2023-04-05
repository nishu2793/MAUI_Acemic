using AceMicEV.Views;

namespace AceMicEV;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        var introscreen = Preferences.Get("IntroScreenKey", null);

        if (introscreen == "No")
        {
            GoToAsync($"//{nameof(SignUpPage)}");

        }

        var UserEmail = Preferences.Get("EmailKey", null);
        if(UserEmail != null)
        {
            GoToAsync($"//{nameof(TabbarPage)}");

        }

    }

    private void LogoutClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LoginPage());
    }
}
