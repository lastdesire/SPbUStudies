using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class Wind
    {
        [JsonProperty("speed")]
        public double Speed;

        [JsonProperty("deg")]
        public double Deg;
    }
}
