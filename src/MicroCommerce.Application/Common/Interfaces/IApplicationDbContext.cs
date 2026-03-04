using MicroCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroCommerce.Application.Common.Interfaces;

/// <summary>
/// Abstraction for the database context used in the Application layer.
/// This ensures the Application layer has no direct dependency on EF Core implementation.
/// </summary>
public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Category> Categories { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
