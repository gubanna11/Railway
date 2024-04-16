using Railway.Infrastructure.Dtos;
using System.Collections.Generic;

namespace Railway.Infrastructure.Services.Interfaces;

public interface ITrainTypesService
{
    IEnumerable<TrainTypeDto> GetAll();
}
