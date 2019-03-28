using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastWPF_Version_1_0
{
    class WeatherInfo
    {
    
        public class CurrentWeather
        {
            public long time { get; set; }
            public string summary { get; set; }
            public string icon { get; set; }
            public string showedIcon
            {
                get
                {
                    string returnIcon = "atmosphere.png";

                    if (icon == "partly-cloudy-day")
                    {
                        returnIcon = "few_clouds_day.png";
                    }
                    else if (icon == "partly-cloudy-night")
                    {
                        returnIcon = "few_clouds_night.png";
                    }
                    else if (icon == "clear-day")
                    {
                        returnIcon = "clear_day.png";
                    }
                    else if (icon == "clear-night")
                    {
                        returnIcon = "clear_night.png";
                    }
                    else if (icon == "wind")
                    {
                        returnIcon = "windy.png";
                    }
                    else if (icon == "cloudy")
                    {
                        returnIcon = "atmosphere.png";
                    }
                    else if (icon == "fog")
                    {
                        returnIcon = "cold.png";
                    }
                    else if (icon == "snow")
                    {
                        returnIcon = "snow.png";
                    }
                    return returnIcon;
                }
                set { }
            }
            public double precipIntensity { get; set; }
            public double precipProbability { get; set; }
            public double temperature { get; set; }
            public double temperatureCelsius
            {
                get
                {
                    return Math.Round((temperature - 32) * 5 / 9, 2);
                }
                set { }
            }
            public double apparentTemperature { get; set; }
            public double apparentTemperatureCelsius
            {
                get
                {
                    return Math.Round((apparentTemperature - 32) * 5 / 9, 2);
                }
                set { }
            }
            public double dewPoint { get; set; }
            public double humidity { get; set; }
            public double humidityPercent
            {
                get
                {
                    return humidity * 100;
                }
                set { }
            }
            public double pressure { get; set; }
            public double windSpeed { get; set; }
            public double windGust { get; set; }
            public double windBearing { get; set; }
            public double cloudCover { get; set; }
            public double uvIndex { get; set; }
            public double visibility { get; set; }
            public double ozone { get; set; }
        }

        public class root
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string timezone { get; set; }

            public CurrentWeather currently { get; set; }
        }

    }
}
