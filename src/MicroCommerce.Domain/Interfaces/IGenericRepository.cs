using System.Linq.Expressions;
using MicroCommerce.Domain.Common;

namespace MicroCommerce.Domain.Interfaces;

/// <summary>
/// Generic repository interface providing standard CRUD operations.
/// Follows the Repository pattern for data access abstraction.
/// </summary>
/// <typeparam name="T">Entity type that extends BaseEntity</typeparam>
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
}
