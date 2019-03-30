using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shine.Models;
using Shine.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Shine
{
    public partial class MainPage : ContentPage
    {
        private readonly OpenWeatherMapService _openWeatherMapService;
        private readonly IBrightnessService _brightnessService;

        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            _openWeatherMapService = new OpenWeatherMapService();

            _brightnessService = DependencyService.Get<IBrightnessService>();
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync() ?? await Geolocation.GetLocationAsync(new GeolocationRequest());

                var requestUri = GenerateRequestUri(Constants.OpenWeatherMapEndpoint, location.Latitude, location.Longitude);
                var weatherData = await _openWeatherMapService.GetWeatherData(requestUri);

                _brightnessService.SetBrightness(1f);
                BindingContext = weatherData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving weather information: {ex.Message}");
            }
 
        }

        string GenerateRequestUri(string endpoint, double lat, double lon)
        {
            string requestUri = endpoint;
            requestUri += $"?lat={lat}&lon={lon}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
