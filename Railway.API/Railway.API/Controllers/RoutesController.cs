using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Dtos.CreateDtos;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    private readonly IRoutesService _routesService;

    public RoutesController(IRoutesService routesService)
    {
        _routesService = routesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var routeDtos = _routesService.GetAll();
        return Ok(routeDtos);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateRouteDto routeDto)
    {
        var newRouteDto = await _routesService.AddAsync(routeDto);

        if (newRouteDto.Id != 0)
        {
            return Ok(new
            {
                Message = "Route was added successfully!",
                Route = routeDto
            });
        }

        return BadRequest();
    }
}
