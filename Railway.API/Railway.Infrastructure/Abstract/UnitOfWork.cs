using Railway.Infrastructure.Abstract.Interfaces;
using Railway.Infrastructure.Data;
using Railway.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Abstract;

public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private readonly IGenericRepository<T> _genericRepository;

    public UnitOfWork(AppDbContext context, IGenericRepository<T> genericRepository)
    {
        _context = context;
        _genericRepository = genericRepository;
    }

    IGenericRepository<T> IUnitOfWork<T>.GenericRepository => _genericRepository;
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
