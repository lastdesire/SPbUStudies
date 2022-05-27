
using System;

using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web.UI;
using System.Drawing;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WeatherWebApp_Browser_
{
    public partial class _Default : Page
    {
        public  void Page_Load(object sender, EventArgs e)
        {
            OpenWeather.OpenWeather oW = new OpenWeather.OpenWeather();
            WeatherApi.WeatherApi wA = new WeatherApi.WeatherApi();
            WeatherbitIo.WeatherbitIo wI = new WeatherbitIo.WeatherbitIo();

            try
            {
                var oWUrl = "https://api.openweathermap.org/data/2.5/weather?id=498817&appid=741efa4783085ff52c374bcd9d5b8ce6";

                oW = ResponseGetter<OpenWeather.OpenWeather>.GetResponse(oWUrl);
            }
            catch (Exception)
            {
                errorLabel.Text = ("Attention. Data is no correct. No response from OpenWeather.");
            }

            try
            {
                var wAUrl = "http://api.weatherapi.com/v1/current.json?key=d53b823ad1374774be4130634221505&q=Saint&aqi=yes";
                wA = ResponseGetter<WeatherApi.WeatherApi>.GetResponse(wAUrl);
            }
            catch (Exception)
            {
                errorLabel.Text = ("Attention. Data is no correct. No response from WeatherApi.");
            }

            try
            {
                var wIUrl = "https://api.weatherbit.io/v2.0/current?lat=59.9342&lon=30.3350&key=2457bd232f554f64a7d7028f1f035639&include=minutely";
                wI = ResponseGetter<WeatherbitIo.WeatherbitIo>.GetResponse(wIUrl);
            }
            catch (Exception)
            {
                errorLabel.Text = ("Attention. Data is no correct. No response from WeatherbitIo.");
            }

            Panel2.BackImageUrl = "https://1.bp.blogspot.com/-YPDHQ-mvAh0/XjWGiYVsYqI/AAAAAAAA7KU/YjyTdBlRJ08l6iyfBABWD9tRnlW0hCaSwCPcBGAYYCw/w400-h288/cloud-sun-psd-406885.png";

            weatherMain.Text = oW.Weather[0].Main;
            
            weatherDescription.Text = "(" + oW.Weather[0].Description + ")";

            averageTemp.Text = "Average temp: " + "OW: " + oW.Main.Temp.ToString("0.##") + "° " + "WA: " + wA.current.temp_c + "° " + "WI: " + wI.data[0].temp + "° ";

            windSpeed.Text = "Speed: " + oW.Wind.Speed.ToString() + " (m/s)";

            direction.Text = "Direction: " + oW.Wind.Deg.ToString();

            localtime.Text = wA.location.localtime;

            regression.Text = (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##") + "° ";
            
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }
    }
}
