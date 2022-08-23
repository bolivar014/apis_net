using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase {
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;

    public HelloWorldController(IHelloWorldService helloWorld, TareasContext db) {
        helloWorldService = helloWorld;

        dbcontext = db;
    }
    [HttpGet]
    // Metodo get que retorna Inyección de dependencia
    public IActionResult Get() {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult createDatabase() {
        dbcontext.Database.EnsureCreated();

        return Ok();
    }
}