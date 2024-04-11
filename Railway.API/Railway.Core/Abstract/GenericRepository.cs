using Microsoft.EntityFrameworkCore;
using Railway.Core.Abstract.Interfaces;
using Railway.Core.Data;
using Railway.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Railway.Core.Abstract;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _context;

    public IQueryable<T> Set { get; }

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        Set = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedEnumerable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Set;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T?> RemoveAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity is not null)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

        return null;
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
