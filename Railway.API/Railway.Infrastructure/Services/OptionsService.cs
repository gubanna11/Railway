using AutoMapper;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Entities;
using Railway.Infrastructure.Dtos;
using Railway.Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Services;

public class OptionsService : IOptionsService
{
    private readonly IUnitOfWork<Option> _unitOfWork;
    private readonly IMapper _mapper;

    public OptionsService(IUnitOfWork<Option> unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OptionDto>> GetAllAsync()
    {
        var options = await _unitOfWork.GenericRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<OptionDto>>(options);
    }
}
