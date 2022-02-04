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
        private const string _apiKey = "5ce4f9d7b705a8d978faff161fe15265";

        public async Task<WeatherResponse> GetWeatherInfo(string city)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");

            
            var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&APPID={_apiKey}");

            var stringResult = await response.Content.ReadAsStringAsync();

            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(stringResult);
            return weatherResponse;
        }

        public async Task<RootWeather> GetWeatherForecastInfo(string city)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org");
            var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&APPID={_apiKey}");

            var stringResult = await response.Content.ReadAsStringAsync();

            var weatherResponse = JsonConvert.DeserializeObject<RootWeather>(stringResult);
            return weatherResponse;
        }

    }
}
