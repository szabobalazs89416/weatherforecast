using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecastWPF_Version_1_0
{
    class WeatherForecast
    {
        public class daily
        {
            public string summary { get; set; }
            public string icon { get; set; }
            public List<datas> data { get; set; }
        }

        public class datas
        {
            public long time { get; set; }
            public DateTime weekDay
            {
                get
                {
                    return this.unixTimeStampToDateTime(time);
                }
                set { }
            }
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
            public long sunriseTime { get; set; }
            public long sunsetTime { get; set; }
            public double moonPhase { get; set; }
            public double precipIntensity { get; set; }
            public double precipIntensityMax { get; set; }
            public long precipIntensityMaxTime { get; set; }
            public double precipProbability { get; set; }
            public double temperatureHigh { get; set; }
            public long temperatureHighTime { get; set; }
            public double temperatureLow { get; set; }
            public long temperatureLowTime { get; set; }
            public double apparentTemperatureHigh { get; set; }
            public long apparentTemperatureHighTime { get; set; }
            public double apparentTemperatureLow { get; set; }
            public long apparentTemperatureLowTime { get; set; }
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
            public long windGustTime { get; set; }
            public double windBearing { get; set; }
            public double cloudCover { get; set; }
            public double uvIndex { get; set; }
            public long uvIndexTime { get; set; }
            public double visibility { get; set; }
            public double ozone { get; set; }
            public double temperatureMin { get; set; }
            public long temperatureMinTime { get; set; }
            public double temperatureMax { get; set; }
            public long temperatureMaxTime { get; set; }
            public double temperatureCelsius
            {
                get
                {
                    return Math.Round((((temperatureMin + temperatureMax) / 2) - 32) * 5 / 9, 2);
                }
                set { }
            }
            public double apparentTemperatureMin { get; set; }
            public long apparentTemperatureMinTime { get; set; }
            public double apparentTemperatureMax { get; set; }
            public long apparentTemperatureMaxTime { get; set; }
            public double apparentCelsius
            {
                get
                {
                    return Math.Round((((apparentTemperatureMin + apparentTemperatureMax) / 2) - 32) * 5 / 9, 2);
                }
                set { }
            }

            public DateTime unixTimeStampToDateTime(double unixTimeStamp)
            {
                // Unix timestamp is seconds past epoch
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
                return dtDateTime;
            }
        }

        public class root
        {
            public daily daily { get; set; }
        }
    }
}
