using System;
using System.Threading.Tasks;

namespace WeatherWebApp_Console_
{
    enum WeatherVariables
    {
        MainWeather,
        WeatherDescription,
        AverageTemp,
        WindSpeed,
        WindDirection,
        CurrTime,
        Correlation,
        Weather

    }

    public class Weather
    {
        public string[] WeatherInfo = new string[8];

        public async Task<string[]> GetWeather()
        {
            //API keys
            var oWUrl = "https://api.openweathermap.org/data/2.5/weather?id=498817&appid=741efa4783085ff52c374bcd9d5b8ce6";
            var wAUrl = "http://api.weatherapi.com/v1/current.json?key=d53b823ad1374774be4130634221505&q=Saint&aqi=yes";
            var wIUrl = "https://api.weatherbit.io/v2.0/current?lat=59.9342&lon=30.3350&key=2457bd232f554f64a7d7028f1f035639&include=minutely";
            
            var oW = Response<OpenWeather.OpenWeather>.GetResponse(oWUrl).Result;
            var wA = Response<WeatherApi.WeatherApi>.GetResponse(wAUrl).Result;
            var wI = Response<WeatherbitIo.WeatherbitIo>.GetResponse(wIUrl).Result;
            
            WeatherInfo[(int)WeatherVariables.MainWeather] = String.Copy(oW.Weather[0].Main);

            WeatherInfo[(int)WeatherVariables.WeatherDescription] = "(" + oW.Weather[0].Description + ")";

            WeatherInfo[(int)WeatherVariables.AverageTemp] = "Average temp: " + "OW: " + oW.Main.Temp.ToString("0.##") + "° " + "WA: " + wA.current.temp_c + "° " + "WI: " + wI.data[0].temp + "° ";

            WeatherInfo[(int)WeatherVariables.WindSpeed] = "Speed: " + oW.Wind.Speed.ToString() + " (m/s)";

            WeatherInfo[(int)WeatherVariables.WindDirection] = String.Copy("Direction: " + oW.Wind.Deg.ToString());
            
            WeatherInfo[(int)WeatherVariables.CurrTime] = String.Copy(wA.location.localtime);

            WeatherInfo[(int)WeatherVariables.Correlation] = (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##") + "° ";
            
            return WeatherInfo;
        }
    }
}
