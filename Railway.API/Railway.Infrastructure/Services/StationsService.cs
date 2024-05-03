using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Railway.Infrastructure.Services;

public class StationsService : IStationsService
{
    private readonly IUnitOfWork<Station> _unitOfWork;
    private readonly IMapper _mapper;

    public StationsService(IUnitOfWork<Station> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<StationDto> GetStationsByLocalityId(int localityId)
    {
        var stations = _unitOfWork.GenericRepository.GetAll(
            s => s.LocalityId == localityId,
            null,
            s => s.StationTracks);

        return _mapper.Map<IEnumerable<StationDto>>(stations);
    }
}
