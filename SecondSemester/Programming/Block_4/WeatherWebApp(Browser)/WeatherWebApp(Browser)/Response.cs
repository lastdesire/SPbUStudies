using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WeatherWebApp_Browser_
{
    static class ResponseGetter<T>
    {
        public static T GetResponse(string url)
        {
            var weatherRequest = WebRequest.Create(url);
            weatherRequest.Method = "POST";
            weatherRequest.ContentType = "application/x-www-urlencoded";

            var weatherResponse =  weatherRequest.GetResponse();

            var weatherAnswer = string.Empty;

            using (Stream s = weatherResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    weatherAnswer =  reader.ReadToEnd();
                }
            }

            weatherResponse.Close();

            T result = JsonConvert.DeserializeObject<T>(weatherAnswer);

            return result;
        }
    }
}