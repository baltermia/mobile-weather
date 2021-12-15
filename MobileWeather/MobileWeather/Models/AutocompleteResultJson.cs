using Newtonsoft.Json;
using System.Collections.Generic;

namespace MobileWeather.Models
{
    public class AutocompleteResultJson
    {
        [JsonProperty("predictions")]
        public IEnumerable<AutocompleteResult> AutocompleteResults { get; set; }
    }
}
