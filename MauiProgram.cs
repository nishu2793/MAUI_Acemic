using BarcodeScanner.Mobile.Maui;
using CommunityToolkit.Maui;
using Microsoft.Maui.Controls.Compatibility.Hosting;
namespace AceMicEV;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("poppins.ttf", "poppins");

            })
            //.ConfigureBarcodeScanner();
            .ConfigureMauiHandlers(handlers =>
            {
                handlers.AddBarcodeScannerHandler();
            });

        return builder.Build();
    }
}