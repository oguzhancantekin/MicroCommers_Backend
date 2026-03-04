namespace MicroCommerce.Domain.Interfaces;

/// <summary>
/// Unit of Work pattern to coordinate multiple repository operations 
/// within a single database transaction.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
