﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherDataApp
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(WeatherDataEnum platform);
    }
}
