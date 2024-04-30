using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocalitiesController : ControllerBase
{
    private readonly ILocalitiesService _localitiesService;

    public LocalitiesController(ILocalitiesService localitiesService)
    {
        _localitiesService = localitiesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var localitites = await _localitiesService.GetLocalitiesAsync();
        return Ok(localitites);
    }
}
