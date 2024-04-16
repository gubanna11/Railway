using Railway.Core.Abstract.Interfaces;
using Railway.Core.Data;
using Railway.Core.Entities;

namespace Railway.Core.Abstract;

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

    public IGenericRepository<Type> GetGenericRepository<Type>() where Type : BaseEntity
    {
        return new GenericRepository<Type>(_context);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
