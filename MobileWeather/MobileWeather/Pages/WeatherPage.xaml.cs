using MobileWeather.Services;
using MobileWeather.Models;
using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using ModelLocation = MobileWeather.Models.Location;
using XamarinLocation = Xamarin.Essentials.Location;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MobileWeather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        private readonly LocationService _service;
        private readonly RestClient client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
        private readonly string apiKey = Data.Secrets.OpenWeatherAPI;

        public WeatherPage()
        {
            InitializeComponent();

            _service = DependencyService.Get<LocationService>();
            _service.OnLocationChanged += OnLocationChanged_Handler;
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());
        }

        private async void GPS_Clicked(object sender, EventArgs e)
        {
            XamarinLocation geo = await Geolocation.GetLastKnownLocationAsync();

            IEnumerable<Placemark> placemarks = await Geocoding.GetPlacemarksAsync(Math.Round(geo.Latitude, 3), Math.Round(geo.Longitude, 3));

            Placemark mark = placemarks?.FirstOrDefault();
            
            ModelLocation location = new ModelLocation()
            {
                City = mark.Locality
            };

            _service.CurrentLocation = location;
        }

        private async void OnLocationChanged_Handler(object sender, LocationChangedEventArgs e)
        {
            ModelLocation location = e.Location;

            lblLocation.Text = location.City;

            RestRequest request = GetDefaultRequest();
            
            request.AddParameter("q", location.City);
            IRestResponse response = await client.ExecuteAsync(request);

            OpenWeatherResponse weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(response.Content);

            lblWeather.Text = weather.WeatherList.FirstOrDefault()?.Description;
            lblTemperature.Text = Math.Round(weather.Temperature.Main).ToString() + "°";
        }

        private RestRequest GetDefaultRequest(Method method = Method.GET)
        {
            RestRequest request = new RestRequest(method);

            request.AddParameter("appid", apiKey);
            request.AddParameter("units", "metric");

            return request;
        }
    }
}