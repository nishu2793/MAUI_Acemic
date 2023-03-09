using DocumentFormat.OpenXml.Bibliography;

namespace AceMicEV.Views;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();

    }

    protected async override void OnAppearing()
    {
        await GetCurrentLocation();
    }

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
   
    public async Task GetCurrentLocation()
    {
        try 
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Latitude: {location.Latitude}");

            DisplayAlert("Location", location. Longitude .ToString()  +   "Latitude"   +  location. Latitude .ToString(),"Ok");
        
        }
       
        catch (Exception ex)    
        {

        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

}