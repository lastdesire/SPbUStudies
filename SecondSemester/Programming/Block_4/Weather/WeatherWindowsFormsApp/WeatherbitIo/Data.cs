using System;

namespace WeatherWindowsFormsApp.WeatherbitIo
{
    internal class Data
    {

        public Data()
        {
            wind_cdir = string.Empty;
            rh = 0;
            pod = string.Empty;
            lon = 0;
            pres = 0;
            timezone = string.Empty;
            ob_time = string.Empty;
            country_code = string.Empty;
            clouds = 0;
            vis = 0;
            wind_spd = 0;
            wind_cdir_full = string.Empty;
            app_temp = 0;
            state_code = string.Empty;
            ts = 0;
            h_angle = 0;
            dewpt = 0;
            weather = new Weather();
            uv = string.Empty;
            aqi = 0;
            station = string.Empty;
            wind_dir = 0;
            elev_angle = 0;
            datetime = string.Empty;
            precip = 0;
            ghi = 0;
            dni = 0;
            dhi = 0;
            solar_rad = 0;
            city_name = string.Empty;
            sunrise = string.Empty;
            sunset = string.Empty;
            temp = 0;
            lat = 0;
            slp = 0;
        }
        public string wind_cdir;
        public double rh;
        public string pod;
        public double lon;
        public double pres;
        public string timezone;
        public string ob_time;
        public string country_code;
        public double clouds;
        public double vis;
        public double wind_spd;
        public string wind_cdir_full;
        public double app_temp;
        public string state_code;
        public Int64 ts;
        public double h_angle;
        public double dewpt;
        public Weather weather;
        public string uv;
        public int aqi;
        public string station;
        public double wind_dir;
        public double elev_angle;
        public string datetime;
        public int precip;
        public double ghi;
        public double dni;
        public double dhi;
        public double solar_rad;
        public string city_name;
        public string sunrise;
        public string sunset;
        public double temp;
        public double lat;
        public double slp;
    }
}
