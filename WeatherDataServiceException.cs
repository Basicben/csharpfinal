using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherDataApp
{
    // Weather Data Service Exception
    public class WeatherDataServiceException : Exception
    {
        public WeatherDataServiceException()
            : base() { }

        public WeatherDataServiceException(string message)
            : base(message) { }

        public WeatherDataServiceException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public WeatherDataServiceException(string message, Exception innerException)
            : base(message, innerException) { }

        public WeatherDataServiceException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }


    }
}
