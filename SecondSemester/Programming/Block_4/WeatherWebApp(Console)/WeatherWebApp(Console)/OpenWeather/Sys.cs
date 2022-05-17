using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Sys
    {
        [JsonProperty("type")]
        public double Type;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("country")]
        public string Country;

        [JsonProperty("sunrise")]
        public double Sunrise;

        [JsonProperty("sunset")]
        public double Sunset;
    }
}
