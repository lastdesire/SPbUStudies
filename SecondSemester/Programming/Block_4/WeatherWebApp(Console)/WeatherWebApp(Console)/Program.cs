using System;

namespace WeatherWebApp_Console_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var weather = new Weather();
            var taskWeatherInfo = weather.GetWeather();
            var weatherInfo = taskWeatherInfo;

            Console.WriteLine("Weather in Saint Petersburg:");

            Console.WriteLine(weatherInfo[(int)WeatherVariables.MainWeather]);

            Console.WriteLine(weatherInfo[(int)WeatherVariables.WeatherDescription]);

            Console.WriteLine(weatherInfo[(int)WeatherVariables.AverageTemp]);

            Console.WriteLine(weatherInfo[(int)WeatherVariables.WindSpeed]);

            Console.WriteLine(weatherInfo[(int)WeatherVariables.WindDirection]);

            Console.WriteLine(weatherInfo[(int)WeatherVariables.CurrTime]);

            Console.Write("Regression: ");
            Console.WriteLine(weatherInfo[(int)WeatherVariables.Regression]);

            Console.Read();
        }
    }
}
