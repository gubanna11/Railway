using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class LocalitiesService : ILocalitiesService
{
    private readonly IUnitOfWork<Locality> _unitOfWork;
    private readonly IMapper _mapper;

    public LocalitiesService(IUnitOfWork<Locality> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocalityDto>> GetLocalitiesAsync()
    {
        var localities = _unitOfWork.GenericRepository.GetAll(null,
            null,
            l => l.Stations);
        return _mapper.Map<IEnumerable<LocalityDto>>(localities);
    }
}
