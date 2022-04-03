using CofferBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CofferBackend.Controllers;

[ApiController]
[Route("v1/submit/[Action]")]
public class SubmitNewDataController : ControllerBase
{
    private readonly ILogger<SubmitNewDataController> _logger;
    
    private readonly DbService _dbService;

    public SubmitNewDataController(ILogger<SubmitNewDataController> logger)
    {
        _dbService = new DbService();
        _logger = logger;
    }

    [HttpPost(Name = "coffee")]
    public IActionResult SubmitCoffee([FromBody] NewCoffee newCoffee)
    {
        _dbService.NewCoffees.Add(newCoffee);
        var res = _dbService.SaveChanges();
        if (res > 0)
        {
            return Ok("Ok");
        }
        else
        {
            return BadRequest("Error");
        }
    }
}