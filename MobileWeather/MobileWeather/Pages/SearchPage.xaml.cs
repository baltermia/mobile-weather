using MobileWeather.Services;
using MobileWeather.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using MobileWeather.ViewModels;

namespace MobileWeather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private readonly LocationService _service;

        private readonly ObservableCollection<LocationItem> Locations = new ObservableCollection<LocationItem>();

        public SearchPage()
        {
            InitializeComponent();

            _service = DependencyService.Get<LocationService>();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Locations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            LocationItem location = e.Item as LocationItem;

            _service.CurrentLocation = location.LocationObject;
        }
    }
}