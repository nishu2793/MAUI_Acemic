using AceMicEV.Services;

namespace AceMicEV.Views;

public partial class ConfiPage : ContentPage
{
    readonly IConfiRepository _confiRepository = new ConfiService();
    public ConfiPage()
	{
		InitializeComponent();
	}
}