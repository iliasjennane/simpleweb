using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Collections.Generic;

namespace simpleweb.Data
{
    public class WeatherForecastService
    {
        private string _apiUrl;
        public WeatherForecastService(IConfiguration configuration)
        {
            _apiUrl = $"http://{configuration.GetValue<string>("apiURL")}/weatherforecast";
        }
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            HttpClient customersApiClient = new HttpClient();
            HttpResponseMessage response = await customersApiClient.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            WeatherForecast[] weatherForecastData = JsonSerializer.Deserialize<WeatherForecast[]>(jsonResponse);
            return weatherForecastData;
        }
    }
}
