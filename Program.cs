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

            Location location = new Location(32.066158, 34.777819);

            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            WeatherData wd = WeatherData.GetInstance(factory.GetWeatherData(location));
            Console.WriteLine(wd.ToString());

        }
    }
}
