using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Resources;
using WeatherForecastWPF_Version_1_0.Properties;

namespace WeatherForecastWPF_Version_1_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string APPID = "2c7296a7dfa8806a353cbccf4b2f4d2b";


        //ToDo get coordinates with Google API
        private string budapestLatitude = "47.4979";
        private string budapestLongitude = "19.0402";
        private string luxembourgLatitude = "49.8153";
        private string luxembourgLongitude = "6.1296";
        private string debrecenLatitude = "47.5316";
        private string debrecenLongitude = "21.6273";
        private string pecsLatitude = "46.0727";
        private string pecsLongitude = "18.2323";
        private string wiennaLatitude = "48.2082";
        private string wiennaLongitude = "16.3738";
        private string pragueLatitude = "50.0755";
        private string pragueLongitude = "14.4378";
        private string munchenLatitude = "48.1351";
        private string munchenLongitude = "11.5820";
        private string amsterdamLatitude = "52.3680";
        private string amsterdamLongitude = "4.9036";
        
        WeatherForecastViewModel wfViewModel;
        
        public MainWindow()
        {
            CultureInfo culture = new CultureInfo(ConfigurationManager.AppSettings["Culture"]);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            wfViewModel = new WeatherForecastViewModel();

            InitializeComponent();
        }

        public void getWeather(string latitude, string longitude)
        {
            try
            {
                string json = wfViewModel.getWeatherService(APPID, latitude, longitude);
                this.showCurrentWeatherInformation(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void getWeatherForecast(string latitude, string longitude)
        {
            try
            {
                string json = wfViewModel.getWeatherForecastService(APPID, latitude, longitude);
                this.showWeatherForecastInformation(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void City_ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            string selectedCity = (sender as ComboBoxItem).Content.ToString();

            switch (selectedCity)
            {
                case "Budapest":
                    this.getWeather(budapestLatitude, budapestLongitude);
                    this.getWeatherForecast(budapestLatitude, budapestLongitude);
                    break;
                case "Luxembourg":
                    this.getWeather(luxembourgLatitude, luxembourgLongitude);
                    this.getWeatherForecast(luxembourgLatitude, luxembourgLatitude);
                    break;
                case "Debrecen":
                    this.getWeather(debrecenLatitude, debrecenLongitude);
                    this.getWeatherForecast(debrecenLatitude, debrecenLongitude);
                    break;
                case "Pécs":
                    this.getWeather(pecsLatitude, pecsLongitude);
                    this.getWeatherForecast(pecsLatitude, pecsLongitude);
                    break;
                case "Wienna":
                    this.getWeather(wiennaLatitude, wiennaLongitude);
                    this.getWeatherForecast(wiennaLatitude, wiennaLongitude);
                    break;
                case "Prague":
                    this.getWeather(pragueLatitude, pragueLongitude);
                    this.getWeatherForecast(pragueLatitude, pragueLongitude);
                    break;
                case "München":
                    this.getWeather(munchenLatitude, munchenLongitude);
                    this.getWeatherForecast(munchenLatitude, munchenLongitude);
                    break;
                case "Amsterdam":
                    this.getWeather(amsterdamLatitude, amsterdamLongitude);
                    this.getWeatherForecast(amsterdamLatitude, amsterdamLongitude);
                    break;
                default:
                    break;
            }
        }

        public void showCurrentWeatherInformation(string json)
        {

            var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
            WeatherInfo.root output = result;
            try
            {
                forecastIcon.Source = this.showIcon(output.currently.showedIcon);
                lbl_timezone.Content = string.Format("{0}", output.timezone);
                lbl_temperature_value.Content = string.Format("{0}", output.currently.temperatureCelsius);
                lbl_apparent_temperature_value.Content = string.Format("{0}", output.currently.apparentTemperatureCelsius);
                lbl_atm_pressure_value.Content = string.Format("{0}", output.currently.pressure);
                lbl_humidity_value.Content = string.Format("{0}", output.currently.humidityPercent);
                lbl_uv_index_value.Content = string.Format("{0}", output.currently.uvIndex);
                lbl_wind_speed_value.Content = string.Format("{0}", output.currently.windSpeed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void showWeatherForecastInformation(string json)
        {
            var result = JsonConvert.DeserializeObject<WeatherForecast.root>(json);
            WeatherForecast.root output = result;
            try
            {
                imgDay1.Source = this.showIcon(output.daily.data[1].showedIcon);
                day_1.Content = string.Format("{0}", (output.daily.data[1].weekDay.DayOfWeek));
                temp1.Content = string.Format("{0}", (output.daily.data[1].temperatureCelsius));
                app_temp1.Content = string.Format("{0}", (output.daily.data[1].apparentCelsius));
                amtmospheric_press1.Content = string.Format("{0}", (output.daily.data[1].pressure));
                wind_speed_1.Content = string.Format("{0}", (output.daily.data[1].windSpeed));
                humidity_1.Content = string.Format("{0}", (output.daily.data[1].humidityPercent));
                uv_index_1.Content = string.Format("{0}", (output.daily.data[1].uvIndex));

                imgDay2.Source = this.showIcon(output.daily.data[2].showedIcon);
                day_2.Content = string.Format("{0}", (output.daily.data[2].weekDay.DayOfWeek));
                temp2.Content = string.Format("{0}", (output.daily.data[2].temperatureCelsius));
                app_temp2.Content = string.Format("{0}", (output.daily.data[2].apparentCelsius));
                amtmospheric_press2.Content = string.Format("{0}", (output.daily.data[2].pressure));
                wind_speed_2.Content = string.Format("{0}", (output.daily.data[2].windSpeed));
                humidity_2.Content = string.Format("{0}", (output.daily.data[2].humidityPercent));
                uv_index_2.Content = string.Format("{0}", (output.daily.data[2].uvIndex));

                imgDay3.Source = this.showIcon(output.daily.data[3].showedIcon);
                day_3.Content = string.Format("{0}", (output.daily.data[3].weekDay.DayOfWeek));
                temp3.Content = string.Format("{0}", (output.daily.data[3].temperatureCelsius));
                app_temp3.Content = string.Format("{0}", (output.daily.data[3].apparentCelsius));
                amtmospheric_press3.Content = string.Format("{0}", (output.daily.data[3].pressure));
                wind_speed_3.Content = string.Format("{0}", (output.daily.data[3].windSpeed));
                humidity_3.Content = string.Format("{0}", (output.daily.data[3].humidityPercent));
                uv_index_3.Content = string.Format("{0}", (output.daily.data[3].uvIndex));

                imgDay4.Source = this.showIcon(output.daily.data[4].showedIcon);
                day_4.Content = string.Format("{0}", (output.daily.data[4].weekDay.DayOfWeek));
                temp4.Content = string.Format("{0}", (output.daily.data[4].temperatureCelsius));
                app_temp4.Content = string.Format("{0}", (output.daily.data[4].apparentCelsius));
                amtmospheric_press4.Content = string.Format("{0}", (output.daily.data[4].pressure));
                wind_speed_4.Content = string.Format("{0}", (output.daily.data[4].windSpeed));
                humidity_4.Content = string.Format("{0}", (output.daily.data[4].humidityPercent));
                uv_index_4.Content = string.Format("{0}", (output.daily.data[4].uvIndex));

                imgDay5.Source = this.showIcon(output.daily.data[5].showedIcon);
                day_5.Content = string.Format("{0}", (output.daily.data[5].weekDay.DayOfWeek));
                temp5.Content = string.Format("{0}", (output.daily.data[5].temperatureCelsius));
                app_temp5.Content = string.Format("{0}", (output.daily.data[5].apparentCelsius));
                amtmospheric_press5.Content = string.Format("{0}", (output.daily.data[5].pressure));
                wind_speed_5.Content = string.Format("{0}", (output.daily.data[5].windSpeed));
                humidity_5.Content = string.Format("{0}", (output.daily.data[5].humidityPercent));
                uv_index_5.Content = string.Format("{0}", (output.daily.data[5].uvIndex));

                imgDay6.Source = this.showIcon(output.daily.data[6].showedIcon);
                day_6.Content = string.Format("{0}", (output.daily.data[6].weekDay.DayOfWeek));
                temp6.Content = string.Format("{0}", (output.daily.data[6].temperatureCelsius));
                app_temp6.Content = string.Format("{0}", (output.daily.data[6].apparentCelsius));
                amtmospheric_press6.Content = string.Format("{0}", (output.daily.data[6].pressure));
                wind_speed_6.Content = string.Format("{0}", (output.daily.data[6].windSpeed));
                humidity_6.Content = string.Format("{0}", (output.daily.data[6].humidityPercent));
                uv_index_6.Content = string.Format("{0}", (output.daily.data[6].uvIndex));

                imgDay7.Source = this.showIcon(output.daily.data[7].showedIcon);
                day_7.Content = string.Format("{0}", (output.daily.data[7].weekDay.DayOfWeek));
                temp7.Content = string.Format("{0}", (output.daily.data[7].temperatureCelsius));
                app_temp7.Content = string.Format("{0}", (output.daily.data[7].apparentCelsius));
                amtmospheric_press7.Content = string.Format("{0}", (output.daily.data[7].pressure));
                wind_speed_7.Content = string.Format("{0}", (output.daily.data[7].windSpeed));
                humidity_7.Content = string.Format("{0}", (output.daily.data[7].humidityPercent));
                uv_index_7.Content = string.Format("{0}", (output.daily.data[7].uvIndex));
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Language_ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            string selectedLanguage = (sender as ComboBoxItem).Content.ToString();
            
            ResourceManager rm = new ResourceManager("WeatherForecastWPF_Version_1_0.Properties.Resources", typeof(Resources).Assembly);

            if (selectedLanguage == "German")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
            }

            this.changeLabelLanguage(rm);
        }

        public void changeLabelLanguage(ResourceManager rm)
        {
            try
            {
                lbl_weather_forecast.Content = rm.GetString("weatherForecast");
                lbl_weather_forecast_for_the_next.Content = rm.GetString("weatherForecastForTheNext");

                lbl_city.Content = rm.GetString("timezone");
                lbl_temperature.Content = rm.GetString("temperature");
                lbl_apparent_temperature.Content = rm.GetString("apparentTemperature");
                lbl_atmospheric_pressure.Content = rm.GetString("atmosphericPressure");
                lbl_wind_speed.Content = rm.GetString("windSpeed");
                lbl_humidity.Content = rm.GetString("humidity");
                lbl_uv_index.Content = rm.GetString("uvIndex");

                lbl_day1_temp.Content = rm.GetString("temperature");
                lbl_day1_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day1_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day1_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day1_humidity.Content = rm.GetString("humidity");
                lbl_day1_uv_index.Content = rm.GetString("uvIndex");

                lbl_day2_temp.Content = rm.GetString("temperature");
                lbl_day2_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day2_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day2_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day2_humidity.Content = rm.GetString("humidity");
                lbl_day2_uv_index.Content = rm.GetString("uvIndex");

                lbl_day3_temp.Content = rm.GetString("temperature");
                lbl_day3_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day3_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day3_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day3_humidity.Content = rm.GetString("humidity");
                lbl_day3_uv_index.Content = rm.GetString("uvIndex");

                lbl_day4_temp.Content = rm.GetString("temperature");
                lbl_day4_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day4_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day4_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day4_humidity.Content = rm.GetString("humidity");
                lbl_day4_uv_index.Content = rm.GetString("uvIndex");

                lbl_day5_temp.Content = rm.GetString("temperature");
                lbl_day5_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day5_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day5_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day5_humidity.Content = rm.GetString("humidity");
                lbl_day5_uv_index.Content = rm.GetString("uvIndex");

                lbl_day6_temp.Content = rm.GetString("temperature");
                lbl_day6_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day6_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day6_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day6_humidity.Content = rm.GetString("humidity");
                lbl_day6_uv_index.Content = rm.GetString("uvIndex");

                lbl_day7_temp.Content = rm.GetString("temperature");
                lbl_day7_app_temp.Content = rm.GetString("apparentTemperature");
                lbl_day7_atm_press.Content = rm.GetString("atmosphericPressure");
                lbl_day7_wind_speed.Content = rm.GetString("windSpeed");
                lbl_day7_humidity.Content = rm.GetString("humidity");
                lbl_day7_uv_index.Content = rm.GetString("uvIndex");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public BitmapImage showIcon(string img)
        {
            string imgPath = string.Format("/Img/{0}", img);
            BitmapImage image = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            return image;
        }
    }
}
