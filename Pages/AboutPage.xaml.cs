using AceMicEV.Views;
using System.Collections.Generic;

namespace AceMicEV.Pages;
public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();

        User.Text = Preferences.Get("EmailKey", "Not Valid");
        Token.Text = Preferences.Get("TokenKey", "Empty");
        First.Text = Preferences.Get("FirstKey", "Empty");
        Last.Text = Preferences.Get("LastKey", "Empty");
    }
    private async void userLogOut(object sender, EventArgs e)
    {
        Preferences.Remove("EmailKey");
        Preferences.Remove("TokenKey");

        App.Current.MainPage = new NavigationPage(new LoginPage());

    }
}