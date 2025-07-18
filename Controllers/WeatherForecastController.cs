using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]
    [Route("Aura/weatherforecast")]
    [Route("[action]")]

    public IEnumerable<WeatherForecast> Get()
    {
        return ListWeatherForecast;
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post([FromBody] WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok(ListWeatherForecast);
    }

    [HttpPatch("{index}")]
    public IActionResult Patch(int index, [FromBody] WeatherForecast weatherForecast)
    {
        if (index < 0 || index >= ListWeatherForecast.Count)
        {
            return NotFound("Index out of range");
        }

        ListWeatherForecast[index] = weatherForecast;
        return Ok(ListWeatherForecast);
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok(ListWeatherForecast);
    }
}
