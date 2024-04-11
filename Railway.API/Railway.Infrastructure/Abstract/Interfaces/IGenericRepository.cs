using Railway.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Abstract.Interfaces;

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

