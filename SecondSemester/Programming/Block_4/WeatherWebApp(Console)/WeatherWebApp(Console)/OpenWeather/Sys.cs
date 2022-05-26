using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Sys
    {
        public Sys()
        {
            Type = 0;
            Id = 0;
            Country = string.Empty;
            Sunrise = 0;
            Sunset = 0;
        }

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
