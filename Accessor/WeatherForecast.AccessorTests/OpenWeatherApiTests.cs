using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast.Accessor;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace WeatherForecast.Accessor.Tests
{
    [TestClass()]
    public class OpenWeatherApiTests
    {
        private readonly IConfiguration _configuration;
        public OpenWeatherApiTests()
        {
            var myConfiguration = new Dictionary<string, string>
                                {
                                    {"OpenWeather:BaseUrl", "http://api.openweathermap.org/data/2.5/"},
                                    {"OpenWeather:ApiKey", "5ce4f9d7b705a8d978faff161fe15265"}
                                };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(myConfiguration)
                .Build();
        }
        [TestMethod()]
        public void ShoulReturnOutput()
        {
            var weatherRepo = new OpenWeatherApi(_configuration);
            var weather = weatherRepo.GetWeatherInfo("Coventry").GetAwaiter().GetResult();
            Assert.IsNotNull(weather);
        }
    }
}