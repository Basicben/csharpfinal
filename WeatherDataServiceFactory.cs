using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace WeatherDataApp
{
    public class WeatherDataServiceFactory : IWeatherDataService
    {

        public WeatherDataEnum platform { get; set; }
        public Location location { get; set; }

        public WeatherDataServiceFactory()
        {
            this.platform = WeatherDataEnum.OPEN_WEATHER_MAP;
            location = new Location(32.066158, 34.777819);
        }

        // get Weather Data by Location (Long, Lat)
        public WeatherData GetWeatherData(WeatherDataEnum platform)
        {
            var json_data = string.Empty;

            if (platform != WeatherDataEnum.OPEN_WEATHER_MAP)
                throw new WeatherDataServiceException("Unrecognized Enum Type. Try to use OPEN_WEATHER_MAP");

            using (var w = new WebClient())
            {
                // attempt to download JSON data as a string
                try
                {
                    string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + this.location.latitude.ToString() + "&lon=" + this.location.longitude.ToString();
                    Console.WriteLine(url);
                    json_data = w.DownloadString(url);
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<WeatherData>(json_data) : WeatherData.GetInstance(null);
                    //return this.GetWeather();
                }
                catch (WeatherDataServiceException e)
                {
                    Console.WriteLine("Error : " + e.StackTrace);
                }
            }

            return null;
        }

    }
}
