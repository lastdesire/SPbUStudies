using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace WeatherWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            panel1.BackgroundImage = oW.Weather[0].Icon;

            mainWeather.Text = oW.Weather[0].Main;

            weatherDescription.Text = "(" + oW.Weather[0].Description + ")";

            averageTemp.Text = "Average temp: " + "OW: " + oW.Main.Temp.ToString("0.##") + "° " + "WA: " + wA.current.temp_c + "° " + "WI: " + wI.data[0].temp + "° ";

            windSpeed.Text = "Speed: " + oW.Wind.Speed.ToString() + " (m/s)";

            windDirection.Text = "Direction: " + oW.Wind.Deg.ToString();

            currTime.Text = wA.location.localtime;

            regression.Text = (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##") + "° ";

            temperatureChart.Series[0].Points.AddXY(wA.location.localtime.Substring(11), oW.Main.Temp.ToString("0.##"));

            temperatureChart.Series[1].Points.AddXY(wA.location.localtime.Substring(11), (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##"));


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }

    public class Response<T>
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