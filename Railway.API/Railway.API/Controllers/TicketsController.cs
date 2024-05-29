using Microsoft.AspNetCore.Mvc;
using Railway.Infrastructure.Dtos.CreateDtos;
using Railway.Infrastructure.Services.Interfaces;

namespace Railway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var tickets = await _ticketsService.GetByUserId(userId);
            return Ok(tickets);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateTicketDto createTicketDto)
        {
            var newTicketDto = await _ticketsService.AddAsync(createTicketDto);
            if (newTicketDto.Id != 0)
            {
                return Ok(new
                {
                    Message = "Ticket was booked successfully!",
                    Ticket = newTicketDto
                });
            }

            return BadRequest();
        }

        [HttpGet("total-price")]
        public async Task<IActionResult> CalculateTotalPrice([FromQuery]int routeSeatId, int ticketTypeId, double distance)
        {
            double price = await _ticketsService.CalculateTotalPrice(routeSeatId, ticketTypeId, distance);
            return Ok(price);
        }
    }
}
