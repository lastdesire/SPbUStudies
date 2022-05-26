using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Wind
    {
        public Wind()
        {
            Speed = 0;
            Deg = 0;
        }

        [JsonProperty("speed")]
        public double Speed;

        [JsonProperty("deg")]
        public double Deg;
    }
}
