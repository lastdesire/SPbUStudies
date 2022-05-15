using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class Coord
    {
        [JsonProperty("lon")]
        public double Lon;

        [JsonProperty("lat")]
        public double Lat;
    }
}
