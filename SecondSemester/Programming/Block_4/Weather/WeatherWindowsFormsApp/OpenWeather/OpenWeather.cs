using Newtonsoft.Json;

namespace WeatherWindowsFormsApp.OpenWeather
{
    class OpenWeather
    {
        public OpenWeather()
        {
            Coord = new Coord();
            Weather = new Weather[1];
            Weather[0] = new Weather();
            Base = string.Empty;
            Main = new Main();
            Visibility = 0;
            Wind = new Wind();
            Clouds = new Clouds();
            Dt = 0;
            Sys = new Sys();
            Timezone = 0;
            Id = 0;
            Name = string.Empty;
            Cod = 0;
        }

        [JsonProperty("coord")]
        public Coord Coord;

        [JsonProperty("weather")]
        public Weather[] Weather;

        [JsonProperty("base")]
        public string Base;

        [JsonProperty("main")]
        public Main Main;

        [JsonProperty("visibility")]
        public double Visibility;

        [JsonProperty("wind")]
        public Wind Wind;

        [JsonProperty("clouds")]
        public Clouds Clouds;

        [JsonProperty("dt")]
        public double Dt;

        [JsonProperty("sys")]
        public Sys Sys;

        [JsonProperty("timezone")]
        public double Timezone;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("cod")]
        public double Cod;
    }
}

// Example of response from OpenWeather
/* 
{
!-----"coord":{"lon":30.2642,"lat":59.8944},
!-----"weather":[{"id":800,"main":"Clear","description":"clear sky","icon":"01n"}],
!-----"base":"stations",
!-----"main":{"temp":283.58,"feels_like":282.45,"temp_min":283.18,"temp_max":284.23,"pressure":999,"humidity":68},
!-----"visibility":10000,
!-----"wind":{"speed":5,"deg":280},
!-----"clouds":{"all":0},
!-----"dt":1652468233,
!-----"sys":{"type":2,"id":197864,"country":"RU","sunrise":1652405229,"sunset":1652466213},
!-----"timezone":10800,
!-----"id":498817,
!-----"name":"Saint Petersburg",
!-----"cod :200
}
*/