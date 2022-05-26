using System;

namespace WeatherWebApp_Console_.WeatherApi
{
    class Current
    {
        public Current()
        {
            last_updated_epoch = 0;

            last_updated = string.Empty;

            temp_c = 0;

            temp_f = 0;

            is_day = true;

            condition = new Condition();

            wind_mph = 0;

            wind_kph = 0;

            wind_degree = 0;

            wind_dir = string.Empty;

            pressure_mb = 0;

            pressure_in = 0;

            precip_mm = 0;

            precip_in = 0;

            humidity = 0;

            cloud = 0;

            feelslike_c = 0;

            feelslike_f = 0;

            vis_km = 0;

            vis_miles = 0;

            uv = 0;

            gust_mph = 0;

            gust_kph = 0;

            air_quality = new AirQuality();
    
        }

        public Int64 last_updated_epoch;

        public string last_updated;

        public double temp_c;

        public double temp_f;

        public bool is_day;

        public Condition condition;

        public double wind_mph;

        public double wind_kph;

        public int wind_degree;

        public string wind_dir;

        public double pressure_mb;

        public double pressure_in;

        public double precip_mm;

        public double precip_in;

        public double humidity;

        public double cloud;

        public double feelslike_c;

        public double feelslike_f;

        public double vis_km;

        public double vis_miles;

        public double uv;

        public double gust_mph;

        public double gust_kph;

        public AirQuality air_quality;
    }
}
