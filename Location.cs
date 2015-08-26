using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataApp
{
    public class Location
    {
        public double longitude { get; set; }
        public double latitude { get; set; }

        public Location(double lat, double lng)
        {
            this.longitude = lng;
            this.latitude = lat;
        }
    }
}


