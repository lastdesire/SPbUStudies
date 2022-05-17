using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Coord
    {
        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("lat")]
        public double Lat;
    }
}
