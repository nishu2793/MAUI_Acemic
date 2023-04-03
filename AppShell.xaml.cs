using AceMicEV.Views;

namespace AceMicEV;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Routing.RegisterRoute(nameof(MyFlyoutPage), typeof(MyFlyoutPage));

        //Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));
        //Routing.RegisterRoute(nameof(TabbarPage), typeof(TabbarPage));
        //Routing.RegisterRoute(nameof(ActivityPopup), typeof(ActivityPopup));
        //var introscreen = Preferences.Get("IntroScreenKey", "No");
        //if (introscreen == "No")
        //{
        //    Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));
        //    //Shell.Current.GoToAsync($"//{nameof(WelcomeScreen)}");
        //    //Routing.RegisterRoute(nameof(WelcomeScreen), typeof(WelcomeScreen));

        //}
        //else
        //{
        //    Routing.RegisterRoute(nameof(TabbarPage), typeof(TabbarPage));
        //   // Shell.Current.GoToAsync($"//{nameof(TabbarPage)}");
        //    //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        //}

    }
}
