using MediatR;

namespace MicroCommerce.Application.Features.Categories.Commands.CreateCategory;

/// <summary>
/// New category creation command.
/// </summary>
public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
