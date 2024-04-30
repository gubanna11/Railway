using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StationsController : ControllerBase
{
    private readonly IStationsService _stationsService;

    public StationsController(IStationsService stationsService)
    {
        _stationsService = stationsService;
    }

    [HttpGet]
    public IActionResult GetByLocalityId([FromQuery] int localityId)
    {
        var stations = _stationsService.GetStationsByLocalityId(localityId);
        return Ok(stations);
    }
}
