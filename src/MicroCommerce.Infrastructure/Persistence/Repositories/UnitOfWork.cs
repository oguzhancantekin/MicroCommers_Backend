using MicroCommerce.Domain.Interfaces;

namespace MicroCommerce.Infrastructure.Persistence.Repositories;

/// <summary>
/// Unit of Work implementation wrapping the ApplicationDbContext.
/// Coordinates SaveChanges across multiple repositories within a single transaction.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
