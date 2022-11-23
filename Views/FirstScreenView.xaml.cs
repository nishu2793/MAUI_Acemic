using AceMicEV.ViewModels;

namespace AceMicEV.Views;

public partial class FirstScreenView : ContentPage
{
	public FirstScreenView()
	{
		InitializeComponent();
		this.BindingContext = new FirstScreenViewModel();
	}
}