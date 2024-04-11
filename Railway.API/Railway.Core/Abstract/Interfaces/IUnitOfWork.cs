using Railway.Core.Entities;
using System.Threading.Tasks;

namespace Railway.Core.Abstract.Interfaces;

public interface IUnitOfWork<T> where T : BaseEntity
{
    IGenericRepository<T> GenericRepository { get; }

    Task SaveAsync();
}
