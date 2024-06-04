using Railway.Infrastructure.Dtos;
using System.Collections.Generic;

namespace Railway.Infrastructure.Services.Interfaces;

public interface ITrainsService
{
    IEnumerable<TrainDto> GetByTypeId(int typeId);
}
