using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Railway.Infrastructure.Services;

public class TrainsService : ITrainsService
{
    private readonly IUnitOfWork<Train> _unitOfWork;
    private readonly IMapper _mapper;

    public TrainsService(IUnitOfWork<Train> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public IEnumerable<TrainDto> GetByTypeId(int typeId)
    {
        var trains = _unitOfWork
            .GenericRepository
            .GetAll(t => t.TypeId == typeId)
            .Select(t => _mapper.Map<TrainDto>(t));
        
        return trains;
    }
}
