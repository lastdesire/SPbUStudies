namespace WeatherWindowsFormsApp.WeatherApi
{
    class WeatherApi
    {
        public WeatherApi()
        {
            location = new Location();
            current = new Current();
        }
        public Location location;

        public Current current;
    }
}

// Example of response from WeatherApi
/*
{
    "location": {
        "name": "Saint Petersburg",
        "region": "Saint Petersburg City",
        "country": "Russia",
        "lat": 59.89,
        "lon": 30.26,
        "tz_id": "Europe/Moscow",
        "localtime_epoch": 1652620267,
        "localtime": "2022-05-15 16:11"
    },
    "current": {
        "last_updated_epoch": 1652616000,
        "last_updated": "2022-05-15 15:00",
        "temp_c": 11.0,
        "temp_f": 51.8,
        "is_day": 1,
        "condition": {
            "text": "Overcast",
            "icon": "//cdn.weatherapi.com/weather/64x64/day/122.png",
            "code": 1009
        },
        "wind_mph": 19.2,
        "wind_kph": 31.0,
        "wind_degree": 290,
        "wind_dir": "WNW",
        "pressure_mb": 1005.0,
        "pressure_in": 29.68,
        "precip_mm": 0.0,
        "precip_in": 0.0,
        "humidity": 54,
        "cloud": 100,
        "feelslike_c": 8.8,
        "feelslike_f": 47.8,
        "vis_km": 10.0,
        "vis_miles": 6.0,
        "uv": 2.0,
        "gust_mph": 14.3,
        "gust_kph": 23.0,
        "air_quality": {
            "co": 220.3000030517578,
            "no2": 5.400000095367432,
            "o3": 75.80000305175781,
            "so2": 4.699999809265137,
            "pm2_5": 0.699999988079071,
            "pm10": 1.0,
            "us-epa-index": 1,
            "gb-defra-index": 1
        }
    }
}
 */