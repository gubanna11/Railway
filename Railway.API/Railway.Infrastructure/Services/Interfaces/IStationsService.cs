using Railway.Infrastructure.Dtos;
using System.Collections.Generic;

namespace Railway.Infrastructure.Services.Interfaces;

public interface IStationsService
{
    IEnumerable<StationDto> GetStationsByLocalityId(int localityId);
}
