using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld) {
        helloWorldService = helloWorld;
    }
    [HttpGet]
    // Metodo get que retorna Inyección de dependencia
    public IActionResult Get() {
        return Ok(helloWorldService.GetHelloWorld());
    }
}