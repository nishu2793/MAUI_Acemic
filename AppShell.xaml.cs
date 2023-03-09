using AceMicEV.Views;

namespace AceMicEV;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        var introscreen = Preferences.Get("IntroScreenKey", "No");
        if (introscreen == "No")
        {
            Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));
            //Shell.Current.GoToAsync($"//{nameof(WelcomeScreen)}");
            //Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));

        }
        else
        {
            Routing.RegisterRoute(nameof(TabbarPage), typeof(TabbarPage));
           // Shell.Current.GoToAsync($"//{nameof(TabbarPage)}");
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

    }
}
