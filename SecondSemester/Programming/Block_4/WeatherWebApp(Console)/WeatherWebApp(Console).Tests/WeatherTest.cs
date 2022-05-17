namespace WeatherWebApp_Console_.Tests
{
    public class WeatherTest
    {
        [Fact]
        public void TestWeatherInformation()
        {
            var weather = new Weather();
            var taskWeatherInfo = weather.GetWeather();
            var weatherInfo = taskWeatherInfo.Result;

            //Take information from here and compare.
            //Be sure that you changed expected strings.
            //https://openweathermap.org/city/498817
            
            Assert.Equal("(overcast clouds)", weatherInfo[(int)WeatherVariables.WeatherDescription]);

            // This is impossible to just take information from weatherapi.com or weatherbit.io, so compare this one with Internet data and data from openweathermap.org
            Assert.Equal("Average temp: OW: 7.81° WA: 8° WI: 8° ", weatherInfo[(int)WeatherVariables.AverageTemp]);

            Assert.Equal("Speed: 5 (m/s)", weatherInfo[(int)WeatherVariables.WindSpeed]);

            Assert.Equal("Direction: 340", weatherInfo[(int)WeatherVariables.WindDirection]);

            Assert.Equal("2022-05-17 21:02", weatherInfo[(int)WeatherVariables.CurrTime]);
        }
    }
}