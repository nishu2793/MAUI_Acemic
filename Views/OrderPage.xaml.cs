
using AceMicEV.Models;
using AceMicEV.Services;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System.Reflection.PortableExecutable;

namespace AceMicEV.Views;

public partial class OrderPage : ContentPage
{
    IConfiRepository _confiRepository  = new ConfiService();
    public OrderPage(string did, string barcodeNumber, string city, string zipcode, string address1, string address2 )
    {
        InitializeComponent();
        date.Text = DateTime.Now.ToString();
        resultaddress.Text = address1.ToString();
        resultaddress2.Text = address2.ToString();
        cityWise.Text = city.ToString();
        zipCode.Text = zipcode.ToString();
        var LoginName = Preferences.Get("EmailKey", "Null");
        UserProfileName.Text = LoginName;
        txtMachine.Text = did;

    }
    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (height <= 650)
        {
            Resources["lblUserdetails"] = Resources["lblUserdetailsVivo"];
            Resources["lblFont"] = Resources["lblFontVivo"];
            Resources["lblBookdetails"] = Resources["lblBookdetailsVivo"];
            Resources["lblMachine"] = Resources["lblMachineVivo"];
            Resources["lblUserProfile"] = Resources["lblUserProfileVivo"];

        }
    }
    private async void SubmitPage_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new ConfiPage());

        string MachineId = txtMachine.Text;
        string Amount = txtAmount.Text;
        string Selecttype = dwnSelctType.SelectedItem.ToString();
        string UserDid = Preferences.Get("DidKey", "Null");

        var userinfo = await _confiRepository.Condata(MachineId, Amount, Selecttype, UserDid);
        if (userinfo != null)
        {
            await Navigation.PushAsync(new ConfiPage(userinfo.firstname,userinfo.lastname, userinfo.emailAddress, userinfo.amount, userinfo.orderId));
        }

    }
}