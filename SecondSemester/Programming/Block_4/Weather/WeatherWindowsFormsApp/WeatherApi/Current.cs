using System;

namespace WeatherWindowsFormsApp.WeatherApi
{
    class Current
    {
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
