using MobileWeather.Models;

namespace MobileWeather.ViewModels
{
    public class LocationItem
    {
        public Location LocationObject { get; set; }

        public string Location { get; set; }
        public string Country { get; set; }
        public string County { get; set; }

        public string CountryCountyString => GetCountryCountyString();

        public string GetCountryCountyString()
        {
            return Country + ", " + County;
        }
    }
}
