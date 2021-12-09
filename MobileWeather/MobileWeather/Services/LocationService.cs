using MobileWeather.Models;

namespace MobileWeather.Services
{
    public class LocationService
    {
        private Location _location;

        public delegate void LocationChangedEventHandler(object sender, LocationChangedEventArgs e);
        public event LocationChangedEventHandler OnLocationChanged;

        public Location CurrentLocation
        {
            get => _location;

            set
            {
                _location = value;

                OnLocationChanged?.Invoke(this, new LocationChangedEventArgs(_location));
            }
        }
    }
}
