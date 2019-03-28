using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherForecastWPF_Version_1_0
{
    class WeatherForecastViewModel
    {
        public string getWeatherService(string APPID, string latitude, string longitude)
        {
            WebClient web = new WebClient();
            string url = string.Format("https://api.darksky.net/forecast/{0}/{1},{2}", APPID, latitude, longitude);
            string json = web.DownloadString(url);
            return json;
        }

        public string getWeatherForecastService(string APPID, string latitude, string longitude)
        {
            WebClient web = new WebClient();
            string url = string.Format("https://api.darksky.net/forecast/{0}/{1},{2}", APPID, latitude, longitude);
            string json = web.DownloadString(url);
            return json;
        }
    }
}
