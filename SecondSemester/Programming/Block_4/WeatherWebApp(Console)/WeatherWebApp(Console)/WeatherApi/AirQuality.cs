using Newtonsoft.Json;

namespace WeatherWebApp_Console_.WeatherApi
{
    class AirQuality
    {
        public double co;

        public double no2;

        public double o3;

        public double so2;

        public double pm2_5;

        public double pm10;

        [JsonProperty("us-epa-index")]
        public int us_epa_index;

        [JsonProperty("gb-defra-index")]
        public int gb_defra_index;
    }
}
