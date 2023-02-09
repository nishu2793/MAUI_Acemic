using AceMicEV.ViewModels;
using AceMicEV.Views;
using BarcodeScanner.Mobile.Maui;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Mopups.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace AceMicEV;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

            })
            //Views
            //builder.Services.AddSingleton<DashBoardPage>();

            // //View Models
            // builder.Services.AddSingleton<DashPageViewModel>();

            //.ConfigureBarcodeScanner();
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddBarcodeScannerHandler();
            });

        return builder.Build();
    }
}