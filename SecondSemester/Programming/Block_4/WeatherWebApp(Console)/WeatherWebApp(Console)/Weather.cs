using System;
using System.Threading.Tasks;

namespace WeatherWebApp_Console_
{
    public enum WeatherVariables
    {
        MainWeather,
        WeatherDescription,
        AverageTemp,
        WindSpeed,
        WindDirection,
        CurrTime,
        Regression,
        Weather

    }

    public class Weather
    {
        public string[] WeatherInfo = new string[8];

        public  string[] GetWeather()
        {
            OpenWeather.OpenWeather oW = new OpenWeather.OpenWeather();
            WeatherApi.WeatherApi wA = new WeatherApi.WeatherApi();
            WeatherbitIo.WeatherbitIo wI = new WeatherbitIo.WeatherbitIo();

            try
            {
                var oWUrl = "https://api.openweathermap.org/data/2.5/weather?id=498817&appid=741efa4783085ff52c374bcd9d5b8ce6";
                
                oW = Response<OpenWeather.OpenWeather>.GetResponse(oWUrl);
            }
            catch(Exception)
            {
                Console.WriteLine("Attention. Data is no correct. No response from OpenWeather.");
            }

            try
            {
                var wAUrl = "http://api.weatherapi.com/v1/current.json?key=d53b823ad1374774be4130634221505&q=Saint&aqi=yes";
                wA = Response<WeatherApi.WeatherApi>.GetResponse(wAUrl);
            }
            catch (Exception)
            {
                Console.WriteLine("Attention. Data is no correct. No response from WeatherApi.");
            }

            try
            {
                var wIUrl = "https://api.weatherbit.io/v2.0/current?lat=59.9342&lon=30.3350&key=2457bd232f554f64a7d7028f1f035639&include=minutely";
                wI = Response<WeatherbitIo.WeatherbitIo>.GetResponse(wIUrl);
            }
            catch (Exception)
            {
                Console.WriteLine("Attention. Data is no correct. No response from WeatherbitIo.");
            }

            
            WeatherInfo[(int)WeatherVariables.MainWeather] = oW.Weather[0].Main;

            WeatherInfo[(int)WeatherVariables.WeatherDescription] = "(" + oW.Weather[0].Description + ")";

            WeatherInfo[(int)WeatherVariables.AverageTemp] = "Average temp: " + "OW: " + oW.Main.Temp.ToString("0.##") + "° " + "WA: " + wA.current.temp_c + "° " + "WI: " + wI.data[0].temp + "° ";

            WeatherInfo[(int)WeatherVariables.WindSpeed] = "Speed: " + oW.Wind.Speed.ToString() + " (m/s)";

            WeatherInfo[(int)WeatherVariables.WindDirection] = "Direction: " + oW.Wind.Deg.ToString();
            
            WeatherInfo[(int)WeatherVariables.CurrTime] = wA.location.localtime;

            WeatherInfo[(int)WeatherVariables.Regression] = (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##") + "° ";
            
            return WeatherInfo;
        }
    }
}
