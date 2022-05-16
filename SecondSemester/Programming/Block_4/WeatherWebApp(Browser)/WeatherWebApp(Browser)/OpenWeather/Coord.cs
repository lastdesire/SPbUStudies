using Newtonsoft.Json;

namespace WeatherWebApp_Browser_.OpenWeather
{
    class Coord
    {
        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("lat")]
        public double Lat;
    }
}
