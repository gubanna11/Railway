using Railway.Infrastructure.Dtos.Procedures.RouteSearch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services.Interfaces;

public interface IRouteStopsService
{
    Task<IEnumerable<RouteStopTicketDto>> GetRoutesBetweenLocalities(int fromLocalityId,
        int toLocalityId, DateTime date);
}
