namespace MobileWeather.Models
{
    public class LocationChangedEventArgs
    {
        public Location Location { get; set; }

        public LocationChangedEventArgs(Location location)
        {
            Location = location;
        }
    }
}
