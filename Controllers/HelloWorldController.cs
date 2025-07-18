using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;
    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        this.helloWorldService = helloWorld;
        this._logger = logger;
    }

    [HttpGet(Name = "GetHelloWorld")]
    public IActionResult Get()
    {
        _logger.LogInformation("Retornando el saludo desde HelloWorld");
        return Ok(helloWorldService.GetHelloWorld());
    }
}