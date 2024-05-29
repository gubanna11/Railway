using Microsoft.EntityFrameworkCore;
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

    public AppDbContext Context => _context;

    IGenericRepository<T> IUnitOfWork<T>.GenericRepository => _genericRepository;

    public IGenericRepository<Type> GetGenericRepository<Type>() where Type : BaseEntity
    {
        return new GenericRepository<Type>(_context);
    }

    public async Task<IEnumerable<Type>> CallProcedureAsync<Type>(string procedureName, params object[] parameters)
    {
        string[] parametersArray = new string[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parametersArray[i] = $"{{{i}}}";
        }

        string parametersString = string.Join(", ", parametersArray);

        var commandText = $"CALL {procedureName}({parametersString})";
        return _context.Database.SqlQueryRaw<Type>(commandText, parameters).ToList();
    }

    public async Task<Type> CallFunctionAsync<Type>(string functionName, params object[] parameters)
    {
        string[] parametersArray = new string[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parametersArray[i] = $"{{{i}}}";
        }

        string parametersString = string.Join(", ", parametersArray);

        var commandText = $"SELECT {functionName}({parametersString})";
        var result = await _context.Database.SqlQueryRaw<Type>(commandText, parameters).ToListAsync();
        return result.FirstOrDefault();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
