using Newtonsoft.Json;
using System.Drawing;

namespace WeatherWindowsFormsApp.OpenWeather
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

        public Bitmap Icon
        {
            get
            {
                return new Bitmap(Image.FromFile($"../../../Icons/{IconId}.png"));
            }
        }
    }
}
