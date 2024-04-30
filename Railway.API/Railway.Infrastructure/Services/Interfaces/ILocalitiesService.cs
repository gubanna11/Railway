using Railway.Infrastructure.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services.Interfaces;

public interface ILocalitiesService
{
    Task<IEnumerable<LocalityDto>> GetLocalitiesAsync();
}
