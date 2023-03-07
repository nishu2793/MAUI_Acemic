 using AceMicEV.Views;

namespace AceMicEV;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new NavigationPage(new WelcomeScreen());
        MainPage = new AppShell();


    }

}
