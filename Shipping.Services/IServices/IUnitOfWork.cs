
using Shipping.Entities.Domain.Identity;

namespace Shipping.Services.IServices;

public interface IUnitOfWork<TEntity> : IDisposable
{
    Task CommitChangesAsync();
    Task AddUserAndEntity(ApplicationUser user, TEntity entity);
}
