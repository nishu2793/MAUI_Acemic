
using AceMicEV.Services;
using System.Reflection.PortableExecutable;

namespace AceMicEV.Views;

public partial class OrderPage : ContentPage
{
    IConfiRepository _confiRepository  = new ConfiService();
	public OrderPage()
	{
		InitializeComponent();
        var LoginName = Preferences.Get("EmailKey", "Null");
        UserProfileName.Text = LoginName;

    }
    private async void SubmitPage_Clicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new ConfiPage());

        string MachineId = txtMachine.Text;
        string Amount = txtAmount.Text;
        string Selecttype = dwnSelctType.SelectedItem.ToString();
        string UserDid = Preferences.Get("DidKey", "Null");

        var userinfo = await _confiRepository.Condata(MachineId, Amount, Selecttype, UserDid);
        if (userinfo)
        {
            await Navigation.PushAsync(new ConfiPage());
        }


    }
}