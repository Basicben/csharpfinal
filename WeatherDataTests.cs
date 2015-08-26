using System;
using WeatherDataApp;
using Newtonsoft.Json;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherDataTesting
{
    [TestClass]
    public class WeatherDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(WeatherDataServiceException))]
        public void GetWeatherDataTest()
        {
            var json_data = string.Empty;
            Location location = new Location(32.066158, 34.777819);
            WeatherDataEnum platform = WeatherDataEnum.OPEN_WEATHER_MAP;

            if (platform != WeatherDataEnum.OPEN_WEATHER_MAP)
                throw new WeatherDataServiceException("Unrecognized Enum Type. Try to use OPEN_WEATHER_MAP");

            using (var w = new WebClient())
            {
                // attempt to download JSON data as a string
                try
                {
                    string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + location.latitude.ToString() + "&lon=" + location.longitude.ToString();
                    Console.WriteLine(url);
                    json_data = w.DownloadString(url);
                    // if string with JSON data is not empty, deserialize it to class and return its instance 
                    WeatherData wd = WeatherData.GetInstance(!string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<WeatherData>(json_data) : WeatherData.GetInstance(null));
                    Console.WriteLine(wd.ToString());
                }
                catch (WeatherDataServiceException e)
                {
                    Console.WriteLine("Error : " + e.StackTrace);
                }
            }

            

        }
    }
}
