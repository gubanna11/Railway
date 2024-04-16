using Railway.Core.Entities;
using System.Linq.Expressions;

namespace Railway.Core.Abstract.Interfaces;

public interface IGenericRepository<T>
    where T : BaseEntity
{
    IQueryable<T> Set { get; }

    Task<IEnumerable<T>> GetAllAsync();

    IEnumerable<T> GetAll(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
           params Expression<Func<T, object>>[] includeProperties);

    Task<T?> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    void Update(T entity);

    Task<T?> RemoveAsync(int id);

    void RemoveRange(IEnumerable<T> entities);
}

