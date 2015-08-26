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
        // get Weather Data by Location (Long, Lat)
        public WeatherData GetWeatherData(Location location)
        {
            var json_data = string.Empty;
            using (var w = new WebClient())
            {
                // attempt to download JSON data as a string
                try
                {
                    string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + location.latitude.ToString() + "&lon=" + location.longitude.ToString();
                    json_data = w.DownloadString("http://api.openweathermap.org/data/2.5/weather?lat=32.066158&lon=34.777819");
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<WeatherData>(json_data) : WeatherData.GetInstance(null);
                    //return this.GetWeather();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            Console.WriteLine("json " + json_data);
            return null;
        }

    }
}
