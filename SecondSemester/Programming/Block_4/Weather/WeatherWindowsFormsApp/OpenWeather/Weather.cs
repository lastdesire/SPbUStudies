using Newtonsoft.Json;
using System.Drawing;
using System.IO;

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

        // Icon should be in folder, where you run application.
        // If it is debug, you should upload folder Icons in folder Debug.
        // If it is release, upload It in Release.
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
