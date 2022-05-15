using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class Main
    {
        private double _temp;

        [JsonProperty("temp")]
        public double Temp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value - 273.15; // From kelvin to celsius.
            }
        }

        private double _feels_like;

        [JsonProperty("feels_like")]
        public double Feels_Like
        {
            get
            {
                return _feels_like;
            }
            set
            {
                _feels_like = value - 273.15; // From kelvin to celsius.
            }
        }

        private double _temp_min;

        [JsonProperty("temp_min")]
        public double Temp_min
        {
            get
            {
                return _temp_min;
            }
            set
            {
                _temp_min = value - 273.15; // From kelvin to celsius.
            }
        }

        private double _temp_max;

        [JsonProperty("temp_max")]
        public double Temp_max
        {
            get
            {
                return _temp_max;
            }
            set
            {
                _temp_max = value - 273.15; // From kelvin to celsius.
            }
        }

        private double _pressure;

        [JsonProperty("pressure")]
        public double Pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                _pressure = value / 1.3332239;
            }
        }

        [JsonProperty("humidity")]
        public double Humidity;
    }
}
