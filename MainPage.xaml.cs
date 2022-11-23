using System.Runtime.CompilerServices;

namespace AceMicEV;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void Next_Clicked(object sender, EventArgs e)
	{     
           Navigation.PushAsync(new HomePage());
       
    }
    private void OnSkipClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            SkipBtn.Text = $"Clicked {count} time";
        else
            SkipBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(SkipBtn.Text);
    }

}

