using Newtonsoft.Json;
using System;
using System.IO;

namespace WeatherWebApp_Console_.OpenWeather
{
    class Weather
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("main")]
        public string Main;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("icon")]
        public string IconId;

        public string Icon;
    }
}
