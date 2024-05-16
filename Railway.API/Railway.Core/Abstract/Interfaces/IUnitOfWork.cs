using Railway.Core.Data;
using Railway.Core.Entities;

namespace Railway.Core.Abstract.Interfaces;

public interface IUnitOfWork<T> where T : BaseEntity
{
    IGenericRepository<T> GenericRepository { get; }

    IGenericRepository<Type> GetGenericRepository<Type>() where Type : BaseEntity;

    AppDbContext Context { get; }

    Task<IEnumerable<Type>> CallProcedureAsync<Type>(string procedureName, params object[] parameters);

    Task SaveAsync();
}
