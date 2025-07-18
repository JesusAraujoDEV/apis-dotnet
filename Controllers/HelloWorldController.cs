using Microsoft.AspNetCore.Mvc;

namespace apis_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]

public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;
    public HelloWorldController(IHelloWorldService helloWorld)
    {
        this.helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}