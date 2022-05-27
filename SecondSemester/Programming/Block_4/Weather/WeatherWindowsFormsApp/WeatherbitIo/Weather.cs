using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherWindowsFormsApp.WeatherbitIo
{
    internal class Weather
    {
        public Weather()
        {
            icon = string.Empty;
            code = 0;
            description = string.Empty;
        }

        public string icon;
        public int code;
        public string description;
    }
}
