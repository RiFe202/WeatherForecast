using Microsoft.AspNetCore.Mvc;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{location}")]
        public async Task<IActionResult> GetWeather(string location)
        {
            var weatherData = await _weatherService.GetWeatherAsync(location);

            if (weatherData == null)
            {
                return NotFound("Unable to fetch weather data.");
            }

            return Ok(weatherData);
        }
    }
}