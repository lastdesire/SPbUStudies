using Newtonsoft.Json;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Coord
    {
        public Coord()
        {
            Lon = 0;
            Lat = 0;
        }
        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("lat")]
        public double Lat;
    }
}
