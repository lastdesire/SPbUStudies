using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
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
