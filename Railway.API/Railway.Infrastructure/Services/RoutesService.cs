using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Dtos.CreateDtos;
using Railway.Infrastructure.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class RoutesService : IRoutesService
{
    private readonly IUnitOfWork<Route> _unitOfWork;
    private readonly IMapper _mapper;

    public RoutesService(IUnitOfWork<Route> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RouteDto> AddAsync(CreateRouteDto createRouteDto)
    {
        Route route = _mapper.Map<Route>(createRouteDto);

        await _unitOfWork.GenericRepository.AddAsync(route);
        await _unitOfWork.SaveAsync();

        foreach (var detail in createRouteDto.RouteDetails)
        {
            var newDetail = _mapper.Map<RouteDetail>(detail);
            newDetail.RouteId = route.Id;
            await _unitOfWork.GetGenericRepository<RouteDetail>().AddAsync(newDetail);
        }

        foreach (var stop in createRouteDto.RouteStops)
        {
            var newStop = _mapper.Map<RouteStop>(stop);
            newStop.RouteId = route.Id;
            await _unitOfWork.GetGenericRepository<RouteStop>().AddAsync(newStop);
        }

        await _unitOfWork.SaveAsync();

        return _mapper.Map<RouteDto>(route);
    }

    public IEnumerable<RouteDto> GetAll()
    {
        var routes = _unitOfWork.GenericRepository.GetAll(
            null,
            null,
            r => r.Train, r => r.RouteStops);

        //var routes =  _unitOfWork.GenericRepository.Set
        //    .Select(
        //    r => new RouteDto
        //    {
        //        Id = r.Id,
        //        Train = r.Train,
        //        //TrainType
        //        RouteStops = r.RouteStops
        //    });

        //return routes;
        return _mapper.Map<IEnumerable<RouteDto>>(routes);
    }
}
