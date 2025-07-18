using apis_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    TareasContext tareasContext;

    private readonly ILogger<HelloWorldController> _logger;
    public HelloWorldController(IHelloWorldService helloWorld, TareasContext tareasContext, ILogger<HelloWorldController> logger)
    {
        this.helloWorldService = helloWorld;
        this.tareasContext = tareasContext;
        this._logger = logger;
    }

    [HttpGet(Name = "GetHelloWorld")]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando el saludo desde HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("CreateDatabase")]
    public IActionResult CreateDatabase()
    {
        _logger.LogInformation("Creando la base de datos si no existe");
        tareasContext.Database.EnsureCreated();
        return Ok("Base de datos creada o ya existe");
    }
}