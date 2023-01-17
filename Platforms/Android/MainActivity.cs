﻿using Android.App;
using Android.Content.PM;
using Android.Widget;

namespace AceMicEV;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override void OnBackPressed()
    {
        Toast.MakeText(this, "Back Button Pressed Detected", ToastLength.Short).Show();
        {
            DependencyService.Get<IAndroidMethods>().CloseApp();
        }
    }
}
