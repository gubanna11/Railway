using Railway.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Railway.Infrastructure.Abstract.Interfaces;

public interface IUnitOfWork<T> where T : BaseEntity
{
    IGenericRepository<T> GenericRepository { get; }

    Task SaveAsync();
}
