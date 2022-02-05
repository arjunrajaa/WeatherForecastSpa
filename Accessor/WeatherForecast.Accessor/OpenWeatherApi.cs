using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Accessor.Interface;
using WeatherForecast.Common;

namespace WeatherForecast.Accessor
{
    public class OpenWeatherApi : IWeatherRepo
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public OpenWeatherApi(IConfiguration config)
        {
            _config = config;
            _apiKey = _config["OpenWeather:ApiKey"];
            _baseUrl = _config["OpenWeather:BaseUrl"];

        }

        public async Task<WeatherResponse> GetWeatherInfo(string city)
        {
            HttpClient client = new HttpClient();
            
            var response = await client.GetAsync($"{_baseUrl}/weather?q={city}&units=metric&APPID={_apiKey}");

            var stringResult = await response.Content.ReadAsStringAsync();

            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
            return weatherResponse;
        }

        public async Task<RootWeather> GetWeatherForecastInfo(string city)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync($"{_baseUrl}/forecast?q={city}&units=metric&APPID={_apiKey}");

            var stringResult = await response.Content.ReadAsStringAsync();

            var weatherResponse = JsonConvert.DeserializeObject<RootWeather>(stringResult);
            return weatherResponse;
        }

    }
}
