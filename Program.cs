using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Factory.
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            // Get Weather Data Singleton instance.
            WeatherData wd = WeatherData.GetInstance(factory.GetWeatherData(factory.platform));
            Console.WriteLine(wd.ToString());
        }
    }
}
