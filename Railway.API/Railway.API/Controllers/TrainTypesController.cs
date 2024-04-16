using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainTypesController : ControllerBase
    {
        private readonly ITrainTypesService _trainTypesService;

        public TrainTypesController(ITrainTypesService trainTypesService)
        {
            _trainTypesService = trainTypesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _trainTypesService.GetAll();
            return Ok(types);
        }
    }
}
