using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WeatherWebApp_Console_
{
    static class Response<T>
    {
        public static async Task<T> GetResponse(string url)
        {
            var openWeatherRequest = WebRequest.Create(url);
            openWeatherRequest.Method = "POST";
            openWeatherRequest.ContentType = "application/x-www-urlencoded";

            var openWeatherResponse = await openWeatherRequest.GetResponseAsync();

            var openWeatherAnswer = string.Empty;

            using (Stream s = openWeatherResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    openWeatherAnswer = await reader.ReadToEndAsync();
                }
            }

            openWeatherResponse.Close();

            T oW = JsonConvert.DeserializeObject<T>(openWeatherAnswer);

            return oW;
        }
    }
}
