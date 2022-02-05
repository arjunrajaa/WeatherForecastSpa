using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecast.Accessor.Interface;
using WeatherForecast.Common;

namespace WeatherForecastSpa.Controllers
{
    [Authorize]
    public class WeatherForecastController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherRepo _weatherRepo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepo weatherRepo)
        {
            _logger = logger;
            _weatherRepo = weatherRepo;

        }

        [Route("api/[controller]/current")]
        [HttpGet]
        public async Task<WeatherResponse> GetCurrentWeather(string city)
        {
            var weatherInfo = await _weatherRepo.GetWeatherInfo(city);
            return weatherInfo;
        }

        [Route("api/[controller]/forecast")]
        [HttpGet]
        public async Task<RootWeather> GetForecastWeather(string city)
        {
            var weatherInfo = await _weatherRepo.GetWeatherForecastInfo(city);
            return weatherInfo;
        }
    }
}
