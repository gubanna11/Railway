using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using Railway.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class TicketsService : ITicketsService
{
    private readonly IUnitOfWork<Ticket> _unitOfWork;
    private readonly IMapper _mapper;

    public TicketsService(IUnitOfWork<Ticket> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TicketDto> AddAsync(CreateTicketDto createTicketDto)
    {
        var ticket = _mapper.Map<Ticket>(createTicketDto);

        await _unitOfWork.GenericRepository.AddAsync(ticket);
        await _unitOfWork.SaveAsync();

        if (createTicketDto.Options != null)
        {
            foreach (var option in createTicketDto.Options)
            {
                TicketOptionDto ticketOptionDto = new TicketOptionDto();

                ticketOptionDto.TicketId = ticket.Id;
                ticketOptionDto.OptionId = option.Id;

                await _unitOfWork.GetGenericRepository<TicketOption>().AddAsync(
                    _mapper.Map<TicketOption>(ticketOptionDto));
            }
        }

        await _unitOfWork.SaveAsync();

        return _mapper.Map<TicketDto>(ticket);
    }

    public async Task<IEnumerable<TicketDto>> GetByUserId(string userId)
    {
        var tickets = _unitOfWork.GenericRepository.GetAll(
            t => t.UserId == userId,
            null,
            t => t.TicketOptions,
            t => t.FromRouteStop.StationTrack.Station.Locality,
            t => t.ToRouteStop.StationTrack.Station.Locality);

        return _mapper.Map<IEnumerable<TicketDto>>(tickets);
    }

    public async Task<double> CalculateTotalPrice(int routeSeatId, int ticketTypeId, double distance)
    {
        var totalPrice = await _unitOfWork.CallFunctionAsync<double>("calculateTotalPrice", routeSeatId, ticketTypeId, distance);

        return totalPrice;
    }
}
