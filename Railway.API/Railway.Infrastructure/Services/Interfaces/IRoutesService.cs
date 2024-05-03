using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services.Interfaces;

public interface IRoutesService
{
    IEnumerable<RouteDto> GetAll();

    Task<RouteDto> AddAsync(CreateRouteDto routeDto);
}
