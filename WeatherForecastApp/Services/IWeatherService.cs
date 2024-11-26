namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        Task<string?> GetWeatherAsync(string location);
    }
}