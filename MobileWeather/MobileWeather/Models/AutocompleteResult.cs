using Newtonsoft.Json;

namespace MobileWeather.Models
{
    public class AutocompleteResult
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("structured_formatting")]
        public AutocompleteResultDetails Details { get; set; }

        public class AutocompleteResultDetails
        {
            [JsonProperty("main_text")]
            public string Main { get; set; }

            [JsonProperty("secondary_text")]
            public string Secondary { get; set; }
        }
    }
}
