﻿using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos.Procedures.RouteSearch;
using Railway.Infrastructure.Dtos.Procedures.RouteSearch.Concrete;
using Railway.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class RouteStopsService : IRouteStopsService
{
    private readonly IUnitOfWork<RouteStop> _unitOfWork;
    private readonly IMapper _mapper;

    public RouteStopsService(IUnitOfWork<RouteStop> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RouteStopTicketDto>> GetRoutesBetweenLocalities(int fromLocalityId, int toLocalityId, DateTime date)
    {
        var stops = await _unitOfWork.CallProcedureAsync<RouteStopTicketDto>
           ("getRoutesByLocalityIdFromAndToWithDate", fromLocalityId, toLocalityId, date);

        foreach (var stop in stops)
        {
            var routeAvailabilityDto = await _unitOfWork.CallProcedureAsync<RouteAvailabilityDto>("getRouteAvailability", stop.RouteId, date);
            stop.Details = new List<RouteStopTicketDetailDto>();
            foreach (var routeAvailability in routeAvailabilityDto)
            {
                stop.Details.Add(new RouteStopTicketDetailDto
                {
                    CoachTypeId = routeAvailability.CoachTypeId,
                    CoachTypeName = routeAvailability.CoachTypeName,
                    SeatsAvailableAmount = routeAvailability.AvailableAmount,
                });
            }
        }

        return stops;
    }
}