using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class Weather
    {
        public Weather()
        {
            Id = 0;
            Main = string.Empty;
            Description = string.Empty;
            IconId = string.Empty;
        }

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
                try
                {
                    return new Bitmap(Image.FromFile($"Icons/{IconId}.png"));
                }
                catch (FileNotFoundException e)
                {
                    return null;
                }
            }
        }

    }
}
