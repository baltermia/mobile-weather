using Newtonsoft.Json;
using System.Collections.Generic;

namespace MobileWeather.Models
{
    public class OpenWeatherResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<Weather> WeatherList { get; set; }

        [JsonProperty("main")]
        public Temperature Temperature { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string IconId { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("temp")]
        public double Main { get; set; }
    }
}
