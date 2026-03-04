using Microsoft.AspNetCore.Identity;

namespace MicroCommerce.Domain.Entities;

/// <summary>
/// Custom user entity inheriting from ASP.NET Core IdentityUser.
/// Can be extended with additional properties in the future.
/// </summary>
public class ApplicationUser : IdentityUser
{
}
