using Railway.Core.Entities;

namespace Railway.Core.Abstract.Interfaces;

public interface IUnitOfWork<T> where T : BaseEntity
{
    IGenericRepository<T> GenericRepository { get; }

    IGenericRepository<Type> GetGenericRepository<Type>() where Type : BaseEntity;

    Task SaveAsync();
}
