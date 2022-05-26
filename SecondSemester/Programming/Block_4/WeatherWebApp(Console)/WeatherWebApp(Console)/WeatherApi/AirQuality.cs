using Newtonsoft.Json;

namespace WeatherWebApp_Console_.WeatherApi
{
    class AirQuality
    {
        public AirQuality()
        {
            co = 0;
            no2 = 0;
            o3 = 0;
            so2 = 0;
            pm2_5 = 0;
            pm10 = 0;
            us_epa_index = 0;
            gb_defra_index = 0;
        }

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
