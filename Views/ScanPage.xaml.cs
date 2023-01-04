using System.Collections.Generic;
using BarcodeScanner.Mobile.Core;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

using AceMicEV.Views;
using AceMicEV.Services;

namespace AceMicEV;

public partial class ScanPage : ContentPage
{
    readonly IMachineRepository _machineRepository = new MachineService();
    public ScanPage()
	{
		InitializeComponent();
        BarcodeScanner.Mobile.Core.Methods.SetSupportBarcodeFormat(BarcodeFormats.Code39 | BarcodeFormats.QRCode | BarcodeFormats.Code128);
        On<iOS>().SetUseSafeArea(true);
    }

    //private void Pay_Clicked(object sender, EventArgs e)
    //{
    //    Navigation.PushAsync(new OrderPage());
    //}

    private void CameraView_OnDetected(object sender, OnDetectedEventArg e)
    {

        List<BarcodeResult> obj = e.BarcodeResults;

        string result = string.Empty;
        for (int i = 0; i < obj.Count; i++)
        {
           // result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine}";
            result += obj[i].DisplayValue;
        }

        this.Dispatcher.Dispatch(async () =>
        {
            var machineInfo = await _machineRepository.Machinedata(result);
            if(machineInfo != null)
            {
                Navigation.PushAsync(new OrderPage(machineInfo.did,machineInfo.barcodeNumber,machineInfo.city,machineInfo.zipcode,machineInfo.address1,machineInfo.address2));
            }
            else
            {
                DisplayAlert("Warning", "Machine Not Found", "Ok");
            }
            
            //Navigation.PushAsync(new OrderPage(result));
            //await DisplayAlert("Result", result, "OK");
            //Camera.IsScanning = true;
        });
    }

    private void Butn1_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NotificationPage());
    }
}
