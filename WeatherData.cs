using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataApp
{
    public class WeatherData
    {

        private static WeatherData instance;

        private WeatherData(WeatherData obj)
        {
            //this.clouds.all = obj.clouds == null ? 0 : obj.clouds.all;
            this.cod = obj.cod;
            this.coord = obj.coord;
            this.dt = obj.dt;
            this.id = obj.id;
            this.main = obj.main;
            this.name = obj.name;
            this.rain = obj.rain;
            this.sys = obj.sys;
            this.weather = obj.weather;
            this.wind = obj.wind;

        }

        private WeatherData()
        {

        }


        public static WeatherData GetInstance(WeatherData obj)
        {

            if (instance == null)
            {
                instance = obj == null ? new WeatherData() : new WeatherData(obj);
            }
            return instance;
        }

        public override string ToString()
        {
            var str = "Coord: \nLatitude : " + this.coord.lat + " Longitude : " + this.coord.lon + "\n\n" +
                "Sys: \nIn " + this.name + "," + this.sys.country + " The sun rises at :" + this.sys.sunrise + " and sets at :" + this.sys.sunset + "\n\n" +
                "Weather : \n";

            for (var i = 0; i < this.weather.Length; i++)
                str += "Description : " + this.weather[i].description + " Icon : " + this.weather[i].icon + " Id : " +this.weather[i].id + " Main : " +this.weather[i].main + "\n";

            str += "Humidity : " + this.main.humidity + "\n\n" + "Tempature : " + this.main.temp + " Maximum Degrees : " + this.main.temp_max + " Minimum Degrees : " + this.main.temp_min + "\n\n";

            str += "\n\n";
            return str;
        }

        public Coord coord { get; set; }
        public Sys sys { get; set; }
        public Weather[] weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }

        public class Sys
        {
            public string country { get; set; }
            public double sunrise { get; set; }
            public double sunset { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double humidity { get; set; }
            public double pressure { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }

        public class Rain
        {
            public double _3h { get; set; }
        }

        public class Clouds
        {
            public double all { get; set; }
        }

        public class Weather
        {
            public double id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }

        }


    }
}
