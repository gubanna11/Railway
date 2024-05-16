using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteStopsController : ControllerBase
    {
        private readonly IRouteStopsService _routeStopsService;

        public RouteStopsController(IRouteStopsService routeStopsService)
        {
            _routeStopsService = routeStopsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutesBetweenLocalitiesWithDate([FromQuery] int fromLocalityId, [FromQuery] int toLocalityId, [FromQuery] DateTime date)
        {
            var result = await _routeStopsService.GetRoutesBetweenLocalities(fromLocalityId, toLocalityId, date);
            return Ok(result);
        }
    }
}
