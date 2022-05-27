using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
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
