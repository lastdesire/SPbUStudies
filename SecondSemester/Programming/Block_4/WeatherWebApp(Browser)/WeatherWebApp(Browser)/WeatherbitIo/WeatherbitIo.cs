using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWebApp_Browser_.WeatherbitIo
{
    class WeatherbitIo
    {
        public Data[] data;
        public Minutely[] minutely;
        public int count;

    }
}


//

/* 
{  
               "data":[  
                  {  
                     "wind_cdir":"NE",
                     "rh":59,
                     "pod":"d",
                     "lon":"-78.63861",
                     "pres":1006.6,
                     "timezone":"America\/New_York",
                     "ob_time":"2017-08-28 16:45",
                     "country_code":"US",
                     "clouds":75,
                     "vis":10,
                     "wind_spd":6.17,
                     "wind_cdir_full":"northeast",
                     "app_temp":24.25,
                     "state_code":"NC",
                     "ts":1503936000,
                     "h_angle":0,
                     "dewpt":15.65,
                     "weather":{  
                        "icon":"c03d",
                        "code": 803,
                        "description":"Broken clouds"
                     },
                     "uv":2,
                     "aqi":45,
                     "station":"CMVN7",
                     "wind_dir":50,
                     "elev_angle":63,
                     "datetime":"2017-08-28:17",
                     "precip":0,
                     "ghi":444.4,
                     "dni":500,
                     "dhi":120,
                     "solar_rad":350,
                     "city_name":"Raleigh",
                     "sunrise":"10:44",
                     "sunset":"23:47",
                     "temp":24.19,
                     "lat":"35.7721",
                     "slp":1022.2
                  }
               ],
               "minutely":[ ... ],
               "count":1
}
 */



/*
 {"count":1,"data":[{"rh":46,"pod":"d","lon":30.34,"pres":1005.5,"timezone":"Europe\/Moscow","ob_time":"2022-05-15 14:37","country_code":"RU","clouds":75,"ts":1652625447,"solar_rad":246,"state_code":"66","city_name":"Saint Petersburg","wind_spd":9,"wind_cdir_full":"west-northwest","wind_cdir":"WNW","slp":1006,"vis":10,"h_angle":40,"sunset":"18:29","dni":698.96,"dewpt":0.7,"snow":0,"uv":1.20585,"precip":0,"wind_dir":300,"sunrise":"01:20","ghi":351.8,"dhi":81.6,"aqi":28,"lat":59.93,"weather":{"icon":"c03d","code":803,"description":"Broken clouds"},"datetime":"2022-05-15:14","temp":12,"station":"ULLI","elev_angle":23.32,"app_temp":12}],"minutely":[{"timestamp_utc":"2022-05-15T15:23:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:23:00","ts":1652628180,"precip":0},{"timestamp_utc":"2022-05-15T15:24:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:24:00","ts":1652628240,"precip":0},{"timestamp_utc":"2022-05-15T15:25:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:25:00","ts":1652628300,"precip":0},{"timestamp_utc":"2022-05-15T15:26:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:26:00","ts":1652628360,"precip":0},{"timestamp_utc":"2022-05-15T15:27:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:27:00","ts":1652628420,"precip":0},{"timestamp_utc":"2022-05-15T15:28:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:28:00","ts":1652628480,"precip":0},{"timestamp_utc":"2022-05-15T15:29:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:29:00","ts":1652628540,"precip":0},{"timestamp_utc":"2022-05-15T15:30:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:30:00","ts":1652628600,"precip":0},{"timestamp_utc":"2022-05-15T15:31:00","snow":0,"temp":11.1,"timestamp_local":"2022-05-15T18:31:00","ts":1652628660,"precip":0},{"timestamp_utc":"2022-05-15T15:32:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:32:00","ts":1652628720,"precip":0},{"timestamp_utc":"2022-05-15T15:33:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:33:00","ts":1652628780,"precip":0},{"timestamp_utc":"2022-05-15T15:34:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:34:00","ts":1652628840,"precip":0},{"timestamp_utc":"2022-05-15T15:35:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:35:00","ts":1652628900,"precip":0},{"timestamp_utc":"2022-05-15T15:36:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:36:00","ts":1652628960,"precip":0},{"timestamp_utc":"2022-05-15T15:37:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:37:00","ts":1652629020,"precip":0},{"timestamp_utc":"2022-05-15T15:38:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:38:00","ts":1652629080,"precip":0},{"timestamp_utc":"2022-05-15T15:39:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:39:00","ts":1652629140,"precip":0},{"timestamp_utc":"2022-05-15T15:40:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:40:00","ts":1652629200,"precip":0},{"timestamp_utc":"2022-05-15T15:41:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:41:00","ts":1652629260,"precip":0},{"timestamp_utc":"2022-05-15T15:42:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:42:00","ts":1652629320,"precip":0},{"timestamp_utc":"2022-05-15T15:43:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:43:00","ts":1652629380,"precip":0},{"timestamp_utc":"2022-05-15T15:44:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:44:00","ts":1652629440,"precip":0},{"timestamp_utc":"2022-05-15T15:45:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:45:00","ts":1652629500,"precip":0},{"timestamp_utc":"2022-05-15T15:46:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:46:00","ts":1652629560,"precip":0},{"timestamp_utc":"2022-05-15T15:47:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:47:00","ts":1652629620,"precip":0},{"timestamp_utc":"2022-05-15T15:48:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:48:00","ts":1652629680,"precip":0},{"timestamp_utc":"2022-05-15T15:49:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:49:00","ts":1652629740,"precip":0},{"timestamp_utc":"2022-05-15T15:50:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:50:00","ts":1652629800,"precip":0},{"timestamp_utc":"2022-05-15T15:51:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:51:00","ts":1652629860,"precip":0},{"timestamp_utc":"2022-05-15T15:52:00","snow":0,"temp":11,"timestamp_local":"2022-05-15T18:52:00","ts":1652629920,"precip":0},{"timestamp_utc":"2022-05-15T15:53:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:53:00","ts":1652629980,"precip":0},{"timestamp_utc":"2022-05-15T15:54:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:54:00","ts":1652630040,"precip":0},{"timestamp_utc":"2022-05-15T15:55:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:55:00","ts":1652630100,"precip":0},{"timestamp_utc":"2022-05-15T15:56:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:56:00","ts":1652630160,"precip":0},{"timestamp_utc":"2022-05-15T15:57:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:57:00","ts":1652630220,"precip":0},{"timestamp_utc":"2022-05-15T15:58:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:58:00","ts":1652630280,"precip":0},{"timestamp_utc":"2022-05-15T15:59:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T18:59:00","ts":1652630340,"precip":0},{"timestamp_utc":"2022-05-15T16:00:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:00:00","ts":1652630400,"precip":0},{"timestamp_utc":"2022-05-15T16:01:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:01:00","ts":1652630460,"precip":0},{"timestamp_utc":"2022-05-15T16:02:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:02:00","ts":1652630520,"precip":0},{"timestamp_utc":"2022-05-15T16:03:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:03:00","ts":1652630580,"precip":0},{"timestamp_utc":"2022-05-15T16:04:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:04:00","ts":1652630640,"precip":0},{"timestamp_utc":"2022-05-15T16:05:00","snow":0,"temp":10.9,"timestamp_local":"2022-05-15T19:05:00","ts":1652630700,"precip":0},{"timestamp_utc":"2022-05-15T16:06:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:06:00","ts":1652630760,"precip":0},{"timestamp_utc":"2022-05-15T16:07:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:07:00","ts":1652630820,"precip":0},{"timestamp_utc":"2022-05-15T16:08:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:08:00","ts":1652630880,"precip":0},{"timestamp_utc":"2022-05-15T16:09:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:09:00","ts":1652630940,"precip":0},{"timestamp_utc":"2022-05-15T16:10:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:10:00","ts":1652631000,"precip":0},{"timestamp_utc":"2022-05-15T16:11:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:11:00","ts":1652631060,"precip":0},{"timestamp_utc":"2022-05-15T16:12:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:12:00","ts":1652631120,"precip":0},{"timestamp_utc":"2022-05-15T16:13:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:13:00","ts":1652631180,"precip":0},{"timestamp_utc":"2022-05-15T16:14:00","snow":0,"temp":10.8,"timestamp_local":"2022-05-15T19:14:00","ts":1652631240,"precip":0},{"timestamp_utc":"2022-05-15T16:15:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:15:00","ts":1652631300,"precip":0},{"timestamp_utc":"2022-05-15T16:16:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:16:00","ts":1652631360,"precip":0},{"timestamp_utc":"2022-05-15T16:17:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:17:00","ts":1652631420,"precip":0},{"timestamp_utc":"2022-05-15T16:18:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:18:00","ts":1652631480,"precip":0},{"timestamp_utc":"2022-05-15T16:19:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:19:00","ts":1652631540,"precip":0},{"timestamp_utc":"2022-05-15T16:20:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:20:00","ts":1652631600,"precip":0},{"timestamp_utc":"2022-05-15T16:21:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:21:00","ts":1652631660,"precip":0},{"timestamp_utc":"2022-05-15T16:22:00","snow":0,"temp":10.7,"timestamp_local":"2022-05-15T19:22:00","ts":1652631720,"precip":0}]}
*/