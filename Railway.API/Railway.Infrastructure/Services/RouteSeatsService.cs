using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos.Procedures.RouteSearch;
using Railway.Infrastructure.Dtos.Procedures.RouteSearch.Concrete;
using Railway.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class RouteSeatsService : IRouteSeatsService
{
    private readonly IUnitOfWork<RouteSeat> _unitOfWork;
    private readonly IMapper _mapper;

    public RouteSeatsService(IUnitOfWork<RouteSeat> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RouteStopTicketDetailDto> GetSeatsByCoachTypeId(int routeId, DateTime date, int coachTypeId)
    {
        RouteAvailabilityDto routeAvailabilityDto = (await _unitOfWork.CallProcedureAsync<RouteAvailabilityDto>("getRouteAvailabilityForCoachTypeId", routeId, date, coachTypeId)).FirstOrDefault();

        var seatAvailabilityDto = await _unitOfWork.CallProcedureAsync<SeatAvailabilityDto>("checkSeatAvailabilityForCoachType", routeId, date, coachTypeId);

        var detail = new RouteStopTicketDetailDto();
        detail.CoachTypeId = coachTypeId;
        detail.CoachTypeName = routeAvailabilityDto.CoachTypeName;
        detail.SeatsAvailableAmount = routeAvailabilityDto.AvailableAmount;

        var groupByNumber = seatAvailabilityDto.GroupBy(sa => sa.CoachNumber);

        detail.Coaches = new List<TicketCoachDto>();

        foreach (var group in groupByNumber)
        {
            var coachDto = new TicketCoachDto
            {
                CoachNumber = group.Key,
                Seats = new List<TicketSeatDto>()
            };

            foreach (var seat in group)
            {
                coachDto.Seats.Add(new TicketSeatDto
                {
                    RouteSeatId = seat.RouteSeatId,
                    IsAvailable = seat.IsAvailable,
                    SeatNumber = seat.SeatNumber
                });
            }

            detail.Coaches.Add(coachDto);
        }

        return detail;
    }
}
