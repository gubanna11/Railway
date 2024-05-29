using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services.Interfaces;

public interface ITicketsService
{
    Task<TicketDto> AddAsync(CreateTicketDto createTicketDto);

    Task<IEnumerable<TicketDto>> GetByUserId(string userId);

    Task<double> CalculateTotalPrice(int routeSeatId, int ticketTypeId, double distance);
}
