using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast.Accessor;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Accessor.Tests
{
    [TestClass()]
    public class OpenWeatherApiTests
    {
        
        [TestMethod()]
        public void ShoulReturnOutput()
        {
            var weatherRepo = new OpenWeatherApi();
            var obj = weatherRepo.GetWeatherInfo("Coventry").GetAwaiter().GetResult();
            Assert.IsNotNull(obj);
        }
    }
}