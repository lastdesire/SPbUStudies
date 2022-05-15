using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class Clouds
    {
        [JsonProperty("all")]
        public double All;
    }
}
