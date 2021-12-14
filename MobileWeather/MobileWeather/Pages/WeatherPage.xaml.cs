using MobileWeather.Services;
using MobileWeather.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

using ModelLocation = MobileWeather.Models.Location;
using XamarinLocation = Xamarin.Essentials.Location;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace MobileWeather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        private readonly LocationService _service;
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
                Address = mark.Thoroughfare,
                Area = mark.SubLocality,
                City = mark.Locality,
                Zip = mark.PostalCode,
                State = mark.AdminArea,
                Country = mark.CountryName
            };

            _service.CurrentLocation = location;
        }

        private void OnLocationChanged_Handler(object sender, LocationChangedEventArgs e)
        {
            lblLocation.Text = e.Location.City;
        }
    }
}