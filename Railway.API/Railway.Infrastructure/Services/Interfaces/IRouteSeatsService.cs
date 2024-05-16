using System.Threading.Tasks;
using System;
using Railway.Infrastructure.Dtos.Procedures.RouteSearch;

namespace Railway.Infrastructure.Services.Interfaces;

public interface IRouteSeatsService
{
    Task<RouteStopTicketDetailDto> GetSeatsByCoachTypeId(int routeId, DateTime date, int coachTypeId);
}
