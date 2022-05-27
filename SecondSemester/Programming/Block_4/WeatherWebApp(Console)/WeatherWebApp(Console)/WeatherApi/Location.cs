using System;

namespace WeatherWebApp_Console_.WeatherApi
{
    class Location
    {
        public Location()
        {
            name = string.Empty;
            region = string.Empty;
            country = string.Empty;
            lat = 0;
            lon = 0;
            tz_id = string.Empty;
            localtime_epoch = 0;
            localtime = "                    ";
        }

        public string name;

        public string region;

        public string country;

        public double lat;

        public double lon;

        public string tz_id;

        public Int64 localtime_epoch;

        public string localtime;
    }
}
