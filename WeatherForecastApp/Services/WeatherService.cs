using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherForecastApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://www.yr.no/nb");
        }

        public async Task<string?> GetWeatherAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be null or empty.", nameof(location));
            }

            try
            {
                var relativeUrl = $"/v%C3%A6rvarsel/daglig-tabell/{Uri.EscapeDataString(location)}";
                var response = await _httpClient.GetAsync(relativeUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                        $"Failed to fetch weather data. Status Code: {response.StatusCode}");
                }

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Request failed: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }
    }
}