namespace MobileWeather.ViewModels
{
    public class LocationItem
    {
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
