using Microsoft.AspNetCore.Mvc;

namespace Weather.API.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("weatherlist", Name = nameof(GetWeathers))]
    public IEnumerable<Weather> GetWeathers()
    {
        return Enumerable.Range(1, 5).Select(index => new Weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    [HttpGet("current", Name = nameof(GetWeather))]
    [ProducesResponseType(typeof(Weather), StatusCodes.Status200OK)]
    public IActionResult GetWeather()
    {
        var weather = new Weather
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
        return Ok(weather);
    }

    [HttpPost("temperature", Name = nameof(SetCurrentTemperature))]
    public async Task<IActionResult> SetCurrentTemperature([FromBody] TemperatureContext temperature)
    {
        await Task.Yield();
        return Ok();
    }
}