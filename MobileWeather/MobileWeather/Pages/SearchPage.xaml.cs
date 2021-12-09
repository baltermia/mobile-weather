using MobileWeather.Services;
using MobileWeather.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileWeather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private readonly LocationService _service;
        public SearchPage()
        {
            InitializeComponent();

            _service = DependencyService.Get<LocationService>();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _service.CurrentLocation = new Location()
            {
                Name = sbrSearch.Text
            };
        }
    }
}