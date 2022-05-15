using System;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace WeatherWindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //-----STARTOPENWEATHERSITE-----//
            var openWeatherRequest = WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?id=498817&appid=741efa4783085ff52c374bcd9d5b8ce6");
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

            OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(openWeatherAnswer);
            //-----ENDOPENWEATHERSITE-----//

            //-----STARTWEATHERAPISITE-----//
            var weatherApiRequest = WebRequest.Create("http://api.weatherapi.com/v1/current.json?key=d53b823ad1374774be4130634221505&q=Saint&aqi=yes");
            weatherApiRequest.Method = "POST";
            weatherApiRequest.ContentType = "application/x-www-urlencoded";

            var weatherApiResponse = await weatherApiRequest.GetResponseAsync();

            var weatherApiAnswer = string.Empty;

            using (Stream s = weatherApiResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    weatherApiAnswer = await reader.ReadToEndAsync();
                }
            }

            weatherApiResponse.Close();

            WeatherApi.WeatherApi wA = JsonConvert.DeserializeObject<WeatherApi.WeatherApi>(weatherApiAnswer);
            //-----ENDWEATHERAPISITE-----//

            //-----STARTWEATHERBIT-----//
            var weatherbitIoRequest = WebRequest.Create("https://api.weatherbit.io/v2.0/current?lat=59.9342&lon=30.3350&key=2457bd232f554f64a7d7028f1f035639&include=minutely");
            weatherbitIoRequest.Method = "POST";
            weatherbitIoRequest.ContentType = "application/x-www-urlencoded";

            var weatherbitIoResponse = await weatherbitIoRequest.GetResponseAsync();

            var weatherbitIoAnswer = string.Empty;

            using (Stream s = weatherbitIoResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    weatherbitIoAnswer = await reader.ReadToEndAsync();
                }
            }

            weatherbitIoResponse.Close();

            WeatherbitIo.WeatherbitIo wI = JsonConvert.DeserializeObject<WeatherbitIo.WeatherbitIo>(weatherbitIoAnswer);
            //-----ENDTOMORROWIOSITE-----//

            panel1.BackgroundImage = oW.Weather[0].Icon;

            label6.Text = oW.Weather[0].Main;

            label2.Text = "(" + oW.Weather[0].Description + ")";

            label3.Text = "Average temp: " + "OW: " + oW.Main.Temp.ToString("0.##") + "° " + "WA: " + wA.current.temp_c + "° " + "WI: " + wI.data[0].temp + "° ";

            label4.Text = "Speed: " + oW.Wind.Speed.ToString() + " (m/s)";

            label5.Text = "Direction: " + oW.Wind.Deg.ToString();

            label8.Text = wA.location.localtime;

            label10.Text = (0.507 * wA.current.temp_c + 0.482 * wI.data[0].temp).ToString("0.##") + "° ";

            chart1.Series[0].Points.AddXY(wA.location.localtime.Substring(11, 5), oW.Main.Temp.ToString("0.##"));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}
