using MobileWeather.Services;
using MobileWeather.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void GPS_Clicked(object sender, EventArgs e)
        {

        }

        private void OnLocationChanged_Handler(object sender, LocationChangedEventArgs e)
        {
            lblLocation.Text = e.Location.Name;
        }
    }
}