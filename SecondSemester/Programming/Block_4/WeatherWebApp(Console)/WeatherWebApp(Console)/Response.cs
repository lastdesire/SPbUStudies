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
            var weatherRequest = WebRequest.Create(url);
            weatherRequest.Method = "POST";
            weatherRequest.ContentType = "application/x-www-urlencoded";

            var weatherResponse = await weatherRequest.GetResponseAsync();

            var weatherAnswer = string.Empty;

            using (Stream s = weatherResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    weatherAnswer = await reader.ReadToEndAsync();
                }
            }

            weatherResponse.Close();

            T result = JsonConvert.DeserializeObject<T>(weatherAnswer);

            return result;
        }
    }
}
