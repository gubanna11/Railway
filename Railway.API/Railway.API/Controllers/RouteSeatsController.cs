using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteSeatsController : ControllerBase
    {
        private readonly IRouteSeatsService _routeSeatsService;

        public RouteSeatsController(IRouteSeatsService routeSeatsService)
        {
            _routeSeatsService = routeSeatsService;
        }

        [HttpGet("by-coach-type")]
        public async Task<IActionResult> GetSeatsInfo([FromQuery] int routeId, [FromQuery] DateTime date, [FromQuery] int coachTypeId)
        {
            var result = await _routeSeatsService.GetSeatsByCoachTypeId(routeId, date, coachTypeId);
            return Ok(result);
        }
    }
}
