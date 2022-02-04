using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Common;

namespace WeatherForecast.Accessor.Interface
{
    public interface IWeatherRepo
    {
        Task<RootWeather> GetWeatherForecastInfo(string city);
        Task<WeatherResponse> GetWeatherInfo(string city);
    }
}
