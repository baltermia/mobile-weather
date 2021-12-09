using Xamarin.Forms;
using MobileWeather.Services;
using MobileWeather.Pages;

namespace MobileWeather
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<LocationService>();
            MainPage = new NavigationPage(new WeatherPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
