using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Clouds
    {
        public Clouds()
        {
            All = 0;
        }

        [JsonProperty("all")]
        public double All;
    }
}
