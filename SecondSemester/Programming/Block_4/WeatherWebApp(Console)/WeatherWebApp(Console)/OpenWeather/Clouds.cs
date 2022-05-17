using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Clouds
    {
        [JsonProperty("all")]
        public double All;
    }
}
