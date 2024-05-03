using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Services.Interfaces;
using System.Collections.Generic;

namespace Railway.Infrastructure.Services;

public class TrainTypesService : ITrainTypesService
{
    private readonly IUnitOfWork<TrainType> _unitOfWork;
    private readonly IMapper _mapper;

    public TrainTypesService(IUnitOfWork<TrainType> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<TrainTypeDto> GetAll()
    {
        var types = _unitOfWork.GenericRepository
            .Set
            .Include(t => t.TrainTypeDetails)
            .ThenInclude(td => td.CoachType);

        return _mapper.Map<IEnumerable<TrainTypeDto>>(types);
    }
}
