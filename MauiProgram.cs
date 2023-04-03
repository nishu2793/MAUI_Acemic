﻿using AceMicEV.ViewModels;
using AceMicEV.Views;
using Android.Graphics.Drawables;
using BarcodeScanner.Mobile.Maui;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

namespace AceMicEV;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
               // fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "Poppins-Regular");


            })

             .ConfigureMauiHandlers(handlers =>
             {
                 handlers.AddBarcodeScannerHandler();
             });


        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (A, V) =>
        {
            A.PlatformView.BackgroundTintList =
            Android.Content.Res.ColorStateList.ValueOf(Colors.AliceBlue.ToAndroid());
        });

        Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
        {


#if ANDROID
            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(global::Android.Graphics.Color.AliceBlue);
            // handler.PlatformView.SetBackgroundDrawable(gd); deprecated  
            handler.PlatformView.SetBackground(gd);
#endif

        });


        return builder.Build();
    }
}   