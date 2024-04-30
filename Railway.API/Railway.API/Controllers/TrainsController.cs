using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainsController : ControllerBase
{
    private readonly ITrainsService _trainsService;

    public TrainsController(ITrainsService trainsService)
    {
        _trainsService = trainsService;
    }

    [HttpGet]
    public IActionResult GetByTypeId([FromQuery] int typeId)
    {
        var trains = _trainsService.GetByTypeId(typeId);
        return Ok(trains);
    }
}
