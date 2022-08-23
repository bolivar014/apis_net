using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // Middleware de autenticación
    private readonly ILogger<WeatherForecastController> _logger;

    // Inicializamos la creación de lista 
    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    // Creamos registro para la lista
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        // Validamos si la lista es igual a null ó no tiene ningun registro
        if(ListWeatherForecast == null || !ListWeatherForecast.Any()) {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    // Evento GET para listar obj GetWeatherForecast
    [HttpGet(Name = "GetWeatherForecast")]
    // Asignamos nombre de las rutas tipo GET por las cuales va a responder el endpoint
    // [Route("Get/weatherforecast")]
    // [Route("Get/weatherforecast2")]
    // [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        // Creamos log 
        _logger.LogInformation("Retornando la lista de weatherforecast");
        // Retornamos lista
        return ListWeatherForecast;
    }

    // Evento POST para la creación de registro en ListWeatherForecast
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast) {
        // Agregamos registro al modelo que estamos recibiendo
        ListWeatherForecast.Add(weatherForecast);

        // Retornamos OK cuando sucede su ejecución
        return Ok();
    }

    // Indicamos que va a recibir una variable index por medio de la URL
    [HttpDelete("{index}")]
    public IActionResult Delete(int index) {
        // Removemos el indice de la lista
        ListWeatherForecast.RemoveAt(index);

        // Retornamo OK
        return Ok();
    }
}
