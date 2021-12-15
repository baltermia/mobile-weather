using MobileWeather.Services;
using MobileWeather.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using MobileWeather.ViewModels;
using RestSharp;
using Newtonsoft.Json;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System;

namespace MobileWeather.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private readonly LocationService _service;

        private readonly RestClient client = new RestClient("https://maps.googleapis.com/maps/api/place/autocomplete/json");
        private readonly string apiKey = Data.Secrets.GooglePlacesAPI;

        public SearchPage()
        {
            InitializeComponent();

            _service = DependencyService.Get<LocationService>();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            RestRequest request = GetDefaultRequest();
            request.AddParameter("input", sbrSearch.Text);

            IRestResponse response = client.Execute(request);

            AutocompleteResultJson jsonResult = JsonConvert.DeserializeObject<AutocompleteResultJson>(response.Content);

            lstResults.ItemsSource = new ObservableCollection<LocationItem>(jsonResult.AutocompleteResults.Select(r => new LocationItem()
            {
                Location = r.Details.Main,
                Details = r.Details.Secondary
            }));
        }

        private async void Locations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            LocationItem location = e.Item as LocationItem;

            _service.CurrentLocation = new Location()
            {
                City = location.Location
            };

            await Navigation.PopAsync();
        }

        private RestRequest GetDefaultRequest(Method method = Method.GET)
        {
            RestRequest request = new RestRequest(method);

            request.AddParameter("types", "(cities)");
            request.AddParameter("key", apiKey);

            return request;

        }
    }
}