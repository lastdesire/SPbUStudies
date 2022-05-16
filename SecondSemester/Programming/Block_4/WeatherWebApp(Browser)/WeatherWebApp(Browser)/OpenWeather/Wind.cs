using Newtonsoft.Json;

namespace WeatherWebApp_Browser_.OpenWeather
{
    class Wind
    {
        [JsonProperty("speed")]
        public double Speed;

        [JsonProperty("deg")]
        public double Deg;
    }
}
