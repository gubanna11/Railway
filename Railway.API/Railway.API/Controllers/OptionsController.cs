using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IOptionsService _optionsService;

        public OptionsController(IOptionsService optionsService)
        {
            _optionsService = optionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var options = await _optionsService.GetAllAsync();

            return Ok(options);
        }
    }
}
